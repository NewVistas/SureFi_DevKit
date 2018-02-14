/*
File:   uartFifos.c
Author: Taylor Robbins
Date:   01\17\2018
Description: 
	** Holds our own UART hardware abstraction layer
	** We have two FIFO buffers for each supported UART (one for Rx and one for Tx)
	** We handle pushing and pulling off these FIFOs in order to safely get data on and off the bus.
	** We also handle UART routing based off the jumper position in HandleInterrupt
*/

#include "defines.h"
#include "uartFifos.h"

#include <stdarg.h>
#include "micro.h"
#include "jumper.h"
#include "debug.h"

// +--------------------------------------------------------------+
// |                     Private Definitions                      |
// +--------------------------------------------------------------+
#define APP_FIFO_BUFFER_SIZE   2048
#define UART_PRINT_BUFFER_SIZE 1024
#define MAX_HISTORY_LENGTH     64

// +--------------------------------------------------------------+
// |                        Private Types                         |
// +--------------------------------------------------------------+
typedef struct __attribute__((packed))
{
	volatile u16 head;
	volatile u16 tail;
	u8 data[APP_FIFO_BUFFER_SIZE];
} Fifo_t;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static Fifo_t RxFifos[AppUart_NumUarts];
static Fifo_t TxFifos[AppUart_NumUarts];
//These two FIFOs are for debug readout purposes
static Fifo_t RxHistoryFifo;
static Fifo_t TxHistoryFifo;
static char uartPrintBuffer[UART_PRINT_BUFFER_SIZE];

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static bool UartIsTxReady(AppUart_t uart)
{
	if (uart == AppUart_DebugOutput)      { return usart_is_tx_ready(USART1); }
	if (uart == AppUart_WindowsInterface) { return usart_is_tx_ready(USART0); }
	if (uart == AppUart_SureFiRadio)      { return uart_is_tx_ready (UART0);  }
	if (uart == AppUart_SureFiBle)        { return uart_is_tx_ready (UART1);  }
	return true;
}

static void UartPutByte(AppUart_t uart, u8 newByte)
{
	if (uart == AppUart_DebugOutput)      { usart_write(USART1, newByte); }
	if (uart == AppUart_WindowsInterface) { usart_write(USART0, newByte); }
	if (uart == AppUart_SureFiRadio)      { uart_write (UART0,  newByte); }
	if (uart == AppUart_SureFiBle)        { uart_write (UART1,  newByte); }
}

static bool UartIsRxReady(AppUart_t uart)
{
	if (uart == AppUart_DebugOutput)      { return usart_is_rx_ready(USART1); }
	if (uart == AppUart_WindowsInterface) { return usart_is_rx_ready(USART0); }
	if (uart == AppUart_SureFiRadio)      { return uart_is_rx_ready (UART0);  }
	if (uart == AppUart_SureFiBle)        { return uart_is_rx_ready (UART1);  }
	return false;
}

static u8 UartGetByte(AppUart_t uart)
{
	u8 result = 0x00;
	u32 result32 = 0x00000000;
	if (uart == AppUart_DebugOutput)      { usart_read(USART1, &result32); result = (u8)result32; }
	if (uart == AppUart_WindowsInterface) { usart_read(USART0, &result32); result = (u8)result32; }
	if (uart == AppUart_SureFiRadio)      { uart_read (UART0,  &result);  }
	if (uart == AppUart_SureFiBle)        { uart_read (UART1,  &result);  }
	return result;
}

static void UartEnableTxInterrupt(AppUart_t uart)
{
	if (uart == AppUart_DebugOutput)      { usart_enable_interrupt(USART1, US_IER_TXRDY); }
	if (uart == AppUart_WindowsInterface) { usart_enable_interrupt(USART0, US_IER_TXRDY); }
	if (uart == AppUart_SureFiRadio)      { uart_enable_interrupt(UART0, UART_IER_TXRDY); }
	if (uart == AppUart_SureFiBle)        { uart_enable_interrupt(UART1, UART_IER_TXRDY); }
}

static void UartDisableTxInterrupt(AppUart_t uart)
{
	if (uart == AppUart_DebugOutput)      { usart_disable_interrupt(USART1, US_IER_TXRDY); }
	if (uart == AppUart_WindowsInterface) { usart_disable_interrupt(USART0, US_IER_TXRDY); }
	if (uart == AppUart_SureFiRadio)      { uart_disable_interrupt(UART0, UART_IER_TXRDY); }
	if (uart == AppUart_SureFiBle)        { uart_disable_interrupt(UART1, UART_IER_TXRDY); }
}

static inline u16 GetFifoLength(Fifo_t* fifoPntr)
{
	if (fifoPntr->tail <= fifoPntr->head)
	{
		return fifoPntr->head - fifoPntr->tail;
	}
	else
	{
		return (ArrayCount(fifoPntr->data) - fifoPntr->tail) + fifoPntr->head;
	}
}
static inline bool FifoPush(Fifo_t* fifoPntr, u8 newByte, bool force)
{
	u16 newHead = (fifoPntr->head+1) % (ArrayCount(fifoPntr->data));
	if (newHead == fifoPntr->tail)
	{
		//No room in the buffer
		if (force)
		{
			//push the tail forward
			fifoPntr->tail = (fifoPntr->tail+1) % (ArrayCount(fifoPntr->data));
		}
		else 
		{
			//drop the new byte
			return false;
		}
	}
	
	fifoPntr->data[fifoPntr->head] = newByte;
	fifoPntr->head = newHead;
	return true;
}
static inline u8 FifoPop(Fifo_t* fifoPntr)
{
	u8 result;
	Assert(GetFifoLength(fifoPntr) > 0);
	
	result = fifoPntr->data[fifoPntr->tail];
	fifoPntr->tail = (fifoPntr->tail+1) % ArrayCount(fifoPntr->data);
	
	return result;
}
static inline u8 FifoGetByte(Fifo_t* fifoPntr, u16 index) 
{
	u16 step = 0;
	u16 bIndex = fifoPntr->tail;
	while (step < index && bIndex != fifoPntr->head)
	{
		bIndex++;
		if (bIndex >= ArrayCount(fifoPntr->data)) { bIndex = 0; }
		step++;
	}
	
	if (bIndex == fifoPntr->head) { return 0x00; }
	else { return fifoPntr->data[bIndex]; }
}

static void HandleInterrupt(AppUart_t uart)
{
	Fifo_t* fifoRx = &RxFifos[uart];
	Fifo_t* fifoTx = &TxFifos[uart];
	
	while (UartIsRxReady(uart))
	{
		u8 newByte = UartGetByte(uart);
		
		bool pushSuccess = FifoPush(fifoRx, newByte, false);
		if (pushSuccess == false)
		{
			AppUartSendString(AppUart_DebugOutput, "[R!]");
		}
		
		// if (uart == AppUart_WindowsInterface && WindowsModeEnabled())
		// {
		// 	FifoPush(&TxFifos[AppUart_SureFiRadio], newByte, false);
		// 	UartEnableTxInterrupt(AppUart_SureFiRadio);
		// }
		// if (uart == AppUart_SureFiBle && BluetoothModeEnabled())
		// {
		// 	FifoPush(&TxFifos[AppUart_SureFiRadio], newByte, false);
		// 	UartEnableTxInterrupt(AppUart_SureFiRadio);
		// }
		if (uart == AppUart_SureFiRadio)
		{
			// if (WindowsModeEnabled())
			// {
			// 	FifoPush(&TxFifos[AppUart_WindowsInterface], newByte, false);
			// 	UartEnableTxInterrupt(AppUart_WindowsInterface);
			// }
			// if (BluetoothModeEnabled())
			// {
			// 	FifoPush(&TxFifos[AppUart_SureFiBle], newByte, false);
			// 	UartEnableTxInterrupt(AppUart_SureFiBle);
			// }
			
			//Record incoming byte on the RxHistoryFifo
			FifoPush(&RxHistoryFifo, newByte, true);
		}
	}
	
	if (GetFifoLength(fifoTx) > 0 && UartIsTxReady(uart))
	{
		u8 nextByte = FifoPop(fifoTx);
		UartPutByte(uart, nextByte);
		
		//Record outgoing byte on the TxHistoryFifo
		if (uart == AppUart_SureFiRadio)
		{
			FifoPush(&TxHistoryFifo, nextByte, true);
		}
		
		if (GetFifoLength(fifoTx) == 0)
		{
			UartDisableTxInterrupt(uart);
		}
	}
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+

void InitializeUartFifos()
{
	ClearArray(RxFifos);
	ClearArray(TxFifos);
	ClearStruct(RxHistoryFifo);
	ClearStruct(TxHistoryFifo);
	
	// +==============================+
	// |     UART0 Initialization     |
	// +==============================+
	{
		//Map to pins PA9 and PA10
		ioport_set_port_mode(IOPORT_PIOA, PIO_PA9A_URXD0 | PIO_PA10A_UTXD0, IOPORT_MODE_MUX_A);
		ioport_disable_port(IOPORT_PIOA, PIO_PA9A_URXD0 | PIO_PA10A_UTXD0);
		
		sam_uart_opt_t uartOptions;
		uartOptions.ul_mck = SystemCoreClock;
		uartOptions.ul_baudrate = 115200;
		uartOptions.ul_mode = (UART_MR_PAR_NO | UART_MR_CHMODE_NORMAL);
		uart_init(UART0, &uartOptions);
		uart_enable_tx(UART0);
		uart_enable_rx(UART0);
		uart_enable(UART0);
		
		NVIC_EnableIRQ(UART0_IRQn);
		uart_enable_interrupt(UART0, UART_IER_RXRDY);
		//NOTE: We will wait to enable UART_IER_TXRDY until we actually have data to send
	}
	
	// +==============================+
	// |     UART1 Initialization     |
	// +==============================+
	{
		//Map to pins PB2 and PB3
		ioport_set_port_mode(IOPORT_PIOB, PIO_PB2A_URXD1 | PIO_PB3A_UTXD1, IOPORT_MODE_MUX_A);
		ioport_disable_port(IOPORT_PIOB, PIO_PB2A_URXD1 | PIO_PB3A_UTXD1);
		
		sam_uart_opt_t uartOptions;
		uartOptions.ul_mck = SystemCoreClock;
		uartOptions.ul_baudrate = 115200;
		uartOptions.ul_mode = (UART_MR_PAR_NO | UART_MR_CHMODE_NORMAL);
		uart_init(UART1, &uartOptions);
		uart_enable_tx(UART1);
		uart_enable_rx(UART1);
		uart_enable(UART1);
		
		NVIC_EnableIRQ(UART1_IRQn);
		uart_enable_interrupt(UART1, UART_IER_RXRDY);
		//NOTE: We will wait to enable US_IER_TXRDY until we actually have data to send
	}
	
	// +==============================+
	// |    USART0 Initialization     |
	// +==============================+
	{
		//Map to pins PA5 and PA6
		ioport_set_port_mode(IOPORT_PIOA, PIO_PA5A_RXD0 | PIO_PA6A_TXD0, IOPORT_MODE_MUX_A);
		ioport_disable_port (IOPORT_PIOA, PIO_PA5A_RXD0 | PIO_PA6A_TXD0);
		
		sam_usart_opt_t usartOptions;
		usartOptions.baudrate     = 115200;
		usartOptions.char_length  = US_MR_CHRL_8_BIT;
		usartOptions.parity_type  = US_MR_PAR_NO;
		usartOptions.stop_bits    = US_MR_NBSTOP_1_BIT;
		usartOptions.channel_mode = US_MR_CHMODE_NORMAL;
		usartOptions.irda_filter  = 0x00;
		usart_init_rs232(USART0, &usartOptions, SystemCoreClock);
		usart_enable_tx(USART0);
		usart_enable_rx(USART0);
		
		NVIC_EnableIRQ(USART0_IRQn);
		usart_enable_interrupt(USART0, US_IER_RXRDY);
		//NOTE: We will wait to enable US_IER_TXRDY until we actually have data to send
	}
	
	// +==============================+
	// |    USART1 Initialization     |
	// +==============================+
	{
		//Map to pins PA21 and PA22
		ioport_set_port_mode(IOPORT_PIOA, PIO_PA21A_RXD1 | PIO_PA22A_TXD1, IOPORT_MODE_MUX_A);
		ioport_disable_port (IOPORT_PIOA, PIO_PA21A_RXD1 | PIO_PA22A_TXD1);
		
		sam_usart_opt_t usartOptions;
		usartOptions.baudrate     = 115200;
		usartOptions.char_length  = US_MR_CHRL_8_BIT;
		usartOptions.parity_type  = US_MR_PAR_NO;
		usartOptions.stop_bits    = US_MR_NBSTOP_1_BIT;
		usartOptions.channel_mode = US_MR_CHMODE_NORMAL;
		usartOptions.irda_filter  = 0x00;
		usart_init_rs232(USART1, &usartOptions, SystemCoreClock);
		usart_enable_tx(USART1);
		usart_enable_rx(USART1);
		
		NVIC_EnableIRQ(USART1_IRQn);
		usart_enable_interrupt(USART1, US_IER_RXRDY);
		//NOTE: We will wait to enable US_IER_TXRDY until we actually have data to send
	}
}

void UpdateUartFifos()
{
	// +==========================================+
	// | Pop Bytes off History if it's Oversized  |
	// +==========================================+
	while (GetFifoLength(&RxHistoryFifo) > MAX_HISTORY_LENGTH)
	{
		FifoPop(&RxHistoryFifo);
	}
	while (GetFifoLength(&TxHistoryFifo) > MAX_HISTORY_LENGTH)
	{
		FifoPop(&TxHistoryFifo);
	}
}



void AppUartSendData(AppUart_t uart, const u8* dataPntr, u16 numBytes)
{
	Assert(uart < AppUart_NumUarts);
	
	MicroDisableInterrupts();
	Fifo_t* fifoTx = &TxFifos[uart];
	u16 bIndex = 0;
	for (bIndex = 0; bIndex < numBytes; bIndex++)
	{
		bool pushSuccess = FifoPush(fifoTx, dataPntr[bIndex], false);
		if (!pushSuccess && uart != AppUart_DebugOutput)
		{
			AppUartSendString(AppUart_DebugOutput, "[O!]");
		}
	}
	MicroEnableInterrupts();
	
	UartEnableTxInterrupt(uart);
}

void AppUartSendString(AppUart_t uart, const char* str)
{
	AppUartSendData(uart, (u8*)str, (u16)strlen(str));
}

void AppUartPrintString(AppUart_t uart, const char* formatStr, ...)
{
	va_list vargs;
	
	va_start(vargs, formatStr);
	int printResult = vsnprintf(uartPrintBuffer, UART_PRINT_BUFFER_SIZE, formatStr, vargs);
	va_end(vargs);
	
	if (printResult >= UART_PRINT_BUFFER_SIZE && uart != AppUart_DebugOutput)
	{
		AppUartSendString(AppUart_DebugOutput, "[P!]");
	}
	else
	{
		uartPrintBuffer[ArrayCount(uartPrintBuffer)-1] = '\0'; //Make sure null-terminator is there
		AppUartSendString(uart, uartPrintBuffer);
	}
}



u16 AppUartGetRxNumBytes(AppUart_t uart)
{
	Fifo_t* fifoRx = &RxFifos[uart];
	u16 fifoLength = GetFifoLength(fifoRx);
	return fifoLength;
}

u8 AppUartGetRxByte(AppUart_t uart, u16 index)
{
	Fifo_t* fifoRx = &RxFifos[uart];
	u8 result = FifoGetByte(fifoRx, index);
	return result;
}

u8 AppUartPopRxByte(AppUart_t uart)
{
	Fifo_t* fifoRx = &RxFifos[uart];
	u8 result = FifoPop(fifoRx);
	return result;
}

bool AppUartPopCommand(AppUart_t uart, u8* bufferOut, bool allowAltAttn)
{
	u8 cmdLength = 0x00;
	u16 cmdIndex = 0;
	u16 bIndex = 0;
	
	while (bIndex < AppUartGetRxNumBytes(uart))
	{
		u8 nextByte = AppUartGetRxByte(uart, bIndex);
		if (cmdIndex == 0)
		{
			if (nextByte == ATTN_CHAR || (allowAltAttn && nextByte == BLE_ATTN_CHAR))
			{
				if (bufferOut != nullptr) { bufferOut[cmdIndex] = nextByte; }
				cmdIndex++;
				bIndex++;
			}
			else
			{
				AppUartPopRxByte(uart);
			}
		}
		else
		{
			Assert(cmdIndex <= SURE_COMMAND_HEADER_SIZE+255);
			if (bufferOut != nullptr) { bufferOut[cmdIndex] = nextByte; }
			if (cmdIndex == 2) { cmdLength = nextByte; }
			cmdIndex++;
			bIndex++;
		}
		
		if (cmdIndex >= SURE_COMMAND_HEADER_SIZE && cmdIndex >= SURE_COMMAND_HEADER_SIZE+cmdLength)
		{
			//Pop the bytes off the FIFO
			while (bIndex > 0) { AppUartPopRxByte(uart); bIndex--; }
			return true;
		}
	}
	
	return false;
}



void PrintRadioUartHistory()
{
	u16 bIndex = 0;
	
	PrintLine_O("Tx %u bytes: (Oldest->Newest)", GetFifoLength(&TxHistoryFifo));
	for (bIndex = 0; bIndex < GetFifoLength(&TxHistoryFifo); bIndex++)
	{
		u8 nextByte = FifoGetByte(&TxHistoryFifo, bIndex);
		if (nextByte == ATTN_CHAR && bIndex > 0)
		{
			Write_I("\n");
		}
		Print_I("%02X ", nextByte);
	}
	WriteLine_I("");
	WriteLine_I("");
	
	PrintLine_O("Rx %u bytes: (Oldest->Newest)", GetFifoLength(&RxHistoryFifo));
	for (bIndex = 0; bIndex < GetFifoLength(&RxHistoryFifo); bIndex++)
	{
		u8 nextByte = FifoGetByte(&RxHistoryFifo, bIndex);
		if (nextByte == ATTN_CHAR && bIndex > 0)
		{
			Write_I("\n");
		}
		Print_I("%02X ", nextByte);
	}
	WriteLine_I("");
	WriteLine_I("");
}

void ClearRadioUartHistory()
{
	while (GetFifoLength(&RxHistoryFifo) > 0)
	{
		FifoPop(&RxHistoryFifo);
	}
	while (GetFifoLength(&TxHistoryFifo) > 0)
	{
		FifoPop(&TxHistoryFifo);
	}
}

// +--------------------------------------------------------------+
// |                  Interrupt Service Routines                  |
// +--------------------------------------------------------------+
void UART0_Handler(void)
{
	HandleInterrupt(AppUart_SureFiRadio);
}

void UART1_Handler(void)
{
	HandleInterrupt(AppUart_SureFiBle);
}

void USART0_Handler(void)
{
	HandleInterrupt(AppUart_WindowsInterface);
}

void USART1_Handler(void)
{
	HandleInterrupt(AppUart_DebugOutput);
}

