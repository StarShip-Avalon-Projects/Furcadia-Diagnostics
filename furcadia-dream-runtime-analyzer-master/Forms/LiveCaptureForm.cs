using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Furcadia;

namespace Dream_Runtime_Analyzer
{
    public partial class LiveCaptureForm : Form
    {
        // Public
        /// <summary>
        /// Returns TRUE if data analysis is available and can be taken from
        /// within the object. Used by Form1 to see if something was captured
        /// in the end.
        /// </summary>
        public bool IsDataAvailable
        {
            get { return (DataAnalyzer != null); }
        }
        public Analyzer DataAnalyzer;

        // Private
        private Character FurcCharacter;
        private FurcSession Session;
        private StreamWriter DataFile;

        private DateTime dtCaptureStart;
        private TimeSpan tsCaptureTime;

        // Are we capturing data right now?
        // Making our use of grpCaptureData to determine/change this transparent.
        private bool CaptureData
        {
            get { return grpCaptureData.Enabled; }
            set { grpCaptureData.Enabled = value; }
        }
        // Are we saving the data we capture to disk?
        private bool bSaveData;
        // Switch that indicates we're waiting for FurcSession to log in.
        private bool bWaitForLogin;


        /*
         *** Constructor
         */
        public LiveCaptureForm()
        {
            InitializeComponent();

            // Set initial directories, didn't set them in designer.
            this.dlgLoad.InitialDirectory = Furcadia.Paths.CharacterPath;
            this.dlgSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        /*
         *** User Interaction Functions
         */
        /// <summary>
        /// Take what's in the Command textbox and transmit it to the server.
        /// </summary>
        private void SendCommand()
        {
            string cmd = tbCommand.Text;

            PutLog("<< " + cmd);
            Session.SendLine(cmd);

            tbCommand.Clear();
        }
        /// <summary>
        /// Shows an error messagebox with a customized error message.
        /// </summary>
        /// <param name="errorMsg">Error message we should display</param>
        private void ShowError(string errorMsg)
        {
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Prompts the user to save a file with the Save dialog.
        /// </summary>
        /// <returns>TRUE if the user specified a filename, FALSE if they cancelled the dialog.</returns>
        private bool ShowSaveDialog()
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                tbSavePath.Text = dlgSave.FileName;
                return true;
            }

            return false;
        }



        /*
         *** Area Activation/Deactivation Functions
         */
        private void SetCustomServerControls(bool enabled)
        {
            tbFurcAddress.Enabled = enabled;
            tbFurcPort.Enabled = enabled;
        }
        private void SetTimerControls(bool enabled)
        {
            numDuration.Enabled = enabled;
            selectTimeUnits.Enabled = enabled;
        }
        private void SetCaptureSaveControls(bool enabled)
        {
            tbSavePath.Enabled = enabled;
            btnSaveBrowse.Enabled = enabled;
        }
        private void SetSendArea(bool enabled)
        {
            tbCommand.Enabled = enabled;
            btnSend.Enabled = enabled;
        }
        private void SetSettings(bool enabled)
        {
            grpLoginSettings.Enabled = enabled;
        }


        /*
         *** Miscellaneous Functions
         */
        /// <summary>
        /// Load login information from a specific Furcadia Character file.
        /// </summary>
        /// <param name="filename">Filename we should load character login data from</param>
        /// <returns>TRUE if loading operation was successful</returns>
        private bool LoadCharacter(string filename)
        {
            Character c = new Character();

            try
            {
                c.LoadCharacterFile(filename);
            }
            catch (Exception e)
            {
                ShowError("Unable to load character file: " + e.Message);
                return false;
            }

            FurcCharacter = c;
            UpdateFromCharacter();
            return true;
        }

        /*
         *** Update/Sync Functions
         */
        private void UpdateCaptureTime()
        {
            if (CaptureData)
                tsCaptureTime = DateTime.Now.Subtract(dtCaptureStart);
        }
        private void UpdateFromCharacter()
        {
            tbFurcUsername.Text = FurcCharacter.LongName;
            tbFurcPassword.Text = FurcCharacter.Password;
        }
        private void UpdateToCharacter()
        {
            if (FurcCharacter == null)
                FurcCharacter = new Character();

            FurcCharacter.LongName = tbFurcUsername.Text;
            FurcCharacter.Password = tbFurcPassword.Text;
        }
        private void UpdateFromSession()
        {
            UpdateCaptureTime();

            // Update log data.
            while (Session.HasNextStatus)
            {
                string status = Session.NextStatus;
                PutLog(status);

                if (bWaitForLogin && status == FurcSession.TEXT_LOGIN_SUCCESS)
                {
                    bWaitForLogin = false;
                    PostLogin();
                }

                if (status == FurcSession.TEXT_CONNECTION_LOST)
                {
                    DoDisconnect();
                    return;
                }
            }

            // If we are capturing data, pass any incoming instructions to
            // the Analyzer's parse function.
            while (Session.HasNextInstruction)
            {
                string instr = Session.NextInstruction;
                
                // If we're capturing to disk, write the data there.
                if (bSaveData)
                    WriteData(instr);

                // If we're capturing the data, pass it to the analyzer.
                if (CaptureData)
                    DataAnalyzer.Process(instr);

                // Let the session dispatcher handle this now.
                Session.Dispatch(instr);
            }

            // Update the UI from Analyzer
            UpdateFromAnalyzer();
        }
        private void UpdateFromAnalyzer()
        {
            // Update Capture Data text if the group is enabled...
            if (!CaptureData)
                return;

            // Update capture time if relevant.
            UpdateCaptureTime();

            ulong totalBytes = DataAnalyzer.TotalBytes;
            uint capSecs = GetCaptureSeconds();

            float dsPercent = (totalBytes > 0) ? (((float)DataAnalyzer.DsBytes / totalBytes) * 100) : 100;
            float avPercent = (totalBytes > 0) ? (((float)DataAnalyzer.AvatarBytes / totalBytes) * 100) : 100;
            float avgSpeed  = (capSecs > 0) ? ((float)DataAnalyzer.TotalBytes / 1024 / capSecs) : 0;

            txtRecvTotal.Text = String.Format("{0:##,###,##0}", DataAnalyzer.TotalBytes);
            txtRecvDsRelated.Text = String.Format("{0:##,###,##0} ({1:N}%)", DataAnalyzer.DsBytes, dsPercent);
            txtRecvAvatar.Text = String.Format("{0:##,###,##0} ({1:N}%)", DataAnalyzer.AvatarBytes, avPercent);
            txtAverageSpeed.Text = String.Format("{0:N} KB/sec", avgSpeed);
            txtLongestInstruction.Text = String.Format("{0:###,##0} bytes", DataAnalyzer.LongestInstructionLength);

            if (tStopCapture.Enabled)
            {
                txtCaptureTime.Text = String.Format("{0:00}:{1:00}:{2:00} ({3}sec left)",
                                            tsCaptureTime.Hours,
                                            tsCaptureTime.Minutes,
                                            tsCaptureTime.Seconds,
                                            ((tStopCapture.Interval / 1000) - GetCaptureSeconds())
                                      );
            }
            else
            {
                txtCaptureTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
                                            tsCaptureTime.Hours,
                                            tsCaptureTime.Minutes,
                                            tsCaptureTime.Seconds
                                      );
            }
        }


        /*
         *** Connectivity & Network I/O Functions
         */
        /// <summary>
        /// Make sure that everything is properly set before we can connect to
        /// Furcadia.
        /// </summary>
        /// <returns>TRUE if we are ready to connect. FALSE if we shouldn't.</returns>
        private bool CanConnect()
        {
            // Ensure that gameserver address isn't blank.
            if (cbCustomServer.Checked && tbFurcAddress.Text == "")
            {
                ShowError("Furcadia address box is empty! Please fill it or uncheck the Custom Server checkbox!");
                return false;
            }

            // Ensure character information is filled in.
            if (tbFurcUsername.Text == "" || tbFurcPassword.Text == "")
            {
                ShowError("Character login information missing - please fill in or load from an INI file.");
                return false;
            }

            // Ready to connect!
            return true;
        }
        /// <summary>
        /// Perform the connection procedure.
        /// </summary>
        private void DoConnect()
        {
            CaptureData = false;
            bWaitForLogin = true;

            // Make sure we're ready for it.
            if (!CanConnect())
                return;

            // Get hostname and port we're connecting to in the end.
            string addr = (cbCustomServer.Checked) ? tbFurcAddress.Text : Program.Settings.DEFAULT_FURC_ADDRESS;
            ushort port = (cbCustomServer.Checked) ? (ushort)tbFurcPort.Value : Program.Settings.DEFAULT_FURC_PORT;

            // Disable pre-connect groups - can't modify them online.
            SetSettings(false);

            ClearLog();

            UpdateToCharacter();
            
            Session = new FurcSession(addr, port, FurcCharacter);

            try
            {
                Session.Connect();
            }
            catch (Exception e)
            {
                string msg = "Cannot connect: " + e.Message;
                PutLog(msg);
                ShowError(msg);
                return;
            }

            DataAnalyzer = new Analyzer();

            tSync.Start();

            btnConnect.Text = "&Disconnect";
        }
        /// <summary>
        /// Perform a disconnection procedure.
        /// </summary>
        private void DoDisconnect()
        {
            btnStartStop.Enabled = false;

            // Stop capture if running.
            StopCapture();

            // Stop the timer and perform the last update from session.
            tSync.Stop();

            if (Session != null)
            {
                Session.Disconnect();
                UpdateFromSession();
                Session = null;
            }

            // Disable "Join Master" area.
            SetSendArea(false);

            // Re-enable the pre-connect groups.
            grpLoginSettings.Enabled = true;
            grpCaptureSettings.Enabled = true;
            
            btnConnect.Text = "&Connect";
        }
        /// <summary>
        /// Perform tasks we should do after a successful login attempt.
        /// </summary>
        private void PostLogin()
        {
            // Enable the Start Capture button.
            btnStartStop.Enabled = true;

            // If they want to capture right after login, let them
            if (cbStartAuto.Checked)
                StartCapture();

            SetSendArea(true);
        }


        /*
         *** Logging Functions
         */
        private void PutLog()
        {
            PutLog("");
        }
        private void PutLog(string text)
        {
            tbServerData.Text += text + Environment.NewLine;

            if (tbServerData.Lines.Length > 5)
            {
                tbServerData.Select(tbServerData.Text.Length - 1, 0);
                tbServerData.ScrollToCaret();
            }
        }
        private void ClearLog()
        {
            tbServerData.Text = "";
        }


        /*
         *** Data Capture Functions
         */
        private void StartCapture()
        {
            grpCaptureSettings.Enabled = false;

            // If they set a timer to stop the capture, configure it here
            if (cbStopAuto.Checked)
            {
                uint intval = (uint)numDuration.Value;
                bool breakOut = false;
                switch (selectTimeUnits.Text)
                {
                    case "sec":
                        intval *= 1000;
                        break;
                    case "min":
                        intval *= 60000;
                        break;
                    case "hr":
                        intval *= 3600000;
                        break;
                    default:
                        PutLog("*** WARNING: Unidentified time unit '" + selectTimeUnits.Text + "' - auto-stop time not set!");
                        breakOut = true;
                        break;
                }

                // If we didn't get a problem in mid-setting, activate the timer.
                if (!breakOut)
                {
                    tStopCapture.Interval = (int)intval;
                    tStopCapture.Start();
                }
            }

            // If they want to save capture data, open the capture file.
            string filename = null;
            bSaveData = cbSaveData.Checked;
            if (bSaveData)
            {
                // Ensure capture save data path is specified if enabled.
                if (cbSaveData.Checked && tbSavePath.Text == "")
                {
                    if (!ShowSaveDialog())
                    {
                        cbSaveData.Checked = false;
                        SetCaptureSaveControls(false);
                    }
                }

                OpenCaptureFile();
                filename = tbSavePath.Text;
            }

            // Enable capture group
            DataAnalyzer = new Analyzer(true);
            if (filename != null)
                DataAnalyzer.Title = filename;

            CaptureData = true;
            dtCaptureStart = DateTime.Now;

            PutLog("Started capturing data!");
            btnStartStop.Text = "&Stop Capture";
            UpdateFromAnalyzer();
        }
        private void StopCapture()
        {
            grpCaptureSettings.Enabled = true;

            // Neutralizing the StopCapture timer
            tStopCapture.Stop();
            UpdateCaptureTime();

            CaptureData = false;

            // Closing capture file is open
            if (bSaveData)
                CloseCaptureFile();

            PutLog("Data capture stopped.");
            btnStartStop.Text = "&Start Capture";
        }
        private void OpenCaptureFile()
        {
            DataFile = null;

            try
            {
                DataFile = new StreamWriter(File.Open(tbSavePath.Text, FileMode.Create, FileAccess.Write, FileShare.Read));
                DataFile.Write("TSCF-1.0\n");
            }
            catch (Exception e)
            {
                ShowError("Cannot open capture file: " + e.Message + " (capture will not be saved!)");
                CloseCaptureFile();
            }

            DataAnalyzer.Title = tbSavePath.Text;
        }
        private void CloseCaptureFile()
        {
            bSaveData = false;

            if (DataFile != null)
            {
                DataFile.Close();
                DataFile = null;
            }
        }
        private void WriteData(string data)
        {
            try
            {
                if (DataFile != null)
                    DataFile.Write(GetUnixTimestamp() + " " + data + '\n');
            }
            catch (Exception e)
            {
                ShowError("Error writing capture data: " + e.Message + " (writing discontinued!)");
                CloseCaptureFile();
            }
        }


        /*
         *** Data Generation & Retrieval Functions
         */
        /// <summary>
        /// Get the amount of seconds our capture has been running so far.
        /// </summary>
        /// <returns>Amount of seconds our capture has been running so far</returns>
        private uint GetCaptureSeconds()
        {
            return (uint)tsCaptureTime.TotalSeconds;
        }
        /// <summary>
        /// Returns a current UNIX timestamp.
        /// </summary>
        /// <returns>Current UNIX timestamp</returns>
        private uint GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (uint)ts.TotalSeconds;
        }


        /*
         *** Event Functions
         */
        // Custom Server checkbox clicked
        private void dbCustomServer_CheckedChanged(object sender, EventArgs e)
        {
            SetCustomServerControls(cbCustomServer.Checked);
        }

        // Load Character button clicked
        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            if (dlgLoad.ShowDialog() == DialogResult.OK)
            {
                LoadCharacter(dlgLoad.FileName);
            }
        }

        // Auto-Stop Checkbox clicked
        private void cbStopAuto_CheckedChanged(object sender, EventArgs e)
        {
            SetTimerControls(cbStopAuto.Checked);
        }

        // Text change attempt for time unit selection combo
        private void selectTimeUnits_TextUpdate(object sender, EventArgs e)
        {
            // Don't allow them to change it.
            selectTimeUnits.SelectedIndex = 1;
        }

        // Save Capture Data Checkbox clicked
        private void cbSaveData_CheckedChanged(object sender, EventArgs e)
        {
            SetCaptureSaveControls(cbSaveData.Checked);
        }

        // Capture DataFile Browse button clicked.
        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            ShowSaveDialog();
        }

        // Connect button clicked.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Check if we're connecting or disconnecting.
            if (btnConnect.Text == "&Connect")
                DoConnect();
            else
                DoDisconnect();
        }

        // UI update timer activated.
        private void tSync_Tick(object sender, EventArgs e)
        {
            UpdateFromSession();
        }

        // Capture stop timer activated.
        private void tStopCapture_Tick(object sender, EventArgs e)
        {
            StopCapture();
        }

        // Start/Stop Capture button clicked
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "&Start Capture")
                StartCapture();
            else
                StopCapture();
        }

        // Live Capture form is about to close
        private void LiveCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoDisconnect();
        }

        // Send button clicked
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        // ENTER key was pressed in the Command textbox
        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendCommand();
                e.Handled = true;
            }
        }
    }
}
