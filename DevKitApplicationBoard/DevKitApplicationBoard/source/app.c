/*
File:   app.c
Author: Taylor Robbins
Date:   01\26\2018
Description: 
	** An example embedded application for the Sure-Fi Radio Module 
*/

#include "defines.h"
#include "app.h"

#include "micro.h"
#include "debug.h"
#include "sureResponses.h"
#include "sureCommands.h"
#include "tickTimer.h"
#include "transmitQueue.h"

// +--------------------------------------------------------------+
// |                     Private Definitions                      |
// +--------------------------------------------------------------+
#define APP_STARTUP_RETRY_TIMEOUT 2000 //ms
#define APP_BUTTON_DEBOUNCE_TIME  50 //ms

#define APP_UID_SIZE     3 //bytes
#define APP_PAYLOAD_SIZE 4 //bytes
#define APP_PACKET_SIZE  (APP_UID_SIZE+APP_PAYLOAD_SIZE) //bytes
#define APP_FHSS_TABLE   200

enum
{
	AppCmd_Ping = 0x00,
	AppCmd_ButtonStatus,
	AppCmd_ModuleButtonStatus,
	AppCmd_StatusUpdate,
};

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
bool AppRunning = false;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static bool buttonWasDown = false;
static bool configurationFinished = false;
static bool ourButtonDown = false;
static bool ourModuleButtonDown = false;
static bool otherButtonDown = false;
static bool otherModuleButtonDown = false;

#if 0
static const u8 rxUid[APP_UID_SIZE] = { 0x10, 0x00, 0x01 };
static const u8 txUid[APP_UID_SIZE] = { 0x20, 0x00, 0x01 };
#else
static const u8 rxUid[APP_UID_SIZE] = { 0x20, 0x00, 0x01 };
static const u8 txUid[APP_UID_SIZE] = { 0x10, 0x00, 0x01 };
#endif

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static void UpdateIndications()
{
	u8 leds[6] = {Indication_Off, Indication_Off, Indication_Off, Indication_Off, Indication_Off, Indication_Off};
	
	if (otherButtonDown)
	{
		leds[0] = Indication_On;
		leds[1] = Indication_On;
		leds[2] = Indication_On;
	}
	
	if (otherModuleButtonDown)
	{
		leds[3] = Indication_On;
		leds[4] = Indication_On;
		leds[5] = Indication_On;
	}
	
	SureSetIndications(leds[0], leds[1], leds[2], leds[3], leds[4], leds[5]);
}

static void UpdateAckData()
{
	u8 payloadBuffer[APP_PAYLOAD_SIZE];
	ClearArray(payloadBuffer);
	payloadBuffer[0] = AppCmd_StatusUpdate;
	payloadBuffer[1] = (ourButtonDown ? 0x01 : 0x00);
	payloadBuffer[2] = (ourModuleButtonDown ? 0x01 : 0x00);
	SureSetAckData(APP_PAYLOAD_SIZE, payloadBuffer);
}

static void SetModuleSettings()
{
	SureDefaultSettings();
	SureQosLightshow();
	
	SureWriteConfig(ConfigFlags_AutoClearFlagsBit);
	SureSetReceivePacketSize(APP_PACKET_SIZE);
	SureSetReceiveUID(APP_UID_SIZE, rxUid);
	SureSetTransmitUID(APP_UID_SIZE, txUid);
	SureSetFhssTable(APP_FHSS_TABLE);
	SureSetQosConfig(QosConfig_Manual);
	SureSetButtonConfig(1, ButtonConfig_NoAction);
	
	SureClearFlags(0xFF);
	ModuleStatus_t intEnableBits = { .fullValue = 0x00000000 };
	intEnableBits.stateFlags = (StateFlags_BusyBit | StateFlags_RadioStateBits | StateFlags_RxInProgressBit);
	intEnableBits.otherFlags = (OtherFlags_ButtonDownBit);
	intEnableBits.clearableFlags = (ClearableFlags_TransmitFinishedBit | ClearableFlags_RxPacketReadyBit | ClearableFlags_AckPacketReadyBit);
	SureSetIntEnableBits(intEnableBits.fullValue);
	
	SureGetStatus();
}

static void ProcessPayload(bool isAck, const u8* payloadPntr)
{
	u8 cmd = payloadPntr[0];
	const u8* payload = &payloadPntr[1];
	
	switch (cmd)
	{
		case AppCmd_Ping:
		{
			WriteLine_I("Got ping!");
		} break;
		
		case AppCmd_ButtonStatus:
		{
			otherButtonDown = (payload[0] != 0x00);
			UpdateIndications();
			PrintLine_O("Got Button %s!", otherButtonDown ? "Press" : "Release");
		} break;
		
		case AppCmd_ModuleButtonStatus:
		{
			otherModuleButtonDown = (payload[0] != 0x00);
			UpdateIndications();
			PrintLine_O("Got Module Button %s!", otherModuleButtonDown ? "Press" : "Release");
		} break;
		
		case AppCmd_StatusUpdate:
		{
			otherButtonDown = (payload[0] != 0x00);
			otherModuleButtonDown = (payload[1] != 0x00);
			UpdateIndications();
			PrintLine_O("Got status update (%s)(%s)",
				otherButtonDown ? "Down" : "Up", otherModuleButtonDown ? "Down" : "Up");
		} break;
		
		default:
		{
			PrintLine_E("Got unknown app command in packet: 0x%02X", cmd);
		} break;
	}
}

static void ModuleResetCallback()
{
	WriteLine_D("Resetting module settings for app");
	SetModuleSettings();
	UpdateAckData();
}

static void TransmitFinishedCallback(u8 sentPayloadSize, const u8* sentPayload,
	const TransmitInfo_t* txInfo, u8 ackDataLength, const u8* ackData)
{
	if (txInfo == nullptr)
	{
		WriteLine_E("Something went wrong during transmit!");
		//NOTE: This can happen if the transmitQueue receives a failure response
		//		from the module while it was trying to transmit your packet.
		//		This should be debugged using the debug output of the failure response it received
		
		//TODO: Any handling that should happen?
		
		//There's nothing to process so return early
		return;
	}
	
	if (txInfo->success)
	{
		PrintLine_I("Transmit Succeeded! (%d, %d) %u retries", txInfo->rssi, txInfo->snr, txInfo->numRetries);
	}
	else
	{
		PrintLine_E("Transmit Failed! (%d, %d) %u retries", txInfo->rssi, txInfo->snr, txInfo->numRetries);
	}
	
	if (ackDataLength > 0 && ackData != nullptr)
	{
		Assert(ackDataLength == APP_PAYLOAD_SIZE);
		
		PrintLine_D("Got %u byte ack data", ackDataLength);
		ProcessPayload(true, &ackData[0]);
	}
}

static void ButtonChangedCallback(bool buttonDown)
{
	u8 payloadBuffer[APP_PAYLOAD_SIZE];
	ClearArray(payloadBuffer);
	payloadBuffer[0] = AppCmd_ModuleButtonStatus;
	
	if (buttonDown)
	{
		WriteLine_I("Module Button Pressed");
		payloadBuffer[1] = 0x01;
		ourModuleButtonDown = true;
	}
	else
	{
		WriteLine_I("Module Button Released");
		payloadBuffer[1] = 0x00;
		ourModuleButtonDown = false;
	}
	
	TransmitQueuePush(APP_PAYLOAD_SIZE, payloadBuffer, TransmitFinishedCallback);
	UpdateAckData();
}

static void ReceivedPacketCallback(u8 packetLength, const u8* packetPntr, const ReceiveInfo_t* rxInfo)
{
	PrintLine_D("Got %u byte rx packet!", packetLength);
	Assert(packetLength == APP_PAYLOAD_SIZE);
	
	ProcessPayload(false, &packetPntr[0]);
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void AppInitialize()
{
	ConfigureInput(TEST_BUTTON_PORT, TEST_BUTTON_MASK, ENABLED);
}

void AppStart()
{
	WriteLine_O("Starting embedded application...");
	SetRadioResponseCallbacks(ModuleResetCallback, ReceivedPacketCallback, ButtonChangedCallback);
	otherButtonDown = false;
	otherModuleButtonDown = false;
	ourButtonDown = !GetPinInputValue(TEST_BUTTON_PORT, TEST_BUTTON_MASK);
	ourModuleButtonDown = false;
	configurationFinished = false;
	
	SetModuleSettings();
	
	//We will make sure the module is present and responding by waiting for the
	//ModuleVersion response to come back. If the module doesn't respond we will
	//retry sending the settings until it does
	SureGotModuleVersion = false;
	GenericCountdown[0] = APP_STARTUP_RETRY_TIMEOUT;
	SureGetModuleVersion();
	
	AppRunning = true;
}

void AppStop()
{
	WriteLine_O("Stopping embedded application...");
	
	SureDefaultSettings();
	SetRadioResponseCallbacks(nullptr, nullptr, nullptr);
	
	AppRunning = false;
}

void AppUpdate()
{
	// +================================+
	// | Wait for Startup Configuration |
	// +================================+
	if (!configurationFinished)
	{
		if (SureGotModuleVersion)
		{
			WriteLine_I("Embedded app is ready!");
			configurationFinished = true;
			
			ourModuleButtonDown = SureModuleStatus.buttonDown;
			UpdateAckData();
			//continue on to the rest of the Update Loop
		}
		else
		{
			if (GenericCountdown[0] == 0)
			{
				WriteLine_E("App configuration timeout. Resending...");
				
				SetModuleSettings();
				SureGotModuleVersion = false;
				GenericCountdown[0] = APP_STARTUP_RETRY_TIMEOUT;
				SureGetModuleVersion();
			}
			
			//Don't run the rest of the Update Loop if configuration is ongoing
			return;
		}
	}
	
	// +==============================+
	// |        Handle Button         |
	// +==============================+
	bool buttonDown = !GetPinInputValue(TEST_BUTTON_PORT, TEST_BUTTON_MASK);
	if (buttonDown != buttonWasDown && GenericCountdown[1] == 0)
	{
		buttonWasDown = buttonDown;
		
		u8 payloadBuffer[APP_PAYLOAD_SIZE];
		ClearArray(payloadBuffer);
		payloadBuffer[0] = AppCmd_ButtonStatus;
		
		if (buttonDown)
		{
			WriteLine_I("Button Pressed");
			payloadBuffer[1] = 0x01;
			ourButtonDown = true;
		}
		else
		{
			WriteLine_I("Button Released");
			payloadBuffer[1] = 0x00;
			ourButtonDown = false;
		}
		
		TransmitQueuePush(APP_PAYLOAD_SIZE, payloadBuffer, TransmitFinishedCallback);
		UpdateAckData();
		
		GenericCountdown[1] = APP_BUTTON_DEBOUNCE_TIME;
	}
}
