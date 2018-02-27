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
			this.HumanReadableCheckbox = new System.Windows.Forms.CheckBox();
			this.MainTabControl = new System.Windows.Forms.TabControl();
			this.TabPageRadio = new System.Windows.Forms.TabPage();
			this.TableHoppingCheckbox = new System.Windows.Forms.CheckBox();
			this.QuietModeCheckbox = new System.Windows.Forms.CheckBox();
			this.AcksEnabledCheckbox = new System.Windows.Forms.CheckBox();
			this.EncryptionReadyLabel = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.FhssTableNumeric = new System.Windows.Forms.NumericUpDown();
			this.PolarityCombobox = new System.Windows.Forms.ComboBox();
			this.BandwidthCombobox = new System.Windows.Forms.ComboBox();
			this.SpreadingFactorCombobox = new System.Windows.Forms.ComboBox();
			this.RadioModeCombobox = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.TransmitPowerCombobox = new System.Windows.Forms.ComboBox();
			this.RxPacketSizeLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.NumRetriesNumeric = new System.Windows.Forms.NumericUpDown();
			this.PayloadSizeNumeric = new System.Windows.Forms.NumericUpDown();
			this.RxUidLengthLabel = new System.Windows.Forms.Label();
			this.TxUidLengthLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxUidTextbox = new System.Windows.Forms.TextBox();
			this.RxUidTextbox = new System.Windows.Forms.TextBox();
			this.TabPageOther = new System.Windows.Forms.TabPage();
			this.ClearIndicationsButton = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.LedCombo1 = new System.Windows.Forms.ComboBox();
			this.LedLabel1 = new System.Windows.Forms.Label();
			this.LedCombo2 = new System.Windows.Forms.ComboBox();
			this.LedLabel2 = new System.Windows.Forms.Label();
			this.LedCombo3 = new System.Windows.Forms.ComboBox();
			this.LedLabel3 = new System.Windows.Forms.Label();
			this.LedCombo4 = new System.Windows.Forms.ComboBox();
			this.LedLabel4 = new System.Windows.Forms.Label();
			this.LedCombo5 = new System.Windows.Forms.ComboBox();
			this.LedLabel5 = new System.Windows.Forms.Label();
			this.LedCombo6 = new System.Windows.Forms.ComboBox();
			this.LedLabel6 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.TxLedModeCombobox = new System.Windows.Forms.ComboBox();
			this.RxLedModeCombobox = new System.Windows.Forms.ComboBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.ButtonConfigCombobox = new System.Windows.Forms.ComboBox();
			this.ButtonHoldTimeNumeric = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.QosConfigCombobox = new System.Windows.Forms.ComboBox();
			this.TabPageCommands = new System.Windows.Forms.TabPage();
			this.label25 = new System.Windows.Forms.Label();
			this.GetRegisteredSerialButton = new System.Windows.Forms.Button();
			this.GetRandomNumberButton = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.FirmwareVersionLabel = new System.Windows.Forms.Label();
			this.RegisteredSerialLabel = new System.Windows.Forms.Label();
			this.RandomNumberLabel = new System.Windows.Forms.Label();
			this.TimeOnAirLabel = new System.Windows.Forms.Label();
			this.MicroVersionLabel = new System.Windows.Forms.Label();
			this.GetTimeOnAirButton = new System.Windows.Forms.Button();
			this.HardwareVersionLabel = new System.Windows.Forms.Label();
			this.GetModuleVersionButton = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.ShowQosButton = new System.Windows.Forms.Button();
			this.LightshowButton = new System.Windows.Forms.Button();
			this.RefreshSettingsButton = new System.Windows.Forms.Button();
			this.DefaultSettingsButton = new System.Windows.Forms.Button();
			this.SleepButton = new System.Windows.Forms.Button();
			this.ResetButton = new System.Windows.Forms.Button();
			this.StartEncryptionButton = new System.Windows.Forms.Button();
			this.TabPageStatus = new System.Windows.Forms.TabPage();
			this.GetStatusButton = new System.Windows.Forms.Button();
			this.ClearFlagsButton = new System.Windows.Forms.Button();
			this.AutoClearFlagsCheckbox = new System.Windows.Forms.CheckBox();
			this.StatusConfigLabel = new System.Windows.Forms.Label();
			this.StatusClearableLabel = new System.Windows.Forms.Label();
			this.StatusOtherLabel = new System.Windows.Forms.Label();
			this.StatusStateLabel = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label85 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.label67 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.label81 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.label79 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.RadioStateStrLabel = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.ButtonHeldBit = new System.Windows.Forms.Label();
			this.TxLedModeBit = new System.Windows.Forms.Label();
			this.AckPacketReadyBit = new System.Windows.Forms.Label();
			this.SettingsPendingBit = new System.Windows.Forms.Label();
			this.ButtonPressedBit = new System.Windows.Forms.Label();
			this.RadioStateBit4 = new System.Windows.Forms.Label();
			this.RxLedModeBit = new System.Windows.Forms.Label();
			this.RxPacketReadyBit = new System.Windows.Forms.Label();
			this.ButtonDownBit = new System.Windows.Forms.Label();
			this.RxInProgressBit = new System.Windows.Forms.Label();
			this.EncryptionRekeyBit = new System.Windows.Forms.Label();
			this.AutoClearFlagsBit = new System.Windows.Forms.Label();
			this.RadioStateBit3 = new System.Windows.Forms.Label();
			this.TransmitFinishedBit = new System.Windows.Forms.Label();
			this.AutoRekeyBit = new System.Windows.Forms.Label();
			this.ChecksumErrorBit = new System.Windows.Forms.Label();
			this.ShowingQosBit = new System.Windows.Forms.Label();
			this.InterruptDrivenBit = new System.Windows.Forms.Label();
			this.WasResetBit = new System.Windows.Forms.Label();
			this.EncryptionActiveBit = new System.Windows.Forms.Label();
			this.DoingLightshowBit = new System.Windows.Forms.Label();
			this.RadioStateBit2 = new System.Windows.Forms.Label();
			this.OnBaseTableBit = new System.Windows.Forms.Label();
			this.ChangingTablesBit = new System.Windows.Forms.Label();
			this.BusyBit = new System.Windows.Forms.Label();
			this.RadioStateBit1 = new System.Windows.Forms.Label();
			this.TabPageInt = new System.Windows.Forms.TabPage();
			this.EnableAllIntButton = new System.Windows.Forms.Button();
			this.DisableAllIntButton = new System.Windows.Forms.Button();
			this.IntConfigLabel = new System.Windows.Forms.Label();
			this.IntClearableLabel = new System.Windows.Forms.Label();
			this.IntOtherLabel = new System.Windows.Forms.Label();
			this.IntStateLabel = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.IntButtonHeldBit = new System.Windows.Forms.Label();
			this.IntTxLedModeBit = new System.Windows.Forms.Label();
			this.IntAckPacketReadyBit = new System.Windows.Forms.Label();
			this.IntSettingsPendingBit = new System.Windows.Forms.Label();
			this.IntButtonPressedBit = new System.Windows.Forms.Label();
			this.IntRadioStateBit4 = new System.Windows.Forms.Label();
			this.IntRxLedModeBit = new System.Windows.Forms.Label();
			this.IntRxPacketReadyBit = new System.Windows.Forms.Label();
			this.IntButtonDownBit = new System.Windows.Forms.Label();
			this.IntOnBaseTableBit = new System.Windows.Forms.Label();
			this.IntChangingTablesBit = new System.Windows.Forms.Label();
			this.IntRxInProgressBit = new System.Windows.Forms.Label();
			this.IntEncryptionRekeyBit = new System.Windows.Forms.Label();
			this.IntAutoClearFlagsBit = new System.Windows.Forms.Label();
			this.IntRadioStateBit3 = new System.Windows.Forms.Label();
			this.IntTransmitFinishedBit = new System.Windows.Forms.Label();
			this.IntAutoRekeyBit = new System.Windows.Forms.Label();
			this.IntChecksumErrorBit = new System.Windows.Forms.Label();
			this.IntShowingQosBit = new System.Windows.Forms.Label();
			this.IntInterruptDrivenBit = new System.Windows.Forms.Label();
			this.IntWasResetBit = new System.Windows.Forms.Label();
			this.IntEncryptionActiveBit = new System.Windows.Forms.Label();
			this.IntDoingLightshowBit = new System.Windows.Forms.Label();
			this.IntRadioStateBit2 = new System.Windows.Forms.Label();
			this.IntBusyBit = new System.Windows.Forms.Label();
			this.IntRadioStateBit1 = new System.Windows.Forms.Label();
			this.TabPageBluetooth = new System.Windows.Forms.TabPage();
			this.BleTp28AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp25AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp6AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp5AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp4AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp3AutoCheckbox = new System.Windows.Forms.CheckBox();
			this.label107 = new System.Windows.Forms.Label();
			this.label92 = new System.Windows.Forms.Label();
			this.label84 = new System.Windows.Forms.Label();
			this.label106 = new System.Windows.Forms.Label();
			this.BleTp28GetButton = new System.Windows.Forms.Button();
			this.label103 = new System.Windows.Forms.Label();
			this.BleTp25GetButton = new System.Windows.Forms.Button();
			this.label100 = new System.Windows.Forms.Label();
			this.BleTp6GetButton = new System.Windows.Forms.Button();
			this.label97 = new System.Windows.Forms.Label();
			this.BleTp5GetButton = new System.Windows.Forms.Button();
			this.label94 = new System.Windows.Forms.Label();
			this.BleTp4GetButton = new System.Windows.Forms.Button();
			this.label82 = new System.Windows.Forms.Label();
			this.BleTp3GetButton = new System.Windows.Forms.Button();
			this.BleDisableAllButton = new System.Windows.Forms.Button();
			this.BleEnableAllButton = new System.Windows.Forms.Button();
			this.BleClearResetFlagButton = new System.Windows.Forms.Button();
			this.BleGetStatusButton = new System.Windows.Forms.Button();
			this.BleFirmwareVersionLabel = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.BleGetVersionButton = new System.Windows.Forms.Button();
			this.BleAdvertisingNameLengthLabel = new System.Windows.Forms.Label();
			this.BleAdvertisingDataLengthLabel = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.label59 = new System.Windows.Forms.Label();
			this.BleAdvertisingDataTextbox = new System.Windows.Forms.TextBox();
			this.BleAdvertisingNameTextbox = new System.Windows.Forms.TextBox();
			this.BleCloseConnectionButton = new System.Windows.Forms.Button();
			this.BleStartAdvertisingButton = new System.Windows.Forms.Button();
			this.label91 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.label90 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.label89 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.label88 = new System.Windows.Forms.Label();
			this.label86 = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.BleIntInDfuModeBit = new System.Windows.Forms.Label();
			this.BleInDfuModeBit = new System.Windows.Forms.Label();
			this.BleIntAdvertisingBit = new System.Windows.Forms.Label();
			this.BleTp28ValueLabel = new System.Windows.Forms.Label();
			this.BleAdvertisingBit = new System.Windows.Forms.Label();
			this.BleTp25ValueLabel = new System.Windows.Forms.Label();
			this.BleIntConnectedBit = new System.Windows.Forms.Label();
			this.BleTp6ValueLabel = new System.Windows.Forms.Label();
			this.BleConnectedBit = new System.Windows.Forms.Label();
			this.BleTp28DirectionLabel = new System.Windows.Forms.Label();
			this.BleTp5ValueLabel = new System.Windows.Forms.Label();
			this.BleTp25DirectionLabel = new System.Windows.Forms.Label();
			this.BleIntSureFiTxInProgressBit = new System.Windows.Forms.Label();
			this.BleTp6DirectionLabel = new System.Windows.Forms.Label();
			this.BleTp4ValueLabel = new System.Windows.Forms.Label();
			this.BleTp5DirectionLabel = new System.Windows.Forms.Label();
			this.BleSureFiTxInProgressBit = new System.Windows.Forms.Label();
			this.BleTp4DirectionLabel = new System.Windows.Forms.Label();
			this.BleTp3ValueLabel = new System.Windows.Forms.Label();
			this.BleTp3DirectionLabel = new System.Windows.Forms.Label();
			this.BleIntWasResetBit = new System.Windows.Forms.Label();
			this.BleWasResetBit = new System.Windows.Forms.Label();
			this.TxTextbox = new System.Windows.Forms.TextBox();
			this.TransmitButton = new System.Windows.Forms.Button();
			this.RxTextbox = new System.Windows.Forms.TextBox();
			this.RxClearButton = new System.Windows.Forms.Button();
			this.TxHexCheckbox = new System.Windows.Forms.CheckBox();
			this.AckTextbox = new System.Windows.Forms.TextBox();
			this.AckClearButton = new System.Windows.Forms.Button();
			this.TxSuccessLabel = new System.Windows.Forms.Label();
			this.TxLengthLabel = new System.Windows.Forms.Label();
			this.TxCountLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.RxLengthLabel = new System.Windows.Forms.Label();
			this.RxCountLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.RxHexCheckbox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AckHexCheckbox = new System.Windows.Forms.CheckBox();
			this.AckLengthLabel = new System.Windows.Forms.Label();
			this.AckCountLabel = new System.Windows.Forms.Label();
			this.TxRssiLabel = new System.Windows.Forms.Label();
			this.TxSnrLabel = new System.Windows.Forms.Label();
			this.RxRssiLabel = new System.Windows.Forms.Label();
			this.RxSnrLabel = new System.Windows.Forms.Label();
			this.OutputClearButton = new System.Windows.Forms.Button();
			this.AckDataTextbox = new System.Windows.Forms.TextBox();
			this.AckDataLengthLabel = new System.Windows.Forms.Label();
			this.AckDataHexCheckbox = new System.Windows.Forms.CheckBox();
			this.TxRetriesLabel = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.PrintStatusCheckbox = new System.Windows.Forms.CheckBox();
			this.BleTp3PullLabel = new System.Windows.Forms.Label();
			this.label77 = new System.Windows.Forms.Label();
			this.BleTp4PullLabel = new System.Windows.Forms.Label();
			this.BleTp5PullLabel = new System.Windows.Forms.Label();
			this.BleTp6PullLabel = new System.Windows.Forms.Label();
			this.BleTp25PullLabel = new System.Windows.Forms.Label();
			this.BleTp28PullLabel = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.StatusBar.SuspendLayout();
			this.MainTabControl.SuspendLayout();
			this.TabPageRadio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FhssTableNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumRetriesNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PayloadSizeNumeric)).BeginInit();
			this.TabPageOther.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ButtonHoldTimeNumeric)).BeginInit();
			this.TabPageCommands.SuspendLayout();
			this.TabPageStatus.SuspendLayout();
			this.TabPageInt.SuspendLayout();
			this.TabPageBluetooth.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 442);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(755, 22);
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
			this.OutputTextbox.Location = new System.Drawing.Point(582, 27);
			this.OutputTextbox.Multiline = true;
			this.OutputTextbox.Name = "OutputTextbox";
			this.OutputTextbox.ReadOnly = true;
			this.OutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputTextbox.Size = new System.Drawing.Size(161, 302);
			this.OutputTextbox.TabIndex = 2;
			this.OutputTextbox.TabStop = false;
			this.OutputTextbox.Text = "[7E] 40 04 12 AB CD EF";
			this.OutputTextbox.WordWrap = false;
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DisconnectButton.Location = new System.Drawing.Point(582, 335);
			this.DisconnectButton.Name = "DisconnectButton";
			this.DisconnectButton.Size = new System.Drawing.Size(161, 23);
			this.DisconnectButton.TabIndex = 3;
			this.DisconnectButton.Text = "Disconnect";
			this.DisconnectButton.UseVisualStyleBackColor = true;
			this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
			// 
			// HumanReadableCheckbox
			// 
			this.HumanReadableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.HumanReadableCheckbox.AutoSize = true;
			this.HumanReadableCheckbox.Checked = true;
			this.HumanReadableCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.HumanReadableCheckbox.Location = new System.Drawing.Point(578, 7);
			this.HumanReadableCheckbox.Name = "HumanReadableCheckbox";
			this.HumanReadableCheckbox.Size = new System.Drawing.Size(54, 17);
			this.HumanReadableCheckbox.TabIndex = 4;
			this.HumanReadableCheckbox.Text = "Name";
			this.HumanReadableCheckbox.UseVisualStyleBackColor = true;
			this.HumanReadableCheckbox.CheckedChanged += new System.EventHandler(this.HumanReadableCheckbox_CheckedChanged);
			// 
			// MainTabControl
			// 
			this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTabControl.Controls.Add(this.TabPageRadio);
			this.MainTabControl.Controls.Add(this.TabPageOther);
			this.MainTabControl.Controls.Add(this.TabPageCommands);
			this.MainTabControl.Controls.Add(this.TabPageStatus);
			this.MainTabControl.Controls.Add(this.TabPageInt);
			this.MainTabControl.Controls.Add(this.TabPageBluetooth);
			this.MainTabControl.Location = new System.Drawing.Point(0, 0);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new System.Drawing.Size(576, 358);
			this.MainTabControl.TabIndex = 5;
			// 
			// TabPageRadio
			// 
			this.TabPageRadio.Controls.Add(this.label72);
			this.TabPageRadio.Controls.Add(this.TableHoppingCheckbox);
			this.TabPageRadio.Controls.Add(this.QuietModeCheckbox);
			this.TabPageRadio.Controls.Add(this.AcksEnabledCheckbox);
			this.TabPageRadio.Controls.Add(this.EncryptionReadyLabel);
			this.TabPageRadio.Controls.Add(this.label15);
			this.TabPageRadio.Controls.Add(this.FhssTableNumeric);
			this.TabPageRadio.Controls.Add(this.PolarityCombobox);
			this.TabPageRadio.Controls.Add(this.BandwidthCombobox);
			this.TabPageRadio.Controls.Add(this.SpreadingFactorCombobox);
			this.TabPageRadio.Controls.Add(this.RadioModeCombobox);
			this.TabPageRadio.Controls.Add(this.label13);
			this.TabPageRadio.Controls.Add(this.label12);
			this.TabPageRadio.Controls.Add(this.label11);
			this.TabPageRadio.Controls.Add(this.label14);
			this.TabPageRadio.Controls.Add(this.label10);
			this.TabPageRadio.Controls.Add(this.TransmitPowerCombobox);
			this.TabPageRadio.Controls.Add(this.RxPacketSizeLabel);
			this.TabPageRadio.Controls.Add(this.label9);
			this.TabPageRadio.Controls.Add(this.label2);
			this.TabPageRadio.Controls.Add(this.label8);
			this.TabPageRadio.Controls.Add(this.NumRetriesNumeric);
			this.TabPageRadio.Controls.Add(this.PayloadSizeNumeric);
			this.TabPageRadio.Controls.Add(this.RxUidLengthLabel);
			this.TabPageRadio.Controls.Add(this.TxUidLengthLabel);
			this.TabPageRadio.Controls.Add(this.label7);
			this.TabPageRadio.Controls.Add(this.label5);
			this.TabPageRadio.Controls.Add(this.label4);
			this.TabPageRadio.Controls.Add(this.TxUidTextbox);
			this.TabPageRadio.Controls.Add(this.RxUidTextbox);
			this.TabPageRadio.Location = new System.Drawing.Point(4, 22);
			this.TabPageRadio.Name = "TabPageRadio";
			this.TabPageRadio.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageRadio.Size = new System.Drawing.Size(568, 332);
			this.TabPageRadio.TabIndex = 0;
			this.TabPageRadio.Text = "Radio Settings";
			this.TabPageRadio.UseVisualStyleBackColor = true;
			// 
			// TableHoppingCheckbox
			// 
			this.TableHoppingCheckbox.AutoSize = true;
			this.TableHoppingCheckbox.Location = new System.Drawing.Point(283, 178);
			this.TableHoppingCheckbox.Name = "TableHoppingCheckbox";
			this.TableHoppingCheckbox.Size = new System.Drawing.Size(96, 17);
			this.TableHoppingCheckbox.TabIndex = 16;
			this.TableHoppingCheckbox.Text = "Table Hopping";
			this.TableHoppingCheckbox.UseVisualStyleBackColor = true;
			this.TableHoppingCheckbox.CheckedChanged += new System.EventHandler(this.TableHoppingCheckbox_CheckedChanged);
			// 
			// QuietModeCheckbox
			// 
			this.QuietModeCheckbox.AutoSize = true;
			this.QuietModeCheckbox.Location = new System.Drawing.Point(196, 178);
			this.QuietModeCheckbox.Name = "QuietModeCheckbox";
			this.QuietModeCheckbox.Size = new System.Drawing.Size(81, 17);
			this.QuietModeCheckbox.TabIndex = 15;
			this.QuietModeCheckbox.Text = "Quiet Mode";
			this.QuietModeCheckbox.UseVisualStyleBackColor = true;
			this.QuietModeCheckbox.CheckedChanged += new System.EventHandler(this.QuietModeCheckbox_CheckedChanged);
			// 
			// AcksEnabledCheckbox
			// 
			this.AcksEnabledCheckbox.AutoSize = true;
			this.AcksEnabledCheckbox.Checked = true;
			this.AcksEnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AcksEnabledCheckbox.Location = new System.Drawing.Point(98, 179);
			this.AcksEnabledCheckbox.Name = "AcksEnabledCheckbox";
			this.AcksEnabledCheckbox.Size = new System.Drawing.Size(92, 17);
			this.AcksEnabledCheckbox.TabIndex = 15;
			this.AcksEnabledCheckbox.Text = "Acks Enabled";
			this.AcksEnabledCheckbox.UseVisualStyleBackColor = true;
			this.AcksEnabledCheckbox.CheckedChanged += new System.EventHandler(this.AcksEnabledCheckbox_CheckedChanged);
			// 
			// EncryptionReadyLabel
			// 
			this.EncryptionReadyLabel.AutoSize = true;
			this.EncryptionReadyLabel.ForeColor = System.Drawing.Color.DarkGreen;
			this.EncryptionReadyLabel.Location = new System.Drawing.Point(146, 57);
			this.EncryptionReadyLabel.Name = "EncryptionReadyLabel";
			this.EncryptionReadyLabel.Size = new System.Drawing.Size(102, 13);
			this.EncryptionReadyLabel.TabIndex = 14;
			this.EncryptionReadyLabel.Text = "✓ Encryption Ready";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(230, 84);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 13);
			this.label15.TabIndex = 13;
			this.label15.Text = "FHSS Table";
			// 
			// FhssTableNumeric
			// 
			this.FhssTableNumeric.Location = new System.Drawing.Point(233, 101);
			this.FhssTableNumeric.Name = "FhssTableNumeric";
			this.FhssTableNumeric.Size = new System.Drawing.Size(62, 20);
			this.FhssTableNumeric.TabIndex = 12;
			this.FhssTableNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FhssTableNumeric.ValueChanged += new System.EventHandler(this.FhssTableNumeric_ValueChanged);
			// 
			// PolarityCombobox
			// 
			this.PolarityCombobox.FormattingEnabled = true;
			this.PolarityCombobox.Items.AddRange(new object[] {
            "Disabled",
            "Up",
            "Down"});
			this.PolarityCombobox.Location = new System.Drawing.Point(147, 100);
			this.PolarityCombobox.Name = "PolarityCombobox";
			this.PolarityCombobox.Size = new System.Drawing.Size(80, 21);
			this.PolarityCombobox.TabIndex = 11;
			this.PolarityCombobox.Text = "Disabled";
			this.PolarityCombobox.SelectedIndexChanged += new System.EventHandler(this.PolarityCombobox_SelectedIndexChanged);
			// 
			// BandwidthCombobox
			// 
			this.BandwidthCombobox.Enabled = false;
			this.BandwidthCombobox.FormattingEnabled = true;
			this.BandwidthCombobox.Items.AddRange(new object[] {
            "31.25 kHz",
            "62.5 kHz",
            "125 kHz",
            "250 kHz",
            "500 kHz"});
			this.BandwidthCombobox.Location = new System.Drawing.Point(283, 141);
			this.BandwidthCombobox.Name = "BandwidthCombobox";
			this.BandwidthCombobox.Size = new System.Drawing.Size(110, 21);
			this.BandwidthCombobox.TabIndex = 10;
			this.BandwidthCombobox.Text = "500 kHz";
			this.BandwidthCombobox.SelectedIndexChanged += new System.EventHandler(this.BandwidthCombobox_SelectedIndexChanged);
			// 
			// SpreadingFactorCombobox
			// 
			this.SpreadingFactorCombobox.Enabled = false;
			this.SpreadingFactorCombobox.FormattingEnabled = true;
			this.SpreadingFactorCombobox.Items.AddRange(new object[] {
            "SF7",
            "SF8",
            "SF9",
            "SF10",
            "SF11",
            "SF12"});
			this.SpreadingFactorCombobox.Location = new System.Drawing.Point(178, 141);
			this.SpreadingFactorCombobox.Name = "SpreadingFactorCombobox";
			this.SpreadingFactorCombobox.Size = new System.Drawing.Size(99, 21);
			this.SpreadingFactorCombobox.TabIndex = 9;
			this.SpreadingFactorCombobox.Text = "SF11";
			this.SpreadingFactorCombobox.SelectedIndexChanged += new System.EventHandler(this.SpreadingFactorCombobox_SelectedIndexChanged);
			// 
			// RadioModeCombobox
			// 
			this.RadioModeCombobox.FormattingEnabled = true;
			this.RadioModeCombobox.Items.AddRange(new object[] {
            "Mode 1 (Longest Range)",
            "Mode 2 (Long Range)",
            "Mode 3 (Mid Range)",
            "Mode 4 (Short Range)",
            "Custom"});
			this.RadioModeCombobox.Location = new System.Drawing.Point(30, 141);
			this.RadioModeCombobox.Name = "RadioModeCombobox";
			this.RadioModeCombobox.Size = new System.Drawing.Size(142, 21);
			this.RadioModeCombobox.TabIndex = 8;
			this.RadioModeCombobox.Text = "Mode 2 (Long Range)";
			this.RadioModeCombobox.SelectedIndexChanged += new System.EventHandler(this.RadioModeCombobox_SelectedIndexChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(283, 125);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(57, 13);
			this.label13.TabIndex = 7;
			this.label13.Text = "Bandwidth";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(178, 125);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Spreading Factor";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(30, 125);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 13);
			this.label11.TabIndex = 7;
			this.label11.Text = "Radio Mode";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(28, 84);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 13);
			this.label14.TabIndex = 7;
			this.label14.Text = "Transmit Power";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(147, 84);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 7;
			this.label10.Text = "Polarity";
			// 
			// TransmitPowerCombobox
			// 
			this.TransmitPowerCombobox.FormattingEnabled = true;
			this.TransmitPowerCombobox.Items.AddRange(new object[] {
            "0 dBm (1 mW)",
            "1 dBm",
            "2 dBm",
            "3 dBm",
            "4 dBm",
            "5 dBm",
            "6 dBm",
            "7 dBm",
            "8 dBm",
            "9 dBm",
            "10 dBm (10 mW)",
            "11 dBm",
            "12 dBm",
            "13 dBm",
            "14 dBm",
            "15 dBm",
            "16 dBm",
            "17 dBm",
            "18 dBm",
            "19 dBm",
            "20 dBm",
            "21 dBm (1/8 W)",
            "22 dBm",
            "23 dBm",
            "24 dBm (1/4 W)",
            "25 dBm",
            "26 dBm",
            "27 dBm (1/2 W)",
            "28 dBm",
            "29 dBm",
            "30 dBm (1 W)"});
			this.TransmitPowerCombobox.Location = new System.Drawing.Point(30, 100);
			this.TransmitPowerCombobox.Name = "TransmitPowerCombobox";
			this.TransmitPowerCombobox.Size = new System.Drawing.Size(111, 21);
			this.TransmitPowerCombobox.TabIndex = 6;
			this.TransmitPowerCombobox.Text = "30 dBm (1 W)";
			this.TransmitPowerCombobox.SelectedIndexChanged += new System.EventHandler(this.TransmitPowerCombobox_SelectedIndexChanged);
			// 
			// RxPacketSizeLabel
			// 
			this.RxPacketSizeLabel.AutoSize = true;
			this.RxPacketSizeLabel.Location = new System.Drawing.Point(226, 27);
			this.RxPacketSizeLabel.Name = "RxPacketSizeLabel";
			this.RxPacketSizeLabel.Size = new System.Drawing.Size(174, 13);
			this.RxPacketSizeLabel.TabIndex = 5;
			this.RxPacketSizeLabel.Text = "64 bytes (ReceivePacketSize = 62)";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(132, 26);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(13, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "+";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "# Retries";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(214, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "=";
			// 
			// NumRetriesNumeric
			// 
			this.NumRetriesNumeric.Location = new System.Drawing.Point(30, 178);
			this.NumRetriesNumeric.Name = "NumRetriesNumeric";
			this.NumRetriesNumeric.Size = new System.Drawing.Size(62, 20);
			this.NumRetriesNumeric.TabIndex = 9;
			this.NumRetriesNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumRetriesNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.NumRetriesNumeric.ValueChanged += new System.EventHandler(this.NumRetriesNumeric_ValueChanged);
			// 
			// PayloadSizeNumeric
			// 
			this.PayloadSizeNumeric.Location = new System.Drawing.Point(147, 23);
			this.PayloadSizeNumeric.Name = "PayloadSizeNumeric";
			this.PayloadSizeNumeric.Size = new System.Drawing.Size(65, 20);
			this.PayloadSizeNumeric.TabIndex = 3;
			this.PayloadSizeNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PayloadSizeNumeric.ValueChanged += new System.EventHandler(this.PayloadSizeNumeric_ValueChanged);
			// 
			// RxUidLengthLabel
			// 
			this.RxUidLengthLabel.AutoSize = true;
			this.RxUidLengthLabel.Location = new System.Drawing.Point(89, 6);
			this.RxUidLengthLabel.Name = "RxUidLengthLabel";
			this.RxUidLengthLabel.Size = new System.Drawing.Size(41, 13);
			this.RxUidLengthLabel.TabIndex = 2;
			this.RxUidLengthLabel.Text = "3 bytes";
			// 
			// TxUidLengthLabel
			// 
			this.TxUidLengthLabel.AutoSize = true;
			this.TxUidLengthLabel.Location = new System.Drawing.Point(89, 45);
			this.TxUidLengthLabel.Name = "TxUidLengthLabel";
			this.TxUidLengthLabel.Size = new System.Drawing.Size(41, 13);
			this.TxUidLengthLabel.TabIndex = 2;
			this.TxUidLengthLabel.Text = "3 bytes";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(144, 7);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Payload Size";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(28, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Tx UID";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Rx UID";
			// 
			// TxUidTextbox
			// 
			this.TxUidTextbox.Location = new System.Drawing.Point(30, 61);
			this.TxUidTextbox.Name = "TxUidTextbox";
			this.TxUidTextbox.Size = new System.Drawing.Size(100, 20);
			this.TxUidTextbox.TabIndex = 0;
			this.TxUidTextbox.Text = "200001";
			this.TxUidTextbox.TextChanged += new System.EventHandler(this.TxUidTextbox_TextChanged);
			this.TxUidTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxUidTextbox_KeyDown);
			this.TxUidTextbox.Leave += new System.EventHandler(this.TxUidTextbox_Leave);
			// 
			// RxUidTextbox
			// 
			this.RxUidTextbox.Location = new System.Drawing.Point(30, 22);
			this.RxUidTextbox.Name = "RxUidTextbox";
			this.RxUidTextbox.Size = new System.Drawing.Size(100, 20);
			this.RxUidTextbox.TabIndex = 0;
			this.RxUidTextbox.Text = "100001";
			this.RxUidTextbox.TextChanged += new System.EventHandler(this.RxUidTextbox_TextChanged);
			this.RxUidTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RxUidTextbox_KeyDown);
			this.RxUidTextbox.Leave += new System.EventHandler(this.RxUidTextbox_Leave);
			// 
			// TabPageOther
			// 
			this.TabPageOther.Controls.Add(this.ClearIndicationsButton);
			this.TabPageOther.Controls.Add(this.label24);
			this.TabPageOther.Controls.Add(this.LedCombo1);
			this.TabPageOther.Controls.Add(this.LedLabel1);
			this.TabPageOther.Controls.Add(this.LedCombo2);
			this.TabPageOther.Controls.Add(this.LedLabel2);
			this.TabPageOther.Controls.Add(this.LedCombo3);
			this.TabPageOther.Controls.Add(this.LedLabel3);
			this.TabPageOther.Controls.Add(this.LedCombo4);
			this.TabPageOther.Controls.Add(this.LedLabel4);
			this.TabPageOther.Controls.Add(this.LedCombo5);
			this.TabPageOther.Controls.Add(this.LedLabel5);
			this.TabPageOther.Controls.Add(this.LedCombo6);
			this.TabPageOther.Controls.Add(this.LedLabel6);
			this.TabPageOther.Controls.Add(this.label22);
			this.TabPageOther.Controls.Add(this.label21);
			this.TabPageOther.Controls.Add(this.TxLedModeCombobox);
			this.TabPageOther.Controls.Add(this.RxLedModeCombobox);
			this.TabPageOther.Controls.Add(this.label20);
			this.TabPageOther.Controls.Add(this.label19);
			this.TabPageOther.Controls.Add(this.label18);
			this.TabPageOther.Controls.Add(this.ButtonConfigCombobox);
			this.TabPageOther.Controls.Add(this.ButtonHoldTimeNumeric);
			this.TabPageOther.Controls.Add(this.label17);
			this.TabPageOther.Controls.Add(this.QosConfigCombobox);
			this.TabPageOther.Location = new System.Drawing.Point(4, 22);
			this.TabPageOther.Name = "TabPageOther";
			this.TabPageOther.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageOther.Size = new System.Drawing.Size(568, 332);
			this.TabPageOther.TabIndex = 1;
			this.TabPageOther.Text = "Other Settings";
			this.TabPageOther.UseVisualStyleBackColor = true;
			// 
			// ClearIndicationsButton
			// 
			this.ClearIndicationsButton.Location = new System.Drawing.Point(8, 170);
			this.ClearIndicationsButton.Name = "ClearIndicationsButton";
			this.ClearIndicationsButton.Size = new System.Drawing.Size(104, 23);
			this.ClearIndicationsButton.TabIndex = 14;
			this.ClearIndicationsButton.Text = "All Off";
			this.ClearIndicationsButton.UseVisualStyleBackColor = true;
			this.ClearIndicationsButton.Click += new System.EventHandler(this.ClearIndicationsButton_Click);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(6, 6);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(58, 13);
			this.label24.TabIndex = 13;
			this.label24.Text = "Indications";
			// 
			// LedCombo1
			// 
			this.LedCombo1.FormattingEnabled = true;
			this.LedCombo1.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo1.Location = new System.Drawing.Point(29, 143);
			this.LedCombo1.Name = "LedCombo1";
			this.LedCombo1.Size = new System.Drawing.Size(83, 21);
			this.LedCombo1.TabIndex = 12;
			this.LedCombo1.Text = "Off";
			this.LedCombo1.SelectedIndexChanged += new System.EventHandler(this.LedCombo1_SelectedIndexChanged);
			// 
			// LedLabel1
			// 
			this.LedLabel1.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel1.Location = new System.Drawing.Point(8, 143);
			this.LedLabel1.Name = "LedLabel1";
			this.LedLabel1.Size = new System.Drawing.Size(21, 21);
			this.LedLabel1.TabIndex = 11;
			this.LedLabel1.Text = "0";
			this.LedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LedCombo2
			// 
			this.LedCombo2.FormattingEnabled = true;
			this.LedCombo2.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo2.Location = new System.Drawing.Point(29, 118);
			this.LedCombo2.Name = "LedCombo2";
			this.LedCombo2.Size = new System.Drawing.Size(83, 21);
			this.LedCombo2.TabIndex = 12;
			this.LedCombo2.Text = "Off";
			this.LedCombo2.SelectedIndexChanged += new System.EventHandler(this.LedCombo2_SelectedIndexChanged);
			// 
			// LedLabel2
			// 
			this.LedLabel2.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel2.Location = new System.Drawing.Point(8, 118);
			this.LedLabel2.Name = "LedLabel2";
			this.LedLabel2.Size = new System.Drawing.Size(21, 21);
			this.LedLabel2.TabIndex = 11;
			this.LedLabel2.Text = "0";
			this.LedLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LedCombo3
			// 
			this.LedCombo3.FormattingEnabled = true;
			this.LedCombo3.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo3.Location = new System.Drawing.Point(29, 94);
			this.LedCombo3.Name = "LedCombo3";
			this.LedCombo3.Size = new System.Drawing.Size(83, 21);
			this.LedCombo3.TabIndex = 12;
			this.LedCombo3.Text = "Off";
			this.LedCombo3.SelectedIndexChanged += new System.EventHandler(this.LedCombo3_SelectedIndexChanged);
			// 
			// LedLabel3
			// 
			this.LedLabel3.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel3.Location = new System.Drawing.Point(8, 94);
			this.LedLabel3.Name = "LedLabel3";
			this.LedLabel3.Size = new System.Drawing.Size(21, 21);
			this.LedLabel3.TabIndex = 11;
			this.LedLabel3.Text = "0";
			this.LedLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LedCombo4
			// 
			this.LedCombo4.FormattingEnabled = true;
			this.LedCombo4.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo4.Location = new System.Drawing.Point(29, 70);
			this.LedCombo4.Name = "LedCombo4";
			this.LedCombo4.Size = new System.Drawing.Size(83, 21);
			this.LedCombo4.TabIndex = 12;
			this.LedCombo4.Text = "Off";
			this.LedCombo4.SelectedIndexChanged += new System.EventHandler(this.LedCombo4_SelectedIndexChanged);
			// 
			// LedLabel4
			// 
			this.LedLabel4.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel4.Location = new System.Drawing.Point(8, 70);
			this.LedLabel4.Name = "LedLabel4";
			this.LedLabel4.Size = new System.Drawing.Size(21, 21);
			this.LedLabel4.TabIndex = 11;
			this.LedLabel4.Text = "0";
			this.LedLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LedCombo5
			// 
			this.LedCombo5.FormattingEnabled = true;
			this.LedCombo5.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo5.Location = new System.Drawing.Point(29, 46);
			this.LedCombo5.Name = "LedCombo5";
			this.LedCombo5.Size = new System.Drawing.Size(83, 21);
			this.LedCombo5.TabIndex = 12;
			this.LedCombo5.Text = "Off";
			this.LedCombo5.SelectedIndexChanged += new System.EventHandler(this.LedCombo5_SelectedIndexChanged);
			// 
			// LedLabel5
			// 
			this.LedLabel5.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel5.Location = new System.Drawing.Point(8, 46);
			this.LedLabel5.Name = "LedLabel5";
			this.LedLabel5.Size = new System.Drawing.Size(21, 21);
			this.LedLabel5.TabIndex = 11;
			this.LedLabel5.Text = "0";
			this.LedLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LedCombo6
			// 
			this.LedCombo6.FormattingEnabled = true;
			this.LedCombo6.Items.AddRange(new object[] {
            "Off",
            "On",
            "Blink 1Hz",
            "Blink 2Hz",
            "Blink 1 Time",
            "Blink 2 Times",
            "Blink 3 Times",
            "Blink 4 Times"});
			this.LedCombo6.Location = new System.Drawing.Point(29, 22);
			this.LedCombo6.Name = "LedCombo6";
			this.LedCombo6.Size = new System.Drawing.Size(83, 21);
			this.LedCombo6.TabIndex = 12;
			this.LedCombo6.Text = "Off";
			this.LedCombo6.SelectedIndexChanged += new System.EventHandler(this.LedCombo6_SelectedIndexChanged);
			// 
			// LedLabel6
			// 
			this.LedLabel6.BackColor = System.Drawing.Color.Transparent;
			this.LedLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LedLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LedLabel6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LedLabel6.Location = new System.Drawing.Point(8, 22);
			this.LedLabel6.Name = "LedLabel6";
			this.LedLabel6.Size = new System.Drawing.Size(21, 21);
			this.LedLabel6.TabIndex = 11;
			this.LedLabel6.Text = "0";
			this.LedLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(225, 92);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(73, 13);
			this.label22.TabIndex = 10;
			this.label22.Text = "Tx LED Mode";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(124, 92);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(74, 13);
			this.label21.TabIndex = 10;
			this.label21.Text = "Rx LED Mode";
			// 
			// TxLedModeCombobox
			// 
			this.TxLedModeCombobox.FormattingEnabled = true;
			this.TxLedModeCombobox.Items.AddRange(new object[] {
            "Default",
            "During Tx"});
			this.TxLedModeCombobox.Location = new System.Drawing.Point(228, 108);
			this.TxLedModeCombobox.Name = "TxLedModeCombobox";
			this.TxLedModeCombobox.Size = new System.Drawing.Size(95, 21);
			this.TxLedModeCombobox.TabIndex = 9;
			this.TxLedModeCombobox.Text = "Default";
			this.TxLedModeCombobox.SelectedIndexChanged += new System.EventHandler(this.TxLedModeCombobox_SelectedIndexChanged);
			// 
			// RxLedModeCombobox
			// 
			this.RxLedModeCombobox.FormattingEnabled = true;
			this.RxLedModeCombobox.Items.AddRange(new object[] {
            "Default",
            "During Rx"});
			this.RxLedModeCombobox.Location = new System.Drawing.Point(127, 108);
			this.RxLedModeCombobox.Name = "RxLedModeCombobox";
			this.RxLedModeCombobox.Size = new System.Drawing.Size(95, 21);
			this.RxLedModeCombobox.TabIndex = 9;
			this.RxLedModeCombobox.Text = "Default";
			this.RxLedModeCombobox.SelectedIndexChanged += new System.EventHandler(this.RxLedModeCombobox_SelectedIndexChanged);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(227, 49);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(71, 13);
			this.label20.TabIndex = 8;
			this.label20.Text = "Button Config";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(124, 49);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(89, 13);
			this.label19.TabIndex = 7;
			this.label19.Text = "Button Hold Time";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(194, 68);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(24, 13);
			this.label18.TabIndex = 6;
			this.label18.Text = "sec";
			// 
			// ButtonConfigCombobox
			// 
			this.ButtonConfigCombobox.FormattingEnabled = true;
			this.ButtonConfigCombobox.Items.AddRange(new object[] {
            "No Action",
            "Send 0\'s",
            "Send Ack Data"});
			this.ButtonConfigCombobox.Location = new System.Drawing.Point(230, 64);
			this.ButtonConfigCombobox.Name = "ButtonConfigCombobox";
			this.ButtonConfigCombobox.Size = new System.Drawing.Size(121, 21);
			this.ButtonConfigCombobox.TabIndex = 5;
			this.ButtonConfigCombobox.Text = "No Action";
			this.ButtonConfigCombobox.SelectedIndexChanged += new System.EventHandler(this.ButtonConfigCombobox_SelectedIndexChanged);
			// 
			// ButtonHoldTimeNumeric
			// 
			this.ButtonHoldTimeNumeric.Location = new System.Drawing.Point(127, 65);
			this.ButtonHoldTimeNumeric.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.ButtonHoldTimeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ButtonHoldTimeNumeric.Name = "ButtonHoldTimeNumeric";
			this.ButtonHoldTimeNumeric.Size = new System.Drawing.Size(67, 20);
			this.ButtonHoldTimeNumeric.TabIndex = 4;
			this.ButtonHoldTimeNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ButtonHoldTimeNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ButtonHoldTimeNumeric.ValueChanged += new System.EventHandler(this.ButtonHoldTimeNumeric_ValueChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(123, 6);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(63, 13);
			this.label17.TabIndex = 3;
			this.label17.Text = "QOS Config";
			// 
			// QosConfigCombobox
			// 
			this.QosConfigCombobox.FormattingEnabled = true;
			this.QosConfigCombobox.Items.AddRange(new object[] {
            "Manual",
            "On Receive",
            "On Transmit",
            "On Rx and Tx",
            "On Ack Data",
            "On Rx and Ack"});
			this.QosConfigCombobox.Location = new System.Drawing.Point(126, 22);
			this.QosConfigCombobox.Name = "QosConfigCombobox";
			this.QosConfigCombobox.Size = new System.Drawing.Size(121, 21);
			this.QosConfigCombobox.TabIndex = 2;
			this.QosConfigCombobox.Text = "On Both";
			this.QosConfigCombobox.SelectedIndexChanged += new System.EventHandler(this.QosConfigCombobox_SelectedIndexChanged);
			// 
			// TabPageCommands
			// 
			this.TabPageCommands.Controls.Add(this.label25);
			this.TabPageCommands.Controls.Add(this.GetRegisteredSerialButton);
			this.TabPageCommands.Controls.Add(this.GetRandomNumberButton);
			this.TabPageCommands.Controls.Add(this.label23);
			this.TabPageCommands.Controls.Add(this.label28);
			this.TabPageCommands.Controls.Add(this.FirmwareVersionLabel);
			this.TabPageCommands.Controls.Add(this.RegisteredSerialLabel);
			this.TabPageCommands.Controls.Add(this.RandomNumberLabel);
			this.TabPageCommands.Controls.Add(this.TimeOnAirLabel);
			this.TabPageCommands.Controls.Add(this.MicroVersionLabel);
			this.TabPageCommands.Controls.Add(this.GetTimeOnAirButton);
			this.TabPageCommands.Controls.Add(this.HardwareVersionLabel);
			this.TabPageCommands.Controls.Add(this.GetModuleVersionButton);
			this.TabPageCommands.Controls.Add(this.label16);
			this.TabPageCommands.Controls.Add(this.ShowQosButton);
			this.TabPageCommands.Controls.Add(this.LightshowButton);
			this.TabPageCommands.Controls.Add(this.RefreshSettingsButton);
			this.TabPageCommands.Controls.Add(this.DefaultSettingsButton);
			this.TabPageCommands.Controls.Add(this.SleepButton);
			this.TabPageCommands.Controls.Add(this.ResetButton);
			this.TabPageCommands.Controls.Add(this.StartEncryptionButton);
			this.TabPageCommands.Location = new System.Drawing.Point(4, 22);
			this.TabPageCommands.Name = "TabPageCommands";
			this.TabPageCommands.Size = new System.Drawing.Size(568, 332);
			this.TabPageCommands.TabIndex = 4;
			this.TabPageCommands.Text = "Commands";
			this.TabPageCommands.UseVisualStyleBackColor = true;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(90, 265);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(108, 13);
			this.label25.TabIndex = 36;
			this.label25.Text = "Registered Serial:";
			// 
			// GetRegisteredSerialButton
			// 
			this.GetRegisteredSerialButton.Location = new System.Drawing.Point(9, 260);
			this.GetRegisteredSerialButton.Name = "GetRegisteredSerialButton";
			this.GetRegisteredSerialButton.Size = new System.Drawing.Size(75, 23);
			this.GetRegisteredSerialButton.TabIndex = 35;
			this.GetRegisteredSerialButton.Text = "Get";
			this.GetRegisteredSerialButton.UseVisualStyleBackColor = true;
			this.GetRegisteredSerialButton.Click += new System.EventHandler(this.GetRegisteredSerialButton_Click);
			// 
			// GetRandomNumberButton
			// 
			this.GetRandomNumberButton.Location = new System.Drawing.Point(9, 231);
			this.GetRandomNumberButton.Name = "GetRandomNumberButton";
			this.GetRandomNumberButton.Size = new System.Drawing.Size(75, 23);
			this.GetRandomNumberButton.TabIndex = 34;
			this.GetRandomNumberButton.Text = "Get";
			this.GetRandomNumberButton.UseVisualStyleBackColor = true;
			this.GetRandomNumberButton.Click += new System.EventHandler(this.GetRandomNumberButton_Click);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.Location = new System.Drawing.Point(90, 236);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(104, 13);
			this.label23.TabIndex = 33;
			this.label23.Text = "Random Number:";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.Location = new System.Drawing.Point(90, 207);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(121, 13);
			this.label28.TabIndex = 33;
			this.label28.Text = "Packet Time On Air:";
			// 
			// FirmwareVersionLabel
			// 
			this.FirmwareVersionLabel.AutoSize = true;
			this.FirmwareVersionLabel.Location = new System.Drawing.Point(90, 160);
			this.FirmwareVersionLabel.Name = "FirmwareVersionLabel";
			this.FirmwareVersionLabel.Size = new System.Drawing.Size(94, 13);
			this.FirmwareVersionLabel.TabIndex = 32;
			this.FirmwareVersionLabel.Text = "Firmware: 1.0(100)";
			// 
			// RegisteredSerialLabel
			// 
			this.RegisteredSerialLabel.AutoSize = true;
			this.RegisteredSerialLabel.Location = new System.Drawing.Point(197, 265);
			this.RegisteredSerialLabel.Name = "RegisteredSerialLabel";
			this.RegisteredSerialLabel.Size = new System.Drawing.Size(36, 13);
			this.RegisteredSerialLabel.TabIndex = 32;
			this.RegisteredSerialLabel.Text = "Empty";
			// 
			// RandomNumberLabel
			// 
			this.RandomNumberLabel.AutoSize = true;
			this.RandomNumberLabel.Location = new System.Drawing.Point(192, 237);
			this.RandomNumberLabel.Name = "RandomNumberLabel";
			this.RandomNumberLabel.Size = new System.Drawing.Size(66, 13);
			this.RandomNumberLabel.TabIndex = 32;
			this.RandomNumberLabel.Text = "0x00000000";
			// 
			// TimeOnAirLabel
			// 
			this.TimeOnAirLabel.AutoSize = true;
			this.TimeOnAirLabel.Location = new System.Drawing.Point(208, 208);
			this.TimeOnAirLabel.Name = "TimeOnAirLabel";
			this.TimeOnAirLabel.Size = new System.Drawing.Size(47, 13);
			this.TimeOnAirLabel.TabIndex = 32;
			this.TimeOnAirLabel.Text = "1234 ms";
			// 
			// MicroVersionLabel
			// 
			this.MicroVersionLabel.AutoSize = true;
			this.MicroVersionLabel.Location = new System.Drawing.Point(90, 186);
			this.MicroVersionLabel.Name = "MicroVersionLabel";
			this.MicroVersionLabel.Size = new System.Drawing.Size(124, 13);
			this.MicroVersionLabel.TabIndex = 32;
			this.MicroVersionLabel.Text = "Micro: 0x0000000 (0x00)";
			// 
			// GetTimeOnAirButton
			// 
			this.GetTimeOnAirButton.Location = new System.Drawing.Point(9, 202);
			this.GetTimeOnAirButton.Name = "GetTimeOnAirButton";
			this.GetTimeOnAirButton.Size = new System.Drawing.Size(75, 23);
			this.GetTimeOnAirButton.TabIndex = 31;
			this.GetTimeOnAirButton.Text = "Get";
			this.GetTimeOnAirButton.UseVisualStyleBackColor = true;
			this.GetTimeOnAirButton.Click += new System.EventHandler(this.GetTimeOnAirButton_Click);
			// 
			// HardwareVersionLabel
			// 
			this.HardwareVersionLabel.AutoSize = true;
			this.HardwareVersionLabel.Location = new System.Drawing.Point(90, 173);
			this.HardwareVersionLabel.Name = "HardwareVersionLabel";
			this.HardwareVersionLabel.Size = new System.Drawing.Size(74, 13);
			this.HardwareVersionLabel.TabIndex = 32;
			this.HardwareVersionLabel.Text = "Hardware: 1.0";
			// 
			// GetModuleVersionButton
			// 
			this.GetModuleVersionButton.Location = new System.Drawing.Point(9, 160);
			this.GetModuleVersionButton.Name = "GetModuleVersionButton";
			this.GetModuleVersionButton.Size = new System.Drawing.Size(75, 23);
			this.GetModuleVersionButton.TabIndex = 31;
			this.GetModuleVersionButton.Text = "Get";
			this.GetModuleVersionButton.UseVisualStyleBackColor = true;
			this.GetModuleVersionButton.Click += new System.EventHandler(this.GetModuleVersionButton_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(90, 147);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(98, 13);
			this.label16.TabIndex = 30;
			this.label16.Text = "Module Version:";
			// 
			// ShowQosButton
			// 
			this.ShowQosButton.Location = new System.Drawing.Point(160, 92);
			this.ShowQosButton.Name = "ShowQosButton";
			this.ShowQosButton.Size = new System.Drawing.Size(145, 23);
			this.ShowQosButton.TabIndex = 29;
			this.ShowQosButton.Text = "Show QOS";
			this.ShowQosButton.UseVisualStyleBackColor = true;
			this.ShowQosButton.Click += new System.EventHandler(this.ShowQosButton_Click);
			// 
			// LightshowButton
			// 
			this.LightshowButton.Location = new System.Drawing.Point(9, 92);
			this.LightshowButton.Name = "LightshowButton";
			this.LightshowButton.Size = new System.Drawing.Size(145, 23);
			this.LightshowButton.TabIndex = 28;
			this.LightshowButton.Text = "Lightshow";
			this.LightshowButton.UseVisualStyleBackColor = true;
			this.LightshowButton.Click += new System.EventHandler(this.LightshowButton_Click);
			// 
			// RefreshSettingsButton
			// 
			this.RefreshSettingsButton.Location = new System.Drawing.Point(9, 9);
			this.RefreshSettingsButton.Name = "RefreshSettingsButton";
			this.RefreshSettingsButton.Size = new System.Drawing.Size(145, 48);
			this.RefreshSettingsButton.TabIndex = 26;
			this.RefreshSettingsButton.Text = "Refresh Settings";
			this.RefreshSettingsButton.UseVisualStyleBackColor = true;
			this.RefreshSettingsButton.Click += new System.EventHandler(this.RefreshSettingsButton_Click);
			// 
			// DefaultSettingsButton
			// 
			this.DefaultSettingsButton.Location = new System.Drawing.Point(160, 9);
			this.DefaultSettingsButton.Name = "DefaultSettingsButton";
			this.DefaultSettingsButton.Size = new System.Drawing.Size(145, 48);
			this.DefaultSettingsButton.TabIndex = 27;
			this.DefaultSettingsButton.Text = "Default Settings";
			this.DefaultSettingsButton.UseVisualStyleBackColor = true;
			this.DefaultSettingsButton.Click += new System.EventHandler(this.DefaultSettingsButton_Click);
			// 
			// SleepButton
			// 
			this.SleepButton.Location = new System.Drawing.Point(9, 63);
			this.SleepButton.Name = "SleepButton";
			this.SleepButton.Size = new System.Drawing.Size(145, 23);
			this.SleepButton.TabIndex = 24;
			this.SleepButton.Text = "Sleep";
			this.SleepButton.UseVisualStyleBackColor = true;
			this.SleepButton.Click += new System.EventHandler(this.SleepButton_Click);
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(160, 63);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(145, 23);
			this.ResetButton.TabIndex = 25;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// StartEncryptionButton
			// 
			this.StartEncryptionButton.Location = new System.Drawing.Point(9, 121);
			this.StartEncryptionButton.Name = "StartEncryptionButton";
			this.StartEncryptionButton.Size = new System.Drawing.Size(296, 23);
			this.StartEncryptionButton.TabIndex = 23;
			this.StartEncryptionButton.Text = "Start Encryption";
			this.StartEncryptionButton.UseVisualStyleBackColor = true;
			this.StartEncryptionButton.Click += new System.EventHandler(this.StartEncryptionButton_Click);
			// 
			// TabPageStatus
			// 
			this.TabPageStatus.Controls.Add(this.GetStatusButton);
			this.TabPageStatus.Controls.Add(this.ClearFlagsButton);
			this.TabPageStatus.Controls.Add(this.AutoClearFlagsCheckbox);
			this.TabPageStatus.Controls.Add(this.StatusConfigLabel);
			this.TabPageStatus.Controls.Add(this.StatusClearableLabel);
			this.TabPageStatus.Controls.Add(this.StatusOtherLabel);
			this.TabPageStatus.Controls.Add(this.StatusStateLabel);
			this.TabPageStatus.Controls.Add(this.label70);
			this.TabPageStatus.Controls.Add(this.label85);
			this.TabPageStatus.Controls.Add(this.label69);
			this.TabPageStatus.Controls.Add(this.label37);
			this.TabPageStatus.Controls.Add(this.label68);
			this.TabPageStatus.Controls.Add(this.label83);
			this.TabPageStatus.Controls.Add(this.label67);
			this.TabPageStatus.Controls.Add(this.label45);
			this.TabPageStatus.Controls.Add(this.label29);
			this.TabPageStatus.Controls.Add(this.label26);
			this.TabPageStatus.Controls.Add(this.label36);
			this.TabPageStatus.Controls.Add(this.label66);
			this.TabPageStatus.Controls.Add(this.label81);
			this.TabPageStatus.Controls.Add(this.label65);
			this.TabPageStatus.Controls.Add(this.label44);
			this.TabPageStatus.Controls.Add(this.label35);
			this.TabPageStatus.Controls.Add(this.label80);
			this.TabPageStatus.Controls.Add(this.label64);
			this.TabPageStatus.Controls.Add(this.label79);
			this.TabPageStatus.Controls.Add(this.label63);
			this.TabPageStatus.Controls.Add(this.label43);
			this.TabPageStatus.Controls.Add(this.label34);
			this.TabPageStatus.Controls.Add(this.RadioStateStrLabel);
			this.TabPageStatus.Controls.Add(this.label32);
			this.TabPageStatus.Controls.Add(this.ButtonHeldBit);
			this.TabPageStatus.Controls.Add(this.TxLedModeBit);
			this.TabPageStatus.Controls.Add(this.AckPacketReadyBit);
			this.TabPageStatus.Controls.Add(this.SettingsPendingBit);
			this.TabPageStatus.Controls.Add(this.ButtonPressedBit);
			this.TabPageStatus.Controls.Add(this.RadioStateBit4);
			this.TabPageStatus.Controls.Add(this.RxLedModeBit);
			this.TabPageStatus.Controls.Add(this.RxPacketReadyBit);
			this.TabPageStatus.Controls.Add(this.ButtonDownBit);
			this.TabPageStatus.Controls.Add(this.RxInProgressBit);
			this.TabPageStatus.Controls.Add(this.EncryptionRekeyBit);
			this.TabPageStatus.Controls.Add(this.AutoClearFlagsBit);
			this.TabPageStatus.Controls.Add(this.RadioStateBit3);
			this.TabPageStatus.Controls.Add(this.TransmitFinishedBit);
			this.TabPageStatus.Controls.Add(this.AutoRekeyBit);
			this.TabPageStatus.Controls.Add(this.ChecksumErrorBit);
			this.TabPageStatus.Controls.Add(this.ShowingQosBit);
			this.TabPageStatus.Controls.Add(this.InterruptDrivenBit);
			this.TabPageStatus.Controls.Add(this.WasResetBit);
			this.TabPageStatus.Controls.Add(this.EncryptionActiveBit);
			this.TabPageStatus.Controls.Add(this.DoingLightshowBit);
			this.TabPageStatus.Controls.Add(this.RadioStateBit2);
			this.TabPageStatus.Controls.Add(this.OnBaseTableBit);
			this.TabPageStatus.Controls.Add(this.ChangingTablesBit);
			this.TabPageStatus.Controls.Add(this.BusyBit);
			this.TabPageStatus.Controls.Add(this.RadioStateBit1);
			this.TabPageStatus.Location = new System.Drawing.Point(4, 22);
			this.TabPageStatus.Name = "TabPageStatus";
			this.TabPageStatus.Size = new System.Drawing.Size(568, 332);
			this.TabPageStatus.TabIndex = 2;
			this.TabPageStatus.Text = "Status";
			this.TabPageStatus.UseVisualStyleBackColor = true;
			// 
			// GetStatusButton
			// 
			this.GetStatusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.GetStatusButton.Location = new System.Drawing.Point(462, 284);
			this.GetStatusButton.Name = "GetStatusButton";
			this.GetStatusButton.Size = new System.Drawing.Size(103, 23);
			this.GetStatusButton.TabIndex = 23;
			this.GetStatusButton.Text = "Get Status";
			this.GetStatusButton.UseVisualStyleBackColor = true;
			this.GetStatusButton.Click += new System.EventHandler(this.GetStatusButton_Click);
			// 
			// ClearFlagsButton
			// 
			this.ClearFlagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearFlagsButton.Location = new System.Drawing.Point(462, 255);
			this.ClearFlagsButton.Name = "ClearFlagsButton";
			this.ClearFlagsButton.Size = new System.Drawing.Size(103, 23);
			this.ClearFlagsButton.TabIndex = 22;
			this.ClearFlagsButton.Text = "Clear Flags";
			this.ClearFlagsButton.UseVisualStyleBackColor = true;
			this.ClearFlagsButton.Click += new System.EventHandler(this.ClearFlagsButton_Click);
			// 
			// AutoClearFlagsCheckbox
			// 
			this.AutoClearFlagsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AutoClearFlagsCheckbox.AutoSize = true;
			this.AutoClearFlagsCheckbox.Location = new System.Drawing.Point(462, 238);
			this.AutoClearFlagsCheckbox.Name = "AutoClearFlagsCheckbox";
			this.AutoClearFlagsCheckbox.Size = new System.Drawing.Size(103, 17);
			this.AutoClearFlagsCheckbox.TabIndex = 21;
			this.AutoClearFlagsCheckbox.Text = "Auto-Clear Flags";
			this.AutoClearFlagsCheckbox.UseVisualStyleBackColor = true;
			this.AutoClearFlagsCheckbox.CheckedChanged += new System.EventHandler(this.AutoClearFlagsCheckbox_CheckedChanged);
			// 
			// StatusConfigLabel
			// 
			this.StatusConfigLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.StatusConfigLabel.AutoSize = true;
			this.StatusConfigLabel.Location = new System.Drawing.Point(376, 313);
			this.StatusConfigLabel.Name = "StatusConfigLabel";
			this.StatusConfigLabel.Size = new System.Drawing.Size(66, 13);
			this.StatusConfigLabel.TabIndex = 20;
			this.StatusConfigLabel.Text = "Config: 0x00";
			// 
			// StatusClearableLabel
			// 
			this.StatusClearableLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.StatusClearableLabel.AutoSize = true;
			this.StatusClearableLabel.Location = new System.Drawing.Point(246, 313);
			this.StatusClearableLabel.Name = "StatusClearableLabel";
			this.StatusClearableLabel.Size = new System.Drawing.Size(80, 13);
			this.StatusClearableLabel.TabIndex = 20;
			this.StatusClearableLabel.Text = "Clearable: 0x00";
			// 
			// StatusOtherLabel
			// 
			this.StatusOtherLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.StatusOtherLabel.AutoSize = true;
			this.StatusOtherLabel.Location = new System.Drawing.Point(126, 313);
			this.StatusOtherLabel.Name = "StatusOtherLabel";
			this.StatusOtherLabel.Size = new System.Drawing.Size(62, 13);
			this.StatusOtherLabel.TabIndex = 20;
			this.StatusOtherLabel.Text = "Other: 0x00";
			// 
			// StatusStateLabel
			// 
			this.StatusStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.StatusStateLabel.AutoSize = true;
			this.StatusStateLabel.Location = new System.Drawing.Point(8, 313);
			this.StatusStateLabel.Name = "StatusStateLabel";
			this.StatusStateLabel.Size = new System.Drawing.Size(61, 13);
			this.StatusStateLabel.TabIndex = 19;
			this.StatusStateLabel.Text = "State: 0x00";
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(275, 180);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(63, 13);
			this.label70.TabIndex = 18;
			this.label70.Text = "Button Held";
			// 
			// label85
			// 
			this.label85.AutoSize = true;
			this.label85.Location = new System.Drawing.Point(406, 81);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(73, 13);
			this.label85.TabIndex = 18;
			this.label85.Text = "Tx LED Mode";
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.Location = new System.Drawing.Point(275, 80);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(97, 13);
			this.label69.TabIndex = 18;
			this.label69.Text = "Ack Packet Ready";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(156, 111);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(87, 13);
			this.label37.TabIndex = 18;
			this.label37.Text = "Settings Pending";
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Location = new System.Drawing.Point(275, 157);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(79, 13);
			this.label68.TabIndex = 17;
			this.label68.Text = "Button Pressed";
			// 
			// label83
			// 
			this.label83.AutoSize = true;
			this.label83.Location = new System.Drawing.Point(406, 58);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(74, 13);
			this.label83.TabIndex = 17;
			this.label83.Text = "Rx LED Mode";
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(275, 57);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(91, 13);
			this.label67.TabIndex = 17;
			this.label67.Text = "Rx Packet Ready";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(156, 57);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(69, 13);
			this.label45.TabIndex = 17;
			this.label45.Text = "Button Down";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(35, 181);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(78, 13);
			this.label29.TabIndex = 17;
			this.label29.Text = "On Base Table";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(35, 135);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(87, 13);
			this.label26.TabIndex = 17;
			this.label26.Text = "Changing Tables";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(35, 158);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(76, 13);
			this.label36.TabIndex = 17;
			this.label36.Text = "Rx In Progress";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(275, 134);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(91, 13);
			this.label66.TabIndex = 16;
			this.label66.Text = "Encryption Rekey";
			// 
			// label81
			// 
			this.label81.AutoSize = true;
			this.label81.Location = new System.Drawing.Point(406, 35);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(84, 13);
			this.label81.TabIndex = 16;
			this.label81.Text = "Auto-Clear Flags";
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(275, 34);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(89, 13);
			this.label65.TabIndex = 16;
			this.label65.Text = "Transmit Finished";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(156, 34);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(74, 13);
			this.label44.TabIndex = 16;
			this.label44.Text = "Showing QOS";
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(156, 80);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(90, 13);
			this.label35.TabIndex = 16;
			this.label35.Text = "Encryption Active";
			// 
			// label80
			// 
			this.label80.AutoSize = true;
			this.label80.Location = new System.Drawing.Point(406, 112);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(63, 13);
			this.label80.TabIndex = 15;
			this.label80.Text = "Auto Rekey";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(275, 111);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(82, 13);
			this.label64.TabIndex = 15;
			this.label64.Text = "Checksum Error";
			// 
			// label79
			// 
			this.label79.AutoSize = true;
			this.label79.Location = new System.Drawing.Point(406, 12);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(80, 13);
			this.label79.TabIndex = 15;
			this.label79.Text = "Interrupt Driven";
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(275, 11);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(60, 13);
			this.label63.TabIndex = 15;
			this.label63.Text = "Was Reset";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(156, 11);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(86, 13);
			this.label43.TabIndex = 15;
			this.label43.Text = "Doing Lightshow";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(35, 112);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(30, 13);
			this.label34.TabIndex = 15;
			this.label34.Text = "Busy";
			// 
			// RadioStateStrLabel
			// 
			this.RadioStateStrLabel.AutoSize = true;
			this.RadioStateStrLabel.Location = new System.Drawing.Point(44, 41);
			this.RadioStateStrLabel.Name = "RadioStateStrLabel";
			this.RadioStateStrLabel.Size = new System.Drawing.Size(55, 13);
			this.RadioStateStrLabel.TabIndex = 14;
			this.RadioStateStrLabel.Text = "Receiving";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.Location = new System.Drawing.Point(35, 26);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(74, 13);
			this.label32.TabIndex = 13;
			this.label32.Text = "RadioState:";
			// 
			// ButtonHeldBit
			// 
			this.ButtonHeldBit.BackColor = System.Drawing.Color.Transparent;
			this.ButtonHeldBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ButtonHeldBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonHeldBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ButtonHeldBit.Location = new System.Drawing.Point(248, 176);
			this.ButtonHeldBit.Name = "ButtonHeldBit";
			this.ButtonHeldBit.Size = new System.Drawing.Size(21, 21);
			this.ButtonHeldBit.TabIndex = 12;
			this.ButtonHeldBit.Text = "0";
			this.ButtonHeldBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TxLedModeBit
			// 
			this.TxLedModeBit.BackColor = System.Drawing.Color.Transparent;
			this.TxLedModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxLedModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxLedModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxLedModeBit.Location = new System.Drawing.Point(379, 77);
			this.TxLedModeBit.Name = "TxLedModeBit";
			this.TxLedModeBit.Size = new System.Drawing.Size(21, 21);
			this.TxLedModeBit.TabIndex = 12;
			this.TxLedModeBit.Text = "0";
			this.TxLedModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AckPacketReadyBit
			// 
			this.AckPacketReadyBit.BackColor = System.Drawing.Color.Transparent;
			this.AckPacketReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AckPacketReadyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckPacketReadyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AckPacketReadyBit.Location = new System.Drawing.Point(248, 76);
			this.AckPacketReadyBit.Name = "AckPacketReadyBit";
			this.AckPacketReadyBit.Size = new System.Drawing.Size(21, 21);
			this.AckPacketReadyBit.TabIndex = 12;
			this.AckPacketReadyBit.Text = "0";
			this.AckPacketReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SettingsPendingBit
			// 
			this.SettingsPendingBit.BackColor = System.Drawing.Color.Transparent;
			this.SettingsPendingBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SettingsPendingBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SettingsPendingBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SettingsPendingBit.Location = new System.Drawing.Point(129, 107);
			this.SettingsPendingBit.Name = "SettingsPendingBit";
			this.SettingsPendingBit.Size = new System.Drawing.Size(21, 21);
			this.SettingsPendingBit.TabIndex = 12;
			this.SettingsPendingBit.Text = "0";
			this.SettingsPendingBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonPressedBit
			// 
			this.ButtonPressedBit.BackColor = System.Drawing.Color.Transparent;
			this.ButtonPressedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ButtonPressedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonPressedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ButtonPressedBit.Location = new System.Drawing.Point(248, 153);
			this.ButtonPressedBit.Name = "ButtonPressedBit";
			this.ButtonPressedBit.Size = new System.Drawing.Size(21, 21);
			this.ButtonPressedBit.TabIndex = 12;
			this.ButtonPressedBit.Text = "0";
			this.ButtonPressedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadioStateBit4
			// 
			this.RadioStateBit4.BackColor = System.Drawing.Color.Transparent;
			this.RadioStateBit4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RadioStateBit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RadioStateBit4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioStateBit4.Location = new System.Drawing.Point(8, 67);
			this.RadioStateBit4.Name = "RadioStateBit4";
			this.RadioStateBit4.Size = new System.Drawing.Size(21, 21);
			this.RadioStateBit4.TabIndex = 12;
			this.RadioStateBit4.Text = "0";
			this.RadioStateBit4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RxLedModeBit
			// 
			this.RxLedModeBit.BackColor = System.Drawing.Color.Transparent;
			this.RxLedModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RxLedModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxLedModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RxLedModeBit.Location = new System.Drawing.Point(379, 54);
			this.RxLedModeBit.Name = "RxLedModeBit";
			this.RxLedModeBit.Size = new System.Drawing.Size(21, 21);
			this.RxLedModeBit.TabIndex = 12;
			this.RxLedModeBit.Text = "0";
			this.RxLedModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RxPacketReadyBit
			// 
			this.RxPacketReadyBit.BackColor = System.Drawing.Color.Transparent;
			this.RxPacketReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RxPacketReadyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxPacketReadyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RxPacketReadyBit.Location = new System.Drawing.Point(248, 53);
			this.RxPacketReadyBit.Name = "RxPacketReadyBit";
			this.RxPacketReadyBit.Size = new System.Drawing.Size(21, 21);
			this.RxPacketReadyBit.TabIndex = 12;
			this.RxPacketReadyBit.Text = "0";
			this.RxPacketReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonDownBit
			// 
			this.ButtonDownBit.BackColor = System.Drawing.Color.Transparent;
			this.ButtonDownBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ButtonDownBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonDownBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ButtonDownBit.Location = new System.Drawing.Point(129, 53);
			this.ButtonDownBit.Name = "ButtonDownBit";
			this.ButtonDownBit.Size = new System.Drawing.Size(21, 21);
			this.ButtonDownBit.TabIndex = 12;
			this.ButtonDownBit.Text = "0";
			this.ButtonDownBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RxInProgressBit
			// 
			this.RxInProgressBit.BackColor = System.Drawing.Color.Transparent;
			this.RxInProgressBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RxInProgressBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxInProgressBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RxInProgressBit.Location = new System.Drawing.Point(8, 154);
			this.RxInProgressBit.Name = "RxInProgressBit";
			this.RxInProgressBit.Size = new System.Drawing.Size(21, 21);
			this.RxInProgressBit.TabIndex = 12;
			this.RxInProgressBit.Text = "0";
			this.RxInProgressBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EncryptionRekeyBit
			// 
			this.EncryptionRekeyBit.BackColor = System.Drawing.Color.Transparent;
			this.EncryptionRekeyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EncryptionRekeyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EncryptionRekeyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EncryptionRekeyBit.Location = new System.Drawing.Point(248, 130);
			this.EncryptionRekeyBit.Name = "EncryptionRekeyBit";
			this.EncryptionRekeyBit.Size = new System.Drawing.Size(21, 21);
			this.EncryptionRekeyBit.TabIndex = 12;
			this.EncryptionRekeyBit.Text = "0";
			this.EncryptionRekeyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AutoClearFlagsBit
			// 
			this.AutoClearFlagsBit.BackColor = System.Drawing.Color.Transparent;
			this.AutoClearFlagsBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AutoClearFlagsBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AutoClearFlagsBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AutoClearFlagsBit.Location = new System.Drawing.Point(379, 31);
			this.AutoClearFlagsBit.Name = "AutoClearFlagsBit";
			this.AutoClearFlagsBit.Size = new System.Drawing.Size(21, 21);
			this.AutoClearFlagsBit.TabIndex = 12;
			this.AutoClearFlagsBit.Text = "0";
			this.AutoClearFlagsBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadioStateBit3
			// 
			this.RadioStateBit3.BackColor = System.Drawing.Color.Transparent;
			this.RadioStateBit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RadioStateBit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RadioStateBit3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioStateBit3.Location = new System.Drawing.Point(8, 47);
			this.RadioStateBit3.Name = "RadioStateBit3";
			this.RadioStateBit3.Size = new System.Drawing.Size(21, 21);
			this.RadioStateBit3.TabIndex = 12;
			this.RadioStateBit3.Text = "0";
			this.RadioStateBit3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TransmitFinishedBit
			// 
			this.TransmitFinishedBit.BackColor = System.Drawing.Color.Transparent;
			this.TransmitFinishedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TransmitFinishedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TransmitFinishedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TransmitFinishedBit.Location = new System.Drawing.Point(248, 30);
			this.TransmitFinishedBit.Name = "TransmitFinishedBit";
			this.TransmitFinishedBit.Size = new System.Drawing.Size(21, 21);
			this.TransmitFinishedBit.TabIndex = 12;
			this.TransmitFinishedBit.Text = "0";
			this.TransmitFinishedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AutoRekeyBit
			// 
			this.AutoRekeyBit.BackColor = System.Drawing.Color.Transparent;
			this.AutoRekeyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AutoRekeyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AutoRekeyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AutoRekeyBit.Location = new System.Drawing.Point(379, 108);
			this.AutoRekeyBit.Name = "AutoRekeyBit";
			this.AutoRekeyBit.Size = new System.Drawing.Size(21, 21);
			this.AutoRekeyBit.TabIndex = 12;
			this.AutoRekeyBit.Text = "0";
			this.AutoRekeyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ChecksumErrorBit
			// 
			this.ChecksumErrorBit.BackColor = System.Drawing.Color.Transparent;
			this.ChecksumErrorBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ChecksumErrorBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChecksumErrorBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChecksumErrorBit.Location = new System.Drawing.Point(248, 107);
			this.ChecksumErrorBit.Name = "ChecksumErrorBit";
			this.ChecksumErrorBit.Size = new System.Drawing.Size(21, 21);
			this.ChecksumErrorBit.TabIndex = 12;
			this.ChecksumErrorBit.Text = "0";
			this.ChecksumErrorBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ShowingQosBit
			// 
			this.ShowingQosBit.BackColor = System.Drawing.Color.Transparent;
			this.ShowingQosBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ShowingQosBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowingQosBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowingQosBit.Location = new System.Drawing.Point(129, 30);
			this.ShowingQosBit.Name = "ShowingQosBit";
			this.ShowingQosBit.Size = new System.Drawing.Size(21, 21);
			this.ShowingQosBit.TabIndex = 12;
			this.ShowingQosBit.Text = "0";
			this.ShowingQosBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// InterruptDrivenBit
			// 
			this.InterruptDrivenBit.BackColor = System.Drawing.Color.Transparent;
			this.InterruptDrivenBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.InterruptDrivenBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InterruptDrivenBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.InterruptDrivenBit.Location = new System.Drawing.Point(379, 8);
			this.InterruptDrivenBit.Name = "InterruptDrivenBit";
			this.InterruptDrivenBit.Size = new System.Drawing.Size(21, 21);
			this.InterruptDrivenBit.TabIndex = 12;
			this.InterruptDrivenBit.Text = "0";
			this.InterruptDrivenBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WasResetBit
			// 
			this.WasResetBit.BackColor = System.Drawing.Color.Transparent;
			this.WasResetBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WasResetBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WasResetBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.WasResetBit.Location = new System.Drawing.Point(248, 7);
			this.WasResetBit.Name = "WasResetBit";
			this.WasResetBit.Size = new System.Drawing.Size(21, 21);
			this.WasResetBit.TabIndex = 12;
			this.WasResetBit.Text = "0";
			this.WasResetBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EncryptionActiveBit
			// 
			this.EncryptionActiveBit.BackColor = System.Drawing.Color.Transparent;
			this.EncryptionActiveBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EncryptionActiveBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EncryptionActiveBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EncryptionActiveBit.Location = new System.Drawing.Point(129, 76);
			this.EncryptionActiveBit.Name = "EncryptionActiveBit";
			this.EncryptionActiveBit.Size = new System.Drawing.Size(21, 21);
			this.EncryptionActiveBit.TabIndex = 12;
			this.EncryptionActiveBit.Text = "0";
			this.EncryptionActiveBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DoingLightshowBit
			// 
			this.DoingLightshowBit.BackColor = System.Drawing.Color.Transparent;
			this.DoingLightshowBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DoingLightshowBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DoingLightshowBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DoingLightshowBit.Location = new System.Drawing.Point(129, 7);
			this.DoingLightshowBit.Name = "DoingLightshowBit";
			this.DoingLightshowBit.Size = new System.Drawing.Size(21, 21);
			this.DoingLightshowBit.TabIndex = 12;
			this.DoingLightshowBit.Text = "0";
			this.DoingLightshowBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadioStateBit2
			// 
			this.RadioStateBit2.BackColor = System.Drawing.Color.Transparent;
			this.RadioStateBit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RadioStateBit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RadioStateBit2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioStateBit2.Location = new System.Drawing.Point(8, 27);
			this.RadioStateBit2.Name = "RadioStateBit2";
			this.RadioStateBit2.Size = new System.Drawing.Size(21, 21);
			this.RadioStateBit2.TabIndex = 12;
			this.RadioStateBit2.Text = "0";
			this.RadioStateBit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OnBaseTableBit
			// 
			this.OnBaseTableBit.BackColor = System.Drawing.Color.Transparent;
			this.OnBaseTableBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OnBaseTableBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OnBaseTableBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OnBaseTableBit.Location = new System.Drawing.Point(8, 177);
			this.OnBaseTableBit.Name = "OnBaseTableBit";
			this.OnBaseTableBit.Size = new System.Drawing.Size(21, 21);
			this.OnBaseTableBit.TabIndex = 12;
			this.OnBaseTableBit.Text = "0";
			this.OnBaseTableBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ChangingTablesBit
			// 
			this.ChangingTablesBit.BackColor = System.Drawing.Color.Transparent;
			this.ChangingTablesBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ChangingTablesBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChangingTablesBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChangingTablesBit.Location = new System.Drawing.Point(8, 131);
			this.ChangingTablesBit.Name = "ChangingTablesBit";
			this.ChangingTablesBit.Size = new System.Drawing.Size(21, 21);
			this.ChangingTablesBit.TabIndex = 12;
			this.ChangingTablesBit.Text = "0";
			this.ChangingTablesBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BusyBit
			// 
			this.BusyBit.BackColor = System.Drawing.Color.Transparent;
			this.BusyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BusyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BusyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BusyBit.Location = new System.Drawing.Point(8, 108);
			this.BusyBit.Name = "BusyBit";
			this.BusyBit.Size = new System.Drawing.Size(21, 21);
			this.BusyBit.TabIndex = 12;
			this.BusyBit.Text = "0";
			this.BusyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadioStateBit1
			// 
			this.RadioStateBit1.BackColor = System.Drawing.Color.Transparent;
			this.RadioStateBit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RadioStateBit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RadioStateBit1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioStateBit1.Location = new System.Drawing.Point(8, 7);
			this.RadioStateBit1.Name = "RadioStateBit1";
			this.RadioStateBit1.Size = new System.Drawing.Size(21, 21);
			this.RadioStateBit1.TabIndex = 12;
			this.RadioStateBit1.Text = "0";
			this.RadioStateBit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TabPageInt
			// 
			this.TabPageInt.Controls.Add(this.EnableAllIntButton);
			this.TabPageInt.Controls.Add(this.DisableAllIntButton);
			this.TabPageInt.Controls.Add(this.IntConfigLabel);
			this.TabPageInt.Controls.Add(this.IntClearableLabel);
			this.TabPageInt.Controls.Add(this.IntOtherLabel);
			this.TabPageInt.Controls.Add(this.IntStateLabel);
			this.TabPageInt.Controls.Add(this.label31);
			this.TabPageInt.Controls.Add(this.label33);
			this.TabPageInt.Controls.Add(this.label38);
			this.TabPageInt.Controls.Add(this.label39);
			this.TabPageInt.Controls.Add(this.label40);
			this.TabPageInt.Controls.Add(this.label41);
			this.TabPageInt.Controls.Add(this.label42);
			this.TabPageInt.Controls.Add(this.label46);
			this.TabPageInt.Controls.Add(this.label62);
			this.TabPageInt.Controls.Add(this.label61);
			this.TabPageInt.Controls.Add(this.label47);
			this.TabPageInt.Controls.Add(this.label48);
			this.TabPageInt.Controls.Add(this.label49);
			this.TabPageInt.Controls.Add(this.label50);
			this.TabPageInt.Controls.Add(this.label51);
			this.TabPageInt.Controls.Add(this.label52);
			this.TabPageInt.Controls.Add(this.label53);
			this.TabPageInt.Controls.Add(this.label54);
			this.TabPageInt.Controls.Add(this.label55);
			this.TabPageInt.Controls.Add(this.label56);
			this.TabPageInt.Controls.Add(this.label57);
			this.TabPageInt.Controls.Add(this.label58);
			this.TabPageInt.Controls.Add(this.label60);
			this.TabPageInt.Controls.Add(this.IntButtonHeldBit);
			this.TabPageInt.Controls.Add(this.IntTxLedModeBit);
			this.TabPageInt.Controls.Add(this.IntAckPacketReadyBit);
			this.TabPageInt.Controls.Add(this.IntSettingsPendingBit);
			this.TabPageInt.Controls.Add(this.IntButtonPressedBit);
			this.TabPageInt.Controls.Add(this.IntRadioStateBit4);
			this.TabPageInt.Controls.Add(this.IntRxLedModeBit);
			this.TabPageInt.Controls.Add(this.IntRxPacketReadyBit);
			this.TabPageInt.Controls.Add(this.IntButtonDownBit);
			this.TabPageInt.Controls.Add(this.IntOnBaseTableBit);
			this.TabPageInt.Controls.Add(this.IntChangingTablesBit);
			this.TabPageInt.Controls.Add(this.IntRxInProgressBit);
			this.TabPageInt.Controls.Add(this.IntEncryptionRekeyBit);
			this.TabPageInt.Controls.Add(this.IntAutoClearFlagsBit);
			this.TabPageInt.Controls.Add(this.IntRadioStateBit3);
			this.TabPageInt.Controls.Add(this.IntTransmitFinishedBit);
			this.TabPageInt.Controls.Add(this.IntAutoRekeyBit);
			this.TabPageInt.Controls.Add(this.IntChecksumErrorBit);
			this.TabPageInt.Controls.Add(this.IntShowingQosBit);
			this.TabPageInt.Controls.Add(this.IntInterruptDrivenBit);
			this.TabPageInt.Controls.Add(this.IntWasResetBit);
			this.TabPageInt.Controls.Add(this.IntEncryptionActiveBit);
			this.TabPageInt.Controls.Add(this.IntDoingLightshowBit);
			this.TabPageInt.Controls.Add(this.IntRadioStateBit2);
			this.TabPageInt.Controls.Add(this.IntBusyBit);
			this.TabPageInt.Controls.Add(this.IntRadioStateBit1);
			this.TabPageInt.Location = new System.Drawing.Point(4, 22);
			this.TabPageInt.Name = "TabPageInt";
			this.TabPageInt.Size = new System.Drawing.Size(568, 332);
			this.TabPageInt.TabIndex = 3;
			this.TabPageInt.Text = "Interrupt Bits";
			this.TabPageInt.UseVisualStyleBackColor = true;
			// 
			// EnableAllIntButton
			// 
			this.EnableAllIntButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.EnableAllIntButton.Location = new System.Drawing.Point(477, 255);
			this.EnableAllIntButton.Name = "EnableAllIntButton";
			this.EnableAllIntButton.Size = new System.Drawing.Size(88, 23);
			this.EnableAllIntButton.TabIndex = 72;
			this.EnableAllIntButton.Text = "Enable All";
			this.EnableAllIntButton.UseVisualStyleBackColor = true;
			this.EnableAllIntButton.Click += new System.EventHandler(this.EnableAllIntButton_Click);
			// 
			// DisableAllIntButton
			// 
			this.DisableAllIntButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DisableAllIntButton.Location = new System.Drawing.Point(477, 284);
			this.DisableAllIntButton.Name = "DisableAllIntButton";
			this.DisableAllIntButton.Size = new System.Drawing.Size(88, 23);
			this.DisableAllIntButton.TabIndex = 71;
			this.DisableAllIntButton.Text = "Disable All";
			this.DisableAllIntButton.UseVisualStyleBackColor = true;
			this.DisableAllIntButton.Click += new System.EventHandler(this.DisableAllIntButton_Click);
			// 
			// IntConfigLabel
			// 
			this.IntConfigLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.IntConfigLabel.AutoSize = true;
			this.IntConfigLabel.Location = new System.Drawing.Point(376, 313);
			this.IntConfigLabel.Name = "IntConfigLabel";
			this.IntConfigLabel.Size = new System.Drawing.Size(66, 13);
			this.IntConfigLabel.TabIndex = 70;
			this.IntConfigLabel.Text = "Config: 0x00";
			// 
			// IntClearableLabel
			// 
			this.IntClearableLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.IntClearableLabel.AutoSize = true;
			this.IntClearableLabel.Location = new System.Drawing.Point(246, 313);
			this.IntClearableLabel.Name = "IntClearableLabel";
			this.IntClearableLabel.Size = new System.Drawing.Size(80, 13);
			this.IntClearableLabel.TabIndex = 69;
			this.IntClearableLabel.Text = "Clearable: 0x00";
			// 
			// IntOtherLabel
			// 
			this.IntOtherLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.IntOtherLabel.AutoSize = true;
			this.IntOtherLabel.Location = new System.Drawing.Point(126, 313);
			this.IntOtherLabel.Name = "IntOtherLabel";
			this.IntOtherLabel.Size = new System.Drawing.Size(62, 13);
			this.IntOtherLabel.TabIndex = 68;
			this.IntOtherLabel.Text = "Other: 0x00";
			// 
			// IntStateLabel
			// 
			this.IntStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.IntStateLabel.AutoSize = true;
			this.IntStateLabel.Location = new System.Drawing.Point(8, 313);
			this.IntStateLabel.Name = "IntStateLabel";
			this.IntStateLabel.Size = new System.Drawing.Size(61, 13);
			this.IntStateLabel.TabIndex = 67;
			this.IntStateLabel.Text = "State: 0x00";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(276, 181);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(63, 13);
			this.label31.TabIndex = 66;
			this.label31.Text = "Button Held";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(406, 81);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(73, 13);
			this.label33.TabIndex = 65;
			this.label33.Text = "Tx LED Mode";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(276, 81);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(97, 13);
			this.label38.TabIndex = 64;
			this.label38.Text = "Ack Packet Ready";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(156, 112);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(87, 13);
			this.label39.TabIndex = 63;
			this.label39.Text = "Settings Pending";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(276, 158);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(79, 13);
			this.label40.TabIndex = 58;
			this.label40.Text = "Button Pressed";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(406, 58);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(74, 13);
			this.label41.TabIndex = 59;
			this.label41.Text = "Rx LED Mode";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(276, 58);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(91, 13);
			this.label42.TabIndex = 62;
			this.label42.Text = "Rx Packet Ready";
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(156, 58);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(69, 13);
			this.label46.TabIndex = 60;
			this.label46.Text = "Button Down";
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(35, 181);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(78, 13);
			this.label62.TabIndex = 61;
			this.label62.Text = "On Base Table";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(35, 135);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(87, 13);
			this.label61.TabIndex = 61;
			this.label61.Text = "Changing Tables";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(35, 158);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(76, 13);
			this.label47.TabIndex = 61;
			this.label47.Text = "Rx In Progress";
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(276, 135);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(91, 13);
			this.label48.TabIndex = 57;
			this.label48.Text = "Encryption Rekey";
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(406, 35);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(84, 13);
			this.label49.TabIndex = 56;
			this.label49.Text = "Auto-Clear Flags";
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(276, 35);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(89, 13);
			this.label50.TabIndex = 55;
			this.label50.Text = "Transmit Finished";
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(156, 35);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(74, 13);
			this.label51.TabIndex = 54;
			this.label51.Text = "Showing QOS";
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(156, 81);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(90, 13);
			this.label52.TabIndex = 53;
			this.label52.Text = "Encryption Active";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(406, 112);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(63, 13);
			this.label53.TabIndex = 51;
			this.label53.Text = "Auto Rekey";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(276, 112);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(82, 13);
			this.label54.TabIndex = 50;
			this.label54.Text = "Checksum Error";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(406, 12);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(80, 13);
			this.label55.TabIndex = 49;
			this.label55.Text = "Interrupt Driven";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(276, 12);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(60, 13);
			this.label56.TabIndex = 48;
			this.label56.Text = "Was Reset";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(156, 12);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(86, 13);
			this.label57.TabIndex = 47;
			this.label57.Text = "Doing Lightshow";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(35, 112);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(30, 13);
			this.label58.TabIndex = 52;
			this.label58.Text = "Busy";
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label60.Location = new System.Drawing.Point(35, 39);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(70, 13);
			this.label60.TabIndex = 45;
			this.label60.Text = "RadioState";
			// 
			// IntButtonHeldBit
			// 
			this.IntButtonHeldBit.BackColor = System.Drawing.Color.Transparent;
			this.IntButtonHeldBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntButtonHeldBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntButtonHeldBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntButtonHeldBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntButtonHeldBit.Location = new System.Drawing.Point(249, 177);
			this.IntButtonHeldBit.Name = "IntButtonHeldBit";
			this.IntButtonHeldBit.Size = new System.Drawing.Size(21, 21);
			this.IntButtonHeldBit.TabIndex = 22;
			this.IntButtonHeldBit.Text = "D";
			this.IntButtonHeldBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntButtonHeldBit.Click += new System.EventHandler(this.IntButtonHeldBit_Click);
			// 
			// IntTxLedModeBit
			// 
			this.IntTxLedModeBit.BackColor = System.Drawing.Color.Transparent;
			this.IntTxLedModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntTxLedModeBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntTxLedModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntTxLedModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntTxLedModeBit.Location = new System.Drawing.Point(379, 77);
			this.IntTxLedModeBit.Name = "IntTxLedModeBit";
			this.IntTxLedModeBit.Size = new System.Drawing.Size(21, 21);
			this.IntTxLedModeBit.TabIndex = 23;
			this.IntTxLedModeBit.Text = "D";
			this.IntTxLedModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntTxLedModeBit.Click += new System.EventHandler(this.IntTxLedModeBit_Click);
			// 
			// IntAckPacketReadyBit
			// 
			this.IntAckPacketReadyBit.BackColor = System.Drawing.Color.Transparent;
			this.IntAckPacketReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntAckPacketReadyBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntAckPacketReadyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntAckPacketReadyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntAckPacketReadyBit.Location = new System.Drawing.Point(249, 77);
			this.IntAckPacketReadyBit.Name = "IntAckPacketReadyBit";
			this.IntAckPacketReadyBit.Size = new System.Drawing.Size(21, 21);
			this.IntAckPacketReadyBit.TabIndex = 24;
			this.IntAckPacketReadyBit.Text = "D";
			this.IntAckPacketReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntAckPacketReadyBit.Click += new System.EventHandler(this.IntAckPacketReadyBit_Click);
			// 
			// IntSettingsPendingBit
			// 
			this.IntSettingsPendingBit.BackColor = System.Drawing.Color.Transparent;
			this.IntSettingsPendingBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntSettingsPendingBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntSettingsPendingBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntSettingsPendingBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntSettingsPendingBit.Location = new System.Drawing.Point(129, 108);
			this.IntSettingsPendingBit.Name = "IntSettingsPendingBit";
			this.IntSettingsPendingBit.Size = new System.Drawing.Size(21, 21);
			this.IntSettingsPendingBit.TabIndex = 25;
			this.IntSettingsPendingBit.Text = "D";
			this.IntSettingsPendingBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntSettingsPendingBit.Click += new System.EventHandler(this.IntSettingsPendingBit_Click);
			// 
			// IntButtonPressedBit
			// 
			this.IntButtonPressedBit.BackColor = System.Drawing.Color.Transparent;
			this.IntButtonPressedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntButtonPressedBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntButtonPressedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntButtonPressedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntButtonPressedBit.Location = new System.Drawing.Point(249, 154);
			this.IntButtonPressedBit.Name = "IntButtonPressedBit";
			this.IntButtonPressedBit.Size = new System.Drawing.Size(21, 21);
			this.IntButtonPressedBit.TabIndex = 26;
			this.IntButtonPressedBit.Text = "D";
			this.IntButtonPressedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntButtonPressedBit.Click += new System.EventHandler(this.IntButtonPressedBit_Click);
			// 
			// IntRadioStateBit4
			// 
			this.IntRadioStateBit4.BackColor = System.Drawing.Color.Transparent;
			this.IntRadioStateBit4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRadioStateBit4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRadioStateBit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRadioStateBit4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRadioStateBit4.Location = new System.Drawing.Point(8, 67);
			this.IntRadioStateBit4.Name = "IntRadioStateBit4";
			this.IntRadioStateBit4.Size = new System.Drawing.Size(21, 21);
			this.IntRadioStateBit4.TabIndex = 27;
			this.IntRadioStateBit4.Text = "D";
			this.IntRadioStateBit4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRadioStateBit4.Click += new System.EventHandler(this.IntRadioStateBit4_Click);
			// 
			// IntRxLedModeBit
			// 
			this.IntRxLedModeBit.BackColor = System.Drawing.Color.Transparent;
			this.IntRxLedModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRxLedModeBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRxLedModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRxLedModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRxLedModeBit.Location = new System.Drawing.Point(379, 54);
			this.IntRxLedModeBit.Name = "IntRxLedModeBit";
			this.IntRxLedModeBit.Size = new System.Drawing.Size(21, 21);
			this.IntRxLedModeBit.TabIndex = 28;
			this.IntRxLedModeBit.Text = "D";
			this.IntRxLedModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRxLedModeBit.Click += new System.EventHandler(this.IntRxLedModeBit_Click);
			// 
			// IntRxPacketReadyBit
			// 
			this.IntRxPacketReadyBit.BackColor = System.Drawing.Color.Transparent;
			this.IntRxPacketReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRxPacketReadyBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRxPacketReadyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRxPacketReadyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRxPacketReadyBit.Location = new System.Drawing.Point(249, 54);
			this.IntRxPacketReadyBit.Name = "IntRxPacketReadyBit";
			this.IntRxPacketReadyBit.Size = new System.Drawing.Size(21, 21);
			this.IntRxPacketReadyBit.TabIndex = 29;
			this.IntRxPacketReadyBit.Text = "D";
			this.IntRxPacketReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRxPacketReadyBit.Click += new System.EventHandler(this.IntRxPacketReadyBit_Click);
			// 
			// IntButtonDownBit
			// 
			this.IntButtonDownBit.BackColor = System.Drawing.Color.Transparent;
			this.IntButtonDownBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntButtonDownBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntButtonDownBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntButtonDownBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntButtonDownBit.Location = new System.Drawing.Point(129, 54);
			this.IntButtonDownBit.Name = "IntButtonDownBit";
			this.IntButtonDownBit.Size = new System.Drawing.Size(21, 21);
			this.IntButtonDownBit.TabIndex = 30;
			this.IntButtonDownBit.Text = "D";
			this.IntButtonDownBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntButtonDownBit.Click += new System.EventHandler(this.IntButtonDownBit_Click);
			// 
			// IntOnBaseTableBit
			// 
			this.IntOnBaseTableBit.BackColor = System.Drawing.Color.Transparent;
			this.IntOnBaseTableBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntOnBaseTableBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntOnBaseTableBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntOnBaseTableBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntOnBaseTableBit.Location = new System.Drawing.Point(8, 177);
			this.IntOnBaseTableBit.Name = "IntOnBaseTableBit";
			this.IntOnBaseTableBit.Size = new System.Drawing.Size(21, 21);
			this.IntOnBaseTableBit.TabIndex = 31;
			this.IntOnBaseTableBit.Text = "D";
			this.IntOnBaseTableBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntOnBaseTableBit.Click += new System.EventHandler(this.IntOnBaseTableBit_Click);
			// 
			// IntChangingTablesBit
			// 
			this.IntChangingTablesBit.BackColor = System.Drawing.Color.Transparent;
			this.IntChangingTablesBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntChangingTablesBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntChangingTablesBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntChangingTablesBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntChangingTablesBit.Location = new System.Drawing.Point(8, 131);
			this.IntChangingTablesBit.Name = "IntChangingTablesBit";
			this.IntChangingTablesBit.Size = new System.Drawing.Size(21, 21);
			this.IntChangingTablesBit.TabIndex = 31;
			this.IntChangingTablesBit.Text = "D";
			this.IntChangingTablesBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntChangingTablesBit.Click += new System.EventHandler(this.IntChangingTablesBit_Click);
			// 
			// IntRxInProgressBit
			// 
			this.IntRxInProgressBit.BackColor = System.Drawing.Color.Transparent;
			this.IntRxInProgressBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRxInProgressBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRxInProgressBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRxInProgressBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRxInProgressBit.Location = new System.Drawing.Point(8, 154);
			this.IntRxInProgressBit.Name = "IntRxInProgressBit";
			this.IntRxInProgressBit.Size = new System.Drawing.Size(21, 21);
			this.IntRxInProgressBit.TabIndex = 31;
			this.IntRxInProgressBit.Text = "D";
			this.IntRxInProgressBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRxInProgressBit.Click += new System.EventHandler(this.IntRxInProgressBit_Click);
			// 
			// IntEncryptionRekeyBit
			// 
			this.IntEncryptionRekeyBit.BackColor = System.Drawing.Color.Transparent;
			this.IntEncryptionRekeyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntEncryptionRekeyBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntEncryptionRekeyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntEncryptionRekeyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntEncryptionRekeyBit.Location = new System.Drawing.Point(249, 131);
			this.IntEncryptionRekeyBit.Name = "IntEncryptionRekeyBit";
			this.IntEncryptionRekeyBit.Size = new System.Drawing.Size(21, 21);
			this.IntEncryptionRekeyBit.TabIndex = 32;
			this.IntEncryptionRekeyBit.Text = "D";
			this.IntEncryptionRekeyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntEncryptionRekeyBit.Click += new System.EventHandler(this.IntEncryptionRekeyBit_Click);
			// 
			// IntAutoClearFlagsBit
			// 
			this.IntAutoClearFlagsBit.BackColor = System.Drawing.Color.Transparent;
			this.IntAutoClearFlagsBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntAutoClearFlagsBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntAutoClearFlagsBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntAutoClearFlagsBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntAutoClearFlagsBit.Location = new System.Drawing.Point(379, 31);
			this.IntAutoClearFlagsBit.Name = "IntAutoClearFlagsBit";
			this.IntAutoClearFlagsBit.Size = new System.Drawing.Size(21, 21);
			this.IntAutoClearFlagsBit.TabIndex = 43;
			this.IntAutoClearFlagsBit.Text = "D";
			this.IntAutoClearFlagsBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntAutoClearFlagsBit.Click += new System.EventHandler(this.IntAutoClearFlagsBit_Click);
			// 
			// IntRadioStateBit3
			// 
			this.IntRadioStateBit3.BackColor = System.Drawing.Color.Transparent;
			this.IntRadioStateBit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRadioStateBit3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRadioStateBit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRadioStateBit3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRadioStateBit3.Location = new System.Drawing.Point(8, 47);
			this.IntRadioStateBit3.Name = "IntRadioStateBit3";
			this.IntRadioStateBit3.Size = new System.Drawing.Size(21, 21);
			this.IntRadioStateBit3.TabIndex = 33;
			this.IntRadioStateBit3.Text = "D";
			this.IntRadioStateBit3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRadioStateBit3.Click += new System.EventHandler(this.IntRadioStateBit3_Click);
			// 
			// IntTransmitFinishedBit
			// 
			this.IntTransmitFinishedBit.BackColor = System.Drawing.Color.Transparent;
			this.IntTransmitFinishedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntTransmitFinishedBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntTransmitFinishedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntTransmitFinishedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntTransmitFinishedBit.Location = new System.Drawing.Point(249, 31);
			this.IntTransmitFinishedBit.Name = "IntTransmitFinishedBit";
			this.IntTransmitFinishedBit.Size = new System.Drawing.Size(21, 21);
			this.IntTransmitFinishedBit.TabIndex = 34;
			this.IntTransmitFinishedBit.Text = "D";
			this.IntTransmitFinishedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntTransmitFinishedBit.Click += new System.EventHandler(this.IntTransmitFinishedBit_Click);
			// 
			// IntAutoRekeyBit
			// 
			this.IntAutoRekeyBit.BackColor = System.Drawing.Color.Transparent;
			this.IntAutoRekeyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntAutoRekeyBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntAutoRekeyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntAutoRekeyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntAutoRekeyBit.Location = new System.Drawing.Point(379, 108);
			this.IntAutoRekeyBit.Name = "IntAutoRekeyBit";
			this.IntAutoRekeyBit.Size = new System.Drawing.Size(21, 21);
			this.IntAutoRekeyBit.TabIndex = 35;
			this.IntAutoRekeyBit.Text = "D";
			this.IntAutoRekeyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntAutoRekeyBit.Click += new System.EventHandler(this.IntAutoRekeyBit_Click);
			// 
			// IntChecksumErrorBit
			// 
			this.IntChecksumErrorBit.BackColor = System.Drawing.Color.Transparent;
			this.IntChecksumErrorBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntChecksumErrorBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntChecksumErrorBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntChecksumErrorBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntChecksumErrorBit.Location = new System.Drawing.Point(249, 108);
			this.IntChecksumErrorBit.Name = "IntChecksumErrorBit";
			this.IntChecksumErrorBit.Size = new System.Drawing.Size(21, 21);
			this.IntChecksumErrorBit.TabIndex = 36;
			this.IntChecksumErrorBit.Text = "D";
			this.IntChecksumErrorBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntChecksumErrorBit.Click += new System.EventHandler(this.IntChecksumErrorBit_Click);
			// 
			// IntShowingQosBit
			// 
			this.IntShowingQosBit.BackColor = System.Drawing.Color.Transparent;
			this.IntShowingQosBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntShowingQosBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntShowingQosBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntShowingQosBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntShowingQosBit.Location = new System.Drawing.Point(129, 31);
			this.IntShowingQosBit.Name = "IntShowingQosBit";
			this.IntShowingQosBit.Size = new System.Drawing.Size(21, 21);
			this.IntShowingQosBit.TabIndex = 37;
			this.IntShowingQosBit.Text = "D";
			this.IntShowingQosBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntShowingQosBit.Click += new System.EventHandler(this.IntShowingQosBit_Click);
			// 
			// IntInterruptDrivenBit
			// 
			this.IntInterruptDrivenBit.BackColor = System.Drawing.Color.Transparent;
			this.IntInterruptDrivenBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntInterruptDrivenBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntInterruptDrivenBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntInterruptDrivenBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntInterruptDrivenBit.Location = new System.Drawing.Point(379, 8);
			this.IntInterruptDrivenBit.Name = "IntInterruptDrivenBit";
			this.IntInterruptDrivenBit.Size = new System.Drawing.Size(21, 21);
			this.IntInterruptDrivenBit.TabIndex = 38;
			this.IntInterruptDrivenBit.Text = "D";
			this.IntInterruptDrivenBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntInterruptDrivenBit.Click += new System.EventHandler(this.IntInterruptDrivenBit_Click);
			// 
			// IntWasResetBit
			// 
			this.IntWasResetBit.BackColor = System.Drawing.Color.Transparent;
			this.IntWasResetBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntWasResetBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntWasResetBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntWasResetBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntWasResetBit.Location = new System.Drawing.Point(249, 8);
			this.IntWasResetBit.Name = "IntWasResetBit";
			this.IntWasResetBit.Size = new System.Drawing.Size(21, 21);
			this.IntWasResetBit.TabIndex = 39;
			this.IntWasResetBit.Text = "D";
			this.IntWasResetBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntWasResetBit.Click += new System.EventHandler(this.IntWasResetBit_Click);
			// 
			// IntEncryptionActiveBit
			// 
			this.IntEncryptionActiveBit.BackColor = System.Drawing.Color.Transparent;
			this.IntEncryptionActiveBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntEncryptionActiveBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntEncryptionActiveBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntEncryptionActiveBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntEncryptionActiveBit.Location = new System.Drawing.Point(129, 77);
			this.IntEncryptionActiveBit.Name = "IntEncryptionActiveBit";
			this.IntEncryptionActiveBit.Size = new System.Drawing.Size(21, 21);
			this.IntEncryptionActiveBit.TabIndex = 40;
			this.IntEncryptionActiveBit.Text = "D";
			this.IntEncryptionActiveBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntEncryptionActiveBit.Click += new System.EventHandler(this.IntEncryptionActiveBit_Click);
			// 
			// IntDoingLightshowBit
			// 
			this.IntDoingLightshowBit.BackColor = System.Drawing.Color.Transparent;
			this.IntDoingLightshowBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntDoingLightshowBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntDoingLightshowBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntDoingLightshowBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntDoingLightshowBit.Location = new System.Drawing.Point(129, 8);
			this.IntDoingLightshowBit.Name = "IntDoingLightshowBit";
			this.IntDoingLightshowBit.Size = new System.Drawing.Size(21, 21);
			this.IntDoingLightshowBit.TabIndex = 41;
			this.IntDoingLightshowBit.Text = "D";
			this.IntDoingLightshowBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntDoingLightshowBit.Click += new System.EventHandler(this.IntDoingLightshowBit_Click);
			// 
			// IntRadioStateBit2
			// 
			this.IntRadioStateBit2.BackColor = System.Drawing.Color.Transparent;
			this.IntRadioStateBit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRadioStateBit2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRadioStateBit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRadioStateBit2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRadioStateBit2.Location = new System.Drawing.Point(8, 27);
			this.IntRadioStateBit2.Name = "IntRadioStateBit2";
			this.IntRadioStateBit2.Size = new System.Drawing.Size(21, 21);
			this.IntRadioStateBit2.TabIndex = 42;
			this.IntRadioStateBit2.Text = "D";
			this.IntRadioStateBit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRadioStateBit2.Click += new System.EventHandler(this.IntRadioStateBit2_Click);
			// 
			// IntBusyBit
			// 
			this.IntBusyBit.BackColor = System.Drawing.Color.Transparent;
			this.IntBusyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntBusyBit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntBusyBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntBusyBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntBusyBit.Location = new System.Drawing.Point(8, 108);
			this.IntBusyBit.Name = "IntBusyBit";
			this.IntBusyBit.Size = new System.Drawing.Size(21, 21);
			this.IntBusyBit.TabIndex = 44;
			this.IntBusyBit.Text = "D";
			this.IntBusyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntBusyBit.Click += new System.EventHandler(this.IntBusyBit_Click);
			// 
			// IntRadioStateBit1
			// 
			this.IntRadioStateBit1.BackColor = System.Drawing.Color.Transparent;
			this.IntRadioStateBit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntRadioStateBit1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntRadioStateBit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntRadioStateBit1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IntRadioStateBit1.Location = new System.Drawing.Point(8, 7);
			this.IntRadioStateBit1.Name = "IntRadioStateBit1";
			this.IntRadioStateBit1.Size = new System.Drawing.Size(21, 21);
			this.IntRadioStateBit1.TabIndex = 21;
			this.IntRadioStateBit1.Text = "D";
			this.IntRadioStateBit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IntRadioStateBit1.Click += new System.EventHandler(this.IntRadioStateBit1_Click);
			// 
			// TabPageBluetooth
			// 
			this.TabPageBluetooth.Controls.Add(this.BleTp28PullLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp25PullLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp6PullLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp5PullLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp4PullLabel);
			this.TabPageBluetooth.Controls.Add(this.label77);
			this.TabPageBluetooth.Controls.Add(this.BleTp28AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.BleTp25AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.BleTp6AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.BleTp5AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.BleTp4AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.BleTp3AutoCheckbox);
			this.TabPageBluetooth.Controls.Add(this.label107);
			this.TabPageBluetooth.Controls.Add(this.label92);
			this.TabPageBluetooth.Controls.Add(this.label84);
			this.TabPageBluetooth.Controls.Add(this.label106);
			this.TabPageBluetooth.Controls.Add(this.BleTp28GetButton);
			this.TabPageBluetooth.Controls.Add(this.label103);
			this.TabPageBluetooth.Controls.Add(this.BleTp25GetButton);
			this.TabPageBluetooth.Controls.Add(this.label100);
			this.TabPageBluetooth.Controls.Add(this.BleTp6GetButton);
			this.TabPageBluetooth.Controls.Add(this.label97);
			this.TabPageBluetooth.Controls.Add(this.BleTp5GetButton);
			this.TabPageBluetooth.Controls.Add(this.label94);
			this.TabPageBluetooth.Controls.Add(this.BleTp4GetButton);
			this.TabPageBluetooth.Controls.Add(this.label82);
			this.TabPageBluetooth.Controls.Add(this.BleTp3GetButton);
			this.TabPageBluetooth.Controls.Add(this.BleDisableAllButton);
			this.TabPageBluetooth.Controls.Add(this.BleEnableAllButton);
			this.TabPageBluetooth.Controls.Add(this.BleClearResetFlagButton);
			this.TabPageBluetooth.Controls.Add(this.BleGetStatusButton);
			this.TabPageBluetooth.Controls.Add(this.BleFirmwareVersionLabel);
			this.TabPageBluetooth.Controls.Add(this.label78);
			this.TabPageBluetooth.Controls.Add(this.BleGetVersionButton);
			this.TabPageBluetooth.Controls.Add(this.BleAdvertisingNameLengthLabel);
			this.TabPageBluetooth.Controls.Add(this.BleAdvertisingDataLengthLabel);
			this.TabPageBluetooth.Controls.Add(this.label71);
			this.TabPageBluetooth.Controls.Add(this.label59);
			this.TabPageBluetooth.Controls.Add(this.BleAdvertisingDataTextbox);
			this.TabPageBluetooth.Controls.Add(this.BleAdvertisingNameTextbox);
			this.TabPageBluetooth.Controls.Add(this.BleCloseConnectionButton);
			this.TabPageBluetooth.Controls.Add(this.BleStartAdvertisingButton);
			this.TabPageBluetooth.Controls.Add(this.label91);
			this.TabPageBluetooth.Controls.Add(this.label76);
			this.TabPageBluetooth.Controls.Add(this.label90);
			this.TabPageBluetooth.Controls.Add(this.label75);
			this.TabPageBluetooth.Controls.Add(this.label89);
			this.TabPageBluetooth.Controls.Add(this.label74);
			this.TabPageBluetooth.Controls.Add(this.label88);
			this.TabPageBluetooth.Controls.Add(this.label86);
			this.TabPageBluetooth.Controls.Add(this.label87);
			this.TabPageBluetooth.Controls.Add(this.label30);
			this.TabPageBluetooth.Controls.Add(this.BleIntInDfuModeBit);
			this.TabPageBluetooth.Controls.Add(this.BleInDfuModeBit);
			this.TabPageBluetooth.Controls.Add(this.BleIntAdvertisingBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp28ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleAdvertisingBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp25ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleIntConnectedBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp6ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleConnectedBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp28DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp5ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp25DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleIntSureFiTxInProgressBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp6DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp4ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp5DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleSureFiTxInProgressBit);
			this.TabPageBluetooth.Controls.Add(this.BleTp4DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp3ValueLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp3PullLabel);
			this.TabPageBluetooth.Controls.Add(this.BleTp3DirectionLabel);
			this.TabPageBluetooth.Controls.Add(this.BleIntWasResetBit);
			this.TabPageBluetooth.Controls.Add(this.BleWasResetBit);
			this.TabPageBluetooth.Location = new System.Drawing.Point(4, 22);
			this.TabPageBluetooth.Name = "TabPageBluetooth";
			this.TabPageBluetooth.Size = new System.Drawing.Size(568, 332);
			this.TabPageBluetooth.TabIndex = 5;
			this.TabPageBluetooth.Text = "Bluetooth";
			this.TabPageBluetooth.UseVisualStyleBackColor = true;
			// 
			// BleTp28AutoCheckbox
			// 
			this.BleTp28AutoCheckbox.AutoSize = true;
			this.BleTp28AutoCheckbox.Location = new System.Drawing.Point(221, 293);
			this.BleTp28AutoCheckbox.Name = "BleTp28AutoCheckbox";
			this.BleTp28AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp28AutoCheckbox.TabIndex = 42;
			this.BleTp28AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// BleTp25AutoCheckbox
			// 
			this.BleTp25AutoCheckbox.AutoSize = true;
			this.BleTp25AutoCheckbox.Location = new System.Drawing.Point(221, 269);
			this.BleTp25AutoCheckbox.Name = "BleTp25AutoCheckbox";
			this.BleTp25AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp25AutoCheckbox.TabIndex = 42;
			this.BleTp25AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// BleTp6AutoCheckbox
			// 
			this.BleTp6AutoCheckbox.AutoSize = true;
			this.BleTp6AutoCheckbox.Location = new System.Drawing.Point(221, 245);
			this.BleTp6AutoCheckbox.Name = "BleTp6AutoCheckbox";
			this.BleTp6AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp6AutoCheckbox.TabIndex = 42;
			this.BleTp6AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// BleTp5AutoCheckbox
			// 
			this.BleTp5AutoCheckbox.AutoSize = true;
			this.BleTp5AutoCheckbox.Location = new System.Drawing.Point(221, 222);
			this.BleTp5AutoCheckbox.Name = "BleTp5AutoCheckbox";
			this.BleTp5AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp5AutoCheckbox.TabIndex = 42;
			this.BleTp5AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// BleTp4AutoCheckbox
			// 
			this.BleTp4AutoCheckbox.AutoSize = true;
			this.BleTp4AutoCheckbox.Location = new System.Drawing.Point(221, 199);
			this.BleTp4AutoCheckbox.Name = "BleTp4AutoCheckbox";
			this.BleTp4AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp4AutoCheckbox.TabIndex = 42;
			this.BleTp4AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// BleTp3AutoCheckbox
			// 
			this.BleTp3AutoCheckbox.AutoSize = true;
			this.BleTp3AutoCheckbox.Location = new System.Drawing.Point(221, 175);
			this.BleTp3AutoCheckbox.Name = "BleTp3AutoCheckbox";
			this.BleTp3AutoCheckbox.Size = new System.Drawing.Size(15, 14);
			this.BleTp3AutoCheckbox.TabIndex = 42;
			this.BleTp3AutoCheckbox.UseVisualStyleBackColor = true;
			// 
			// label107
			// 
			this.label107.AutoSize = true;
			this.label107.Location = new System.Drawing.Point(215, 160);
			this.label107.Name = "label107";
			this.label107.Size = new System.Drawing.Size(29, 13);
			this.label107.TabIndex = 41;
			this.label107.Text = "Auto";
			// 
			// label92
			// 
			this.label92.AutoSize = true;
			this.label92.Location = new System.Drawing.Point(135, 159);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(34, 13);
			this.label92.TabIndex = 41;
			this.label92.Text = "Value";
			// 
			// label84
			// 
			this.label84.AutoSize = true;
			this.label84.Location = new System.Drawing.Point(44, 159);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(49, 13);
			this.label84.TabIndex = 41;
			this.label84.Text = "Direction";
			// 
			// label106
			// 
			this.label106.AutoSize = true;
			this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label106.Location = new System.Drawing.Point(7, 294);
			this.label106.Name = "label106";
			this.label106.Size = new System.Drawing.Size(37, 13);
			this.label106.TabIndex = 40;
			this.label106.Text = "TP28";
			// 
			// BleTp28GetButton
			// 
			this.BleTp28GetButton.Location = new System.Drawing.Point(173, 289);
			this.BleTp28GetButton.Name = "BleTp28GetButton";
			this.BleTp28GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp28GetButton.TabIndex = 39;
			this.BleTp28GetButton.Text = "Get";
			this.BleTp28GetButton.UseVisualStyleBackColor = true;
			// 
			// label103
			// 
			this.label103.AutoSize = true;
			this.label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label103.Location = new System.Drawing.Point(7, 270);
			this.label103.Name = "label103";
			this.label103.Size = new System.Drawing.Size(37, 13);
			this.label103.TabIndex = 40;
			this.label103.Text = "TP25";
			// 
			// BleTp25GetButton
			// 
			this.BleTp25GetButton.Location = new System.Drawing.Point(173, 265);
			this.BleTp25GetButton.Name = "BleTp25GetButton";
			this.BleTp25GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp25GetButton.TabIndex = 39;
			this.BleTp25GetButton.Text = "Get";
			this.BleTp25GetButton.UseVisualStyleBackColor = true;
			// 
			// label100
			// 
			this.label100.AutoSize = true;
			this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label100.Location = new System.Drawing.Point(14, 246);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(30, 13);
			this.label100.TabIndex = 40;
			this.label100.Text = "TP6";
			// 
			// BleTp6GetButton
			// 
			this.BleTp6GetButton.Location = new System.Drawing.Point(173, 241);
			this.BleTp6GetButton.Name = "BleTp6GetButton";
			this.BleTp6GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp6GetButton.TabIndex = 39;
			this.BleTp6GetButton.Text = "Get";
			this.BleTp6GetButton.UseVisualStyleBackColor = true;
			// 
			// label97
			// 
			this.label97.AutoSize = true;
			this.label97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label97.Location = new System.Drawing.Point(14, 223);
			this.label97.Name = "label97";
			this.label97.Size = new System.Drawing.Size(30, 13);
			this.label97.TabIndex = 40;
			this.label97.Text = "TP5";
			// 
			// BleTp5GetButton
			// 
			this.BleTp5GetButton.Location = new System.Drawing.Point(173, 218);
			this.BleTp5GetButton.Name = "BleTp5GetButton";
			this.BleTp5GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp5GetButton.TabIndex = 39;
			this.BleTp5GetButton.Text = "Get";
			this.BleTp5GetButton.UseVisualStyleBackColor = true;
			// 
			// label94
			// 
			this.label94.AutoSize = true;
			this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label94.Location = new System.Drawing.Point(14, 200);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(30, 13);
			this.label94.TabIndex = 40;
			this.label94.Text = "TP4";
			// 
			// BleTp4GetButton
			// 
			this.BleTp4GetButton.Location = new System.Drawing.Point(173, 195);
			this.BleTp4GetButton.Name = "BleTp4GetButton";
			this.BleTp4GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp4GetButton.TabIndex = 39;
			this.BleTp4GetButton.Text = "Get";
			this.BleTp4GetButton.UseVisualStyleBackColor = true;
			// 
			// label82
			// 
			this.label82.AutoSize = true;
			this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label82.Location = new System.Drawing.Point(14, 176);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(30, 13);
			this.label82.TabIndex = 40;
			this.label82.Text = "TP3";
			// 
			// BleTp3GetButton
			// 
			this.BleTp3GetButton.Location = new System.Drawing.Point(173, 171);
			this.BleTp3GetButton.Name = "BleTp3GetButton";
			this.BleTp3GetButton.Size = new System.Drawing.Size(42, 23);
			this.BleTp3GetButton.TabIndex = 39;
			this.BleTp3GetButton.Text = "Get";
			this.BleTp3GetButton.UseVisualStyleBackColor = true;
			// 
			// BleDisableAllButton
			// 
			this.BleDisableAllButton.Location = new System.Drawing.Point(351, 185);
			this.BleDisableAllButton.Name = "BleDisableAllButton";
			this.BleDisableAllButton.Size = new System.Drawing.Size(95, 23);
			this.BleDisableAllButton.TabIndex = 38;
			this.BleDisableAllButton.Text = "Disable All";
			this.BleDisableAllButton.UseVisualStyleBackColor = true;
			// 
			// BleEnableAllButton
			// 
			this.BleEnableAllButton.Location = new System.Drawing.Point(351, 161);
			this.BleEnableAllButton.Name = "BleEnableAllButton";
			this.BleEnableAllButton.Size = new System.Drawing.Size(95, 23);
			this.BleEnableAllButton.TabIndex = 38;
			this.BleEnableAllButton.Text = "Enable All";
			this.BleEnableAllButton.UseVisualStyleBackColor = true;
			// 
			// BleClearResetFlagButton
			// 
			this.BleClearResetFlagButton.Location = new System.Drawing.Point(351, 18);
			this.BleClearResetFlagButton.Name = "BleClearResetFlagButton";
			this.BleClearResetFlagButton.Size = new System.Drawing.Size(95, 23);
			this.BleClearResetFlagButton.TabIndex = 36;
			this.BleClearResetFlagButton.Text = "Clear Reset Flag";
			this.BleClearResetFlagButton.UseVisualStyleBackColor = true;
			// 
			// BleGetStatusButton
			// 
			this.BleGetStatusButton.Location = new System.Drawing.Point(351, 42);
			this.BleGetStatusButton.Name = "BleGetStatusButton";
			this.BleGetStatusButton.Size = new System.Drawing.Size(95, 23);
			this.BleGetStatusButton.TabIndex = 35;
			this.BleGetStatusButton.Text = "Get Status";
			this.BleGetStatusButton.UseVisualStyleBackColor = true;
			// 
			// BleFirmwareVersionLabel
			// 
			this.BleFirmwareVersionLabel.AutoSize = true;
			this.BleFirmwareVersionLabel.Location = new System.Drawing.Point(78, 135);
			this.BleFirmwareVersionLabel.Name = "BleFirmwareVersionLabel";
			this.BleFirmwareVersionLabel.Size = new System.Drawing.Size(94, 13);
			this.BleFirmwareVersionLabel.TabIndex = 34;
			this.BleFirmwareVersionLabel.Text = "Firmware: 1.0(100)";
			// 
			// label78
			// 
			this.label78.AutoSize = true;
			this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label78.Location = new System.Drawing.Point(78, 122);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(111, 13);
			this.label78.TabIndex = 33;
			this.label78.Text = "Bluetooth Version:";
			// 
			// BleGetVersionButton
			// 
			this.BleGetVersionButton.Location = new System.Drawing.Point(6, 122);
			this.BleGetVersionButton.Name = "BleGetVersionButton";
			this.BleGetVersionButton.Size = new System.Drawing.Size(66, 23);
			this.BleGetVersionButton.TabIndex = 23;
			this.BleGetVersionButton.Text = "Get";
			this.BleGetVersionButton.UseVisualStyleBackColor = true;
			// 
			// BleAdvertisingNameLengthLabel
			// 
			this.BleAdvertisingNameLengthLabel.AutoSize = true;
			this.BleAdvertisingNameLengthLabel.Location = new System.Drawing.Point(185, 6);
			this.BleAdvertisingNameLengthLabel.Name = "BleAdvertisingNameLengthLabel";
			this.BleAdvertisingNameLengthLabel.Size = new System.Drawing.Size(47, 13);
			this.BleAdvertisingNameLengthLabel.TabIndex = 22;
			this.BleAdvertisingNameLengthLabel.Text = "10 bytes";
			// 
			// BleAdvertisingDataLengthLabel
			// 
			this.BleAdvertisingDataLengthLabel.AutoSize = true;
			this.BleAdvertisingDataLengthLabel.Location = new System.Drawing.Point(185, 44);
			this.BleAdvertisingDataLengthLabel.Name = "BleAdvertisingDataLengthLabel";
			this.BleAdvertisingDataLengthLabel.Size = new System.Drawing.Size(47, 13);
			this.BleAdvertisingDataLengthLabel.TabIndex = 22;
			this.BleAdvertisingDataLengthLabel.Text = "10 bytes";
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(3, 44);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(85, 13);
			this.label71.TabIndex = 21;
			this.label71.Text = "Advertising Data";
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(3, 6);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(90, 13);
			this.label59.TabIndex = 21;
			this.label59.Text = "Advertising Name";
			// 
			// BleAdvertisingDataTextbox
			// 
			this.BleAdvertisingDataTextbox.Location = new System.Drawing.Point(6, 60);
			this.BleAdvertisingDataTextbox.Name = "BleAdvertisingDataTextbox";
			this.BleAdvertisingDataTextbox.Size = new System.Drawing.Size(226, 20);
			this.BleAdvertisingDataTextbox.TabIndex = 20;
			// 
			// BleAdvertisingNameTextbox
			// 
			this.BleAdvertisingNameTextbox.Location = new System.Drawing.Point(6, 21);
			this.BleAdvertisingNameTextbox.Name = "BleAdvertisingNameTextbox";
			this.BleAdvertisingNameTextbox.Size = new System.Drawing.Size(226, 20);
			this.BleAdvertisingNameTextbox.TabIndex = 19;
			// 
			// BleCloseConnectionButton
			// 
			this.BleCloseConnectionButton.Location = new System.Drawing.Point(122, 86);
			this.BleCloseConnectionButton.Name = "BleCloseConnectionButton";
			this.BleCloseConnectionButton.Size = new System.Drawing.Size(110, 23);
			this.BleCloseConnectionButton.TabIndex = 18;
			this.BleCloseConnectionButton.Text = "Close Connection";
			this.BleCloseConnectionButton.UseVisualStyleBackColor = true;
			// 
			// BleStartAdvertisingButton
			// 
			this.BleStartAdvertisingButton.Location = new System.Drawing.Point(6, 86);
			this.BleStartAdvertisingButton.Name = "BleStartAdvertisingButton";
			this.BleStartAdvertisingButton.Size = new System.Drawing.Size(110, 23);
			this.BleStartAdvertisingButton.TabIndex = 18;
			this.BleStartAdvertisingButton.Text = "Start Advertising";
			this.BleStartAdvertisingButton.UseVisualStyleBackColor = true;
			// 
			// label91
			// 
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(277, 217);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(71, 13);
			this.label91.TabIndex = 17;
			this.label91.Text = "In DFU Mode";
			// 
			// label76
			// 
			this.label76.AutoSize = true;
			this.label76.Location = new System.Drawing.Point(277, 79);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(71, 13);
			this.label76.TabIndex = 17;
			this.label76.Text = "In DFU Mode";
			// 
			// label90
			// 
			this.label90.AutoSize = true;
			this.label90.Location = new System.Drawing.Point(277, 194);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(59, 13);
			this.label90.TabIndex = 17;
			this.label90.Text = "Advertising";
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(277, 56);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(59, 13);
			this.label75.TabIndex = 17;
			this.label75.Text = "Advertising";
			// 
			// label89
			// 
			this.label89.AutoSize = true;
			this.label89.Location = new System.Drawing.Point(277, 171);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(59, 13);
			this.label89.TabIndex = 17;
			this.label89.Text = "Connected";
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(277, 33);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(59, 13);
			this.label74.TabIndex = 17;
			this.label74.Text = "Connected";
			// 
			// label88
			// 
			this.label88.AutoSize = true;
			this.label88.Location = new System.Drawing.Point(277, 240);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(111, 13);
			this.label88.TabIndex = 17;
			this.label88.Text = "Sure-Fi Tx In Progress";
			// 
			// label86
			// 
			this.label86.AutoSize = true;
			this.label86.Location = new System.Drawing.Point(277, 102);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(111, 13);
			this.label86.TabIndex = 17;
			this.label86.Text = "Sure-Fi Tx In Progress";
			// 
			// label87
			// 
			this.label87.AutoSize = true;
			this.label87.Location = new System.Drawing.Point(277, 148);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(60, 13);
			this.label87.TabIndex = 17;
			this.label87.Text = "Was Reset";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(277, 10);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(60, 13);
			this.label30.TabIndex = 17;
			this.label30.Text = "Was Reset";
			// 
			// BleIntInDfuModeBit
			// 
			this.BleIntInDfuModeBit.BackColor = System.Drawing.Color.Transparent;
			this.BleIntInDfuModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleIntInDfuModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleIntInDfuModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleIntInDfuModeBit.Location = new System.Drawing.Point(253, 213);
			this.BleIntInDfuModeBit.Name = "BleIntInDfuModeBit";
			this.BleIntInDfuModeBit.Size = new System.Drawing.Size(21, 21);
			this.BleIntInDfuModeBit.TabIndex = 16;
			this.BleIntInDfuModeBit.Text = "D";
			this.BleIntInDfuModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleInDfuModeBit
			// 
			this.BleInDfuModeBit.BackColor = System.Drawing.Color.Transparent;
			this.BleInDfuModeBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleInDfuModeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleInDfuModeBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleInDfuModeBit.Location = new System.Drawing.Point(253, 75);
			this.BleInDfuModeBit.Name = "BleInDfuModeBit";
			this.BleInDfuModeBit.Size = new System.Drawing.Size(21, 21);
			this.BleInDfuModeBit.TabIndex = 16;
			this.BleInDfuModeBit.Text = "0";
			this.BleInDfuModeBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleIntAdvertisingBit
			// 
			this.BleIntAdvertisingBit.BackColor = System.Drawing.Color.Transparent;
			this.BleIntAdvertisingBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleIntAdvertisingBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleIntAdvertisingBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleIntAdvertisingBit.Location = new System.Drawing.Point(253, 190);
			this.BleIntAdvertisingBit.Name = "BleIntAdvertisingBit";
			this.BleIntAdvertisingBit.Size = new System.Drawing.Size(21, 21);
			this.BleIntAdvertisingBit.TabIndex = 16;
			this.BleIntAdvertisingBit.Text = "D";
			this.BleIntAdvertisingBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp28ValueLabel
			// 
			this.BleTp28ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp28ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp28ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp28ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp28ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp28ValueLabel.Location = new System.Drawing.Point(133, 290);
			this.BleTp28ValueLabel.Name = "BleTp28ValueLabel";
			this.BleTp28ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp28ValueLabel.TabIndex = 16;
			this.BleTp28ValueLabel.Text = "Low";
			this.BleTp28ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleAdvertisingBit
			// 
			this.BleAdvertisingBit.BackColor = System.Drawing.Color.Transparent;
			this.BleAdvertisingBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleAdvertisingBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleAdvertisingBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleAdvertisingBit.Location = new System.Drawing.Point(253, 52);
			this.BleAdvertisingBit.Name = "BleAdvertisingBit";
			this.BleAdvertisingBit.Size = new System.Drawing.Size(21, 21);
			this.BleAdvertisingBit.TabIndex = 16;
			this.BleAdvertisingBit.Text = "0";
			this.BleAdvertisingBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp25ValueLabel
			// 
			this.BleTp25ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp25ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp25ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp25ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp25ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp25ValueLabel.Location = new System.Drawing.Point(133, 266);
			this.BleTp25ValueLabel.Name = "BleTp25ValueLabel";
			this.BleTp25ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp25ValueLabel.TabIndex = 16;
			this.BleTp25ValueLabel.Text = "Low";
			this.BleTp25ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleIntConnectedBit
			// 
			this.BleIntConnectedBit.BackColor = System.Drawing.Color.Transparent;
			this.BleIntConnectedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleIntConnectedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleIntConnectedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleIntConnectedBit.Location = new System.Drawing.Point(253, 167);
			this.BleIntConnectedBit.Name = "BleIntConnectedBit";
			this.BleIntConnectedBit.Size = new System.Drawing.Size(21, 21);
			this.BleIntConnectedBit.TabIndex = 16;
			this.BleIntConnectedBit.Text = "D";
			this.BleIntConnectedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp6ValueLabel
			// 
			this.BleTp6ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp6ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp6ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp6ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp6ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp6ValueLabel.Location = new System.Drawing.Point(133, 242);
			this.BleTp6ValueLabel.Name = "BleTp6ValueLabel";
			this.BleTp6ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp6ValueLabel.TabIndex = 16;
			this.BleTp6ValueLabel.Text = "Low";
			this.BleTp6ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleConnectedBit
			// 
			this.BleConnectedBit.BackColor = System.Drawing.Color.Transparent;
			this.BleConnectedBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleConnectedBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleConnectedBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleConnectedBit.Location = new System.Drawing.Point(253, 29);
			this.BleConnectedBit.Name = "BleConnectedBit";
			this.BleConnectedBit.Size = new System.Drawing.Size(21, 21);
			this.BleConnectedBit.TabIndex = 16;
			this.BleConnectedBit.Text = "0";
			this.BleConnectedBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp28DirectionLabel
			// 
			this.BleTp28DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp28DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp28DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp28DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp28DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp28DirectionLabel.Location = new System.Drawing.Point(47, 290);
			this.BleTp28DirectionLabel.Name = "BleTp28DirectionLabel";
			this.BleTp28DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp28DirectionLabel.TabIndex = 16;
			this.BleTp28DirectionLabel.Text = "In";
			this.BleTp28DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp5ValueLabel
			// 
			this.BleTp5ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp5ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp5ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp5ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp5ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp5ValueLabel.Location = new System.Drawing.Point(133, 219);
			this.BleTp5ValueLabel.Name = "BleTp5ValueLabel";
			this.BleTp5ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp5ValueLabel.TabIndex = 16;
			this.BleTp5ValueLabel.Text = "Low";
			this.BleTp5ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp25DirectionLabel
			// 
			this.BleTp25DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp25DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp25DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp25DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp25DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp25DirectionLabel.Location = new System.Drawing.Point(47, 266);
			this.BleTp25DirectionLabel.Name = "BleTp25DirectionLabel";
			this.BleTp25DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp25DirectionLabel.TabIndex = 16;
			this.BleTp25DirectionLabel.Text = "In";
			this.BleTp25DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleIntSureFiTxInProgressBit
			// 
			this.BleIntSureFiTxInProgressBit.BackColor = System.Drawing.Color.Transparent;
			this.BleIntSureFiTxInProgressBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleIntSureFiTxInProgressBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleIntSureFiTxInProgressBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleIntSureFiTxInProgressBit.Location = new System.Drawing.Point(253, 236);
			this.BleIntSureFiTxInProgressBit.Name = "BleIntSureFiTxInProgressBit";
			this.BleIntSureFiTxInProgressBit.Size = new System.Drawing.Size(21, 21);
			this.BleIntSureFiTxInProgressBit.TabIndex = 16;
			this.BleIntSureFiTxInProgressBit.Text = "D";
			this.BleIntSureFiTxInProgressBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp6DirectionLabel
			// 
			this.BleTp6DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp6DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp6DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp6DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp6DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp6DirectionLabel.Location = new System.Drawing.Point(47, 242);
			this.BleTp6DirectionLabel.Name = "BleTp6DirectionLabel";
			this.BleTp6DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp6DirectionLabel.TabIndex = 16;
			this.BleTp6DirectionLabel.Text = "In";
			this.BleTp6DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp4ValueLabel
			// 
			this.BleTp4ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp4ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp4ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp4ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp4ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp4ValueLabel.Location = new System.Drawing.Point(133, 196);
			this.BleTp4ValueLabel.Name = "BleTp4ValueLabel";
			this.BleTp4ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp4ValueLabel.TabIndex = 16;
			this.BleTp4ValueLabel.Text = "Low";
			this.BleTp4ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp5DirectionLabel
			// 
			this.BleTp5DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp5DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp5DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp5DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp5DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp5DirectionLabel.Location = new System.Drawing.Point(47, 219);
			this.BleTp5DirectionLabel.Name = "BleTp5DirectionLabel";
			this.BleTp5DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp5DirectionLabel.TabIndex = 16;
			this.BleTp5DirectionLabel.Text = "In";
			this.BleTp5DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleSureFiTxInProgressBit
			// 
			this.BleSureFiTxInProgressBit.BackColor = System.Drawing.Color.Transparent;
			this.BleSureFiTxInProgressBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleSureFiTxInProgressBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleSureFiTxInProgressBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleSureFiTxInProgressBit.Location = new System.Drawing.Point(253, 98);
			this.BleSureFiTxInProgressBit.Name = "BleSureFiTxInProgressBit";
			this.BleSureFiTxInProgressBit.Size = new System.Drawing.Size(21, 21);
			this.BleSureFiTxInProgressBit.TabIndex = 16;
			this.BleSureFiTxInProgressBit.Text = "0";
			this.BleSureFiTxInProgressBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp4DirectionLabel
			// 
			this.BleTp4DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp4DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp4DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp4DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp4DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp4DirectionLabel.Location = new System.Drawing.Point(47, 196);
			this.BleTp4DirectionLabel.Name = "BleTp4DirectionLabel";
			this.BleTp4DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp4DirectionLabel.TabIndex = 16;
			this.BleTp4DirectionLabel.Text = "In";
			this.BleTp4DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp3ValueLabel
			// 
			this.BleTp3ValueLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp3ValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp3ValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp3ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp3ValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp3ValueLabel.Location = new System.Drawing.Point(133, 172);
			this.BleTp3ValueLabel.Name = "BleTp3ValueLabel";
			this.BleTp3ValueLabel.Size = new System.Drawing.Size(38, 21);
			this.BleTp3ValueLabel.TabIndex = 16;
			this.BleTp3ValueLabel.Text = "Low";
			this.BleTp3ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp3DirectionLabel
			// 
			this.BleTp3DirectionLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp3DirectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp3DirectionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp3DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp3DirectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp3DirectionLabel.Location = new System.Drawing.Point(47, 172);
			this.BleTp3DirectionLabel.Name = "BleTp3DirectionLabel";
			this.BleTp3DirectionLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp3DirectionLabel.TabIndex = 16;
			this.BleTp3DirectionLabel.Text = "In";
			this.BleTp3DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleIntWasResetBit
			// 
			this.BleIntWasResetBit.BackColor = System.Drawing.Color.Transparent;
			this.BleIntWasResetBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleIntWasResetBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleIntWasResetBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleIntWasResetBit.Location = new System.Drawing.Point(253, 144);
			this.BleIntWasResetBit.Name = "BleIntWasResetBit";
			this.BleIntWasResetBit.Size = new System.Drawing.Size(21, 21);
			this.BleIntWasResetBit.TabIndex = 16;
			this.BleIntWasResetBit.Text = "D";
			this.BleIntWasResetBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleWasResetBit
			// 
			this.BleWasResetBit.BackColor = System.Drawing.Color.Transparent;
			this.BleWasResetBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleWasResetBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleWasResetBit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleWasResetBit.Location = new System.Drawing.Point(253, 6);
			this.BleWasResetBit.Name = "BleWasResetBit";
			this.BleWasResetBit.Size = new System.Drawing.Size(21, 21);
			this.BleWasResetBit.TabIndex = 16;
			this.BleWasResetBit.Text = "0";
			this.BleWasResetBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TxTextbox
			// 
			this.TxTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxTextbox.Location = new System.Drawing.Point(29, 376);
			this.TxTextbox.Name = "TxTextbox";
			this.TxTextbox.Size = new System.Drawing.Size(289, 20);
			this.TxTextbox.TabIndex = 6;
			this.TxTextbox.TextChanged += new System.EventHandler(this.TxTextbox_TextChanged);
			this.TxTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxTextbox_KeyDown);
			// 
			// TransmitButton
			// 
			this.TransmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TransmitButton.Location = new System.Drawing.Point(324, 374);
			this.TransmitButton.Name = "TransmitButton";
			this.TransmitButton.Size = new System.Drawing.Size(75, 23);
			this.TransmitButton.TabIndex = 7;
			this.TransmitButton.Text = "Transmit";
			this.TransmitButton.UseVisualStyleBackColor = true;
			this.TransmitButton.Click += new System.EventHandler(this.TransmitButton_Click);
			// 
			// RxTextbox
			// 
			this.RxTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxTextbox.Location = new System.Drawing.Point(480, 375);
			this.RxTextbox.Name = "RxTextbox";
			this.RxTextbox.ReadOnly = true;
			this.RxTextbox.Size = new System.Drawing.Size(215, 20);
			this.RxTextbox.TabIndex = 11;
			// 
			// RxClearButton
			// 
			this.RxClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxClearButton.Location = new System.Drawing.Point(700, 374);
			this.RxClearButton.Name = "RxClearButton";
			this.RxClearButton.Size = new System.Drawing.Size(50, 23);
			this.RxClearButton.TabIndex = 12;
			this.RxClearButton.Text = "Clear";
			this.RxClearButton.UseVisualStyleBackColor = true;
			this.RxClearButton.Click += new System.EventHandler(this.RxClearButton_Click);
			// 
			// TxHexCheckbox
			// 
			this.TxHexCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TxHexCheckbox.AutoSize = true;
			this.TxHexCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.TxHexCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxHexCheckbox.Location = new System.Drawing.Point(4, 374);
			this.TxHexCheckbox.Name = "TxHexCheckbox";
			this.TxHexCheckbox.Size = new System.Drawing.Size(25, 27);
			this.TxHexCheckbox.TabIndex = 13;
			this.TxHexCheckbox.Text = "HEX";
			this.TxHexCheckbox.UseVisualStyleBackColor = true;
			this.TxHexCheckbox.CheckedChanged += new System.EventHandler(this.TxHexCheckbox_CheckedChanged);
			// 
			// AckTextbox
			// 
			this.AckTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AckTextbox.Location = new System.Drawing.Point(29, 416);
			this.AckTextbox.Name = "AckTextbox";
			this.AckTextbox.ReadOnly = true;
			this.AckTextbox.Size = new System.Drawing.Size(289, 20);
			this.AckTextbox.TabIndex = 14;
			// 
			// AckClearButton
			// 
			this.AckClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckClearButton.Location = new System.Drawing.Point(324, 414);
			this.AckClearButton.Name = "AckClearButton";
			this.AckClearButton.Size = new System.Drawing.Size(75, 23);
			this.AckClearButton.TabIndex = 15;
			this.AckClearButton.Text = "Clear";
			this.AckClearButton.UseVisualStyleBackColor = true;
			this.AckClearButton.Click += new System.EventHandler(this.AckClearButton_Click);
			// 
			// TxSuccessLabel
			// 
			this.TxSuccessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxSuccessLabel.AutoSize = true;
			this.TxSuccessLabel.ForeColor = System.Drawing.Color.DarkGreen;
			this.TxSuccessLabel.Location = new System.Drawing.Point(405, 373);
			this.TxSuccessLabel.Name = "TxSuccessLabel";
			this.TxSuccessLabel.Size = new System.Drawing.Size(48, 13);
			this.TxSuccessLabel.TabIndex = 17;
			this.TxSuccessLabel.Text = "Success";
			// 
			// TxLengthLabel
			// 
			this.TxLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxLengthLabel.AutoSize = true;
			this.TxLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxLengthLabel.Location = new System.Drawing.Point(186, 363);
			this.TxLengthLabel.Name = "TxLengthLabel";
			this.TxLengthLabel.Size = new System.Drawing.Size(69, 13);
			this.TxLengthLabel.TabIndex = 18;
			this.TxLengthLabel.Text = "Length: 0 / 0";
			// 
			// TxCountLabel
			// 
			this.TxCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxCountLabel.AutoSize = true;
			this.TxCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxCountLabel.Location = new System.Drawing.Point(272, 363);
			this.TxCountLabel.Name = "TxCountLabel";
			this.TxCountLabel.Size = new System.Drawing.Size(47, 13);
			this.TxCountLabel.TabIndex = 18;
			this.TxCountLabel.Text = "Count: 0";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(478, 362);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Receive";
			// 
			// RxLengthLabel
			// 
			this.RxLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxLengthLabel.AutoSize = true;
			this.RxLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxLengthLabel.Location = new System.Drawing.Point(589, 362);
			this.RxLengthLabel.Name = "RxLengthLabel";
			this.RxLengthLabel.Size = new System.Drawing.Size(52, 13);
			this.RxLengthLabel.TabIndex = 18;
			this.RxLengthLabel.Text = "Length: 0";
			// 
			// RxCountLabel
			// 
			this.RxCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxCountLabel.AutoSize = true;
			this.RxCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxCountLabel.Location = new System.Drawing.Point(649, 362);
			this.RxCountLabel.Name = "RxCountLabel";
			this.RxCountLabel.Size = new System.Drawing.Size(47, 13);
			this.RxCountLabel.TabIndex = 18;
			this.RxCountLabel.Text = "Count: 0";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(29, 363);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Transmit";
			// 
			// RxHexCheckbox
			// 
			this.RxHexCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxHexCheckbox.AutoSize = true;
			this.RxHexCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.RxHexCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxHexCheckbox.Location = new System.Drawing.Point(455, 374);
			this.RxHexCheckbox.Name = "RxHexCheckbox";
			this.RxHexCheckbox.Size = new System.Drawing.Size(25, 27);
			this.RxHexCheckbox.TabIndex = 13;
			this.RxHexCheckbox.Text = "HEX";
			this.RxHexCheckbox.UseVisualStyleBackColor = true;
			this.RxHexCheckbox.CheckedChanged += new System.EventHandler(this.RxHexCheckbox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(27, 403);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Acknowledgement";
			// 
			// AckHexCheckbox
			// 
			this.AckHexCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AckHexCheckbox.AutoSize = true;
			this.AckHexCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.AckHexCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckHexCheckbox.Location = new System.Drawing.Point(5, 415);
			this.AckHexCheckbox.Name = "AckHexCheckbox";
			this.AckHexCheckbox.Size = new System.Drawing.Size(25, 27);
			this.AckHexCheckbox.TabIndex = 13;
			this.AckHexCheckbox.Text = "HEX";
			this.AckHexCheckbox.UseVisualStyleBackColor = true;
			this.AckHexCheckbox.CheckedChanged += new System.EventHandler(this.AckHexCheckbox_CheckedChanged);
			// 
			// AckLengthLabel
			// 
			this.AckLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckLengthLabel.AutoSize = true;
			this.AckLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckLengthLabel.Location = new System.Drawing.Point(207, 403);
			this.AckLengthLabel.Name = "AckLengthLabel";
			this.AckLengthLabel.Size = new System.Drawing.Size(52, 13);
			this.AckLengthLabel.TabIndex = 18;
			this.AckLengthLabel.Text = "Length: 0";
			// 
			// AckCountLabel
			// 
			this.AckCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckCountLabel.AutoSize = true;
			this.AckCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckCountLabel.Location = new System.Drawing.Point(272, 403);
			this.AckCountLabel.Name = "AckCountLabel";
			this.AckCountLabel.Size = new System.Drawing.Size(47, 13);
			this.AckCountLabel.TabIndex = 18;
			this.AckCountLabel.Text = "Count: 0";
			// 
			// TxRssiLabel
			// 
			this.TxRssiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxRssiLabel.AutoSize = true;
			this.TxRssiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxRssiLabel.Location = new System.Drawing.Point(400, 414);
			this.TxRssiLabel.Name = "TxRssiLabel";
			this.TxRssiLabel.Size = new System.Drawing.Size(37, 12);
			this.TxRssiLabel.TabIndex = 19;
			this.TxRssiLabel.Text = "RSSI: 0";
			// 
			// TxSnrLabel
			// 
			this.TxSnrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxSnrLabel.AutoSize = true;
			this.TxSnrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxSnrLabel.Location = new System.Drawing.Point(402, 425);
			this.TxSnrLabel.Name = "TxSnrLabel";
			this.TxSnrLabel.Size = new System.Drawing.Size(35, 12);
			this.TxSnrLabel.TabIndex = 19;
			this.TxSnrLabel.Text = "SNR: 0";
			// 
			// RxRssiLabel
			// 
			this.RxRssiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxRssiLabel.AutoSize = true;
			this.RxRssiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxRssiLabel.Location = new System.Drawing.Point(706, 400);
			this.RxRssiLabel.Name = "RxRssiLabel";
			this.RxRssiLabel.Size = new System.Drawing.Size(37, 12);
			this.RxRssiLabel.TabIndex = 19;
			this.RxRssiLabel.Text = "RSSI: 0";
			// 
			// RxSnrLabel
			// 
			this.RxSnrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RxSnrLabel.AutoSize = true;
			this.RxSnrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RxSnrLabel.Location = new System.Drawing.Point(708, 411);
			this.RxSnrLabel.Name = "RxSnrLabel";
			this.RxSnrLabel.Size = new System.Drawing.Size(35, 12);
			this.RxSnrLabel.TabIndex = 19;
			this.RxSnrLabel.Text = "SNR: 0";
			// 
			// OutputClearButton
			// 
			this.OutputClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputClearButton.Location = new System.Drawing.Point(692, 3);
			this.OutputClearButton.Name = "OutputClearButton";
			this.OutputClearButton.Size = new System.Drawing.Size(51, 23);
			this.OutputClearButton.TabIndex = 20;
			this.OutputClearButton.Text = "Clear";
			this.OutputClearButton.UseVisualStyleBackColor = true;
			this.OutputClearButton.Click += new System.EventHandler(this.OutputClearButton_Click);
			// 
			// AckDataTextbox
			// 
			this.AckDataTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckDataTextbox.Location = new System.Drawing.Point(480, 416);
			this.AckDataTextbox.Name = "AckDataTextbox";
			this.AckDataTextbox.Size = new System.Drawing.Size(215, 20);
			this.AckDataTextbox.TabIndex = 16;
			this.AckDataTextbox.TextChanged += new System.EventHandler(this.AckDataTextbox_TextChanged);
			this.AckDataTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AckDataTextbox_KeyDown);
			this.AckDataTextbox.Leave += new System.EventHandler(this.AckDataTextbox_Leave);
			// 
			// AckDataLengthLabel
			// 
			this.AckDataLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckDataLengthLabel.AutoSize = true;
			this.AckDataLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckDataLengthLabel.Location = new System.Drawing.Point(614, 403);
			this.AckDataLengthLabel.Name = "AckDataLengthLabel";
			this.AckDataLengthLabel.Size = new System.Drawing.Size(69, 13);
			this.AckDataLengthLabel.TabIndex = 17;
			this.AckDataLengthLabel.Text = "Length: 0 / 0";
			// 
			// AckDataHexCheckbox
			// 
			this.AckDataHexCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AckDataHexCheckbox.AutoSize = true;
			this.AckDataHexCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.AckDataHexCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AckDataHexCheckbox.Location = new System.Drawing.Point(455, 416);
			this.AckDataHexCheckbox.Name = "AckDataHexCheckbox";
			this.AckDataHexCheckbox.Size = new System.Drawing.Size(25, 27);
			this.AckDataHexCheckbox.TabIndex = 13;
			this.AckDataHexCheckbox.Text = "HEX";
			this.AckDataHexCheckbox.UseVisualStyleBackColor = true;
			this.AckDataHexCheckbox.CheckedChanged += new System.EventHandler(this.AckDataHexCheckbox_CheckedChanged);
			// 
			// TxRetriesLabel
			// 
			this.TxRetriesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxRetriesLabel.AutoSize = true;
			this.TxRetriesLabel.ForeColor = System.Drawing.Color.DarkGreen;
			this.TxRetriesLabel.Location = new System.Drawing.Point(402, 384);
			this.TxRetriesLabel.Name = "TxRetriesLabel";
			this.TxRetriesLabel.Size = new System.Drawing.Size(55, 13);
			this.TxRetriesLabel.TabIndex = 17;
			this.TxRetriesLabel.Text = "0/0 retries";
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label27.Location = new System.Drawing.Point(479, 403);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(52, 13);
			this.label27.TabIndex = 18;
			this.label27.Text = "Ack Data";
			// 
			// PrintStatusCheckbox
			// 
			this.PrintStatusCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PrintStatusCheckbox.AutoSize = true;
			this.PrintStatusCheckbox.Location = new System.Drawing.Point(630, 7);
			this.PrintStatusCheckbox.Name = "PrintStatusCheckbox";
			this.PrintStatusCheckbox.Size = new System.Drawing.Size(56, 17);
			this.PrintStatusCheckbox.TabIndex = 21;
			this.PrintStatusCheckbox.Text = "Status";
			this.PrintStatusCheckbox.UseVisualStyleBackColor = true;
			this.PrintStatusCheckbox.CheckedChanged += new System.EventHandler(this.PrintStatusCheckbox_CheckedChanged);
			// 
			// BleTp3PullLabel
			// 
			this.BleTp3PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp3PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp3PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp3PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp3PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp3PullLabel.Location = new System.Drawing.Point(90, 172);
			this.BleTp3PullLabel.Name = "BleTp3PullLabel";
			this.BleTp3PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp3PullLabel.TabIndex = 16;
			this.BleTp3PullLabel.Text = "None";
			this.BleTp3PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label77
			// 
			this.label77.AutoSize = true;
			this.label77.Location = new System.Drawing.Point(98, 159);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(24, 13);
			this.label77.TabIndex = 43;
			this.label77.Text = "Pull";
			// 
			// BleTp4PullLabel
			// 
			this.BleTp4PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp4PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp4PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp4PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp4PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp4PullLabel.Location = new System.Drawing.Point(90, 195);
			this.BleTp4PullLabel.Name = "BleTp4PullLabel";
			this.BleTp4PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp4PullLabel.TabIndex = 44;
			this.BleTp4PullLabel.Text = "None";
			this.BleTp4PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp5PullLabel
			// 
			this.BleTp5PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp5PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp5PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp5PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp5PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp5PullLabel.Location = new System.Drawing.Point(90, 219);
			this.BleTp5PullLabel.Name = "BleTp5PullLabel";
			this.BleTp5PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp5PullLabel.TabIndex = 44;
			this.BleTp5PullLabel.Text = "None";
			this.BleTp5PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp6PullLabel
			// 
			this.BleTp6PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp6PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp6PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp6PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp6PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp6PullLabel.Location = new System.Drawing.Point(90, 242);
			this.BleTp6PullLabel.Name = "BleTp6PullLabel";
			this.BleTp6PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp6PullLabel.TabIndex = 44;
			this.BleTp6PullLabel.Text = "None";
			this.BleTp6PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp25PullLabel
			// 
			this.BleTp25PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp25PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp25PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp25PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp25PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp25PullLabel.Location = new System.Drawing.Point(90, 266);
			this.BleTp25PullLabel.Name = "BleTp25PullLabel";
			this.BleTp25PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp25PullLabel.TabIndex = 44;
			this.BleTp25PullLabel.Text = "None";
			this.BleTp25PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BleTp28PullLabel
			// 
			this.BleTp28PullLabel.BackColor = System.Drawing.Color.Transparent;
			this.BleTp28PullLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BleTp28PullLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BleTp28PullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BleTp28PullLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BleTp28PullLabel.Location = new System.Drawing.Point(90, 290);
			this.BleTp28PullLabel.Name = "BleTp28PullLabel";
			this.BleTp28PullLabel.Size = new System.Drawing.Size(41, 21);
			this.BleTp28PullLabel.TabIndex = 44;
			this.BleTp28PullLabel.Text = "None";
			this.BleTp28PullLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(7, 25);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(22, 13);
			this.label72.TabIndex = 17;
			this.label72.Text = "2 +";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(755, 464);
			this.Controls.Add(this.PrintStatusCheckbox);
			this.Controls.Add(this.AckDataLengthLabel);
			this.Controls.Add(this.OutputClearButton);
			this.Controls.Add(this.AckDataTextbox);
			this.Controls.Add(this.RxSnrLabel);
			this.Controls.Add(this.RxRssiLabel);
			this.Controls.Add(this.TxSnrLabel);
			this.Controls.Add(this.TxRssiLabel);
			this.Controls.Add(this.RxCountLabel);
			this.Controls.Add(this.AckCountLabel);
			this.Controls.Add(this.TxCountLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.RxLengthLabel);
			this.Controls.Add(this.AckLengthLabel);
			this.Controls.Add(this.TxLengthLabel);
			this.Controls.Add(this.TxRetriesLabel);
			this.Controls.Add(this.TxSuccessLabel);
			this.Controls.Add(this.AckDataHexCheckbox);
			this.Controls.Add(this.AckClearButton);
			this.Controls.Add(this.AckTextbox);
			this.Controls.Add(this.AckHexCheckbox);
			this.Controls.Add(this.RxHexCheckbox);
			this.Controls.Add(this.TxHexCheckbox);
			this.Controls.Add(this.RxClearButton);
			this.Controls.Add(this.RxTextbox);
			this.Controls.Add(this.TransmitButton);
			this.Controls.Add(this.TxTextbox);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.HumanReadableCheckbox);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.OutputTextbox);
			this.Controls.Add(this.StatusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(684, 415);
			this.Name = "MainForm";
			this.Text = "Sure-Fi Module Developer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.MainTabControl.ResumeLayout(false);
			this.TabPageRadio.ResumeLayout(false);
			this.TabPageRadio.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FhssTableNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumRetriesNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PayloadSizeNumeric)).EndInit();
			this.TabPageOther.ResumeLayout(false);
			this.TabPageOther.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ButtonHoldTimeNumeric)).EndInit();
			this.TabPageCommands.ResumeLayout(false);
			this.TabPageCommands.PerformLayout();
			this.TabPageStatus.ResumeLayout(false);
			this.TabPageStatus.PerformLayout();
			this.TabPageInt.ResumeLayout(false);
			this.TabPageInt.PerformLayout();
			this.TabPageBluetooth.ResumeLayout(false);
			this.TabPageBluetooth.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.Timer TickTimer;
		private System.Windows.Forms.Button DisconnectButton;
		public System.Windows.Forms.TextBox OutputTextbox;
		public System.Windows.Forms.CheckBox HumanReadableCheckbox;
		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.TabPage TabPageRadio;
		private System.Windows.Forms.TabPage TabPageOther;
		private System.Windows.Forms.TextBox TxTextbox;
		public System.Windows.Forms.Button TransmitButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button RxClearButton;
		private System.Windows.Forms.CheckBox TxHexCheckbox;
		private System.Windows.Forms.Button AckClearButton;
		private System.Windows.Forms.Label TxLengthLabel;
		private System.Windows.Forms.Label TxCountLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label RxPacketSizeLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage TabPageStatus;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label LedLabel1;
		private System.Windows.Forms.Label LedLabel2;
		private System.Windows.Forms.Label LedLabel3;
		private System.Windows.Forms.Label LedLabel4;
		private System.Windows.Forms.Label LedLabel5;
		private System.Windows.Forms.Label LedLabel6;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TabPage TabPageCommands;
		private System.Windows.Forms.Button ShowQosButton;
		private System.Windows.Forms.Button LightshowButton;
		private System.Windows.Forms.Button RefreshSettingsButton;
		private System.Windows.Forms.Button DefaultSettingsButton;
		private System.Windows.Forms.Button SleepButton;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.Button StartEncryptionButton;
		public System.Windows.Forms.CheckBox AutoClearFlagsCheckbox;
		public System.Windows.Forms.Label StatusConfigLabel;
		public System.Windows.Forms.Label StatusClearableLabel;
		public System.Windows.Forms.Label StatusOtherLabel;
		public System.Windows.Forms.Label StatusStateLabel;
		private System.Windows.Forms.Label ButtonHeldBit;
		private System.Windows.Forms.Label TxLedModeBit;
		private System.Windows.Forms.Label AckPacketReadyBit;
		private System.Windows.Forms.Label SettingsPendingBit;
		private System.Windows.Forms.Label ButtonPressedBit;
		private System.Windows.Forms.Label RadioStateBit4;
		private System.Windows.Forms.Label RxLedModeBit;
		private System.Windows.Forms.Label RxPacketReadyBit;
		private System.Windows.Forms.Label ButtonDownBit;
		private System.Windows.Forms.Label RxInProgressBit;
		private System.Windows.Forms.Label EncryptionRekeyBit;
		private System.Windows.Forms.Label AutoClearFlagsBit;
		private System.Windows.Forms.Label RadioStateBit3;
		private System.Windows.Forms.Label TransmitFinishedBit;
		private System.Windows.Forms.Label AutoRekeyBit;
		private System.Windows.Forms.Label ChecksumErrorBit;
		private System.Windows.Forms.Label ShowingQosBit;
		private System.Windows.Forms.Label InterruptDrivenBit;
		private System.Windows.Forms.Label WasResetBit;
		private System.Windows.Forms.Label EncryptionActiveBit;
		private System.Windows.Forms.Label DoingLightshowBit;
		private System.Windows.Forms.Label RadioStateBit2;
		private System.Windows.Forms.Label BusyBit;
		private System.Windows.Forms.Label RadioStateBit1;
		private System.Windows.Forms.Label EncryptionReadyLabel;
		private System.Windows.Forms.Button OutputClearButton;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Button GetTimeOnAirButton;
		private System.Windows.Forms.Button GetModuleVersionButton;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button GetRandomNumberButton;
		public System.Windows.Forms.Label FirmwareVersionLabel;
		public System.Windows.Forms.Label MicroVersionLabel;
		public System.Windows.Forms.Label HardwareVersionLabel;
		private System.Windows.Forms.Label label23;
		public System.Windows.Forms.Label TimeOnAirLabel;
		public System.Windows.Forms.Label RandomNumberLabel;
		public System.Windows.Forms.NumericUpDown NumRetriesNumeric;
		public System.Windows.Forms.NumericUpDown PayloadSizeNumeric;
		public System.Windows.Forms.TextBox TxUidTextbox;
		public System.Windows.Forms.TextBox RxUidTextbox;
		public System.Windows.Forms.ComboBox BandwidthCombobox;
		public System.Windows.Forms.ComboBox SpreadingFactorCombobox;
		public System.Windows.Forms.ComboBox RadioModeCombobox;
		public System.Windows.Forms.ComboBox TransmitPowerCombobox;
		public System.Windows.Forms.NumericUpDown FhssTableNumeric;
		public System.Windows.Forms.ComboBox PolarityCombobox;
		public System.Windows.Forms.CheckBox AcksEnabledCheckbox;
		public System.Windows.Forms.Label RxUidLengthLabel;
		public System.Windows.Forms.Label TxUidLengthLabel;
		public System.Windows.Forms.Label AckDataLengthLabel;
		public System.Windows.Forms.TextBox AckDataTextbox;
		public System.Windows.Forms.CheckBox AckDataHexCheckbox;
		private System.Windows.Forms.Label label27;
		public System.Windows.Forms.Label TxSuccessLabel;
		public System.Windows.Forms.Label TxRetriesLabel;
		public System.Windows.Forms.Label TxRssiLabel;
		public System.Windows.Forms.Label TxSnrLabel;
		public System.Windows.Forms.TextBox RxTextbox;
		public System.Windows.Forms.CheckBox RxHexCheckbox;
		public System.Windows.Forms.Label RxLengthLabel;
		public System.Windows.Forms.Label RxCountLabel;
		public System.Windows.Forms.Label RxRssiLabel;
		public System.Windows.Forms.Label RxSnrLabel;
		public System.Windows.Forms.TextBox AckTextbox;
		public System.Windows.Forms.CheckBox AckHexCheckbox;
		public System.Windows.Forms.Label AckLengthLabel;
		public System.Windows.Forms.Label AckCountLabel;
		private System.Windows.Forms.CheckBox PrintStatusCheckbox;
		public System.Windows.Forms.ComboBox LedCombo1;
		public System.Windows.Forms.ComboBox LedCombo2;
		public System.Windows.Forms.ComboBox LedCombo3;
		public System.Windows.Forms.ComboBox LedCombo4;
		public System.Windows.Forms.ComboBox LedCombo5;
		public System.Windows.Forms.ComboBox LedCombo6;
		private System.Windows.Forms.Button ClearIndicationsButton;
		public System.Windows.Forms.CheckBox QuietModeCheckbox;
		public System.Windows.Forms.ComboBox TxLedModeCombobox;
		public System.Windows.Forms.ComboBox RxLedModeCombobox;
		public System.Windows.Forms.ComboBox ButtonConfigCombobox;
		public System.Windows.Forms.NumericUpDown ButtonHoldTimeNumeric;
		public System.Windows.Forms.ComboBox QosConfigCombobox;
		private System.Windows.Forms.Button GetStatusButton;
		public System.Windows.Forms.Button ClearFlagsButton;
		private System.Windows.Forms.Button EnableAllIntButton;
		private System.Windows.Forms.Button DisableAllIntButton;
		public System.Windows.Forms.Label IntConfigLabel;
		public System.Windows.Forms.Label IntClearableLabel;
		public System.Windows.Forms.Label IntOtherLabel;
		public System.Windows.Forms.Label IntStateLabel;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label60;
		public System.Windows.Forms.Label IntButtonHeldBit;
		public System.Windows.Forms.Label IntTxLedModeBit;
		public System.Windows.Forms.Label IntAckPacketReadyBit;
		public System.Windows.Forms.Label IntSettingsPendingBit;
		public System.Windows.Forms.Label IntButtonPressedBit;
		public System.Windows.Forms.Label IntRadioStateBit4;
		public System.Windows.Forms.Label IntRxLedModeBit;
		public System.Windows.Forms.Label IntRxPacketReadyBit;
		public System.Windows.Forms.Label IntButtonDownBit;
		public System.Windows.Forms.Label IntRxInProgressBit;
		public System.Windows.Forms.Label IntEncryptionRekeyBit;
		public System.Windows.Forms.Label IntAutoClearFlagsBit;
		public System.Windows.Forms.Label IntRadioStateBit3;
		public System.Windows.Forms.Label IntTransmitFinishedBit;
		public System.Windows.Forms.Label IntAutoRekeyBit;
		public System.Windows.Forms.Label IntChecksumErrorBit;
		public System.Windows.Forms.Label IntShowingQosBit;
		public System.Windows.Forms.Label IntInterruptDrivenBit;
		public System.Windows.Forms.Label IntWasResetBit;
		public System.Windows.Forms.Label IntEncryptionActiveBit;
		public System.Windows.Forms.Label IntDoingLightshowBit;
		public System.Windows.Forms.Label IntRadioStateBit2;
		public System.Windows.Forms.Label IntBusyBit;
		public System.Windows.Forms.Label IntRadioStateBit1;
		public System.Windows.Forms.TabPage TabPageInt;
		public System.Windows.Forms.Label RadioStateStrLabel;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button GetRegisteredSerialButton;
		public System.Windows.Forms.Label RegisteredSerialLabel;
		public System.Windows.Forms.CheckBox TableHoppingCheckbox;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label OnBaseTableBit;
		private System.Windows.Forms.Label ChangingTablesBit;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label61;
		public System.Windows.Forms.Label IntOnBaseTableBit;
		public System.Windows.Forms.Label IntChangingTablesBit;
		private System.Windows.Forms.TabPage TabPageBluetooth;
		public System.Windows.Forms.Label BleFirmwareVersionLabel;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Button BleGetVersionButton;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label59;
		public System.Windows.Forms.TextBox BleAdvertisingDataTextbox;
		public System.Windows.Forms.TextBox BleAdvertisingNameTextbox;
		private System.Windows.Forms.Button BleCloseConnectionButton;
		public System.Windows.Forms.Button BleStartAdvertisingButton;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button BleGetStatusButton;
		private System.Windows.Forms.Label label107;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Button BleDisableAllButton;
		private System.Windows.Forms.Button BleEnableAllButton;
		private System.Windows.Forms.Button BleClearResetFlagButton;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label77;
		public System.Windows.Forms.Label BleTp28PullLabel;
		public System.Windows.Forms.Label BleTp25PullLabel;
		public System.Windows.Forms.Label BleTp6PullLabel;
		public System.Windows.Forms.Label BleTp5PullLabel;
		public System.Windows.Forms.Label BleTp4PullLabel;
		public System.Windows.Forms.Label BleTp3PullLabel;
		public System.Windows.Forms.Label BleAdvertisingNameLengthLabel;
		public System.Windows.Forms.Label BleAdvertisingDataLengthLabel;
		public System.Windows.Forms.Label BleInDfuModeBit;
		public System.Windows.Forms.Label BleAdvertisingBit;
		public System.Windows.Forms.Label BleConnectedBit;
		public System.Windows.Forms.Label BleSureFiTxInProgressBit;
		public System.Windows.Forms.Label BleWasResetBit;
		public System.Windows.Forms.CheckBox BleTp28AutoCheckbox;
		public System.Windows.Forms.CheckBox BleTp25AutoCheckbox;
		public System.Windows.Forms.CheckBox BleTp6AutoCheckbox;
		public System.Windows.Forms.CheckBox BleTp5AutoCheckbox;
		public System.Windows.Forms.CheckBox BleTp4AutoCheckbox;
		public System.Windows.Forms.CheckBox BleTp3AutoCheckbox;
		public System.Windows.Forms.Button BleTp28GetButton;
		public System.Windows.Forms.Button BleTp25GetButton;
		public System.Windows.Forms.Button BleTp6GetButton;
		public System.Windows.Forms.Button BleTp5GetButton;
		public System.Windows.Forms.Button BleTp4GetButton;
		public System.Windows.Forms.Button BleTp3GetButton;
		public System.Windows.Forms.Label BleIntInDfuModeBit;
		public System.Windows.Forms.Label BleIntAdvertisingBit;
		public System.Windows.Forms.Label BleTp28ValueLabel;
		public System.Windows.Forms.Label BleTp25ValueLabel;
		public System.Windows.Forms.Label BleIntConnectedBit;
		public System.Windows.Forms.Label BleTp6ValueLabel;
		public System.Windows.Forms.Label BleTp28DirectionLabel;
		public System.Windows.Forms.Label BleTp5ValueLabel;
		public System.Windows.Forms.Label BleTp25DirectionLabel;
		public System.Windows.Forms.Label BleIntSureFiTxInProgressBit;
		public System.Windows.Forms.Label BleTp6DirectionLabel;
		public System.Windows.Forms.Label BleTp4ValueLabel;
		public System.Windows.Forms.Label BleTp5DirectionLabel;
		public System.Windows.Forms.Label BleTp4DirectionLabel;
		public System.Windows.Forms.Label BleTp3ValueLabel;
		public System.Windows.Forms.Label BleTp3DirectionLabel;
		public System.Windows.Forms.Label BleIntWasResetBit;
		private System.Windows.Forms.Label label72;
	}
}