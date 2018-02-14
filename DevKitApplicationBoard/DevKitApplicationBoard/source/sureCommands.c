/*
File:   sureCommands.c
Author: Taylor Robbins
Date:   01\24\2018
Description: 
	** Holds a simple abstraction layer for sending all of the different Sure-Fi Radio Commands
*/

#include "defines.h"
#include "sureCommands.h"

#include "uartFifos.h"
#include "helpers.h"
#include "debug.h"

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 commandBuffer[SURE_COMMAND_HEADER_SIZE+255];

// +--------------------------------------------------------------+
// |                      Generic Functions                       |
// +--------------------------------------------------------------+
void SureSendCommand(const SureCommand_t* commandPntr)
{
	AppUartSendData(AppUart_SureFiRadio, (u8*)commandPntr, SURE_COMMAND_HEADER_SIZE + commandPntr->length);
}

void SureSendCommandBytes(const u8* bytesPntr)
{
	SureSendCommand((SureCommand_t*)bytesPntr);
}

void SureSendNoPayload(u8 cmd)
{
	SureCommand_t* cmdPntr = (SureCommand_t*)&commandBuffer[0];
	cmdPntr->attn = ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 0;
	SureSendCommand(cmdPntr);
}

void SureSendOneBytePayload(u8 cmd, u8 payload)
{
	SureCommand_t* cmdPntr = (SureCommand_t*)&commandBuffer[0];
	cmdPntr->attn = ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 1;
	cmdPntr->payload.bytes[0] = payload;
	SureSendCommand(cmdPntr);
}

void SureSendTwoBytePayload(u8 cmd, u8 payload1, u8 payload2)
{
	SureCommand_t* cmdPntr = (SureCommand_t*)&commandBuffer[0];
	cmdPntr->attn = ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 2;
	cmdPntr->payload.bytes[0] = payload1;
	cmdPntr->payload.bytes[1] = payload2;
	SureSendCommand(cmdPntr);
}

void SureSendThreeBytePayload(u8 cmd, u8 payload1, u8 payload2, u8 payload3)
{
	SureCommand_t* cmdPntr = (SureCommand_t*)&commandBuffer[0];
	cmdPntr->attn = ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 3;
	cmdPntr->payload.bytes[0] = payload1;
	cmdPntr->payload.bytes[1] = payload2;
	cmdPntr->payload.bytes[2] = payload3;
	SureSendCommand(cmdPntr);
}

// +--------------------------------------------------------------+
// |                  SureCmd_ Wrapper Functions                  |
// +--------------------------------------------------------------+

void SureDefaultSettings()
{
	SureSendNoPayload(SureCmd_DefaultSettings);
}

void SureClearFlags(u8 mask)
{
	SureSendOneBytePayload(SureCmd_ClearFlags, mask);
}

void SureWriteConfig(u8 config)
{
	SureSendOneBytePayload(SureCmd_WriteConfig, config);
}

void SureSetIntEnableBits(u32 intEnableBits)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_SetIntEnableBits;
	sureCmd->length = sizeof(u32);
	sureCmd->payload.intEnableBits = intEnableBits;
	SureSendCommand(sureCmd);
}

void SureReset()
{
	SureSendNoPayload(SureCmd_Reset);
}

void SureSleep()
{
	SureSendNoPayload(SureCmd_Sleep);
}

void SureQosLightshow()
{
	SureSendNoPayload(SureCmd_QosLightshow);
}

void SureTransmitData(u8 payloadLength, const u8* payloadPntr)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_TransmitData;
	sureCmd->length = payloadLength;
	memcpy(sureCmd->payload.bytes, payloadPntr, payloadLength);
	SureSendCommand(sureCmd);
}

void SureStartEncryption()
{
	SureSendNoPayload(SureCmd_StartEncryption);
}

void SureStopEncryption()
{
	SureSendNoPayload(SureCmd_StopEncryption);
}

void SureShowQualityOfService()
{
	SureSendNoPayload(SureCmd_ShowQualityOfService);
}

void SureGetStatus()
{
	SureSendNoPayload(SureCmd_GetStatus);
}

void SureGetIntEnableBits()
{
	SureSendNoPayload(SureCmd_GetIntEnableBits);
}

void SureGetModuleVersion()
{
	SureSendNoPayload(SureCmd_GetModuleVersion);
}

void SureGetPacketTimeOnAir()
{
	SureSendNoPayload(SureCmd_GetPacketTimeOnAir);
}

void SureGetRandomNumber()
{
	SureSendNoPayload(SureCmd_GetRandomNumber);
}

void SureGetPacket()
{
	SureSendNoPayload(SureCmd_GetPacket);
}

void SureGetAckPacket()
{
	SureSendNoPayload(SureCmd_GetAckPacket);
}

void SureGetReceiveInfo()
{
	SureSendNoPayload(SureCmd_GetReceiveInfo);
}

void SureGetTransmitInfo()
{
	SureSendNoPayload(SureCmd_GetTransmitInfo);
}

void SureGetRegisteredSerial()
{
	SureSendNoPayload(SureCmd_GetRegisteredSerial);
}

void SureSetAllSettings(const ModuleSettings_t* settings)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_SetAllSettings;
	sureCmd->length = sizeof(ModuleSettings_t);
	sureCmd->payload.allSettings = *settings;
	SureSendCommand(sureCmd);
}

void SureSetRadioMode(u8 radioMode)
{
	SureSendOneBytePayload(SureCmd_SetRadioMode, radioMode);
}

void SureSetRadioModeCustom(u8 spreadingFactor, u8 bandwidth)
{
	SureSendThreeBytePayload(SureCmd_SetRadioMode, RadioMode_Custom, spreadingFactor, bandwidth);
}

void SureSetFhssTable(u8 tableChoice)
{
	SureSendOneBytePayload(SureCmd_SetFhssTable, tableChoice);
}

void SureSetReceiveUID(u8 uidLength, const u8* uidPntr)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_SetReceiveUID;
	sureCmd->length = uidLength;
	memcpy(sureCmd->payload.bytes, uidPntr, uidLength);
	SureSendCommand(sureCmd);
}

void SureSetTransmitUID(u8 uidLength, const u8* uidPntr)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_SetTransmitUID;
	sureCmd->length = uidLength;
	memcpy(sureCmd->payload.bytes, uidPntr, uidLength);
	SureSendCommand(sureCmd);
}

void SureSetReceivePacketSize(u8 packetSize)
{
	SureSendOneBytePayload(SureCmd_SetReceivePacketSize, packetSize);
}

void SureSetRadioPolarity(u8 polarity)
{
	SureSendOneBytePayload(SureCmd_SetRadioPolarity, polarity);
}

void SureDisableRadioPolarity()
{
	SureSendOneBytePayload(SureCmd_SetRadioPolarity, 0x00);
}

void SureSetTransmitPower(u8 transmitPower)
{
	SureSendOneBytePayload(SureCmd_SetTransmitPower, transmitPower);
}

void SureSetAckData(u8 ackDataLength, const u8* ackDataPntr)
{
	SureCommand_t* sureCmd = (SureCommand_t*)&commandBuffer[0];
	sureCmd->attn = ATTN_CHAR;
	sureCmd->cmd = SureCmd_SetAckData;
	sureCmd->length = ackDataLength;
	memcpy(sureCmd->payload.bytes, ackDataPntr, ackDataLength);
	SureSendCommand(sureCmd);
}

void SureSetQosConfig(u8 qosConfig)
{
	SureSendOneBytePayload(SureCmd_SetQosConfig, qosConfig);
}

void SureSetIndications(u8 led1, u8 led2, u8 led3, u8 led4, u8 led5, u8 led6)
{
	SureSendThreeBytePayload(SureCmd_SetIndications,
		(led1<<0) | (led2<<4), (led3<<0) | (led4<<4), (led5<<0) | (led6<<4));
}

void SureSetQuietMode(bool enabled)
{
	SureSendOneBytePayload(SureCmd_SetQuietMode, enabled ? 0x01 : 0x00);
}

void SureSetButtonConfig(u8 holdTime, u8 buttonConfig)
{
	SureSendOneBytePayload(SureCmd_SetButtonConfig, (holdTime<<4) | buttonConfig);
}

void SureSetAcksEnabled(bool enabled)
{
	SureSendOneBytePayload(SureCmd_SetAcksEnabled, enabled ? 0x01 : 0x00);
}

void SureSetNumRetries(u8 numRetries)
{
	SureSendOneBytePayload(SureCmd_SetNumRetries, numRetries);
}

void SureGetAllSettings()
{
	//NOTE: These are all variable length and do not come in the allSettings response
	//		automatically so we have to request them seperately
	SureGetRadioMode();
	SureGetReceiveUID();
	SureGetTransmitUID();
	SureGetAckData();
	
	SureSendNoPayload(SureCmd_GetAllSettings);
}

void SureGetRadioMode()
{
	SureSendNoPayload(SureCmd_GetRadioMode);
}

void SureGetFhssTable()
{
	SureSendNoPayload(SureCmd_GetFhssTable);
}

void SureGetReceiveUID()
{
	SureSendNoPayload(SureCmd_GetReceiveUID);
}

void SureGetTransmitUID()
{
	SureSendNoPayload(SureCmd_GetTransmitUID);
}

void SureGetReceivePacketSize()
{
	SureSendNoPayload(SureCmd_GetReceivePacketSize);
}

void SureGetRadioPolarity()
{
	SureSendNoPayload(SureCmd_GetRadioPolarity);
}

void SureGetTransmitPower()
{
	SureSendNoPayload(SureCmd_GetTransmitPower);
}

void SureGetAckData()
{
	SureSendNoPayload(SureCmd_GetAckData);
}

void SureGetQosConfig()
{
	SureSendNoPayload(SureCmd_GetQosConfig);
}

void SureGetIndications()
{
	SureSendNoPayload(SureCmd_GetIndications);
}

void SureGetQuietMode()
{
	SureSendNoPayload(SureCmd_GetQuietMode);
}

void SureGetButtonConfig()
{
	SureSendNoPayload(SureCmd_GetButtonConfig);
}

void SureGetAcksEnabled()
{
	SureSendNoPayload(SureCmd_GetAcksEnabled);
}

void SureGetNumRetries()
{
	SureSendNoPayload(SureCmd_GetNumRetries);
}

// +--------------------------------------------------------------+
// |                      Blocking Functions                      |
// +--------------------------------------------------------------+


// +--------------------------------------------------------------+
// |                   Parse Debug Input String                   |
// +--------------------------------------------------------------+
bool SureHandleDebugCommand(const char* commandStr)
{
	u32 commandLength = (u32)strlen(commandStr);
	
	if (strcmp(commandStr, "defaultSettings") == 0)
	{
		SureDefaultSettings();
		return true;
	}
	else if (commandLength == 11+2 && strncmp(commandStr, "clearFlags ", 11) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[11]);
		SureClearFlags(inputValue);
		return true;
	}
	else if (commandLength == 12+2 && strncmp(commandStr, "writeConfig ", 12) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[12]);
		SureWriteConfig(inputValue);
		return true;
	}
	else if (commandLength == 17+8 && strncmp(commandStr, "setIntEnableBits ", 17) == 0)
	{
		u8 highest = ParseHexByte(&commandStr[17+0]);
		u8 high    = ParseHexByte(&commandStr[17+2]);
		u8 low     = ParseHexByte(&commandStr[17+4]);
		u8 lowest  = ParseHexByte(&commandStr[17+6]);
		u32 fullValue = (highest<<24) | (high<<16) | (low<<8) | (lowest<<0);
		SureSetIntEnableBits(fullValue);
		return true;
	}
	else if (strcmp(commandStr, "reset") == 0)
	{
		SureReset();
		return true;
	}
	else if (strcmp(commandStr, "sleep") == 0)
	{
		SureSleep();
		return true;
	}
	else if (strcmp(commandStr, "qosLightshow") == 0)
	{
		SureQosLightshow();
		return true;
	}
	else if (commandLength >= 13+2 && strncmp(commandStr, "transmitData ", 13) == 0)
	{
		u8 payloadBuffer[MAX_RX_PACKET_LENGTH];
		u8 pIndex = 0;
		for (pIndex = 0; 13 + pIndex*2 + 2 <= commandLength; pIndex++)
		{
			payloadBuffer[pIndex] = ParseHexByte(&commandStr[13 + pIndex*2]);
		}
		SureTransmitData(pIndex, payloadBuffer);
		return true;
	}
	else if (strcmp(commandStr, "startEncryption") == 0)
	{
		SureStartEncryption();
		return true;
	}
	else if (strcmp(commandStr, "stopEncryption") == 0)
	{
		SureStopEncryption();
		return true;
	}
	else if (strcmp(commandStr, "showQualityOfService") == 0)
	{
		SureShowQualityOfService();
		return true;
	}
	else if (strcmp(commandStr, "getStatus") == 0)
	{
		SureGetStatus();
		return true;
	}
	else if (strcmp(commandStr, "getIntEnableBits") == 0)
	{
		SureGetIntEnableBits();
		return true;
	}
	else if (strcmp(commandStr, "getModuleVersion") == 0)
	{
		SureGetModuleVersion();
		return true;
	}
	else if (strcmp(commandStr, "getPacketTimeOnAir") == 0)
	{
		SureGetPacketTimeOnAir();
		return true;
	}
	else if (strcmp(commandStr, "getRandomNumber") == 0)
	{
		SureGetRandomNumber();
		return true;
	}
	else if (strcmp(commandStr, "getPacket") == 0)
	{
		SureGetPacket();
		return true;
	}
	else if (strcmp(commandStr, "getAckPacket") == 0)
	{
		SureGetAckPacket();
		return true;
	}
	else if (strcmp(commandStr, "getReceiveInfo") == 0)
	{
		SureGetReceiveInfo();
		return true;
	}
	else if (strcmp(commandStr, "getTransmitInfo") == 0)
	{
		SureGetTransmitInfo();
		return true;
	}
	else if (strcmp(commandStr, "getRegisteredSerial") == 0)
	{
		SureGetRegisteredSerial();
		return true;
	}
	else if (commandLength == 15+(sizeof(ModuleSettings_t)*2) && strncmp(commandStr, "setAllSettings ", 15) == 0)
	{
		ModuleSettings_t allSettings; ClearStruct(allSettings);
		u8* bytePntr = (u8*)&allSettings;
		u8 pIndex = 0;
		for (pIndex = 0; pIndex <= sizeof(allSettings); pIndex++)
		{
			bytePntr[pIndex] = ParseHexByte(&commandStr[15 + pIndex*2]);
		}
		SureSetAllSettings(&allSettings);
		return true;
	}
	else if (commandLength == 13+2 && strncmp(commandStr, "setRadioMode ", 13) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[13]);
		SureSetRadioMode(inputValue);
		return true;
	}
	else if (commandLength == 19+4 && strncmp(commandStr, "setRadioModeCustom ", 19) == 0)
	{
		u8 spreadingFactor = ParseHexByte(&commandStr[19+0]);
		u8 bandwidth       = ParseHexByte(&commandStr[19+2]);
		SureSetRadioModeCustom(spreadingFactor, bandwidth);
		return true;
	}
	else if (commandLength == 13+2 && strncmp(commandStr, "setFhssTable ", 13) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[13]);
		SureSetFhssTable(inputValue);
		return true;
	}
	else if (commandLength >= 14+2 && commandLength <= 14+(MAX_UID_LENGTH*2) && strncmp(commandStr, "setReceiveUid ", 14) == 0)
	{
		u8 uidBuffer[MAX_UID_LENGTH];
		u8 pIndex = 0;
		for (pIndex = 0; 14 + pIndex*2 + 2 <= commandLength; pIndex++)
		{
			uidBuffer[pIndex] = ParseHexByte(&commandStr[14 + pIndex*2]);
		}
		SureSetReceiveUID(pIndex, uidBuffer);
		return true;
	}
	else if (commandLength >= 15+2 && commandLength <= 15+(MAX_UID_LENGTH*2) && strncmp(commandStr, "setTransmitUid ", 15) == 0)
	{
		u8 uidBuffer[MAX_UID_LENGTH];
		u8 pIndex = 0;
		for (pIndex = 0; 15 + pIndex*2 + 2 <= commandLength; pIndex++)
		{
			uidBuffer[pIndex] = ParseHexByte(&commandStr[15 + pIndex*2]);
		}
		SureSetTransmitUID(pIndex, uidBuffer);
		return true;
	}
	else if (commandLength == 21+2 && strncmp(commandStr, "setReceivePacketSize ", 21) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[21]);
		SureSetReceivePacketSize(inputValue);
		return true;
	}
	else if (commandLength == 17+2 && strncmp(commandStr, "setRadioPolarity ", 17) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[17]);
		SureSetRadioPolarity(inputValue);
		return true;
	}
	else if (strcmp(commandStr, "disableRadioPolarity") == 0)
	{
		SureDisableRadioPolarity();
		return true;
	}
	else if (commandLength == 17+2 && strncmp(commandStr, "setTransmitPower ", 17) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[17]);
		SureSetTransmitPower(inputValue);
		return true;
	}
	else if (commandLength >= 11+2 && strncmp(commandStr, "setAckData ", 11) == 0)
	{
		u8 payloadBuffer[MAX_RX_PACKET_LENGTH];
		u8 pIndex = 0;
		for (pIndex = 0; 11 + pIndex*2 + 2 <= commandLength; pIndex++)
		{
			payloadBuffer[pIndex] = ParseHexByte(&commandStr[11 + pIndex*2]);
		}
		SureSetAckData(pIndex, payloadBuffer);
		return true;
	}
	else if (commandLength == 13+2 && strncmp(commandStr, "setQosConfig ", 13) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[13]);
		SureSetQosConfig(inputValue);
		return true;
	}
	else if (commandLength == 15+6 && strncmp(commandStr, "setIndications ", 15) == 0)
	{
		u8 indications[3];
		indications[0] = ParseHexByte(&commandStr[15+0]);
		indications[1] = ParseHexByte(&commandStr[15+2]);
		indications[2] = ParseHexByte(&commandStr[15+4]);
		SureSetIndications(
			(indications[0]>>0)&0x0F, (indications[0]>>4)&0x0F,
			(indications[1]>>0)&0x0F, (indications[1]>>4)&0x0F,
			(indications[2]>>0)&0x0F, (indications[2]>>4)&0x0F
		);
		return true;
	}
	else if (commandLength == 13+2 && strncmp(commandStr, "setQuietMode ", 13) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[13]);
		SureSetQuietMode(inputValue);
		return true;
	}
	else if (commandLength == 16+2 && strncmp(commandStr, "setButtonConfig ", 16) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[16]);
		SureSetButtonConfig((inputValue>>4)&0x0F, (inputValue>>0)&0x0F);
		return true;
	}
	else if (commandLength == 15+2 && strncmp(commandStr, "setAcksEnabled ", 15) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[15]);
		SureSetAcksEnabled(inputValue);
		return true;
	}
	else if (commandLength == 14+2 && strncmp(commandStr, "setNumRetries ", 14) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[14]);
		SureSetNumRetries(inputValue);
		return true;
	}
	else if (strcmp(commandStr, "getAllSettings") == 0)
	{
		SureGetAllSettings();
		return true;
	}
	else if (strcmp(commandStr, "getRadioMode") == 0)
	{
		SureGetRadioMode();
		return true;
	}
	else if (strcmp(commandStr, "getFhssTable") == 0)
	{
		SureGetFhssTable();
		return true;
	}
	else if (strcmp(commandStr, "getReceiveUid") == 0)
	{
		SureGetReceiveUID();
		return true;
	}
	else if (strcmp(commandStr, "getTransmitUid") == 0)
	{
		SureGetTransmitUID();
		return true;
	}
	else if (strcmp(commandStr, "getReceivePacketSize") == 0)
	{
		SureGetReceivePacketSize();
		return true;
	}
	else if (strcmp(commandStr, "getRadioPolarity") == 0)
	{
		SureGetRadioPolarity();
		return true;
	}
	else if (strcmp(commandStr, "getTransmitPower") == 0)
	{
		SureGetTransmitPower();
		return true;
	}
	else if (strcmp(commandStr, "getAckData") == 0)
	{
		SureGetAckData();
		return true;
	}
	else if (strcmp(commandStr, "getQosConfig") == 0)
	{
		SureGetQosConfig();
		return true;
	}
	else if (strcmp(commandStr, "getIndications") == 0)
	{
		SureGetIndications();
		return true;
	}
	else if (strcmp(commandStr, "getQuietMode") == 0)
	{
		SureGetQuietMode();
		return true;
	}
	else if (strcmp(commandStr, "getButtonConfig") == 0)
	{
		SureGetButtonConfig();
		return true;
	}
	else if (strcmp(commandStr, "getAcksEnabled") == 0)
	{
		SureGetAcksEnabled();
		return true;
	}
	else if (strcmp(commandStr, "getNumRetries") == 0)
	{
		SureGetNumRetries();
		return true;
	}
	else
	{
		return false;
	}
}

