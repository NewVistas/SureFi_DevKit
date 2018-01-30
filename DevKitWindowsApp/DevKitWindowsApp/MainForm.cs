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
		SerialPort port;
		string portName;
		
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
		
		// +==============================+
		// |         Form Events          |
		// +==============================+
		public MainForm(string portName, ConnectionResultHandler connectionFinishedCallback)
		{
			InitializeComponent();
			
			OnConnectionFinished += connectionFinishedCallback;
			
			try
			{
				this.port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
				this.port.Open();
				
				if (this.port.IsOpen)
				{
					this.portName = portName;
				}
				else
				{
					ReportConnectionResult(false, "Could not open " + portName);
					return;
				}
			}
			catch (Exception exception)
			{
				ReportConnectionResult(false, "Exception hit while connecting to port: " + exception.ToString());
				return;
			}
			
			ReportConnectionResult(true, "");
			StatusUpdate("Connected to " + this.portName + "!");
		}
		
		private void MainForm_Load(object sender, EventArgs e)
		{
		
		}
		
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.port.IsOpen)
			{
				this.port.Close();
				this.portName = "";
			}
		}
		
		private void TickTimer_Tick(object sender, EventArgs e)
		{
			if (this.port != null && this.port.IsOpen)
			{
				if (this.port.BytesToRead > 0)
				{
					char[] newBytes = new char[this.port.BytesToRead];
					this.port.Read(newBytes, 0, this.port.BytesToRead);
					
					string newString = "";
					foreach (char c in newBytes)
					{
						if (c == 0x7E)
						{
							newString += "\r\n";
						}
						
						byte b = Convert.ToByte(c);
						newString += b.ToString("X2") + " ";
					}
					
					OutputTextbox.Text += newString;
				}
			}
		}
		
		// +==============================+
		// |        Control Events        |
		// +==============================+
	}
}
