namespace DevKitWindowsApp
{
    partial class ConnectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
			this.ComListBox = new System.Windows.Forms.ListBox();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ComListBox
			// 
			this.ComListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ComListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComListBox.FormattingEnabled = true;
			this.ComListBox.ItemHeight = 16;
			this.ComListBox.Items.AddRange(new object[] {
            "Scanning..."});
			this.ComListBox.Location = new System.Drawing.Point(12, 24);
			this.ComListBox.Name = "ComListBox";
			this.ComListBox.Size = new System.Drawing.Size(260, 276);
			this.ComListBox.TabIndex = 0;
			this.ComListBox.SelectedIndexChanged += new System.EventHandler(this.ComListBox_SelectedIndexChanged);
			// 
			// ConnectButton
			// 
			this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ConnectButton.Enabled = false;
			this.ConnectButton.Location = new System.Drawing.Point(278, 249);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(109, 55);
			this.ConnectButton.TabIndex = 1;
			this.ConnectButton.Text = "Connect";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RefreshButton.Location = new System.Drawing.Point(278, 24);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(109, 28);
			this.RefreshButton.TabIndex = 2;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(278, 134);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(109, 109);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select an available COM port...";
			// 
			// ConnectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 320);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.ComListBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(326, 359);
			this.Name = "ConnectForm";
			this.Text = "Port Selector";
			this.Load += new System.EventHandler(this.ConnectForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ComListBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
	}
}

