namespace DevKitWindowsApp
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TickTimer = new System.Windows.Forms.Timer(this.components);
			this.OutputTextbox = new System.Windows.Forms.TextBox();
			this.DisconnectButton = new System.Windows.Forms.Button();
			this.FormatResponsesCheckbox = new System.Windows.Forms.CheckBox();
			this.StatusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 548);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(768, 22);
			this.StatusBar.TabIndex = 1;
			this.StatusBar.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(59, 17);
			this.StatusLabel.Text = "Loading...";
			// 
			// TickTimer
			// 
			this.TickTimer.Enabled = true;
			this.TickTimer.Interval = 60;
			this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
			// 
			// OutputTextbox
			// 
			this.OutputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputTextbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.OutputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OutputTextbox.Cursor = System.Windows.Forms.Cursors.Default;
			this.OutputTextbox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OutputTextbox.Location = new System.Drawing.Point(595, 27);
			this.OutputTextbox.Multiline = true;
			this.OutputTextbox.Name = "OutputTextbox";
			this.OutputTextbox.ReadOnly = true;
			this.OutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OutputTextbox.Size = new System.Drawing.Size(161, 489);
			this.OutputTextbox.TabIndex = 2;
			this.OutputTextbox.TabStop = false;
			this.OutputTextbox.Text = "[7E] 40 04 12 AB CD EF";
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DisconnectButton.Location = new System.Drawing.Point(595, 522);
			this.DisconnectButton.Name = "DisconnectButton";
			this.DisconnectButton.Size = new System.Drawing.Size(144, 23);
			this.DisconnectButton.TabIndex = 3;
			this.DisconnectButton.Text = "Disconnect";
			this.DisconnectButton.UseVisualStyleBackColor = true;
			this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
			// 
			// FormatResponsesCheckbox
			// 
			this.FormatResponsesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FormatResponsesCheckbox.AutoSize = true;
			this.FormatResponsesCheckbox.Checked = true;
			this.FormatResponsesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.FormatResponsesCheckbox.Location = new System.Drawing.Point(595, 7);
			this.FormatResponsesCheckbox.Name = "FormatResponsesCheckbox";
			this.FormatResponsesCheckbox.Size = new System.Drawing.Size(114, 17);
			this.FormatResponsesCheckbox.TabIndex = 4;
			this.FormatResponsesCheckbox.Text = "Format Responses";
			this.FormatResponsesCheckbox.UseVisualStyleBackColor = true;
			this.FormatResponsesCheckbox.CheckedChanged += new System.EventHandler(this.FormatResponsesCheckbox_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(768, 570);
			this.Controls.Add(this.FormatResponsesCheckbox);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.OutputTextbox);
			this.Controls.Add(this.StatusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Sure-Fi Module Developer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.Timer TickTimer;
		private System.Windows.Forms.Button DisconnectButton;
		public System.Windows.Forms.TextBox OutputTextbox;
		public System.Windows.Forms.CheckBox FormatResponsesCheckbox;
	}
}