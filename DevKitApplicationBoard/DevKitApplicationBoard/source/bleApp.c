/*
File:   bleApp.c
Author: Taylor Robbins
Date:   02\14\2018
Description: 
	** Handles running the bluetooth chip when the jumper is set to bluetooth mode
*/

#include "defines.h"
#include "bleApp.h"

#include "debug.h"
#include "bleResponses.h"
#include "uartFifos.h"
#include "bleCommands.h"
#include "tickTimer.h"

// +--------------------------------------------------------------+
// |                     Private Definitions                      |
// +--------------------------------------------------------------+
#define BLE_APP_STARTUP_RETRY_TIMEOUT 2000 //ms

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
bool BleAppRunning = false;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static bool configurationFinished = false;

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static void SetBleSettings()
{
	u8 advertisingData[] = { 0x12, 0x34, 0x56, 0x78, 0x90 };
	BleSetAdvertisingData(advertisingData, ArrayCount(advertisingData));
	const char* advertisingName = "Sure-Fi DevKit";
	BleSetAdvertisingName(advertisingName, (u8)strlen(advertisingName));
	BleSetStatusUpdateBits(BleFlags_AdvertisingBit|BleFlags_ConnectedBit|BleFlags_SureFiTxInProgressBit);
}

static void BleResetCallback()
{
	WriteLine_D("Reconfiguring bluetooth after it reset");
	SetBleSettings();
	BleGetFirmwareVersion();
	BleGetStatus();
	BleStartAdvertising();
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitializeBleApp()
{
	//TODO: Initialize something?
}

void BleAppStart()
{
	WriteLine_O("Starting BLE Application...");
	configurationFinished = false;
	
	SetBleResponseCallbacks(BleResetCallback);
	SetBleSettings();
	
	//We will make sure the bluetooth is present and responding by waiting for the
	//BleStatus response to come back. If the bluetooth doesn't respond we will
	//retry sending the settings until it does
	BleGotStatus = false;
	GenericCountdown[0] = BLE_APP_STARTUP_RETRY_TIMEOUT;
	BleGetFirmwareVersion();
	BleGetStatus();
	
	BleAppRunning = true;
}

void BleAppStop()
{
	WriteLine_O("Stopping BLE Application...");	
	
	SetBleResponseCallbacks(nullptr);
	BleStopAdvertising();
	
	BleAppRunning = false;
}

void BleAppUpdate()
{
	if (!configurationFinished)
	{
		if (BleGotStatus)
		{
			WriteLine_I("BLE app is ready!");
			configurationFinished = true;
			//continue on to the rest of the Update Loop
			BleStartAdvertising();
		}
		else
		{
			if (GenericCountdown[0] == 0)
			{
				WriteLine_E("BLE app configuration timeout. Resending...");
				
				SetBleSettings();
				BleGotStatus = false;
				GenericCountdown[0] = BLE_APP_STARTUP_RETRY_TIMEOUT;
				BleGetFirmwareVersion();
				BleGetStatus();
			}
			
			//Don't run the rest of the Update Loop if configuration is ongoing
			return;
		}
	}
	
	//TODO: Something to update?
}

