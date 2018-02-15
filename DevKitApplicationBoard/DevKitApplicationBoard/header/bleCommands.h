/*
File:   bleCommands.h
Author: Taylor Robbins
Date:   02\14\2018
*/

#ifndef _BLE_COMMANDS_H
#define _BLE_COMMANDS_H

// +--------------------------------------------------------------+
// |                      Generic Functions                       |
// +--------------------------------------------------------------+
void BleSendCommand(const BleCommand_t* commandPntr);
void BleSendCommandBytes(const u8* bytesPntr);
void BleSendNoPayload(u8 cmd);
void BleSendOneBytePayload(u8 cmd, u8 payload);
void BleSendTwoBytePayload(u8 cmd, u8 payload1, u8 payload2);
void BleSendThreeBytePayload(u8 cmd, u8 payload1, u8 payload2, u8 payload3);

// +--------------------------------------------------------------+
// |                  BleCmd_ Wrapper Functions                   |
// +--------------------------------------------------------------+
void BleStartAdvertising();
void BleStopAdvertising();
void BleCloseConnection();
void BleStartDfuMode();
void BleReadExmem(u32 address, u8 numBytes);
void BleWriteExmem(u32 address, const u8* dataPntr, u8 dataLength);
void BleClearExmem(u32 address);
void BleSetGpioOutput(u8 gpioIndex);
void BleSetGpioInput(u8 gpioIndex, u8 pull);
void BleClearResetFlag();

void BleGetFirmwareVersion();
void BleGetStatus();

void BleSetStatusUpdateBits(u8 updateBits);
void BleSetAdvertisingData(const u8* dataPntr, u8 dataLength);
void BleSetAdvertisingName(const char* namePntr, u8 nameLength);
void BleSetTemporaryData(const u8* dataPntr, u8 dataLength);
void BleSetGpioValue(u8 gpioIndex, u8 value);

void BleGetStatusUpdateBits();
void BleGetAdvertisingData();
void BleGetAdvertisingName();
void BleGetTemporaryData();
void BleGetGpioValue(u8 gpioIndex);

// +--------------------------------------------------------------+
// |                   Parse Debug Input String                   |
// +--------------------------------------------------------------+
bool BleHandleDebugCommand(const char* commandStr);

#endif //  _BLE_COMMANDS_H
