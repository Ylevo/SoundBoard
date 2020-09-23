namespace SoundBoard
{
    partial class mainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.audioHkDevicesCmbBox = new System.Windows.Forms.ComboBox();
            this.audioHkDataGrid = new System.Windows.Forms.DataGridView();
            this.audioNameCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioKeyCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioShortFilesDisplayCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioFullFilesDisplayCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioFilesHiddenCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioStartCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioVolumeCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioIdCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioHkAddNewBtn = new System.Windows.Forms.Button();
            this.audioHkFilesPathTxtBox = new System.Windows.Forms.TextBox();
            this.audioHkBrowseBtn = new System.Windows.Forms.Button();
            this.browseDialog = new System.Windows.Forms.OpenFileDialog();
            this.audioHkRemoveBtn = new System.Windows.Forms.Button();
            this.audioHkTxtBox = new System.Windows.Forms.TextBox();
            this.audioHkKeyLbl = new System.Windows.Forms.Label();
            this.audioHkNameLbl = new System.Windows.Forms.Label();
            this.audioHkNameTxtBox = new System.Windows.Forms.TextBox();
            this.audioHkVolumeLbl = new System.Windows.Forms.Label();
            this.audioHkVolumeBar = new System.Windows.Forms.TrackBar();
            this.audioHkStartAtTimePicker = new System.Windows.Forms.DateTimePicker();
            this.audioHkStartAtLbl = new System.Windows.Forms.Label();
            this.audioHkAudioDeviceLbl = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.newFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.loadFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.saveFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.saveAsFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.exportAsZipFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.alwaysSaveOnClosingFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.exitFileSubMenuItem = new System.Windows.Forms.MenuItem();
            this.optionsMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.aboutSubMenuItem = new System.Windows.Forms.MenuItem();
            this.ItemTemplate = new Microsoft.VisualBasic.PowerPacks.DataRepeaterItem();
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.audioHkTab = new System.Windows.Forms.TabPage();
            this.audioTabGrpBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.audioHkVolumePanel = new System.Windows.Forms.Panel();
            this.volumeValueLbl = new System.Windows.Forms.Label();
            this.separatorLineLbl = new System.Windows.Forms.Label();
            this.controlHkFadingTab = new System.Windows.Forms.TabPage();
            this.controlHkFadingGrpBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.controlHkHeaderLbl = new System.Windows.Forms.Label();
            this.fadingHeaderLbl = new System.Windows.Forms.Label();
            this.controlHkDataGrid = new System.Windows.Forms.DataGridView();
            this.ctrlKeyCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlIdCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fadingDataGrid = new System.Windows.Forms.DataGridView();
            this.actionDisplayFadeCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionNameFadeCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fadeInCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fadeOutCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.fadingInLbl = new System.Windows.Forms.Label();
            this.fadingOutLbl = new System.Windows.Forms.Label();
            this.fadeInBar = new System.Windows.Forms.TrackBar();
            this.fadeOutBar = new System.Windows.Forms.TrackBar();
            this.fadingApplyBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.controlHkAddNewBtn = new System.Windows.Forms.Button();
            this.controlHkRemoveBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.controlHkKeyLbl = new System.Windows.Forms.Label();
            this.controlHkActionLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.controlHkFwdBwdPanel = new System.Windows.Forms.Panel();
            this.controlHkFwdBwdValueNmrc = new System.Windows.Forms.NumericUpDown();
            this.controlHkFwdBwdSecondsLbl = new System.Windows.Forms.Label();
            this.controlHkFwdBwdByLbl = new System.Windows.Forms.Label();
            this.controlHkVolumeTempoPanel = new System.Windows.Forms.Panel();
            this.volumePanelValueLbl = new System.Windows.Forms.Label();
            this.volumeByLbl = new System.Windows.Forms.Label();
            this.controlHkVolumeBar = new System.Windows.Forms.TrackBar();
            this.controlHkPitchPanel = new System.Windows.Forms.Panel();
            this.controlHkPitchPanelValueLbl = new System.Windows.Forms.Label();
            this.controlHkPitchBar = new System.Windows.Forms.TrackBar();
            this.controlHkPitchByLbl = new System.Windows.Forms.Label();
            this.controlHkKeyPressPanel = new System.Windows.Forms.Panel();
            this.controlHkKeyToPressTxtBox = new System.Windows.Forms.TextBox();
            this.controlHkKeyToPressLbl = new System.Windows.Forms.Label();
            this.controlHkKeyTxtBox = new System.Windows.Forms.TextBox();
            this.controlHkRoleCmbBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.audioHkDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioHkVolumeBar)).BeginInit();
            this.mainTabCtrl.SuspendLayout();
            this.audioHkTab.SuspendLayout();
            this.audioTabGrpBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.audioHkVolumePanel.SuspendLayout();
            this.controlHkFadingTab.SuspendLayout();
            this.controlHkFadingGrpBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fadingDataGrid)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fadeInBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeOutBar)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.controlHkFwdBwdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkFwdBwdValueNmrc)).BeginInit();
            this.controlHkVolumeTempoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkVolumeBar)).BeginInit();
            this.controlHkPitchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkPitchBar)).BeginInit();
            this.controlHkKeyPressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // audioHkDevicesCmbBox
            // 
            this.audioHkDevicesCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkDevicesCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioHkDevicesCmbBox.FormattingEnabled = true;
            this.audioHkDevicesCmbBox.Location = new System.Drawing.Point(148, 23);
            this.audioHkDevicesCmbBox.Name = "audioHkDevicesCmbBox";
            this.audioHkDevicesCmbBox.Size = new System.Drawing.Size(283, 21);
            this.audioHkDevicesCmbBox.TabIndex = 0;
            // 
            // audioHkDataGrid
            // 
            this.audioHkDataGrid.AllowUserToAddRows = false;
            this.audioHkDataGrid.AllowUserToDeleteRows = false;
            this.audioHkDataGrid.AllowUserToResizeRows = false;
            this.audioHkDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.audioHkDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.audioHkDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.audioHkDataGrid.ColumnHeadersHeight = 25;
            this.audioHkDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.audioHkDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.audioNameCln,
            this.audioKeyCln,
            this.audioShortFilesDisplayCln,
            this.audioFullFilesDisplayCln,
            this.audioFilesHiddenCln,
            this.audioStartCln,
            this.audioVolumeCln,
            this.audioIdCln});
            this.audioHkDataGrid.Location = new System.Drawing.Point(20, 60);
            this.audioHkDataGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 40);
            this.audioHkDataGrid.MultiSelect = false;
            this.audioHkDataGrid.Name = "audioHkDataGrid";
            this.audioHkDataGrid.RowHeadersVisible = false;
            this.audioHkDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.audioHkDataGrid.Size = new System.Drawing.Size(707, 184);
            this.audioHkDataGrid.TabIndex = 3;
            this.audioHkDataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.HotkeysDataGrids_CellBeginEdit);
            this.audioHkDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AudioHkDataGrid_CellContentDoubleClick);
            this.audioHkDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HotkeysDataGrids_CellEndEdit);
            this.audioHkDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AudioHkDataGrid_CellEnter);
            this.audioHkDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AudioHkDataGrid_CellValueChanged);
            this.audioHkDataGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.AudioHkDataGrid_CurrentCellDirtyStateChanged);
            this.audioHkDataGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.HotkeysDataGrids_EditingControlShowing);
            this.audioHkDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HkDataGrid_KeyDown);
            // 
            // audioNameCln
            // 
            this.audioNameCln.HeaderText = "Name";
            this.audioNameCln.Name = "audioNameCln";
            // 
            // audioKeyCln
            // 
            this.audioKeyCln.FillWeight = 60F;
            this.audioKeyCln.HeaderText = "Key";
            this.audioKeyCln.Name = "audioKeyCln";
            // 
            // audioShortFilesDisplayCln
            // 
            this.audioShortFilesDisplayCln.FillWeight = 120F;
            this.audioShortFilesDisplayCln.HeaderText = "Files";
            this.audioShortFilesDisplayCln.Name = "audioShortFilesDisplayCln";
            this.audioShortFilesDisplayCln.ReadOnly = true;
            // 
            // audioFullFilesDisplayCln
            // 
            this.audioFullFilesDisplayCln.FillWeight = 120F;
            this.audioFullFilesDisplayCln.HeaderText = "Files";
            this.audioFullFilesDisplayCln.Name = "audioFullFilesDisplayCln";
            this.audioFullFilesDisplayCln.ReadOnly = true;
            this.audioFullFilesDisplayCln.Visible = false;
            // 
            // audioFilesHiddenCln
            // 
            this.audioFilesHiddenCln.HeaderText = "FilesHidden";
            this.audioFilesHiddenCln.Name = "audioFilesHiddenCln";
            this.audioFilesHiddenCln.Visible = false;
            // 
            // audioStartCln
            // 
            this.audioStartCln.FillWeight = 30F;
            this.audioStartCln.HeaderText = "Start";
            this.audioStartCln.Name = "audioStartCln";
            // 
            // audioVolumeCln
            // 
            this.audioVolumeCln.FillWeight = 30F;
            this.audioVolumeCln.HeaderText = "Volume";
            this.audioVolumeCln.Name = "audioVolumeCln";
            // 
            // audioIdCln
            // 
            this.audioIdCln.HeaderText = "audioIdCln";
            this.audioIdCln.Name = "audioIdCln";
            this.audioIdCln.Visible = false;
            // 
            // audioHkAddNewBtn
            // 
            this.audioHkAddNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.audioHkAddNewBtn.Location = new System.Drawing.Point(20, 257);
            this.audioHkAddNewBtn.Name = "audioHkAddNewBtn";
            this.audioHkAddNewBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.audioHkAddNewBtn.Size = new System.Drawing.Size(85, 23);
            this.audioHkAddNewBtn.TabIndex = 4;
            this.audioHkAddNewBtn.Text = "Add new";
            this.audioHkAddNewBtn.UseVisualStyleBackColor = true;
            this.audioHkAddNewBtn.Click += new System.EventHandler(this.AudioHkAddNewBtn_Click);
            // 
            // audioHkFilesPathTxtBox
            // 
            this.audioHkFilesPathTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.audioHkFilesPathTxtBox, 3);
            this.audioHkFilesPathTxtBox.Location = new System.Drawing.Point(90, 44);
            this.audioHkFilesPathTxtBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.audioHkFilesPathTxtBox.Name = "audioHkFilesPathTxtBox";
            this.audioHkFilesPathTxtBox.ReadOnly = true;
            this.audioHkFilesPathTxtBox.Size = new System.Drawing.Size(367, 20);
            this.audioHkFilesPathTxtBox.TabIndex = 7;
            // 
            // audioHkBrowseBtn
            // 
            this.audioHkBrowseBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.audioHkBrowseBtn.Location = new System.Drawing.Point(3, 42);
            this.audioHkBrowseBtn.Name = "audioHkBrowseBtn";
            this.audioHkBrowseBtn.Size = new System.Drawing.Size(81, 23);
            this.audioHkBrowseBtn.TabIndex = 8;
            this.audioHkBrowseBtn.Text = "Browse";
            this.audioHkBrowseBtn.UseVisualStyleBackColor = true;
            this.audioHkBrowseBtn.Click += new System.EventHandler(this.AudioHkBrowseBtn_Click);
            // 
            // browseDialog
            // 
            this.browseDialog.Filter = "Audio files|*.mp3;*.wav;";
            this.browseDialog.Multiselect = true;
            // 
            // audioHkRemoveBtn
            // 
            this.audioHkRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.audioHkRemoveBtn.Location = new System.Drawing.Point(126, 257);
            this.audioHkRemoveBtn.Name = "audioHkRemoveBtn";
            this.audioHkRemoveBtn.Size = new System.Drawing.Size(85, 23);
            this.audioHkRemoveBtn.TabIndex = 11;
            this.audioHkRemoveBtn.Text = "Remove";
            this.audioHkRemoveBtn.UseVisualStyleBackColor = true;
            this.audioHkRemoveBtn.Click += new System.EventHandler(this.HkRemoveBtn_Click);
            // 
            // audioHkTxtBox
            // 
            this.audioHkTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkTxtBox.Location = new System.Drawing.Point(90, 5);
            this.audioHkTxtBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.audioHkTxtBox.Name = "audioHkTxtBox";
            this.audioHkTxtBox.Size = new System.Drawing.Size(129, 20);
            this.audioHkTxtBox.TabIndex = 12;
            this.audioHkTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyInput);
            // 
            // audioHkKeyLbl
            // 
            this.audioHkKeyLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkKeyLbl.AutoSize = true;
            this.audioHkKeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkKeyLbl.Location = new System.Drawing.Point(3, 6);
            this.audioHkKeyLbl.Name = "audioHkKeyLbl";
            this.audioHkKeyLbl.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.audioHkKeyLbl.Size = new System.Drawing.Size(81, 17);
            this.audioHkKeyLbl.TabIndex = 14;
            this.audioHkKeyLbl.Text = "Key :";
            // 
            // audioHkNameLbl
            // 
            this.audioHkNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkNameLbl.AutoSize = true;
            this.audioHkNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkNameLbl.Location = new System.Drawing.Point(242, 6);
            this.audioHkNameLbl.Name = "audioHkNameLbl";
            this.audioHkNameLbl.Size = new System.Drawing.Size(79, 17);
            this.audioHkNameLbl.TabIndex = 19;
            this.audioHkNameLbl.Text = "Name :";
            // 
            // audioHkNameTxtBox
            // 
            this.audioHkNameTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkNameTxtBox.Location = new System.Drawing.Point(327, 5);
            this.audioHkNameTxtBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.audioHkNameTxtBox.Name = "audioHkNameTxtBox";
            this.audioHkNameTxtBox.Size = new System.Drawing.Size(130, 20);
            this.audioHkNameTxtBox.TabIndex = 20;
            // 
            // audioHkVolumeLbl
            // 
            this.audioHkVolumeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkVolumeLbl.AutoSize = true;
            this.audioHkVolumeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkVolumeLbl.Location = new System.Drawing.Point(480, 45);
            this.audioHkVolumeLbl.Margin = new System.Windows.Forms.Padding(3);
            this.audioHkVolumeLbl.Name = "audioHkVolumeLbl";
            this.audioHkVolumeLbl.Size = new System.Drawing.Size(84, 17);
            this.audioHkVolumeLbl.TabIndex = 25;
            this.audioHkVolumeLbl.Text = "Volume :";
            // 
            // audioHkVolumeBar
            // 
            this.audioHkVolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkVolumeBar.AutoSize = false;
            this.audioHkVolumeBar.Location = new System.Drawing.Point(0, 12);
            this.audioHkVolumeBar.Maximum = 100;
            this.audioHkVolumeBar.Name = "audioHkVolumeBar";
            this.audioHkVolumeBar.Size = new System.Drawing.Size(133, 23);
            this.audioHkVolumeBar.TabIndex = 24;
            this.audioHkVolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.audioHkVolumeBar.Value = 20;
            this.audioHkVolumeBar.Scroll += new System.EventHandler(this.AudioHkVolumeBar_Scroll);
            this.audioHkVolumeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AudioHkVolumeBar_MouseDown);
            this.audioHkVolumeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AudioHkVolumeBar_MouseUp);
            // 
            // audioHkStartAtTimePicker
            // 
            this.audioHkStartAtTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.audioHkStartAtTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkStartAtTimePicker.Location = new System.Drawing.Point(570, 4);
            this.audioHkStartAtTimePicker.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.audioHkStartAtTimePicker.Name = "audioHkStartAtTimePicker";
            this.audioHkStartAtTimePicker.Size = new System.Drawing.Size(83, 22);
            this.audioHkStartAtTimePicker.TabIndex = 23;
            this.audioHkStartAtTimePicker.Value = new System.DateTime(2015, 7, 23, 0, 0, 0, 0);
            // 
            // audioHkStartAtLbl
            // 
            this.audioHkStartAtLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkStartAtLbl.AutoSize = true;
            this.audioHkStartAtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkStartAtLbl.Location = new System.Drawing.Point(480, 6);
            this.audioHkStartAtLbl.Name = "audioHkStartAtLbl";
            this.audioHkStartAtLbl.Size = new System.Drawing.Size(84, 17);
            this.audioHkStartAtLbl.TabIndex = 22;
            this.audioHkStartAtLbl.Text = "Start at :";
            // 
            // audioHkAudioDeviceLbl
            // 
            this.audioHkAudioDeviceLbl.AutoSize = true;
            this.audioHkAudioDeviceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioHkAudioDeviceLbl.Location = new System.Drawing.Point(28, 24);
            this.audioHkAudioDeviceLbl.Name = "audioHkAudioDeviceLbl";
            this.audioHkAudioDeviceLbl.Size = new System.Drawing.Size(99, 17);
            this.audioHkAudioDeviceLbl.TabIndex = 21;
            this.audioHkAudioDeviceLbl.Text = "Audio Output :";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem,
            this.optionsMenuItem,
            this.helpMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newFileSubMenuItem,
            this.loadFileSubMenuItem,
            this.menuItem1,
            this.saveFileSubMenuItem,
            this.saveAsFileSubMenuItem,
            this.exportAsZipFileSubMenuItem,
            this.alwaysSaveOnClosingFileSubMenuItem,
            this.menuItem2,
            this.exitFileSubMenuItem});
            this.fileMenuItem.Text = "File";
            // 
            // newFileSubMenuItem
            // 
            this.newFileSubMenuItem.Index = 0;
            this.newFileSubMenuItem.Text = "New";
            this.newFileSubMenuItem.Click += new System.EventHandler(this.NewFileSubMenuItem_Click);
            // 
            // loadFileSubMenuItem
            // 
            this.loadFileSubMenuItem.Index = 1;
            this.loadFileSubMenuItem.Text = "Load...";
            this.loadFileSubMenuItem.Click += new System.EventHandler(this.LoadFileSubMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // saveFileSubMenuItem
            // 
            this.saveFileSubMenuItem.Index = 3;
            this.saveFileSubMenuItem.Text = "Save";
            this.saveFileSubMenuItem.Click += new System.EventHandler(this.SaveFileSubMenuItem_Click);
            // 
            // saveAsFileSubMenuItem
            // 
            this.saveAsFileSubMenuItem.Index = 4;
            this.saveAsFileSubMenuItem.Text = "Save as...";
            this.saveAsFileSubMenuItem.Click += new System.EventHandler(this.SaveAsFileSubMenuItem_Click);
            // 
            // exportAsZipFileSubMenuItem
            // 
            this.exportAsZipFileSubMenuItem.Index = 5;
            this.exportAsZipFileSubMenuItem.Text = "Export as zip...";
            this.exportAsZipFileSubMenuItem.Click += new System.EventHandler(this.ExportAsZipFileSubMenuItem_Click);
            // 
            // alwaysSaveOnClosingFileSubMenuItem
            // 
            this.alwaysSaveOnClosingFileSubMenuItem.Index = 6;
            this.alwaysSaveOnClosingFileSubMenuItem.Text = "Always save on closing";
            this.alwaysSaveOnClosingFileSubMenuItem.Click += new System.EventHandler(this.AlwaysSaveOnClosingFileSubMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 7;
            this.menuItem2.Text = "-";
            // 
            // exitFileSubMenuItem
            // 
            this.exitFileSubMenuItem.Index = 8;
            this.exitFileSubMenuItem.Text = "Exit";
            this.exitFileSubMenuItem.Click += new System.EventHandler(this.ExitFileSubMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Index = 1;
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 2;
            this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.aboutSubMenuItem});
            this.helpMenuItem.Text = "Help";
            // 
            // aboutSubMenuItem
            // 
            this.aboutSubMenuItem.Index = 0;
            this.aboutSubMenuItem.Text = "About";
            this.aboutSubMenuItem.Click += new System.EventHandler(this.AboutSubMenuItem_Click);
            // 
            // ItemTemplate
            // 
            this.ItemTemplate.Size = new System.Drawing.Size(232, 100);
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabCtrl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.mainTabCtrl.Controls.Add(this.audioHkTab);
            this.mainTabCtrl.Controls.Add(this.controlHkFadingTab);
            this.mainTabCtrl.Location = new System.Drawing.Point(3, 12);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(760, 408);
            this.mainTabCtrl.TabIndex = 27;
            // 
            // audioHkTab
            // 
            this.audioHkTab.BackColor = System.Drawing.SystemColors.Control;
            this.audioHkTab.Controls.Add(this.audioTabGrpBox);
            this.audioHkTab.Location = new System.Drawing.Point(4, 25);
            this.audioHkTab.Name = "audioHkTab";
            this.audioHkTab.Padding = new System.Windows.Forms.Padding(3);
            this.audioHkTab.Size = new System.Drawing.Size(752, 379);
            this.audioHkTab.TabIndex = 1;
            this.audioHkTab.Text = "Audio Hotkeys";
            // 
            // audioTabGrpBox
            // 
            this.audioTabGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioTabGrpBox.BackColor = System.Drawing.SystemColors.Control;
            this.audioTabGrpBox.Controls.Add(this.tableLayoutPanel1);
            this.audioTabGrpBox.Controls.Add(this.audioHkAudioDeviceLbl);
            this.audioTabGrpBox.Controls.Add(this.separatorLineLbl);
            this.audioTabGrpBox.Controls.Add(this.audioHkDevicesCmbBox);
            this.audioTabGrpBox.Controls.Add(this.audioHkDataGrid);
            this.audioTabGrpBox.Controls.Add(this.audioHkAddNewBtn);
            this.audioTabGrpBox.Controls.Add(this.audioHkRemoveBtn);
            this.audioTabGrpBox.Location = new System.Drawing.Point(3, -4);
            this.audioTabGrpBox.Name = "audioTabGrpBox";
            this.audioTabGrpBox.Size = new System.Drawing.Size(749, 384);
            this.audioTabGrpBox.TabIndex = 28;
            this.audioTabGrpBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.19087F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.50622F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.30291F));
            this.tableLayoutPanel1.Controls.Add(this.audioHkVolumePanel, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.audioHkKeyLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.audioHkFilesPathTxtBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.audioHkTxtBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.audioHkVolumeLbl, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.audioHkBrowseBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.audioHkNameLbl, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.audioHkNameTxtBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.audioHkStartAtLbl, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.audioHkStartAtTimePicker, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 299);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.72603F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.27397F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 78);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // audioHkVolumePanel
            // 
            this.audioHkVolumePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.audioHkVolumePanel.Controls.Add(this.audioHkVolumeBar);
            this.audioHkVolumePanel.Controls.Add(this.volumeValueLbl);
            this.audioHkVolumePanel.Location = new System.Drawing.Point(570, 33);
            this.audioHkVolumePanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.audioHkVolumePanel.Name = "audioHkVolumePanel";
            this.audioHkVolumePanel.Size = new System.Drawing.Size(134, 35);
            this.audioHkVolumePanel.TabIndex = 29;
            // 
            // volumeValueLbl
            // 
            this.volumeValueLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.volumeValueLbl.AutoSize = true;
            this.volumeValueLbl.Location = new System.Drawing.Point(52, 0);
            this.volumeValueLbl.Name = "volumeValueLbl";
            this.volumeValueLbl.Size = new System.Drawing.Size(27, 13);
            this.volumeValueLbl.TabIndex = 26;
            this.volumeValueLbl.Text = "20%";
            // 
            // separatorLineLbl
            // 
            this.separatorLineLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorLineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLineLbl.Location = new System.Drawing.Point(20, 294);
            this.separatorLineLbl.Name = "separatorLineLbl";
            this.separatorLineLbl.Size = new System.Drawing.Size(707, 2);
            this.separatorLineLbl.TabIndex = 27;
            // 
            // controlHkFadingTab
            // 
            this.controlHkFadingTab.BackColor = System.Drawing.SystemColors.Control;
            this.controlHkFadingTab.Controls.Add(this.controlHkFadingGrpBox);
            this.controlHkFadingTab.Location = new System.Drawing.Point(4, 25);
            this.controlHkFadingTab.Name = "controlHkFadingTab";
            this.controlHkFadingTab.Padding = new System.Windows.Forms.Padding(3);
            this.controlHkFadingTab.Size = new System.Drawing.Size(752, 379);
            this.controlHkFadingTab.TabIndex = 0;
            this.controlHkFadingTab.Text = "Control Hotkeys & Fading";
            // 
            // controlHkFadingGrpBox
            // 
            this.controlHkFadingGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkFadingGrpBox.BackColor = System.Drawing.SystemColors.Control;
            this.controlHkFadingGrpBox.Controls.Add(this.tableLayoutPanel2);
            this.controlHkFadingGrpBox.Location = new System.Drawing.Point(3, -4);
            this.controlHkFadingGrpBox.Name = "controlHkFadingGrpBox";
            this.controlHkFadingGrpBox.Size = new System.Drawing.Size(749, 384);
            this.controlHkFadingGrpBox.TabIndex = 0;
            this.controlHkFadingGrpBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.38F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.controlHkHeaderLbl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.fadingHeaderLbl, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.controlHkDataGrid, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.fadingDataGrid, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(704, 358);
            this.tableLayoutPanel2.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(141, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel1.Size = new System.Drawing.Size(210, 24);
            this.panel1.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 2);
            this.label3.TabIndex = 29;
            // 
            // controlHkHeaderLbl
            // 
            this.controlHkHeaderLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkHeaderLbl.AutoSize = true;
            this.controlHkHeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkHeaderLbl.Location = new System.Drawing.Point(3, 0);
            this.controlHkHeaderLbl.Name = "controlHkHeaderLbl";
            this.controlHkHeaderLbl.Size = new System.Drawing.Size(132, 18);
            this.controlHkHeaderLbl.TabIndex = 0;
            this.controlHkHeaderLbl.Text = "Control Hotkeys";
            // 
            // fadingHeaderLbl
            // 
            this.fadingHeaderLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadingHeaderLbl.AutoSize = true;
            this.fadingHeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadingHeaderLbl.Location = new System.Drawing.Point(422, 0);
            this.fadingHeaderLbl.Name = "fadingHeaderLbl";
            this.fadingHeaderLbl.Size = new System.Drawing.Size(59, 18);
            this.fadingHeaderLbl.TabIndex = 1;
            this.fadingHeaderLbl.Text = "Fading";
            // 
            // controlHkDataGrid
            // 
            this.controlHkDataGrid.AllowUserToAddRows = false;
            this.controlHkDataGrid.AllowUserToDeleteRows = false;
            this.controlHkDataGrid.AllowUserToResizeRows = false;
            this.controlHkDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.controlHkDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.controlHkDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.controlHkDataGrid.ColumnHeadersHeight = 22;
            this.controlHkDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.controlHkDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctrlKeyCln,
            this.actionCln,
            this.valueCln,
            this.ctrlIdCln});
            this.tableLayoutPanel2.SetColumnSpan(this.controlHkDataGrid, 2);
            this.controlHkDataGrid.Location = new System.Drawing.Point(3, 33);
            this.controlHkDataGrid.Name = "controlHkDataGrid";
            this.controlHkDataGrid.RowHeadersVisible = false;
            this.controlHkDataGrid.Size = new System.Drawing.Size(348, 181);
            this.controlHkDataGrid.TabIndex = 30;
            this.controlHkDataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.HotkeysDataGrids_CellBeginEdit);
            this.controlHkDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HotkeysDataGrids_CellEndEdit);
            this.controlHkDataGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.HotkeysDataGrids_EditingControlShowing);
            this.controlHkDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HkDataGrid_KeyDown);
            // 
            // ctrlKeyCln
            // 
            this.ctrlKeyCln.FillWeight = 110F;
            this.ctrlKeyCln.HeaderText = "Key";
            this.ctrlKeyCln.Name = "ctrlKeyCln";
            // 
            // actionCln
            // 
            this.actionCln.FillWeight = 118F;
            this.actionCln.HeaderText = "Action";
            this.actionCln.Name = "actionCln";
            this.actionCln.ReadOnly = true;
            // 
            // valueCln
            // 
            this.valueCln.FillWeight = 72F;
            this.valueCln.HeaderText = "Value";
            this.valueCln.Name = "valueCln";
            this.valueCln.ReadOnly = true;
            // 
            // ctrlIdCln
            // 
            this.ctrlIdCln.HeaderText = "idCln";
            this.ctrlIdCln.Name = "ctrlIdCln";
            this.ctrlIdCln.ReadOnly = true;
            this.ctrlIdCln.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(487, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel2.Size = new System.Drawing.Size(214, 24);
            this.panel2.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 2);
            this.label4.TabIndex = 29;
            // 
            // fadingDataGrid
            // 
            this.fadingDataGrid.AllowUserToAddRows = false;
            this.fadingDataGrid.AllowUserToDeleteRows = false;
            this.fadingDataGrid.AllowUserToResizeRows = false;
            this.fadingDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadingDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fadingDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.fadingDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.fadingDataGrid.ColumnHeadersHeight = 25;
            this.fadingDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fadingDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.actionDisplayFadeCln,
            this.actionNameFadeCln,
            this.fadeInCln,
            this.fadeOutCln});
            this.tableLayoutPanel2.SetColumnSpan(this.fadingDataGrid, 2);
            this.fadingDataGrid.Location = new System.Drawing.Point(422, 33);
            this.fadingDataGrid.MultiSelect = false;
            this.fadingDataGrid.Name = "fadingDataGrid";
            this.fadingDataGrid.ReadOnly = true;
            this.fadingDataGrid.RowHeadersVisible = false;
            this.fadingDataGrid.RowTemplate.Height = 38;
            this.fadingDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fadingDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fadingDataGrid.Size = new System.Drawing.Size(279, 181);
            this.fadingDataGrid.TabIndex = 31;
            this.fadingDataGrid.SelectionChanged += new System.EventHandler(this.FadingDataGrid_SelectionChanged);
            this.fadingDataGrid.SizeChanged += new System.EventHandler(this.FadingDataGrid_SizeChanged);
            // 
            // actionDisplayFadeCln
            // 
            this.actionDisplayFadeCln.FillWeight = 140.6548F;
            this.actionDisplayFadeCln.HeaderText = "Action";
            this.actionDisplayFadeCln.Name = "actionDisplayFadeCln";
            this.actionDisplayFadeCln.ReadOnly = true;
            // 
            // actionNameFadeCln
            // 
            this.actionNameFadeCln.HeaderText = "actionNameFadeCln";
            this.actionNameFadeCln.Name = "actionNameFadeCln";
            this.actionNameFadeCln.ReadOnly = true;
            this.actionNameFadeCln.Visible = false;
            // 
            // fadeInCln
            // 
            this.fadeInCln.FillWeight = 70.23041F;
            this.fadeInCln.HeaderText = "Fade in";
            this.fadeInCln.Name = "fadeInCln";
            this.fadeInCln.ReadOnly = true;
            // 
            // fadeOutCln
            // 
            this.fadeOutCln.FillWeight = 75.11478F;
            this.fadeOutCln.HeaderText = "Fade out";
            this.fadeOutCln.Name = "fadeOutCln";
            this.fadeOutCln.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(387, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 30, 0);
            this.label5.Name = "label5";
            this.tableLayoutPanel2.SetRowSpan(this.label5, 2);
            this.label5.Size = new System.Drawing.Size(2, 328);
            this.label5.TabIndex = 51;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.fadingInLbl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fadingOutLbl, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.fadeInBar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.fadeOutBar, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.fadingApplyBtn, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(422, 220);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.69231F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.30769F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(279, 135);
            this.tableLayoutPanel3.TabIndex = 52;
            // 
            // fadingInLbl
            // 
            this.fadingInLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadingInLbl.AutoSize = true;
            this.fadingInLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadingInLbl.Location = new System.Drawing.Point(3, 42);
            this.fadingInLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.fadingInLbl.Name = "fadingInLbl";
            this.fadingInLbl.Size = new System.Drawing.Size(67, 16);
            this.fadingInLbl.TabIndex = 33;
            this.fadingInLbl.Text = "Fade in :";
            // 
            // fadingOutLbl
            // 
            this.fadingOutLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadingOutLbl.AutoSize = true;
            this.fadingOutLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadingOutLbl.Location = new System.Drawing.Point(3, 74);
            this.fadingOutLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 17);
            this.fadingOutLbl.Name = "fadingOutLbl";
            this.fadingOutLbl.Size = new System.Drawing.Size(67, 16);
            this.fadingOutLbl.TabIndex = 34;
            this.fadingOutLbl.Text = "Fade out :";
            // 
            // fadeInBar
            // 
            this.fadeInBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadeInBar.AutoSize = false;
            this.fadeInBar.Location = new System.Drawing.Point(76, 41);
            this.fadeInBar.Maximum = 2000;
            this.fadeInBar.Name = "fadeInBar";
            this.fadeInBar.Size = new System.Drawing.Size(200, 29);
            this.fadeInBar.TabIndex = 35;
            this.fadeInBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fadeInBar.Value = 1;
            this.fadeInBar.Scroll += new System.EventHandler(this.FadeInBar_Scroll);
            // 
            // fadeOutBar
            // 
            this.fadeOutBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fadeOutBar.AutoSize = false;
            this.fadeOutBar.Location = new System.Drawing.Point(76, 76);
            this.fadeOutBar.Maximum = 2000;
            this.fadeOutBar.Name = "fadeOutBar";
            this.fadeOutBar.Size = new System.Drawing.Size(200, 28);
            this.fadeOutBar.TabIndex = 36;
            this.fadeOutBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fadeOutBar.Value = 200;
            this.fadeOutBar.Scroll += new System.EventHandler(this.FadeOutBar_Scroll);
            // 
            // fadingApplyBtn
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.fadingApplyBtn, 2);
            this.fadingApplyBtn.Location = new System.Drawing.Point(3, 110);
            this.fadingApplyBtn.Name = "fadingApplyBtn";
            this.fadingApplyBtn.Size = new System.Drawing.Size(75, 22);
            this.fadingApplyBtn.TabIndex = 37;
            this.fadingApplyBtn.Text = "Apply";
            this.fadingApplyBtn.UseVisualStyleBackColor = true;
            this.fadingApplyBtn.Click += new System.EventHandler(this.FadingApplyBtn_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.controlHkAddNewBtn, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.controlHkRemoveBtn, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 220);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(348, 135);
            this.tableLayoutPanel4.TabIndex = 53;
            // 
            // controlHkAddNewBtn
            // 
            this.controlHkAddNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.controlHkAddNewBtn.Location = new System.Drawing.Point(3, 12);
            this.controlHkAddNewBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.controlHkAddNewBtn.Name = "controlHkAddNewBtn";
            this.controlHkAddNewBtn.Size = new System.Drawing.Size(85, 23);
            this.controlHkAddNewBtn.TabIndex = 42;
            this.controlHkAddNewBtn.Text = "Add new";
            this.controlHkAddNewBtn.UseVisualStyleBackColor = true;
            this.controlHkAddNewBtn.Click += new System.EventHandler(this.ControlHkAddHkBtn_Click);
            // 
            // controlHkRemoveBtn
            // 
            this.controlHkRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.controlHkRemoveBtn.Location = new System.Drawing.Point(103, 12);
            this.controlHkRemoveBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.controlHkRemoveBtn.Name = "controlHkRemoveBtn";
            this.controlHkRemoveBtn.Size = new System.Drawing.Size(85, 23);
            this.controlHkRemoveBtn.TabIndex = 43;
            this.controlHkRemoveBtn.Text = "Remove";
            this.controlHkRemoveBtn.UseVisualStyleBackColor = true;
            this.controlHkRemoveBtn.Click += new System.EventHandler(this.HkRemoveBtn_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel4.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.13F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.87F));
            this.tableLayoutPanel5.Controls.Add(this.controlHkKeyLbl, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.controlHkActionLbl, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.controlHkKeyTxtBox, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.controlHkRoleCmbBox, 3, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.61225F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.38776F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(342, 84);
            this.tableLayoutPanel5.TabIndex = 44;
            // 
            // controlHkKeyLbl
            // 
            this.controlHkKeyLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkKeyLbl.AutoSize = true;
            this.controlHkKeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkKeyLbl.Location = new System.Drawing.Point(3, 4);
            this.controlHkKeyLbl.Name = "controlHkKeyLbl";
            this.controlHkKeyLbl.Size = new System.Drawing.Size(39, 16);
            this.controlHkKeyLbl.TabIndex = 38;
            this.controlHkKeyLbl.Text = "Key :";
            // 
            // controlHkActionLbl
            // 
            this.controlHkActionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkActionLbl.AutoSize = true;
            this.controlHkActionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkActionLbl.Location = new System.Drawing.Point(147, 4);
            this.controlHkActionLbl.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.controlHkActionLbl.Name = "controlHkActionLbl";
            this.controlHkActionLbl.Size = new System.Drawing.Size(57, 16);
            this.controlHkActionLbl.TabIndex = 40;
            this.controlHkActionLbl.Text = "Action :";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.controlHkFwdBwdPanel);
            this.panel3.Controls.Add(this.controlHkVolumeTempoPanel);
            this.panel3.Controls.Add(this.controlHkPitchPanel);
            this.panel3.Controls.Add(this.controlHkKeyPressPanel);
            this.panel3.Location = new System.Drawing.Point(144, 25);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 59);
            this.panel3.TabIndex = 49;
            // 
            // controlHkFwdBwdPanel
            // 
            this.controlHkFwdBwdPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkFwdBwdPanel.Controls.Add(this.controlHkFwdBwdValueNmrc);
            this.controlHkFwdBwdPanel.Controls.Add(this.controlHkFwdBwdSecondsLbl);
            this.controlHkFwdBwdPanel.Controls.Add(this.controlHkFwdBwdByLbl);
            this.controlHkFwdBwdPanel.Location = new System.Drawing.Point(2, 2);
            this.controlHkFwdBwdPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlHkFwdBwdPanel.Name = "controlHkFwdBwdPanel";
            this.controlHkFwdBwdPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.controlHkFwdBwdPanel.Size = new System.Drawing.Size(190, 50);
            this.controlHkFwdBwdPanel.TabIndex = 44;
            // 
            // controlHkFwdBwdValueNmrc
            // 
            this.controlHkFwdBwdValueNmrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkFwdBwdValueNmrc.Location = new System.Drawing.Point(63, 10);
            this.controlHkFwdBwdValueNmrc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.controlHkFwdBwdValueNmrc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.controlHkFwdBwdValueNmrc.Name = "controlHkFwdBwdValueNmrc";
            this.controlHkFwdBwdValueNmrc.Size = new System.Drawing.Size(45, 20);
            this.controlHkFwdBwdValueNmrc.TabIndex = 3;
            this.controlHkFwdBwdValueNmrc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // controlHkFwdBwdSecondsLbl
            // 
            this.controlHkFwdBwdSecondsLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.controlHkFwdBwdSecondsLbl.AutoSize = true;
            this.controlHkFwdBwdSecondsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkFwdBwdSecondsLbl.Location = new System.Drawing.Point(111, 11);
            this.controlHkFwdBwdSecondsLbl.Name = "controlHkFwdBwdSecondsLbl";
            this.controlHkFwdBwdSecondsLbl.Size = new System.Drawing.Size(60, 16);
            this.controlHkFwdBwdSecondsLbl.TabIndex = 2;
            this.controlHkFwdBwdSecondsLbl.Text = "seconds";
            // 
            // controlHkFwdBwdByLbl
            // 
            this.controlHkFwdBwdByLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkFwdBwdByLbl.AutoSize = true;
            this.controlHkFwdBwdByLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkFwdBwdByLbl.Location = new System.Drawing.Point(22, 11);
            this.controlHkFwdBwdByLbl.Name = "controlHkFwdBwdByLbl";
            this.controlHkFwdBwdByLbl.Size = new System.Drawing.Size(23, 16);
            this.controlHkFwdBwdByLbl.TabIndex = 0;
            this.controlHkFwdBwdByLbl.Text = "by";
            // 
            // controlHkVolumeTempoPanel
            // 
            this.controlHkVolumeTempoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkVolumeTempoPanel.Controls.Add(this.volumePanelValueLbl);
            this.controlHkVolumeTempoPanel.Controls.Add(this.volumeByLbl);
            this.controlHkVolumeTempoPanel.Controls.Add(this.controlHkVolumeBar);
            this.controlHkVolumeTempoPanel.Location = new System.Drawing.Point(2, 2);
            this.controlHkVolumeTempoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlHkVolumeTempoPanel.Name = "controlHkVolumeTempoPanel";
            this.controlHkVolumeTempoPanel.Size = new System.Drawing.Size(190, 50);
            this.controlHkVolumeTempoPanel.TabIndex = 46;
            this.controlHkVolumeTempoPanel.Visible = false;
            // 
            // volumePanelValueLbl
            // 
            this.volumePanelValueLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.volumePanelValueLbl.AutoSize = true;
            this.volumePanelValueLbl.Location = new System.Drawing.Point(109, 0);
            this.volumePanelValueLbl.Name = "volumePanelValueLbl";
            this.volumePanelValueLbl.Size = new System.Drawing.Size(21, 13);
            this.volumePanelValueLbl.TabIndex = 48;
            this.volumePanelValueLbl.Text = "1%";
            // 
            // volumeByLbl
            // 
            this.volumeByLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeByLbl.AutoSize = true;
            this.volumeByLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeByLbl.Location = new System.Drawing.Point(22, 11);
            this.volumeByLbl.Name = "volumeByLbl";
            this.volumeByLbl.Size = new System.Drawing.Size(23, 16);
            this.volumeByLbl.TabIndex = 1;
            this.volumeByLbl.Text = "by";
            // 
            // controlHkVolumeBar
            // 
            this.controlHkVolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkVolumeBar.AutoSize = false;
            this.controlHkVolumeBar.Location = new System.Drawing.Point(56, 12);
            this.controlHkVolumeBar.Maximum = 100;
            this.controlHkVolumeBar.Minimum = 1;
            this.controlHkVolumeBar.Name = "controlHkVolumeBar";
            this.controlHkVolumeBar.Size = new System.Drawing.Size(133, 25);
            this.controlHkVolumeBar.TabIndex = 47;
            this.controlHkVolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.controlHkVolumeBar.Value = 1;
            this.controlHkVolumeBar.Scroll += new System.EventHandler(this.ControlHkVolumeBar_Scroll);
            // 
            // controlHkPitchPanel
            // 
            this.controlHkPitchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkPitchPanel.Controls.Add(this.controlHkPitchPanelValueLbl);
            this.controlHkPitchPanel.Controls.Add(this.controlHkPitchBar);
            this.controlHkPitchPanel.Controls.Add(this.controlHkPitchByLbl);
            this.controlHkPitchPanel.Location = new System.Drawing.Point(2, 2);
            this.controlHkPitchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlHkPitchPanel.Name = "controlHkPitchPanel";
            this.controlHkPitchPanel.Size = new System.Drawing.Size(190, 50);
            this.controlHkPitchPanel.TabIndex = 47;
            this.controlHkPitchPanel.Visible = false;
            // 
            // controlHkPitchPanelValueLbl
            // 
            this.controlHkPitchPanelValueLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.controlHkPitchPanelValueLbl.AutoSize = true;
            this.controlHkPitchPanelValueLbl.Location = new System.Drawing.Point(109, 0);
            this.controlHkPitchPanelValueLbl.Name = "controlHkPitchPanelValueLbl";
            this.controlHkPitchPanelValueLbl.Size = new System.Drawing.Size(28, 13);
            this.controlHkPitchPanelValueLbl.TabIndex = 48;
            this.controlHkPitchPanelValueLbl.Text = "+0,1";
            // 
            // controlHkPitchBar
            // 
            this.controlHkPitchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkPitchBar.AutoSize = false;
            this.controlHkPitchBar.Location = new System.Drawing.Point(56, 12);
            this.controlHkPitchBar.Maximum = 50;
            this.controlHkPitchBar.Minimum = 1;
            this.controlHkPitchBar.Name = "controlHkPitchBar";
            this.controlHkPitchBar.Size = new System.Drawing.Size(133, 25);
            this.controlHkPitchBar.TabIndex = 47;
            this.controlHkPitchBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.controlHkPitchBar.Value = 1;
            this.controlHkPitchBar.Scroll += new System.EventHandler(this.PitchBar_Scroll);
            // 
            // controlHkPitchByLbl
            // 
            this.controlHkPitchByLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkPitchByLbl.AutoSize = true;
            this.controlHkPitchByLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkPitchByLbl.Location = new System.Drawing.Point(22, 11);
            this.controlHkPitchByLbl.Name = "controlHkPitchByLbl";
            this.controlHkPitchByLbl.Size = new System.Drawing.Size(23, 16);
            this.controlHkPitchByLbl.TabIndex = 1;
            this.controlHkPitchByLbl.Text = "by";
            // 
            // controlHkKeyPressPanel
            // 
            this.controlHkKeyPressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkKeyPressPanel.Controls.Add(this.controlHkKeyToPressTxtBox);
            this.controlHkKeyPressPanel.Controls.Add(this.controlHkKeyToPressLbl);
            this.controlHkKeyPressPanel.Location = new System.Drawing.Point(2, 2);
            this.controlHkKeyPressPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlHkKeyPressPanel.Name = "controlHkKeyPressPanel";
            this.controlHkKeyPressPanel.Size = new System.Drawing.Size(190, 50);
            this.controlHkKeyPressPanel.TabIndex = 45;
            this.controlHkKeyPressPanel.Visible = false;
            // 
            // controlHkKeyToPressTxtBox
            // 
            this.controlHkKeyToPressTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkKeyToPressTxtBox.Location = new System.Drawing.Point(99, 11);
            this.controlHkKeyToPressTxtBox.Name = "controlHkKeyToPressTxtBox";
            this.controlHkKeyToPressTxtBox.Size = new System.Drawing.Size(82, 20);
            this.controlHkKeyToPressTxtBox.TabIndex = 2;
            this.controlHkKeyToPressTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyInput);
            // 
            // controlHkKeyToPressLbl
            // 
            this.controlHkKeyToPressLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkKeyToPressLbl.AutoSize = true;
            this.controlHkKeyToPressLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlHkKeyToPressLbl.Location = new System.Drawing.Point(1, 11);
            this.controlHkKeyToPressLbl.Name = "controlHkKeyToPressLbl";
            this.controlHkKeyToPressLbl.Size = new System.Drawing.Size(80, 16);
            this.controlHkKeyToPressLbl.TabIndex = 1;
            this.controlHkKeyToPressLbl.Text = "Key to hold :";
            // 
            // controlHkKeyTxtBox
            // 
            this.controlHkKeyTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkKeyTxtBox.Location = new System.Drawing.Point(48, 3);
            this.controlHkKeyTxtBox.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.controlHkKeyTxtBox.Name = "controlHkKeyTxtBox";
            this.controlHkKeyTxtBox.Size = new System.Drawing.Size(81, 20);
            this.controlHkKeyTxtBox.TabIndex = 39;
            this.controlHkKeyTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyInput);
            // 
            // controlHkRoleCmbBox
            // 
            this.controlHkRoleCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHkRoleCmbBox.FormattingEnabled = true;
            this.controlHkRoleCmbBox.Location = new System.Drawing.Point(207, 3);
            this.controlHkRoleCmbBox.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.controlHkRoleCmbBox.Name = "controlHkRoleCmbBox";
            this.controlHkRoleCmbBox.Size = new System.Drawing.Size(120, 21);
            this.controlHkRoleCmbBox.TabIndex = 41;
            this.controlHkRoleCmbBox.SelectionChangeCommitted += new System.EventHandler(this.ControlHkRoleCmbBox_SelectionChangeCommitted);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 422);
            this.Controls.Add(this.mainTabCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(781, 460);
            this.Name = "mainForm";
            this.Text = "SoundBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Click += new System.EventHandler(this.SaveAsFileSubMenuItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.audioHkDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioHkVolumeBar)).EndInit();
            this.mainTabCtrl.ResumeLayout(false);
            this.audioHkTab.ResumeLayout(false);
            this.audioTabGrpBox.ResumeLayout(false);
            this.audioTabGrpBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.audioHkVolumePanel.ResumeLayout(false);
            this.audioHkVolumePanel.PerformLayout();
            this.controlHkFadingTab.ResumeLayout(false);
            this.controlHkFadingGrpBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlHkDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fadingDataGrid)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fadeInBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeOutBar)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.controlHkFwdBwdPanel.ResumeLayout(false);
            this.controlHkFwdBwdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkFwdBwdValueNmrc)).EndInit();
            this.controlHkVolumeTempoPanel.ResumeLayout(false);
            this.controlHkVolumeTempoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkVolumeBar)).EndInit();
            this.controlHkPitchPanel.ResumeLayout(false);
            this.controlHkPitchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlHkPitchBar)).EndInit();
            this.controlHkKeyPressPanel.ResumeLayout(false);
            this.controlHkKeyPressPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox audioHkDevicesCmbBox;
        private System.Windows.Forms.DataGridView audioHkDataGrid;
        private System.Windows.Forms.Button audioHkAddNewBtn;
        private System.Windows.Forms.TextBox audioHkFilesPathTxtBox;
        private System.Windows.Forms.Button audioHkBrowseBtn;
        private System.Windows.Forms.OpenFileDialog browseDialog;
        private System.Windows.Forms.Button audioHkRemoveBtn;
        private System.Windows.Forms.TextBox audioHkTxtBox;
        private System.Windows.Forms.Label audioHkKeyLbl;
        private System.Windows.Forms.Label audioHkNameLbl;
        private System.Windows.Forms.TextBox audioHkNameTxtBox;
        private System.Windows.Forms.Label audioHkAudioDeviceLbl;
        private System.Windows.Forms.Label audioHkStartAtLbl;
        private System.Windows.Forms.DateTimePicker audioHkStartAtTimePicker;
        private System.Windows.Forms.TrackBar audioHkVolumeBar;
        private System.Windows.Forms.Label audioHkVolumeLbl;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem fileMenuItem;
        private System.Windows.Forms.MenuItem saveFileSubMenuItem;
        private System.Windows.Forms.MenuItem saveAsFileSubMenuItem;
        private System.Windows.Forms.MenuItem alwaysSaveOnClosingFileSubMenuItem;
        private System.Windows.Forms.MenuItem exportAsZipFileSubMenuItem;
        private System.Windows.Forms.MenuItem loadFileSubMenuItem;
        private System.Windows.Forms.MenuItem optionsMenuItem;
        private System.Windows.Forms.MenuItem helpMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem exitFileSubMenuItem;
        private Microsoft.VisualBasic.PowerPacks.DataRepeaterItem ItemTemplate;
        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage controlHkFadingTab;
        private System.Windows.Forms.TabPage audioHkTab;
        private System.Windows.Forms.Label volumeValueLbl;
        private System.Windows.Forms.Label separatorLineLbl;
        private System.Windows.Forms.GroupBox audioTabGrpBox;
        private System.Windows.Forms.GroupBox controlHkFadingGrpBox;
        private System.Windows.Forms.Label fadingHeaderLbl;
        private System.Windows.Forms.Label controlHkHeaderLbl;
        private System.Windows.Forms.Button fadingApplyBtn;
        private System.Windows.Forms.TrackBar fadeOutBar;
        private System.Windows.Forms.TrackBar fadeInBar;
        private System.Windows.Forms.Label fadingOutLbl;
        private System.Windows.Forms.Label fadingInLbl;
        private System.Windows.Forms.DataGridView fadingDataGrid;
        private System.Windows.Forms.DataGridView controlHkDataGrid;
        private System.Windows.Forms.ComboBox controlHkRoleCmbBox;
        private System.Windows.Forms.Label controlHkActionLbl;
        private System.Windows.Forms.TextBox controlHkKeyTxtBox;
        private System.Windows.Forms.Label controlHkKeyLbl;
        private System.Windows.Forms.Button controlHkRemoveBtn;
        private System.Windows.Forms.Button controlHkAddNewBtn;
        private System.Windows.Forms.Panel controlHkFwdBwdPanel;
        private System.Windows.Forms.Label controlHkFwdBwdByLbl;
        private System.Windows.Forms.Label controlHkFwdBwdSecondsLbl;
        private System.Windows.Forms.Panel controlHkKeyPressPanel;
        private System.Windows.Forms.TextBox controlHkKeyToPressTxtBox;
        private System.Windows.Forms.Label controlHkKeyToPressLbl;
        private System.Windows.Forms.Panel controlHkVolumeTempoPanel;
        private System.Windows.Forms.Label volumeByLbl;
        private System.Windows.Forms.Label volumePanelValueLbl;
        private System.Windows.Forms.TrackBar controlHkVolumeBar;
        private System.Windows.Forms.Panel controlHkPitchPanel;
        private System.Windows.Forms.Label controlHkPitchPanelValueLbl;
        private System.Windows.Forms.TrackBar controlHkPitchBar;
        private System.Windows.Forms.Label controlHkPitchByLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel audioHkVolumePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDisplayFadeCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNameFadeCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn fadeInCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn fadeOutCln;
        private System.Windows.Forms.MenuItem aboutSubMenuItem;
        private System.Windows.Forms.NumericUpDown controlHkFwdBwdValueNmrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctrlKeyCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctrlIdCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioNameCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioKeyCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioShortFilesDisplayCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioFullFilesDisplayCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioFilesHiddenCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioStartCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioVolumeCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioIdCln;
        private System.Windows.Forms.MenuItem newFileSubMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}

