using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.IO.Ports;

namespace DevKitWindowsApp
{
	public partial class ConnectForm : Form
	{
		// +==============================+
		// |       Member Variables       |
		// +==============================+
		MainForm mainForm;
		List<string> portNames = null;
		
		// +==============================+
		// |       Helper Functions       |
		// +==============================+
		int CompareComNames(string a, string b)
		{
			int comNumberA = 0;
			int comNumberB = 0;
			
			if (a.Length > 3 && a.Substring(0, 3).ToUpper() == "COM")
			{
				if (int.TryParse(a.Substring(3), out comNumberA) == false)
				{
					comNumberA = 0;
				}
			}
			if (b.Length > 3 && b.Substring(0, 3).ToUpper() == "COM")
			{
				if (int.TryParse(b.Substring(3), out comNumberB) == false)
				{
					comNumberB = 0;
				}
			}
			
			if (comNumberA > comNumberB) { return 1; }
			if (comNumberA < comNumberB) { return -1; }
			return 0;
		}
		
		string GetComModuleName(string portName)
		{
			string result = null;
			
			PortFifo testPort = new PortFifo(null, portName);
			if (testPort.isOpen)
			{
				result = portName;
				
				testPort.PushTxCommandNoBytes(SureCmd.GetStatus);
				testPort.PushTxCommandNoBytes(SureCmd.GetReceiveUID);
				testPort.FlushTxBytes();
				
				int numMs = 50;
				bool gotStatus = false;
				while (numMs > 0)
				{
					testPort.Update();
					List<byte> response = testPort.PopRxCommand();
					if (response != null)
					{
						byte rspCmd = response[1];
						byte rspLength = response[2];
						List<byte> payload = response.GetRange(3, response.Count-3);
						
						if (rspCmd == (byte)SureRsp.Status)
						{
							if (rspLength == 4)
							{
								Console.WriteLine("Got Status Response");
								gotStatus = true;
							}
							else
							{
								Console.WriteLine("Got " + rspLength.ToString() + " byte Status Response");
							}
						}
						else if (rspCmd == (byte)SureRsp.ReceiveUID)
						{
							if (gotStatus)
							{
								Console.WriteLine("Got " + rspLength.ToString() + " byte ReceiveUID Response");
								
								result = "Sure-Fi Module-";
								if (payload.Count == 0)
								{
									result += "No UID";
								}
								else
								{
									for (int bIndex = 0; bIndex < payload.Count; bIndex++)
									{
										result += payload[bIndex].ToString("X2");
									}
								}
								break;
							}
							else
							{
								Console.WriteLine("Got ReceiveUID Response before Status Response");
							}
						}
						else
						{
							Console.WriteLine("Got other " + rspLength.ToString() + " byte command " + rspCmd.ToString("X2"));
						}
					}
					
					Thread.Sleep(1);
					numMs--;
				}
			}
			
			if (result == portName) { Console.WriteLine("Timed out on " + portName); }
			testPort.Close();
			return result;
		}
		
		void UpdateComList()
		{
			portNames = new List<string>();
			string[] ports = SerialPort.GetPortNames();
			Comparison<string> comparison = new Comparison<string>(CompareComNames);
			Array.Sort(ports, comparison);
			
			ComListBox.Items.Clear();
			foreach (string port in ports)
			{
				string moduleName = GetComModuleName(port);
				if (moduleName != null)
				{
					ComListBox.Items.Insert(ComListBox.Items.Count, moduleName);
				}
				else
				{
					ComListBox.Items.Insert(ComListBox.Items.Count, port + " [In Use]");
				}
				portNames.Add(port);
			}
			
			ConnectButton.Enabled = false;
		}
		
		void ConnectToPort(string portName)
		{
			ConnectButton.Enabled = false;
			ConnectButton.Text = "Connecting...";
			
			this.mainForm = new MainForm(this);
			this.mainForm.OnConnectionFinished += MainForm_OnConnectionFinished;
			this.mainForm.FormClosed += MainForm_FormClosed;
			this.mainForm.TryConnectToPort(portName);
		}
		
		// +==============================+
		// |         Form Events          |
		// +==============================+
		public ConnectForm()
		{
			InitializeComponent();
		}
		
		private void ConnectForm_Load(object sender, EventArgs e)
		{
			UpdateComList();
		}
		
		private void MainForm_OnConnectionFinished(object sender, bool success, string message)
		{
			ConnectButton.Enabled = true;
			ConnectButton.Text = "Connect";
			
			if (success)
			{
				this.mainForm.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show(this, message, "Could not connect to COM port");
				this.mainForm = null;
			}
		}
		
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.Visible)
			{
				UpdateComList();
			}
			else
			{
				this.Close();
			}
		}
		
		// +==============================+
		// |        Control Events        |
		// +==============================+
		
		private void ComListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ComListBox.SelectedIndex >= 0)
			{
				ConnectButton.Enabled = true;
			}
			else
			{
				ConnectButton.Enabled = false;
			}
		}
		
		private void ConnectButton_Click(object sender, EventArgs e)
		{
			if (ComListBox.SelectedIndex >= 0)
			{
				string connectPortName = portNames[ComListBox.SelectedIndex];
				Console.WriteLine("Connecting to \"" + connectPortName + "\"");
				ConnectToPort(connectPortName);
			}
		}
		
		private void RefreshButton_Click(object sender, EventArgs e)
		{
			UpdateComList();
		}
	}
}
