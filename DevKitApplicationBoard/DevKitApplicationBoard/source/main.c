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
#include "app.h"

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
	InitTransmitQueue();
	AppInitialize();
	
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
		UpdateTransmitQueue();
		if (AppRunning)
		{
			AppUpdate();
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
