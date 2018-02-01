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
	public partial class ConnectForm : Form
	{
		// +==============================+
		// |       Member Variables       |
		// +==============================+
		MainForm mainForm;
		
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
		
		void UpdateComList()
		{
			string[] ports = SerialPort.GetPortNames();
			Comparison<string> comparison = new Comparison<string>(CompareComNames);
			Array.Sort(ports, comparison);
			
			ComListBox.Items.Clear();
			foreach (string port in ports)
			{
				ComListBox.Items.Insert(ComListBox.Items.Count, port);
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
				string connectPortName = ComListBox.SelectedItem.ToString();
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
