namespace Dream_Runtime_Analyzer
{
    partial class Form1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ttsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenDataFile = new System.Windows.Forms.OpenFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpBandwidth = new System.Windows.Forms.TabPage();
            this.txtDisplayInstructionCountPerSecond = new System.Windows.Forms.Label();
            this.txtDisplayInstructionCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAvatarInstructionCountPerSecond = new System.Windows.Forms.Label();
            this.txtAvatarInstructionCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDsInstructionCountPerSecond = new System.Windows.Forms.Label();
            this.txtDsInstructionCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCaptureTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCaptureTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLongestInstruction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAverageSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAvatarBandwidth = new System.Windows.Forms.Label();
            this.txtDsBandwidth = new System.Windows.Forms.Label();
            this.txtTotalBandwidth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpDsFrequency = new System.Windows.Forms.TabPage();
            this.dgvDsFrequency = new System.Windows.Forms.DataGridView();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DsbLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpInstrFrequency = new System.Windows.Forms.TabPage();
            this.dgvInstrFrequency = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportRaw = new System.Windows.Forms.Button();
            this.btnLoadDs = new System.Windows.Forms.Button();
            this.dlgSaveExportData = new System.Windows.Forms.SaveFileDialog();
            this.btnAbout = new System.Windows.Forms.Button();
            this.dlgOpenDsFile = new System.Windows.Forms.OpenFileDialog();
            this.btnCapture = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpBandwidth.SuspendLayout();
            this.tpDsFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsFrequency)).BeginInit();
            this.tpInstrFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(455, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.liveCaptureToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ttsExport,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openFileToolStripMenuItem.Text = "&Open Data...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // liveCaptureToolStripMenuItem
            // 
            this.liveCaptureToolStripMenuItem.Name = "liveCaptureToolStripMenuItem";
            this.liveCaptureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.liveCaptureToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.liveCaptureToolStripMenuItem.Text = "&Capture Data...";
            this.liveCaptureToolStripMenuItem.Click += new System.EventHandler(this.liveCaptureToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // ttsExport
            // 
            this.ttsExport.Enabled = false;
            this.ttsExport.Name = "ttsExport";
            this.ttsExport.Size = new System.Drawing.Size(194, 22);
            this.ttsExport.Text = "&Export...";
            this.ttsExport.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dlgOpenDataFile
            // 
            this.dlgOpenDataFile.DefaultExt = "log";
            this.dlgOpenDataFile.FileName = "capture.log";
            this.dlgOpenDataFile.Filter = "Capture files|*.log|All files|*.*";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpBandwidth);
            this.tabControl.Controls.Add(this.tpDsFrequency);
            this.tabControl.Controls.Add(this.tpInstrFrequency);
            this.tabControl.Location = new System.Drawing.Point(2, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(453, 237);
            this.tabControl.TabIndex = 4;
            // 
            // tpBandwidth
            // 
            this.tpBandwidth.Controls.Add(this.txtDisplayInstructionCountPerSecond);
            this.tpBandwidth.Controls.Add(this.txtDisplayInstructionCount);
            this.tpBandwidth.Controls.Add(this.label11);
            this.tpBandwidth.Controls.Add(this.txtAvatarInstructionCountPerSecond);
            this.tpBandwidth.Controls.Add(this.txtAvatarInstructionCount);
            this.tpBandwidth.Controls.Add(this.label10);
            this.tpBandwidth.Controls.Add(this.txtDsInstructionCountPerSecond);
            this.tpBandwidth.Controls.Add(this.txtDsInstructionCount);
            this.tpBandwidth.Controls.Add(this.label9);
            this.tpBandwidth.Controls.Add(this.label8);
            this.tpBandwidth.Controls.Add(this.txtCaptureTitle);
            this.tpBandwidth.Controls.Add(this.label7);
            this.tpBandwidth.Controls.Add(this.txtCaptureTime);
            this.tpBandwidth.Controls.Add(this.label6);
            this.tpBandwidth.Controls.Add(this.txtLongestInstruction);
            this.tpBandwidth.Controls.Add(this.label5);
            this.tpBandwidth.Controls.Add(this.txtAverageSpeed);
            this.tpBandwidth.Controls.Add(this.label4);
            this.tpBandwidth.Controls.Add(this.txtAvatarBandwidth);
            this.tpBandwidth.Controls.Add(this.txtDsBandwidth);
            this.tpBandwidth.Controls.Add(this.txtTotalBandwidth);
            this.tpBandwidth.Controls.Add(this.label3);
            this.tpBandwidth.Controls.Add(this.label2);
            this.tpBandwidth.Controls.Add(this.label1);
            this.tpBandwidth.Location = new System.Drawing.Point(4, 22);
            this.tpBandwidth.Name = "tpBandwidth";
            this.tpBandwidth.Padding = new System.Windows.Forms.Padding(3);
            this.tpBandwidth.Size = new System.Drawing.Size(445, 211);
            this.tpBandwidth.TabIndex = 0;
            this.tpBandwidth.Text = "Bandwidth";
            this.tpBandwidth.UseVisualStyleBackColor = true;
            // 
            // txtDisplayInstructionCountPerSecond
            // 
            this.txtDisplayInstructionCountPerSecond.AutoSize = true;
            this.txtDisplayInstructionCountPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDisplayInstructionCountPerSecond.Location = new System.Drawing.Point(259, 187);
            this.txtDisplayInstructionCountPerSecond.Name = "txtDisplayInstructionCountPerSecond";
            this.txtDisplayInstructionCountPerSecond.Size = new System.Drawing.Size(68, 13);
            this.txtDisplayInstructionCountPerSecond.TabIndex = 12;
            this.txtDisplayInstructionCountPerSecond.Text = "0 instr/sec";
            // 
            // txtDisplayInstructionCount
            // 
            this.txtDisplayInstructionCount.AutoSize = true;
            this.txtDisplayInstructionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDisplayInstructionCount.Location = new System.Drawing.Point(155, 187);
            this.txtDisplayInstructionCount.Name = "txtDisplayInstructionCount";
            this.txtDisplayInstructionCount.Size = new System.Drawing.Size(14, 13);
            this.txtDisplayInstructionCount.TabIndex = 9;
            this.txtDisplayInstructionCount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 183);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label11.Size = new System.Drawing.Size(121, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "- Display (supp/resume):";
            // 
            // txtAvatarInstructionCountPerSecond
            // 
            this.txtAvatarInstructionCountPerSecond.AutoSize = true;
            this.txtAvatarInstructionCountPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAvatarInstructionCountPerSecond.Location = new System.Drawing.Point(259, 170);
            this.txtAvatarInstructionCountPerSecond.Name = "txtAvatarInstructionCountPerSecond";
            this.txtAvatarInstructionCountPerSecond.Size = new System.Drawing.Size(68, 13);
            this.txtAvatarInstructionCountPerSecond.TabIndex = 11;
            this.txtAvatarInstructionCountPerSecond.Text = "0 instr/sec";
            // 
            // txtAvatarInstructionCount
            // 
            this.txtAvatarInstructionCount.AutoSize = true;
            this.txtAvatarInstructionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAvatarInstructionCount.Location = new System.Drawing.Point(155, 170);
            this.txtAvatarInstructionCount.Name = "txtAvatarInstructionCount";
            this.txtAvatarInstructionCount.Size = new System.Drawing.Size(14, 13);
            this.txtAvatarInstructionCount.TabIndex = 8;
            this.txtAvatarInstructionCount.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 166);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "- Avatar:";
            // 
            // txtDsInstructionCountPerSecond
            // 
            this.txtDsInstructionCountPerSecond.AutoSize = true;
            this.txtDsInstructionCountPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDsInstructionCountPerSecond.Location = new System.Drawing.Point(259, 153);
            this.txtDsInstructionCountPerSecond.Name = "txtDsInstructionCountPerSecond";
            this.txtDsInstructionCountPerSecond.Size = new System.Drawing.Size(68, 13);
            this.txtDsInstructionCountPerSecond.TabIndex = 10;
            this.txtDsInstructionCountPerSecond.Text = "0 instr/sec";
            // 
            // txtDsInstructionCount
            // 
            this.txtDsInstructionCount.AutoSize = true;
            this.txtDsInstructionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDsInstructionCount.Location = new System.Drawing.Point(155, 153);
            this.txtDsInstructionCount.Name = "txtDsInstructionCount";
            this.txtDsInstructionCount.Size = new System.Drawing.Size(14, 13);
            this.txtDsInstructionCount.TabIndex = 7;
            this.txtDsInstructionCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 149);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "- DragonSpeak:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Instruction Count:";
            // 
            // txtCaptureTitle
            // 
            this.txtCaptureTitle.AutoSize = true;
            this.txtCaptureTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCaptureTitle.Location = new System.Drawing.Point(155, 7);
            this.txtCaptureTitle.Name = "txtCaptureTitle";
            this.txtCaptureTitle.Size = new System.Drawing.Size(30, 13);
            this.txtCaptureTitle.TabIndex = 0;
            this.txtCaptureTitle.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Capture Title:";
            // 
            // txtCaptureTime
            // 
            this.txtCaptureTime.AutoSize = true;
            this.txtCaptureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCaptureTime.Location = new System.Drawing.Point(155, 114);
            this.txtCaptureTime.Name = "txtCaptureTime";
            this.txtCaptureTime.Size = new System.Drawing.Size(57, 13);
            this.txtCaptureTime.TabIndex = 6;
            this.txtCaptureTime.Text = "00:00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Capture Time:";
            // 
            // txtLongestInstruction
            // 
            this.txtLongestInstruction.AutoSize = true;
            this.txtLongestInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLongestInstruction.Location = new System.Drawing.Point(155, 97);
            this.txtLongestInstruction.Name = "txtLongestInstruction";
            this.txtLongestInstruction.Size = new System.Drawing.Size(48, 13);
            this.txtLongestInstruction.TabIndex = 5;
            this.txtLongestInstruction.Text = "0 bytes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Longest Instruction:";
            // 
            // txtAverageSpeed
            // 
            this.txtAverageSpeed.AutoSize = true;
            this.txtAverageSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAverageSpeed.Location = new System.Drawing.Point(155, 80);
            this.txtAverageSpeed.Name = "txtAverageSpeed";
            this.txtAverageSpeed.Size = new System.Drawing.Size(78, 13);
            this.txtAverageSpeed.TabIndex = 4;
            this.txtAverageSpeed.Text = "0.00 KB/sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Average Speed:";
            // 
            // txtAvatarBandwidth
            // 
            this.txtAvatarBandwidth.AutoSize = true;
            this.txtAvatarBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAvatarBandwidth.Location = new System.Drawing.Point(155, 63);
            this.txtAvatarBandwidth.Name = "txtAvatarBandwidth";
            this.txtAvatarBandwidth.Size = new System.Drawing.Size(48, 13);
            this.txtAvatarBandwidth.TabIndex = 3;
            this.txtAvatarBandwidth.Text = "0 bytes";
            // 
            // txtDsBandwidth
            // 
            this.txtDsBandwidth.AutoSize = true;
            this.txtDsBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDsBandwidth.Location = new System.Drawing.Point(155, 46);
            this.txtDsBandwidth.Name = "txtDsBandwidth";
            this.txtDsBandwidth.Size = new System.Drawing.Size(48, 13);
            this.txtDsBandwidth.TabIndex = 2;
            this.txtDsBandwidth.Text = "0 bytes";
            // 
            // txtTotalBandwidth
            // 
            this.txtTotalBandwidth.AutoSize = true;
            this.txtTotalBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTotalBandwidth.Location = new System.Drawing.Point(155, 29);
            this.txtTotalBandwidth.Name = "txtTotalBandwidth";
            this.txtTotalBandwidth.Size = new System.Drawing.Size(48, 13);
            this.txtTotalBandwidth.TabIndex = 1;
            this.txtTotalBandwidth.Text = "0 bytes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 59);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "- Avatar-related:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 42);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "- DragonSpeak-related:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total Bandwidth:";
            // 
            // tpDsFrequency
            // 
            this.tpDsFrequency.Controls.Add(this.dgvDsFrequency);
            this.tpDsFrequency.Location = new System.Drawing.Point(4, 22);
            this.tpDsFrequency.Name = "tpDsFrequency";
            this.tpDsFrequency.Padding = new System.Windows.Forms.Padding(3);
            this.tpDsFrequency.Size = new System.Drawing.Size(445, 211);
            this.tpDsFrequency.TabIndex = 1;
            this.tpDsFrequency.Text = "DS Frequency";
            this.tpDsFrequency.UseVisualStyleBackColor = true;
            // 
            // dgvDsFrequency
            // 
            this.dgvDsFrequency.AllowUserToAddRows = false;
            this.dgvDsFrequency.AllowUserToDeleteRows = false;
            this.dgvDsFrequency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsFrequency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.DsbLine});
            this.dgvDsFrequency.Location = new System.Drawing.Point(0, 0);
            this.dgvDsFrequency.Name = "dgvDsFrequency";
            this.dgvDsFrequency.ReadOnly = true;
            this.dgvDsFrequency.RowHeadersVisible = false;
            this.dgvDsFrequency.Size = new System.Drawing.Size(447, 215);
            this.dgvDsFrequency.TabIndex = 0;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MaxInputLength = 10;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DsbLine
            // 
            this.DsbLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DsbLine.HeaderText = "DSB Lines";
            this.DsbLine.MaxInputLength = 255;
            this.DsbLine.Name = "DsbLine";
            this.DsbLine.ReadOnly = true;
            this.DsbLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpInstrFrequency
            // 
            this.tpInstrFrequency.Controls.Add(this.dgvInstrFrequency);
            this.tpInstrFrequency.Location = new System.Drawing.Point(4, 22);
            this.tpInstrFrequency.Name = "tpInstrFrequency";
            this.tpInstrFrequency.Padding = new System.Windows.Forms.Padding(3);
            this.tpInstrFrequency.Size = new System.Drawing.Size(445, 211);
            this.tpInstrFrequency.TabIndex = 2;
            this.tpInstrFrequency.Text = "Instr. Frequency";
            this.tpInstrFrequency.UseVisualStyleBackColor = true;
            // 
            // dgvInstrFrequency
            // 
            this.dgvInstrFrequency.AllowUserToAddRows = false;
            this.dgvInstrFrequency.AllowUserToDeleteRows = false;
            this.dgvInstrFrequency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstrFrequency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvInstrFrequency.Location = new System.Drawing.Point(0, 0);
            this.dgvInstrFrequency.Name = "dgvInstrFrequency";
            this.dgvInstrFrequency.ReadOnly = true;
            this.dgvInstrFrequency.RowHeadersVisible = false;
            this.dgvInstrFrequency.Size = new System.Drawing.Size(447, 211);
            this.dgvInstrFrequency.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Frequency";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Instruction";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 255;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnExportRaw
            // 
            this.btnExportRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportRaw.Enabled = false;
            this.btnExportRaw.Location = new System.Drawing.Point(368, 270);
            this.btnExportRaw.Name = "btnExportRaw";
            this.btnExportRaw.Size = new System.Drawing.Size(75, 23);
            this.btnExportRaw.TabIndex = 2;
            this.btnExportRaw.Text = "E&xport Raw";
            this.btnExportRaw.UseVisualStyleBackColor = true;
            this.btnExportRaw.Click += new System.EventHandler(this.btnExportRaw_Click);
            // 
            // btnLoadDs
            // 
            this.btnLoadDs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDs.Enabled = false;
            this.btnLoadDs.Location = new System.Drawing.Point(287, 270);
            this.btnLoadDs.Name = "btnLoadDs";
            this.btnLoadDs.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDs.TabIndex = 1;
            this.btnLoadDs.Text = "&Load DS";
            this.btnLoadDs.UseVisualStyleBackColor = true;
            this.btnLoadDs.Click += new System.EventHandler(this.btnLoadDs_Click);
            // 
            // dlgSaveExportData
            // 
            this.dlgSaveExportData.Filter = "All files|*.*";
            this.dlgSaveExportData.Title = "Save Exported Data...";
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.Location = new System.Drawing.Point(12, 270);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // dlgOpenDsFile
            // 
            this.dlgOpenDsFile.DefaultExt = "ds";
            this.dlgOpenDsFile.FileName = "default";
            this.dlgOpenDsFile.Filter = "DragonSpeak files|*.ds|All files|*.*";
            this.dlgOpenDsFile.Title = "Open DragonSpeak File...";
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(206, 270);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "&Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 301);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnLoadDs);
            this.Controls.Add(this.btnExportRaw);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(471, 337);
            this.MinimumSize = new System.Drawing.Size(471, 337);
            this.Name = "Form1";
            this.Text = "Dream Runtime Analyzer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpBandwidth.ResumeLayout(false);
            this.tpBandwidth.PerformLayout();
            this.tpDsFrequency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsFrequency)).EndInit();
            this.tpInstrFrequency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ttsExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpenDataFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpBandwidth;
        private System.Windows.Forms.TabPage tpDsFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtAvatarBandwidth;
        private System.Windows.Forms.Label txtDsBandwidth;
        private System.Windows.Forms.Label txtTotalBandwidth;
        private System.Windows.Forms.Label txtAverageSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtLongestInstruction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtCaptureTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtDsInstructionCountPerSecond;
        private System.Windows.Forms.Label txtDsInstructionCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtCaptureTitle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtAvatarInstructionCountPerSecond;
        private System.Windows.Forms.Label txtAvatarInstructionCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtDisplayInstructionCountPerSecond;
        private System.Windows.Forms.Label txtDisplayInstructionCount;
        private System.Windows.Forms.Button btnExportRaw;
        private System.Windows.Forms.Button btnLoadDs;
        private System.Windows.Forms.DataGridView dgvDsFrequency;
        private System.Windows.Forms.TabPage tpInstrFrequency;
        private System.Windows.Forms.DataGridView dgvInstrFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn DsbLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.SaveFileDialog dlgSaveExportData;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.OpenFileDialog dlgOpenDsFile;
        private System.Windows.Forms.Button btnCapture;
    }
}

