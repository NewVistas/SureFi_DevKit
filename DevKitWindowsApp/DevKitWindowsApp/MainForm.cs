using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace DevKitWindowsApp
{
	public partial class MainForm : Form
	{
		// +==============================+
		// |       Member Variables       |
		// +==============================+
		ConnectForm connectForm;
		PortFifo port;
		int connectionTimeout = 0;
		bool isConnecting = false;
		byte savedStateFlags = 0x00;
		byte savedOtherFlags = 0x00;
		byte savedClearableFlags = 0x00;
		byte savedConfigFlags = 0x00;
		
		public delegate void ConnectionResultHandler(object sender, bool success, string message);
		public event ConnectionResultHandler OnConnectionFinished;
		
		//NOTE: This variable prevents many of the "ValueChanged" call backs from taking action
		//		It should be set whenever you want to programmatically change the value of a UI element without causing unintended effects
		public bool updatingElement = false;
		
		// +==============================+
		// |       Helper Functions       |
		// +==============================+
		void ReportConnectionResult(bool success, string message)
		{
			Console.WriteLine("Connection " + (success ? "Succeeded" : "Failed") + "!");
			
			this.OutputTextbox.Clear();
			this.port.commandHistory.Clear();
			this.port.commandHistoryIsRsp.Clear();
			
			OnConnectionFinished(this, success, message);
			
			if (!success) { this.Close(); }
		}
		
		void StatusUpdate(string statusMessage)
		{
			StatusLabel.Text = statusMessage;
		}
		
		public void SetStatusBit(int statusByte, byte bit, bool filled)
		{
			Label bitLabel = null;
			if (statusByte == 0)
			{
				if (bit == 0x01) { bitLabel = this.RadioStateBit1;      }
				if (bit == 0x02) { bitLabel = this.RadioStateBit2;      }
				if (bit == 0x04) { bitLabel = this.RadioStateBit3;      }
				if (bit == 0x08) { bitLabel = this.RadioStateBit4;      }
				if (bit == 0x10) { bitLabel = this.BusyBit;             }
				if (bit == 0x20) { bitLabel = this.EncryptionActiveBit; }
				if (bit == 0x40) { bitLabel = this.RxInProgressBit;     }
				if (bit == 0x80) { bitLabel = this.SettingsPendingBit;  }
			}
			if (statusByte == 1)
			{
				if (bit == 0x01) { bitLabel = this.DoingLightshowBit;   }
				if (bit == 0x02) { bitLabel = this.ShowingQosBit;       }
				if (bit == 0x04) { bitLabel = this.ButtonDownBit;       }
			}
			if (statusByte == 2)
			{
				if (bit == 0x01) { bitLabel = this.WasResetBit;         }
				if (bit == 0x02) { bitLabel = this.TransmitFinishedBit; }
				if (bit == 0x04) { bitLabel = this.RxPacketReadyBit;    }
				if (bit == 0x08) { bitLabel = this.AckPacketReadyBit;   }
				if (bit == 0x10) { bitLabel = this.ChecksumErrorBit;    }
				if (bit == 0x20) { bitLabel = this.EncryptionRekeyBit;  }
				if (bit == 0x40) { bitLabel = this.ButtonPressedBit;    }
				if (bit == 0x80) { bitLabel = this.ButtonHeldBit;       }
			}
			if (statusByte == 3)
			{
				if (bit == 0x01) { bitLabel = this.InterruptDrivenBit; }
				if (bit == 0x02) { bitLabel = this.AutoClearFlagsBit;  }
				if (bit == 0x04) { bitLabel = this.RxLedModeBit;       }
				if (bit == 0x08) { bitLabel = this.TxLedModeBit;       }
				if (bit == 0x10) { bitLabel = this.AutoRekeyBit;       }
			}
			
			string newText = filled ? "1" : "0";
			if (bitLabel != null && bitLabel.Text != newText)
			{
				bitLabel.Text = newText;
				bitLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.DeepSkyBlue : KnownColor.Transparent);
				bitLabel.ForeColor = Color.FromKnownColor(filled ? KnownColor.Control : KnownColor.ControlText);
			}
		}
		
		public void IncrementCount(Label label)
		{
			int currentCount = 0;
			if (label.Text.Length > 7)
			{
				string numString = label.Text.Substring(7, label.Text.Length - 7);
				int.TryParse(numString, out currentCount);
			}
			currentCount++;
			label.Text = "Count: " + currentCount.ToString();
		}
		
		bool IsHexChar(char c)
		{
			if (c >= '0' && c <= '9') { return true; }
			if (c >= 'a' && c <= 'f') { return true; }
			if (c >= 'A' && c <= 'F') { return true; }
			return false;
		}
		
		byte GetHexCharValue(char c)
		{
			if (c >= '0' && c <= '9') { return (byte)(c - '0'); }
			if (c >= 'a' && c <= 'f') { return (byte)((c - 'a') + 10); }
			if (c >= 'A' && c <= 'F') { return (byte)((c - 'A') + 10); }
			return 0;
		}
		
		public bool TryParseHexString(string hexString, out byte[] bytesOut)
		{
			// if (hexString.Length < 2) { bytesOut = null; return false; }
			if ((hexString.Length%2) != 0) { bytesOut = null; return false; }
			bytesOut = new byte[hexString.Length/2];
			
			int bIndex = 0;
			for (int cIndex = 0; cIndex+2 <= hexString.Length; cIndex += 2)
			{
				char c1 = hexString[cIndex];
				char c2 = hexString[cIndex+1];
				if (!IsHexChar(c1)) { return false; }
				if (!IsHexChar(c2)) { return false; }
				byte hexValue = GetHexCharValue(c1);
				hexValue = (byte)(hexValue << 4);
				hexValue += GetHexCharValue(c2);
				bytesOut[bIndex] = hexValue;
				bIndex++;
			}
			
			return true;
		}
		
		public void PrintRxCommand(byte[] responseBytes)
		{
			string commandStr = "";
			
			if (this.HumanReadableCheckbox.Checked)
			{
				commandStr = SureFi.GetHumanReadableResponseStr(responseBytes);
			}
			else
			{
				commandStr = SureFi.GetResponseStr(responseBytes);
			}
			
			if (this.PrintStatusCheckbox.Checked || (SureRsp)responseBytes[1] != SureRsp.Status)
			{
				this.OutputTextbox.AppendText(commandStr + "\r\n");
			}
		}
		
		public void PrintTxCommand(byte[] commandBytes)
		{
			string commandStr = "";
			
			if (this.HumanReadableCheckbox.Checked)
			{
				commandStr = SureFi.GetHumanReadableCommandStr(commandBytes);
			}
			else
			{
				commandStr = SureFi.GetCommandStr(commandBytes);
			}
			
			this.OutputTextbox.AppendText(">>" + commandStr + "\r\n");
		}
		
		void RefreshOutputTextbox()
		{
			this.OutputTextbox.Clear();
			
			for (int hIndex = 0; hIndex < this.port.commandHistory.Count; hIndex++)
			{
				if (this.port.commandHistoryIsRsp[hIndex])
				{
					PrintRxCommand(this.port.commandHistory[hIndex]);
				}
				else
				{
					PrintTxCommand(this.port.commandHistory[hIndex]);
				}
			}
		}
		
		public void HandleSuccessResponse(SureCmd cmd)
		{
			if (cmd == SureCmd.TransmitData)
			{
				TransmitButton.Text = "Started...";
				
				IncrementCount(this.TxCountLabel);
			}
		}
		public void HandleFailureResponse(SureCmd cmd, SureError error)
		{
			//TODO: Show a messagebox
			
			if (cmd == SureCmd.TransmitData)
			{
				TransmitButton.Text = "Transmit";
				TransmitButton.Enabled = true;
			}
		}
		
		public void HandleStatusUpdate(byte stateFlags, byte otherFlags, byte clearableFlags, byte configFlags)
		{
			byte stateChanged     = (byte)(stateFlags ^ this.savedStateFlags);
			byte otherChanged     = (byte)(stateFlags ^ this.savedOtherFlags);
			byte clearableChanged = (byte)(stateFlags ^ this.savedClearableFlags);
			byte configChanged    = (byte)(stateFlags ^ this.savedConfigFlags);
			
			if ((stateChanged & SureFi.StateFlags_BusyBit) != 0)
			{
				if ((stateFlags & SureFi.StateFlags_BusyBit) != 0)
				{
					Console.WriteLine("Module is Busy");
				}
				else
				{
					Console.WriteLine("Module is Not Busy");
				}
			}
			
			RadioState radioState = (RadioState)(stateFlags & 0x0F);
			if (radioState == RadioState.Transmitting || radioState == RadioState.WaitingForAck)
			{
				this.TransmitButton.Text = "Transmitting...";
				this.TransmitButton.Enabled = false;
			}
			
			if ((stateChanged & SureFi.StateFlags_EncryptionActiveBit) != 0)
			{
				if ((stateFlags & SureFi.StateFlags_EncryptionActiveBit) != 0)
				{
					StartEncryptionButton.Text = "Stop Encryption";
				}
				else
				{
					StartEncryptionButton.Text = "Start Encryption";
				}
			}
			
			byte flagsToClear = 0x00;
			
			if ((clearableChanged & SureFi.ClearableFlags_WasResetBit) != 0 &&
				(clearableFlags & SureFi.ClearableFlags_WasResetBit) != 0)
			{
				Console.WriteLine("Module was reset. Getting all settings again");
				SureFi.ClearGotFlags();
				this.port.PushTxCommandNoBytes(SureCmd.GetModuleVersion);
				this.port.PushTxCommandNoBytes(SureCmd.GetStatus);
				this.port.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
				this.port.PushTxCommandNoBytes(SureCmd.GetTransmitUID);
				this.port.PushTxCommandNoBytes(SureCmd.GetRadioMode);
				this.port.PushTxCommandNoBytes(SureCmd.GetAllSettings);
				this.port.PushTxCommandNoBytes(SureCmd.GetAckData);
				
				flagsToClear |= SureFi.ClearableFlags_WasResetBit;
			}
			
			if ((clearableChanged & SureFi.ClearableFlags_TransmitFinishedBit) != 0 &&
				(clearableFlags & SureFi.ClearableFlags_TransmitFinishedBit) != 0)
			{
				Console.WriteLine("Transmit finished");
				this.port.PushTxCommandNoBytes(SureCmd.GetTransmitInfo);
				flagsToClear |= SureFi.ClearableFlags_TransmitFinishedBit;
				
				this.TransmitButton.Text = "Getting Info...";
			}
			
			if ((clearableChanged & SureFi.ClearableFlags_RxPacketReadyBit) != 0 &&
				(clearableFlags & SureFi.ClearableFlags_RxPacketReadyBit) != 0)
			{
				Console.WriteLine("Packet Received");
				this.port.PushTxCommandNoBytes(SureCmd.GetReceiveInfo);
				this.port.PushTxCommandNoBytes(SureCmd.GetPacket);
				flagsToClear |= SureFi.ClearableFlags_RxPacketReadyBit;
			}
			
			if ((clearableChanged & SureFi.ClearableFlags_AckPacketReadyBit) != 0 &&
				(clearableFlags & SureFi.ClearableFlags_AckPacketReadyBit) != 0)
			{
				Console.WriteLine("Ack Packet Received");
				this.port.PushTxCommandNoBytes(SureCmd.GetAckPacket);
				flagsToClear |= SureFi.ClearableFlags_AckPacketReadyBit;
			}
			
			if ((configFlags & SureFi.ConfigFlags_AutoClearFlagsBit) == 0 &&
				flagsToClear != 0x00)
			{
				Console.WriteLine("Manually clearing flags: 0x" + flagsToClear.ToString("X2"));
				byte[] payload = { flagsToClear };
				this.port.PushTxCommand(SureCmd.ClearStatusFlags, payload);
			}
			
			this.savedStateFlags     = stateFlags;
			this.savedOtherFlags     = otherFlags;
			this.savedClearableFlags = clearableFlags;
			this.savedConfigFlags    = configFlags;
		}
		
		// +==============================+
		// |         Form Events          |
		// +==============================+
		public MainForm(ConnectForm connectForm)
		{
			InitializeComponent();
			
			this.connectForm = connectForm;
		}
		
		public void TryConnectToPort(string portName)
		{
			if (this.port != null && this.port.isOpen)
			{
				ReportConnectionResult(false, "Port is already open");
				return;
			}
			
			this.port = new PortFifo(this, portName);
			if (this.port.isOpen)
			{
				StatusUpdate("Connecting to " + portName + "...");
			}
			else
			{
				ReportConnectionResult(false, this.port.connectFailureString);
				return;
			}
			
			this.savedStateFlags = 0x00;
			this.savedOtherFlags = 0x00;
			this.savedClearableFlags = 0x00;
			this.savedConfigFlags = 0x00;
			
			SureFi.ClearGotFlags();
			this.port.PushTxCommandNoBytes(SureCmd.GetModuleVersion);
			this.port.PushTxCommandNoBytes(SureCmd.GetStatus);
			this.port.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetTransmitUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetRadioMode);
			this.port.PushTxCommandNoBytes(SureCmd.GetAllSettings);
			this.port.PushTxCommandNoBytes(SureCmd.GetAckData);
			
			this.OutputTextbox.Text = "";
			this.isConnecting = true;
			this.connectionTimeout = 2000/this.TickTimer.Interval;
			this.TickTimer.Enabled = true;
		}
		
		private void MainForm_Load(object sender, EventArgs e)
		{
		
		}
		
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.port != null)
			{
				this.port.Close();
			}
		}
		
		// +==============================+
		// |          Tick Timer          |
		// +==============================+
		private void TickTimer_Tick(object sender, EventArgs e)
		{
			if (this.port != null)
			{
				bool wasOpen = this.port.isOpen;
				
				this.port.Update();
				
				if (wasOpen && !this.port.isOpen)
				{
					this.Hide();
					connectForm.Show();
					ReportConnectionResult(false, this.port.connectFailureString);
					this.Close();
					return;
				}
				
				List<byte> newCommandList = this.port.PopRxCommand();
				while (newCommandList != null)
				{
					byte[] newCommand = newCommandList.ToArray();
					// Console.Write("Got " + newCommand.Count.ToString() + " byte command { ");
					// foreach (byte b in newCommand)
					// {
					// 	Console.Write(b.ToString("X2") + " ");
					// }
					// Console.WriteLine("}");
					SureFi.ProcessResponse(this, newCommand);
					
					newCommandList = this.port.PopRxCommand();
				}
				
				if (this.isConnecting)
				{
					if (SureFi.gotModuleVersion &&
						SureFi.gotModuleStatus &&
						SureFi.gotReceiveUid &&
						SureFi.gotTransmitUid &&
						SureFi.gotAckData &&
						SureFi.gotRadioMode &&
						SureFi.gotAllSettings)
					{
						Console.WriteLine("Got all responses from the module");
						this.isConnecting = false;
						ReportConnectionResult(true, "");
						StatusUpdate("Connected to " + this.port.portName + "!");
					}
				}
			}
			
			if (this.connectionTimeout > 0)
			{
				this.connectionTimeout--;
			}
			
			if (this.isConnecting && this.connectionTimeout <= 0)
			{
				this.isConnecting = false;
				Console.WriteLine("Connection timed out");
				ReportConnectionResult(false, "Connection timed out before receiving all responses");
				this.port.Close();
			}
		}
		
		// +==============================+
		// |        Control Events        |
		// +==============================+
		
		private void OutputClearButton_Click(object sender, EventArgs e)
		{
			OutputTextbox.Clear();
			if (this.port != null)
			{
				this.port.commandHistory.Clear();
				this.port.commandHistoryIsRsp.Clear();
			}
		}
		
		private void HumanReadableCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			RefreshOutputTextbox();
		}
			
		private void PrintStatusCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			RefreshOutputTextbox();
		}
		
		private void DisconnectButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.connectForm.Show();
			this.Close();
		}
		
		// +--------------------------------------------------------------+
		// |                      Radio Settings Tab                      |
		// +--------------------------------------------------------------+
		// +==============================+
		// |    Encryption Ready Label    |
		// +==============================+
		public void UpdateEncryptionReady()
		{
			bool rxUidSizeGood = false;
			bool txUidSizeGood = false;
			bool packetSizeGood = false;
			
			int packetSize = 0;
			byte[] uid = null;
			if (TryParseHexString(RxUidTextbox.Text, out uid))
			{
				if (uid.Length > 0)
				{
					rxUidSizeGood = true;
				}
				
				packetSize += uid.Length;
				packetSize += (int)PayloadSizeNumeric.Value;
				if (packetSize > 0 && packetSize <= 64 &&
					((packetSize+1) % 8) == 0)
				{
					packetSizeGood = true;
				}
			}
			if (TryParseHexString(TxUidTextbox.Text, out uid))
			{
				if (uid.Length > 0)
				{
					txUidSizeGood = true;
				}
			}
			
			if (!rxUidSizeGood)
			{
				EncryptionReadyLabel.Text = "X Encryption: Rx UID is 0 bytes";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
			else if (!txUidSizeGood)
			{
				EncryptionReadyLabel.Text = "X Encryption: Tx UID is 0 bytes";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
			else if (!packetSizeGood)
			{
				EncryptionReadyLabel.Text = "✓ Encryption: PacketSize+1 is not multiple of 8";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.Orange);
			}
			else
			{
				EncryptionReadyLabel.Text = "✓ Encryption: Ready";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
			}
		}
		
		// +==============================+
		// |        Rx UID Textbox        |
		// +==============================+
		private bool rxUidChanged = false;
		private void PushRxUidChange()
		{
			byte[] uid = null;
			if (TryParseHexString(RxUidTextbox.Text, out uid))
			{
				port.PushTxCommand(SureCmd.SetReceiveUID, uid);
				RxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
			else
			{
				RxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
		}
		private void RxUidTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				// Console.WriteLine("Rx Uid Text Changed");
				
				//Crop the text down to 8 bytes
				if (RxUidTextbox.Text.Length > 8*2)//TODO: MAX_UID_LENGTH define?
				{
					updatingElement = true;
					
					int selectionPos = RxUidTextbox.SelectionStart;
					RxUidTextbox.Text = RxUidTextbox.Text.Substring(0, 8*2);//TODO: MAX_UID_LENGTH define?
					if (selectionPos > RxUidTextbox.Text.Length) { selectionPos = RxUidTextbox.Text.Length; }
					RxUidTextbox.SelectionStart = selectionPos;
					RxUidTextbox.SelectionLength = 0;
					
					updatingElement = false;
				}
				
				byte[] hexValues = null;
				if (TryParseHexString(RxUidTextbox.Text, out hexValues))
				{
					RxUidLengthLabel.Text = hexValues.Length.ToString() + " bytes";
					RxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					
					UpdatePacketSize();
					UpdateEncryptionReady();
				}
				else
				{
					RxUidLengthLabel.Text = "Invalid";
					RxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
				
				RxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
				rxUidChanged = true;
			}
		}
		private void RxUidTextbox_Leave(object sender, EventArgs e)
		{
			if (rxUidChanged)
			{
				rxUidChanged = false;
				PushPacketSizeChange(false);
				UpdateEncryptionReady();
				PushRxUidChange();
			}
		}
		private void RxUidTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)// && rxUidChanged)
			{
				rxUidChanged = false;
				PushPacketSizeChange(false);
				UpdateEncryptionReady();
				PushRxUidChange();
			}
		}
		
		// +==============================+
		// |        Tx UID Textbox        |
		// +==============================+
		private bool txUidChanged = false;
		private void PushTxUidChange()
		{
			byte[] uid = null;
			if (TryParseHexString(TxUidTextbox.Text, out uid))
			{
				port.PushTxCommand(SureCmd.SetTransmitUID, uid);
				TxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
			else
			{
				TxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
		}
		
		private void TxUidTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				// Console.WriteLine("Tx Uid Text Changed");
				
				//Crop the text down to 8 bytes
				if (TxUidTextbox.Text.Length > 8*2)//TODO: MAX_UID_LENGTH define?
				{
					updatingElement = true;
					
					int selectionPos = TxUidTextbox.SelectionStart;
					TxUidTextbox.Text = TxUidTextbox.Text.Substring(0, 8*2);//TODO: MAX_UID_LENGTH define?
					if (selectionPos > TxUidTextbox.Text.Length) { selectionPos = TxUidTextbox.Text.Length; }
					TxUidTextbox.SelectionStart = selectionPos;
					TxUidTextbox.SelectionLength = 0;
					
					updatingElement = false;
				}
				
				byte[] hexValues = null;
				if (TryParseHexString(TxUidTextbox.Text, out hexValues))
				{
					TxUidLengthLabel.Text = hexValues.Length.ToString() + " bytes";
					TxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					TxUidLengthLabel.Text = "Invalid";
					TxUidLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
				
				TxUidTextbox.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
				txUidChanged = true;
			}
		}
		
		private void TxUidTextbox_Leave(object sender, EventArgs e)
		{
			if (txUidChanged)
			{
				txUidChanged = false;
				UpdateEncryptionReady();
				PushTxUidChange();
			}
		}
		
		private void TxUidTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)// && txUidChanged)
			{
				txUidChanged = false;
				UpdateEncryptionReady();
				PushTxUidChange();
			}
		}
		
		// +==============================+
		// |     Payload Size Numeric     |
		// +==============================+
		public void PushPacketSizeChange(bool onlyLabel)
		{
			int packetSize = 0;
			byte[] rxUid = null;
			if (TryParseHexString(RxUidTextbox.Text, out rxUid))
			{
				packetSize += rxUid.Length;
				packetSize += (int)PayloadSizeNumeric.Value;
				
				if (packetSize > 0 && packetSize <= 64)
				{
					RxPacketSizeLabel.Text = packetSize.ToString() + " byte ReceivePacketSize";
					RxPacketSizeLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					
					if (!onlyLabel)
					{
						byte[] payload = { (byte)packetSize };
						port.PushTxCommand(SureCmd.SetReceivePacketSize, payload);
					}
				}
				else
				{
					RxPacketSizeLabel.Text = packetSize.ToString() + " byte ReceivePacketSize";
					RxPacketSizeLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
				
			}
			else
			{
				RxPacketSizeLabel.Text = "? byte ReceivePacketSize";
				RxPacketSizeLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
		}
		public void UpdatePacketSize()
		{
			PushPacketSizeChange(true);
		}
		private void PayloadSizeNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				updatingElement = true;
				if (PayloadSizeNumeric.Value < 0)
				{
					PayloadSizeNumeric.Value = 0;
				}
				if (PayloadSizeNumeric.Value > 64)
				{
					PayloadSizeNumeric.Value = 64;
				}
				updatingElement = false;
				
				UpdateEncryptionReady();
				PushPacketSizeChange(false);
			}
		}
		
		// +==============================+
		// |   Transmit Power Combobox    |
		// +==============================+
		private void PushTransmitPower()
		{
			byte[] payload = { (byte)(TransmitPowerCombobox.SelectedIndex + 1) };
			this.port.PushTxCommand(SureCmd.SetTransmitPower, payload);
		}
		private void TransmitPowerCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushTransmitPower();
			}
		}
		
		// +==============================+
		// |      Polarity Combobox       |
		// +==============================+
		private void PushPolarity()
		{
			if (PolarityCombobox.SelectedIndex == 0) //Disabled
			{
				byte[] payload = { 0x00 };
				this.port.PushTxCommand(SureCmd.SetRadioPolarity, payload);
			}
			else if (PolarityCombobox.SelectedIndex == 1) //Up
			{
				byte[] payload = { 0x01 };
				this.port.PushTxCommand(SureCmd.SetRadioPolarity, payload);
			}
			else if (PolarityCombobox.SelectedIndex == 2) //Down
			{
				byte[] payload = { 0x02 };
				this.port.PushTxCommand(SureCmd.SetRadioPolarity, payload);
			}
		}
		private void PolarityCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushPolarity();
			}
		}
		
		// +==============================+
		// |     FHSS Table Combobox      |
		// +==============================+
		private void PushFhssTable()
		{
			byte[] payload = { (byte)FhssTableNumeric.Value };
			this.port.PushTxCommand(SureCmd.SetFhssTable, payload);
		}
		private void FhssTableNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				updatingElement = true;
				if (FhssTableNumeric.Value < 0)
				{
					FhssTableNumeric.Value = 0;
				}
				if (FhssTableNumeric.Value >= 216)
				{
					FhssTableNumeric.Value = 215;
				}
				updatingElement = false;
				
				PushFhssTable();
			}
		}
		
		// +==============================+
		// |     Radio Mode Combobox      |
		// +==============================+
		private void PushRadioMode()
		{
			if (RadioModeCombobox.SelectedIndex == 4) //Custom
			{
				byte[] payload = { 0x07, (byte)(SpreadingFactorCombobox.SelectedIndex+1), (byte)(BandwidthCombobox.SelectedIndex+1) };
				this.port.PushTxCommand(SureCmd.SetRadioMode, payload);
			}
			else
			{
				byte[] payload = { (byte)(RadioModeCombobox.SelectedIndex+1) };
				this.port.PushTxCommand(SureCmd.SetRadioMode, payload);
			}
		}
		private void RadioModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (RadioModeCombobox.SelectedIndex == 4) //Custom
				{
					SpreadingFactorCombobox.Enabled = true;
					BandwidthCombobox.Enabled = true;
				}
				else
				{
					SpreadingFactorCombobox.Enabled = false;
					BandwidthCombobox.Enabled = false;
				}
				
				PushRadioMode();
			}
		}
		private void SpreadingFactorCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushRadioMode();
			}
		}
		private void BandwidthCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushRadioMode();
			}
		}
		
		// +==============================+
		// |     Num Retries Combobox     |
		// +==============================+
		private void PushNumRetries()
		{
			byte[] payload = { (byte)NumRetriesNumeric.Value };
			this.port.PushTxCommand(SureCmd.SetNumRetries, payload);
		}
		private void NumRetriesNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				updatingElement = true;
				if (NumRetriesNumeric.Value < 0)
				{
					NumRetriesNumeric.Value = 0;
				}
				if (NumRetriesNumeric.Value >= 216)
				{
					NumRetriesNumeric.Value = 215;
				}
				updatingElement = false;
				
				PushNumRetries();
			}
		}
		
		// +==============================+
		// |     Acks Enable Checkbox     |
		// +==============================+
		private void PushAcksEnabled()
		{
			byte[] payload = { (byte)(AcksEnabledCheckbox.Checked ? 0x01 : 0x00) };
			this.port.PushTxCommand(SureCmd.SetAcksEnabled, payload);
		}
		private void AcksEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (AcksEnabledCheckbox.Checked)
				{
					NumRetriesNumeric.Enabled = true;
				}
				else
				{
					NumRetriesNumeric.Enabled = false;
				}
				
				PushAcksEnabled();
			}
		}
		
		// +==============================+
		// |     Quiet Mode Checkbox      |
		// +==============================+
		private void PushQuietModeEnabled()
		{
			byte[] payload = { (byte)(QuietModeCheckbox.Checked ? 0x01 : 0x00) };
			this.port.PushTxCommand(SureCmd.SetQuietMode, payload);
		}
		private void QuietModeCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushQuietModeEnabled();
			}
		}
		
		// +--------------------------------------------------------------+
		// |                          Lower Area                          |
		// +--------------------------------------------------------------+
		// +==============================+
		// |  Transmit UI Element Events  |
		// +==============================+
		public void PushTransmit()
		{
			int payloadSize = (int)PayloadSizeNumeric.Value;
			byte[] payload = null;
			if (TxHexCheckbox.Checked)
			{
				if (TryParseHexString(TxTextbox.Text, out payload))
				{
					if (payload.Length < payloadSize)
					{
						payload = null;
					}
				}
				else
				{
					payload = null;
				}
			}
			else
			{
				payload = Encoding.ASCII.GetBytes(TxTextbox.Text);
			}
			
			bool sentCommand = false;
			if (payload != null)
			{
				if (payload.Length < payloadSize)
				{
					byte[] paddedPayload = new byte[payloadSize];
					for (int bIndex = 0; bIndex < payloadSize; bIndex++)
					{
						if (bIndex < payload.Length) { paddedPayload[bIndex] = payload[bIndex]; }
						else { paddedPayload[bIndex] = 0x00; }
					}
					port.PushTxCommand(SureCmd.TransmitData, paddedPayload);
					TxTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					sentCommand = true;
				}
				else if (payload.Length == payloadSize)
				{
					port.PushTxCommand(SureCmd.TransmitData, payload);
					TxTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					sentCommand = true;
				}
				else
				{
					TxTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
			}
			else
			{
				TxTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
			
			if (sentCommand)
			{
				TransmitButton.Text = "Sending Cmd";
				TransmitButton.Enabled = false;
			}
		}
		private void TxHexCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				TxTextbox.Clear();
			}
		}
		private void TxTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				int payloadSize = (int)PayloadSizeNumeric.Value;
				if (TxHexCheckbox.Checked)
				{
					//Keep them from typing in too long of a payload
					if (TxTextbox.Text.Length > payloadSize*2)
					{
						updatingElement = true;
						
						int selectionPos = TxTextbox.SelectionStart;
						TxTextbox.Text = TxTextbox.Text.Substring(0, payloadSize*2);
						if (selectionPos > TxTextbox.Text.Length) { selectionPos = TxTextbox.Text.Length; }
						TxTextbox.SelectionStart = selectionPos;
						TxTextbox.SelectionLength = 0;
						
						updatingElement = false;
					}
					
					byte[] hexValues = null;
					if (TryParseHexString(TxTextbox.Text, out hexValues))
					{
						TxLengthLabel.Text = "Length: " + hexValues.Length.ToString() + " / " + payloadSize.ToString();
						
						if (hexValues.Length == 0)
						{
							TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
						}
						else if (hexValues.Length == payloadSize)
						{
							TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
						}
						else
						{
							TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
						}
					}
					else
					{
						TxLengthLabel.Text = "Length: ? / " + payloadSize.ToString();
						TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
					}
				}
				else
				{
					if (TxTextbox.Text.Length > payloadSize)
					{
						updatingElement = true;
						
						int selectionPos = TxTextbox.SelectionStart;
						TxTextbox.Text = TxTextbox.Text.Substring(0, payloadSize);
						if (selectionPos > TxTextbox.Text.Length) { selectionPos = TxTextbox.Text.Length; }
						TxTextbox.SelectionStart = selectionPos;
						TxTextbox.SelectionLength = 0;
						
						updatingElement = false;
					}
					
					byte[] hexValues = Encoding.ASCII.GetBytes(TxTextbox.Text);
					TxLengthLabel.Text = "Length: " + hexValues.Length.ToString() + " / " + payloadSize.ToString();
					
					if (hexValues.Length <= payloadSize)
					{
						TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					}
					else
					{
						TxLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
					}
				}
				
				TxTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
		}
		private void TransmitButton_Click(object sender, EventArgs e)
		{
			PushTransmit();
		}
		private void TxTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && TransmitButton.Enabled)
			{
				PushTransmit();
			}
		}
		
		// +==============================+
		// |    Ack UI Element Events     |
		// +==============================+
		private void AckHexCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				AckTextbox.Clear();
			}
		}
		private void AckClearButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				AckTextbox.Clear();
				AckCountLabel.Text = "Count: 0";
				//NOTE: Because there is no clear button for Tx we will just clear it here
				TxCountLabel.Text = "Count: 0";
			}
		}
		
		// +==============================+
		// |  Ack Data UI Element Events  |
		// +==============================+
		private bool ackDataChanged = false;
		public void PushAckDataChange()
		{
			int payloadSize = (int)PayloadSizeNumeric.Value;
			byte[] ackData = null;
			if (AckDataHexCheckbox.Checked)
			{
				if (AckDataTextbox.Text.Length == 0)
				{
					ackData = new byte[0];
				}
				else if (TryParseHexString(AckDataTextbox.Text, out ackData))
				{
					if (ackData.Length < payloadSize)
					{
						ackData = null;
					}
				}
				else
				{
					ackData = null;
				}
			}
			else
			{
				ackData = Encoding.ASCII.GetBytes(AckDataTextbox.Text);
			}
			
			if (ackData != null)
			{
				if (ackData.Length == 0)
				{
					port.PushTxCommandNoBytes(SureCmd.SetAckData);
					AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else if (ackData.Length < payloadSize)
				{
					byte[] paddedAckData = new byte[payloadSize];
					for (int bIndex = 0; bIndex < payloadSize; bIndex++)
					{
						if (bIndex < ackData.Length) { paddedAckData[bIndex] = ackData[bIndex]; }
						else { paddedAckData[bIndex] = 0x00; }
					}
					port.PushTxCommand(SureCmd.SetAckData, paddedAckData);
					AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else if (ackData.Length == payloadSize)
				{
					port.PushTxCommand(SureCmd.SetAckData, ackData);
					AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
			}
			else
			{
				AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
		}
		private void AckDataHexCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				AckDataTextbox.Clear();
			}
		}
		private void AckDataTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				int payloadSize = (int)PayloadSizeNumeric.Value;
				if (AckDataHexCheckbox.Checked)
				{
					//Keep them from typing in too long of a payload
					if (AckDataTextbox.Text.Length > payloadSize*2)
					{
						updatingElement = true;
						
						int selectionPos = AckDataTextbox.SelectionStart;
						AckDataTextbox.Text = AckDataTextbox.Text.Substring(0, payloadSize*2);
						if (selectionPos > AckDataTextbox.Text.Length) { selectionPos = AckDataTextbox.Text.Length; }
						AckDataTextbox.SelectionStart = selectionPos;
						AckDataTextbox.SelectionLength = 0;
						
						updatingElement = false;
					}
					
					byte[] hexValues = null;
					if (TryParseHexString(AckDataTextbox.Text, out hexValues))
					{
						AckDataLengthLabel.Text = "Length: " + hexValues.Length.ToString() + " / " + payloadSize.ToString();
						
						if (hexValues.Length == 0)
						{
							AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
						}
						else if (hexValues.Length == payloadSize)
						{
							AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
						}
						else
						{
							AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
						}
					}
					else
					{
						AckDataLengthLabel.Text = "Length: ? / " + payloadSize.ToString();
						AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
					}
				}
				else
				{
					//Keep them from typing in too long of a payload
					if (AckDataTextbox.Text.Length > payloadSize)
					{
						updatingElement = true;
						
						int selectionPos = AckDataTextbox.SelectionStart;
						AckDataTextbox.Text = AckDataTextbox.Text.Substring(0, payloadSize);
						if (selectionPos > AckDataTextbox.Text.Length) { selectionPos = AckDataTextbox.Text.Length; }
						AckDataTextbox.SelectionStart = selectionPos;
						AckDataTextbox.SelectionLength = 0;
						
						updatingElement = false;
					}
					
					byte[] hexValues = Encoding.ASCII.GetBytes(AckDataTextbox.Text);
					AckDataLengthLabel.Text = "Length: " + hexValues.Length.ToString() + " / " + payloadSize.ToString();
					
					if (hexValues.Length <= payloadSize)
					{
						AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					}
					else
					{
						AckDataLengthLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
					}
				}
				
				AckDataTextbox.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
				ackDataChanged = true;
			}
		}
		private void AckDataTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ackDataChanged = false;
				PushAckDataChange();
			}
		}
		private void AckDataTextbox_Leave(object sender, EventArgs e)
		{
			if (ackDataChanged)
			{
				ackDataChanged = false;
				PushAckDataChange();
			}
		}
		
		// +==============================+
		// |  Receive UI Element Events   |
		// +==============================+
		private void RxHexCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				RxTextbox.Clear();
			}
		}
		private void RxClearButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				RxTextbox.Clear();
				RxCountLabel.Text = "Count: 0";
			}
		}
		
		// +--------------------------------------------------------------+
		// |                      Other Settings Tab                      |
		// +--------------------------------------------------------------+
		
		// +==============================+
		// |  Indication Combobox Events  |
		// +==============================+
		private byte[] indications = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		public void PushIndications(bool labelsOnly)
		{
			byte[] newIndications = {
				(byte)LedCombo1.SelectedIndex,
				(byte)LedCombo2.SelectedIndex,
				(byte)LedCombo3.SelectedIndex,
				(byte)LedCombo4.SelectedIndex,
				(byte)LedCombo5.SelectedIndex,
				(byte)LedCombo6.SelectedIndex,
			};
			
			if (newIndications[0] != indications[0] ||
				newIndications[1] != indications[1] ||
				newIndications[2] != indications[2] ||
				newIndications[3] != indications[3] ||
				newIndications[4] != indications[4] ||
				newIndications[5] != indications[5])
			{
				if (!labelsOnly)
				{
					byte[] payload = {
						(byte)((newIndications[0] & 0x0F) + (newIndications[1] << 4)),
						(byte)((newIndications[2] & 0x0F) + (newIndications[3] << 4)),
						(byte)((newIndications[4] & 0x0F) + (newIndications[5] << 4)),
					};
					this.port.PushTxCommand(SureCmd.SetIndications, payload);
				}
				
				LedLabel1.Text = newIndications[0].ToString();
				if (newIndications[0] == 0x00)
				{
					LedLabel1.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel1.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel1.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel1.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				LedLabel2.Text = newIndications[1].ToString();
				if (newIndications[1] == 0x00)
				{
					LedLabel2.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel2.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel2.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel2.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				LedLabel3.Text = newIndications[2].ToString();
				if (newIndications[2] == 0x00)
				{
					LedLabel3.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel3.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel3.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel3.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				LedLabel4.Text = newIndications[3].ToString();
				if (newIndications[3] == 0x00)
				{
					LedLabel4.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel4.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel4.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel4.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				LedLabel5.Text = newIndications[4].ToString();
				if (newIndications[4] == 0x00)
				{
					LedLabel5.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel5.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel5.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel5.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				LedLabel6.Text = newIndications[5].ToString();
				if (newIndications[5] == 0x00)
				{
					LedLabel6.BackColor = Color.FromKnownColor(KnownColor.Transparent);
					LedLabel6.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				}
				else
				{
					LedLabel6.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
					LedLabel6.ForeColor = Color.FromKnownColor(KnownColor.Control);
				}
				
				indications[0] = newIndications[0];
				indications[1] = newIndications[1];
				indications[2] = newIndications[2];
				indications[3] = newIndications[3];
				indications[4] = newIndications[4];
				indications[5] = newIndications[5];
			}
		}
		private void LedCombo1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void LedCombo2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void LedCombo3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void LedCombo4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void LedCombo5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void LedCombo6_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushIndications(false);
			}
		}
		private void ClearIndicationsButton_Click(object sender, EventArgs e)
		{
			this.updatingElement = true;
			LedCombo1.SelectedIndex = 0;
			LedCombo2.SelectedIndex = 0;
			LedCombo3.SelectedIndex = 0;
			LedCombo4.SelectedIndex = 0;
			LedCombo5.SelectedIndex = 0;
			LedCombo6.SelectedIndex = 0;
			this.updatingElement = false;
			
			PushIndications(false);
		}
		
		// +==============================+
		// |  QOS Config Combobox Events  |
		// +==============================+
		private void PushQosConfig()
		{
			byte[] payload = { (byte)(0x01 + QosConfigCombobox.SelectedIndex) };
			this.port.PushTxCommand(SureCmd.SetQosConfig, payload);
		}
		private void QosConfigCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushQosConfig();
			}
		}
		
		// +====================================+
		// | Button Config and Hold Time Events |
		// +====================================+
		private void PushButtonConfig()
		{
			byte configValue = (byte)((0x01 + ButtonConfigCombobox.SelectedIndex) & 0x0F);
			configValue += (byte)(((byte)ButtonHoldTimeNumeric.Value & 0x0F) << 4);
			byte[] payload = { configValue };
			this.port.PushTxCommand(SureCmd.SetButtonConfig, payload);
		}
		private void ButtonHoldTimeNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				this.updatingElement = true;
				if (ButtonHoldTimeNumeric.Value < 1)  { ButtonHoldTimeNumeric.Value = 1;  }
				if (ButtonHoldTimeNumeric.Value > 15) { ButtonHoldTimeNumeric.Value = 15; }
				this.updatingElement = false;
				
				PushButtonConfig();
			}
		}
		private void ButtonConfigCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushButtonConfig();
			}
		}
		
		// +====================================+
		// | Rx and Tx Led Mode Combobox Events |
		// +====================================+
		private void PushConfigByte()
		{
			byte newValue = 0x00;
			if (RxLedModeCombobox.SelectedIndex > 0) { newValue += SureFi.ConfigFlags_RxLedModeBit; }
			if (TxLedModeCombobox.SelectedIndex > 0) { newValue += SureFi.ConfigFlags_TxLedModeBit; }
			if (AutoClearFlagsCheckbox.Checked)      { newValue += SureFi.ConfigFlags_AutoClearFlagsBit; }
			byte[] payload = { newValue };
			this.port.PushTxCommand(SureCmd.WriteConfig, payload);
		}
		private void RxLedModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushConfigByte();
			}
		}
		private void TxLedModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushConfigByte();
			}
		}
		
		// +--------------------------------------------------------------+
		// |                          Status Tab                          |
		// +--------------------------------------------------------------+
		private void AutoClearFlagsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (AutoClearFlagsCheckbox.Checked)
				{
					ClearFlagsButton.Enabled = false;
				}
				else
				{
					ClearFlagsButton.Enabled = true;
				}
				PushConfigByte();
			}
		}
		
		private void ClearFlagsButton_Click(object sender, EventArgs e)
		{
			byte[] payload = { 0xFF };
			this.port.PushTxCommand(SureCmd.ClearStatusFlags, payload);
		}
		
		private void GetStatusButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.GetStatus);
		}
		
		// +--------------------------------------------------------------+
		// |                         Commands Tab                         |
		// +--------------------------------------------------------------+
		private void RefreshSettingsButton_Click(object sender, EventArgs e)
		{
			SureFi.ClearGotFlags();
			this.port.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetTransmitUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetRadioMode);
			this.port.PushTxCommandNoBytes(SureCmd.GetAllSettings);
			this.port.PushTxCommandNoBytes(SureCmd.GetAckData);
		}
		private void DefaultSettingsButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.DefaultSettings);
			SureFi.ClearGotFlags();
			this.port.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetTransmitUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetRadioMode);
			this.port.PushTxCommandNoBytes(SureCmd.GetAllSettings);
			this.port.PushTxCommandNoBytes(SureCmd.GetAckData);
		}
		private void SleepButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.Sleep);
		}
		private void ResetButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.Reset);
		}
		private void LightshowButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.QosLightshow);
		}
		private void ShowQosButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.ShowQualityOfService);
		}
		private void StartEncryptionButton_Click(object sender, EventArgs e)
		{
			if ((savedStateFlags & SureFi.StateFlags_EncryptionActiveBit) != 0)
			{
				this.port.PushTxCommandNoBytes(SureCmd.StopEncryption);
			}
			else
			{
				this.port.PushTxCommandNoBytes(SureCmd.StartEncryption);
			}
		}
		private void GetModuleVersionButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.GetModuleVersion);
		}
		private void GetTimeOnAirButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.GetPacketTimeOnAir);
		}
		private void GetRandomNumberButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.GetRandomNumber);
		}
	}
}
