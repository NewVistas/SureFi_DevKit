/*
File:   bleCommands.c
Author: Taylor Robbins
Date:   02\14\2018
Description: 
	** Holds a simple abstraction layer for sending alternate commands to the
	** bluetooth (ones prefixed with BLE_ATTN_CHAR instead of ATTN_CHAR) 
*/

#include "defines.h"
#include "bleCommands.h"

#include "debug.h"
#include "uartFifos.h"
#include "helpers.h"

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 commandBuffer[BLE_COMMAND_HEADER_SIZE+255];

// +--------------------------------------------------------------+
// |                      Generic Functions                       |
// +--------------------------------------------------------------+
void BleSendCommand(const BleCommand_t* commandPntr)
{
	AppUartSendData(AppUart_SureFiBle, (u8*)commandPntr, BLE_COMMAND_HEADER_SIZE + commandPntr->length);
}

void BleSendCommandBytes(const u8* bytesPntr)
{
	BleSendCommand((BleCommand_t*)bytesPntr);
}

void BleSendNoPayload(u8 cmd)
{
	BleCommand_t* cmdPntr = (BleCommand_t*)&commandBuffer[0];
	cmdPntr->attn = BLE_ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 0;
	BleSendCommand(cmdPntr);
}

void BleSendOneBytePayload(u8 cmd, u8 payload)
{
	BleCommand_t* cmdPntr = (BleCommand_t*)&commandBuffer[0];
	cmdPntr->attn = BLE_ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 1;
	cmdPntr->payload.bytes[0] = payload;
	BleSendCommand(cmdPntr);
}

void BleSendTwoBytePayload(u8 cmd, u8 payload1, u8 payload2)
{
	BleCommand_t* cmdPntr = (BleCommand_t*)&commandBuffer[0];
	cmdPntr->attn = BLE_ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 2;
	cmdPntr->payload.bytes[0] = payload1;
	cmdPntr->payload.bytes[1] = payload2;
	BleSendCommand(cmdPntr);
}

void BleSendThreeBytePayload(u8 cmd, u8 payload1, u8 payload2, u8 payload3)
{
	BleCommand_t* cmdPntr = (BleCommand_t*)&commandBuffer[0];
	cmdPntr->attn = BLE_ATTN_CHAR;
	cmdPntr->cmd = cmd;
	cmdPntr->length = 3;
	cmdPntr->payload.bytes[0] = payload1;
	cmdPntr->payload.bytes[1] = payload2;
	cmdPntr->payload.bytes[2] = payload3;
	BleSendCommand(cmdPntr);
}

// +--------------------------------------------------------------+
// |                  BleCmd_ Wrapper Functions                   |
// +--------------------------------------------------------------+

void BleStartAdvertising()
{
	BleSendNoPayload(BleCmd_StartAdvertising);
}

void BleStopAdvertising()
{
	BleSendNoPayload(BleCmd_StopAdvertising);
}

void BleCloseConnection()
{
	BleSendNoPayload(BleCmd_CloseConnection);
}

void BleStartDfuMode()
{
	BleSendNoPayload(BleCmd_StartDfuMode);
}

void BleReadExmem(u32 address, u8 numBytes)
{
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_ReadExmem;
	bleCmd->length = sizeof(u32) + sizeof(u8);
	bleCmd->payload.exmem.address = address;
	bleCmd->payload.exmem.numBytes = numBytes;
	BleSendCommand(bleCmd);
}

void BleWriteExmem(u32 address, const u8* dataPntr, u8 dataLength)
{
	if (dataLength > 255-sizeof(u32))
	{
		//Too many bytes, can't fit in command
		return;
	}
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_WriteExmem;
	bleCmd->length = sizeof(u32) + dataLength;
	bleCmd->payload.exmem.address = address;
	memcpy(bleCmd->payload.exmem.data, dataPntr, dataLength);
	BleSendCommand(bleCmd);
}

void BleClearExmem(u32 address)
{
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_ClearExmem;
	bleCmd->length = sizeof(u32);
	bleCmd->payload.exmem.address = address;
	BleSendCommand(bleCmd);
}

void BleSetGpioOutput(u8 gpioIndex)
{
	BleSendTwoBytePayload(BleCmd_SetGpioDirection, gpioIndex, BleGpioDir_Output);
}

void BleSetGpioInput(u8 gpioIndex, u8 pull)
{
	BleSendThreeBytePayload(BleCmd_SetGpioDirection, gpioIndex, BleGpioDir_Input, pull);
}

void BleClearResetFlag()
{
	BleSendNoPayload(BleCmd_ClearResetFlag);
}

void BleGetFirmwareVersion()
{
	BleSendNoPayload(BleCmd_GetFirmwareVersion);
}

void BleGetStatus()
{
	BleSendNoPayload(BleCmd_GetStatus);
}

void BleSetStatusUpdateBits(u8 updateBits)
{
	BleSendOneBytePayload(BleCmd_SetStatusUpdateBits, updateBits);
}

void BleSetAdvertisingData(const u8* dataPntr, u8 dataLength)
{
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_SetAdvertisingData;
	bleCmd->length = dataLength;
	if (dataLength > 0)
	{
		memcpy(bleCmd->payload.bytes, dataPntr, dataLength);
	}
	BleSendCommand(bleCmd);
}

void BleSetAdvertisingName(const char* namePntr, u8 nameLength)
{
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_SetAdvertisingName;
	bleCmd->length = nameLength;
	if (nameLength > 0)
	{
		memcpy(bleCmd->payload.bytes, namePntr, nameLength);
	}
	BleSendCommand(bleCmd);
}

void BleSetTemporaryData(const u8* dataPntr, u8 dataLength)
{
	BleCommand_t* bleCmd = (BleCommand_t*)&commandBuffer[0];
	bleCmd->attn = BLE_ATTN_CHAR;
	bleCmd->cmd = BleCmd_SetTemporaryData;
	bleCmd->length = dataLength;
	if (dataLength > 0)
	{
		memcpy(bleCmd->payload.bytes, dataPntr, dataLength);
	}
	BleSendCommand(bleCmd);
}

void BleSetGpioValue(u8 gpioIndex, u8 value)
{
	BleSendTwoBytePayload(BleCmd_SetGpioValue, gpioIndex, value);
}

void BleSetGpioUpdateEnabled(u8 gpioIndex, bool enabled)
{
	BleSendTwoBytePayload(BleCmd_SetGpioUpdateEnabled, gpioIndex, (enabled ? 0x01 : 0x00));
}

void BleGetStatusUpdateBits()
{
	BleSendNoPayload(BleCmd_GetStatusUpdateBits);
}

void BleGetAdvertisingData()
{
	BleSendNoPayload(BleCmd_GetAdvertisingData);
}

void BleGetAdvertisingName()
{
	BleSendNoPayload(BleCmd_GetAdvertisingName);
}

void BleGetTemporaryData()
{
	BleSendNoPayload(BleCmd_GetTemporaryData);
}

void BleGetGpioValue(u8 gpioIndex)
{
	BleSendOneBytePayload(BleCmd_GetGpioValue, gpioIndex);
}

void BleGetGpioUpdateEnabled(u8 gpioIndex)
{
	BleSendOneBytePayload(BleCmd_GetGpioUpdateEnabled, gpioIndex);
}

// +--------------------------------------------------------------+
// |                   Parse Debug Input String                   |
// +--------------------------------------------------------------+
bool BleHandleDebugCommand(const char* commandStr)
{
	u32 commandLength = (u32)strlen(commandStr);
	
	if (strcmp(commandStr, "bleStartAdvertising") == 0)
	{
		BleStartAdvertising();
		return true;
	}
	else if (strcmp(commandStr, "bleStopAdvertising") == 0)
	{
		BleStopAdvertising();
		return true;
	}
	else if (strcmp(commandStr, "bleCloseConnection") == 0)
	{
		BleCloseConnection();
		return true;
	}
	else if (strcmp(commandStr, "bleStartDfuMode") == 0)
	{
		BleStartDfuMode();
		return true;
	}
	// else if (strcmp(commandStr, "bleReadExmem") == 0)
	// {
	// }
	// else if (strcmp(commandStr, "bleWriteExmem") == 0)
	// {
	// 	return true;
	// }
	// else if (strcmp(commandStr, "bleClearExmem") == 0)
	// {
	// 	return true;
	// }
	else if (commandLength == 16+2+1+2 && strncmp(commandStr, "bleSetGpioInput ", 16) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[16]);
		u8 gpioPull = ParseHexByte(&commandStr[16+3]);
		BleSetGpioInput(gpioNumber, gpioPull);
		return true;
	}
	else if (commandLength == 17+2 && strncmp(commandStr, "bleSetGpioOutput ", 17) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[17]);
		BleSetGpioOutput(gpioNumber);
		return true;
	}
	else if (strcmp(commandStr, "bleClearResetFlag") == 0)
	{
		BleClearResetFlag();
		return true;
	}
	else if (strcmp(commandStr, "bleGetFirmwareVersion") == 0)
	{
		BleGetFirmwareVersion();
		return true;
	}
	else if (strcmp(commandStr, "bleGetStatus") == 0)
	{
		BleGetStatus();
		return true;
	}
	else if (commandLength == 23+2 && strncmp(commandStr, "bleSetStatusUpdateBits ", 23) == 0)
	{
		u8 inputValue = ParseHexByte(&commandStr[23]);
		BleSetStatusUpdateBits(inputValue);
		return true;
	}
	else if (commandLength >= 22 && strncmp(commandStr, "bleSetAdvertisingData ", 22) == 0)
	{
		u8 payloadBuffer[MAX_ADV_DATA_LENGTH];
		u8 pIndex = 0;
		for (pIndex = 0; 22 + pIndex*2 + 2 <= commandLength && pIndex < ArrayCount(payloadBuffer); pIndex++)
		{
			payloadBuffer[pIndex] = ParseHexByte(&commandStr[22 + pIndex*2]);
		}
		BleSetAdvertisingData(payloadBuffer, pIndex);
		return true;
	}
	else if (commandLength >= 22 && strncmp(commandStr, "bleSetAdvertisingName ", 22) == 0)
	{
		const char* namePntr = (const char*)&commandStr[22];
		BleSetAdvertisingName(namePntr, (u8)strlen(namePntr));
		return true;
	}
	else if (commandLength >= 20 && strncmp(commandStr, "bleSetTemporaryData ", 20) == 0)
	{
		u8 payloadBuffer[255];
		u8 pIndex = 0;
		for (pIndex = 0; 20 + pIndex*2 + 2 <= commandLength && pIndex < ArrayCount(payloadBuffer); pIndex++)
		{
			payloadBuffer[pIndex] = ParseHexByte(&commandStr[20 + pIndex*2]);
		}
		BleSetTemporaryData(payloadBuffer, pIndex);
		return true;
	}
	else if (commandLength == 16+2+1+2 && strncmp(commandStr, "bleSetGpioValue ", 16) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[16]);
		u8 gpioValue = ParseHexByte(&commandStr[16+3]);
		BleSetGpioValue(gpioNumber, gpioValue);
		return true;
	}
	else if (commandLength == 24+2+1+2 && strncmp(commandStr, "bleSetGpioUpdateEnabled ", 24) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[24]);
		u8 inputValue = ParseHexByte(&commandStr[24+3]);
		BleSetGpioUpdateEnabled(gpioNumber, (inputValue != 0));
		return true;
	}
	else if (strcmp(commandStr, "bleGetStatusUpdateBits") == 0)
	{
		BleGetStatusUpdateBits();
		return true;
	}
	else if (strcmp(commandStr, "bleGetAdvertisingData") == 0)
	{
		BleGetAdvertisingData();
		return true;
	}
	else if (strcmp(commandStr, "bleGetAdvertisingName") == 0)
	{
		BleGetAdvertisingName();
		return true;
	}
	else if (strcmp(commandStr, "bleGetTemporaryData") == 0)
	{
		BleGetTemporaryData();
		return true;
	}
	else if (commandLength == 16+2 && strncmp(commandStr, "bleGetGpioValue ", 16) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[16]);
		BleGetGpioValue(gpioNumber);
		return true;
	}
	else if (commandLength == 24+2 && strncmp(commandStr, "bleGetGpioUpdateEnabled ", 24) == 0)
	{
		u8 gpioNumber = ParseHexByte(&commandStr[24]);
		BleGetGpioUpdateEnabled(gpioNumber);
		return true;
	}
	else
	{
		return false;
	}
}

