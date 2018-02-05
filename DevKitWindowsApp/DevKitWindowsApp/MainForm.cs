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
		
		bool TryParseHexString(string hexString, out byte[] bytesOut)
		{
			if (hexString.Length < 2) { bytesOut = null; return false; }
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
				ReportConnectionResult(true, "");
				StatusUpdate("Connected to " + portName + "!");
			}
			else
			{
				ReportConnectionResult(false, this.port.connectFailureString);
			}
			
			this.OutputTextbox.Text = "";
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
				
				List<byte> newCommand = this.port.PopRxCommand();
				while (newCommand != null)
				{
					// Console.Write("Got " + newCommand.Count.ToString() + " byte command { ");
					// foreach (byte b in newCommand)
					// {
					// 	Console.Write(b.ToString("X2") + " ");
					// }
					// Console.WriteLine("}");
					SureFi.ProcessResponse(this, newCommand);
					
					newCommand = this.port.PopRxCommand();
				}
			}
		}
		
		// +==============================+
		// |        Control Events        |
		// +==============================+
		
		private void DisconnectButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.connectForm.Show();
			this.Close();
		}
		
		private void HumanReadableCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			this.OutputTextbox.Clear();
		}
		
		private void LedCombo6_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LedCombo6.SelectedIndex == 0)
			{
				LedLabel6.BackColor = Color.FromKnownColor(KnownColor.Transparent);
				LedLabel6.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
			else
			{
				LedLabel6.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
				LedLabel6.ForeColor = Color.FromKnownColor(KnownColor.Control);
			}
			LedLabel6.Text = LedCombo6.SelectedIndex.ToString();
		}
		
		private void AutoClearFlagsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (AutoClearFlagsCheckbox.Checked)
			{
				ClearFlagsButton.Enabled = false;
				AutoClearFlagsBit.Text = "1";
				AutoClearFlagsBit.BackColor = Color.FromKnownColor(KnownColor.OrangeRed);
				AutoClearFlagsBit.ForeColor = Color.FromKnownColor(KnownColor.Control);
			}
			else
			{
				ClearFlagsButton.Enabled = true;
				AutoClearFlagsBit.Text = "0";
				AutoClearFlagsBit.BackColor = Color.FromKnownColor(KnownColor.Transparent);
				AutoClearFlagsBit.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
		}
		
		// +==============================+
		// |        Rx UID Textbox        |
		// +==============================+
		private bool rxUidChanged = false;
		private void PushRxUidChange()
		{
			byte[] payload = null;
			if (TryParseHexString(RxUidTextbox.Text, out payload))
			{
				port.PushTxCommand(SureCmd.SetReceiveUID, payload);
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
				PushRxUidChange();
			}
		}
		private void RxUidTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)// && rxUidChanged)
			{
				rxUidChanged = false;
				PushRxUidChange();
			}
		}
		
		// +==============================+
		// |        Tx UID Textbox        |
		// +==============================+
		private bool txUidChanged = false;
		private void PushTxUidChange()
		{
			byte[] payload = null;
			if (TryParseHexString(TxUidTextbox.Text, out payload))
			{
				port.PushTxCommand(SureCmd.SetTransmitUID, payload);
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
				PushTxUidChange();
			}
		}
		
		private void TxUidTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)// && txUidChanged)
			{
				txUidChanged = false;
				PushTxUidChange();
			}
		}
	}
}
