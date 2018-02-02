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
		// SerialPort port;
		// string portName;
		
		public delegate void ConnectionResultHandler(object sender, bool success, string message);
		public event ConnectionResultHandler OnConnectionFinished;
		
		void ReportConnectionResult(bool success, string message)
		{
			Console.WriteLine("Connection " + (success ? "Succeeded" : "Failed") + "!");
			
			OnConnectionFinished(this, success, message);
			
			if (!success) { this.Close(); }
		}
		
		// +==============================+
		// |       Helper Functions       |
		// +==============================+
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
	}
}
