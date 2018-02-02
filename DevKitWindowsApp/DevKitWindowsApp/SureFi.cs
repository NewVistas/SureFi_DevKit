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
			
			string rspString = rspCmd.ToString() + "[" + rspLength.ToString() + "] { ";
			foreach (byte b in rspPayload)
			{
				rspString += b.ToString("X2") + " ";
			}
			rspString += "}";
			
			Console.WriteLine("Got " + rspString);
			if (mainForm.HumanReadableCheckbox.Checked)
			{
				mainForm.OutputTextbox.Text += rspString + "\r\n";
			}
			
			switch (rspCmd)
			{
				case SureRsp.Status:
				{
					Console.WriteLine("Got status!");
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
							Console.WriteLine("Setting " + bIndex.ToString() + "." + bit.ToString("X2") + " to " + isBitSet.ToString());
							mainForm.SetStatusBit(bIndex, bit, isBitSet);
						}
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
