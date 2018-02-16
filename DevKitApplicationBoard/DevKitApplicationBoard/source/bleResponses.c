/*
File:   bleResponses.c
Author: Taylor Robbins
Date:   02\14\2018
Description: 
	** Handles the responses that come from the bluetooth UART 
*/


#include "defines.h"
#include "bleResponses.h"

#include "debug.h"
#include "bleCommands.h"
#include "uartFifos.h"
#include "jumper.h"

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
bool PrintBleResponses = false;
bool PrintBleStatusUpdates = false;
bool PrintBleSuccesses = false;
bool PrintBleFailures = true;

u32 BleExmemDataAddress = 0x00000000;
u8 BleExmemDataLength = 0;
u8 BleExmemData[255];             bool BleGotExmemData = false;
FullVersion_t BleFirmwareVersion; bool BleGotFirmwareVersion = false;
BleStatus_t BleStatus;            bool BleGotStatus = false;
u8 BleSuccessCommand;             bool BleGotSuccess = false;
u8 BleFailureCommand;
u8 BleFailureErrorCode;           bool BleGotFailure = false;
BleStatus_t BleStatusUpdateBits;  bool BleGotStatusUpdateBits = false;
u8 BleAdvertisingDataLength = 0;
u8 BleAdvertisingData[32];        bool BleGotAdvertisingData = false;
u8 BleAdvertisingNameLength = 0;
u8 BleAdvertisingName[32];        bool BleGotAdvertisingName = false;
u8 BleTemporaryDataLength = 0;
u8 BleTemporaryData[255];         bool BleGotTemporaryData = false;
u8 BleGpioIndex = 0;
u8 BleGpioValue;                  bool BleGotGpioValue = false;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static u8 cmdBuffer[BLE_COMMAND_HEADER_SIZE+255];
static BleResetCallback_f* bleResetCallbackPntr = nullptr;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitBleResponses()
{
	ClearStruct(BleStatus);
	
	ClearArray(cmdBuffer);
}

void SetBleResponseCallbacks(BleResetCallback_f* bleResetCallback)
{
	bleResetCallbackPntr = bleResetCallback;
}

void BleClearGotFlags()
{
	BleGotStatus = false;
}

void HandleBleResponse(const BleCommand_t* rsp)
{
	u32 bIndex = 0;
	
	switch (rsp->cmd)
	{
		// +==============================+
		// |    BleRsp_DfuNeedAdvData     |
		// +==============================+
		// case BleRsp_DfuNeedAdvData:
		// {
		// 	PrintLine_D("BleRsp_DfuNeedAdvData[%u]", rsp->length);
		// 	//TODO: Implement me!
		// } break;
		
		// +==============================+
		// |       BleRsp_ExmemData       |
		// +==============================+
		case BleRsp_ExmemData:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_ExmemData[%u] %08X", rsp->length, rsp->payload);
			}
			BleExmemDataAddress = rsp->payload.exmem.address;
			BleExmemDataLength = (rsp->length-sizeof(u32));
			if (BleExmemDataLength > ArrayCount(BleExmemData)) { BleExmemDataLength = ArrayCount(BleExmemData); }
			memcpy(BleExmemData, rsp->payload.exmem.data, BleExmemDataLength);
			BleGotExmemData = true;
		} break;
		
		// +==============================+
		// |    BleRsp_FirmwareVersion    |
		// +==============================+
		case BleRsp_FirmwareVersion:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_FirmwareVersion[%u] %u.%u(%u)", rsp->length, rsp->payload.firmwareVersion.major, rsp->payload.firmwareVersion.minor, rsp->payload.firmwareVersion.build);
			}
			BleFirmwareVersion = rsp->payload.firmwareVersion;
			BleGotFirmwareVersion = true;
		} break;
		
		// +==============================+
		// |        BleRsp_Status         |
		// +==============================+
		case BleRsp_Status:
		{
			if (PrintBleStatusUpdates)
			{
				PrintLine_D("BleRsp_Status[%u]: 0x%02X", rsp->length, rsp->payload.status.fullValue);
			}
			
			BleStatus_t statusChanged;
			statusChanged.fullValue = (rsp->payload.status.fullValue ^ BleStatus.fullValue);
			
			if (rsp->payload.status.wasReset)
			{
				BleClearResetFlag();
				if (statusChanged.wasReset)
				{
					WriteLine_E("BLE was reset!");
					if (bleResetCallbackPntr != nullptr)
					{
						bleResetCallbackPntr();
					}
				}
			}
			
			if (statusChanged.connected)
			{
				PrintLine_I("Bluetooth %s!", rsp->payload.status.connected ? "Connected" : "Disconnected");
			}
			
			//TODO: Process the rest status
			
			BleStatus = rsp->payload.status;
			BleGotStatus = true;
		} break;
		
		// +==============================+
		// |        BleRsp_Success        |
		// +==============================+
		case BleRsp_Success:
		{
			if (PrintBleSuccesses)
			{
				PrintLine_I("%s Succeeded!", GetBleCmdStr(rsp->payload.bytes[0]));
			}
			BleSuccessCommand = rsp->payload.bytes[0];
			BleGotSuccess = true;
		} break;
		
		// +==============================+
		// |        BleRsp_Failure        |
		// +==============================+
		case BleRsp_Failure:
		{
			if (PrintBleFailures)
			{
				PrintLine_E("%s Failed! Error: %s", GetBleCmdStr(rsp->payload.bytes[0]), GetBleErrorStr(rsp->payload.bytes[1]));
			}
			BleFailureCommand = rsp->payload.bytes[0];
			BleFailureErrorCode = rsp->payload.bytes[1];
			BleGotFailure = true;
		} break;
		
		// +==============================+
		// |      BleRsp_UartTimeout      |
		// +==============================+
		case BleRsp_UartTimeout:
		{
			if (PrintBleFailures)
			{
				PrintLine_E("BleRsp_UartTimeout[%u]", rsp->length);
			}
			//TODO: Implement me!
		} break;
		
		// +==============================+
		// |   BleRsp_StatusUpdateBits    |
		// +==============================+
		case BleRsp_StatusUpdateBits:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_StatusUpdateBits[%u] 0x%02X", rsp->length, rsp->payload.updateBits.fullValue);
			}
			BleStatusUpdateBits = rsp->payload.updateBits;
			BleGotStatusUpdateBits = true;
		} break;
		
		// +==============================+
		// |    BleRsp_AdvertisingData    |
		// +==============================+
		case BleRsp_AdvertisingData:
		{
			if (PrintBleResponses)
			{
				Print_D("BleRsp_AdvertisingData[%u]: ", rsp->length);
				for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("");
			}
			BleAdvertisingDataLength = rsp->length;
			if (BleAdvertisingDataLength > ArrayCount(BleAdvertisingData)) { BleAdvertisingDataLength = ArrayCount(BleAdvertisingData); }
			memcpy(BleAdvertisingData, rsp->payload.bytes, BleAdvertisingDataLength);
			BleGotAdvertisingData = true;
		} break;
		
		// +==============================+
		// |    BleRsp_AdvertisingName    |
		// +==============================+
		case BleRsp_AdvertisingName:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_AdvertisingName[%u] \"%.*s\"", rsp->length, rsp->length, (const char*)rsp->payload.bytes);
			}
			BleAdvertisingNameLength = rsp->length;
			if (BleAdvertisingNameLength > ArrayCount(BleAdvertisingName)) { BleAdvertisingNameLength = ArrayCount(BleAdvertisingName); }
			memcpy(BleAdvertisingName, rsp->payload.bytes, BleAdvertisingNameLength);
			BleGotAdvertisingName = true;
		} break;
		
		// +==============================+
		// |     BleRsp_TemporaryData     |
		// +==============================+
		case BleRsp_TemporaryData:
		{
			if (PrintBleResponses)
			{
				Print_D("BleRsp_TemporaryData[%u]: ", rsp->length);
				for (bIndex = 0; bIndex < rsp->length; bIndex++)
				{
					Print_D("%02X ", rsp->payload.bytes[bIndex]);
				}
				WriteLine_D("");
			}
			BleTemporaryDataLength = rsp->length;
			if (BleTemporaryDataLength > ArrayCount(BleTemporaryData)) { BleTemporaryDataLength = ArrayCount(BleTemporaryData); }
			memcpy(BleTemporaryData, rsp->payload.bytes, BleTemporaryDataLength);
			BleGotTemporaryData = true;
		} break;
		
		// +==============================+
		// |       BleRsp_GpioValue       |
		// +==============================+
		case BleRsp_GpioValue:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_GpioValue[%u] TP%u = %u", rsp->length, rsp->payload.gpio.index, rsp->payload.gpio.value);
			}
			BleGpioIndex = rsp->payload.gpio.index;
			BleGpioValue = rsp->payload.gpio.value;
			BleGotGpioValue = true;
		} break;
		
		// +==============================+
		// |   BleRsp_GpioUpdateEnabled   |
		// +==============================+
		case BleRsp_GpioUpdateEnabled:
		{
			if (PrintBleResponses)
			{
				PrintLine_D("BleRsp_GpioUpdateEnabled[%u] TP%u updates %s", rsp->length, rsp->payload.gpio.index, rsp->payload.gpio.updateEnabled ? "Enabled" : "Disabled");
			}
			//TODO: Should we add some variables to hold this value? (BleUpdateEnabled array, BleGotUpdateEnabled array)
		} break;
		
		default:
		{
			PrintLine_E("Got unknown %u byte BLE response 0x%02X", rsp->length, rsp->cmd);
		} break;
	}
}
