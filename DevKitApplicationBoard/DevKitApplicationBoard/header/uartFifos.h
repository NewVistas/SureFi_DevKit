/*
File:   uartFifos.h
Author: Taylor Robbins
Date:   01\17\2018
*/

#ifndef _UART_FIFOS_H
#define _UART_FIFOS_H

// +--------------------------------------------------------------+
// |                         Public Types                         |
// +--------------------------------------------------------------+
typedef enum
{
	AppUart_DebugOutput = 0,
	AppUart_WindowsInterface,
	AppUart_SureFiRadio,
	AppUart_SureFiBle,
	AppUart_NumUarts,
} AppUart_t;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitializeUartFifos();
void UpdateUartFifos();

void AppUartSendData(AppUart_t uart, const u8* dataPntr, u16 numBytes);
void AppUartSendString(AppUart_t uart, const char* str);
void AppUartPrintString(AppUart_t uart, const char* formatStr, ...);

u16 AppUartGetRxNumBytes(AppUart_t uart);
u8 AppUartGetRxByte(AppUart_t uart, u16 index);
u8 AppUartPopRxByte(AppUart_t uart);
bool AppUartPopCommand(AppUart_t uart, u8* bufferOut, bool allowAltAttn);

void PrintRadioUartHistory();
void ClearRadioUartHistory();

#endif //  _UART_FIFOS_H
