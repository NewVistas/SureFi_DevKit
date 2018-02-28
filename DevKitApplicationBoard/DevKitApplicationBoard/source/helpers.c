/*
File:   helpers.c
Author: Taylor Robbins
Date:   01\24\2018
Description: 
	** Holds some general purpose helper functions for various tasks 
*/

#include "defines.h"
#include "helpers.h"

#include "debug.h"

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
bool IsHexChar(char c)
{
	if (c >= '0' && c <= '9') { return true; }
	if (c >= 'A' && c <= 'F') { return true; }
	if (c >= 'a' && c <= 'f') { return true; }
	return false;
}

u8 GetHexCharValue(char c)
{
	if (c >= '0' && c <= '9') { return 0  + (c - '0'); }
	if (c >= 'A' && c <= 'F') { return 10 + (c - 'A'); }
	if (c >= 'a' && c <= 'f') { return 10 + (c - 'a'); }
	return 0;
}

u8 ParseHexByte(const char* chars)
{
	u8 result = 0x00;
	result += (GetHexCharValue(chars[0]) << 4);
	result += (GetHexCharValue(chars[1]) << 0);
	return result;
}

const char* GetSureErrorStr(u8 sureError)
{
	switch (sureError)
	{
		case SureError_ValueTooLow:     return "Value Too Low";
		case SureError_ValueTooHigh:    return "Value Too High";
		case SureError_InvalidValue:    return "Invalid Value";
		case SureError_PayloadTooLarge: return "Payload Too Large";
		case SureError_PayloadTooSmall: return "Payload Too Small";
		case SureError_Busy:            return "Busy";
		case SureError_InvalidSettings: return "Invalid Settings";
		case SureError_NotFccApproved:  return "Not Fcc Approved";
		case SureError_AlreadyStarted:  return "Already Started";
		case SureError_Unsupported:     return "Unsupported";
		default: return "Unknown";
	};
}

const char* GetSureCmdStr(u8 sureCmd)
{
	switch (sureCmd)
	{
		case SureCmd_DefaultSettings:        return "DefaultSettings";
		case SureCmd_ClearFlags:             return "ClearFlags";
		case SureCmd_WriteConfig:            return "WriteConfig";
		case SureCmd_SetIntEnableBits:       return "SetIntEnableBits";
		case SureCmd_Reset:                  return "Reset";
		case SureCmd_Sleep:                  return "Sleep";
		case SureCmd_QosLightshow:           return "QosLightshow";
		case SureCmd_TransmitData:           return "TransmitData";
		case SureCmd_StartEncryption:        return "StartEncryption";
		case SureCmd_StopEncryption:         return "StopEncryption";
		case SureCmd_ShowQualityOfService:   return "ShowQualityOfService";
		case SureCmd_GetStatus:              return "GetStatus";
		case SureCmd_GetIntEnableBits:       return "GetIntEnableBits";
		case SureCmd_GetModuleVersion:       return "GetModuleVersion";
		case SureCmd_GetPacketTimeOnAir:     return "GetPacketTimeOnAir";
		case SureCmd_GetRandomNumber:        return "GetRandomNumber";
		case SureCmd_GetPacket:              return "GetPacket";
		case SureCmd_GetAckPacket:           return "GetAckPacket";
		case SureCmd_GetReceiveInfo:         return "GetReceiveInfo";
		case SureCmd_GetTransmitInfo:        return "GetTransmitInfo";
		case SureCmd_GetRegisteredSerial:    return "GetRegisteredSerial";
		case SureCmd_SetAllSettings:         return "SetAllSettings";
		case SureCmd_SetRadioMode:           return "SetRadioMode";
		case SureCmd_SetFhssTable:           return "SetFhssTable";
		case SureCmd_SetReceiveUID:          return "SetReceiveUID";
		case SureCmd_SetTransmitUID:         return "SetTransmitUID";
		case SureCmd_SetReceivePacketSize:   return "SetReceivePacketSize";
		case SureCmd_SetRadioPolarity:       return "SetRadioPolarity";
		case SureCmd_SetTransmitPower:       return "SetTransmitPower";
		case SureCmd_SetAckData:             return "SetAckData";
		case SureCmd_SetTableHoppingEnabled: return "SetTableHoppingEnabled";
		case SureCmd_SetQosConfig:           return "SetQosConfig";
		case SureCmd_SetIndications:         return "SetIndications";
		case SureCmd_SetQuietMode:           return "SetQuietMode";
		case SureCmd_SetButtonConfig:        return "SetButtonConfig";
		case SureCmd_SetAcksEnabled:         return "SetAcksEnabled";
		case SureCmd_SetNumRetries:          return "SetNumRetries";
		case SureCmd_GetAllSettings:         return "GetAllSettings";
		case SureCmd_GetRadioMode:           return "GetRadioMode";
		case SureCmd_GetFhssTable:           return "GetFhssTable";
		case SureCmd_GetReceiveUID:          return "GetReceiveUID";
		case SureCmd_GetTransmitUID:         return "GetTransmitUID";
		case SureCmd_GetReceivePacketSize:   return "GetReceivePacketSize";
		case SureCmd_GetRadioPolarity:       return "GetRadioPolarity";
		case SureCmd_GetTransmitPower:       return "GetTransmitPower";
		case SureCmd_GetAckData:             return "GetAckData";
		case SureCmd_GetTableHoppingEnabled: return "GetTableHoppingEnabled";
		case SureCmd_GetQosConfig:           return "GetQosConfig";
		case SureCmd_GetIndications:         return "GetIndications";
		case SureCmd_GetQuietMode:           return "GetQuietMode";
		case SureCmd_GetButtonConfig:        return "GetButtonConfig";
		case SureCmd_GetAcksEnabled:         return "GetAcksEnabled";
		case SureCmd_GetNumRetries:          return "GetNumRetries";
		default: return "Unknown";
	};
}

const char* GetBleErrorStr(u8 bleError)
{
	switch (bleError)
	{
		case BleError_ValueTooLow:     return "Value Too Low";
		case BleError_ValueTooHigh:    return "Value Too High";
		case BleError_InvalidValue:    return "Invalid Value";
		case BleError_PayloadTooLarge: return "Payload Too Large";
		case BleError_PayloadTooSmall: return "Payload Too Small";
		case BleError_Busy:            return "Busy";
		case BleError_InvalidSettings: return "Invalid Settings";
		case BleError_NotFccApproved:  return "Not Fcc Approved";
		case BleError_AlreadyStarted:  return "Already Started";
		case BleError_Unsupported:     return "Unsupported";
		case BleError_NotStarted:      return "Not Started";
		default: return "Unknown";
	};
}

const char* GetBleCmdStr(u8 bleCmd)
{
	switch (bleCmd)
	{
		case BleCmd_StartAdvertising:     return "StartAdvertising";
		case BleCmd_StopAdvertising:      return "StopAdvertising";
		case BleCmd_CloseConnection:      return "CloseConnection";
		case BleCmd_StartDfuMode:         return "StartDfuMode";
		case BleCmd_ReadExmem:            return "ReadExmem";
		case BleCmd_WriteExmem:           return "WriteExmem";
		case BleCmd_ClearExmem:           return "ClearExmem";
		case BleCmd_ClearResetFlag:       return "ClearResetFlag";
		case BleCmd_GetFirmwareVersion:   return "GetFirmwareVersion";
		case BleCmd_GetStatus:            return "GetStatus";
		case BleCmd_SetStatusUpdateBits:  return "SetStatusUpdateBits";
		case BleCmd_SetAdvertisingData:   return "SetAdvertisingData";
		case BleCmd_SetAdvertisingName:   return "SetAdvertisingName";
		case BleCmd_SetTemporaryData:     return "SetTemporaryData";
		case BleCmd_SetGpioConfiguration: return "SetGpioConfiguration";
		case BleCmd_SetGpioValue:         return "SetGpioValue";
		case BleCmd_SetGpioUpdateEnabled: return "SetGpioUpdateEnabled";
		case BleCmd_GetStatusUpdateBits:  return "GetStatusUpdateBits";
		case BleCmd_GetAdvertisingData:   return "GetAdvertisingData";
		case BleCmd_GetAdvertisingName:   return "GetAdvertisingName";
		case BleCmd_GetTemporaryData:     return "GetTemporaryData";
		case BleCmd_GetGpioConfiguration: return "GetGpioConfiguration";
		case BleCmd_GetGpioValue:         return "GetGpioValue";
		case BleCmd_GetGpioUpdateEnabled: return "GetGpioUpdateEnabled";
		default: return "Unknown";
	};
}

void PrintU64(u64 value)
{
	u8* bytePntr = (u8*)&value;
	Print_I("%02X%02X%02X%02X%02X%02X%02X%02X",
		bytePntr[7], bytePntr[6], bytePntr[5], bytePntr[4],
		bytePntr[3], bytePntr[2], bytePntr[1], bytePntr[0]
	);
}
