namespace Dream_Runtime_Analyzer
{
    partial class DsDialog
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
            this.dgvDsbLines = new System.Windows.Forms.DataGridView();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DsbLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDragonSpeak = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDsbLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenDsFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLineNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDsbLineNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsbLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDragonSpeak)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDsbLines
            // 
            this.dgvDsbLines.AllowUserToAddRows = false;
            this.dgvDsbLines.AllowUserToDeleteRows = false;
            this.dgvDsbLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDsbLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDsbLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsbLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.DsbLine});
            this.dgvDsbLines.Location = new System.Drawing.Point(12, 12);
            this.dgvDsbLines.MultiSelect = false;
            this.dgvDsbLines.Name = "dgvDsbLines";
            this.dgvDsbLines.ReadOnly = true;
            this.dgvDsbLines.RowHeadersVisible = false;
            this.dgvDsbLines.RowTemplate.Height = 20;
            this.dgvDsbLines.RowTemplate.ReadOnly = true;
            this.dgvDsbLines.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDsbLines.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDsbLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDsbLines.Size = new System.Drawing.Size(162, 358);
            this.dgvDsbLines.TabIndex = 0;
            this.dgvDsbLines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDsbLines_CellClick);
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MaxInputLength = 10;
            this.Frequency.MinimumWidth = 80;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 80;
            // 
            // DsbLine
            // 
            this.DsbLine.HeaderText = "DSB Line";
            this.DsbLine.MaxInputLength = 10;
            this.DsbLine.MinimumWidth = 60;
            this.DsbLine.Name = "DsbLine";
            this.DsbLine.ReadOnly = true;
            this.DsbLine.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DsbLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DsbLine.Width = 80;
            // 
            // dgvDragonSpeak
            // 
            this.dgvDragonSpeak.AllowUserToAddRows = false;
            this.dgvDragonSpeak.AllowUserToDeleteRows = false;
            this.dgvDragonSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDragonSpeak.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDragonSpeak.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDragonSpeak.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvDragonSpeak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDragonSpeak.ColumnHeadersVisible = false;
            this.dgvDragonSpeak.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.nDsbLine});
            this.dgvDragonSpeak.Location = new System.Drawing.Point(180, 12);
            this.dgvDragonSpeak.Name = "dgvDragonSpeak";
            this.dgvDragonSpeak.ReadOnly = true;
            this.dgvDragonSpeak.RowHeadersVisible = false;
            this.dgvDragonSpeak.RowTemplate.Height = 20;
            this.dgvDragonSpeak.RowTemplate.ReadOnly = true;
            this.dgvDragonSpeak.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDragonSpeak.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDragonSpeak.Size = new System.Drawing.Size(542, 329);
            this.dgvDragonSpeak.TabIndex = 1;
            this.dgvDragonSpeak.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDragonSpeak_CellClick);
            this.dgvDragonSpeak.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDragonSpeak_CellClick);
            // 
            // Line
            // 
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nDsbLine
            // 
            this.nDsbLine.HeaderText = "DSB Line";
            this.nDsbLine.MaxInputLength = 10;
            this.nDsbLine.Name = "nDsbLine";
            this.nDsbLine.ReadOnly = true;
            this.nDsbLine.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(647, 347);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOpenDsFile
            // 
            this.btnOpenDsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDsFile.Location = new System.Drawing.Point(446, 347);
            this.btnOpenDsFile.Name = "btnOpenDsFile";
            this.btnOpenDsFile.Size = new System.Drawing.Size(195, 23);
            this.btnOpenDsFile.TabIndex = 2;
            this.btnOpenDsFile.Text = "&Open DragonSpeak File";
            this.btnOpenDsFile.UseVisualStyleBackColor = true;
            this.btnOpenDsFile.Click += new System.EventHandler(this.btnOpenDsFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Line:";
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLineNumber.Location = new System.Drawing.Point(216, 352);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(76, 13);
            this.txtLineNumber.TabIndex = 4;
            this.txtLineNumber.Text = "N/A";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DSB Line:";
            // 
            // txtDsbLineNumber
            // 
            this.txtDsbLineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDsbLineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDsbLineNumber.Location = new System.Drawing.Point(359, 352);
            this.txtDsbLineNumber.Name = "txtDsbLineNumber";
            this.txtDsbLineNumber.Size = new System.Drawing.Size(76, 13);
            this.txtDsbLineNumber.TabIndex = 5;
            this.txtDsbLineNumber.Text = "N/A";
            // 
            // DsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 382);
            this.Controls.Add(this.txtDsbLineNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLineNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenDsFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDragonSpeak);
            this.Controls.Add(this.dgvDsbLines);
            this.MinimumSize = new System.Drawing.Size(750, 300);
            this.Name = "DsDialog";
            this.Text = "DragonSpeak Inspector";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsbLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDragonSpeak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDsbLines;
        private System.Windows.Forms.DataGridView dgvDragonSpeak;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenDsFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn DsbLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtLineNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDsbLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDsbLine;
    }
}