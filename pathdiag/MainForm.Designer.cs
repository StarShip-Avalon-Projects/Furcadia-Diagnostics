using System.Diagnostics;
using System.Reflection;

namespace PathDiag
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.pageProgram = new System.Windows.Forms.TabPage();
            this.btnDefaultMaps = new System.Windows.Forms.Button();
            this.btnOpenGlobalSkins = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDefaultMaps = new System.Windows.Forms.TextBox();
            this.tbGlobalSkins = new System.Windows.Forms.TextBox();
            this.btnOpenLocaldir = new System.Windows.Forms.Button();
            this.btnOpenDefaultPatch = new System.Windows.Forms.Button();
            this.btnOpenInstallPath = new System.Windows.Forms.Button();
            this.tbLocaldirPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDefaultPatchFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInstallFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pagePersonalized = new System.Windows.Forms.TabPage();
            this.btnOpenLocalSkins = new System.Windows.Forms.Button();
            this.btnOpenScreenshots = new System.Windows.Forms.Button();
            this.btnOpenWhisperLogs = new System.Windows.Forms.Button();
            this.btnOpenLogs = new System.Windows.Forms.Button();
            this.btnOpenPersonalDreams = new System.Windows.Forms.Button();
            this.btnOpenCharacter = new System.Windows.Forms.Button();
            this.btnOpenPersonal = new System.Windows.Forms.Button();
            this.btnOpenSettings = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbLocalSkins = new System.Windows.Forms.TextBox();
            this.tbScreenshots = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbWhisperLogs = new System.Windows.Forms.TextBox();
            this.tbSessionLogs = new System.Windows.Forms.TextBox();
            this.tbPersonalDreams = new System.Windows.Forms.TextBox();
            this.tbCharacterFiles = new System.Windows.Forms.TextBox();
            this.tbPersonalData = new System.Windows.Forms.TextBox();
            this.tbSettingsPath = new System.Windows.Forms.TextBox();
            this.pageCache = new System.Windows.Forms.TabPage();
            this.btnOpenTempPatches = new System.Windows.Forms.Button();
            this.btnOpenTempFiles = new System.Windows.Forms.Button();
            this.btnOpenTempDreams = new System.Windows.Forms.Button();
            this.btnOpenPermMaps = new System.Windows.Forms.Button();
            this.btnOpenPortCache = new System.Windows.Forms.Button();
            this.btnOpenCachePath = new System.Windows.Forms.Button();
            this.tbTemporaryPatches = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTemporaryFiles = new System.Windows.Forms.TextBox();
            this.tbTemporaryDreams = new System.Windows.Forms.TextBox();
            this.tbPermanentMaps = new System.Windows.Forms.TextBox();
            this.tbPortraitCache = new System.Windows.Forms.TextBox();
            this.tbCachePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPathType = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TabControl.SuspendLayout();
            this.pageProgram.SuspendLayout();
            this.pagePersonalized.SuspendLayout();
            this.pageCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.pageProgram);
            this.TabControl.Controls.Add(this.pagePersonalized);
            this.TabControl.Controls.Add(this.pageCache);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(585, 239);
            this.TabControl.TabIndex = 0;
            // 
            // pageProgram
            // 
            this.pageProgram.Controls.Add(this.btnDefaultMaps);
            this.pageProgram.Controls.Add(this.btnOpenGlobalSkins);
            this.pageProgram.Controls.Add(this.label3);
            this.pageProgram.Controls.Add(this.label2);
            this.pageProgram.Controls.Add(this.tbDefaultMaps);
            this.pageProgram.Controls.Add(this.tbGlobalSkins);
            this.pageProgram.Controls.Add(this.btnOpenLocaldir);
            this.pageProgram.Controls.Add(this.btnOpenDefaultPatch);
            this.pageProgram.Controls.Add(this.btnOpenInstallPath);
            this.pageProgram.Controls.Add(this.tbLocaldirPath);
            this.pageProgram.Controls.Add(this.label5);
            this.pageProgram.Controls.Add(this.tbDefaultPatchFolder);
            this.pageProgram.Controls.Add(this.label4);
            this.pageProgram.Controls.Add(this.tbInstallFolder);
            this.pageProgram.Controls.Add(this.label1);
            this.pageProgram.Location = new System.Drawing.Point(4, 22);
            this.pageProgram.Name = "pageProgram";
            this.pageProgram.Padding = new System.Windows.Forms.Padding(3);
            this.pageProgram.Size = new System.Drawing.Size(577, 213);
            this.pageProgram.TabIndex = 0;
            this.pageProgram.Text = "Program";
            this.pageProgram.UseVisualStyleBackColor = true;
            // 
            // btnDefaultMaps
            // 
            this.btnDefaultMaps.Location = new System.Drawing.Point(493, 82);
            this.btnDefaultMaps.Name = "btnDefaultMaps";
            this.btnDefaultMaps.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultMaps.TabIndex = 18;
            this.btnDefaultMaps.Text = "Open";
            this.btnDefaultMaps.UseVisualStyleBackColor = true;
            this.btnDefaultMaps.Click += new System.EventHandler(this.btnDefaultMaps_Click);
            // 
            // btnOpenGlobalSkins
            // 
            this.btnOpenGlobalSkins.Location = new System.Drawing.Point(493, 56);
            this.btnOpenGlobalSkins.Name = "btnOpenGlobalSkins";
            this.btnOpenGlobalSkins.Size = new System.Drawing.Size(75, 23);
            this.btnOpenGlobalSkins.TabIndex = 17;
            this.btnOpenGlobalSkins.Text = "Open";
            this.btnOpenGlobalSkins.UseVisualStyleBackColor = true;
            this.btnOpenGlobalSkins.Click += new System.EventHandler(this.btnOpenGlobalSkins_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Default Maps:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Global Skins:";
            // 
            // tbDefaultMaps
            // 
            this.tbDefaultMaps.Location = new System.Drawing.Point(118, 84);
            this.tbDefaultMaps.Name = "tbDefaultMaps";
            this.tbDefaultMaps.ReadOnly = true;
            this.tbDefaultMaps.Size = new System.Drawing.Size(369, 20);
            this.tbDefaultMaps.TabIndex = 14;
            // 
            // tbGlobalSkins
            // 
            this.tbGlobalSkins.Location = new System.Drawing.Point(118, 58);
            this.tbGlobalSkins.Name = "tbGlobalSkins";
            this.tbGlobalSkins.ReadOnly = true;
            this.tbGlobalSkins.Size = new System.Drawing.Size(369, 20);
            this.tbGlobalSkins.TabIndex = 13;
            // 
            // btnOpenLocaldir
            // 
            this.btnOpenLocaldir.Location = new System.Drawing.Point(493, 108);
            this.btnOpenLocaldir.Name = "btnOpenLocaldir";
            this.btnOpenLocaldir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLocaldir.TabIndex = 12;
            this.btnOpenLocaldir.Text = "Open";
            this.btnOpenLocaldir.UseVisualStyleBackColor = true;
            this.btnOpenLocaldir.Click += new System.EventHandler(this.btnOpenLocaldir_Click);
            // 
            // btnOpenDefaultPatch
            // 
            this.btnOpenDefaultPatch.Location = new System.Drawing.Point(493, 30);
            this.btnOpenDefaultPatch.Name = "btnOpenDefaultPatch";
            this.btnOpenDefaultPatch.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDefaultPatch.TabIndex = 11;
            this.btnOpenDefaultPatch.Text = "Open";
            this.btnOpenDefaultPatch.UseVisualStyleBackColor = true;
            this.btnOpenDefaultPatch.Click += new System.EventHandler(this.btnOpenDefaultPatch_Click);
            // 
            // btnOpenInstallPath
            // 
            this.btnOpenInstallPath.Location = new System.Drawing.Point(493, 4);
            this.btnOpenInstallPath.Name = "btnOpenInstallPath";
            this.btnOpenInstallPath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenInstallPath.TabIndex = 10;
            this.btnOpenInstallPath.Text = "Open";
            this.btnOpenInstallPath.UseVisualStyleBackColor = true;
            this.btnOpenInstallPath.Click += new System.EventHandler(this.btnOpenInstallPath_Click);
            // 
            // tbLocaldirPath
            // 
            this.tbLocaldirPath.Location = new System.Drawing.Point(118, 110);
            this.tbLocaldirPath.Name = "tbLocaldirPath";
            this.tbLocaldirPath.ReadOnly = true;
            this.tbLocaldirPath.Size = new System.Drawing.Size(369, 20);
            this.tbLocaldirPath.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Localdir Path:";
            // 
            // tbDefaultPatchFolder
            // 
            this.tbDefaultPatchFolder.Location = new System.Drawing.Point(118, 32);
            this.tbDefaultPatchFolder.Name = "tbDefaultPatchFolder";
            this.tbDefaultPatchFolder.ReadOnly = true;
            this.tbDefaultPatchFolder.Size = new System.Drawing.Size(369, 20);
            this.tbDefaultPatchFolder.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Default Patch Folder:";
            // 
            // tbInstallFolder
            // 
            this.tbInstallFolder.Location = new System.Drawing.Point(118, 6);
            this.tbInstallFolder.Name = "tbInstallFolder";
            this.tbInstallFolder.ReadOnly = true;
            this.tbInstallFolder.Size = new System.Drawing.Size(369, 20);
            this.tbInstallFolder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Install Folder:";
            // 
            // pagePersonalized
            // 
            this.pagePersonalized.Controls.Add(this.btnOpenLocalSkins);
            this.pagePersonalized.Controls.Add(this.btnOpenScreenshots);
            this.pagePersonalized.Controls.Add(this.btnOpenWhisperLogs);
            this.pagePersonalized.Controls.Add(this.btnOpenLogs);
            this.pagePersonalized.Controls.Add(this.btnOpenPersonalDreams);
            this.pagePersonalized.Controls.Add(this.btnOpenCharacter);
            this.pagePersonalized.Controls.Add(this.btnOpenPersonal);
            this.pagePersonalized.Controls.Add(this.btnOpenSettings);
            this.pagePersonalized.Controls.Add(this.label23);
            this.pagePersonalized.Controls.Add(this.label22);
            this.pagePersonalized.Controls.Add(this.tbLocalSkins);
            this.pagePersonalized.Controls.Add(this.tbScreenshots);
            this.pagePersonalized.Controls.Add(this.label21);
            this.pagePersonalized.Controls.Add(this.label20);
            this.pagePersonalized.Controls.Add(this.label19);
            this.pagePersonalized.Controls.Add(this.label18);
            this.pagePersonalized.Controls.Add(this.label17);
            this.pagePersonalized.Controls.Add(this.label16);
            this.pagePersonalized.Controls.Add(this.tbWhisperLogs);
            this.pagePersonalized.Controls.Add(this.tbSessionLogs);
            this.pagePersonalized.Controls.Add(this.tbPersonalDreams);
            this.pagePersonalized.Controls.Add(this.tbCharacterFiles);
            this.pagePersonalized.Controls.Add(this.tbPersonalData);
            this.pagePersonalized.Controls.Add(this.tbSettingsPath);
            this.pagePersonalized.Location = new System.Drawing.Point(4, 22);
            this.pagePersonalized.Name = "pagePersonalized";
            this.pagePersonalized.Size = new System.Drawing.Size(577, 213);
            this.pagePersonalized.TabIndex = 2;
            this.pagePersonalized.Text = "Personalized";
            this.pagePersonalized.UseVisualStyleBackColor = true;
            // 
            // btnOpenLocalSkins
            // 
            this.btnOpenLocalSkins.Location = new System.Drawing.Point(493, 186);
            this.btnOpenLocalSkins.Name = "btnOpenLocalSkins";
            this.btnOpenLocalSkins.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLocalSkins.TabIndex = 27;
            this.btnOpenLocalSkins.Text = "Open";
            this.btnOpenLocalSkins.UseVisualStyleBackColor = true;
            this.btnOpenLocalSkins.Click += new System.EventHandler(this.btnOpenLocalSkins_Click);
            // 
            // btnOpenScreenshots
            // 
            this.btnOpenScreenshots.Location = new System.Drawing.Point(493, 160);
            this.btnOpenScreenshots.Name = "btnOpenScreenshots";
            this.btnOpenScreenshots.Size = new System.Drawing.Size(75, 23);
            this.btnOpenScreenshots.TabIndex = 26;
            this.btnOpenScreenshots.Text = "Open";
            this.btnOpenScreenshots.UseVisualStyleBackColor = true;
            this.btnOpenScreenshots.Click += new System.EventHandler(this.btnOpenScreenshots_Click);
            // 
            // btnOpenWhisperLogs
            // 
            this.btnOpenWhisperLogs.Location = new System.Drawing.Point(493, 134);
            this.btnOpenWhisperLogs.Name = "btnOpenWhisperLogs";
            this.btnOpenWhisperLogs.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWhisperLogs.TabIndex = 25;
            this.btnOpenWhisperLogs.Text = "Open";
            this.btnOpenWhisperLogs.UseVisualStyleBackColor = true;
            this.btnOpenWhisperLogs.Click += new System.EventHandler(this.btnOpenWhisperLogs_Click);
            // 
            // btnOpenLogs
            // 
            this.btnOpenLogs.Location = new System.Drawing.Point(493, 108);
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLogs.TabIndex = 24;
            this.btnOpenLogs.Text = "Open";
            this.btnOpenLogs.UseVisualStyleBackColor = true;
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            // 
            // btnOpenPersonalDreams
            // 
            this.btnOpenPersonalDreams.Location = new System.Drawing.Point(493, 82);
            this.btnOpenPersonalDreams.Name = "btnOpenPersonalDreams";
            this.btnOpenPersonalDreams.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPersonalDreams.TabIndex = 23;
            this.btnOpenPersonalDreams.Text = "Open";
            this.btnOpenPersonalDreams.UseVisualStyleBackColor = true;
            this.btnOpenPersonalDreams.Click += new System.EventHandler(this.btnOpenPersonalDreams_Click);
            // 
            // btnOpenCharacter
            // 
            this.btnOpenCharacter.Location = new System.Drawing.Point(493, 56);
            this.btnOpenCharacter.Name = "btnOpenCharacter";
            this.btnOpenCharacter.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCharacter.TabIndex = 22;
            this.btnOpenCharacter.Text = "Open";
            this.btnOpenCharacter.UseVisualStyleBackColor = true;
            this.btnOpenCharacter.Click += new System.EventHandler(this.btnOpenCharacter_Click);
            // 
            // btnOpenPersonal
            // 
            this.btnOpenPersonal.Location = new System.Drawing.Point(493, 30);
            this.btnOpenPersonal.Name = "btnOpenPersonal";
            this.btnOpenPersonal.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPersonal.TabIndex = 21;
            this.btnOpenPersonal.Text = "Open";
            this.btnOpenPersonal.UseVisualStyleBackColor = true;
            this.btnOpenPersonal.Click += new System.EventHandler(this.btnOpenPersonal_Click);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(493, 4);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSettings.TabIndex = 20;
            this.btnOpenSettings.Text = "Open";
            this.btnOpenSettings.UseVisualStyleBackColor = true;
            this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 191);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Local Skins:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Screenshots:";
            // 
            // tbLocalSkins
            // 
            this.tbLocalSkins.Location = new System.Drawing.Point(118, 188);
            this.tbLocalSkins.Name = "tbLocalSkins";
            this.tbLocalSkins.ReadOnly = true;
            this.tbLocalSkins.Size = new System.Drawing.Size(369, 20);
            this.tbLocalSkins.TabIndex = 18;
            // 
            // tbScreenshots
            // 
            this.tbScreenshots.Location = new System.Drawing.Point(118, 162);
            this.tbScreenshots.Name = "tbScreenshots";
            this.tbScreenshots.ReadOnly = true;
            this.tbScreenshots.Size = new System.Drawing.Size(369, 20);
            this.tbScreenshots.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Whisper Logs:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Session Logs:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 87);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Personal Dreams:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Character Files:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Personal Data:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Settings Path:";
            // 
            // tbWhisperLogs
            // 
            this.tbWhisperLogs.Location = new System.Drawing.Point(118, 136);
            this.tbWhisperLogs.Name = "tbWhisperLogs";
            this.tbWhisperLogs.ReadOnly = true;
            this.tbWhisperLogs.Size = new System.Drawing.Size(369, 20);
            this.tbWhisperLogs.TabIndex = 10;
            // 
            // tbSessionLogs
            // 
            this.tbSessionLogs.Location = new System.Drawing.Point(118, 110);
            this.tbSessionLogs.Name = "tbSessionLogs";
            this.tbSessionLogs.ReadOnly = true;
            this.tbSessionLogs.Size = new System.Drawing.Size(369, 20);
            this.tbSessionLogs.TabIndex = 9;
            // 
            // tbPersonalDreams
            // 
            this.tbPersonalDreams.Location = new System.Drawing.Point(118, 84);
            this.tbPersonalDreams.Name = "tbPersonalDreams";
            this.tbPersonalDreams.ReadOnly = true;
            this.tbPersonalDreams.Size = new System.Drawing.Size(369, 20);
            this.tbPersonalDreams.TabIndex = 8;
            // 
            // tbCharacterFiles
            // 
            this.tbCharacterFiles.Location = new System.Drawing.Point(118, 58);
            this.tbCharacterFiles.Name = "tbCharacterFiles";
            this.tbCharacterFiles.ReadOnly = true;
            this.tbCharacterFiles.Size = new System.Drawing.Size(369, 20);
            this.tbCharacterFiles.TabIndex = 7;
            // 
            // tbPersonalData
            // 
            this.tbPersonalData.Location = new System.Drawing.Point(118, 32);
            this.tbPersonalData.Name = "tbPersonalData";
            this.tbPersonalData.ReadOnly = true;
            this.tbPersonalData.Size = new System.Drawing.Size(369, 20);
            this.tbPersonalData.TabIndex = 6;
            // 
            // tbSettingsPath
            // 
            this.tbSettingsPath.Location = new System.Drawing.Point(118, 6);
            this.tbSettingsPath.Name = "tbSettingsPath";
            this.tbSettingsPath.ReadOnly = true;
            this.tbSettingsPath.Size = new System.Drawing.Size(369, 20);
            this.tbSettingsPath.TabIndex = 5;
            // 
            // pageCache
            // 
            this.pageCache.Controls.Add(this.btnOpenTempPatches);
            this.pageCache.Controls.Add(this.btnOpenTempFiles);
            this.pageCache.Controls.Add(this.btnOpenTempDreams);
            this.pageCache.Controls.Add(this.btnOpenPermMaps);
            this.pageCache.Controls.Add(this.btnOpenPortCache);
            this.pageCache.Controls.Add(this.btnOpenCachePath);
            this.pageCache.Controls.Add(this.tbTemporaryPatches);
            this.pageCache.Controls.Add(this.label15);
            this.pageCache.Controls.Add(this.label14);
            this.pageCache.Controls.Add(this.label13);
            this.pageCache.Controls.Add(this.label12);
            this.pageCache.Controls.Add(this.label11);
            this.pageCache.Controls.Add(this.label10);
            this.pageCache.Controls.Add(this.tbTemporaryFiles);
            this.pageCache.Controls.Add(this.tbTemporaryDreams);
            this.pageCache.Controls.Add(this.tbPermanentMaps);
            this.pageCache.Controls.Add(this.tbPortraitCache);
            this.pageCache.Controls.Add(this.tbCachePath);
            this.pageCache.Location = new System.Drawing.Point(4, 22);
            this.pageCache.Name = "pageCache";
            this.pageCache.Padding = new System.Windows.Forms.Padding(3);
            this.pageCache.Size = new System.Drawing.Size(577, 213);
            this.pageCache.TabIndex = 1;
            this.pageCache.Text = "Cache";
            this.pageCache.UseVisualStyleBackColor = true;
            // 
            // btnOpenTempPatches
            // 
            this.btnOpenTempPatches.Location = new System.Drawing.Point(493, 134);
            this.btnOpenTempPatches.Name = "btnOpenTempPatches";
            this.btnOpenTempPatches.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTempPatches.TabIndex = 21;
            this.btnOpenTempPatches.Text = "Open";
            this.btnOpenTempPatches.UseVisualStyleBackColor = true;
            this.btnOpenTempPatches.Click += new System.EventHandler(this.btnOpenTempPatches_Click);
            // 
            // btnOpenTempFiles
            // 
            this.btnOpenTempFiles.Location = new System.Drawing.Point(493, 108);
            this.btnOpenTempFiles.Name = "btnOpenTempFiles";
            this.btnOpenTempFiles.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTempFiles.TabIndex = 20;
            this.btnOpenTempFiles.Text = "Open";
            this.btnOpenTempFiles.UseVisualStyleBackColor = true;
            this.btnOpenTempFiles.Click += new System.EventHandler(this.btnOpenTempFiles_Click);
            // 
            // btnOpenTempDreams
            // 
            this.btnOpenTempDreams.Location = new System.Drawing.Point(493, 82);
            this.btnOpenTempDreams.Name = "btnOpenTempDreams";
            this.btnOpenTempDreams.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTempDreams.TabIndex = 19;
            this.btnOpenTempDreams.Text = "Open";
            this.btnOpenTempDreams.UseVisualStyleBackColor = true;
            this.btnOpenTempDreams.Click += new System.EventHandler(this.btnOpenTempDreams_Click);
            // 
            // btnOpenPermMaps
            // 
            this.btnOpenPermMaps.Location = new System.Drawing.Point(493, 56);
            this.btnOpenPermMaps.Name = "btnOpenPermMaps";
            this.btnOpenPermMaps.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPermMaps.TabIndex = 18;
            this.btnOpenPermMaps.Text = "Open";
            this.btnOpenPermMaps.UseVisualStyleBackColor = true;
            this.btnOpenPermMaps.Click += new System.EventHandler(this.btnOpenPermMaps_Click);
            // 
            // btnOpenPortCache
            // 
            this.btnOpenPortCache.Location = new System.Drawing.Point(493, 30);
            this.btnOpenPortCache.Name = "btnOpenPortCache";
            this.btnOpenPortCache.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPortCache.TabIndex = 17;
            this.btnOpenPortCache.Text = "Open";
            this.btnOpenPortCache.UseVisualStyleBackColor = true;
            this.btnOpenPortCache.Click += new System.EventHandler(this.btnOpenPortCache_Click);
            // 
            // btnOpenCachePath
            // 
            this.btnOpenCachePath.Location = new System.Drawing.Point(493, 4);
            this.btnOpenCachePath.Name = "btnOpenCachePath";
            this.btnOpenCachePath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCachePath.TabIndex = 16;
            this.btnOpenCachePath.Text = "Open";
            this.btnOpenCachePath.UseVisualStyleBackColor = true;
            this.btnOpenCachePath.Click += new System.EventHandler(this.btnOpenCachePath_Click);
            // 
            // tbTemporaryPatches
            // 
            this.tbTemporaryPatches.Location = new System.Drawing.Point(118, 136);
            this.tbTemporaryPatches.Name = "tbTemporaryPatches";
            this.tbTemporaryPatches.ReadOnly = true;
            this.tbTemporaryPatches.Size = new System.Drawing.Size(369, 20);
            this.tbTemporaryPatches.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Temporary Patches:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Temporary Files:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Temporary Dreams:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Permanent Maps:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Portrait Cache:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cache Path:";
            // 
            // tbTemporaryFiles
            // 
            this.tbTemporaryFiles.Location = new System.Drawing.Point(118, 110);
            this.tbTemporaryFiles.Name = "tbTemporaryFiles";
            this.tbTemporaryFiles.ReadOnly = true;
            this.tbTemporaryFiles.Size = new System.Drawing.Size(369, 20);
            this.tbTemporaryFiles.TabIndex = 8;
            // 
            // tbTemporaryDreams
            // 
            this.tbTemporaryDreams.Location = new System.Drawing.Point(118, 84);
            this.tbTemporaryDreams.Name = "tbTemporaryDreams";
            this.tbTemporaryDreams.ReadOnly = true;
            this.tbTemporaryDreams.Size = new System.Drawing.Size(369, 20);
            this.tbTemporaryDreams.TabIndex = 7;
            // 
            // tbPermanentMaps
            // 
            this.tbPermanentMaps.Location = new System.Drawing.Point(118, 58);
            this.tbPermanentMaps.Name = "tbPermanentMaps";
            this.tbPermanentMaps.ReadOnly = true;
            this.tbPermanentMaps.Size = new System.Drawing.Size(369, 20);
            this.tbPermanentMaps.TabIndex = 6;
            // 
            // tbPortraitCache
            // 
            this.tbPortraitCache.Location = new System.Drawing.Point(118, 32);
            this.tbPortraitCache.Name = "tbPortraitCache";
            this.tbPortraitCache.ReadOnly = true;
            this.tbPortraitCache.Size = new System.Drawing.Size(369, 20);
            this.tbPortraitCache.TabIndex = 5;
            // 
            // tbCachePath
            // 
            this.tbCachePath.Location = new System.Drawing.Point(118, 6);
            this.tbCachePath.Name = "tbCachePath";
            this.tbCachePath.ReadOnly = true;
            this.tbCachePath.Size = new System.Drawing.Size(369, 20);
            this.tbCachePath.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(521, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "1.100.100.100";
            // 
            // cbPathType
            // 
            this.cbPathType.Items.AddRange(new object[] {
            "Current",
            "Default"});
            this.cbPathType.Location = new System.Drawing.Point(423, 6);
            this.cbPathType.Name = "cbPathType";
            this.cbPathType.Size = new System.Drawing.Size(80, 21);
            this.cbPathType.TabIndex = 14;
            this.cbPathType.Text = "Current";
            this.cbPathType.SelectedIndexChanged += new System.EventHandler(this.cbPathType_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(361, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(282, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 13);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "FilePath Docs";
            this.linkLabel1.Click += linklable1_clicked;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 256);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbPathType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(625, 295);
            this.MinimumSize = new System.Drawing.Size(625, 295);
            this.Name = "MainForm";
            this.Text = "Furcadia/Furcadia-Frmework Path Diagnostic Tool";
            this.TabControl.ResumeLayout(false);
            this.pageProgram.ResumeLayout(false);
            this.pageProgram.PerformLayout();
            this.pagePersonalized.ResumeLayout(false);
            this.pagePersonalized.PerformLayout();
            this.pageCache.ResumeLayout(false);
            this.pageCache.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage pageProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pageCache;
        private System.Windows.Forms.TabPage pagePersonalized;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInstallFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDefaultPatchFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLocaldirPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTemporaryFiles;
        private System.Windows.Forms.TextBox tbTemporaryDreams;
        private System.Windows.Forms.TextBox tbPermanentMaps;
        private System.Windows.Forms.TextBox tbPortraitCache;
        private System.Windows.Forms.TextBox tbCachePath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbPathType;
        private System.Windows.Forms.TextBox tbTemporaryPatches;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbWhisperLogs;
        private System.Windows.Forms.TextBox tbSessionLogs;
        private System.Windows.Forms.TextBox tbPersonalDreams;
        private System.Windows.Forms.TextBox tbCharacterFiles;
        private System.Windows.Forms.TextBox tbPersonalData;
        private System.Windows.Forms.TextBox tbSettingsPath;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbLocalSkins;
        private System.Windows.Forms.TextBox tbScreenshots;
        private System.Windows.Forms.Button btnOpenLocaldir;
        private System.Windows.Forms.Button btnOpenDefaultPatch;
        private System.Windows.Forms.Button btnOpenInstallPath;
        private System.Windows.Forms.Button btnOpenTempPatches;
        private System.Windows.Forms.Button btnOpenTempFiles;
        private System.Windows.Forms.Button btnOpenTempDreams;
        private System.Windows.Forms.Button btnOpenPermMaps;
        private System.Windows.Forms.Button btnOpenPortCache;
        private System.Windows.Forms.Button btnOpenCachePath;
        private System.Windows.Forms.Button btnOpenLocalSkins;
        private System.Windows.Forms.Button btnOpenScreenshots;
        private System.Windows.Forms.Button btnOpenWhisperLogs;
        private System.Windows.Forms.Button btnOpenLogs;
        private System.Windows.Forms.Button btnOpenPersonalDreams;
        private System.Windows.Forms.Button btnOpenCharacter;
        private System.Windows.Forms.Button btnOpenPersonal;
        private System.Windows.Forms.Button btnOpenSettings;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDefaultMaps;
        private System.Windows.Forms.TextBox tbGlobalSkins;
        private System.Windows.Forms.Button btnDefaultMaps;
        private System.Windows.Forms.Button btnOpenGlobalSkins;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

