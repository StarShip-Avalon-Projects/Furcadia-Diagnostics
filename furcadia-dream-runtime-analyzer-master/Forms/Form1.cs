using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dream_Runtime_Analyzer
{
    public partial class Form1 : Form
    {
        public Analyzer DataAnalyzer = null;

        public Form1()
        {
            InitializeComponent();

            // Set initial directories, didn't set them in designer.
            this.dlgOpenDataFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        /*
         *** User Interaction Functions
         */
        /// <summary>
        /// Prompts for a DS file and opens DS Inspector on it.
        /// </summary>
        private void OpenDsDialog()
        {
            if (dlgOpenDsFile.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                DsDialog dsd = new DsDialog(DataAnalyzer, dlgOpenDsFile.FileName);
                dsd.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot open DS Inspector: " + e.Message);
            }
        }
        /// <summary>
        /// Opens the Live Capture dialog for capture from the server.
        /// </summary>
        private void OpenCaptureDialog()
        {
            LiveCaptureForm ldcf = new LiveCaptureForm();

            if (ldcf.ShowDialog() == DialogResult.OK && ldcf.IsDataAvailable)
            {
                DataAnalyzer = ldcf.DataAnalyzer;
                UpdateFromAnalyzer();
            }
        }
        /// <summary>
        /// Loads analysis data from the TimeStamped source file we use to save
        /// captures to, and writes the raw data to a file of your choice by
        /// rising the save dialog.
        /// </summary>
        private void ExportRawData()
        {
            // Check if we have a filename
            if (DataAnalyzer == null || !SourceFileExists())
            {
                MessageBox.Show("Unable to locate source file! Export is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AllowRawExport(false);
                return;
            }

            // If it's not a timestamped file, it's pointless
            if (!DataAnalyzer.IsTimeStamped)
            {
                MessageBox.Show("Source file is already in its raw form - cannot export.", "Already Raw", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AllowRawExport(false);
                return;
            }

            // Show them the save dialog
            dlgSaveExportData.InitialDirectory = Path.GetDirectoryName(DataAnalyzer.Title);
            dlgSaveExportData.DefaultExt = Path.GetExtension(DataAnalyzer.Title);
            dlgSaveExportData.FileName = Path.GetFileNameWithoutExtension(DataAnalyzer.Title) + "-raw";
            if (dlgSaveExportData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DoExport(DataAnalyzer.Title, dlgSaveExportData.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not export data: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /*
         *** UI Update Functions
         */
        /// <summary>
        /// Update all the UI elements from DataAnalyzer.
        /// </summary>
        private void UpdateFromAnalyzer()
        {
            // If no analyzer yet, don't bother.
            if (DataAnalyzer == null)
            {
                AllowRawExport(false);
                AllowLoadDs(false);
                return;
            }

            //--- Updating Bandwidth tab
            bool timeAvailable = DataAnalyzer.IsTimeAvailable;
            ulong totalBytes = DataAnalyzer.TotalBytes;
            double dsPercentage = 100.0;
            double avPercentage = 100.0;

            // NOTE: totalBytes should never be 0 in theory, but this won't hurt...
            if (totalBytes > 0)
            {
                dsPercentage = ((double)DataAnalyzer.DsBytes / totalBytes) * 100;
                avPercentage = ((double)DataAnalyzer.AvatarBytes / totalBytes) * 100;
            }

            if (DataAnalyzer.Title != null)
            {
                txtCaptureTitle.Text = (!DataAnalyzer.Title.StartsWith("<")) ? Path.GetFileName(DataAnalyzer.Title) : DataAnalyzer.Title;
                AllowRawExport(true);
            }
            else
            {
                txtCaptureTitle.Text = "N/A";
                AllowRawExport(false);
            }

            txtTotalBandwidth.Text = GetByteCount(totalBytes);
            txtDsBandwidth.Text = GetByteCount(DataAnalyzer.DsBytes, dsPercentage);
            txtAvatarBandwidth.Text = GetByteCount(DataAnalyzer.AvatarBytes, avPercentage);

            txtLongestInstruction.Text = GetByteCount(DataAnalyzer.LongestInstructionLength);

            if (timeAvailable)
            {
                TimeSpan capTime = DataAnalyzer.RunTime;
                txtCaptureTime.Text = String.Format("{0:00}:{1:00}:{2:00}", capTime.Hours, capTime.Minutes, capTime.Seconds);
                txtAverageSpeed.Text = String.Format("{0:N} KB/sec", DataAnalyzer.AvgSpeed);
            }
            else
            {
                txtCaptureTime.Text = "N/A";
                txtAverageSpeed.Text = "N/A";
            }

            // Instruction counters
            uint capTimeSeconds = DataAnalyzer.RunTimeSeconds;

            txtDsInstructionCount.Text = GetCount(DataAnalyzer.DsCount);
            txtAvatarInstructionCount.Text = GetCount(DataAnalyzer.AvatarCount);
            txtDisplayInstructionCount.Text = GetCount(GetDisplayInstructionCount());

            if (timeAvailable)
            {
                txtDsInstructionCountPerSecond.Text = GetIPS((double)DataAnalyzer.DsCount / capTimeSeconds);
                txtAvatarInstructionCountPerSecond.Text = GetIPS((double)DataAnalyzer.AvatarCount / capTimeSeconds);
                txtDisplayInstructionCountPerSecond.Text = GetIPS((double)GetDisplayInstructionCount() / capTimeSeconds);
            }
            else
            {
                txtDsInstructionCountPerSecond.Text = "N/A";
                txtAvatarInstructionCountPerSecond.Text = "N/A";
                txtDisplayInstructionCountPerSecond.Text = "N/A";
            }

            //--- Updating DS Frequency tab
            UpdateDsFrequency();

            //--- Updating Instruction Frequency tab
            UpdateInstrFrequency();

            // Determine which buttons do we enable
            AllowLoadDs(DataAnalyzer != null);
            AllowRawExport(SourceFileExists() && DataAnalyzer.IsTimeStamped);
        }
        /// <summary>
        /// Update the DS Frequency tab from DataAnalyzer.
        /// </summary>
        private void UpdateDsFrequency()
        {
            // Remove everything
            dgvDsFrequency.Rows.Clear();

            SortedDictionary<uint, List<ushort>> lineTable = DataAnalyzer.GetLineTableByFrequency();
            foreach (uint freq in lineTable.Keys)
            {
                int n = dgvDsFrequency.Rows.Add();
                string lines = "";

                foreach (ushort line in lineTable[freq])
                    lines += line.ToString() + ", ";

                dgvDsFrequency.Rows[n].Cells[0].Value = freq.ToString();
                dgvDsFrequency.Rows[n].Cells[1].Value = lines.Substring(0, lines.Length - 2);
            }
        }
        /// <summary>
        /// Update the Instruction Frequency tab from DataAnalyzer.
        /// </summary>
        private void UpdateInstrFrequency()
        {
            // Remove everything
            dgvInstrFrequency.Rows.Clear();

            SortedDictionary<uint, List<char>> instrTable = DataAnalyzer.GetInstructionTableByFrequency();
            foreach (uint freq in instrTable.Keys)
            {
                int n = dgvInstrFrequency.Rows.Add();
                string instructions = "";

                foreach (char instr in instrTable[freq])
                    instructions += instr.ToString() + " ";

                dgvInstrFrequency.Rows[n].Cells[0].Value = freq.ToString();
                dgvInstrFrequency.Rows[n].Cells[1].Value = instructions.Substring(0, instructions.Length - 1);
            }
        }


        /*
         *** UI Group Switching Functions
         */
        private void AllowRawExport(bool enabled)
        {
            ttsExport.Enabled = enabled;
            btnExportRaw.Enabled = enabled;
        }
        private void AllowLoadDs(bool enabled)
        {
            btnLoadDs.Enabled = enabled;
        }


        /*
         *** MISCELLANEOUS
         */
        /// <summary>
        /// Loads analysis data from a specific file.
        /// </summary>
        /// <param name="filename">Filename we should load our data from</param>
        /// <returns>TRUE if the data was loaded successfully.</returns>
        private bool LoadData(string filename)
        {
            Analyzer a = new Analyzer();

            try
            {
                a.Load(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", "Unable to load data: " + e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataAnalyzer = a;
            return true;
        }
        /// <summary>
        /// Exports data from a source TSCF file to a target raw file. If the
        /// target file already exists, it is overwritten.
        /// </summary>
        /// <param name="srcFile">Source (timestamped) file</param>
        /// <param name="dstFile">Target file</param>
        private void DoExport(string srcFile, string dstFile)
        {
            StreamReader src = new StreamReader(srcFile, Encoding.ASCII);
            StreamWriter dst = new StreamWriter(dstFile, false, Encoding.ASCII);

            // Verify it's a TSCF file, we only know how to deal with those.
            string line = src.ReadLine();

            if (!line.StartsWith("TSCF-1.0"))
            {
                AllowRawExport(false); // Subsequent attempts are pointless
                throw new Exception("Unrecognized file format");
            }

            // Transfer data
            char[] sep = { ' ' };
            while (!src.EndOfStream)
            {
                line = src.ReadLine();
                if (line == null)
                    break;

                string[] param = line.Split(sep, 2, StringSplitOptions.None);
                dst.WriteLine(param[1]);
            }

            src.Close();
            dst.Close();
            MessageBox.Show("Raw data was successfully exported!", "Raw Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Checks if the filename within the Analyzer object exists to see if
        /// it can be re-loaded and more information can be retrieved later.
        /// </summary>
        /// <returns>TRUE if the name within DataAnalyzer's title is a file and it exists.</returns>
        private bool SourceFileExists()
        {
            return (DataAnalyzer != null && File.Exists(DataAnalyzer.Title));
        }


        /*
         *** Data Generation/Retrieval Functions
         */
        private uint GetDisplayInstructionCount()
        {
            return DataAnalyzer.GetInstructionFrequency('=') +
                   DataAnalyzer.GetInstructionFrequency('~');
        }
        private string GetCount(ulong amt)
        {
            return String.Format("{0:###,###,##0}", amt);
        }
        private string GetByteCount(ulong bytes)
        {
             return GetCount(bytes) + " bytes";
        }
        private string GetByteCount(ulong bytes, double percentage)
        {
            return GetByteCount(bytes) + String.Format(" ({0:N}%)", percentage);
        }
        private string GetIPS(double instrPerSec)
        {
            return String.Format("{0,6:###,##0.00} instr/sec", instrPerSec);
        }


        /*
         *** Event Functions
         */
        // Export Raw button clicked
        private void btnExportRaw_Click(object sender, EventArgs e)
        {
            ExportRawData();
        }

        // About button clicked
        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        // Load DS button clicked
        private void btnLoadDs_Click(object sender, EventArgs e)
        {
            OpenDsDialog();
        }

        // Capture button clicked
        private void btnCapture_Click(object sender, EventArgs e)
        {
            OpenCaptureDialog();
        }


        /*
         *** Menu Strip Event Functions
         */
        // Live Capture
        private void liveCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCaptureDialog();
        }

        // Open File
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenDataFile.ShowDialog() == DialogResult.OK)
            {
                if (LoadData(dlgOpenDataFile.FileName))
                    UpdateFromAnalyzer();
                // Else, it will pop up an error already
            }
        }

        // Quit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Export Raw Data
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportRawData();
        }
    }
}
