/*
File:   sureResponses.h
Author: Taylor Robbins
Date:   01\24\2018
*/

#ifndef _SURE_RESPONSES_H
#define _SURE_RESPONSES_H

// +--------------------------------------------------------------+
// |              Public Structure/Type Definitions               |
// +--------------------------------------------------------------+
typedef void ModuleResetCallback_f();
typedef void ReceivedPacketCallback_f(u8 packetLength, const u8* packetPntr, const ReceiveInfo_t* rxInfo);
typedef void ButtonChangedCallback_f(bool buttonDown);

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
extern bool PrintSureResponses;
extern bool PrintSureStatusUpdates;
extern bool PrintSureSuccesses;
extern bool PrintSureFailures;

extern u8 SureSuccessCmd;                       extern bool SureGotSuccess;
extern u8 SureFailureCmd;                       extern bool SureGotFailure;
extern u8 SureFailureError;

extern bool SureGotTransmitFinished;

extern ModuleStatus_t SureModuleStatus;         extern bool SureGotModuleStatus;
extern ModuleStatus_t SureIntEnableBits;        extern bool SureGotIntEnableBits;
extern ModuleVersion_t SureModuleVersion;       extern bool SureGotModuleVersion;
extern u16 SurePacketTimeOnAir;                 extern bool SureGotPacketTimeOnAir;
extern u32 SureRandomNumber;                    extern bool SureGotRandomNumber;
extern u8  SureRxPacketLength;
extern u8  SureRxPacket[MAX_RX_PACKET_LENGTH];  extern bool SureGotRxPacket;
extern u8  SureAckPacketLength;
extern u8  SureAckPacket[MAX_RX_PACKET_LENGTH]; extern bool SureGotAckPacket;
extern ReceiveInfo_t SureRxInfo;                extern bool SureGotRxInfo;
extern TransmitInfo_t SureTxInfo;               extern bool SureGotTxInfo;
extern char SureSerial[MAX_SERIAL_STR_LENGTH+1];extern bool SureGotSerial;

extern ModuleSettings_t SureAllSettings;        extern bool SureGotAllSettings;
extern u8 SureRadioMode;                        extern bool SureGotRadioMode;
extern u8 SureSpreadingFactor;
extern u8 SureBandwidth;
extern u8 SureFhssTable;                        extern bool SureGotFhssTable;
extern u8 SureReceiveUidLength;
extern u8 SureReceiveUid[MAX_UID_LENGTH];       extern bool SureGotReceiveUid;
extern u8 SureTransmitUidLength;
extern u8 SureTransmitUid[MAX_UID_LENGTH];      extern bool SureGotTransmitUid;
extern u8 SureReceivePacketSize;                extern bool SureGotReceivePacketSize;
extern u8 SureRadioPolarity;                    extern bool SureGotRadioPolarity;
extern u8 SureTransmitPower;                    extern bool SureGotTransmitPower;
extern u8 SureAckDataLength;
extern u8 SureAckData[MAX_RX_PACKET_LENGTH];    extern bool SureGotAckData;

extern u8   SureQosConfig;                      extern bool SureGotQosConfig;
extern u8   SureIndications[6];                 extern bool SureGotIndications;
extern bool SureQuietMode;                      extern bool SureGotQuietMode;
extern u8   SureButtonHoldTime;
extern u8   SureButtonConfig;                   extern bool SureGotButtonConfig;
extern bool SureAcksEnabled;                    extern bool SureGotAcksEnabled;
extern u8   SureNumRetries;                     extern bool SureGotNumRetries;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitRadioResponses();
void SetRadioResponseCallbacks(
	ModuleResetCallback_f* moduleResetCallback,
	ReceivedPacketCallback_f* receivedPacketCallback,
	ButtonChangedCallback_f* buttonChangedCallback);
void PrintRadioInfo();
void HandleRadioResponse(const SureCommand_t* rsp);

#endif //  _SURE_RESPONSES_H
