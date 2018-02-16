/*
File:   micro.c
Author: Taylor Robbins
Date:   01\17\2018
Description: 
	** Holds a lot of the microcontroller specific initialization and functions 
*/

#include "defines.h"
#include "micro.h"

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void MicroInit()
{
	UnlockPowerManagementController();
	//Enable the peripheral clocks on all the peripherals we need
	PMC->PMC_PCER0 = ((1<<ID_PIOA) | (1<<ID_PIOB) | (1<<ID_UART0) | (1<<ID_UART1) | (1<<ID_USART0) | (1<<ID_USART1));
	LockPowerManagementController();
	
	MATRIX->CCFG_SYSIO |= (DEBUG_LED2_MASK);
	
	ConfigureOutput(DEBUG_LED1_PORT, DEBUG_LED1_MASK, LED_OFF);
	ConfigureOutput(DEBUG_LED2_PORT, DEBUG_LED2_MASK, LED_OFF);
	ConfigureOutput(POWER_LED_PORT,  POWER_LED_MASK,  LED_OFF);
	ConfigureInput (MODE1_JUMPER_PORT, MODE1_JUMPER_MASK, DISABLED, ENABLED);
	ConfigureInput (MODE2_JUMPER_PORT, MODE2_JUMPER_MASK, DISABLED, ENABLED);
	ConfigureInput (MODE3_JUMPER_PORT, MODE3_JUMPER_MASK, DISABLED, ENABLED);
	ConfigureInput (RADIO_INT_BUSY_PORT, RADIO_INT_BUSY_MASK, ENABLED, DISABLED);
	ConfigureInput (BLE_CONNECTED_PORT,  BLE_CONNECTED_MASK,  ENABLED, DISABLED);
}

void QuickDelay()
{
	uint32_t counter;
	for (counter = 0; counter < 200000; counter++)
	{
		__NOP();
	}
}

void ResetWatchdog()
{
	WDT->WDT_CR = WDT_CR_KEY_PASSWD | WDT_CR_WDRSTT;
}

void MicroEnableInterrupts()
{
	Enable_global_interrupt();
}

void MicroDisableInterrupts()
{
	Disable_global_interrupt();
}
