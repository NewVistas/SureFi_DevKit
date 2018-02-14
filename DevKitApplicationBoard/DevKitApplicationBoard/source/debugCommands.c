/*
File:   debugCommands.c
Author: Taylor Robbins
Date:   01\22\2018
Description: 
	** Holds the function that handles incoming debug commands 
*/

#include "defines.h"
#include "debugCommands.h"

#include "debug.h"
#include "uartFifos.h"
#include "micro.h"
#include "tickTimer.h"
#include "sureResponses.h"
#include "sureCommands.h"
#include "bleCommands.h"
#include "helpers.h"

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+

void HandleDebugCommand(const char* commandStr)
{
	u32 commandLength = (u32)strlen(commandStr);
	
	// +==============================+
	// |             help             |
	// +==============================+
	if (strcmp(commandStr, "help") == 0)
	{
		WriteLine_D("There is no help right now");
	}
	// +==============================+
	// |          sureStatus          |
	// +==============================+
	else if (strcmp(commandStr, "sureStatus") == 0)
	{
		PrintLine_O("Status: CFG[%02X] CLR[%02X] OTH[%02X] STA[%02X]",
			SureModuleStatus.configFlags,
			SureModuleStatus.clearableFlags,
			SureModuleStatus.otherFlags,
			SureModuleStatus.stateFlags
		);
		
		switch (SureModuleStatus.stateFlags & StateFlags_RadioStateBits)
		{
			case RadioState_Initializing:  PrintLine_I("RadioState: Initializing"); break;
			case RadioState_Receiving:     PrintLine_I("RadioState: Receiving"); break;
			case RadioState_Transmitting:  PrintLine_I("RadioState: Transmitting"); break;
			case RadioState_WaitingForAck: PrintLine_I("RadioState: WaitingForAck"); break;
			case RadioState_Acknowledging: PrintLine_I("RadioState: Acknowledging"); break;
			case RadioState_Sleeping:      PrintLine_I("RadioState: Sleeping"); break;
			default:                       PrintLine_I("RadioState: Unknown"); break;
		};
		PrintLine_I("Busy:             %s (0x%02X) %s", (SureModuleStatus.stateFlags     & StateFlags_BusyBit)                 ? "1" : "0", StateFlags_BusyBit,                 (SureIntEnableBits.stateFlags     & StateFlags_BusyBit)                 ? "INT" : "");
		PrintLine_I("EncryptionActive: %s (0x%02X) %s", (SureModuleStatus.stateFlags     & StateFlags_EncryptionActiveBit)     ? "1" : "0", StateFlags_EncryptionActiveBit,     (SureIntEnableBits.stateFlags     & StateFlags_EncryptionActiveBit)     ? "INT" : "");
		PrintLine_I("RxInProgress:     %s (0x%02X) %s", (SureModuleStatus.stateFlags     & StateFlags_RxInProgressBit)         ? "1" : "0", StateFlags_RxInProgressBit,         (SureIntEnableBits.stateFlags     & StateFlags_RxInProgressBit)         ? "INT" : "");
		PrintLine_I("SettingsPending:  %s (0x%02X) %s", (SureModuleStatus.stateFlags     & StateFlags_SettingsPendingBit)      ? "1" : "0", StateFlags_SettingsPendingBit,      (SureIntEnableBits.stateFlags     & StateFlags_SettingsPendingBit)      ? "INT" : "");
		WriteLine_I("");
		PrintLine_I("DoingLightshow:   %s (0x%02X) %s", (SureModuleStatus.otherFlags     & OtherFlags_DoingLightshowBit)       ? "1" : "0", OtherFlags_DoingLightshowBit,       (SureIntEnableBits.otherFlags     & OtherFlags_DoingLightshowBit)       ? "INT" : "");
		PrintLine_I("ShowingQos:       %s (0x%02X) %s", (SureModuleStatus.otherFlags     & OtherFlags_ShowingQosBit)           ? "1" : "0", OtherFlags_ShowingQosBit,           (SureIntEnableBits.otherFlags     & OtherFlags_ShowingQosBit)           ? "INT" : "");
		PrintLine_I("ButtonDown:       %s (0x%02X) %s", (SureModuleStatus.otherFlags     & OtherFlags_ButtonDownBit)           ? "1" : "0", OtherFlags_ButtonDownBit,           (SureIntEnableBits.otherFlags     & OtherFlags_ButtonDownBit)           ? "INT" : "");
		WriteLine_I("");
		PrintLine_I("WasReset:         %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_WasResetBit)         ? "1" : "0", ClearableFlags_WasResetBit,         (SureIntEnableBits.clearableFlags & ClearableFlags_WasResetBit)         ? "INT" : "");
		PrintLine_I("TransmitFinished: %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_TransmitFinishedBit) ? "1" : "0", ClearableFlags_TransmitFinishedBit, (SureIntEnableBits.clearableFlags & ClearableFlags_TransmitFinishedBit) ? "INT" : "");
		PrintLine_I("RxPacketReady:    %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_RxPacketReadyBit)    ? "1" : "0", ClearableFlags_RxPacketReadyBit,    (SureIntEnableBits.clearableFlags & ClearableFlags_RxPacketReadyBit)    ? "INT" : "");
		PrintLine_I("AckPacketReady:   %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_AckPacketReadyBit)   ? "1" : "0", ClearableFlags_AckPacketReadyBit,   (SureIntEnableBits.clearableFlags & ClearableFlags_AckPacketReadyBit)   ? "INT" : "");
		PrintLine_I("ChecksumError:    %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_ChecksumErrorBit)    ? "1" : "0", ClearableFlags_ChecksumErrorBit,    (SureIntEnableBits.clearableFlags & ClearableFlags_ChecksumErrorBit)    ? "INT" : "");
		PrintLine_I("EncryptionRekey:  %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_EncryptionRekeyBit)  ? "1" : "0", ClearableFlags_EncryptionRekeyBit,  (SureIntEnableBits.clearableFlags & ClearableFlags_EncryptionRekeyBit)  ? "INT" : "");
		PrintLine_I("ButtonPressed:    %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_ButtonPressedBit)    ? "1" : "0", ClearableFlags_ButtonPressedBit,    (SureIntEnableBits.clearableFlags & ClearableFlags_ButtonPressedBit)    ? "INT" : "");
		PrintLine_I("ButtonHeld:       %s (0x%02X) %s", (SureModuleStatus.clearableFlags & ClearableFlags_ButtonHeldBit)       ? "1" : "0", ClearableFlags_ButtonHeldBit,       (SureIntEnableBits.clearableFlags & ClearableFlags_ButtonHeldBit)       ? "INT" : "");
		WriteLine_I("");
		PrintLine_I("InterruptDriven:  %s (0x%02X) %s", (SureModuleStatus.configFlags    & ConfigFlags_InterruptDrivenBit)     ? "1" : "0", ConfigFlags_InterruptDrivenBit,     (SureIntEnableBits.configFlags    & ConfigFlags_InterruptDrivenBit)     ? "INT" : "");
		PrintLine_I("AutoClearFlags:   %s (0x%02X) %s", (SureModuleStatus.configFlags    & ConfigFlags_AutoClearFlagsBit)      ? "1" : "0", ConfigFlags_AutoClearFlagsBit,      (SureIntEnableBits.configFlags    & ConfigFlags_AutoClearFlagsBit)      ? "INT" : "");
		PrintLine_I("RxLedMode:        %s (0x%02X) %s", (SureModuleStatus.configFlags    & ConfigFlags_RxLedModeBit)           ? "1" : "0", ConfigFlags_RxLedModeBit,           (SureIntEnableBits.configFlags    & ConfigFlags_RxLedModeBit)           ? "INT" : "");
		PrintLine_I("TxLedMode:        %s (0x%02X) %s", (SureModuleStatus.configFlags    & ConfigFlags_TxLedModeBit)           ? "1" : "0", ConfigFlags_TxLedModeBit,           (SureIntEnableBits.configFlags    & ConfigFlags_TxLedModeBit)           ? "INT" : "");
		PrintLine_I("AutoRekey:        %s (0x%02X) %s", (SureModuleStatus.configFlags    & ConfigFlags_AutoRekeyBit)           ? "1" : "0", ConfigFlags_AutoRekeyBit,           (SureIntEnableBits.configFlags    & ConfigFlags_AutoRekeyBit)           ? "INT" : "");
	}
	// +==============================+
	// |          radioInfo           |
	// +==============================+
	else if (strcmp(commandStr, "radioInfo") == 0)
	{
		PrintRadioInfo();
	}
	// +==============================+
	// |        printResponses        |
	// +==============================+
	else if (strcmp(commandStr, "printResponses") == 0)
	{
		PrintSureResponses = !PrintSureResponses;
		PrintLine_I("Print Radio Responses %s", PrintSureResponses ? "Enabled" : "Disabled");
	}
	// +==============================+
	// |         printStatus          |
	// +==============================+
	else if (strcmp(commandStr, "printStatus") == 0)
	{
		PrintStatusUpdates = !PrintStatusUpdates;
		PrintLine_I("Print Status Updates %s", PrintStatusUpdates ? "Enabled" : "Disabled");
	}
	// +==============================+
	// |        printSuccesses        |
	// +==============================+
	else if (strcmp(commandStr, "printSuccesses") == 0)
	{
		PrintSureSuccesses = !PrintSureSuccesses;
		PrintLine_I("Print Status Successes %s", PrintSureSuccesses ? "Enabled" : "Disabled");
	}
	// +==============================+
	// |        printFailures         |
	// +==============================+
	else if (strcmp(commandStr, "printFailures") == 0)
	{
		PrintSureFailures = !PrintSureFailures;
		PrintLine_I("Print Status Failures %s", PrintSureFailures ? "Enabled" : "Disabled");
	}
	// +==============================+
	// |             tick             |
	// +==============================+
	else if (strcmp(commandStr, "tick") == 0)
	{
		PrintLine_D("TickCounter = %u", TickCounter);
	}
	// +==============================+
	// |           history            |
	// +==============================+
	else if (strcmp(commandStr, "history") == 0)
	{
		WriteLine_I("Radio UART history:");
		PrintRadioUartHistory();
	}
	// +==============================+
	// |         clearHistory         |
	// +==============================+
	else if (strcmp(commandStr, "clearHistory") == 0)
	{
		WriteLine_I("Clearing radio UART history");
		ClearRadioUartHistory();
	}
	// +==============================+
	// |        bleName [name]        |
	// +==============================+
	else if (commandLength >= 8 && strncmp(commandStr, "bleName ", 8) == 0)
	{
		const char* nameStr = &commandStr[8];
		PrintLine_I("Setting BLE advertising name to \"%s\"", nameStr);
		BleSetAdvertisingName(nameStr, strlen(nameStr));
	}
	// +==============================+
	// |        bleData [HEX]         |
	// +==============================+
	else if (commandLength >= 8 && strncmp(commandStr, "bleData ", 8) == 0)
	{
		const char* hexStr = &commandStr[8];
		u32 hexStrLength = (u32)strlen(hexStr);
		u8 dataBuffer[MAX_ADV_DATA_LENGTH];
		u8 numBytes = 0;
		while (numBytes < ArrayCount(dataBuffer) && numBytes*2 + 2 <= hexStrLength)
		{
			dataBuffer[numBytes] = ParseHexByte(&hexStr[numBytes*2]);
			numBytes++;
		}
		PrintLine_I("Setting BLE advertising data to %u bytes", numBytes);
		BleSetAdvertisingData(dataBuffer, numBytes);
	}
	// +==============================+
	// |         listCommands         |
	// +==============================+
	else if (strcmp(commandStr, "listCommands") == 0)
	{
		WriteLine_O(" +==============================+");
		WriteLine_O(" |    Sure-Fi Radio Commands    |");
		WriteLine_O(" +==============================+");
		WriteLine_I("SureCmd_DefaultSettings      = 0x30");
		WriteLine_I("SureCmd_ClearStatusFlags     = 0x31");
		WriteLine_I("SureCmd_WriteConfig          = 0x32");
		WriteLine_I("SureCmd_SetIntEnableBits     = 0x33");
		WriteLine_I("SureCmd_Reset                = 0x34");
		WriteLine_I("SureCmd_Sleep                = 0x35");
		WriteLine_I("SureCmd_QosLightshow         = 0x36");
		WriteLine_I("SureCmd_TransmitData         = 0x37");
		WriteLine_I("SureCmd_StartEncryption      = 0x38");
		WriteLine_I("SureCmd_StopEncryption       = 0x39");
		WriteLine_I("SureCmd_ShowQualityOfService = 0x3A");
		WriteLine_I("");
		WriteLine_I("SureCmd_GetStatus            = 0x40");
		WriteLine_I("SureCmd_GetIntEnableBits     = 0x41");
		WriteLine_I("SureCmd_GetModuleVersion     = 0x42");
		WriteLine_I("SureCmd_GetPacketTimeOnAir   = 0x43");
		WriteLine_I("SureCmd_GetRandomNumber      = 0x44");
		WriteLine_I("SureCmd_GetPacket            = 0x45");
		WriteLine_I("SureCmd_GetAckPacket         = 0x46");
		WriteLine_I("SureCmd_GetReceiveInfo       = 0x47");
		WriteLine_I("SureCmd_GetTransmitInfo      = 0x48");
		WriteLine_I("");
		WriteLine_I("SureCmd_SetAllSettings       = 0x50");
		WriteLine_I("SureCmd_SetRadioMode         = 0x51");
		WriteLine_I("SureCmd_SetFhssTable         = 0x52");
		WriteLine_I("SureCmd_SetReceiveUID        = 0x53");
		WriteLine_I("SureCmd_SetTransmitUID       = 0x54");
		WriteLine_I("SureCmd_SetReceivePacketSize = 0x55");
		WriteLine_I("SureCmd_SetRadioPolarity     = 0x56");
		WriteLine_I("SureCmd_SetTransmitPower     = 0x57");
		WriteLine_I("SureCmd_SetAckData           = 0x58");
		WriteLine_I("");
		WriteLine_I("SureCmd_SetQosConfig         = 0x60");
		WriteLine_I("SureCmd_SetIndications       = 0x61");
		WriteLine_I("SureCmd_SetQuietMode         = 0x62");
		WriteLine_I("SureCmd_SetButtonConfig      = 0x63");
		WriteLine_I("SureCmd_SetAcksEnabled       = 0x64");
		WriteLine_I("SureCmd_SetNumRetries        = 0x65");
		WriteLine_I("");
		WriteLine_I("SureCmd_GetAllSettings       = 0x70");
		WriteLine_I("SureCmd_GetRadioMode         = 0x71");
		WriteLine_I("SureCmd_GetFhssTable         = 0x72");
		WriteLine_I("SureCmd_GetReceiveUID        = 0x73");
		WriteLine_I("SureCmd_GetTransmitUID       = 0x74");
		WriteLine_I("SureCmd_GetReceivePacketSize = 0x75");
		WriteLine_I("SureCmd_GetRadioPolarity     = 0x76");
		WriteLine_I("SureCmd_GetTransmitPower     = 0x77");
		WriteLine_I("SureCmd_GetAckData           = 0x78");
		WriteLine_I("");
		WriteLine_I("SureCmd_GetQosConfig         = 0x80");
		WriteLine_I("SureCmd_GetIndications       = 0x81");
		WriteLine_I("SureCmd_GetQuietMode         = 0x82");
		WriteLine_I("SureCmd_GetButtonConfig      = 0x83");
		WriteLine_I("SureCmd_GetAcksEnabled       = 0x84");
		WriteLine_I("SureCmd_GetNumRetries        = 0x85");
	}
	// +==============================+
	// |        listResponses         |
	// +==============================+
	else if (strcmp(commandStr, "listResponses") == 0)
	{
		WriteLine_O(" +==============================+");
		WriteLine_O(" |   Sure-Fi Radio Responses    |");
		WriteLine_O(" +==============================+");
		WriteLine_I("SureRsp_Status            = 0x40");
		WriteLine_I("SureRsp_IntEnableBits     = 0x41");
		WriteLine_I("SureRsp_ModuleVersion     = 0x42");
		WriteLine_I("SureRsp_PacketTimeOnAir   = 0x43");
		WriteLine_I("SureRsp_RandomNumber      = 0x44");
		WriteLine_I("SureRsp_Packet            = 0x45");
		WriteLine_I("SureRsp_AckPacket         = 0x46");
		WriteLine_I("SureRsp_ReceiveInfo       = 0x47");
		WriteLine_I("SureRsp_TransmitInfo      = 0x48");
		WriteLine_I("");
		WriteLine_I("SureRsp_Success           = 0x50");
		WriteLine_I("SureRsp_Failure           = 0x51");
		WriteLine_I("SureRsp_Unsupported       = 0x52");
		WriteLine_I("SureRsp_UartTimeout       = 0x53");
		WriteLine_I("");
		WriteLine_I("SureRsp_AllSettings       = 0x70");
		WriteLine_I("SureRsp_RadioMode         = 0x71");
		WriteLine_I("SureRsp_FhssTable         = 0x72");
		WriteLine_I("SureRsp_ReceiveUID        = 0x73");
		WriteLine_I("SureRsp_TransmitUID       = 0x74");
		WriteLine_I("SureRsp_ReceivePacketSize = 0x75");
		WriteLine_I("SureRsp_RadioPolarity     = 0x76");
		WriteLine_I("SureRsp_TransmitPower     = 0x77");
		WriteLine_I("SureRsp_AckData           = 0x78");
		WriteLine_I("");
		WriteLine_I("SureRsp_QosConfig         = 0x80");
		WriteLine_I("SureRsp_Indications       = 0x81");
		WriteLine_I("SureRsp_QuietMode         = 0x82");
		WriteLine_I("SureRsp_ButtonConfig      = 0x83");
		WriteLine_I("SureRsp_AcksEnabled       = 0x84");
		WriteLine_I("SureRsp_NumRetries        = 0x85");
	}
	// +==============================+
	// |          send [HEX]          |
	// +==============================+
	else if (commandLength > 5 && strncmp(commandStr, "send ", 5) == 0)
	{
		u16 numBytesSent = 0;
		u16 cIndex;
		for (cIndex = 5; cIndex+2 <= commandLength; cIndex += 2)
		{
			//Skip spaces
			while (cIndex < commandLength && commandStr[cIndex] == ' ') { cIndex++; }
			if (cIndex+2 > commandLength) { break; }
			
			if (!IsHexChar(commandStr[cIndex]) || !IsHexChar(commandStr[cIndex+1]))
			{
				PrintLine_E("\"%c%c\" is not valid HEX", commandStr[cIndex], commandStr[cIndex+1]);
			}
			else
			{
				u8 nextByte = ParseHexByte(&commandStr[cIndex]);
				AppUartSendData(AppUart_SureFiRadio, &nextByte, 1);
				numBytesSent++;
			}
		}
		
		PrintLine_I("Sent %u bytes to radio", numBytesSent);
	}
	else if (SureHandleDebugCommand(commandStr))
	{
		//sureCommands.c handled the command
	}
	else
	{
		PrintLine_E("Unknown command: \"%s\"", commandStr);
	}
}