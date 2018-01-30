using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevKitWindowsApp
{
	public partial class MainForm : Form
	{
		// +==============================+
		// |        Custom Events         |
		// +==============================+
		public delegate void ConnectionResultHandler(object sender, bool success);
		public event ConnectionResultHandler OnConnectionFinished;
		
		void ReportConnectionResult(bool success)
		{
			Console.WriteLine("Connection " + (success ? "Succeeded" : "Failed") + "!");
			
			OnConnectionFinished(this, false);
			
			if (!success) { this.Close(); }
		}
		
		// +==============================+
		// |         Form Events          |
		// +==============================+
		public MainForm(string portName, ConnectionResultHandler connectionFinishedCallback)
		{
			InitializeComponent();
			
			OnConnectionFinished += connectionFinishedCallback;
			
			TestLabel.Text = "Passed: " + portName;
			
			ReportConnectionResult(true);
		}
		
		private void MainForm_Load(object sender, EventArgs e)
		{
		
		}
		
		// +==============================+
		// |        Control Events        |
		// +==============================+
	}
}
