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
		byte savedBleFlags = 0x00;
		
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
		
		public void StatusUpdate(string statusMessage)
		{
			StatusLabel.Text = statusMessage;
		}
		
		public void ShowErrorMesage(string title, string message, string errorString)
		{
			MessageBox.Show(this, message + "\r\n\r\n" + errorString, title, MessageBoxButtons.OK);
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
				if (bit == 0x20) { bitLabel = this.ChangingTablesBit;   }
				if (bit == 0x40) { bitLabel = this.RxInProgressBit;     }
				if (bit == 0x80) { bitLabel = this.OnBaseTableBit;      }
			}
			if (statusByte == 1)
			{
				if (bit == 0x01) { bitLabel = this.DoingLightshowBit;   }
				if (bit == 0x02) { bitLabel = this.ShowingQosBit;       }
				if (bit == 0x04) { bitLabel = this.ButtonDownBit;       }
				if (bit == 0x08) { bitLabel = this.EncryptionActiveBit; }
				if (bit == 0x10) { bitLabel = this.SettingsPendingBit;  }
				if (bit == 0x20) { bitLabel = this.RxLedOnBit;          }
				if (bit == 0x40) { bitLabel = this.TxLedOnBit;          }
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
				if (bit == 0x20) { bitLabel = this.RxTxLedsManualBit;  }
			}
			
			string newText = filled ? "1" : "0";
			if (bitLabel != null && bitLabel.Text != newText)
			{
				bitLabel.Text = newText;
				bitLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.DeepSkyBlue : KnownColor.Transparent);
				bitLabel.ForeColor = Color.FromKnownColor(filled ? KnownColor.Control : KnownColor.ControlText);
				
				if (bitLabel == this.RxLedOnBit)
				{
					this.RxLedOnLabel.Text = bitLabel.Text;
					this.RxLedOnLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.Red : KnownColor.Transparent);
					this.RxLedOnLabel.ForeColor = bitLabel.ForeColor;
				}
				else if (bitLabel == this.TxLedOnBit)
				{
					this.TxLedOnLabel.Text = bitLabel.Text;
					this.TxLedOnLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.Orange : KnownColor.Transparent);
					this.TxLedOnLabel.ForeColor = bitLabel.ForeColor;
				}
			}
		}
		
		public void SetIntEnableBit(int statusByte, byte bit, bool filled)
		{
			Label bitLabel = null;
			if (statusByte == 0)
			{
				if (bit == 0x01) { bitLabel = this.IntRadioStateBit1;      }
				if (bit == 0x02) { bitLabel = this.IntRadioStateBit2;      }
				if (bit == 0x04) { bitLabel = this.IntRadioStateBit3;      }
				if (bit == 0x08) { bitLabel = this.IntRadioStateBit4;      }
				if (bit == 0x10) { bitLabel = this.IntBusyBit;             }
				if (bit == 0x20) { bitLabel = this.IntChangingTablesBit;   }
				if (bit == 0x40) { bitLabel = this.IntRxInProgressBit;     }
				if (bit == 0x80) { bitLabel = this.IntOnBaseTableBit;      }
			}
			if (statusByte == 1)
			{
				if (bit == 0x01) { bitLabel = this.IntDoingLightshowBit;   }
				if (bit == 0x02) { bitLabel = this.IntShowingQosBit;       }
				if (bit == 0x04) { bitLabel = this.IntButtonDownBit;       }
				if (bit == 0x08) { bitLabel = this.IntEncryptionActiveBit; }
				if (bit == 0x10) { bitLabel = this.IntSettingsPendingBit;  }
				if (bit == 0x20) { bitLabel = this.IntRxLedOnBit;          }
				if (bit == 0x40) { bitLabel = this.IntTxLedOnBit;          }
			}
			if (statusByte == 2)
			{
				if (bit == 0x01) { bitLabel = this.IntWasResetBit;         }
				if (bit == 0x02) { bitLabel = this.IntTransmitFinishedBit; }
				if (bit == 0x04) { bitLabel = this.IntRxPacketReadyBit;    }
				if (bit == 0x08) { bitLabel = this.IntAckPacketReadyBit;   }
				if (bit == 0x10) { bitLabel = this.IntChecksumErrorBit;    }
				if (bit == 0x20) { bitLabel = this.IntEncryptionRekeyBit;  }
				if (bit == 0x40) { bitLabel = this.IntButtonPressedBit;    }
				if (bit == 0x80) { bitLabel = this.IntButtonHeldBit;       }
			}
			if (statusByte == 3)
			{
				if (bit == 0x01) { bitLabel = this.IntInterruptDrivenBit; }
				if (bit == 0x02) { bitLabel = this.IntAutoClearFlagsBit;  }
				if (bit == 0x04) { bitLabel = this.IntRxLedModeBit;       }
				if (bit == 0x08) { bitLabel = this.IntTxLedModeBit;       }
				if (bit == 0x10) { bitLabel = this.IntAutoRekeyBit;       }
				if (bit == 0x20) { bitLabel = this.IntRxTxLedsManualBit;  }
			}
			
			string newText = filled ? "E" : "D";
			if (bitLabel != null && bitLabel.Text != newText)
			{
				bitLabel.Text = newText;
				bitLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.DeepSkyBlue : KnownColor.Transparent);
				bitLabel.ForeColor = Color.FromKnownColor(filled ? KnownColor.Control : KnownColor.ControlText);
			}
		}
		
		public void SetBleStatusBit(byte bit, bool filled)
		{
			Label bitLabel = null;
			if (bit == 0x01) { bitLabel = this.BleWasResetBit; }
			if (bit == 0x02) { bitLabel = this.BleConnectedBit; }
			if (bit == 0x04) { bitLabel = this.BleAdvertisingBit; }
			if (bit == 0x08) { bitLabel = this.BleInDfuModeBit; }
			if (bit == 0x10) { bitLabel = this.BleSureFiTxInProgressBit; }
			if (bit == 0x20) { bitLabel = this.BleConnectionAttemptedBit; }
			// if (bit == 0x40) { bitLabel = this.Bit; }
			// if (bit == 0x80) { bitLabel = this.Bit; }
			
			string newText = filled ? "1" : "0";
			if (bitLabel != null && bitLabel.Text != newText)
			{
				bitLabel.Text = newText;
				bitLabel.BackColor = Color.FromKnownColor(filled ? KnownColor.DeepSkyBlue : KnownColor.Transparent);
				bitLabel.ForeColor = Color.FromKnownColor(filled ? KnownColor.Control : KnownColor.ControlText);
			}
		}
		
		public void SetBleIntEnableBit(byte bit, bool filled)
		{
			Label bitLabel = null;
			if (bit == 0x01) { bitLabel = this.BleIntWasResetBit; }
			if (bit == 0x02) { bitLabel = this.BleIntConnectedBit; }
			if (bit == 0x04) { bitLabel = this.BleIntAdvertisingBit; }
			if (bit == 0x08) { bitLabel = this.BleIntInDfuModeBit; }
			if (bit == 0x10) { bitLabel = this.BleIntSureFiTxInProgressBit; }
			if (bit == 0x20) { bitLabel = this.BleIntConnectionAttemptedBit; }
			// if (bit == 0x40) { bitLabel = this.Bit; }
			// if (bit == 0x80) { bitLabel = this.Bit; }
			
			string newText = filled ? "E" : "D";
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
				if (responseBytes[0] == 0x7E)
				{
					commandStr = SureFi.GetHumanReadableResponseStr(responseBytes);
				}
				else if (responseBytes[0] == 0x7C)
				{
					commandStr = SureFi.GetHumanReadableBleResponseStr(responseBytes);
				}
			}
			else
			{
				if (responseBytes[0] == 0x7E)
				{
					commandStr = SureFi.GetResponseStr(responseBytes);
				}
				else if (responseBytes[0] == 0x7C)
				{
					commandStr = SureFi.GetBleResponseStr(responseBytes);
				}
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
				if (commandBytes[0] == 0x7E)
				{
					commandStr = SureFi.GetHumanReadableCommandStr(commandBytes);
				}
				else if (commandBytes[0] == 0x7C)
				{
					commandStr = SureFi.GetHumanReadableBleCommandStr(commandBytes);
				}
			}
			else
			{
				if (commandBytes[0] == 0x7E)
				{
					commandStr = SureFi.GetCommandStr(commandBytes);
				}
				else if (commandBytes[0] == 0x7C)
				{
					commandStr = SureFi.GetBleCommandStr(commandBytes);
				}
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
			ShowErrorMesage("Command Failed", "SureCmd_" + cmd.ToString() + " Failed", "Error: " + error.ToString());
			
			if (cmd == SureCmd.TransmitData)
			{
				TransmitButton.Text = "Transmit";
				TransmitButton.Enabled = true;
			}
		}
		
		public void HandleStatusUpdate(byte stateFlags, byte otherFlags, byte clearableFlags, byte configFlags)
		{
			//perform an XOR to find which bits have changed since last update
			byte stateChanged     = (byte)(stateFlags     ^ this.savedStateFlags);
			byte otherChanged     = (byte)(otherFlags     ^ this.savedOtherFlags);
			byte clearableChanged = (byte)(clearableFlags ^ this.savedClearableFlags);
			byte configChanged    = (byte)(configFlags    ^ this.savedConfigFlags);
			
			// Console.WriteLine("Change:" +
			// 	" state 0x" + stateChanged.ToString("X2") +
			// 	" other 0x" + otherChanged.ToString("X2") +
			// 	" clear 0x" + clearableChanged.ToString("X2") +
			// 	" confg 0x" + configChanged.ToString("X2"));
			
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
			
			if ((otherChanged & SureFi.OtherFlags_EncryptionActiveBit) != 0)
			{
				if ((otherFlags & SureFi.OtherFlags_EncryptionActiveBit) != 0)
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
				this.port.PushTxCommandNoBytes(SureCmd.GetIntEnableBits);
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
				this.port.PushTxCommand(SureCmd.ClearFlags, payload);
			}
			
			this.savedStateFlags     = stateFlags;
			this.savedOtherFlags     = otherFlags;
			this.savedClearableFlags = clearableFlags;
			this.savedConfigFlags    = configFlags;
			
			if ((configFlags & SureFi.ConfigFlags_AutoClearFlagsBit) != 0)
			{
				//If autoClearFlags is enabled then we can assume the Clearable Flags byte was cleared
				this.savedClearableFlags = 0x00;
			}
		}
		
		public void HandleBleSuccessResponse(BleCmd cmd)
		{
			//TODO: Handle any specific Success responses?
		}
		public void HandleBleFailureResponse(BleCmd cmd, BleError error)
		{
			ShowErrorMesage("Command Failed", "BleCmd_" + cmd.ToString() + " Failed", "Error: " + error.ToString());
			
			if (cmd == BleCmd.SetAdvertisingName)
			{
				BleAdvertisingNameTextbox.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
		}
		
		public void HandleBleStatusUpdate(byte bleFlags)
		{
			//perform an XOR to find which bits have changed since last update
			byte bleChanged = (byte)(bleFlags ^ this.savedBleFlags);
			
			if ((bleChanged & SureFi.BleFlags_WasResetBit) != 0 &&
				(bleFlags & SureFi.BleFlags_WasResetBit) != 0)
			{
				Console.WriteLine("BLE was reset. Getting all settings again");
				SureFi.ClearBleGotFlags();
				this.port.PushBleTxCommandNoBytes(BleCmd.ClearResetFlag);
				
				this.port.PushBleTxCommandNoBytes(BleCmd.GetFirmwareVersion);
				this.port.PushBleTxCommandNoBytes(BleCmd.GetStatusUpdateBits);
				this.port.PushBleTxCommandNoBytes(BleCmd.GetAdvertisingData);
				this.port.PushBleTxCommandNoBytes(BleCmd.GetAdvertisingName);
				this.port.PushBleTxCommandNoBytes(BleCmd.GetTemporaryData);
				this.port.PushBleTxCommandNoBytes(BleCmd.GetRejectConnections);
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 3 });
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 4 });
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 5 });
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 6 });
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 25 });
				this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 28 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 3 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 4 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 5 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 6 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 25 });
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 28 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 3 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 4 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 5 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 6 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 25 });
				this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 28 });
			}
			
			this.savedBleFlags = bleFlags;
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
			this.port.PushTxCommandNoBytes(SureCmd.GetIntEnableBits);
			this.port.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetTransmitUID);
			this.port.PushTxCommandNoBytes(SureCmd.GetRadioMode);
			this.port.PushTxCommandNoBytes(SureCmd.GetAllSettings);
			this.port.PushTxCommandNoBytes(SureCmd.GetAckData);
			
			SureFi.ClearBleGotFlags();
			this.port.PushBleTxCommandNoBytes(BleCmd.GetFirmwareVersion);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetStatus);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetStatusUpdateBits);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetAdvertisingData);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetAdvertisingName);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetTemporaryData);
			this.port.PushBleTxCommandNoBytes(BleCmd.GetRejectConnections);
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 3 });
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 4 });
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 5 });
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 6 });
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 25 });
			this.port.PushBleTxCommand(BleCmd.GetGpioConfiguration, new byte[]{ 28 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 3 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 4 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 5 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 6 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 25 });
			this.port.PushBleTxCommand(BleCmd.GetGpioValue, new byte[]{ 28 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 3 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 4 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 5 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 6 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 25 });
			this.port.PushBleTxCommand(BleCmd.GetGpioUpdateEnabled, new byte[]{ 28 });
			
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
					if (newCommand[0] == 0x7E)
					{
						SureFi.ProcessResponse(this, newCommand);
					}
					else if (newCommand[0] == 0x7C)
					{
						SureFi.ProcessBleResponse(this, newCommand);
					}
					else
					{
						//This really shouldn't happen
						Console.WriteLine("Unknown ATTN character on popped command");
					}
					
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
			bool acksEnabledGood = AcksEnabledCheckbox.Checked;
			bool payloadSizeGood = (PayloadSizeNumeric.Value > 0);
			
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
					((packetSize+2) % 16) == 0)
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
			else if (!payloadSizeGood)
			{
				EncryptionReadyLabel.Text = "X Encryption: Need at least 1 byte Payload";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
			else if (!packetSizeGood)
			{
				EncryptionReadyLabel.Text = "X Encryption: ReceivePacketSize+2 is not multiple of 16";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
			}
			else if (!acksEnabledGood)
			{
				EncryptionReadyLabel.Text = "X Encryption: Acks are Not Enabled";
				EncryptionReadyLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
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
				e.SuppressKeyPress = true;
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
				e.SuppressKeyPress = true;
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
			byte[] rxUid = null;
			if (TryParseHexString(RxUidTextbox.Text, out rxUid))
			{
				int packetSize = rxUid.Length;
				packetSize += (int)PayloadSizeNumeric.Value;
				int radioPacketSize = packetSize + 2;
				
				if (packetSize > 0 && packetSize <= 64)
				{
					RxPacketSizeLabel.Text = radioPacketSize.ToString() + " bytes (ReceivePacketSize = " + packetSize.ToString() + ")";
					RxPacketSizeLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					
					if (!onlyLabel)
					{
						byte[] payload = { (byte)packetSize };
						port.PushTxCommand(SureCmd.SetReceivePacketSize, payload);
					}
				}
				else
				{
					RxPacketSizeLabel.Text = radioPacketSize.ToString() + " bytes (ReceivePacketSize = " + packetSize.ToString() + ")";
					RxPacketSizeLabel.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
				}
				
			}
			else
			{
				RxPacketSizeLabel.Text = "? bytes (ReceivePacketSize = ?)";
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
				UpdateEncryptionReady();
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
		
		// +==============================+
		// |    Table Hopping Checkbox    |
		// +==============================+
		private void PushTableHoppingEnabled()
		{
			byte[] payload = { (byte)(TableHoppingCheckbox.Checked ? 0x01 : 0x00) };
			this.port.PushTxCommand(SureCmd.SetTableHoppingEnabled, payload);
		}
		private void TableHoppingCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushTableHoppingEnabled();
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
				TxTextbox.Focus();
				TxTextbox.Clear();
				TxLengthLabel.Text = "Length: 0";
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
				e.SuppressKeyPress = true;
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
				AckTextbox.Focus();
				AckTextbox.Clear();
				AckLengthLabel.Text = "Length: 0";
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
				AckLengthLabel.Text = "Length: 0";
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
				if (AckDataTextbox.Text.Length == 0)
				{
					ackData = new byte[0];
				}
				else
				{
					ackData = Encoding.ASCII.GetBytes(AckDataTextbox.Text);
				}
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
				AckDataTextbox.Focus();
				AckDataTextbox.Clear();
				AckDataLengthLabel.Text = "Length: 0 / " + PayloadSizeNumeric.Value.ToString();
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
				e.SuppressKeyPress = true;
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
				RxTextbox.Focus();
				RxTextbox.Clear();
				RxLengthLabel.Text = "Length: 0";
			}
		}
		private void RxClearButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				RxTextbox.Clear();
				RxCountLabel.Text = "Count: 0";
				RxLengthLabel.Text = "Length: 0";
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
			if (RxTxLedsManualCheckbox.Checked)      { newValue += SureFi.ConfigFlags_RxTxLedsManualBit; }
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
		private void RxTxLedsManualCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				PushConfigByte();
				if (RxTxLedsManualCheckbox.Checked)
				{
					this.RxLedModeCombobox.Enabled = false;
					this.TxLedModeCombobox.Enabled = false;
					this.RxLedPulseTimeNumeric.Enabled = true;
					this.RxLedPulseButton.Enabled      = true;
					this.RxLedTurnOnButton.Enabled     = true;
					this.TxLedPulseTimeNumeric.Enabled = true;
					this.TxLedPulseButton.Enabled      = true;
					this.TxLedTurnOnButton.Enabled     = true;
				}
				else
				{
					this.RxLedModeCombobox.Enabled = true;
					this.TxLedModeCombobox.Enabled = true;
					this.RxLedPulseTimeNumeric.Enabled = false;
					this.RxLedPulseButton.Enabled      = false;
					this.RxLedTurnOnButton.Enabled     = false;
					this.TxLedPulseTimeNumeric.Enabled = false;
					this.TxLedPulseButton.Enabled      = false;
					this.TxLedTurnOnButton.Enabled     = false;
				}
			}
		}
		private void RxLedPulseButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				byte[] payload = { 0x01, 0x00, 0x00 };
				UInt16 time = (UInt16)this.RxLedPulseTimeNumeric.Value;
				payload[1] = (byte)((time >> 0) & 0xFF);
				payload[2] = (byte)((time >> 8) & 0xFF);
				this.port.PushTxCommand(SureCmd.SetRxLED, payload);
			}
		}
		private void TxLedPulseButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				byte[] payload = { 0x01, 0x00, 0x00 };
				UInt16 time = (UInt16)this.TxLedPulseTimeNumeric.Value;
				payload[1] = (byte)((time >> 0) & 0xFF);
				payload[2] = (byte)((time >> 8) & 0xFF);
				this.port.PushTxCommand(SureCmd.SetTxLED, payload);
			}
		}
		private void RxLedTurnOnButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (this.RxLedOnLabel.Text == "0")
				{
					byte[] payload = { 0x01, 0x00, 0x00 };
					this.port.PushTxCommand(SureCmd.SetRxLED, payload);
				}
				else
				{
					byte[] payload = { 0x00, 0x00, 0x00 };
					this.port.PushTxCommand(SureCmd.SetRxLED, payload);
				}
			}
		}
		private void TxLedTurnOnButton_Click(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (this.TxLedOnLabel.Text == "0")
				{
					byte[] payload = { 0x01, 0x00, 0x00 };
					this.port.PushTxCommand(SureCmd.SetTxLED, payload);
				}
				else
				{
					byte[] payload = { 0x00, 0x00, 0x00 };
					this.port.PushTxCommand(SureCmd.SetTxLED, payload);
				}
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
			this.port.PushTxCommand(SureCmd.ClearFlags, payload);
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
			if ((savedOtherFlags & SureFi.OtherFlags_EncryptionActiveBit) != 0)
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
		private void GetRegisteredSerialButton_Click(object sender, EventArgs e)
		{
			this.port.PushTxCommandNoBytes(SureCmd.GetRegisteredSerial);
		}
		private void GetMacAddressButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.GetMacAddress);
		}
		
		// +--------------------------------------------------------------+
		// |                     Int Enable Bits Tab                      |
		// +--------------------------------------------------------------+
		public byte[] intEnableBits = {0x00, 0x00, 0x00, 0x00};
		private void PushIntEnableBits()
		{
			for (int bIndex = 0; bIndex < 4; bIndex++)
			{
				for (int bitIndex = 0; bitIndex < 8; bitIndex++)
				{
					byte bit = (byte)(0x01 << bitIndex);
					bool isBitSet = (intEnableBits[bIndex] & bit) > 0;
					this.SetIntEnableBit(bIndex, bit, isBitSet);
				}
				
			}
			
			this.IntStateLabel.Text     = "State: 0x"     + intEnableBits[0].ToString("X2");
			this.IntOtherLabel.Text     = "Other: 0x"     + intEnableBits[1].ToString("X2");
			this.IntClearableLabel.Text = "Clearable: 0x" + intEnableBits[2].ToString("X2");
			this.IntConfigLabel.Text    = "Config: 0x"    + intEnableBits[3].ToString("X2");
			
			this.port.PushTxCommand(SureCmd.SetIntEnableBits, intEnableBits);
		}
		private void IntRadioStateBit1_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x01) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x01)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x01); }
			PushIntEnableBits();
		}
		private void IntRadioStateBit2_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x02) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x02)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x02); }
			PushIntEnableBits();
		}
		private void IntRadioStateBit3_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x04) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x04)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x04); }
			PushIntEnableBits();
		}
		private void IntRadioStateBit4_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x08) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x08)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x08); }
			PushIntEnableBits();
		}
		private void IntBusyBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x10) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x10)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x10); }
			PushIntEnableBits();
		}
		private void IntChangingTablesBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x20) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x20)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x20); }
			PushIntEnableBits();
		}
		private void IntRxInProgressBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x40) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x40)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x40); }
			PushIntEnableBits();
		}
		private void IntOnBaseTableBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[0] & 0x80) != 0x00) { intEnableBits[0] = (byte)(intEnableBits[0] & (~0x80)); }
			else { intEnableBits[0] = (byte)(intEnableBits[0] | 0x80); }
			PushIntEnableBits();
		}
		private void IntDoingLightshowBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x01) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x01)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x01); }
			PushIntEnableBits();
		}
		private void IntShowingQosBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x02) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x02)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x02); }
			PushIntEnableBits();
		}
		private void IntButtonDownBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x04) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x04)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x04); }
			PushIntEnableBits();
		}
		private void IntEncryptionActiveBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x08) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x08)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x08); }
			PushIntEnableBits();
		}
		private void IntSettingsPendingBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x10) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x10)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x10); }
			PushIntEnableBits();
		}
		private void IntRxLedOnBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x20) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x20)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x20); }
			PushIntEnableBits();
		}
		private void IntTxLedOnBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[1] & 0x40) != 0x00) { intEnableBits[1] = (byte)(intEnableBits[1] & (~0x40)); }
			else { intEnableBits[1] = (byte)(intEnableBits[1] | 0x40); }
			PushIntEnableBits();
		}
		private void IntWasResetBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x01) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x01)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x01); }
			PushIntEnableBits();
		}
		private void IntTransmitFinishedBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x02) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x02)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x02); }
			PushIntEnableBits();
		}
		private void IntRxPacketReadyBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x04) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x04)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x04); }
			PushIntEnableBits();
		}
		private void IntAckPacketReadyBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x08) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x08)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x08); }
			PushIntEnableBits();
		}
		private void IntChecksumErrorBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x10) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x10)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x10); }
			PushIntEnableBits();
		}
		private void IntEncryptionRekeyBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x20) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x20)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x20); }
			PushIntEnableBits();
		}
		private void IntButtonPressedBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x40) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x40)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x40); }
			PushIntEnableBits();
		}
		private void IntButtonHeldBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[2] & 0x80) != 0x00) { intEnableBits[2] = (byte)(intEnableBits[2] & (~0x80)); }
			else { intEnableBits[2] = (byte)(intEnableBits[2] | 0x80); }
			PushIntEnableBits();
		}
		private void IntInterruptDrivenBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x01) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x01)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x01); }
			PushIntEnableBits();
		}
		private void IntAutoClearFlagsBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x02) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x02)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x02); }
			PushIntEnableBits();
		}
		private void IntRxLedModeBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x04) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x04)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x04); }
			PushIntEnableBits();
		}
		private void IntTxLedModeBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x08) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x08)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x08); }
			PushIntEnableBits();
		}
		private void IntAutoRekeyBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x10) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x10)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x10); }
			PushIntEnableBits();
		}
		private void IntRxTxLedsManualBit_Click(object sender, EventArgs e)
		{
			if ((intEnableBits[3] & 0x20) != 0x00) { intEnableBits[3] = (byte)(intEnableBits[3] & (~0x20)); }
			else { intEnableBits[3] = (byte)(intEnableBits[3] | 0x20); }
			PushIntEnableBits();
		}
		
		private void EnableAllIntButton_Click(object sender, EventArgs e)
		{
			intEnableBits[0] = 0xFF;
			intEnableBits[1] = 0xFF;
			intEnableBits[2] = 0xFF;
			intEnableBits[3] = 0xFF;
			PushIntEnableBits();
		}
		private void DisableAllIntButton_Click(object sender, EventArgs e)
		{
			intEnableBits[0] = 0x00;
			intEnableBits[1] = 0x00;
			intEnableBits[2] = 0x00;
			intEnableBits[3] = 0x00;
			PushIntEnableBits();
		}
		
		// +--------------------------------------------------------------+
		// |                        Bluetooth Tab                         |
		// +--------------------------------------------------------------+
		// +==============================+
		// | Ble Advertising Name Events  |
		// +==============================+
		private bool advertisingNameChanged = false;
		private void PushAdvertisingName()
		{
			byte[] payload = Encoding.ASCII.GetBytes(BleAdvertisingNameTextbox.Text);
			this.port.PushBleTxCommand(BleCmd.SetAdvertisingName, payload);
			BleAdvertisingNameTextbox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			this.advertisingNameChanged = false;
		}
		private void BleAdvertisingNameTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!updatingElement)
			{
				if (BleAdvertisingNameTextbox.Text.Length > 22)
				{
					updatingElement = true;
					int selectionPos = BleAdvertisingNameTextbox.SelectionStart;
					BleAdvertisingNameTextbox.Text = BleAdvertisingNameTextbox.Text.Substring(0, 22);
					if (selectionPos > 22) { selectionPos = 22; }
					BleAdvertisingNameTextbox.SelectionStart = selectionPos;
					BleAdvertisingNameTextbox.SelectionLength = 0;
					updatingElement = false;
				}
				BleAdvertisingNameLengthLabel.Text = BleAdvertisingNameTextbox.Text.Length.ToString() + " bytes";
				BleAdvertisingNameTextbox.ForeColor = Color.FromKnownColor(KnownColor.DarkGreen);
				advertisingNameChanged = true;
			}
		}
		private void BleAdvertisingNameTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				PushAdvertisingName();
			}
		}
		private void BleAdvertisingNameTextbox_Leave(object sender, EventArgs e)
		{
			if (!updatingElement && this.advertisingNameChanged)
			{
				PushAdvertisingName();
			}
		}
		
		// +==============================+
		// | Ble Advertising Data Events  |
		// +==============================+
		private void BleAdvertisingDataTextbox_TextChanged(object sender, EventArgs e)
		{
			
		}
		
		// +==============================+
		// |  Ble Command Button Events   |
		// +==============================+
		private void BleStartAdvertisingButton_Click(object sender, EventArgs e)
		{
			if ((savedBleFlags & SureFi.BleFlags_AdvertisingBit) != 0)
			{
				this.port.PushBleTxCommandNoBytes(BleCmd.StopAdvertising);
			}
			else
			{
				this.port.PushBleTxCommandNoBytes(BleCmd.StartAdvertising);
			}
		}
		private void BleCloseConnectionButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.CloseConnection);
		}
		private void BleGetVersionButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.GetFirmwareVersion);
		}
		private void RejectConnectionsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			byte[] payload = { 0x00 };
			if (RejectConnectionsCheckbox.Checked) { payload[0] = 0x01; }
			this.port.PushBleTxCommand(BleCmd.SetRejectConnections, payload);
		}
		
		// +==============================+
		// |   Ble Status Button Events   |
		// +==============================+
		private void BleClearResetFlagButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.ClearResetFlag);
		}
		private void BleClearConnectionAttemptedButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.ClearConnAttemptFlag);
		}
		private void BleGetStatusButton_Click(object sender, EventArgs e)
		{
			this.port.PushBleTxCommandNoBytes(BleCmd.GetStatus);
		}
		
		// +==============================+
		// |   BLE Interrupt Bit Events   |
		// +==============================+
		public byte bleStatusUpdateBits = 0x00;
		public void PushBleStatusUpdateBits(bool sendCommands)
		{
			for (int bitIndex = 0; bitIndex < 8; bitIndex++)
			{
				byte bit = (byte)(0x01 << bitIndex);
				bool isBitSet = (bleStatusUpdateBits & bit) > 0;
				this.SetBleIntEnableBit(bit, isBitSet);
			}
			
			// this.BleIntStatusLabel.Text = "Update: 0x" + bleStatusUpdateBits.ToString("X2");
			
			if (sendCommands)
			{
				byte[] payload = { bleStatusUpdateBits };
				this.port.PushBleTxCommand(BleCmd.SetStatusUpdateBits, payload);
			}
		}
		private void BleEnableAllButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				bleStatusUpdateBits = 0xFF;
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleDisableAllButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				bleStatusUpdateBits = 0x00;
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntWasResetBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x01) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x01)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x01); }
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntConnectedBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x02) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x02)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x02); }
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntAdvertisingBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x04) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x04)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x04); }
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntInDfuModeBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x08) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x08)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x08); }
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntSureFiTxInProgressBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x10) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x10)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x10); }
				PushBleStatusUpdateBits(true);
			}
		}
		private void BleIntConnectionAttemptedBit_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				if ((bleStatusUpdateBits & 0x20) != 0x00) { bleStatusUpdateBits = (byte)(bleStatusUpdateBits & (~0x20)); }
				else { bleStatusUpdateBits = (byte)(bleStatusUpdateBits | 0x20); }
				PushBleStatusUpdateBits(true);
			}
		}
		
		// +==============================+
		// |    Gpio Helper Functions     |
		// +==============================+
		private Label GetBleGpioDirectionLabel(byte gpioNumber)
		{
			if (gpioNumber == 3)  { return this.BleTp3DirectionLabel; }
			if (gpioNumber == 4)  { return this.BleTp4DirectionLabel; }
			if (gpioNumber == 5)  { return this.BleTp5DirectionLabel; }
			if (gpioNumber == 6)  { return this.BleTp6DirectionLabel; }
			if (gpioNumber == 25) { return this.BleTp25DirectionLabel; }
			if (gpioNumber == 28) { return this.BleTp28DirectionLabel; }
			return null;
		}
		private Label GetBleGpioPullLabel(byte gpioNumber)
		{
			if (gpioNumber == 3)  { return this.BleTp3PullLabel; }
			if (gpioNumber == 4)  { return this.BleTp4PullLabel; }
			if (gpioNumber == 5)  { return this.BleTp5PullLabel; }
			if (gpioNumber == 6)  { return this.BleTp6PullLabel; }
			if (gpioNumber == 25) { return this.BleTp25PullLabel; }
			if (gpioNumber == 28) { return this.BleTp28PullLabel; }
			return null;
		}
		private Label GetBleGpioValueLabel(byte gpioNumber)
		{
			if (gpioNumber == 3)  { return this.BleTp3ValueLabel; }
			if (gpioNumber == 4)  { return this.BleTp4ValueLabel; }
			if (gpioNumber == 5)  { return this.BleTp5ValueLabel; }
			if (gpioNumber == 6)  { return this.BleTp6ValueLabel; }
			if (gpioNumber == 25) { return this.BleTp25ValueLabel; }
			if (gpioNumber == 28) { return this.BleTp28ValueLabel; }
			return null;
		}
		private Button GetBleGpioGetButton(byte gpioNumber)
		{
			if (gpioNumber == 3)  { return this.BleTp3GetButton; }
			if (gpioNumber == 4)  { return this.BleTp4GetButton; }
			if (gpioNumber == 5)  { return this.BleTp5GetButton; }
			if (gpioNumber == 6)  { return this.BleTp6GetButton; }
			if (gpioNumber == 25) { return this.BleTp25GetButton; }
			if (gpioNumber == 28) { return this.BleTp28GetButton; }
			return null;
		}
		private CheckBox GetBleGpioAutoUpdateCheckbox(byte gpioNumber)
		{
			if (gpioNumber == 3)  { return this.BleTp3AutoCheckbox; }
			if (gpioNumber == 4)  { return this.BleTp4AutoCheckbox; }
			if (gpioNumber == 5)  { return this.BleTp5AutoCheckbox; }
			if (gpioNumber == 6)  { return this.BleTp6AutoCheckbox; }
			if (gpioNumber == 25) { return this.BleTp25AutoCheckbox; }
			if (gpioNumber == 28) { return this.BleTp28AutoCheckbox; }
			return null;
		}
		public void PushBleGpioDirection(byte gpioNumber, byte gpioDirection, byte gpioPull, bool sendCommands)
		{
			Label directionLabel = GetBleGpioDirectionLabel(gpioNumber);
			Label pullLabel = GetBleGpioPullLabel(gpioNumber);
			Label valueLabel = GetBleGpioValueLabel(gpioNumber);
			Button getButton = GetBleGpioGetButton(gpioNumber);
			CheckBox autoUpdateCheckbox = GetBleGpioAutoUpdateCheckbox(gpioNumber);
			if (directionLabel == null || pullLabel == null || valueLabel == null || 
				getButton == null || autoUpdateCheckbox == null)
			{
				Console.WriteLine("Unknown gpioNumber " + gpioNumber.ToString());
				return;
			}
			
			bool changedDirection = false;
			if (gpioDirection == 0x00) //Output
			{
				if (directionLabel.Text != "Out") { changedDirection = true; }
				directionLabel.Text = "Out";
				directionLabel.ForeColor = Color.FromKnownColor(KnownColor.Control);
				directionLabel.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
				
				pullLabel.Text = "None";
				pullLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				pullLabel.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
				pullLabel.Cursor = Cursors.Default;
				pullLabel.BorderStyle = BorderStyle.None;
				
				valueLabel.Text = "Low";
				valueLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				valueLabel.BackColor = Color.FromKnownColor(KnownColor.Transparent);
				valueLabel.Cursor = Cursors.Hand;
				valueLabel.BorderStyle = BorderStyle.FixedSingle;
				
				getButton.Enabled = false;
				autoUpdateCheckbox.Enabled = false;
				this.updatingElement = true;
				autoUpdateCheckbox.Checked = false;
				this.updatingElement = false;
			}
			else //Input
			{
				if (directionLabel.Text != "In") { changedDirection = true; }
				directionLabel.Text = "In";
				directionLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				directionLabel.BackColor = Color.FromKnownColor(KnownColor.Transparent);
				
				if (gpioPull == 0x01) //Pull-up
				{
					pullLabel.Text = "Up";
					pullLabel.ForeColor = Color.FromKnownColor(KnownColor.Control);
					pullLabel.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
				}
				else if (gpioPull == 0x02) //Pull-down
				{
					pullLabel.Text = "Down";
					pullLabel.ForeColor = Color.FromKnownColor(KnownColor.Control);
					pullLabel.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
				}
				else
				{
					pullLabel.Text = "None";
					pullLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
					pullLabel.BackColor = Color.FromKnownColor(KnownColor.Transparent);
				}
				pullLabel.Cursor = Cursors.Hand;
				pullLabel.BorderStyle = BorderStyle.FixedSingle;
				
				valueLabel.Cursor = Cursors.Default;
				valueLabel.BorderStyle = BorderStyle.None;
				
				autoUpdateCheckbox.Enabled = true;
				if (changedDirection)
				{
					getButton.Enabled = true;
					this.updatingElement = true;
					autoUpdateCheckbox.Checked = false;
					this.updatingElement = false;
				}
			}
			
			if (sendCommands)
			{
				if (gpioDirection == 0x00) //Output
				{
					byte[] payload = { gpioNumber, gpioDirection, 0x00 };
					this.port.PushBleTxCommand(BleCmd.SetGpioConfiguration, payload);
				}
				else //Input
				{
					byte[] payload = { gpioNumber, gpioDirection, gpioPull };
					this.port.PushBleTxCommand(BleCmd.SetGpioConfiguration, payload);
					// if (changedDirection)
					// {
					// 	byte[] payload2 = { gpioNumber, 0x00 };
					// 	this.port.PushBleTxCommand(BleCmd.SetGpioUpdateEnabled, payload2);
					// }
				}
			}
		}
		public void PushBleGpioValue(byte gpioNumber, byte gpioValue, bool sendCommands)
		{
			Label directionLabel = GetBleGpioDirectionLabel(gpioNumber);
			Label pullLabel = GetBleGpioPullLabel(gpioNumber);
			Label valueLabel = GetBleGpioValueLabel(gpioNumber);
			Button getButton = GetBleGpioGetButton(gpioNumber);
			CheckBox autoUpdateCheckbox = GetBleGpioAutoUpdateCheckbox(gpioNumber);
			if (directionLabel == null || pullLabel == null || valueLabel == null || 
				getButton == null || autoUpdateCheckbox == null)
			{
				Console.WriteLine("Unknown gpioNumber " + gpioNumber.ToString());
				return;
			}
			
			if (gpioValue > 0)
			{
				valueLabel.Text = "High";
				valueLabel.ForeColor = Color.FromKnownColor(KnownColor.Control);
				valueLabel.BackColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
			}
			else
			{
				valueLabel.Text = "Low";
				valueLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
				valueLabel.BackColor = Color.FromKnownColor(KnownColor.Transparent);
			}
			
			if (sendCommands)
			{
				byte[] payload = { gpioNumber, gpioValue };
				this.port.PushBleTxCommand(BleCmd.SetGpioValue, payload);
			}
		}
		public void PushBleGpioAutoUpdateEnabled(byte gpioNumber, bool enabled, bool sendCommands)
		{
			Label directionLabel = GetBleGpioDirectionLabel(gpioNumber);
			Label pullLabel = GetBleGpioPullLabel(gpioNumber);
			Label valueLabel = GetBleGpioValueLabel(gpioNumber);
			Button getButton = GetBleGpioGetButton(gpioNumber);
			CheckBox autoUpdateCheckbox = GetBleGpioAutoUpdateCheckbox(gpioNumber);
			if (directionLabel == null || pullLabel == null || valueLabel == null || 
				getButton == null || autoUpdateCheckbox == null)
			{
				Console.WriteLine("Unknown gpioNumber " + gpioNumber.ToString());
				return;
			}
			
			this.updatingElement = true;
			autoUpdateCheckbox.Checked = enabled;
			this.updatingElement = false;
			getButton.Enabled = !enabled;
			
			if (sendCommands)
			{
				byte[] payload = { gpioNumber, 0x00 };
				if (enabled) { payload[1] = 0x01; }
				this.port.PushBleTxCommand(BleCmd.SetGpioUpdateEnabled, payload);
			}
		}
		
		// +==============================+
		// |        Ble TP3 Events        |
		// +==============================+
		private void BleTp3DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp3PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp3PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp3DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp3DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(3, dirValue, pullValue, true);
			}
		}
		private void BleTp3PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp3DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp3PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp3PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp3PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(3, dirValue, pullValue, true);
			}
		}
		private void BleTp3ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp3DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp3ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp3ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(3, gpioValue, true);
			}
		}
		private void BleTp3GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 3 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp3AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(3, BleTp3AutoCheckbox.Checked, true);
			}
		}
		
		// +==============================+
		// |        Ble TP4 Events        |
		// +==============================+
		private void BleTp4DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp4PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp4PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp4DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp4DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(4, dirValue, pullValue, true);
			}
		}
		private void BleTp4PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp4DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp4PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp4PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp4PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(4, dirValue, pullValue, true);
			}
		}
		private void BleTp4ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp4DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp4ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp4ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(4, gpioValue, true);
			}
		}
		private void BleTp4GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 4 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp4AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(4, BleTp4AutoCheckbox.Checked, true);
			}
		}
		
		// +==============================+
		// |        Ble TP5 Events        |
		// +==============================+
		private void BleTp5DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp5PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp5PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp5DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp5DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(5, dirValue, pullValue, true);
			}
		}
		private void BleTp5PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp5DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp5PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp5PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp5PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(5, dirValue, pullValue, true);
			}
		}
		private void BleTp5ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp5DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp5ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp5ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(5, gpioValue, true);
			}
		}
		private void BleTp5GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 5 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp5AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(5, BleTp5AutoCheckbox.Checked, true);
			}
		}
		
		// +==============================+
		// |        Ble TP6 Events        |
		// +==============================+
		private void BleTp6DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp6PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp6PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp6DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp6DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(6, dirValue, pullValue, true);
			}
		}
		private void BleTp6PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp6DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp6PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp6PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp6PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(6, dirValue, pullValue, true);
			}
		}
		private void BleTp6ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp6DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp6ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp6ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(6, gpioValue, true);
			}
		}
		private void BleTp6GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 6 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp6AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(6, BleTp6AutoCheckbox.Checked, true);
			}
		}
		
		// +==============================+
		// |       Ble TP25 Events        |
		// +==============================+
		private void BleTp25DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp25PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp25PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp25DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp25DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(25, dirValue, pullValue, true);
			}
		}
		private void BleTp25PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp25DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp25PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp25PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp25PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(25, dirValue, pullValue, true);
			}
		}
		private void BleTp25ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp25DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp25ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp25ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(25, gpioValue, true);
			}
		}
		private void BleTp25GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 25 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp25AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(25, BleTp25AutoCheckbox.Checked, true);
			}
		}
		
		// +==============================+
		// |       Ble TP28 Events        |
		// +==============================+
		private void BleTp28DirectionLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement)
			{
				byte pullValue = 0x00;
				if (BleTp28PullLabel.Text == "Up")   { pullValue = 0x01; }
				if (BleTp28PullLabel.Text == "Down") { pullValue = 0x02; }
				
				byte dirValue = 0x00;
				if (BleTp28DirectionLabel.Text == "In")
				{
					dirValue = 0x00; //Change to Output
				}
				else if (BleTp28DirectionLabel.Text == "Out")
				{
					dirValue = 0x01; //Change to Input
				}
				
				PushBleGpioDirection(28, dirValue, pullValue, true);
			}
		}
		private void BleTp28PullLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && BleTp28DirectionLabel.Text == "In")
			{
				byte pullValue = 0x00;
				if (BleTp28PullLabel.Text == "None")
				{
					pullValue = 0x01; //Change to Up
				}
				else if (BleTp28PullLabel.Text == "Up")
				{
					pullValue = 0x02; //Change to Down
				}
				else if (BleTp28PullLabel.Text == "Down")
				{
					pullValue = 0x00; //Change to None
				}
				
				byte dirValue = 0x01; //Input
				PushBleGpioDirection(28, dirValue, pullValue, true);
			}
		}
		private void BleTp28ValueLabel_Click(object sender, MouseEventArgs e)
		{
			if (!this.updatingElement && this.BleTp28DirectionLabel.Text == "Out")
			{
				byte gpioValue = 0x00;
				if (BleTp28ValueLabel.Text == "High")
				{
					gpioValue = 0x00; //Change to Low
				}
				else if (BleTp28ValueLabel.Text == "Low")
				{
					gpioValue = 0x01; //Change to High
				}
				
				PushBleGpioValue(28, gpioValue, true);
			}
		}
		private void BleTp28GetButton_Click(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				byte[] payload = { 28 };
				this.port.PushBleTxCommand(BleCmd.GetGpioValue, payload);
			}
		}
		private void BleTp28AutoCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.updatingElement)
			{
				PushBleGpioAutoUpdateEnabled(28, BleTp28AutoCheckbox.Checked, true);
			}
		}
	}
}
