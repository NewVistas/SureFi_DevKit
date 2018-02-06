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
		ClearStatusFlags,
		WriteConfig,
		SetIntEnableBits,
		Reset,
		Sleep,
		QosLightshow,
		TransmitData,
		StartEncryption,
		StopEncryption,
		ShowQualityOfService,
		
		GetStatus = 0x40,
		GetIntEnableBits,
		GetModuleVersion,
		GetPacketTimeOnAir,
		GetRandomNumber,
		GetPacket,
		GetAckPacket,
		GetReceiveInfo,
		GetTransmitInfo,
		
		SetAllSettings = 0x50,
		SetRadioMode,
		SetFhssTable,
		SetReceiveUID,
		SetTransmitUID,
		SetReceivePacketSize,
		SetRadioPolarity,
		SetTransmitPower,
		SetAckData,
		
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
		
		Success = 0x50,
		Failure,
		Unsupported,
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
	}
	
	class SureFi
	{
		public static byte StateFlags_RadioStateBits          = 0x0F;
		public static byte StateFlags_BusyBit                 = 0x10;
		public static byte StateFlags_EncryptionActiveBit     = 0x20;
		public static byte StateFlags_RxInProgressBit         = 0x40;
		public static byte StateFlags_SettingsPendingBit      = 0x80;
		
		public static byte OtherFlags_DoingLightshowBit       = 0x01;
		public static byte OtherFlags_ShowingQosBit           = 0x02;
		public static byte OtherFlags_ButtonDownBit           = 0x04;
		
		public static byte ClearableFlags_WasResetBit         = 0x01;
		public static byte ClearableFlags_TransmitFinishedBit = 0x02;
		public static byte ClearableFlags_RxPacketReadyBit    = 0x04;
		public static byte ClearableFlags_AckPacketReadyBit   = 0x08;
		public static byte ClearableFlags_ChecksumErrorBit    = 0x10;
		public static byte ClearableFlags_EncryptionRekeyBit  = 0x20;
		public static byte ClearableFlags_ButtonPressedBit    = 0x40;
		public static byte ClearableFlags_ButtonHeldBit       = 0x80;
		
		public static byte ConfigFlags_InterruptDrivenBit     = 0x01;
		public static byte ConfigFlags_AutoClearFlagsBit      = 0x02;
		public static byte ConfigFlags_RxLedModeBit           = 0x04;
		public static byte ConfigFlags_TxLedModeBit           = 0x08;
		public static byte ConfigFlags_AutoRekeyBit           = 0x10;
		
		public static bool gotModuleStatus      = false;
		public static bool gotIntEnableBits     = false;
		public static bool gotModuleVersion     = false;
		public static bool gotPacketTimeOnAir   = false;
		public static bool gotRandomNumber      = false;
		public static bool gotRxPacket          = false;
		public static bool gotAckPacket         = false;
		public static bool gotRxInfo            = false;
		public static bool gotTxInfo            = false;
		public static bool gotAllSettings       = false;
		public static bool gotRadioMode         = false;
		public static bool gotFhssTable         = false;
		public static bool gotReceiveUid        = false;
		public static bool gotTransmitUid       = false;
		public static bool gotReceivePacketSize = false;
		public static bool gotRadioPolarity     = false;
		public static bool gotTransmitPower     = false;
		public static bool gotAckData           = false;
		public static bool gotQosConfig         = false;
		public static bool gotIndications       = false;
		public static bool gotQuietMode         = false;
		public static bool gotButtonConfig      = false;
		public static bool gotAcksEnabled       = false;
		public static bool gotNumRetries        = false;
		
		public static void ClearGotFlags()
		{
			gotModuleStatus      = false;
			gotIntEnableBits     = false;
			gotModuleVersion     = false;
			gotPacketTimeOnAir   = false;
			gotRandomNumber      = false;
			gotRxPacket          = false;
			gotAckPacket         = false;
			gotRxInfo            = false;
			gotTxInfo            = false;
			gotAllSettings       = false;
			gotRadioMode         = false;
			gotFhssTable         = false;
			gotReceiveUid        = false;
			gotTransmitUid       = false;
			gotReceivePacketSize = false;
			gotRadioPolarity     = false;
			gotTransmitPower     = false;
			gotAckData           = false;
			gotQosConfig         = false;
			gotIndications       = false;
			gotQuietMode         = false;
			gotButtonConfig      = false;
			gotAcksEnabled       = false;
			gotNumRetries        = false;
		}
		
		static byte TruncateInt(int intValue)
		{
			if (intValue < 0) { return 0; }
			return (byte)(intValue % 256);
		}
		
		static bool AreBytesAscii(byte[] byteArray)
		{
			bool foundNullTerm = false;
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
				}
				else
				{
					//Found non-ascii character
					return false;
				}
			}
			
			return true;
		}
		
		public static void ProcessResponse(MainForm mainForm, List<byte> responseBytes)
		{
			SureRsp rspCmd = (SureRsp)responseBytes[1];
			byte rspLength = responseBytes[2];
			List<byte> rspPayload = responseBytes.GetRange(3, responseBytes.Count-3);
			
			string rspString = rspCmd.ToString() + "[" + rspLength.ToString() + "]";
			foreach (byte b in rspPayload)
			{
				rspString += " " + b.ToString("X2");
			}
			// rspString += "}";
			
			Console.WriteLine("Got " + rspString);
			if (mainForm.HumanReadableCheckbox.Checked)
			{
				mainForm.OutputTextbox.Text += rspString + "\r\n";
			}
			
			switch (rspCmd)
			{
				// +==============================+
				// |        SureRsp.Status        |
				// +==============================+
				case SureRsp.Status:
				{
					if (rspPayload.Count == 4)
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
						
						byte stateFlags    = rspPayload[0];
						byte otherFlags     = rspPayload[1];
						byte clearableFlags = rspPayload[2];
						byte configFlags    = rspPayload[3];
						mainForm.HandleStatusUpdate(stateFlags, otherFlags, clearableFlags, configFlags);
						
						gotModuleStatus = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.IntEnableBits     |
				// +==============================+
				case SureRsp.IntEnableBits:
				{
					if (rspPayload.Count == 4)
					{
						//TODO: Implement me
						
						gotIntEnableBits = true;
					}
				} break;
				
				// +==============================+
				// |    SureRsp.ModuleVersion     |
				// +==============================+
				case SureRsp.ModuleVersion:
				{
					if (rspPayload.Count == 11)
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
					if (rspPayload.Count == 2)
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
					if (rspPayload.Count == 4)
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
					//TODO: This won't be necassary in the future when
					//		the responses come back without the UID
					int rxUidLength = 0;
					byte[] rxUid = null;
					if (mainForm.TryParseHexString(mainForm.RxUidTextbox.Text, out rxUid))
					{
						rxUidLength = rxUid.Length;
					}
					byte[] radioPayload = rspPayload.GetRange(rxUidLength, rspPayload.Count - rxUidLength).ToArray();
					bool isHexStr = (mainForm.RxHexCheckbox.Checked || !AreBytesAscii(radioPayload));
					
					mainForm.updatingElement = true;
					
					int numBytes = 0;
					if (isHexStr)
					{
						//Auto-Check the HEX checkbox
						mainForm.RxHexCheckbox.Checked = true;
						
						mainForm.RxTextbox.Text = "";
						foreach (byte b in radioPayload)
						{
							mainForm.RxTextbox.Text += b.ToString("X2");
							numBytes++;
						}
					}
					else
					{
						mainForm.RxTextbox.Text = "";
						foreach (byte b in radioPayload)
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
					
					gotAckPacket = true;
				} break;
				
				// +==============================+
				// |     SureRsp.ReceiveInfo      |
				// +==============================+
				case SureRsp.ReceiveInfo:
				{
					if (rspPayload.Count == 4)
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
					if (rspPayload.Count == 6)
					{
						byte succcessByte  = rspPayload[0];
						short rssi         = (short)(rspPayload[1] + (rspPayload[2] << 8));
						sbyte snr          = (sbyte)(rspPayload[3]);
						byte numRetries    = rspPayload[4];
						byte ackDataLength = rspPayload[5];
						
						mainForm.updatingElement = true;
						
						mainForm.TxRssiLabel.Text = "RSSI: " + rssi.ToString();
						mainForm.TxSnrLabel.Text  = "SNR: " + snr.ToString();
						mainForm.TxRetriesLabel.Text = numRetries.ToString() + "/" + mainForm.NumRetriesNumeric.Value.ToString() + " retries";
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
				// |       SureRsp.Success        |
				// +==============================+
				case SureRsp.Success:
				{
					if (rspPayload.Count == 1)
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
					if (rspPayload.Count == 2)
					{
						byte cmdByte = rspPayload[0];
						byte errorByte = rspPayload[1];
						SureCmd sureCmd = (SureCmd)cmdByte;
						SureError sureError = (SureError)errorByte;
						
						mainForm.HandleFailureResponse(sureCmd, sureError);
					}
				} break;
				
				// +==============================+
				// |     SureRsp.Unsupported      |
				// +==============================+
				case SureRsp.Unsupported:
				{
					
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
					if (rspPayload.Count == 13)
					{
						byte radioMode         = rspPayload[0];
						byte fhssTable         = rspPayload[1];
						byte receivePacketSize = rspPayload[2];
						byte radioPolarity     = rspPayload[3];
						byte transmitPower     = rspPayload[4];
						byte qosConfig         = rspPayload[5];
						byte[] indications     = rspPayload.GetRange(6, 3).ToArray();
						byte quietMode         = rspPayload[9];
						byte buttonConfig      = rspPayload[10];
						byte acksEnabled       = rspPayload[11];
						byte numRetries        = rspPayload[12];
						
						mainForm.updatingElement = true;
						
						mainForm.FhssTableNumeric.Value = (Decimal)fhssTable;
						int payloadSize = receivePacketSize - mainForm.RxUidTextbox.Text.Length/2;
						mainForm.PayloadSizeNumeric.Value = (Decimal)payloadSize;
						mainForm.UpdatePacketSize();
						mainForm.PolarityCombobox.SelectedIndex = radioPolarity;
						mainForm.TransmitPowerCombobox.SelectedIndex = transmitPower - 0x01;
						
						//TODO: Fill the rest of the stuff
						
						mainForm.AcksEnabledCheckbox.Checked = (acksEnabled != 0x00);
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
					if (rspPayload.Count == 1 && rspPayload[0] <= 0x04)
					{
						byte radioMode = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.RadioModeCombobox.SelectedIndex = radioMode - 0x01;
						mainForm.SpreadingFactorCombobox.Enabled = false;
						mainForm.BandwidthCombobox.Enabled = false;
						
						mainForm.updatingElement = false;
						
						gotRadioMode = true;
					}
					else if (rspPayload.Count == 3 && rspPayload[0] == 0x07)
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
					if (rspPayload.Count == 1)
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
					mainForm.RxUidLengthLabel.Text = rspPayload.Count.ToString() + " bytes";
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
					mainForm.TxUidLengthLabel.Text = rspPayload.Count.ToString() + " bytes";
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
					if (rspPayload.Count == 1)
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
					if (rspPayload.Count == 1)
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
					if (rspPayload.Count == 1)
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
					bool isHexStr = !AreBytesAscii(rspPayload.ToArray());
					int numBytes = 0;
					if (rspPayload.Count > 0)
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
				// |      SureRsp.QosConfig       |
				// +==============================+
				case SureRsp.QosConfig:
				{
					
					gotQosConfig = true;
				} break;
				
				// +==============================+
				// |     SureRsp.Indications      |
				// +==============================+
				case SureRsp.Indications:
				{
					
					gotIndications = true;
				} break;
				
				// +==============================+
				// |      SureRsp.QuietMode       |
				// +==============================+
				case SureRsp.QuietMode:
				{
					
					gotQuietMode = true;
				} break;
				
				// +==============================+
				// |     SureRsp.ButtonConfig     |
				// +==============================+
				case SureRsp.ButtonConfig:
				{
					
					gotButtonConfig = true;
				} break;
				
				// +==============================+
				// |     SureRsp.AcksEnabled      |
				// +==============================+
				case SureRsp.AcksEnabled:
				{
					if (rspPayload.Count == 1)
					{
						byte acksEnabled = rspPayload[0];
						
						mainForm.updatingElement = true;
						
						mainForm.AcksEnabledCheckbox.Checked = (acksEnabled != 0x00);
						mainForm.NumRetriesNumeric.Enabled = mainForm.AcksEnabledCheckbox.Checked;
						
						mainForm.updatingElement = false;
						
						gotAcksEnabled = true;
					}
				} break;
				
				// +==============================+
				// |      SureRsp.NumRetries      |
				// +==============================+
				case SureRsp.NumRetries:
				{
					if (rspPayload.Count == 1)
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
	}
}
