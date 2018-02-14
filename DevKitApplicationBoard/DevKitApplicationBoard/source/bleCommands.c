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

void BleSetGpioDirection(u8 gpioIndex, u8 direction)
{
	BleSendTwoBytePayload(BleCmd_SetGpioDirection, gpioIndex, direction);
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

