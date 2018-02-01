using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevKitWindowsApp
{
	class SureFi
	{
		public static Dictionary<byte, string> commandNames = new Dictionary<byte, string>
		{
			{ 0x30, "DefaultSettings" },
			{ 0x31, "ClearStatusFlags" },
			{ 0x32, "WriteConfig" },
			{ 0x33, "SetIntEnableBits" },
			{ 0x34, "Reset" },
			{ 0x35, "Sleep" },
			{ 0x36, "QosLightshow" },
			{ 0x37, "TransmitData" },
			{ 0x38, "StartEncryption" },
			{ 0x39, "StopEncryption" },
			{ 0x3A, "ShowQualityOfService" },
		
			{ 0x40, "GetStatus" },
			{ 0x41, "GetIntEnableBits" },
			{ 0x42, "GetModuleVersion" },
			{ 0x43, "GetPacketTimeOnAir" },
			{ 0x44, "GetRandomNumber" },
			{ 0x45, "GetPacket" },
			{ 0x46, "GetAckPacket" },
			{ 0x47, "GetReceiveInfo" },
			{ 0x48, "GetTransmitInfo" },
		
			{ 0x50, "SetAllSettings" },
			{ 0x51, "SetRadioMode" },
			{ 0x52, "SetFhssTable" },
			{ 0x53, "SetReceiveUID" },
			{ 0x54, "SetTransmitUID" },
			{ 0x55, "SetReceivePacketSize" },
			{ 0x56, "SetRadioPolarity" },
			{ 0x57, "SetTransmitPower" },
			{ 0x58, "SetAckData" },
		
			{ 0x60, "SetQosConfig" },
			{ 0x61, "SetIndications" },
			{ 0x62, "SetQuietMode" },
			{ 0x63, "SetButtonConfig" },
			{ 0x64, "SetAcksEnabled" },
			{ 0x65, "SetNumRetries" },
		
			{ 0x70, "GetAllSettings" },
			{ 0x71, "GetRadioMode" },
			{ 0x72, "GetFhssTable" },
			{ 0x73, "GetReceiveUID" },
			{ 0x74, "GetTransmitUID" },
			{ 0x75, "GetReceivePacketSize" },
			{ 0x76, "GetRadioPolarity" },
			{ 0x77, "GetTransmitPower" },
			{ 0x78, "GetAckData" },
		
			{ 0x80, "GetQosConfig" },
			{ 0x81, "GetIndications" },
			{ 0x82, "GetQuietMode" },
			{ 0x83, "GetButtonConfig" },
			{ 0x84, "GetAcksEnabled" },
			{ 0x85, "GetNumRetries" },
		};
		public static Dictionary<byte, string> responseNames = new Dictionary<byte, string>
		{
			{ 0x40, "Status" },
			{ 0x41, "IntEnableBits" },
			{ 0x42, "ModuleVersion" },
			{ 0x43, "PacketTimeOnAir" },
			{ 0x44, "RandomNumber" },
			{ 0x45, "Packet" },
			{ 0x46, "AckPacket" },
			{ 0x47, "ReceiveInfo" },
			{ 0x48, "TransmitInfo" },
			
			{ 0x50, "Success" },
			{ 0x51, "Failure" },
			{ 0x52, "Unsupported" },
			{ 0x53, "UartTimeout" },
			
			{ 0x70, "AllSettings" },
			{ 0x71, "RadioMode" },
			{ 0x72, "FhssTable" },
			{ 0x73, "ReceiveUID" },
			{ 0x74, "TransmitUID" },
			{ 0x75, "ReceivePacketSize" },
			{ 0x76, "RadioPolarity" },
			{ 0x77, "TransmitPower" },
			{ 0x78, "AckData" },
			
			{ 0x80, "QosConfig" },
			{ 0x81, "Indications" },
			{ 0x82, "QuietMode" },
			{ 0x83, "ButtonConfig" },
			{ 0x84, "AcksEnabled" },
			{ 0x85, "NumRetries" },
		};
		
		public static void ProcessResponse(MainForm mainForm, List<byte> responseBytes)
		{
			byte rspCmd = responseBytes[1];
			byte rspLength = responseBytes[2];
			List<byte> rspPayload = responseBytes.GetRange(3, responseBytes.Count-3);
			
			string rspName = responseNames[rspCmd];
			string rspString = rspName + "[" + rspLength.ToString() + "] { ";
			foreach (byte b in rspPayload)
			{
				rspString += b.ToString("X2") + " ";
			}
			rspString += "}";
			
			Console.WriteLine("Got " + rspString);
			if (mainForm.FormatResponsesCheckbox.Checked)
			{
				mainForm.OutputTextbox.Text += rspString + "\r\n";
			}
		}
	}
}
