/*
File:   surefiModule.h
Author: Taylor Robbins
Date:   11\29\2017
*/

#ifndef _SUREFI_MODULE_H
#define _SUREFI_MODULE_H

// +--------------------------------------------------------------+
// |                         Definitions                          |
// +--------------------------------------------------------------+
#define MAX_UID_LENGTH            8
#define MAX_NUM_RETRIES           16
#define NUM_HOPPING_TABLE_OPTIONS (72*3)
#define ATTN_CHAR                 0x7E
#define MAX_RX_PACKET_LENGTH      64

// +--------------------------------------------------------------+
// |                         Enumerations                         |
// +--------------------------------------------------------------+
// +==============================+
// |         RadioState_          |
// +==============================+
enum
{
	RadioState_Initializing,  //0b0000
	RadioState_Receiving,     //0b0001
	RadioState_Transmitting,  //0b0010
	RadioState_WaitingForAck, //0b0011
	RadioState_Acknowledging, //0b0100
	RadioState_Sleeping,      //0b0101
};

// +==============================+
// |          QosConfig_          |
// +==============================+
enum
{
	QosConfig_Manual = 0x01,
	QosConfig_OnReceive,
	QosConfig_OnTransmit,
	QosConfig_OnReceiveAndTransmit,
};

// +==============================+
// |        ButtonConfig_         |
// +==============================+
enum
{
	ButtonConfig_NoAction     = 0x1,
	ButtonConfig_SendZeros,   //0x2
	ButtonConfig_SendAckData, //0x3
	
	ButtonConfig_HoldLengthMask = 0xF0,
};

// +==============================+
// |         Indication_          |
// +==============================+
enum
{
	Indication_Off        = 0x0,
	Indication_On,       // 0x1
	Indication_Blink1Hz, // 0x2
	Indication_Blink2Hz, // 0x3
	Indication_Pattern1, // 0x4
	Indication_Pattern2, // 0x5
	Indication_Pattern3, // 0x6
	Indication_Pattern4, // 0x7
};

// +==============================+
// |          RadioMode_          |
// +==============================+
enum
{
	RadioMode_1       = 0x01,//(SF12-SF10 250kHz-62.5kHz)
	RadioMode_2,      //0x02 //(SF11-SF9  250kHz-62.5kHz)
	RadioMode_3,      //0x03 //(SF10-SF8  250kHz-62.5kHz)
	RadioMode_4,      //0x04 //(SF9-SF7   250kHz-62.5kHz)
	RadioMode_5,      //0x05 //(SF8       250kHz)
	RadioMode_6,      //0x06 //(SF7       250kHz)
	RadioMode_Custom, //0x07
};

// +==============================+
// |        TransmitPower_        |
// +==============================+
enum
{
	TransmitPower_0dBm   = 0x01, //(1 mWatt)
	TransmitPower_1dBm,  //0x02
	TransmitPower_2dBm,  //0x03
	TransmitPower_3dBm,  //0x04
	TransmitPower_4dBm,  //0x05
	TransmitPower_5dBm,  //0x06
	TransmitPower_6dBm,  //0x07
	TransmitPower_7dBm,  //0x08
	TransmitPower_8dBm,  //0x09
	TransmitPower_9dBm,  //0x0A
	TransmitPower_10dBm, //0x0B (10 mWatt)
	TransmitPower_11dBm, //0x0C
	TransmitPower_12dBm, //0x0D
	TransmitPower_13dBm, //0x0E
	TransmitPower_14dBm, //0x0F
	TransmitPower_15dBm, //0x10
	TransmitPower_16dBm, //0x11
	TransmitPower_17dBm, //0x12
	TransmitPower_18dBm, //0x13
	TransmitPower_19dBm, //0x14
	TransmitPower_20dBm, //0x15 (20 mWatt)
	TransmitPower_21dBm, //0x16 (1/8 Watt)
	TransmitPower_22dBm, //0x17
	TransmitPower_23dBm, //0x18
	TransmitPower_24dBm, //0x19 (1/4 Watt)
	TransmitPower_25dBm, //0x1A
	TransmitPower_26dBm, //0x1B
	TransmitPower_27dBm, //0x1C (1/2 Watt)
	TransmitPower_28dBm, //0x1D
	TransmitPower_29dBm, //0x1E
	TransmitPower_30dBm, //0x1F (1 Watt)
	
	TransmitPower_1_mWatt  = TransmitPower_0dBm,
	TransmitPower_10_mWatt = TransmitPower_10dBm,
	TransmitPower_20_mWatt = TransmitPower_20dBm,
	TransmitPower_1_8_Watt = TransmitPower_21dBm,
	TransmitPower_1_4_Watt = TransmitPower_24dBm,
	TransmitPower_1_2_Watt = TransmitPower_27dBm,
	TransmitPower_1_Watt   = TransmitPower_30dBm,
};

// +==============================+
// |    SpreadingFactorOption_    |
// +==============================+
enum
{
	SpreadingFactorOption_7   = 0x01,
	SpreadingFactorOption_8,  //0x02
	SpreadingFactorOption_9,  //0x03
	SpreadingFactorOption_10, //0x04
	SpreadingFactorOption_11, //0x05
	SpreadingFactorOption_12, //0x06
};

// +==============================+
// |       BandwidthOption_       |
// +==============================+
enum
{
	BandwidthOption_31_25  = 0x01,
	BandwidthOption_62_50, //0x02
	BandwidthOption_125,   //0x03
	BandwidthOption_250,   //0x04
	BandwidthOption_500,   //0x05
};

// +================================+
// | Module Status Bit Enumerations |
// +================================+
enum //stateFlags
{
	StateFlags_RadioStateBits      = 0x0F,
	StateFlags_BusyBit             = 0x10,
	StateFlags_EncryptionActiveBit = 0x20,
	StateFlags_RxInProgressBit     = 0x40,
	StateFlags_SettingsPendingBit  = 0x80,
};

enum //otherFlags
{	
	OtherFlags_DoingLightshowBit   = 0x01,
	OtherFlags_ShowingQosBit       = 0x02,
	OtherFlags_ButtonDownBit       = 0x04,
};

enum //clearableFlags
{	
	ClearableFlags_WasResetBit         = 0x01,
	ClearableFlags_TransmitFinishedBit = 0x02,
	ClearableFlags_RxPacketReadyBit    = 0x04,
	ClearableFlags_AckPacketReadyBit   = 0x08,
	ClearableFlags_ChecksumErrorBit    = 0x10,
	ClearableFlags_EncryptionRekeyBit  = 0x20,
	ClearableFlags_ButtonPressedBit    = 0x40,
	ClearableFlags_ButtonHeldBit       = 0x80,
};

enum //configFlags
{
	ConfigFlags_InterruptDrivenBit  = 0x01,
	ConfigFlags_AutoClearFlagsBit   = 0x02,
	ConfigFlags_RxLedModeBit        = 0x04,
	ConfigFlags_TxLedModeBit        = 0x08,
	ConfigFlags_AutoRekeyBit        = 0x10,
};

// +--------------------------------------------------------------+
// |                          Structures                          |
// +--------------------------------------------------------------+
typedef struct __attribute__((packed))
{
	uint8_t  success;
	int16_t rssi;
	int8_t  snr;
	uint8_t  numRetries;
	uint8_t  ackDataLength;
} TransmitInfo_t;

typedef struct __attribute__((packed))
{
	uint8_t  success;
	int16_t rssi;
	int8_t  snr;
} ReceiveInfo_t;

typedef struct __attribute__((packed))
{
	uint32_t id;
	uint8_t revision;
} McuVersion_t;

typedef struct __attribute__((packed))
{
	uint8_t major;
	uint8_t minor;
} HardwareVersion_t;

typedef struct __attribute__((packed))
{
	uint8_t major;
	uint8_t minor;
} FirmwareVersion_t;

typedef struct __attribute__((packed))
{
	uint8_t  major;
	uint8_t  minor;
	uint16_t build;
} FullVersion_t;

typedef struct __attribute__((packed))
{
	FullVersion_t firmware;
	HardwareVersion_t hardware;
	McuVersion_t mcu;
} ModuleVersion_t;

typedef struct __attribute__((packed))
{
	uint8_t radioMode;
	uint8_t fhssTable;
	uint8_t receivePacketSize;
	uint8_t radioPolarity;
	uint8_t transmitPower;
	uint8_t qosConfig;
	uint8_t indications[3];
	uint8_t quietMode;
	uint8_t buttonConfig;
	uint8_t acksEnabled;
	uint8_t numRetries;
} ModuleSettings_t;

typedef union __attribute__((packed))
{
	uint32_t fullValue;
	
	uint8_t bytes[4];
	
	struct __attribute__((packed))
	{
		uint8_t stateFlags;
		uint8_t otherFlags;
		uint8_t clearableFlags;
		uint8_t configFlags;
	};
	
	struct __attribute__((packed))
	{
		//Read-only Flags
		unsigned radioState:4;
		unsigned busy:1;
		unsigned encryptionActive:1;
		unsigned rxInProgress:1;
		unsigned settingsPending:1;
		
		unsigned doingLightshow:1;
		unsigned showingQos:1;
		unsigned buttonDown:1;
		unsigned :5;
		
		//Clearable Flags
		unsigned wasReset:1;
		unsigned transmitFinished:1;
		unsigned rxPacketReady:1;
		unsigned ackPacketReady:1;
		unsigned checksumError:1;
		unsigned encryptionRekey:1;
		unsigned buttonPressed:1;
		unsigned buttonHeld:1;
		
		//Configuration Flags
		unsigned interruptDriven:1;
		unsigned autoClearFlags:1;
		unsigned rxLedMode:1;
		unsigned txLedMode:1;
		unsigned autoRekey:1;
		unsigned :3;
	};
} ModuleStatus_t;

// +--------------------------------------------------------------+
// |                      Command Structure                       |
// +--------------------------------------------------------------+
#define SURE_COMMAND_HEADER_SIZE      (3)
#define SURE_COMMAND_PAYLOAD_MAX_SIZE (MAX_RX_PACKET_LENGTH)
typedef struct __attribute__((packed))
{
	uint8_t attn;
	uint8_t cmd;
	uint8_t length;
	union __attribute__((packed))
	{
		uint8_t bytes[SURE_COMMAND_PAYLOAD_MAX_SIZE];
		
		ModuleStatus_t status;
		ModuleVersion_t moduleVersion;
		TransmitInfo_t txInfo;
		ReceiveInfo_t rxInfo;
		uint16_t timeOnAir;
		uint32_t randomNumber;
		uint32_t intEnableBits;
		
		ModuleSettings_t allSettings;
		uint8_t radioMode;
		uint8_t fhssTable;
		uint8_t receivePacketSize;
		uint8_t radioPolarity;
		uint8_t transmitPower;
		uint8_t qosConfig;
		uint8_t indications[3];
		uint8_t quietMode;
		uint8_t buttonConfig;
		uint8_t acksEnabled;
		uint8_t numRetries;
		
		struct __attribute__((packed))
		{
			uint16_t address;
			uint32_t words[2];
		} programInfo;
		
		struct __attribute__((packed))
		{
			uint8_t mode;
			uint8_t spreadingFactor;
			uint8_t bandwidth;
		} customMode;
	} payload;
} SureCommand_t;

#define Alloc_SureCommand(BufferName, PointerName, PayloadSize) \
	uint8_t BufferName[SURE_COMMAND_HEADER_SIZE + (PayloadSize)];    \
	SureCommand_t* PointerName = (SureCommand_t*)&BufferName[0]

// +--------------------------------------------------------------+
// |                     Command Enumeration                      |
// +--------------------------------------------------------------+
enum //SureCmd_
{
	// SureCmd_SetDebugMode        = 0x29, // 1 byte
	// +==============================+
	// |      Run Time Commands       |
	// +==============================+
	SureCmd_DefaultSettings = 0x30, // 0 bytes
	SureCmd_ClearStatusFlags,       // 1 byte
	SureCmd_WriteConfig,            // 1 byte
	SureCmd_SetIntEnableBits,       // 4 bytes
	SureCmd_Reset,                  // 0 bytes
	SureCmd_Sleep,                  // 0 bytes
	SureCmd_QosLightshow,           // 0 bytes
	SureCmd_TransmitData,           // Variable length
	SureCmd_StartEncryption,        // 0 bytes
	SureCmd_StopEncryption,         // 0 bytes
	SureCmd_ShowQualityOfService,   // 0 bytes
	
	// +==============================+
	// |   Get Information Commands   |
	// +==============================+
	SureCmd_GetStatus = 0x40,   // 0 bytes
	SureCmd_GetIntEnableBits,   // 0 bytes
	SureCmd_GetModuleVersion,   // 0 bytes
	SureCmd_GetPacketTimeOnAir, // 0 bytes
	SureCmd_GetRandomNumber,    // 0 bytes
	SureCmd_GetPacket,          // 0 bytes
	SureCmd_GetAckPacket,       // 0 bytes
	SureCmd_GetReceiveInfo,     // 0 bytes
	SureCmd_GetTransmitInfo,    // 0 bytes
	
	// +==============================+
	// |     Set Setting Commands     |
	// +==============================+
	SureCmd_SetAllSettings = 0x50, // sizeof(ModuleSettings_t)
	SureCmd_SetRadioMode,          // 1 or 3 bytes
	SureCmd_SetFhssTable,          // 1 byte
	SureCmd_SetReceiveUID,         // Variable length
	SureCmd_SetTransmitUID,        // Variable length
	SureCmd_SetReceivePacketSize,  // 1 byte
	SureCmd_SetRadioPolarity,      // 1 byte
	SureCmd_SetTransmitPower,      // 1 byte
	SureCmd_SetAckData,            // Variable length
	
	SureCmd_SetQosConfig = 0x60,   // 1 byte
	SureCmd_SetIndications,        // 3 bytes (4 bits per LED)
	SureCmd_SetQuietMode,          // 1 byte
	SureCmd_SetButtonConfig,       // 1 byte
	SureCmd_SetAcksEnabled,        // 1 byte
	SureCmd_SetNumRetries,         // 1 byte
	
	// +==============================+
	// |     Get Setting Commands     |
	// +==============================+
	SureCmd_GetAllSettings = 0x70, // 0 bytes
	SureCmd_GetRadioMode,          // 0 bytes
	SureCmd_GetFhssTable,          // 0 bytes
	SureCmd_GetReceiveUID,         // 0 bytes
	SureCmd_GetTransmitUID,        // 0 bytes
	SureCmd_GetReceivePacketSize,  // 0 bytes
	SureCmd_GetRadioPolarity,      // 0 bytes
	SureCmd_GetTransmitPower,      // 0 bytes
	SureCmd_GetAckData,            // 0 bytes
	
	SureCmd_GetQosConfig = 0x80,   // 0 bytes
	SureCmd_GetIndications,        // 0 bytes
	SureCmd_GetQuietMode,          // 0 bytes
	SureCmd_GetButtonConfig,       // 0 bytes
	SureCmd_GetAcksEnabled,        // 0 bytes
	SureCmd_GetNumRetries,         // 0 bytes
};

// +--------------------------------------------------------------+
// |                     Response Enumaration                     |
// +--------------------------------------------------------------+
enum //SureRsp_
{
	// +==============================+
	// |        Info Responses        |
	// +==============================+
	SureRsp_Status = 0x40,   // 4 bytes
	SureRsp_IntEnableBits,   // 4 bytes
	SureRsp_ModuleVersion,   // sizeof(ModuleVersion_t)
	SureRsp_PacketTimeOnAir, // 2 bytes
	SureRsp_RandomNumber,    // 4 bytes
	SureRsp_Packet,          // Variable length
	SureRsp_AckPacket,       // Variable length
	SureRsp_ReceiveInfo,     // sizeof(ReceiveInfo_t)
	SureRsp_TransmitInfo,    // sizeof(TransmitInfo_t)
	
	// +==============================+
	// |  Success/Failure Responses   |
	// +==============================+
	SureRsp_Success = 0x50, // 1 byte
	SureRsp_Failure,        // 2 bytes
	SureRsp_Unsupported,    // 1 byte
	SureRsp_UartTimeout,    // 3 bytes
	
	// +==============================+
	// |    Get Settings Responses    |
	// +==============================+
	SureRsp_AllSettings = 0x70, // sizeof(ModuleSettings_t)
	SureRsp_RadioMode,          // 1 or 3 bytes
	SureRsp_FhssTable,          // 1 byte
	SureRsp_ReceiveUID,         // Variable length
	SureRsp_TransmitUID,        // Variable length
	SureRsp_ReceivePacketSize,  // 1 byte
	SureRsp_RadioPolarity,      // 1 byte
	SureRsp_TransmitPower,      // 1 byte
	SureRsp_AckData,            // Variable length
	
	SureRsp_QosConfig = 0x80,   // 1 byte
	SureRsp_Indications,        // 3 bytes
	SureRsp_QuietMode,          // 1 byte
	SureRsp_ButtonConfig,       // 1 byte
	SureRsp_AcksEnabled,        // 1 byte
	SureRsp_NumRetries,         // 1 byte
};

// +--------------------------------------------------------------+
// |                 Failure Response Error Codes                 |
// +--------------------------------------------------------------+
enum //SureError_
{
	SureError_ValueTooLow      = 0x01,
	SureError_ValueTooHigh,    //0x02
	SureError_InvalidValue,    //0x03
	SureError_PayloadTooLarge, //0x04
	SureError_PayloadTooSmall, //0x05
	SureError_Busy,            //0x06
	SureError_InvalidSettings, //0x07
	SureError_NotFccApproved,  //0x08
	SureError_AlreadyStarted,  //0x09
};

#endif //  _SUREFI_MODULE_H
