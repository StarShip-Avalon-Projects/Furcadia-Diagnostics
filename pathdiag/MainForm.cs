using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PathDiag
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private Furcadia.IO.Paths FurcadiaPaths;

        #endregion Private Fields

        #region Public Constructors

        public MainForm()
        {
            FurcadiaPaths = new Furcadia.IO.Paths();
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.label6.Text = fvi.FileVersion;
            RefreshData();
        }

        #endregion Public Constructors

        #region Private Methods

        private void btnDefaultMaps_Click(object sender, EventArgs e)
        {
            OpenPath(tbDefaultMaps.Text);
        }

        private void btnOpenCachePath_Click(object sender, EventArgs e)
        {
            OpenPath(tbCachePath.Text);
        }

        private void btnOpenCharacter_Click(object sender, EventArgs e)
        {
            OpenPath(tbCharacterFiles.Text);
        }

        private void btnOpenDefaultPatch_Click(object sender, EventArgs e)
        {
            OpenPath(tbDefaultPatchFolder.Text);
        }

        private void btnOpenGlobalSkins_Click(object sender, EventArgs e)
        {
            OpenPath(tbGlobalSkins.Text);
        }

        //--- OPEN BUTTON HANDLING (*sigh*) ---//
        private void btnOpenInstallPath_Click(object sender, EventArgs e)
        {
            OpenPath(tbInstallFolder.Text);
        }

        private void btnOpenLocaldir_Click(object sender, EventArgs e)
        {
            OpenPath(tbLocaldirPath.Text);
        }

        private void btnOpenLocalSkins_Click(object sender, EventArgs e)
        {
            OpenPath(tbLocalSkins.Text);
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            OpenPath(tbSessionLogs.Text);
        }

        private void btnOpenPermMaps_Click(object sender, EventArgs e)
        {
            OpenPath(tbPermanentMaps.Text);
        }

        private void btnOpenPersonal_Click(object sender, EventArgs e)
        {
            OpenPath(tbPersonalData.Text);
        }

        private void btnOpenPersonalDreams_Click(object sender, EventArgs e)
        {
            OpenPath(tbPersonalDreams.Text);
        }

        private void btnOpenPortCache_Click(object sender, EventArgs e)
        {
            OpenPath(tbPortraitCache.Text);
        }

        private void btnOpenScreenshots_Click(object sender, EventArgs e)
        {
            OpenPath(tbScreenshots.Text);
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            OpenPath(tbSettingsPath.Text);
        }

        private void btnOpenTempDreams_Click(object sender, EventArgs e)
        {
            OpenPath(tbTemporaryDreams.Text);
        }

        private void btnOpenTempFiles_Click(object sender, EventArgs e)
        {
            OpenPath(tbTemporaryFiles.Text);
        }

        private void btnOpenTempPatches_Click(object sender, EventArgs e)
        {
            OpenPath(tbTemporaryPatches.Text);
        }

        private void btnOpenWhisperLogs_Click(object sender, EventArgs e)
        {
            OpenPath(tbWhisperLogs.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cbPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void OpenPath(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCurrentPaths()
        {
            // If we can't find the installation path, we might as well abort.
            if (FurcadiaPaths.FurcadiaPath == null)
            {
                MessageBox.Show(
                    "Furcadia installation was not found on this system - all current paths should not exist.",
                    "Note",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                cbPathType.SelectedText = "Default";
                return;
            }

            // Program Tab
            tbInstallFolder.Text = FurcadiaPaths.FurcadiaPath;
            tbDefaultPatchFolder.Text = FurcadiaPaths.DefaultPatchPath;
            tbGlobalSkins.Text = FurcadiaPaths.GlobalSkinsPath;
            tbDefaultMaps.Text = FurcadiaPaths.GlobalMapsPath;

            tbLocaldirPath.Text = (FurcadiaPaths.UsingLocaldir) ? FurcadiaPaths.LocaldirPath : "Not Available";
            btnOpenLocaldir.Enabled = FurcadiaPaths.UsingLocaldir;

            // Personalized Tab
            tbSettingsPath.Text = FurcadiaPaths.SettingsPath;
            tbPersonalData.Text = FurcadiaPaths.PersonalDataPath;
            tbCharacterFiles.Text = FurcadiaPaths.CharacterPath;
            tbPersonalDreams.Text = FurcadiaPaths.DreamsPath;
            tbSessionLogs.Text = FurcadiaPaths.LogsPath;
            tbWhisperLogs.Text = FurcadiaPaths.WhisperLogsPath;
            tbScreenshots.Text = FurcadiaPaths.ScreenshotsPath;
            tbLocalSkins.Text = FurcadiaPaths.LocalSkinsPath;

            // Cache Tab
            tbCachePath.Text = FurcadiaPaths.CachePath;
            tbPortraitCache.Text = FurcadiaPaths.PortraitCachePath;
            tbPermanentMaps.Text = FurcadiaPaths.PermanentMapsCachePath;
            tbTemporaryDreams.Text = FurcadiaPaths.TemporaryDreamsPath;
            tbTemporaryFiles.Text = FurcadiaPaths.TemporaryFilesPath;
            tbTemporaryPatches.Text = FurcadiaPaths.TemporaryPatchesPath;
        }

        private void PopulateDefaultPaths()
        {
            // Program Tab
            tbInstallFolder.Text = FurcadiaPaths.DefaultFurcadiaPath;
            tbGlobalSkins.Text = FurcadiaPaths.DefaultGlobalSkinsPath;
            tbDefaultMaps.Text = FurcadiaPaths.DefaultGlobalMapsPath;
            tbDefaultPatchFolder.Text = Path.Combine(FurcadiaPaths.DefaultFurcadiaPath, @"patches", @"default");

            tbLocaldirPath.Text = (FurcadiaPaths.UsingLocaldir) ? FurcadiaPaths.LocaldirPath : "Not Available";
            btnOpenLocaldir.Enabled = FurcadiaPaths.UsingLocaldir;

            // Personalized Tab
            tbSettingsPath.Text = FurcadiaPaths.DefaultSettingsPath;
            tbPersonalData.Text = FurcadiaPaths.DefaultPersonalDataPath;
            tbCharacterFiles.Text = FurcadiaPaths.DefaultCharacterPath;
            tbPersonalDreams.Text = FurcadiaPaths.DefaultDreamsPath;
            tbSessionLogs.Text = FurcadiaPaths.DefaultLogsPath;
            tbWhisperLogs.Text = FurcadiaPaths.DefaultWhisperLogsPath;
            tbScreenshots.Text = FurcadiaPaths.DefaultScreenshotsPath;
            tbLocalSkins.Text = FurcadiaPaths.DefaultLocalSkinsPath;

            // Cache Tab
            tbCachePath.Text = FurcadiaPaths.DefaultCachePath;
            tbPortraitCache.Text = FurcadiaPaths.DefaultPortraitCachePath;
            tbPermanentMaps.Text = FurcadiaPaths.DefaultPermanentMapsCachePath;
            tbTemporaryDreams.Text = FurcadiaPaths.DefaultTemporaryDreamsPath;
            tbTemporaryFiles.Text = FurcadiaPaths.DefaultTemporaryFilesPath;
            tbTemporaryPatches.Text = FurcadiaPaths.DefaultTemporaryPatchesPath;
        }

        private void RefreshData()
        {
            FurcadiaPaths = new Furcadia.IO.Paths();
            FurcadiaPaths.GetFurcadiaLocaldirPath(); // Rescan Localdir to avoid cache.
            if (cbPathType.Text == "Current")
                PopulateCurrentPaths();
            else
                PopulateDefaultPaths();
        }

        #endregion Private Methods

        private void linklable1_clicked(object sender, EventArgs e)
        {
            Process.Start("https://starship-avalon-projects.github.io/FurcadiaFramework/html/a23d6f60-970b-4881-ad5f-077563316c63.htm");
        }
    }
}