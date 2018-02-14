/*
File:   main.c
Author: Taylor Robbins
Date:   01\16\2018
Description: 
	** Contains the main entry point for the whole program
*/

#include "defines.h"

#include "uart.h"
#include "ioport.h"
#include "sysclk.h"

#include "version.h"
#include "micro.h"
#include "uartFifos.h"
#include "debug.h"
#include "debugCommands.h"
#include "jumper.h"
#include "tickTimer.h"
#include "sureResponses.h"
#include "transmitQueue.h"
#include "bleResponses.h"
#include "app.h"
#include "bleApp.h"

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 cmdBuffer[SURE_COMMAND_HEADER_SIZE + 255];

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static void ProcessBleCommandsAndResponses()
{
	while (AppUartPopCommand(AppUart_SureFiBle, cmdBuffer, true))
	{
		if (cmdBuffer[0] == ATTN_CHAR)
		{
			SureCommand_t* cmdPntr = (SureCommand_t*)cmdBuffer;
			if (BluetoothModeEnabled())
			{
				//In bluetooth mode we route all normal commands to the radio so you can
				//control the Sure-Fi radio using a phone application.
				AppUartSendData(AppUart_SureFiRadio, cmdBuffer, SURE_COMMAND_HEADER_SIZE + cmdPntr->length);
			}
			else
			{
				PrintLine_D("Got %u byte CMD from phone 0x%02X", cmdPntr->length, cmdPntr->cmd);
			}
		}
		else if (cmdBuffer[0] == BLE_ATTN_CHAR)
		{
			//Commands prefixed with the BLE_ATTN_CHAR are for us to process and should not be sent to the radio
			BleCommand_t* cmdPntr = (BleCommand_t*)&cmdBuffer[0];
			HandleBleResponse(cmdPntr);
		}
		else { Assert(false); } //this should never happen
	}
}

static void ProcessWindowsCommands()
{
	while (AppUartPopCommand(AppUart_WindowsInterface, cmdBuffer, false))
	{
		if (cmdBuffer[0] == ATTN_CHAR)
		{
			SureCommand_t* cmdPntr = (SureCommand_t*)cmdBuffer;
			if (WindowsModeEnabled())
			{
				//In windows mode we route all commands to the radio so you can
				//control the Sure-Fi radio using a the windows application
				AppUartSendData(AppUart_SureFiRadio, cmdBuffer, SURE_COMMAND_HEADER_SIZE + cmdPntr->length);
			}
			else
			{
				PrintLine_D("Got %u byte CMD from windows 0x%02X", cmdPntr->length, cmdPntr->cmd);
			}
		}
		else { Assert(false); } //this should never happen
	}
}

static void ProcessRadioResponses()
{
	while (AppUartPopCommand(AppUart_SureFiRadio, cmdBuffer, false))
	{
		if (cmdBuffer[0] == ATTN_CHAR)
		{
			SureCommand_t* rspPntr = (SureCommand_t*)cmdBuffer;
			if (BluetoothModeEnabled())
			{
				//If bluetooth is enabled then route radio responses to it
				AppUartSendData(AppUart_SureFiBle, cmdBuffer, SURE_COMMAND_HEADER_SIZE + rspPntr->length);
			}
			if (WindowsModeEnabled())
			{
				//If windows is enabled then route radio responses to it
				AppUartSendData(AppUart_WindowsInterface, cmdBuffer, SURE_COMMAND_HEADER_SIZE + rspPntr->length);
			}
			
			HandleRadioResponse(rspPntr);
		}
		else { Assert(false); } //this should never happen
	}
}

// +--------------------------------------------------------------+
// |                       Main Entry Point                       |
// +--------------------------------------------------------------+
int main(void)
{
	// +==============================+
	// |        Initialization        |
	// +==============================+
	MicroDisableInterrupts();
	
	sysclk_init();
	SystemCoreClockUpdate();
	ioport_init();
	MicroInit();
	InitializeUartFifos();
	InitializeTickTimer();
	InitRadioResponses();
	InitBleResponses();
	InitTransmitQueue();
	AppInitialize();
	InitializeBleApp();
	
	MicroEnableInterrupts();
	
	WriteLine_O("+==============================+");
	WriteLine_O("|       Sure-Fi Dev-Kit        |");
	WriteLine_O("+==============================+");
	PrintLine_D("Version %u.%u(%u)", VERSION_MAJOR, VERSION_MINOR, VERSION_BUILD);
	SetPinValue(POWER_LED_PORT,  POWER_LED_MASK,  LED_OFF);
	SetPinValue(DEBUG_LED1_PORT, DEBUG_LED1_MASK, LED_OFF);
	SetPinValue(DEBUG_LED2_PORT, DEBUG_LED2_MASK, LED_OFF);
	PrintLine_D("SystemCoreClock: %uMHz", sysclk_get_peripheral_bus_hz(TC0));
	
	// +==============================+
	// |          Main Loop           |
	// +==============================+
	while (FOREVER) 
	{
		ResetWatchdog();
		UpdateUartFifos();
		UpdateDebugInput();
		UpdateJumper();
		ProcessRadioResponses();
		ProcessBleCommandsAndResponses();
		ProcessWindowsCommands();
		UpdateTransmitQueue();
		if (AppRunning)
		{
			AppUpdate();
		}
		if (BleAppRunning)
		{
			BleAppUpdate();
		}
		
		// +==============================+
		// |     Debug Input Commands     |
		// +==============================+
		if (DebugInputReady())
		{
			const char* commandStr = GetDebugInput(nullptr);
			PrintLine_O("Input >> \"%s\"", commandStr);
			
			HandleDebugCommand(commandStr);
			
			ClearDebugInput();
		}
		
		// QuickDelay();
	}
}
