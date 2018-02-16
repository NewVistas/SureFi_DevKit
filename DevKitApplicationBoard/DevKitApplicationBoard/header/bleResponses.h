/*
File:   bleResponses.h
Author: Taylor Robbins
Date:   02\14\2018
*/

#ifndef _BLE_RESPONSES_H
#define _BLE_RESPONSES_H

// +--------------------------------------------------------------+
// |              Public Structure/Type Definitions               |
// +--------------------------------------------------------------+
typedef void BleResetCallback_f();

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
bool PrintBleResponses;
bool PrintBleStatusUpdates;
bool PrintBleSuccesses;
bool PrintBleFailures;

extern u32 BleExmemDataAddress;
extern u8 BleExmemDataLength;
extern u8 BleExmemData[255];             extern bool BleGotExmemData;
extern FullVersion_t BleFirmwareVersion; extern bool BleGotFirmwareVersion;
extern BleStatus_t BleStatus;            extern bool BleGotStatus;
extern u8 BleSuccessCommand;             extern bool BleGotSuccess;
extern u8 BleFailureCommand;
extern u8 BleFailureErrorCode;           extern bool BleGotFailure;
extern BleStatus_t BleStatusUpdateBits;  extern bool BleGotStatusUpdateBits;
extern u8 BleAdvertisingDataLength;
extern u8 BleAdvertisingData[32];        extern bool BleGotAdvertisingData;
extern u8 BleAdvertisingNameLength;
extern u8 BleAdvertisingName[32];        extern bool BleGotAdvertisingName;
extern u8 BleTemporaryDataLength;
extern u8 BleTemporaryData[255];         extern bool BleGotTemporaryData;
extern u8 BleGpioIndex;
extern u8 BleGpioValue;                  extern bool BleGotGpioValue;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitBleResponses();
void SetBleResponseCallbacks(BleResetCallback_f* bleResetCallback);
void BleClearGotFlags();
void HandleBleResponse(const BleCommand_t* rsp);

#endif //  _BLE_RESPONSES_H
