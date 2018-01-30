/*
File:   sureResponses.c
Author: Taylor Robbins
Date:   01\24\2018
Description: 
	** Handles responses coming from the Sure-Fi radio
*/

#include "defines.h"
#include "sureResponses.h"

#include "debug.h"
#include "uartFifos.h"
#include "tickTimer.h"
#include "helpers.h"
#include "sureCommands.h"

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
bool PrintSureResponses = false;
bool PrintStatusUpdates = false;
bool PrintSureSuccesses = false;
bool PrintSureFailures = true;

u8 SureSuccessCmd = 0x00;                bool SureGotSuccess = false;
u8 SureFailureCmd = 0x00;                bool SureGotFailure = false;
u8 SureFailureError = 0x00;

bool SureGotTransmitFinished = false;

ModuleStatus_t SureModuleStatus;         bool SureGotModuleStatus      = false;
ModuleStatus_t SureIntEnableBits;        bool SureGotIntEnableBits     = false;
ModuleVersion_t SureModuleVersion;       bool SureGotModuleVersion     = false;
u16 SurePacketTimeOnAir = 0x0000;        bool SureGotPacketTimeOnAir   = false;
u32 SureRandomNumber = 0x00000000;       bool SureGotRandomNumber      = false;
u8  SureRxPacketLength = 0x00;
u8  SureRxPacket[MAX_RX_PACKET_LENGTH];  bool SureGotRxPacket          = false;
u8  SureAckPacketLength = 0x00;
u8  SureAckPacket[MAX_RX_PACKET_LENGTH]; bool SureGotAckPacket         = false;
ReceiveInfo_t SureRxInfo;                bool SureGotRxInfo            = false;
TransmitInfo_t SureTxInfo;               bool SureGotTxInfo            = false;

ModuleSettings_t SureAllSettings;        bool SureGotAllSettings       = false;
u8 SureRadioMode = 0x00;                 bool SureGotRadioMode         = false;
u8 SureSpreadingFactor = 0x00;
u8 SureBandwidth = 0x00;
u8 SureFhssTable = 0x00;                 bool SureGotFhssTable         = false;
u8 SureReceiveUidLength = 0x00;
u8 SureReceiveUid[MAX_UID_LENGTH];       bool SureGotReceiveUid        = false;
u8 SureTransmitUidLength = 0x00;
u8 SureTransmitUid[MAX_UID_LENGTH];      bool SureGotTransmitUid       = false;
u8 SureReceivePacketSize = 0x00;         bool SureGotReceivePacketSize = false;
u8 SureRadioPolarity = 0x00;             bool SureGotRadioPolarity     = false;
u8 SureTransmitPower = 0x00;             bool SureGotTransmitPower     = false;
u8 SureAckDataLength = 0x00;
u8 SureAckData[MAX_RX_PACKET_LENGTH];    bool SureGotAckData           = false;

u8   SureQosConfig = 0x00;               bool SureGotQosConfig         = false;
u8   SureIndications[6];                 bool SureGotIndications       = false;
bool SureQuietMode = false;              bool SureGotQuietMode         = false;
u8   SureButtonHoldTime = 0x00;
u8   SureButtonConfig = 0x00;            bool SureGotButtonConfig      = false;
bool SureAcksEnabled = false;            bool SureGotAcksEnabled       = false;
u8   SureNumRetries = 0x00;              bool SureGotNumRetries        = false;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 cmdBuffer[SURE_COMMAND_HEADER_SIZE+255];
static ModuleResetCallback_f* moduleResetCallbackPntr = nullptr;
static ReceivedPacketCallback_f* receivedPacketCallbackPntr = nullptr;
static ButtonChangedCallback_f* buttonChangedCallbackPntr = nullptr;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitRadioResponses()
{
	ClearArray(cmdBuffer);
	
	ClearStruct(SureModuleStatus);
	ClearStruct(SureIntEnableBits);
	ClearStruct(SureModuleVersion);
	ClearArray(SureRxPacket);
	ClearArray(SureAckPacket);
	ClearStruct(SureRxInfo);
	ClearStruct(SureTxInfo);
	ClearStruct(SureAllSettings);
	ClearArray(SureReceiveUid);
	ClearArray(SureTransmitUid);
	ClearArray(SureAckData);
	ClearArray(SureIndications);
	
	//TODO: Any other initialization?
}

void SetResponseCallbacks(
	ModuleResetCallback_f* moduleResetCallback,
	ReceivedPacketCallback_f* receivedPacketCallback,
	ButtonChangedCallback_f* buttonChangedCallback)
{
	moduleResetCallbackPntr = moduleResetCallback;
	receivedPacketCallbackPntr = receivedPacketCallback;
	buttonChangedCallbackPntr = buttonChangedCallback;
}

void ProcessRadioResponses()
{
	while (AppUartPopCommand(AppUart_SureFiRadio, cmdBuffer))
	{
		Assert(cmdBuffer[0] == ATTN_CHAR);
		SureCommand_t* cmdPntr = (SureCommand_t*)&cmdBuffer[0];
		HandleRadioResponse(cmdPntr);
	}
}

void HandleRadioResponse(const SureCommand_t* rsp)
{
	switch (rsp->cmd)
	{
		// +==============================+
		// |        SureRsp_Status        |
		// +==============================+
		case SureRsp_Status:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_Status[%u]", rsp->length);
			}
			
			ModuleStatus_t statusChanged;
			statusChanged.fullValue = (rsp->payload.status.fullValue ^ SureModuleStatus.fullValue);
			
			if (PrintStatusUpdates)
			{
				PrintLine_D(": [%02X][%02X][%02X][%02X] ([%02X][%02X][%02X][%02X])",
					rsp->payload.status.configFlags, rsp->payload.status.clearableFlags,
					rsp->payload.status.otherFlags, rsp->payload.status.stateFlags,
					statusChanged.configFlags, statusChanged.clearableFlags,
					statusChanged.otherFlags, statusChanged.stateFlags
				);
			}
			else if (PrintSureResponses) { WriteLine_D(""); }
			
			if (!rsp->payload.status.autoClearFlags &&
				rsp->payload.status.clearableFlags != 0x00)
			{
				WriteLine_D("Clearing flags");
				SureClearStatusFlags(0xFF);
			}
			
			if (rsp->payload.status.wasReset)
			{
				WriteLine_E("Module was reset!");
				if (moduleResetCallbackPntr != nullptr) { moduleResetCallbackPntr(); }
			}
			
			if (statusChanged.buttonDown)
			{
				if (buttonChangedCallbackPntr != nullptr) { buttonChangedCallbackPntr(rsp->payload.status.buttonDown); }
			}
			
			if (rsp->payload.status.transmitFinished)
			{
				WriteLine_D("Transmit Finished");
				SureGotTransmitFinished = true;
				SureGetTransmitInfo();
			}
			if (rsp->payload.status.ackPacketReady)
			{
				SureGetAckPacket();
			}
			if (rsp->payload.status.rxPacketReady)
			{
				SureGotRxPacket = false;
				SureGotRxInfo = false;
				SureGetPacket();
				SureGetReceiveInfo();
			}
			
			SureModuleStatus = rsp->payload.status;
			SureGotModuleStatus = true;
		} break;
		
		// +==============================+
		// |    SureRsp_IntEnableBits     |
		// +==============================+
		case SureRsp_IntEnableBits:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_IntEnableBits[%u]", rsp->length);
				PrintLine_D(": [%02X][%02X][%02X][%02X]",
					rsp->payload.status.configFlags, rsp->payload.status.clearableFlags,
					rsp->payload.status.otherFlags, rsp->payload.status.stateFlags);
			}
			SureIntEnableBits = rsp->payload.status;
			SureGotIntEnableBits = true;
		} break;
		
		// +==============================+
		// |    SureRsp_ModuleVersion     |
		// +==============================+
		case SureRsp_ModuleVersion:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_ModuleVersion[%u]", rsp->length);
				PrintLine_D(": FRM: %u.%u(%u) HRD: %u.%u MCU: %07X.%02X",
					rsp->payload.moduleVersion.firmware.major, rsp->payload.moduleVersion.firmware.minor, rsp->payload.moduleVersion.firmware.build,
					rsp->payload.moduleVersion.hardware.major, rsp->payload.moduleVersion.hardware.minor,
					rsp->payload.moduleVersion.mcu.id, rsp->payload.moduleVersion.mcu.revision);
			}
			SureModuleVersion = rsp->payload.moduleVersion;
			SureGotModuleVersion = true;
		} break;
		
		// +==============================+
		// |   SureRsp_PacketTimeOnAir    |
		// +==============================+
		case SureRsp_PacketTimeOnAir:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_PacketTimeOnAir[%u]: %ums", rsp->length, rsp->payload.timeOnAir);
			}
			SurePacketTimeOnAir = rsp->payload.timeOnAir;
			SureGotPacketTimeOnAir = true;
		} break;
		
		// +==============================+
		// |     SureRsp_RandomNumber     |
		// +==============================+
		case SureRsp_RandomNumber:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_RandomNumber[%u]: 0x%08X", rsp->length, rsp->payload.randomNumber);
			}
			SureRandomNumber = rsp->payload.randomNumber;
			SureGotRandomNumber = true;
		} break;
		
		// +==============================+
		// |        SureRsp_Packet        |
		// +==============================+
		case SureRsp_Packet:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_Packet[%u]", rsp->length);
				Write_D(": { ");
				u8 bIndex = 0;for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("}");
			}
			SureRxPacketLength = rsp->length;
			memcpy(SureRxPacket, rsp->payload.bytes, rsp->length);
			SureGotRxPacket = true;
			
			if (receivedPacketCallbackPntr != nullptr && SureGotRxPacket && SureGotRxInfo)
			{
				receivedPacketCallbackPntr(SureRxPacketLength, SureRxPacket, &SureRxInfo);
			}
		} break;
		
		// +==============================+
		// |      SureRsp_AckPacket       |
		// +==============================+
		case SureRsp_AckPacket:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_AckPacket[%u]", rsp->length);
				Write_D(": { ");
				u8 bIndex = 0;for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("}");
			}
			SureAckPacketLength = rsp->length;
			memcpy(SureAckPacket, rsp->payload.bytes, rsp->length);
			SureGotAckPacket = true;
		} break;
		
		// +==============================+
		// |     SureRsp_ReceiveInfo      |
		// +==============================+
		case SureRsp_ReceiveInfo:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_ReceiveInfo[%u]", rsp->length);
				PrintLine_D(": %s (%d, %d)", rsp->payload.rxInfo.success ? "Valid" : "Checksum", rsp->payload.rxInfo.rssi, rsp->payload.rxInfo.snr);
			}
			SureRxInfo = rsp->payload.rxInfo;
			SureGotRxInfo = true;
			
			if (receivedPacketCallbackPntr != nullptr && SureGotRxPacket && SureGotRxInfo)
			{
				receivedPacketCallbackPntr(SureRxPacketLength, SureRxPacket, &SureRxInfo);
			}
		} break;
		
		// +==============================+
		// |     SureRsp_TransmitInfo     |
		// +==============================+
		case SureRsp_TransmitInfo:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_TransmitInfo[%u]", rsp->length);
				PrintLine_D(": %s (%d, %d) %u retries", rsp->payload.txInfo.success ? "Success" : "Failure", rsp->payload.txInfo.rssi, rsp->payload.txInfo.snr, rsp->payload.txInfo.numRetries);
			}
			SureTxInfo = rsp->payload.txInfo;
			SureGotTxInfo = true;
		} break;
		
		// +==============================+
		// |       SureRsp_Success        |
		// +==============================+
		case SureRsp_Success:
		{
			Assert(rsp->length == 1);
			if (PrintSureSuccesses)
			{
				const char* cmdStr = GetSureCmdStr(rsp->payload.bytes[0]);
				PrintLine_D("%s Succeeded!", cmdStr);
			}
			SureSuccessCmd = rsp->payload.bytes[0];
			SureGotSuccess = true;
		} break;
		
		// +==============================+
		// |       SureRsp_Failure        |
		// +==============================+
		case SureRsp_Failure:
		{
			Assert(rsp->length == 2);
			if (PrintSureFailures)
			{
				const char* cmdStr = GetSureCmdStr(rsp->payload.bytes[0]);
				const char* errorStr = GetSureErrorStr(rsp->payload.bytes[1]);
				PrintLine_E("%s Failed! Error: %s", cmdStr, errorStr);
			}
			SureFailureCmd = rsp->payload.bytes[0];
			SureFailureError = rsp->payload.bytes[1];
			SureGotFailure = true;
		} break;
		
		// +==============================+
		// |     SureRsp_Unsupported      |
		// +==============================+
		case SureRsp_Unsupported:
		{
			const char* cmdStr = GetSureCmdStr(rsp->payload.bytes[0]);
			PrintLine_E("SureRsp_Unsupported! CMD: %s (0x%02X)", cmdStr, rsp->payload.bytes[0]);
		} break;
		
		// +==============================+
		// |     SureRsp_UartTimeout      |
		// +==============================+
		case SureRsp_UartTimeout:
		{
			WriteLine_E("SureRsp_UartTimeout!");
		} break;
		
		// +==============================+
		// |     SureRsp_AllSettings      |
		// +==============================+
		case SureRsp_AllSettings:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_AllSettings[%u]:", rsp->length);
				PrintLine_D("  RadioMode         = 0x%02X", rsp->payload.allSettings.radioMode);
				PrintLine_D("  FhssTable         = %u",     rsp->payload.allSettings.fhssTable);
				PrintLine_D("  ReceivePacketSize = %u",     rsp->payload.allSettings.receivePacketSize);
				PrintLine_D("  RadioPolarity     = 0x%02X", rsp->payload.allSettings.radioPolarity);
				PrintLine_D("  TransmitPower     = 0x%02X", rsp->payload.allSettings.transmitPower);
				PrintLine_D("  QosConfig         = 0x%02X", rsp->payload.allSettings.qosConfig);
				PrintLine_D("  Indications       = [0x%02X][0x%02X][0x%02X]", rsp->payload.allSettings.indications[0], rsp->payload.allSettings.indications[1], rsp->payload.allSettings.indications[2]);
				PrintLine_D("  QuietMode         = %s",     rsp->payload.allSettings.quietMode ? "Enabled" : "Disabled");
				PrintLine_D("  ButtonConfig      = 0x%02X", rsp->payload.allSettings.buttonConfig);
				PrintLine_D("  AcksEnabled       = %s",     rsp->payload.allSettings.acksEnabled ? "Enabled" : "Disabled");
				PrintLine_D("  NumRetries        = %u",     rsp->payload.allSettings.numRetries);
			}
			SureAllSettings = rsp->payload.allSettings;
			SureGotAllSettings = true;
			
			SureFhssTable = rsp->payload.allSettings.fhssTable;
			SureGotFhssTable = true;
			SureReceivePacketSize = rsp->payload.allSettings.receivePacketSize;
			SureGotReceivePacketSize = true;
			SureRadioPolarity = rsp->payload.allSettings.radioPolarity;
			SureGotRadioPolarity = true;
			SureTransmitPower = rsp->payload.allSettings.transmitPower;
			SureGotTransmitPower = true;
			SureQosConfig = rsp->payload.allSettings.qosConfig;
			SureGotQosConfig = true;
			SureIndications[0] = ((rsp->payload.allSettings.indications[0]>>0) & 0x0F);
			SureIndications[1] = ((rsp->payload.allSettings.indications[0]>>4) & 0x0F);
			SureIndications[2] = ((rsp->payload.allSettings.indications[1]>>0) & 0x0F);
			SureIndications[3] = ((rsp->payload.allSettings.indications[1]>>4) & 0x0F);
			SureIndications[4] = ((rsp->payload.allSettings.indications[2]>>0) & 0x0F);
			SureIndications[5] = ((rsp->payload.allSettings.indications[2]>>4) & 0x0F);
			SureGotIndications = true;
			SureQuietMode = rsp->payload.allSettings.quietMode;
			SureGotQuietMode = true;
			SureButtonHoldTime = ((rsp->payload.allSettings.buttonConfig>>4) & 0x0F);
			SureButtonConfig = ((rsp->payload.allSettings.buttonConfig>>0) & 0x0F);
			SureGotButtonConfig = true;
			SureAcksEnabled = rsp->payload.allSettings.acksEnabled;
			SureGotAcksEnabled = true;
			SureNumRetries = rsp->payload.allSettings.numRetries;
			SureGotNumRetries = true;
		} break;
		
		// +==============================+
		// |      SureRsp_RadioMode       |
		// +==============================+
		case SureRsp_RadioMode:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_RadioMode[%u]", rsp->length);
				if (rsp->payload.radioMode == RadioMode_Custom)
				{
					PrintLine_D(": Custom SF: 0x%02X BW: 0x%02X", rsp->payload.customMode.spreadingFactor, rsp->payload.customMode.bandwidth);
				}
				else
				{
					PrintLine_D(": 0x%02X", rsp->payload.radioMode);
				}
			}
			SureRadioMode = rsp->payload.radioMode;
			SureSpreadingFactor = rsp->payload.customMode.spreadingFactor;
			SureBandwidth = rsp->payload.customMode.bandwidth;
			SureGotRadioMode = true;
		} break;
		
		// +==============================+
		// |      SureRsp_FhssTable       |
		// +==============================+
		case SureRsp_FhssTable:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_FhssTable[%u]: %u", rsp->length, rsp->payload.fhssTable);
			}
			SureFhssTable = rsp->payload.fhssTable;
			SureGotFhssTable = true;
		} break;
		
		// +==============================+
		// |      SureRsp_ReceiveUID      |
		// +==============================+
		case SureRsp_ReceiveUID:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_ReceiveUID[%u]", rsp->length);
				Write_D(": { ");
				u8 bIndex = 0;for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("}");
			}
			
			if (rsp->length <= MAX_UID_LENGTH)
			{
				SureReceiveUidLength = rsp->length;
				memcpy(SureReceiveUid, rsp->payload.bytes, rsp->length);
				SureGotReceiveUid = true;
			}
		} break;
		
		// +==============================+
		// |     SureRsp_TransmitUID      |
		// +==============================+
		case SureRsp_TransmitUID:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_TransmitUID[%u]", rsp->length);
				Write_D(": { ");
				u8 bIndex = 0;for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("}");
			}
			
			if (rsp->length <= MAX_UID_LENGTH)
			{
				SureTransmitUidLength = rsp->length;
				memcpy(SureTransmitUid, rsp->payload.bytes, rsp->length);
				SureGotTransmitUid = true;
			}
		} break;
		
		// +==============================+
		// |  SureRsp_ReceivePacketSize   |
		// +==============================+
		case SureRsp_ReceivePacketSize:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_ReceivePacketSize[%u]: %u", rsp->length, rsp->payload.receivePacketSize);
			}
			SureReceivePacketSize = rsp->payload.receivePacketSize;
			SureGotReceivePacketSize = true;
		} break;
		
		// +==============================+
		// |    SureRsp_RadioPolarity     |
		// +==============================+
		case SureRsp_RadioPolarity:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_RadioPolarity[%u]: 0x%02X", rsp->length, rsp->payload.radioPolarity);
			}
			SureRadioPolarity = rsp->payload.radioPolarity;
			SureGotRadioPolarity = true;
		} break;
		
		// +==============================+
		// |    SureRsp_TransmitPower     |
		// +==============================+
		case SureRsp_TransmitPower:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_TransmitPower[%u]: 0x%02X", rsp->length, rsp->payload.transmitPower);
			}
			SureTransmitPower = rsp->payload.transmitPower;
			SureGotTransmitPower = true;
		} break;
		
		// +==============================+
		// |       SureRsp_AckData        |
		// +==============================+
		case SureRsp_AckData:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_AckData[%u]", rsp->length);
				Write_D(": { ");
				u8 bIndex = 0;for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("}");
			}
			
			if (rsp->length <= MAX_RX_PACKET_LENGTH)
			{
				SureAckDataLength = rsp->length;
				memcpy(SureAckData, rsp->payload.bytes, rsp->length);
				SureGotAckData = true;
			}
		} break;
		
		// +==============================+
		// |      SureRsp_QosConfig       |
		// +==============================+
		case SureRsp_QosConfig:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_QosConfig[%u]: 0x%02X", rsp->length, rsp->payload.qosConfig);
			}
			SureQosConfig = rsp->payload.qosConfig;
			SureGotQosConfig = true;
		} break;
		
		// +==============================+
		// |     SureRsp_Indications      |
		// +==============================+
		case SureRsp_Indications:
		{
			if (PrintSureResponses)
			{
				Print_D("SureRsp_Indications[%u]", rsp->length);
				PrintLine_D(": [%02X][%02X][%02X]", rsp->payload.indications[0], rsp->payload.indications[1], rsp->payload.indications[2]);
			}
			SureIndications[0] = ((rsp->payload.indications[0]>>0) & 0x0F);
			SureIndications[1] = ((rsp->payload.indications[0]>>4) & 0x0F);
			SureIndications[2] = ((rsp->payload.indications[1]>>0) & 0x0F);
			SureIndications[3] = ((rsp->payload.indications[1]>>4) & 0x0F);
			SureIndications[4] = ((rsp->payload.indications[2]>>0) & 0x0F);
			SureIndications[5] = ((rsp->payload.indications[2]>>4) & 0x0F);
			SureGotIndications = true;
		} break;
		
		// +==============================+
		// |      SureRsp_QuietMode       |
		// +==============================+
		case SureRsp_QuietMode:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_QuietMode[%u]: %s", rsp->length, rsp->payload.quietMode ? "Enabled" : "Disabled");
			}
			SureQuietMode = rsp->payload.quietMode;
			SureGotQuietMode = true;
		} break;
		
		// +==============================+
		// |     SureRsp_ButtonConfig     |
		// +==============================+
		case SureRsp_ButtonConfig:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_ButtonConfig[%u]: 0x%02X", rsp->length, rsp->payload.buttonConfig);
			}
			SureButtonConfig   = ((rsp->payload.buttonConfig>>0) & 0x0F);
			SureButtonHoldTime = ((rsp->payload.buttonConfig>>4) & 0x0F);
			SureGotButtonConfig = true;
		} break;
		
		// +==============================+
		// |     SureRsp_AcksEnabled      |
		// +==============================+
		case SureRsp_AcksEnabled:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_AcksEnabled[%u]: %s", rsp->length, rsp->payload.acksEnabled ? "Enabled" : "Disabled");
			}
			SureAcksEnabled = rsp->payload.acksEnabled;
			SureGotAcksEnabled = true;
		} break;
		
		// +==============================+
		// |      SureRsp_NumRetries      |
		// +==============================+
		case SureRsp_NumRetries:
		{
			if (PrintSureResponses)
			{
				PrintLine_D("SureRsp_NumRetries[%u]: %u", rsp->length, rsp->payload.numRetries);
			}
			SureNumRetries = rsp->payload.numRetries;
			SureGotNumRetries = true;
		} break;
		
		
		// +==============================+
		// |       Unknown Response       |
		// +==============================+
		default:
		{
			PrintLine_E("Unknown %u byte SureRsp: 0x%02X", rsp->length, rsp->cmd);
		} break;
	};
}

void PrintRadioInfo()
{
	u32 bIndex;
	
	WriteLine_O("Sure-Fi Radio Info:");
	Write_I("ModuleStatus:      ");
	if (SureGotModuleStatus)
	{
		PrintLine_I("[%02X][%02X][%02X][%02X]",
			SureModuleStatus.configFlags, SureModuleStatus.clearableFlags,
			SureModuleStatus.otherFlags, SureModuleStatus.stateFlags);
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("IntEnableBits:     ");
	if (SureGotIntEnableBits)
	{
		PrintLine_I("[%02X][%02X][%02X][%02X]",
			SureIntEnableBits.configFlags, SureIntEnableBits.clearableFlags,
			SureIntEnableBits.otherFlags, SureIntEnableBits.stateFlags);
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("ModuleVersion:     ");
	if (SureGotModuleVersion)
	{
		PrintLine_I("FRM: %u.%u(%u) HRD: %u.%u MCU: %07X.%02X",
			SureModuleVersion.firmware.major, SureModuleVersion.firmware.minor, SureModuleVersion.firmware.build,
			SureModuleVersion.hardware.major, SureModuleVersion.hardware.minor,
			SureModuleVersion.mcu.id, SureModuleVersion.mcu.revision);
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("PacketTimeOnAir:   ");
	if (SureGotPacketTimeOnAir)   { PrintLine_I("%ums", SurePacketTimeOnAir); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("RandomNumber:      ");
	if (SureGotRandomNumber)      { PrintLine_I("0x%08X", SureRandomNumber); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("RxPacket:          ");
	if (SureGotRxPacket)
	{
		Print_I("[%u]{ ", SureRxPacketLength);
		for (bIndex = 0; bIndex < SureRxPacketLength; bIndex++) { Print_I("%02X ", SureRxPacket[bIndex]); }
		WriteLine_I("}");
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("AckPacket:         ");
	if (SureGotAckPacket)
	{
		Print_I("[%u]{ ", SureAckPacketLength);
		for (bIndex = 0; bIndex < SureAckPacketLength; bIndex++) { Print_I("%02X ", SureAckPacket[bIndex]); }
		WriteLine_I("}");
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("RxInfo:            ");
	if (SureGotRxInfo)
	{
		PrintLine_I("%s (%d, %d)",
			SureRxInfo.success ? "Valid" : "Checksum", SureRxInfo.rssi, SureRxInfo.snr);
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("TxInfo:            ");
	if (SureGotTxInfo)
	{
		PrintLine_I("%s (%d, %d) %u retries",
			SureTxInfo.success ? "Success" : "Failure", SureTxInfo.rssi, SureTxInfo.snr, SureTxInfo.numRetries);
	}
	else                          { WriteLine_I("Unknown"); }
	
	PrintLine_O("AllSettings: %s", SureGotAllSettings ? "Obtained" : "Not-Obtained");
	
	Write_I("RadioMode:         ");
	if (SureGotRadioMode)
	{
		if (SureRadioMode == RadioMode_Custom) { PrintLine_I("Custom SF: 0x%02X BW: 0x%02X", SureSpreadingFactor, SureBandwidth); }
		else { PrintLine_I("0x%02X", SureRadioMode); }
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("FhssTable:         ");
	if (SureGotFhssTable)         { PrintLine_I("%u", SureFhssTable); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("ReceiveUid:        ");
	if (SureGotReceiveUid)
	{
		Print_I("[%u]{ ", SureReceiveUidLength);
		for (bIndex = 0; bIndex < SureReceiveUidLength; bIndex++) { Print_I("%02X ", SureReceiveUid[bIndex]); }
		WriteLine_I("}");
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("TransmitUid:       ");
	if (SureGotTransmitUid)
	{
		Print_I("[%u]{ ", SureTransmitUidLength);
		for (bIndex = 0; bIndex < SureTransmitUidLength; bIndex++) { Print_I("%02X ", SureTransmitUid[bIndex]); }
		WriteLine_I("}");
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("ReceivePacketSize: ");
	if (SureGotReceivePacketSize) { PrintLine_I("%u", SureReceivePacketSize); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("RadioPolarity:     ");
	if (SureGotRadioPolarity)     { PrintLine_I("0x%02X", SureRadioPolarity); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("TransmitPower:     ");
	if (SureGotTransmitPower)     { PrintLine_I("0x%02X", SureTransmitPower); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("AckData:           ");
	if (SureGotAckData)
	{
		Print_I("[%u]{ ", SureAckDataLength);
		for (bIndex = 0; bIndex < SureAckDataLength; bIndex++) { Print_I("%02X ", SureAckData[bIndex]); }
		WriteLine_I("}");
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("QosConfig:         ");
	if (SureGotQosConfig)         { PrintLine_I("0x%02X", SureQosConfig); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("Indications:       ");
	if (SureGotIndications)
	{
		PrintLine_I("[%X][%X][%X][%X][%X][%X]",
			SureIndications[0], SureIndications[1], SureIndications[2],
			SureIndications[3], SureIndications[4], SureIndications[5]);
	}
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("QuietMode:         ");
	if (SureGotQuietMode)         { PrintLine_I("%s", SureQuietMode ? "Enabled" : "Disabled"); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("ButtonHoldTime:    ");
	if (SureGotButtonConfig)      { PrintLine_I("%us", SureButtonHoldTime); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("ButtonConfig:      ");
	if (SureGotButtonConfig)      { PrintLine_I("0x%02X", SureButtonConfig); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("AcksEnabled:       ");
	if (SureGotAcksEnabled)       { PrintLine_I("%s", SureAcksEnabled ? "Enabled" : "Disabled"); }
	else                          { WriteLine_I("Unknown"); }
	
	Write_I("NumRetries:        ");
	if (SureGotNumRetries)        { PrintLine_I("%u", SureNumRetries); }
	else                          { WriteLine_I("Unknown"); }
	
	// PrintLine_I("ModuleVersion       = FRM: %u.%u(%u) HRD: %u.%u",
	// 	SureModuleVersion.firmware.major, SureModuleVersion.firmware.minor, SureModuleVersion.firmware.build,
	// 	SureModuleVersion.hardware.major, SureModuleVersion.hardware.minor);
	// PrintLine_I("SurePacketTimeOnAir = %ums", SurePacketTimeOnAir);
	// PrintLine_I("RandomNumber        = 0x%08X", SureRandomNumber);
	// PrintLine_I("RxPacketLength      = %u", SureRxPacketLength);
	// Write_I    ("RxPacket            = { ");
	// for(bIndex = 0; bIndex < SureRxPacketLength; bIndex++)
	// {
		
	// }
	// PrintLine_I("AckPacketLength     = %u", SureAckPacketLength);
	// Write_I("AckPacket           = { ");
	// PrintLine_I("RxInfo              = %s (%d, %d)",
	// 	SureRxInfo.success ? "Valid" : "Checksum", SureRxInfo.rssi, SureRxInfo.snr);
	// PrintLine_I("TxInfo              = %s (%d, %d) %u retries",
	// 	SureTxInfo.success ? "Success" : "Failure", SureTxInfo.rssi, SureTxInfo.snr, SureTxInfo.numRetries);
	
	// WriteLine_O("Sure-Fi Radio Settings:");
	// // PrintLine_I("AllSettings         = %02X", SureAllSettings);
	// PrintLine_I("RadioMode           = 0x%02X", SureRadioMode);
	// PrintLine_I("SpreadingFactor     = 0x%02X", SureSpreadingFactor);
	// PrintLine_I("Bandwidth           = 0x%02X", SureBandwidth);
	// PrintLine_I("FhssTable           = 0x%02X", SureFhssTable);
	// PrintLine_I("ReceiveUidLength    = %u", SureReceiveUidLength);
	// // PrintLine_I("ReceiveUid          = %02X", SureReceiveUid);
	// PrintLine_I("TransmitUidLength   = %u", SureTransmitUidLength);
	// // PrintLine_I("TransmitUid         = %02X", SureTransmitUid);
	// PrintLine_I("ReceivePacketSize   = %u", SureReceivePacketSize);
	// PrintLine_I("RadioPolarity       = 0x%02X", SureRadioPolarity);
	// PrintLine_I("TransmitPower       = 0x%02X", SureTransmitPower);
	// PrintLine_I("AckDataLength       = %u", SureAckDataLength);
	// // PrintLine_I("AckData             = %02X", SureAckData);
	// PrintLine_I("QosConfig           = 0x%02X", SureQosConfig);
	// PrintLine_I("Indications         = [%01X][%01X][%01X][%01X][%01X][%01X]",
	// 	SureIndications[0], SureIndications[1], SureIndications[2],
	// 	SureIndications[3], SureIndications[4], SureIndications[5]);
	// PrintLine_I("QuietMode           = %s", SureQuietMode ? "Enabled" : "Disabled");
	// PrintLine_I("ButtonHoldTime      = %us", SureButtonHoldTime);
	// PrintLine_I("ButtonConfig        = 0x%02X", SureButtonConfig);
	// PrintLine_I("AcksEnabled         = %s", SureAcksEnabled ? "Enabled" : "Disabled");
	// PrintLine_I("NumRetries          = %u", SureNumRetries);
}
