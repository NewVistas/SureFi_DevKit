/*
File:   sureCommands.h
Author: Taylor Robbins
Date:   01\24\2018
*/

#ifndef _SURE_COMMANDS_H
#define _SURE_COMMANDS_H

// +--------------------------------------------------------------+
// |                      Generic Functions                       |
// +--------------------------------------------------------------+
void SureSendCommand(const SureCommand_t* commandPntr);
void SureSendCommandBytes(const u8* bytesPntr);
void SureSendOneBytePayload(u8 cmd, u8 payload);
void SureSendTwoBytePayload(u8 cmd, u8 payload1, u8 payload2);
void SureSendThreeBytePayload(u8 cmd, u8 payload1, u8 payload2, u8 payload3);
void SureSendNoPayload(u8 cmd);

// +--------------------------------------------------------------+
// |                    Non-Blocking Functions                    |
// +--------------------------------------------------------------+
void SureDefaultSettings();
void SureClearFlags(u8 mask);
void SureWriteConfig(u8 config);
void SureSetIntEnableBits(u32 intEnableBits);
void SureReset();
void SureSleep();
void SureQosLightshow();
void SureTransmitData(u8 payloadLength, const u8* payloadPntr);
void SureStartEncryption();
void SureStopEncryption();
void SureShowQualityOfService();
void SureGetStatus();
void SureGetIntEnableBits();
void SureGetModuleVersion();
void SureGetPacketTimeOnAir();
void SureGetRandomNumber();
void SureGetPacket();
void SureGetAckPacket();
void SureGetReceiveInfo();
void SureGetTransmitInfo();
void SureGetRegisteredSerial();
void SureSetAllSettings(const ModuleSettings_t* settings);
void SureSetRadioMode(u8 radioMode);
void SureSetRadioModeCustom(u8 spreadingFactor, u8 bandwidth);
void SureSetFhssTable(u8 tableChoice);
void SureSetReceiveUID(u8 uidLength, const u8* uidPntr);
void SureSetTransmitUID(u8 uidLength, const u8* uidPntr);
void SureSetReceivePacketSize(u8 packetSize);
void SureSetRadioPolarity(u8 polarity);
void SureDisableRadioPolarity();
void SureSetTransmitPower(u8 transmitPower);
void SureSetAckData(u8 ackDataLength, const u8* ackDataPntr);
void SureSetQosConfig(u8 qosConfig);
void SureSetIndications(u8 led1, u8 led2, u8 led3, u8 led4, u8 led5, u8 led6);
void SureSetQuietMode(bool enabled);
void SureSetButtonConfig(u8 holdTime, u8 buttonConfig);
void SureSetAcksEnabled(bool enabled);
void SureSetNumRetries(u8 numRetries);
void SureGetAllSettings();
void SureGetRadioMode();
void SureGetFhssTable();
void SureGetReceiveUID();
void SureGetTransmitUID();
void SureGetReceivePacketSize();
void SureGetRadioPolarity();
void SureGetTransmitPower();
void SureGetAckData();
void SureGetQosConfig();
void SureGetIndications();
void SureGetQuietMode();
void SureGetButtonConfig();
void SureGetAcksEnabled();
void SureGetNumRetries();

// +--------------------------------------------------------------+
// |                      Blocking Functions                      |
// +--------------------------------------------------------------+


// +--------------------------------------------------------------+
// |                   Parse Debug Input String                   |
// +--------------------------------------------------------------+
bool SureHandleDebugCommand(const char* commandStr);

#endif //  _SURE_COMMANDS_H
