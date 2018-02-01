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
	class PortFifo
	{
		// +==============================+
		// |       Member Variables       |
		// +==============================+
		MainForm mainForm = null;
		List<byte> rxFifo;
		
		public bool isOpen = false;
		public string connectFailureString = "";
		public string portName = "";
		public SerialPort port = null;
		
		// +==============================+
		// |         Constructor          |
		// +==============================+
		public PortFifo(MainForm mainForm, string portName)
		{
			this.mainForm = mainForm;
			
			this.rxFifo = new List<byte>();
			
			try
			{
				this.port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
				this.port.Open();
				
				if (this.port.IsOpen)
				{
					this.portName = portName;
					this.isOpen = true;
				}
				else
				{
					this.portName = "";
					this.port = null;
					
					this.isOpen = false;
					this.connectFailureString = "Could not open " + portName;
				}
			}
			catch (Exception exception)
			{
				this.portName = "";
				this.port = null;
				
				this.isOpen = false;
				this.connectFailureString = "Exception while connecting: " + exception.ToString();
			}
		}
		
		public void Close()
		{
			if (this.port != null && this.port.IsOpen)
			{
				this.port.Close();
			}
			this.port = null;
			this.isOpen = false;
			this.portName = "";
		}
		
		// +==============================+
		// |       Public Functions       |
		// +==============================+
		public void Update()
		{
			if (this.isOpen && (this.port == null || this.port.IsOpen == false))
			{
				this.connectFailureString = "Port was closed unexpectadly";
				this.isOpen = false;
				this.port = null;
				this.portName = "";
			}
			
			if (this.isOpen)
			{
				if (this.port.BytesToRead > 0)
				{
					char[] newBytes = new char[this.port.BytesToRead];
					this.port.Read(newBytes, 0, this.port.BytesToRead);
					
					string newString = "";
					foreach (char c in newBytes)
					{
						byte b = Convert.ToByte(c);
						
						if (!mainForm.FormatResponsesCheckbox.Checked)
						{
							if (c == 0x7E && mainForm.OutputTextbox.Text != "")
							{
								newString += "\r\n";
							}
							
							string byteStr = b.ToString("X2");
							if (c == 0x7E)
							{
								byteStr = "[" + byteStr + "]";
							}
							newString += byteStr + " ";
						}
						
						this.rxFifo.Add(b);
					}
					
					mainForm.OutputTextbox.Text += newString;
				}
			}
		}
		
		public List<byte> PopRxCommand()
		{
			List<byte> result = new List<byte>();
			
			bool foundCommand = false;
			int bIndex = 0;
			while (bIndex < this.rxFifo.Count)
			{
				byte newByte = this.rxFifo[bIndex];
				
				if (bIndex == 0)
				{
					if (newByte == 0x7E)
					{
						result.Add(newByte);
						bIndex++;
					}
					else
					{
						Console.WriteLine("Pop[" + newByte.ToString("X2") + "]");
						this.rxFifo.RemoveAt(0);
					}
				}
				else
				{
					result.Add(newByte);
					bIndex++;
					
					if (bIndex >= 3)
					{
						byte length = result[2];
						if (bIndex >= 3 + length)
						{
							foundCommand = true;
							break;
						}
					}
				}
			}
			
			if (foundCommand)
			{
				while (bIndex > 0)
				{
					//Pop all the bytes off the fifo
					rxFifo.RemoveAt(0);
					bIndex--;
				}
				return result;
			}
			else
			{
				return null;
			}
		}
	}
}
