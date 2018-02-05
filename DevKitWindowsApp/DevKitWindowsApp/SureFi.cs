using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevKitWindowsApp
{
	enum SureCmd : byte
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
	
	enum SureRsp : byte
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
	
	class SureFi
	{
		static byte TruncateInt(int intValue)
		{
			if (intValue < 0) { return 0; }
			return (byte)(intValue % 256);
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
					}
				} break;
				
				// +==============================+
				// |        SureRsp.Packet        |
				// +==============================+
				case SureRsp.Packet:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.AckPacket       |
				// +==============================+
				case SureRsp.AckPacket:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.ReceiveInfo      |
				// +==============================+
				case SureRsp.ReceiveInfo:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.TransmitInfo     |
				// +==============================+
				case SureRsp.TransmitInfo:
				{
					
				} break;
				
				// +==============================+
				// |       SureRsp.Success        |
				// +==============================+
				case SureRsp.Success:
				{
					
				} break;
				
				// +==============================+
				// |       SureRsp.Failure        |
				// +==============================+
				case SureRsp.Failure:
				{
					
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
					
				} break;
				
				// +==============================+
				// |      SureRsp.RadioMode       |
				// +==============================+
				case SureRsp.RadioMode:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.FhssTable       |
				// +==============================+
				case SureRsp.FhssTable:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.ReceiveUID      |
				// +==============================+
				case SureRsp.ReceiveUID:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.TransmitUID      |
				// +==============================+
				case SureRsp.TransmitUID:
				{
					
				} break;
				
				// +==============================+
				// |  SureRsp.ReceivePacketSize   |
				// +==============================+
				case SureRsp.ReceivePacketSize:
				{
					
				} break;
				
				// +==============================+
				// |    SureRsp.RadioPolarity     |
				// +==============================+
				case SureRsp.RadioPolarity:
				{
					
				} break;
				
				// +==============================+
				// |    SureRsp.TransmitPower     |
				// +==============================+
				case SureRsp.TransmitPower:
				{
					
				} break;
				
				// +==============================+
				// |       SureRsp.AckData        |
				// +==============================+
				case SureRsp.AckData:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.QosConfig       |
				// +==============================+
				case SureRsp.QosConfig:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.Indications      |
				// +==============================+
				case SureRsp.Indications:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.QuietMode       |
				// +==============================+
				case SureRsp.QuietMode:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.ButtonConfig     |
				// +==============================+
				case SureRsp.ButtonConfig:
				{
					
				} break;
				
				// +==============================+
				// |     SureRsp.AcksEnabled      |
				// +==============================+
				case SureRsp.AcksEnabled:
				{
					
				} break;
				
				// +==============================+
				// |      SureRsp.NumRetries      |
				// +==============================+
				case SureRsp.NumRetries:
				{
					
				} break;
				
				default:
				{
					Console.WriteLine("Unhandled command 0x" + ((byte)rspCmd).ToString("X2"));
				} break;
			}
		}
	}
}
