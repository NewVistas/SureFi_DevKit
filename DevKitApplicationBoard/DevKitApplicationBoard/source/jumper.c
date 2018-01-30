/*
File:   jumper.c
Author: Taylor Robbins
Date:   01\22\2018
Description: 
	** Handles the jumper input on the Dev-Kit application board
*/

#include "defines.h"
#include "jumper.h"

#include "micro.h"
#include "debug.h"
#include "tickTimer.h"
#include "app.h"

// +--------------------------------------------------------------+
// |                     Private Definitions                      |
// +--------------------------------------------------------------+
#define JUMPER_DEBOUNCE_TIME 1000 //ms

// +--------------------------------------------------------------+
// |              Private Structure/Type Definitions              |
// +--------------------------------------------------------------+
enum
{
	JumperBit_Embedded  = 0x01,
	JumperBit_Windows   = 0x02,
	JumperBit_Bluetooth = 0x04,
};

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 jumperStatus = 0x00;

static const char* GetJumperBitStr(u8 jumperBit)
{
	switch (jumperBit)
	{
		case JumperBit_Embedded:  return "Embedded";
		case JumperBit_Windows:   return "Windows";
		case JumperBit_Bluetooth: return "Bluetooth";
		default: return "Unknown";
	};
}

static u8 GetJumperStatus()
{
	u8 result = 0x00;
	
	if (GetPinInputValue(MODE1_JUMPER_PORT, MODE1_JUMPER_MASK) == false)
	{
		result |= JumperBit_Embedded;
	}
	if (GetPinInputValue(MODE2_JUMPER_PORT, MODE2_JUMPER_MASK) == false)
	{
		result |= JumperBit_Windows;
	}
	if (GetPinInputValue(MODE3_JUMPER_PORT, MODE3_JUMPER_MASK) == false)
	{
		result |= JumperBit_Bluetooth;
	}
	
	return result;
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void UpdateJumper()
{
	u8 newJumperStatus = GetJumperStatus();
	if (newJumperStatus != jumperStatus && JumperDebounceCountdown == 0)
	{
		u8 changedBits = (newJumperStatus ^ jumperStatus);
		
		if (IsFlagSet(changedBits, JumperBit_Embedded))
		{
			bool enabled = IsFlagSet(newJumperStatus, JumperBit_Embedded);
			PrintLine_I("%s Mode %s", GetJumperBitStr(JumperBit_Embedded), enabled ? "Enabled" : "Disabled");
			SetPinValue(POWER_LED_PORT, POWER_LED_MASK, enabled ? LED_ON : LED_OFF);
			
			if (enabled && !AppRunning)
			{
				AppStart();
			}
			else if (!enabled && AppRunning)
			{
				AppStop();
			}
		}
		
		if (IsFlagSet(changedBits, JumperBit_Windows))
		{
			bool enabled = IsFlagSet(newJumperStatus, JumperBit_Windows);
			PrintLine_I("%s Mode %s", GetJumperBitStr(JumperBit_Windows), enabled ? "Enabled" : "Disabled");
			SetPinValue(DEBUG_LED1_PORT, DEBUG_LED1_MASK, enabled ? LED_ON : LED_OFF);
		}
		
		if (IsFlagSet(changedBits, JumperBit_Bluetooth))
		{
			bool enabled = IsFlagSet(newJumperStatus, JumperBit_Bluetooth);
			PrintLine_I("%s Mode %s", GetJumperBitStr(JumperBit_Bluetooth), enabled ? "Enabled" : "Disabled");
			SetPinValue(DEBUG_LED2_PORT, DEBUG_LED2_MASK, enabled ? LED_ON : LED_OFF);
		}
		
		JumperDebounceCountdown = JUMPER_DEBOUNCE_TIME;
		jumperStatus = newJumperStatus;
	}
}

bool EmbeddedModeEnabled()
{
	return (jumperStatus & JumperBit_Embedded);
}

bool WindowsModeEnabled()
{
	return (jumperStatus & JumperBit_Windows);
}

bool BluetoothModeEnabled()
{
	return (jumperStatus & JumperBit_Bluetooth);
}
