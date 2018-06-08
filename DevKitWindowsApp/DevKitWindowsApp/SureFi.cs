using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevKitWindowsApp
{
	public enum SureCmd : byte
	{
		DefaultSettings = 0x30,
		ClearFlags,
		WriteConfig,
		SetIntEnableBits,
		Reset,
		Sleep,
		QosLightshow,
		TransmitData,
		StartEncryption,
		StopEncryption,
		ShowQualityOfService,
		SetRxLED,
		SetTxLED,
		
		GetStatus = 0x40,
		GetIntEnableBits,
		GetModuleVersion,
		GetPacketTimeOnAir,
		GetRandomNumber,
		GetPacket,
		GetAckPacket,
		GetReceiveInfo,
		GetTransmitInfo,
		GetRegisteredSerial,
		
		SetAllSettings = 0x50,
		SetRadioMode,
		SetFhssTable,
		SetReceiveUID,
		SetTransmitUID,
		SetReceivePacketSize,
		SetRadioPolarity,
		SetTransmitPower,
		SetAckData,
		SetTableHoppingEnabled,
		
		SetQosConfig = 0x60,
		SetIndications,
		SetQuietMode,
		SetButtonConfig,
		SetAcksEnabled,
		SetNumRetries,
		
		GetAllSettings = 0x70,
		GetRadioMode,
		GetFhssTable,
		GetReceiveUID,
		GetTransmitUID,
		GetReceivePacketSize,
		GetRadioPolarity,
		GetTransmitPower,
		GetAckData,
		GetTableHoppingEnabled,
		
		GetQosConfig = 0x80,
		GetIndications,
		GetQuietMode,
		GetButtonConfig,
		GetAcksEnabled,
		GetNumRetries,
	};
	
	public enum SureRsp : byte
	{
		Status = 0x40,
		IntEnableBits,
		ModuleVersion,
		PacketTimeOnAir,
		RandomNumber,
		Packet,
		AckPacket,
		ReceiveInfo,
		TransmitInfo,
		RegisteredSerial,
		
		Success = 0x50,
		Failure,
		UartTimeout,
		
		AllSettings = 0x70,
		RadioMode,
		FhssTable,
		ReceiveUID,
		TransmitUID,
		ReceivePacketSize,
		RadioPolarity,
		TransmitPower,
		AckData,
		TableHoppingEnabled,
		
		QosConfig = 0x80,
		Indications,
		QuietMode,
		ButtonConfig,
		AcksEnabled,
		NumRetries,
	};
	
	public enum SureError : byte
	{
		ValueTooLow = 0x01,
		ValueTooHigh,
		InvalidValue,
		PayloadTooLarge,
		PayloadTooSmall,
		Busy,
		InvalidSettings,
		NotFccApproved,
		AlreadyStarted,
		Unsupported,
	};
	
	public enum RadioState : byte
	{
		Initializing = 0x00,
		Receiving,
		Transmitting,
		WaitingForAck,
		Acknowledging,
		Sleeping,
	};
	
	public enum QosConfig : byte
	{
		Manual = 0x01,
		OnReceive,
		OnTransmit,
		OnReceiveAndTransmit,
		OnAckData,
		OnReceiveAndAckData,
	};
	
	public enum ButtonConfig : byte
	{
		NoAction = 0x01,
		SendZeroes,
		SendAckData,
	};
	
	public enum Indication : byte
	{
		Off = 0x0,
		On,
		Blink1Hz,
		Blink2Hz,
		Pattern1,
		Pattern2,
		Pattern3,
		Pattern4,
	};
	
	public enum BleCmd : byte
	{
		StartAdvertising = 0x30,
		StopAdvertising,
		CloseConnection,
		StartDfuMode,
		ReadExmem,
		WriteExmem,
		ClearExmem,
		ClearResetFlag,
		ClearConnAttemptFlag,
		
		GetFirmwareVersion = 0x40,
		GetStatus,
		GetMacAddress,
		
		SetStatusUpdateBits = 0x50,
		SetAdvertisingData,
		SetAdvertisingName,
		SetTemporaryData,
		SetGpioConfiguration,
		SetGpioValue,
		SetGpioUpdateEnabled,
		SetRejectConnections,
		
		GetStatusUpdateBits = 0x70,
		GetAdvertisingData,
		GetAdvertisingName,
		GetTemporaryData,
		GetGpioConfiguration,
		GetGpioValue,
		GetGpioUpdateEnabled,
		GetRejectConnections,
	};
	
	public enum BleRsp : byte
	{
		DfuNeedAdvData = 0x30,
		ExmemData,
		
		FirmwareVersion = 0x40,
		Status,
		MacAddress,
		
		Success = 0x50,
		Failure,
		UartTimeout,
		BleWriteTimeout,
		
		StatusUpdateBits = 0x70,
		AdvertisingData,
		AdvertisingName,
		TemporaryData,
		GpioConfiguration,
		GpioValue,
		GpioUpdateEnabled,
		RejectConnections,
	};
	
	public enum BleError : byte
	{
		ValueTooLow = 0x01,
		ValueTooHigh,
		InvalidValue,
		PayloadTooLarge,
		PayloadTooSmall,
		Busy,
		InvalidSettings,
		NotFccApproved,
		AlreadyStarted,
		Unsupported,
		NotStarted,
	};
	
	class SureFi
	{
		public const byte StateFlags_RadioStateBits    = 0x0F;
		public const byte StateFlags_BusyBit           = 0x10;
		public const byte StateFlags_ChangingTablesBit = 0x20;
		public const byte StateFlags_RxInProgressBit   = 0x40;
		public const byte StateFlags_OnBaseTableBit    = 0x80;
		
		public const byte OtherFlags_DoingLightshowBit   = 0x01;
		public const byte OtherFlags_ShowingQosBit       = 0x02;
		public const byte OtherFlags_ButtonDownBit       = 0x04;
		public const byte OtherFlags_EncryptionActiveBit = 0x08;
		public const byte OtherFlags_SettingsPendingBit  = 0x10;
		public const byte OtherFlags_RxLedOnBit          = 0x20;
		public const byte OtherFlags_TxLedOnBit          = 0x40;
		
		public const byte ClearableFlags_WasResetBit         = 0x01;
		public const byte ClearableFlags_TransmitFinishedBit = 0x02;
		public const byte ClearableFlags_RxPacketReadyBit    = 0x04;
		public const byte ClearableFlags_AckPacketReadyBit   = 0x08;
		public const byte ClearableFlags_ChecksumErrorBit    = 0x10;
		public const byte ClearableFlags_EncryptionRekeyBit  = 0x20;
		public const byte ClearableFlags_ButtonPressedBit    = 0x40;
		public const byte ClearableFlags_ButtonHeldBit       = 0x80;
		
		public const byte ConfigFlags_InterruptDrivenBit = 0x01;
		public const byte ConfigFlags_AutoClearFlagsBit  = 0x02;
		public const byte ConfigFlags_RxLedModeBit       = 0x04;
		public const byte ConfigFlags_TxLedModeBit       = 0x08;
		public const byte ConfigFlags_AutoRekeyBit       = 0x10;
		public const byte ConfigFlags_RxTxLedsManualBit  = 0x20;
		
		public const byte BleFlags_WasResetBit            = 0x01;
		public const byte BleFlags_ConnectedBit           = 0x02;
		public const byte BleFlags_AdvertisingBit         = 0x04;
		public const byte BleFlags_InDfuModeBit           = 0x08;
		public const byte BleFlags_SureFiTxInProgressBit  = 0x10;
		public const byte BleFlags_ConnectionAttemptedBit = 0x10;
		
		public static bool gotModuleStatus        = false;
		public static bool gotIntEnableBits       = false;
		public static bool gotModuleVersion       = false;
		public static bool gotPacketTimeOnAir     = false;
		public static bool gotRandomNumber        = false;
		public static bool gotRxPacket            = false;
		public static bool gotAckPacket           = false;
		public static bool gotRxInfo              = false;
		public static bool gotTxInfo              = false;
		public static bool gotRegisteredSerial    = false;
		public static bool gotAllSettings         = false;
		public static bool gotRadioMode           = false;
		public static bool gotFhssTable           = false;
		public static bool gotReceiveUid          = false;
		public static bool gotTransmitUid         = false;
		public static bool gotReceivePacketSize   = false;
		public static bool gotRadioPolarity       = false;
		public static bool gotTransmitPower       = false;
		public static bool gotAckData             = false;
		public static bool gotTableHoppingEnabled = false;
		public static bool gotQosConfig           = false;
		public static bool gotIndications         = false;
		public static bool gotQuietMode           = false;
		public static bool gotButtonConfig        = false;
		public static bool gotAcksEnabled         = false;
		public static bool gotNumRetries          = false;
		
		public static bool gotBleExmemData         = false;
		public static bool gotBleFirmwareVersion   = false;
		public static bool gotBleStatus            = false;
		public static bool gotBleMacAddress        = false;
		public static bool gotBleStatusUpdateBits  = false;
		public static bool gotBleAdvertisingData   = false;
		public static bool gotBleAdvertisingName   = false;
		public static bool gotBleTemporaryData     = false;
		public static bool gotBleGpioConfiguration = false;
		public static bool gotBleGpioValue         = false;
		public static bool gotBleGpioUpdateEnabled = false;
		public static bool gotBleRejectConnections = false;
		
		public static void ClearGotFlags()
		{
			gotModuleStatus        = false;
			gotIntEnableBits       = false;
			gotModuleVersion       = false;
			gotPacketTimeOnAir     = false;
			gotRandomNumber        = false;
			gotRxPacket            = false;
			gotAckPacket           = false;
			gotRxInfo              = false;
			gotTxInfo              = false;
			gotAllSettings         = false;
			gotRadioMode           = false;
			gotFhssTable           = false;
			gotReceiveUid          = false;
			gotTransmitUid         = false;
			gotReceivePacketSize   = false;
			gotRadioPolarity       = false;
			gotTransmitPower       = false;
			gotAckData             = false;
			gotTableHoppingEnabled = false;
			gotQosConfig           = false;
			gotIndications         = false;
			gotQuietMode           = false;
			gotButtonConfig        = false;
			gotAcksEnabled         = false;
			gotNumRetries          = false;
		}
		
		public static void ClearBleGotFlags()
		{
			gotBleExmemData         = false;
			gotBleFirmwareVersion   = false;
			gotBleStatus            = false;
			gotBleMacAddress        = false;
			gotBleStatusUpdateBits  = false;
			gotBleAdvertisingData   = false;
			gotBleAdvertisingName   = false;
			gotBleTemporaryData     = false;
			gotBleGpioConfiguration = false;
			gotBleGpioValue         = false;
			gotBleGpioUpdateEnabled = false;
			gotBleRejectConnections = false;
		}
		
		static byte TruncateInt(int intValue)
		{
			if (intValue < 0) { return 0; }
			return (byte)(intValue % 256);
		}
		
		static bool AreBytesAscii(byte[] byteArray)
		{
			bool foundNullTerm = false;
			bool foundNotNullTerm = false;
			for (int bIndex = 0; bIndex < byteArray.Length; bIndex++)
			{
				byte newByte = byteArray[bIndex];
				if (newByte == 0x00)
				{
					foundNullTerm = true;
				}
				else if ((newByte >= 0x20 && newByte <= 0x7E) || newByte == 0x09)//tab
				{
					if (foundNullTerm)
					{
						//Found ascii characters after the first null-terminator
						return false;
					}
					foundNotNullTerm = true;
				}
				else
				{
					//Found non-ascii character
					return false;
				}
			}
			
			return foundNotNullTerm;
		}
		
		public static string GetCommandStr(byte[] commandBytes)
		{
			byte[] cmdPayload = new byte[commandBytes.Length-3];
			Array.Copy(commandBytes, 3, cmdPayload, 0, commandBytes.Length-3);
			
			string result = commandBytes[0].ToString("X2") +
				" {" + commandBytes[1].ToString("X2") + "}" +
				"[" + commandBytes[2].ToString() + "]";
			
			// result += "{";
			foreach (byte b in cmdPayload)
			{
				result += " " + b.ToString("X2");
			}
			// result += " }";
			
			return result;
		}
		
		public static string GetHumanReadableCommandStr(byte[] commandBytes)
		{
			SureCmd cmd = (SureCmd)commandBytes[1];
			byte cmdLength = commandBytes[2];
			byte[] cmdPayload = new byte[cmdLength];
			Array.Copy(commandBytes, 3, cmdPayload, 0, cmdLength);
			
			string result = cmd.ToString() + "[" + cmdLength.ToString() + "]";
			
			switch (cmd)
			{
				default:
				{
					// result += "{";
					foreach (byte b in cmdPayload)
					{
						result += " " + b.ToString("X2");
					}
					// result += " }";
				} break;
			};
			
			return result;
		}
		
		public static string GetResponseStr(byte[] responseBytes)
		{
			byte[] rspPayload = new byte[responseBytes.Length-3];
			Array.Copy(responseBytes, 3, rspPayload, 0, responseBytes.Length-3);
			
			string result = responseBytes[0].ToString("X2") +
				" {" + responseBytes[1].ToString("X2") + "}" +
				"[" + responseBytes[2].ToString() + "]";
			
			// result += "{";
			foreach (byte b in rspPayload)
			{
				result += " " + b.ToString("X2");
			}
			// result += " }";
			
			return result;
		}
		
		public static string GetHumanReadableResponseStr(byte[] responseBytes)
		{
			SureRsp rspCmd = (SureRsp)responseBytes[1];
			byte rspLength = responseBytes[2];
			byte[] rspPayload = new byte[rspLength];
			Array.Copy(responseBytes, 3, rspPayload, 0, rspLength);
			
			string result = rspCmd.ToString() + "[" + rspLength.ToString() + "]";
			
			switch (rspCmd)
			{
				case SureRsp.Success:
				{
					SureCmd sureCmd = (SureCmd)rspPayload[0];
					result += ":" + sureCmd.ToString();
				} break;
				
				case SureRsp.Failure:
				{
					SureCmd sureCmd = (SureCmd)rspPayload[0];
					SureError sureError = (SureError)rspPayload[1];
					result += ":" + sureCmd.ToString();
					result += ":" + sureError.ToString();
				} break;
				
				default:
				{
					// result += "{";
					foreach (byte b in rspPayload)
					{
						result += " " + b.ToString("X2");
					}
					// result += " }";
				} break;
			};
			
			return result;
		}
		
		public static void ProcessResponse(MainForm mainForm, byte[] responseBytes)
		{
			SureRsp rspCmd = (SureRsp)responseBytes[1];
			byte rspLength = responseBytes[2];
			byte[] rspPayload = new byte[rspLength];
			Array.Copy(responseBytes, 3, rspPayload, 0, rspLength);
			string rspString = GetHumanReadableResponseStr(responseBytes);
			Console.WriteLine("Got " + rspString);
			
			switch (rspCmd)
			{
				// +==============================+
				// |        SureRsp.Status        |
				// +==============================+
				case SureRsp.Status:
				{
					if (rspPayload.Length == 4)
					{
						// Console.WriteLine("Got status!");
						for (int bIndex = 0; bIndex < 4; bIndex++)
						{
							if (bIndex == 0) { mainForm.StatusStateLabel.Text     = "State: 0x"     + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 1) { mainForm.StatusOtherLabel.Text     = "Other: 0x"     + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 2) { mainForm.StatusClearableLabel.Text = "Clearable: 0x" + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 3) { mainForm.StatusConfigLabel.Text    = "Config: 0x"    + rspPayload[bIndex].ToString("X2"); }
							for (int bitIndex = 0; bitIndex < 8; bitIndex++)
							{
								byte bit = (byte)(0x01 << bitIndex);
								bool isBitSet = (rspPayload[bIndex] & bit) > 0;
								// Console.WriteLine("Setting " + bIndex.ToString() + "." + bit.ToString("X2") + " to " + isBitSet.ToString());
								mainForm.SetStatusBit(bIndex, bit, isBitSet);
							}
						}
						
						byte stateFlags     = rspPayload[0];
						byte otherFlags     = rspPayload[1];
						byte clearableFlags = rspPayload[2];
						byte configFlags    = rspPayload[3];
						
						bool autoClearFlagsEnabled = ((configFlags & ConfigFlags_AutoClearFlagsBit) != 0x00);
						bool rxLedMode             = ((configFlags & ConfigFlags_RxLedModeBit) != 0x00);
						bool txLedMode             = ((configFlags & ConfigFlags_TxLedModeBit) != 0x00);
						bool rxTxLedsManual        = ((configFlags & ConfigFlags_RxTxLedsManualBit) != 0x00);
						
						RadioState radioState = (RadioState)(stateFlags & StateFlags_RadioStateBits);
						
						mainForm.updatingElement = true;
						
						mainForm.AutoClearFlagsCheckbox.Checked = autoClearFlagsEnabled;
						mainForm.ClearFlagsButton.Enabled = !autoClearFlagsEnabled;
						mainForm.RxLedModeCombobox.SelectedIndex = (rxLedMode ? 1 : 0);
						mainForm.TxLedModeCombobox.SelectedIndex = (txLedMode ? 1 : 0);
						if (rxTxLedsManual)
						{
							mainForm.RxLedModeCombobox.Enabled = false;
							mainForm.TxLedModeCombobox.Enabled = false;
							mainForm.RxLedPulseTimeNumeric.Enabled = true;
							mainForm.RxLedPulseButton.Enabled      = true;
							mainForm.RxLedTurnOnButton.Enabled     = true;
							mainForm.TxLedPulseTimeNumeric.Enabled = true;
							mainForm.TxLedPulseButton.Enabled      = true;
							mainForm.TxLedTurnOnButton.Enabled     = true;
						}
						else
						{
							mainForm.RxLedModeCombobox.Enabled = true;
							mainForm.TxLedModeCombobox.Enabled = true;
							mainForm.RxLedPulseTimeNumeric.Enabled = false;
							mainForm.RxLedPulseButton.Enabled      = false;
							mainForm.RxLedTurnOnButton.Enabled     = false;
							mainForm.TxLedPulseTimeNumeric.Enabled = false;
							mainForm.TxLedPulseButton.Enabled      = false;
							mainForm.TxLedTurnOnButton.Enabled     = false;
						}
						mainForm.RxTxLedsManualCheckbox.Checked = rxTxLedsManual;
						
						mainForm.RadioStateStrLabel.Text = radioState.ToString();
						
						mainForm.updatingElement = false;
						
						mainForm.HandleStatusUpdate(stateFlags, otherFlags, clearableFlags, configFlags);
						
						gotModuleStatus = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.IntEnableBits     |
				// +==============================+
				case SureRsp.IntEnableBits:
				{
					if (rspPayload.Length == 4)
					{
						for (int bIndex = 0; bIndex < 4; bIndex++)
						{
							if (bIndex == 0) { mainForm.IntStateLabel.Text     = "State: 0x"     + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 1) { mainForm.IntOtherLabel.Text     = "Other: 0x"     + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 2) { mainForm.IntClearableLabel.Text = "Clearable: 0x" + rspPayload[bIndex].ToString("X2"); }
							if (bIndex == 3) { mainForm.IntConfigLabel.Text    = "Config: 0x"    + rspPayload[bIndex].ToString("X2"); }
							for (int bitIndex = 0; bitIndex < 8; bitIndex++)
							{
								byte bit = (byte)(0x01 << bitIndex);
								bool isBitSet = (rspPayload[bIndex] & bit) > 0;
								mainForm.SetIntEnableBit(bIndex, bit, isBitSet);
							}
						}
						
						mainForm.intEnableBits[0] = rspPayload[0];
						mainForm.intEnableBits[1] = rspPayload[1];
						mainForm.intEnableBits[2] = rspPayload[2];
						mainForm.intEnableBits[3] = rspPayload[3];
						
						gotIntEnableBits = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.ModuleVersion     |
				// +==============================+
				case SureRsp.ModuleVersion:
				{
					if (rspPayload.Length == 11)
					{
						byte firmwareMajor = rspPayload[0];
						byte firmwareMinor = rspPayload[1];
						UInt16 firmwareBuild = (UInt16)(
							(rspPayload[2] << 0) +
							(rspPayload[3] << 8)
						);
						
						byte hardwareMajor = rspPayload[4];
						byte hardwareMinor = rspPayload[5];
						
						UInt32 microId = (UInt32)(
							(rspPayload[6] << 0) +
							(rspPayload[7] << 8) +
							(rspPayload[8] << 16) +
							(rspPayload[9] << 24)
						);
						byte microRevision = rspPayload[10];
						
						mainForm.FirmwareVersionLabel.Text = "Firmware: " + firmwareMajor.ToString() + "." + firmwareMinor.ToString() + " (" + firmwareBuild.ToString() + ")";
						mainForm.HardwareVersionLabel.Text = "Hardware: " + hardwareMajor.ToString() + "." + hardwareMinor.ToString();
						mainForm.MicroVersionLabel.Text = "Micro: 0x" + microId.ToString("X7") + " (0x" + microRevision.ToString("X2") + ")";
						
						gotModuleVersion = true;
					}
				} break;
				
				// +==============================+
				// |   SureRsp.PacketTimeOnAir    |
				// +==============================+
				case SureRsp.PacketTimeOnAir:
				{
					if (rspPayload.Length == 2)
					{
						UInt16 timeOnAir = (UInt16)(
							(rspPayload[0] << 0) +
							(rspPayload[1] << 8)
						);
						
						mainForm.TimeOnAirLabel.Text = timeOnAir.ToString() + " ms";
						
						gotPacketTimeOnAir = true;
					}
				} break;
				
				// +==============================+
				// |     SureRsp.RandomNumber     |
				// +==============================+
				case SureRsp.RandomNumber:
				{
					if (rspPayload.Length == 4)
					{
						UInt32 randomNumber = (UInt32)(
							(rspPayload[0] << 0) +
							(rspPayload[1] << 8) +
							(rspPayload[2] << 16) +
							(rspPayload[3] << 24)
						);
						
						mainForm.RandomNumberLabel.Text = "0x" + randomNumber.ToString("X8");
						
						gotRandomNumber = true;
					}
				} break;
				
				// +==============================+
				// |        SureRsp.Packet        |
				// +==============================+
				case SureRsp.Packet:
				{
					bool isHexStr = (mainForm.RxHexCheckbox.Checked || !AreBytesAscii(rspPayload));
					
					mainForm.updatingElement = true;
					
					int numBytes = 0;
					if (isHexStr)
					{
						//Auto-Check the HEX checkbox
						mainForm.RxHexCheckbox.Checked = true;
						
						mainForm.RxTextbox.Text = "";
						foreach (byte b in rspPayload)
						{
							mainForm.RxTextbox.Text += b.ToString("X2");
							numBytes++;
						}
					}
					else
					{
						mainForm.RxTextbox.Text = "";
						foreach (byte b in rspPayload)
						{
							if (b == 0x00)
							{
								break;
							}
							mainForm.RxTextbox.Text += (char)b;
							numBytes++;
						}
					}
					mainForm.RxLengthLabel.Text = "Length: " + numBytes.ToString();
					mainForm.IncrementCount(mainForm.RxCountLabel);
					
					mainForm.updatingElement = false;
					
					gotRxPacket = true;
				} break;
				
				// +==============================+
				// |      SureRsp.AckPacket       |
				// +==============================+
				case SureRsp.AckPacket:
				{
					bool isHexStr = (mainForm.AckHexCheckbox.Checked || !AreBytesAscii(rspPayload));
					
					mainForm.updatingElement = true;
					
					int numBytes = 0;
					if (isHexStr)
					{
						//Auto-Check the HEX checkbox
						mainForm.AckHexCheckbox.Checked = true;
						
						mainForm.AckTextbox.Text = "";
						foreach (byte b in rspPayload)
						{
							mainForm.AckTextbox.Text += b.ToString("X2");
							numBytes++;
						}
					}
					else
					{
						mainForm.AckTextbox.Text = "";
						foreach (byte b in rspPayload)
						{
							if (b == 0x00)
							{
								break;
							}
							mainForm.AckTextbox.Text += (char)b;
							numBytes++;
						}
					}
					mainForm.AckLengthLabel.Text = "Length: " + numBytes.ToString();
					mainForm.IncrementCount(mainForm.AckCountLabel);
					
					mainForm.updatingElement = false;
					
					gotAckPacket = true;
				} break;
				
				// +==============================+
				// |     SureRsp.ReceiveInfo      |
				// +==============================+
				case SureRsp.ReceiveInfo:
				{
					if (rspPayload.Length == 4)
					{
						byte succcessByte  = rspPayload[0];
						short rssi         = (short)(rspPayload[1] + (rspPayload[2] << 8));
						sbyte snr          = (sbyte)(rspPayload[3]);
						
						mainForm.updatingElement = true;
						
						mainForm.RxRssiLabel.Text = "RSSI: " + rssi.ToString();
						mainForm.RxSnrLabel.Text  = "SNR: " + snr.ToString();
						
						mainForm.updatingElement = false;
						
						gotTxInfo = true;
					}
					
					gotRxInfo = true;
				} break;
				
				// +==============================+
				// |     SureRsp.TransmitInfo     |
				// +==============================+
				case SureRsp.TransmitInfo:
				{
					if (rspPayload.Length == 7)
					{
						byte succcessByte  = rspPayload[0];
						short rssi         = (short)(rspPayload[1] + (rspPayload[2] << 8));
						sbyte snr          = (sbyte)(rspPayload[3]);
						byte numRetries    = rspPayload[4];
						byte maxRetries    = rspPayload[5];
						byte ackDataLength = rspPayload[6];
						
						mainForm.updatingElement = true;
						
						mainForm.TxRssiLabel.Text = "RSSI: " + rssi.ToString();
						mainForm.TxSnrLabel.Text  = "SNR: " + snr.ToString();
						mainForm.TxRetriesLabel.Text = numRetries.ToString() + "/" + maxRetries.ToString() + " retries";
						if (succcessByte != 0x00)
						{
							mainForm.TxSuccessLabel.Text = "Success";
							mainForm.TxSuccessLabel.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
							mainForm.TxRetriesLabel.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
						}
						else
						{
							mainForm.TxSuccessLabel.Text = "Failure";
							mainForm.TxSuccessLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
							mainForm.TxRetriesLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
						}
						mainForm.TransmitButton.Text = "Transmit";
						mainForm.TransmitButton.Enabled = true;
						
						mainForm.updatingElement = false;
						
						gotTxInfo = true;
					}
				} break;
				
				// +==============================+
				// |   SureRsp.RegisteredSerial   |
				// +==============================+
				case SureRsp.RegisteredSerial:
				{
					string registeredSerial = System.Text.Encoding.Default.GetString(rspPayload);
					
					mainForm.updatingElement = true;
					
					mainForm.RegisteredSerialLabel.Text = registeredSerial;
					
					mainForm.updatingElement = false;
					
					gotRegisteredSerial = true;
				} break;
				
				// +==============================+
				// |       SureRsp.Success        |
				// +==============================+
				case SureRsp.Success:
				{
					if (rspPayload.Length == 1)
					{
						byte cmdByte = rspPayload[0];
						SureCmd sureCmd = (SureCmd)cmdByte;
						
						mainForm.HandleSuccessResponse(sureCmd);
					}
				} break;
				
				// +==============================+
				// |       SureRsp.Failure        |
				// +==============================+
				case SureRsp.Failure:
				{
					if (rspPayload.Length == 2)
					{
						byte cmdByte = rspPayload[0];
						byte errorByte = rspPayload[1];
						SureCmd sureCmd = (SureCmd)cmdByte;
						SureError sureError = (SureError)errorByte;
						
						mainForm.HandleFailureResponse(sureCmd, sureError);
					}
				} break;
				
				// +==============================+
				// |     SureRsp.UartTimeout      |
				// +==============================+
				case SureRsp.UartTimeout:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.AllSettings      |
				// +==============================+
				case SureRsp.AllSettings:
				{
					if (rspPayload.Length == 14)
					{
						byte radioMode           = rspPayload[0];
						byte fhssTable           = rspPayload[1];
						byte receivePacketSize   = rspPayload[2];
						byte radioPolarity       = rspPayload[3];
						byte transmitPower       = rspPayload[4];
						bool tableHoppingEnabled = (rspPayload[5] != 0x00);
						byte qosConfig           = rspPayload[6];
						byte indication1         = (byte)((rspPayload[7]>>0) & 0x0F);
						byte indication2         = (byte)((rspPayload[7]>>4) & 0x0F);
						byte indication3         = (byte)((rspPayload[8]>>0) & 0x0F);
						byte indication4         = (byte)((rspPayload[8]>>4) & 0x0F);
						byte indication5         = (byte)((rspPayload[9]>>0) & 0x0F);
						byte indication6         = (byte)((rspPayload[9]>>4) & 0x0F);
						bool quietModeEnabled    = (rspPayload[10] != 0x00);
						byte buttonConfig        = (byte)((rspPayload[11]>>0) & 0x0F);
						byte buttonHoldTime      = (byte)((rspPayload[11]>>4) & 0x0F);
						bool acksEnabled         = (rspPayload[12] != 0x00);
						byte numRetries          = rspPayload[13];
						
						mainForm.updatingElement = true;
						
						mainForm.FhssTableNumeric.Value = (Decimal)fhssTable;
						int payloadSize = receivePacketSize - mainForm.RxUidTextbox.Text.Length/2;
						mainForm.PayloadSizeNumeric.Value = (Decimal)payloadSize;
						mainForm.UpdatePacketSize();
						mainForm.PolarityCombobox.SelectedIndex = radioPolarity;
						mainForm.TransmitPowerCombobox.SelectedIndex = transmitPower - 0x01;
						mainForm.TableHoppingCheckbox.Checked = tableHoppingEnabled;
						
						mainForm.QosConfigCombobox.SelectedIndex = (qosConfig - 0x01);
						
						mainForm.LedCombo1.SelectedIndex = indication1;
						mainForm.LedCombo2.SelectedIndex = indication2;
						mainForm.LedCombo3.SelectedIndex = indication3;
						mainForm.LedCombo4.SelectedIndex = indication4;
						mainForm.LedCombo5.SelectedIndex = indication5;
						mainForm.LedCombo6.SelectedIndex = indication6;
						mainForm.PushIndications(true);
						
						mainForm.QuietModeCheckbox.Checked = quietModeEnabled;
						
						mainForm.ButtonConfigCombobox.SelectedIndex = (buttonConfig - 0x01);
						mainForm.ButtonHoldTimeNumeric.Value = (Decimal)buttonHoldTime;
						
						mainForm.AcksEnabledCheckbox.Checked = acksEnabled;
						mainForm.NumRetriesNumeric.Enabled = mainForm.AcksEnabledCheckbox.Checked;
						mainForm.NumRetriesNumeric.Value = (Decimal)numRetries;
						
						mainForm.UpdateEncryptionReady();
						
						mainForm.updatingElement = false;
						
						gotAllSettings = true;
					}
				} break;
				
				// +==============================+
				// |      SureRsp.RadioMode       |
				// +==============================+
				case SureRsp.RadioMode:
				{
					if (rspPayload.Length == 1 && rspPayload[0] <= 0x04)
					{
						byte radioMode = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.RadioModeCombobox.SelectedIndex = radioMode - 0x01;
						mainForm.SpreadingFactorCombobox.Enabled = false;
						mainForm.BandwidthCombobox.Enabled = false;
						
						mainForm.updatingElement = false;
						
						gotRadioMode = true;
					}
					else if (rspPayload.Length == 3 && rspPayload[0] == 0x07)
					{
						byte radioMode       = rspPayload[0];
						byte spreadingFactor = rspPayload[1];
						byte bandwidth       = rspPayload[2];
						
						mainForm.updatingElement = true;
						
						mainForm.RadioModeCombobox.SelectedIndex = 0x04;
						mainForm.SpreadingFactorCombobox.SelectedIndex = spreadingFactor - 0x01;
						mainForm.BandwidthCombobox.SelectedIndex = bandwidth - 0x01;
						mainForm.SpreadingFactorCombobox.Enabled = true;
						mainForm.BandwidthCombobox.Enabled = true;
						
						mainForm.updatingElement = false;
						
						gotRadioMode = true;
					}
				} break;
				
				// +==============================+
				// |      SureRsp.FhssTable       |
				// +==============================+
				case SureRsp.FhssTable:
				{
					if (rspPayload.Length == 1)
					{
						byte fhssTable = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.FhssTableNumeric.Value = (Decimal)fhssTable;
						
						mainForm.updatingElement = false;
						
						gotFhssTable = true;
					}
				} break;
				
				// +==============================+
				// |      SureRsp.ReceiveUID      |
				// +==============================+
				case SureRsp.ReceiveUID:
				{
					string uidString = "";
					foreach (byte b in rspPayload)
					{
						uidString += b.ToString("X2");
					}
					
					mainForm.updatingElement = true;
					
					mainForm.RxUidTextbox.Text = uidString;
					mainForm.RxUidLengthLabel.Text = rspPayload.Length.ToString() + " bytes";
					mainForm.RxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					mainForm.UpdatePacketSize();
					mainForm.UpdateEncryptionReady();
					
					mainForm.updatingElement = false;
					
					gotReceiveUid = true;
				} break;
				
				// +==============================+
				// |     SureRsp.TransmitUID      |
				// +==============================+
				case SureRsp.TransmitUID:
				{
					string uidString = "";
					foreach (byte b in rspPayload)
					{
						uidString += b.ToString("X2");
					}
					
					mainForm.updatingElement = true;
					
					mainForm.TxUidTextbox.Text = uidString;
					mainForm.TxUidLengthLabel.Text = rspPayload.Length.ToString() + " bytes";
					mainForm.TxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					mainForm.UpdateEncryptionReady();
					
					mainForm.updatingElement = false;
					
					gotTransmitUid = true;
				} break;
				
				// +==============================+
				// |  SureRsp.ReceivePacketSize   |
				// +==============================+
				case SureRsp.ReceivePacketSize:
				{
					if (rspPayload.Length == 1)
					{
						byte rxPacketSize = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						int payloadSize = rxPacketSize - mainForm.RxUidTextbox.Text.Length/2;
						mainForm.PayloadSizeNumeric.Value = (Decimal)payloadSize;
						mainForm.UpdatePacketSize();
						mainForm.UpdateEncryptionReady();
						
						mainForm.updatingElement = false;
						
						gotReceivePacketSize = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.RadioPolarity     |
				// +==============================+
				case SureRsp.RadioPolarity:
				{
					if (rspPayload.Length == 1)
					{
						byte radioPolarity = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.PolarityCombobox.SelectedIndex = radioPolarity;
						
						mainForm.updatingElement = false;
						
						gotRadioPolarity = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.TransmitPower     |
				// +==============================+
				case SureRsp.TransmitPower:
				{
					if (rspPayload.Length == 1)
					{
						byte transmitPower = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.TransmitPowerCombobox.SelectedIndex = transmitPower - 0x01;
						
						mainForm.updatingElement = false;
						
						gotTransmitPower = true;
					}
				} break;
				
				// +==============================+
				// |       SureRsp.AckData        |
				// +==============================+
				case SureRsp.AckData:
				{
					string ackDataStr = "";
					bool isHexStr = (rspPayload.Length > 0 && !AreBytesAscii(rspPayload.ToArray()));
					int numBytes = 0;
					if (rspPayload.Length > 0)
					{
						if (isHexStr)
						{
							foreach (byte b in rspPayload)
							{
								ackDataStr += b.ToString("X2");
								numBytes++;
							}
						}
						else
						{
							foreach (byte b in rspPayload)
							{
								if (b == 0x00) { break; }
								else
								{
									ackDataStr += (char)b;
									numBytes++;
								}
							}
						}
					}
					
					mainForm.updatingElement = true;
					
					mainForm.AckDataTextbox.Text = ackDataStr;
					mainForm.AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					mainForm.AckDataLengthLabel.Text = "Length: " + numBytes.ToString() + " / " + mainForm.PayloadSizeNumeric.Value.ToString();
					mainForm.AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					mainForm.AckDataHexCheckbox.Checked = isHexStr;
					
					mainForm.updatingElement = false;
					
					gotAckData = true;
				} break;
				
				// +==============================+
				// | SureRsp.TableHoppingEnabled  |
				// +==============================+
				case SureRsp.TableHoppingEnabled:
				{
					if (rspPayload.Length == 1)
					{
						bool tableHoppingEnabled = (rspPayload[0] != 0x00);
						
						mainForm.updatingElement = true;
						
						mainForm.TableHoppingCheckbox.Checked = tableHoppingEnabled;
						
						mainForm.updatingElement = false;
					}
					gotTableHoppingEnabled = true;
				} break;
				
				// +==============================+
				// |      SureRsp.QosConfig       |
				// +==============================+
				case SureRsp.QosConfig:
				{
					if (rspPayload.Length == 1)
					{
						byte qosConfig = rspPayload[0];
						
						mainForm.updatingElement = true;
						mainForm.QosConfigCombobox.SelectedIndex = (qosConfig - 0x01);
						mainForm.updatingElement = false;
					}
					gotQosConfig = true;
				} break;
				
				// +==============================+
				// |     SureRsp.Indications      |
				// +==============================+
				case SureRsp.Indications:
				{
					if (rspPayload.Length == 3)
					{
						byte indication1 = (byte)((rspPayload[0]>>0) & 0x0F);
						byte indication2 = (byte)((rspPayload[0]>>4) & 0x0F);
						byte indication3 = (byte)((rspPayload[1]>>0) & 0x0F);
						byte indication4 = (byte)((rspPayload[1]>>4) & 0x0F);
						byte indication5 = (byte)((rspPayload[2]>>0) & 0x0F);
						byte indication6 = (byte)((rspPayload[2]>>4) & 0x0F);
						
						mainForm.updatingElement = true;
						
						mainForm.LedCombo1.SelectedIndex = indication1;
						mainForm.LedCombo2.SelectedIndex = indication2;
						mainForm.LedCombo3.SelectedIndex = indication3;
						mainForm.LedCombo4.SelectedIndex = indication4;
						mainForm.LedCombo5.SelectedIndex = indication5;
						mainForm.LedCombo6.SelectedIndex = indication6;
						mainForm.PushIndications(true);
						
						mainForm.updatingElement = false;
					}
					gotIndications = true;
				} break;
				
				// +==============================+
				// |      SureRsp.QuietMode       |
				// +==============================+
				case SureRsp.QuietMode:
				{
					if (rspPayload.Length == 1)
					{
						bool quietModeEnabled = (rspPayload[0] != 0x00);
						
						mainForm.updatingElement = true;
						mainForm.QuietModeCheckbox.Checked = quietModeEnabled;
						mainForm.updatingElement = false;
					}
					gotQuietMode = true;
				} break;
				
				// +==============================+
				// |     SureRsp.ButtonConfig     |
				// +==============================+
				case SureRsp.ButtonConfig:
				{
					if (rspPayload.Length == 1)
					{
						byte buttonConfig   = (byte)((rspPayload[0]>>0) & 0x0F);
						byte buttonHoldTime = (byte)((rspPayload[0]>>4) & 0x0F);
						
						mainForm.updatingElement = true;
						
						mainForm.ButtonConfigCombobox.SelectedIndex = (buttonConfig - 0x01);
						mainForm.ButtonHoldTimeNumeric.Value = (Decimal)buttonHoldTime;
						
						mainForm.updatingElement = false;
					}
					gotButtonConfig = true;
				} break;
				
				// +==============================+
				// |     SureRsp.AcksEnabled      |
				// +==============================+
				case SureRsp.AcksEnabled:
				{
					if (rspPayload.Length == 1)
					{
						byte acksEnabled = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.AcksEnabledCheckbox.Checked = (acksEnabled != 0x00);
						mainForm.NumRetriesNumeric.Enabled = mainForm.AcksEnabledCheckbox.Checked;
						mainForm.UpdateEncryptionReady();
						
						mainForm.updatingElement = false;
						
						gotAcksEnabled = true;
					}
				} break;
				
				// +==============================+
				// |      SureRsp.NumRetries      |
				// +==============================+
				case SureRsp.NumRetries:
				{
					if (rspPayload.Length == 1)
					{
						byte numRetries = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.NumRetriesNumeric.Value = (Decimal)numRetries;
						
						mainForm.updatingElement = false;
						
						gotNumRetries = true;
					}
				} break;
				
				default:
				{
					Console.WriteLine("Unhandled command 0x" + ((byte)rspCmd).ToString("X2"));
				} break;
			}
		}
		
		public static string GetBleCommandStr(byte[] commandBytes)
		{
			byte[] cmdPayload = new byte[commandBytes.Length-3];
			Array.Copy(commandBytes, 3, cmdPayload, 0, commandBytes.Length-3);
			
			string result = commandBytes[0].ToString("X2") +
				" {" + commandBytes[1].ToString("X2") + "}" +
				"[" + commandBytes[2].ToString() + "]";
			
			// result += "{";
			foreach (byte b in cmdPayload)
			{
				result += " " + b.ToString("X2");
			}
			// result += " }";
			
			return result;
		}
		
		public static string GetHumanReadableBleCommandStr(byte[] commandBytes)
		{
			BleCmd cmd = (BleCmd)commandBytes[1];
			byte cmdLength = commandBytes[2];
			byte[] cmdPayload = new byte[cmdLength];
			Array.Copy(commandBytes, 3, cmdPayload, 0, cmdLength);
			
			string result = "Ble_" + cmd.ToString() + "[" + cmdLength.ToString() + "]";
			
			switch (cmd)
			{
				default:
				{
					// result += "{";
					foreach (byte b in cmdPayload)
					{
						result += " " + b.ToString("X2");
					}
					// result += " }";
				} break;
			};
			
			return result;
		}
		
		public static string GetBleResponseStr(byte[] responseBytes)
		{
			byte[] rspPayload = new byte[responseBytes.Length-3];
			Array.Copy(responseBytes, 3, rspPayload, 0, responseBytes.Length-3);
			
			string result = responseBytes[0].ToString("X2") +
				" {" + responseBytes[1].ToString("X2") + "}" +
				"[" + responseBytes[2].ToString() + "]";
			
			// result += "{";
			foreach (byte b in rspPayload)
			{
				result += " " + b.ToString("X2");
			}
			// result += " }";
			
			return result;
		}
		
		public static string GetHumanReadableBleResponseStr(byte[] responseBytes)
		{
			BleRsp rspCmd = (BleRsp)responseBytes[1];
			byte rspLength = responseBytes[2];
			byte[] rspPayload = new byte[rspLength];
			Array.Copy(responseBytes, 3, rspPayload, 0, rspLength);
			
			string result = "Ble_" + rspCmd.ToString() + "[" + rspLength.ToString() + "]";
			
			switch (rspCmd)
			{
				case BleRsp.Success:
				{
					BleCmd bleCmd = (BleCmd)rspPayload[0];
					result += ":" + bleCmd.ToString();
				} break;
				
				case BleRsp.Failure:
				{
					BleCmd bleCmd = (BleCmd)rspPayload[0];
					BleError bleError = (BleError)rspPayload[1];
					result += ":" + bleCmd.ToString();
					result += ":" + bleError.ToString();
				} break;
				
				default:
				{
					// result += "{";
					foreach (byte b in rspPayload)
					{
						result += " " + b.ToString("X2");
					}
					// result += " }";
				} break;
			};
			
			return result;
		}
		
		public static void ProcessBleResponse(MainForm mainForm, byte[] responseBytes)
		{
			BleRsp rspCmd = (BleRsp)responseBytes[1];
			byte rspLength = responseBytes[2];
			byte[] rspPayload = new byte[rspLength];
			Array.Copy(responseBytes, 3, rspPayload, 0, rspLength);
			// string rspString = GetHumanReadableBleResponseStr(responseBytes);
			// Console.WriteLine("Got " + rspString);
			
			
			switch (rspCmd)
			{
				// +==============================+
				// |    BleRsp.DfuNeedAdvData     |
				// +==============================+
				// case BleRsp.DfuNeedAdvData:
				// {
				// 	//TODO: Implement me
				// } break;
				
				// +==============================+
				// |       BleRsp.ExmemData       |
				// +==============================+
				// case BleRsp.ExmemData:
				// {
				// 	//TODO: Implement me
				// } break;
				
				// +==============================+
				// |    BleRsp.FirmwareVersion    |
				// +==============================+
				case BleRsp.FirmwareVersion:
				{
					if (rspPayload.Length == 4)
					{
						byte firmwareMajor = rspPayload[0];
						byte firmwareMinor = rspPayload[1];
						UInt16 firmwareBuild = (UInt16)(
							(rspPayload[2] << 0) +
							(rspPayload[3] << 8)
						);
						
						mainForm.BleFirmwareVersionLabel.Text = "Firmware: " + firmwareMajor.ToString() + "." + firmwareMinor.ToString() + " (" + firmwareBuild.ToString() + ")";
						
						gotModuleVersion = true;
					}
				} break;
				
				// +==============================+
				// |        BleRsp.Status         |
				// +==============================+
				case BleRsp.Status:
				{
					if (rspPayload.Length == 1)
					{
						// Console.WriteLine("Got BLE status!");
						// mainForm.BleStatusLabel.Text = "Status: 0x"     + rspPayload[0].ToString("X2");
						for (int bitIndex = 0; bitIndex < 8; bitIndex++)
						{
							byte bit = (byte)(0x01 << bitIndex);
							bool isBitSet = (rspPayload[0] & bit) > 0;
							mainForm.SetBleStatusBit(bit, isBitSet);
						}
						
						byte bleFlags = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						if ((bleFlags & BleFlags_AdvertisingBit) != 0)
						{
							mainForm.BleStartAdvertisingButton.Text = "Stop Advertising";
						}
						else
						{
							mainForm.BleStartAdvertisingButton.Text = "Start Advertising";
						}
						
						mainForm.updatingElement = false;
						
						mainForm.HandleBleStatusUpdate(bleFlags);
						
						gotBleStatus = true;
					}
				} break;
				
				// +==============================+
				// |      BleRsp.MacAddress       |
				// +==============================+
				case BleRsp.MacAddress:
				{
					string macAddressStr = "";
					foreach (byte b in rspPayload)
					{
						if (macAddressStr != "") { macAddressStr = ":" + macAddressStr; }
						macAddressStr = b.ToString("X2") + macAddressStr;
					}
					
					mainForm.updatingElement = true;
					
					mainForm.MacAddressLabel.Text = macAddressStr;
					
					mainForm.updatingElement = false;
					
					gotBleMacAddress = true;
				} break;
				
				// +==============================+
				// |        BleRsp.Success        |
				// +==============================+
				case BleRsp.Success:
				{
					if (rspPayload.Length == 1)
					{
						byte cmdByte = rspPayload[0];
						BleCmd bleCmd = (BleCmd)cmdByte;
						
						mainForm.HandleBleSuccessResponse(bleCmd);
					}
				} break;
				
				// +==============================+
				// |        BleRsp.Failure        |
				// +==============================+
				case BleRsp.Failure:
				{
					if (rspPayload.Length == 2)
					{
						byte cmdByte = rspPayload[0];
						byte errorByte = rspPayload[1];
						BleCmd bleCmd = (BleCmd)cmdByte;
						BleError bleError = (BleError)errorByte;
						
						mainForm.HandleBleFailureResponse(bleCmd, bleError);
					}
				} break;
				
				// +==============================+
				// |      BleRsp.UartTimeout      |
				// +==============================+
				case BleRsp.UartTimeout:
				{
					//TODO: Do something?
				} break;
				
				// +==============================+
				// |    BleRsp.BleWriteTimeout    |
				// +==============================+
				case BleRsp.BleWriteTimeout:
				{
					//TODO: Do something?
				} break;
				
				// +==============================+
				// |   BleRsp.StatusUpdateBits    |
				// +==============================+
				case BleRsp.StatusUpdateBits:
				{
					if (rspPayload.Length == 1)
					{
						mainForm.bleStatusUpdateBits = rspPayload[0];
						mainForm.PushBleStatusUpdateBits(false);
						
						gotBleStatusUpdateBits = true;
					}
				} break;
				
				// +==============================+
				// |    BleRsp.AdvertisingData    |
				// +==============================+
				case BleRsp.AdvertisingData:
				{
					mainForm.updatingElement = true;
					
					int numBytes = 0;
					mainForm.BleAdvertisingDataTextbox.Text = "";
					foreach (byte b in rspPayload)
					{
						mainForm.BleAdvertisingDataTextbox.Text += b.ToString("X2");
						numBytes++;
					}
					mainForm.BleAdvertisingDataLengthLabel.Text = numBytes.ToString() + " bytes";
					
					mainForm.updatingElement = false;
					
					gotBleAdvertisingData = true;
				} break;
				
				// +==============================+
				// |    BleRsp.AdvertisingName    |
				// +==============================+
				case BleRsp.AdvertisingName:
				{
					mainForm.updatingElement = true;
					
					int numBytes = 0;
					mainForm.BleAdvertisingNameTextbox.Text = "";
					foreach (byte b in rspPayload)
					{
						mainForm.BleAdvertisingNameTextbox.Text += (char)b;
						numBytes++;
					}
					mainForm.BleAdvertisingNameLengthLabel.Text = numBytes.ToString() + " bytes";
					
					mainForm.updatingElement = false;
					
					gotBleAdvertisingName = true;
				} break;
				
				// +==============================+
				// |     BleRsp.TemporaryData     |
				// +==============================+
				case BleRsp.TemporaryData:
				{
					mainForm.updatingElement = true;
					
					//TODO: Add temporary data textbox to the UI
					// int numBytes = 0;
					// mainForm.BleTemporaryDataTextbox.Text = "";
					// foreach (byte b in rspPayload)
					// {
					// 	mainForm.BleTemporaryDataTextbox.Text += b.ToString("X2");
					// 	numBytes++;
					// }
					// mainForm.BleTemporaryDataLengthLabel.Text = numBytes.ToString() + " bytes";
					
					mainForm.updatingElement = false;
					
					gotBleTemporaryData = true;
				} break;
				
				// +==============================+
				// |   BleRsp.GpioConfiguration   |
				// +==============================+
				case BleRsp.GpioConfiguration:
				{
					if (rspPayload.Length == 3)
					{
						byte gpioNumber = rspPayload[0];
						byte gpioDirection = rspPayload[1];
						byte gpioOther = rspPayload[2]; //(Either gpioPull or gpioValue)
						if (gpioDirection == 0x01) //Input
						{
							mainForm.PushBleGpioDirection(gpioNumber, gpioDirection, gpioOther, false);
						}
						else //Output
						{
							mainForm.PushBleGpioDirection(gpioNumber, gpioDirection, 0x00, false);
							mainForm.PushBleGpioValue(gpioNumber, gpioOther, false);
						}
					}
					gotBleGpioConfiguration = true;
				} break;
				
				// +==============================+
				// |       BleRsp.GpioValue       |
				// +==============================+
				case BleRsp.GpioValue:
				{
					if (rspPayload.Length == 2)
					{
						byte gpioNumber = rspPayload[0];
						byte gpioValue = rspPayload[1];
						mainForm.PushBleGpioValue(gpioNumber, gpioValue, false);
					}
					gotBleGpioValue = true;
				} break;
				
				// +==============================+
				// |   BleRsp.GpioUpdateEnabled   |
				// +==============================+
				case BleRsp.GpioUpdateEnabled:
				{
					if (rspPayload.Length == 2)
					{
						byte gpioNumber = rspPayload[0];
						bool gpioUpdateEnabled = (rspPayload[1] != 0);
						mainForm.PushBleGpioAutoUpdateEnabled(gpioNumber, gpioUpdateEnabled, false);
					}
					gotBleGpioUpdateEnabled = true;
				} break;
				
				// +==============================+
				// |   BleRsp.RejectConnections   |
				// +==============================+
				case BleRsp.RejectConnections:
				{
					mainForm.updatingElement = true;
					
					if (rspPayload.Length == 1)
					{
						byte rejectConnections = rspPayload[0];
						mainForm.RejectConnectionsCheckbox.Checked = (rejectConnections != 0x00);
					}
					
					mainForm.updatingElement = false;
					
					gotBleRejectConnections = true;
				} break;
				
				default:
				{
					Console.WriteLine("Unhandled BLE command 0x" + ((byte)rspCmd).ToString("X2"));
				} break;
			}
		}
	}
}
