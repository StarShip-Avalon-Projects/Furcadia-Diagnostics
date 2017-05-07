namespace Dream_Runtime_Analyzer
{
    partial class LiveCaptureForm
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
            this.grpLoginSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomServer = new System.Windows.Forms.CheckBox();
            this.tbFurcPort = new System.Windows.Forms.NumericUpDown();
            this.tbFurcAddress = new System.Windows.Forms.TextBox();
            this.btnLoadCharacter = new System.Windows.Forms.Button();
            this.tbFurcPassword = new System.Windows.Forms.TextBox();
            this.tbFurcUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.grpCaptureSettings = new System.Windows.Forms.GroupBox();
            this.cbStopAuto = new System.Windows.Forms.CheckBox();
            this.cbStartAuto = new System.Windows.Forms.CheckBox();
            this.selectTimeUnits = new System.Windows.Forms.ComboBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveBrowse = new System.Windows.Forms.Button();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.cbSaveData = new System.Windows.Forms.CheckBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgLoad = new System.Windows.Forms.OpenFileDialog();
            this.grpCaptureData = new System.Windows.Forms.GroupBox();
            this.txtCaptureTime = new System.Windows.Forms.Label();
            this.txtLongestInstruction = new System.Windows.Forms.Label();
            this.txtAverageSpeed = new System.Windows.Forms.Label();
            this.txtRecvAvatar = new System.Windows.Forms.Label();
            this.txtRecvDsRelated = new System.Windows.Forms.Label();
            this.txtRecvTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbServerData = new System.Windows.Forms.TextBox();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tSync = new System.Windows.Forms.Timer(this.components);
            this.tStopCapture = new System.Windows.Forms.Timer(this.components);
            this.grpLoginSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFurcPort)).BeginInit();
            this.grpCaptureSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.grpCaptureData.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLoginSettings
            // 
            this.grpLoginSettings.Controls.Add(this.label3);
            this.grpLoginSettings.Controls.Add(this.label2);
            this.grpLoginSettings.Controls.Add(this.label1);
            this.grpLoginSettings.Controls.Add(this.cbCustomServer);
            this.grpLoginSettings.Controls.Add(this.tbFurcPort);
            this.grpLoginSettings.Controls.Add(this.tbFurcAddress);
            this.grpLoginSettings.Controls.Add(this.btnLoadCharacter);
            this.grpLoginSettings.Controls.Add(this.tbFurcPassword);
            this.grpLoginSettings.Controls.Add(this.tbFurcUsername);
            this.grpLoginSettings.Location = new System.Drawing.Point(12, 12);
            this.grpLoginSettings.Name = "grpLoginSettings";
            this.grpLoginSettings.Size = new System.Drawing.Size(307, 122);
            this.grpLoginSettings.TabIndex = 0;
            this.grpLoginSettings.TabStop = false;
            this.grpLoginSettings.Text = "Login Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server:";
            // 
            // cbCustomServer
            // 
            this.cbCustomServer.AutoSize = true;
            this.cbCustomServer.Location = new System.Drawing.Point(72, 45);
            this.cbCustomServer.Name = "cbCustomServer";
            this.cbCustomServer.Size = new System.Drawing.Size(93, 17);
            this.cbCustomServer.TabIndex = 3;
            this.cbCustomServer.Text = "C&ustom server";
            this.cbCustomServer.UseVisualStyleBackColor = true;
            this.cbCustomServer.CheckedChanged += new System.EventHandler(this.dbCustomServer_CheckedChanged);
            // 
            // tbFurcPort
            // 
            this.tbFurcPort.Enabled = false;
            this.tbFurcPort.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbFurcPort.Location = new System.Drawing.Point(220, 19);
            this.tbFurcPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbFurcPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbFurcPort.Name = "tbFurcPort";
            this.tbFurcPort.Size = new System.Drawing.Size(57, 20);
            this.tbFurcPort.TabIndex = 5;
            this.tbFurcPort.Value = new decimal(new int[] {
            6500,
            0,
            0,
            0});
            // 
            // tbFurcAddress
            // 
            this.tbFurcAddress.Enabled = false;
            this.tbFurcAddress.Location = new System.Drawing.Point(72, 19);
            this.tbFurcAddress.Name = "tbFurcAddress";
            this.tbFurcAddress.Size = new System.Drawing.Size(142, 20);
            this.tbFurcAddress.TabIndex = 4;
            this.tbFurcAddress.Text = "lightbringer.furcadia.com";
            // 
            // btnLoadCharacter
            // 
            this.btnLoadCharacter.Location = new System.Drawing.Point(220, 68);
            this.btnLoadCharacter.Name = "btnLoadCharacter";
            this.btnLoadCharacter.Size = new System.Drawing.Size(75, 46);
            this.btnLoadCharacter.TabIndex = 2;
            this.btnLoadCharacter.Text = "&Load...";
            this.btnLoadCharacter.UseVisualStyleBackColor = true;
            this.btnLoadCharacter.Click += new System.EventHandler(this.btnLoadCharacter_Click);
            // 
            // tbFurcPassword
            // 
            this.tbFurcPassword.Location = new System.Drawing.Point(72, 94);
            this.tbFurcPassword.Name = "tbFurcPassword";
            this.tbFurcPassword.PasswordChar = '*';
            this.tbFurcPassword.Size = new System.Drawing.Size(142, 20);
            this.tbFurcPassword.TabIndex = 1;
            // 
            // tbFurcUsername
            // 
            this.tbFurcUsername.Location = new System.Drawing.Point(72, 68);
            this.tbFurcUsername.Name = "tbFurcUsername";
            this.tbFurcUsername.Size = new System.Drawing.Size(142, 20);
            this.tbFurcUsername.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Command:";
            // 
            // tbCommand
            // 
            this.tbCommand.Enabled = false;
            this.tbCommand.Location = new System.Drawing.Point(64, 19);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(150, 20);
            this.tbCommand.TabIndex = 1;
            this.tbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCommand_KeyPress);
            // 
            // grpCaptureSettings
            // 
            this.grpCaptureSettings.Controls.Add(this.cbStopAuto);
            this.grpCaptureSettings.Controls.Add(this.cbStartAuto);
            this.grpCaptureSettings.Controls.Add(this.selectTimeUnits);
            this.grpCaptureSettings.Controls.Add(this.numDuration);
            this.grpCaptureSettings.Controls.Add(this.label5);
            this.grpCaptureSettings.Controls.Add(this.btnSaveBrowse);
            this.grpCaptureSettings.Controls.Add(this.tbSavePath);
            this.grpCaptureSettings.Controls.Add(this.cbSaveData);
            this.grpCaptureSettings.Location = new System.Drawing.Point(12, 141);
            this.grpCaptureSettings.Name = "grpCaptureSettings";
            this.grpCaptureSettings.Size = new System.Drawing.Size(307, 120);
            this.grpCaptureSettings.TabIndex = 1;
            this.grpCaptureSettings.TabStop = false;
            this.grpCaptureSettings.Text = "Capture Settings";
            // 
            // cbStopAuto
            // 
            this.cbStopAuto.AutoSize = true;
            this.cbStopAuto.Checked = true;
            this.cbStopAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStopAuto.Location = new System.Drawing.Point(6, 42);
            this.cbStopAuto.Name = "cbStopAuto";
            this.cbStopAuto.Size = new System.Drawing.Size(146, 17);
            this.cbStopAuto.TabIndex = 1;
            this.cbStopAuto.Text = "Stop capturing data after:";
            this.cbStopAuto.UseVisualStyleBackColor = true;
            this.cbStopAuto.CheckedChanged += new System.EventHandler(this.cbStopAuto_CheckedChanged);
            // 
            // cbStartAuto
            // 
            this.cbStartAuto.AutoSize = true;
            this.cbStartAuto.Location = new System.Drawing.Point(6, 19);
            this.cbStartAuto.Name = "cbStartAuto";
            this.cbStartAuto.Size = new System.Drawing.Size(205, 17);
            this.cbStartAuto.TabIndex = 0;
            this.cbStartAuto.Text = "Start capturing data when connected.";
            this.cbStartAuto.UseVisualStyleBackColor = true;
            // 
            // selectTimeUnits
            // 
            this.selectTimeUnits.FormattingEnabled = true;
            this.selectTimeUnits.Items.AddRange(new object[] {
            "sec",
            "min",
            "hr"});
            this.selectTimeUnits.Location = new System.Drawing.Point(246, 40);
            this.selectTimeUnits.Name = "selectTimeUnits";
            this.selectTimeUnits.Size = new System.Drawing.Size(49, 21);
            this.selectTimeUnits.TabIndex = 3;
            this.selectTimeUnits.Text = "min";
            this.selectTimeUnits.TextUpdate += new System.EventHandler(this.selectTimeUnits_TextUpdate);
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(171, 41);
            this.numDuration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(69, 20);
            this.numDuration.TabIndex = 2;
            this.numDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "File:";
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Enabled = false;
            this.btnSaveBrowse.Location = new System.Drawing.Point(220, 86);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBrowse.TabIndex = 6;
            this.btnSaveBrowse.Text = "Browse...";
            this.btnSaveBrowse.UseVisualStyleBackColor = true;
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // tbSavePath
            // 
            this.tbSavePath.Enabled = false;
            this.tbSavePath.Location = new System.Drawing.Point(39, 88);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(175, 20);
            this.tbSavePath.TabIndex = 5;
            // 
            // cbSaveData
            // 
            this.cbSaveData.AutoSize = true;
            this.cbSaveData.Location = new System.Drawing.Point(6, 65);
            this.cbSaveData.Name = "cbSaveData";
            this.cbSaveData.Size = new System.Drawing.Size(151, 17);
            this.cbSaveData.TabIndex = 4;
            this.cbSaveData.Text = "Save capture data to disk:";
            this.cbSaveData.UseVisualStyleBackColor = true;
            this.cbSaveData.CheckedChanged += new System.EventHandler(this.cbSaveData_CheckedChanged);
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "log";
            this.dlgSave.FileName = "capture.log";
            this.dlgSave.Filter = "Capture files|*.log|All files|*.*";
            this.dlgSave.Title = "Capture data file...";
            // 
            // dlgLoad
            // 
            this.dlgLoad.DefaultExt = "ini";
            this.dlgLoad.FileName = "furcadia.ini";
            this.dlgLoad.Filter = "INI files|*.ini|All files|*.*";
            this.dlgLoad.Title = "Open Furcadia character...";
            // 
            // grpCaptureData
            // 
            this.grpCaptureData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCaptureData.Controls.Add(this.txtCaptureTime);
            this.grpCaptureData.Controls.Add(this.txtLongestInstruction);
            this.grpCaptureData.Controls.Add(this.txtAverageSpeed);
            this.grpCaptureData.Controls.Add(this.txtRecvAvatar);
            this.grpCaptureData.Controls.Add(this.txtRecvDsRelated);
            this.grpCaptureData.Controls.Add(this.txtRecvTotal);
            this.grpCaptureData.Controls.Add(this.label11);
            this.grpCaptureData.Controls.Add(this.label10);
            this.grpCaptureData.Controls.Add(this.label9);
            this.grpCaptureData.Controls.Add(this.label8);
            this.grpCaptureData.Controls.Add(this.label7);
            this.grpCaptureData.Controls.Add(this.label6);
            this.grpCaptureData.Enabled = false;
            this.grpCaptureData.Location = new System.Drawing.Point(325, 12);
            this.grpCaptureData.Name = "grpCaptureData";
            this.grpCaptureData.Size = new System.Drawing.Size(337, 149);
            this.grpCaptureData.TabIndex = 3;
            this.grpCaptureData.TabStop = false;
            this.grpCaptureData.Text = "Capture Data";
            // 
            // txtCaptureTime
            // 
            this.txtCaptureTime.AutoSize = true;
            this.txtCaptureTime.Location = new System.Drawing.Point(147, 127);
            this.txtCaptureTime.Name = "txtCaptureTime";
            this.txtCaptureTime.Size = new System.Drawing.Size(43, 13);
            this.txtCaptureTime.TabIndex = 5;
            this.txtCaptureTime.Text = "0:00:00";
            // 
            // txtLongestInstruction
            // 
            this.txtLongestInstruction.AutoSize = true;
            this.txtLongestInstruction.Location = new System.Drawing.Point(147, 105);
            this.txtLongestInstruction.Name = "txtLongestInstruction";
            this.txtLongestInstruction.Size = new System.Drawing.Size(41, 13);
            this.txtLongestInstruction.TabIndex = 4;
            this.txtLongestInstruction.Text = "0 bytes";
            // 
            // txtAverageSpeed
            // 
            this.txtAverageSpeed.AutoSize = true;
            this.txtAverageSpeed.Location = new System.Drawing.Point(147, 85);
            this.txtAverageSpeed.Name = "txtAverageSpeed";
            this.txtAverageSpeed.Size = new System.Drawing.Size(67, 13);
            this.txtAverageSpeed.TabIndex = 3;
            this.txtAverageSpeed.Text = "0.00 KB/sec";
            // 
            // txtRecvAvatar
            // 
            this.txtRecvAvatar.AutoSize = true;
            this.txtRecvAvatar.Location = new System.Drawing.Point(147, 58);
            this.txtRecvAvatar.Name = "txtRecvAvatar";
            this.txtRecvAvatar.Size = new System.Drawing.Size(13, 13);
            this.txtRecvAvatar.TabIndex = 2;
            this.txtRecvAvatar.Text = "0";
            // 
            // txtRecvDsRelated
            // 
            this.txtRecvDsRelated.AutoSize = true;
            this.txtRecvDsRelated.Location = new System.Drawing.Point(147, 40);
            this.txtRecvDsRelated.Name = "txtRecvDsRelated";
            this.txtRecvDsRelated.Size = new System.Drawing.Size(13, 13);
            this.txtRecvDsRelated.TabIndex = 1;
            this.txtRecvDsRelated.Text = "0";
            // 
            // txtRecvTotal
            // 
            this.txtRecvTotal.AutoSize = true;
            this.txtRecvTotal.Location = new System.Drawing.Point(147, 22);
            this.txtRecvTotal.Name = "txtRecvTotal";
            this.txtRecvTotal.Size = new System.Drawing.Size(13, 13);
            this.txtRecvTotal.TabIndex = 0;
            this.txtRecvTotal.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Longest Instruction:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Capture Time:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Average Speed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "- Avatar && Movement:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "- DS-related:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total Received (bytes):";
            // 
            // tbServerData
            // 
            this.tbServerData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerData.Location = new System.Drawing.Point(325, 173);
            this.tbServerData.Multiline = true;
            this.tbServerData.Name = "tbServerData";
            this.tbServerData.ReadOnly = true;
            this.tbServerData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbServerData.Size = new System.Drawing.Size(337, 188);
            this.tbServerData.TabIndex = 4;
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnOk);
            this.grpControl.Controls.Add(this.label4);
            this.grpControl.Controls.Add(this.tbCommand);
            this.grpControl.Controls.Add(this.btnStartStop);
            this.grpControl.Controls.Add(this.btnSend);
            this.grpControl.Controls.Add(this.btnConnect);
            this.grpControl.Location = new System.Drawing.Point(12, 267);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(307, 94);
            this.grpControl.TabIndex = 2;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Control";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(220, 46);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 42);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Location = new System.Drawing.Point(115, 45);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(96, 43);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "&Start Capture";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(220, 17);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 45);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 43);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tSync
            // 
            this.tSync.Interval = 250;
            this.tSync.Tick += new System.EventHandler(this.tSync_Tick);
            // 
            // tStopCapture
            // 
            this.tStopCapture.Tick += new System.EventHandler(this.tStopCapture_Tick);
            // 
            // LiveCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 372);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpCaptureData);
            this.Controls.Add(this.grpCaptureSettings);
            this.Controls.Add(this.grpLoginSettings);
            this.Controls.Add(this.tbServerData);
            this.MinimumSize = new System.Drawing.Size(690, 408);
            this.Name = "LiveCaptureForm";
            this.Text = "Live Data Capture - Dream Runtime Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveCaptureForm_FormClosing);
            this.grpLoginSettings.ResumeLayout(false);
            this.grpLoginSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFurcPort)).EndInit();
            this.grpCaptureSettings.ResumeLayout(false);
            this.grpCaptureSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.grpCaptureData.ResumeLayout(false);
            this.grpCaptureData.PerformLayout();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLoginSettings;
        private System.Windows.Forms.Button btnLoadCharacter;
        private System.Windows.Forms.TextBox tbFurcPassword;
        private System.Windows.Forms.TextBox tbFurcUsername;
        private System.Windows.Forms.NumericUpDown tbFurcPort;
        private System.Windows.Forms.TextBox tbFurcAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbCustomServer;
        private System.Windows.Forms.GroupBox grpCaptureSettings;
        private System.Windows.Forms.CheckBox cbSaveData;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgLoad;
        private System.Windows.Forms.Button btnSaveBrowse;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpCaptureData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox selectTimeUnits;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.CheckBox cbStopAuto;
        private System.Windows.Forms.CheckBox cbStartAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtLongestInstruction;
        private System.Windows.Forms.Label txtAverageSpeed;
        private System.Windows.Forms.Label txtRecvAvatar;
        private System.Windows.Forms.Label txtRecvDsRelated;
        private System.Windows.Forms.Label txtRecvTotal;
        private System.Windows.Forms.TextBox tbServerData;
        private System.Windows.Forms.Label txtCaptureTime;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer tSync;
        private System.Windows.Forms.Timer tStopCapture;
        private System.Windows.Forms.Button btnOk;
    }
}