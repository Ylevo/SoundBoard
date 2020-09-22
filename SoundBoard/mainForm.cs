using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using NAudio.Wave;
using System.IO;
using SoundBoard.Helpers;
using SoundBoard.Persistence;
using SoundBoard.Utilities;
using SoundBoard.Core;
using SoundBoard.Logic;


namespace SoundBoard
{

    public partial class mainForm : Form
    {
        private HotkeyLogic hkLogic;
        private XmlLogic xmlLogic;
        private string dataGridCellValueTemp;
        private string currentXmlFilePath = "";
        private bool volumeTest = false;
        private DirtyTracker dirtyTracker;
        private Dictionary<string, ControlRoles> friendlyActionsNames;
        private KeyEventHandler dataGridKeyEdit = null;
        private KeyPressEventHandler dataGridKeyPressEdit = null;
        private KeysTranslater keysTranslater;

        public mainForm(bool isFirstInstance)
        {
            Init(isFirstInstance);
        }

        private void Init(bool isFirstInstance)
        {
            InitializeComponent();

            var devices = DirectSoundOut.Devices;
            hkLogic = new HotkeyLogic(this);
            xmlLogic = new XmlLogic(this, hkLogic);
            keysTranslater = new KeysTranslater();

            audioHkDevicesCmbBox.DataSource = devices;
            audioHkDevicesCmbBox.DisplayMember = "Description";
            audioHkDevicesCmbBox.ValueMember = "Guid";
            try
            {
                audioHkDevicesCmbBox.SelectedValue = new Guid(AppDataManager.getCfgParameter(AppDataNames.DefaultAudioOutputDevice));
            }
            catch (FormatException) { }
            if (audioHkDevicesCmbBox.SelectedValue == null) { audioHkDevicesCmbBox.SelectedValue = devices.FirstOrDefault().Guid; }
            DataGridViewComboBoxColumn audioDeviceCln = new DataGridViewComboBoxColumn();
            audioDeviceCln.Name = "audioDeviceCln";
            audioDeviceCln.DataPropertyName = "Guid";
            audioDeviceCln.HeaderText = "Audio Output";
            audioDeviceCln.Width = 220;
            audioDeviceCln.DataSource = devices.ToList();
            audioDeviceCln.ValueMember = "Guid";
            audioDeviceCln.DisplayMember = "Description";
            audioHkDataGrid.Columns.Add(audioDeviceCln);
            audioHkStartAtTimePicker.Format = DateTimePickerFormat.Custom;
            audioHkStartAtTimePicker.CustomFormat = "mm:ss";
            audioHkStartAtTimePicker.ShowUpDown = true;

            friendlyActionsNames = new Dictionary<string, ControlRoles>()
            {
                { "Forward", ControlRoles.Forward },
                { "Backward", ControlRoles.Backward },
                { "Play/Pause", ControlRoles.PlayPause },
                { "Stop", ControlRoles.Stop },
                { "Increase Volume", ControlRoles.IncreaseVolume },
                { "Decrease Volume", ControlRoles.DecreaseVolume },
                { "Mute Sound", ControlRoles.Mute },
                { "Increase Speed", ControlRoles.IncreaseSpeed },
                { "Decrease Speed", ControlRoles.DecreaseSpeed },
                { "Increase Tempo", ControlRoles.IncreaseTempo },
                { "Decrease Tempo", ControlRoles.DecreaseTempo },
                { "Increase Pitch", ControlRoles.IncreasePitch },
                { "Decrease Pitch", ControlRoles.DecreasePitch },
                { "Reset Music Rates", ControlRoles.ResetRates },
                { "Hold Down Key", ControlRoles.HoldDownKey },
                { "Disable/Enable Hotkeys", ControlRoles.MasterHotkey },
                { "Auto Repeat Track", ControlRoles.AutoRepeat }
            };
            controlHkRoleCmbBox.DataSource = new BindingSource(friendlyActionsNames, null);
            controlHkRoleCmbBox.DisplayMember = "Key";
            controlHkRoleCmbBox.ValueMember = "Value";

            fadingDataGrid.Rows.Add("Stop", "Stop", "0 ms", "0 ms");
            fadingDataGrid.Rows.Add("Play/Pause", "PlayPause", "0 ms", "0 ms");
            fadingDataGrid.Rows.Add("Start New Sound", "StartSound", "0 ms", "0 ms");
            fadingDataGrid.Rows.Add("Forward/Backward", "ForwardBackward", "0 ms", "0 ms");

            alwaysSaveOnClosingFileSubMenuItem.Checked = AppDataManager.getCfgParameter(AppDataNames.SaveOnClosing) == "1";
            UpdateResetMusicRates(AppDataManager.getCfgParameter(AppDataNames.ResetRatesOnNewPlay) == "1");
            UpdateResetAutoRepeat(AppDataManager.getCfgParameter(AppDataNames.ResetAutoRepeatOnNewPlay) == "1");
            UpdateAudioLatency(AppDataManager.getCfgParameter(AppDataNames.AudioLatency));
            UpdateTracksOrder(AppDataManager.getCfgParameter(AppDataNames.TracksPlayOrder));
            UpdateNotifications(AppDataManager.getCfgParameter(AppDataNames.EnableNotifications) == "1");
            if (isFirstInstance == true && AppDataManager.getCfgParameter(AppDataNames.LoadXmlOnStartUp) == "1")
            {
                LoadXml(AppDataManager.getCfgParameter(AppDataNames.DefaultXmlFilePath));
                currentXmlFilePath = AppDataManager.getCfgParameter(AppDataNames.DefaultXmlFilePath);
            }
            else
            {
                // initialized otherwise in LoadXml
                InitDirtyTracker();
            }
            if (AppDataManager.getCfgParameter(AppDataNames.DisplayTracksFullFilepaths) == "1")
            {
                UpdateTracksFilepathsDisplay(true);
            }
            SoundPlayer.Instance.Notificator.Click += delegate { ShowMe(); };
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            TopMost = true;
            TopMost = false;
        }

        private void LoadXml(string xmlFilePath)
        {
            List<string> errorsList;
            try
            {
                errorsList = xmlLogic.LoadHotkeysXml(xmlFilePath);
                currentXmlFilePath = xmlFilePath;
                if (errorsList.Count > 0)
                {
                    MessageBox.Show(String.Join("\n", errorsList.ToArray()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.MessageToUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorHelper.XmlLoad.UnexpectedErrorException, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.NewLog(ex, "Unexpected error during xml loading.");
            }
            finally
            {
                InitDirtyTracker();
            }
        }

        private bool SaveToXml(bool relativePaths = false)
        {
            bool saved = false;
            try
            {
                if (currentXmlFilePath == "")
                {
                    saved = SaveAsXml();
                }
                else 
                {
                    xmlLogic.SaveHotkeysToXml(currentXmlFilePath, relativePaths);
                    InitDirtyTracker();
                    saved = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorHelper.XmlSave.UnexpectedErrorException, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.NewLog(ex, "Unexpected exception during xml saving.");
            }
            return saved;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (AppDataManager.getCfgParameter(AppDataNames.SaveOnClosing) == "1")
                {
                    SaveToXml();
                }
                else 
                {
                    if (AppDataManager.getCfgParameter(AppDataNames.DisableDirtyTracker) == "0" && dirtyTracker.isFormDirty())
                    {
                        DialogResult answer = MessageBox.Show("Save hotkeys?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        switch (answer)
                        {
                            case DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                            case DialogResult.Yes:
                                SaveToXml();
                                break;
                        }
                    }
                }
                if (!e.Cancel)
                {
                    AppDataManager.setCfgParameter(AppDataNames.DefaultAudioOutputDevice, audioHkDevicesCmbBox.SelectedValue.ToString());
                    AppDataManager.saveCfg();
                    SoundPlayer.Instance.Notificator.Dispose();
                }
            }
            catch (Exception ex)
            {
                Logger.NewLog(ex, "Exception when closing the form");
                e.Cancel = false;
            }
        }

        private void AudioHkBrowseBtn_Click(object sender, EventArgs e)
        {
            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                audioHkFilesPathTxtBox.Text = String.Join("*", browseDialog.FileNames);
                browseDialog.InitialDirectory = Path.GetDirectoryName(browseDialog.FileNames.First());
            }
        }

        private void AudioHkAddNewBtn_Click(object sender, EventArgs e)
        {
            string key = "", files = "", name = "";
            int hkId, startingTime; float volume;
            Guid device = Guid.Empty;
            try
            {
                key = audioHkTxtBox.Text;
                files = audioHkFilesPathTxtBox.Text;
                name = audioHkNameTxtBox.Text;
                if (files == "")
                {
                    throw new NoFileSelectedException();
                }
                startingTime = audioHkStartAtTimePicker.Value.Second + (audioHkStartAtTimePicker.Value.Minute * 60);
                volume = (float)audioHkVolumeBar.Value / 100;
                device = (Guid)audioHkDevicesCmbBox.SelectedValue;
                hkId = hkLogic.AddNewAudioHotkey(key, files, volume, device, startingTime, name);
                AudioHkDataGridAddLine(key, files, volume, hkId, device, startingTime, name);
                audioHkTxtBox.Text = "";
                audioHkFilesPathTxtBox.Text = "";
                audioHkNameTxtBox.Text = "";
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.MessageToUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorAddHotkey, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.NewLog(ex, string.Format("Unexpected exception in add new hotkey. Key : {0} | Files : {1} | Device : {2}.",  key, files, device.ToString()));
            }
        }

        private void DataGridHkRemove(object sender, EventArgs e)
        {
            var datagrid = sender as DataGridView;
            string clnName = datagrid.Name == "audioHkDataGrid" ? "audioIdCln" : "ctrlIdCln";
            if (datagrid.CurrentRow != null)
            {
                try
                {
                    int hotkeyId = (int)datagrid.CurrentRow.Cells[clnName].Value;
                    hkLogic.RemoveHotkey(hotkeyId);
                }
                catch (Exception ex)
                {
                    Logger.NewLog(ex, "Exception when removing an hotkey.");
                }
                finally
                {
                    datagrid.Rows.Remove(datagrid.CurrentRow);
                }
            }
        }

        private void HotkeyInput(object sender, KeyEventArgs e)
        {
            string hotkeyString;
            e.SuppressKeyPress = true;
            TextBox keyTxtBox = sender as TextBox;
            Keys keyCode = e.KeyCode;
            if (keyCode != Keys.ControlKey && keyCode != Keys.Menu && keyCode != Keys.ShiftKey)
            {
                if (keyCode == Keys.Escape || keyCode == Keys.LWin || keyCode == Keys.RWin)
                {
                    keyTxtBox.Text = "";
                }
                else
                {
                    if (keyTxtBox.Name == "keyToPressTxtBox")
                    {
                        hotkeyString = keysTranslater.KeyCodeToString(keyCode);
                    }
                    else
                    {
                        hotkeyString = (e.Control ? "CTRL+" : "") + (e.Alt ? "ALT+" : "") + (e.Shift ? "SHIFT+" : "") + keysTranslater.KeyCodeToString(keyCode);
                    }
                    foreach (TextBox txtBox in this.GetAll(typeof(TextBox)))
                    {
                        if (txtBox.Text == hotkeyString)
                        {
                            txtBox.Text = "";
                        }
                    }
                    keyTxtBox.Text = hotkeyString;
                }
            }
        }

        private void HotkeysDataGrids_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bool activateKeyInput = false;
            switch(((DataGridView)sender).CurrentCell.OwningColumn.Name)
            {
                case "audioKeyCln":
                case "ctrlKeyCln":
                    activateKeyInput = true;
                    break;
            }
            DataGridKeyCellInputHandler(sender, e, activateKeyInput);
        }

        private void DataGridKeyCellInputHandler(object sender, DataGridViewEditingControlShowingEventArgs e, bool activateKeyInput)
        {
            if (activateKeyInput)
            {
                if (dataGridKeyEdit == null)
                {
                    dataGridKeyEdit = new KeyEventHandler(HotkeyInput);
                    dataGridKeyPressEdit = new KeyPressEventHandler(delegate (object pressSender, KeyPressEventArgs pressEvent) { pressEvent.Handled = true; });
                    e.Control.KeyDown += dataGridKeyEdit;
                    e.Control.KeyPress += dataGridKeyPressEdit;
                }
            }
            else
            {
                if (dataGridKeyEdit != null)
                {
                    e.Control.KeyDown -= dataGridKeyEdit;
                    e.Control.KeyPress -= dataGridKeyPressEdit;
                    dataGridKeyEdit = null;
                    dataGridKeyPressEdit = null;
                }
            }
        }

        private void HotkeysDataGrids_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            try
            {
                int hkId = (int)dataGrid.CurrentRow.Cells.Cast<DataGridViewCell>().First(r => r.OwningColumn.Name.Substring(r.OwningColumn.Name.Length - 5) == "IdCln").Value;
                switch (dataGrid.Columns[e.ColumnIndex].Name)
                {
                    case "audioNameCln":
                        if (dataGrid.CurrentCell.Value == null)
                        {
                            dataGrid.CurrentCell.Value = dataGridCellValueTemp;
                        }
                        else
                        {
                            hkLogic.ModifyAudioHotkey(hkId, newName: dataGrid.CurrentCell.Value.ToString());
                        }
                        break;
                    case "audioKeyCln":
                    case "ctrlKeyCln":
                        string oldKey = dataGridCellValueTemp;
                        string newKey = dataGrid.CurrentCell.Value?.ToString().Trim();
                        if (newKey == null || oldKey == newKey || newKey == "")
                        {
                            dataGrid.CurrentCell.Value = oldKey;
                            break;
                        }
                        hkLogic.ModifyHotkey(hkId, newKey);
                        break;
                    case "audioVolumeCln":
                        string newVolumeStr = dataGrid.CurrentCell.Value?.ToString().Trim();
                        float newVolume = -1;
                        if (newVolumeStr == null) { throw new InvalidVolumeValueException(newVolumeStr); }
                        if (newVolumeStr.Contains('%'))
                        {
                            newVolumeStr = newVolumeStr.Substring(0, newVolumeStr.IndexOf('%'));
                        }
                        if (newVolumeStr.Length < 4 && float.TryParse(newVolumeStr, out newVolume))
                        {
                            hkLogic.ModifyAudioHotkey(hkId, newVolume: newVolume);
                            dataGrid.CurrentCell.Value = newVolume + "%";
                        }
                        else
                        {
                            throw new InvalidVolumeValueException(newVolumeStr);
                        }
                        break;
                    case "audioStartCln":
                        string newStartValueStr = dataGrid.CurrentCell.Value?.ToString().Trim();
                        TimeSpan result;
                        if (newStartValueStr != null && TimeSpan.TryParseExact(newStartValueStr, new string[2] { "m\\:ss", "mm\\:ss" }, CultureInfo.InvariantCulture, TimeSpanStyles.None, out result))
                        {
                            hkLogic.ModifyAudioHotkey(hkId, newStartingTime: (int)result.TotalSeconds);
                        }
                        else
                        {
                            throw new InvalidStartingTimeValueException(newStartValueStr);
                        }
                        break;
                }
            }
            catch (CustomException ex)
            {
                dataGrid.CurrentCell.Value = dataGridCellValueTemp;
                MessageBox.Show(ex.MessageToUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Logger.NewLog(ex, "Exception during data grid editing.");
                MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorDataGridEdit, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataGridHkRemove(sender, e);
            }
        }

        private void AudioHkDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (audioHkDataGrid.Columns[e.ColumnIndex].Name == "audioShortFilesDisplayCln" || audioHkDataGrid.Columns[e.ColumnIndex].Name == "audioFullFilesDisplayCln")
            {
                try
                {
                    string newFiles;
                    int hkId;
                    DataGridViewRow currentRow = audioHkDataGrid.Rows[e.RowIndex];
                    if (browseDialog.ShowDialog() == DialogResult.OK)
                    {
                        newFiles = String.Join("*", browseDialog.FileNames);
                        currentRow.Cells["audioFilesHiddenCln"].Value = newFiles;
                        currentRow.Cells["audioFullFilesDisplayCln"].Value = newFiles.Replace('*', ',');
                        currentRow.Cells["audioShortFilesDisplayCln"].Value = GetConcatedFilenames(newFiles);
                        hkId = (int)currentRow.Cells["audioIdCln"].Value;
                        hkLogic.ModifyAudioHotkey(hkId, newFiles: newFiles);
                        browseDialog.InitialDirectory = Path.GetDirectoryName(browseDialog.FileNames.First());
                    }
                }
                catch (Exception ex)
                {
                    Logger.NewLog(ex, "Exception when changing played files in audioHk data grid.");
                    MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorDataGridEdit, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataGridHkRemove(sender, e);
                }
            }
        }
        
        private void HotkeysDataGrids_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string cellClnName = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            if (cellClnName == "audioKeyCln" || cellClnName == "ctrlKeyCln" || cellClnName == "audioNameCln" || cellClnName == "audioVolumeCln" || cellClnName == "audioStartCln")
            {
                dataGridCellValueTemp = ((DataGridView)sender).CurrentCell.Value.ToString();
            }
        }

        private void AudioHkDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Easing the combobox cells editing, requiring only one click to enter edit mode.
            var datagridview = sender as DataGridView;
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void AudioHkDataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (audioHkDataGrid.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                audioHkDataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void AudioHkDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (audioHkDataGrid.Columns[e.ColumnIndex].Name == "audioDeviceCln")
            {
                try
                {
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)audioHkDataGrid.Rows[e.RowIndex].Cells["audioDeviceCln"];
                    if (cb.Value != null)
                    {
                        string newDevice = cb.Value.ToString();
                        int hkId = (int)audioHkDataGrid.Rows[e.RowIndex].Cells["audioIdCln"].Value;
                        hkLogic.ModifyAudioHotkey(hkId, newAudioDevice: newDevice);
                    }
                }
                catch (Exception ex)
                {
                    Logger.NewLog(ex, "Exception when changing audio output in audioHk data grid.");
                    MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorDataGridEdit, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataGridHkRemove(sender, e);
                }
            }
        }

        private void AudioHkVolumeBar_Scroll(object sender, EventArgs e)
        {
            if (volumeTest)
            {
                SoundPlayer.Instance.ChangeVolume((float)audioHkVolumeBar.Value / 100);
            }
            volumeValueLbl.Text = audioHkVolumeBar.Value.ToString() + "%"; ;
        }

        private void AudioHkVolumeBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (audioHkFilesPathTxtBox.Text != "")
            {
                SoundPlayer.Instance.StopSound();
                int startTime =  audioHkStartAtTimePicker.Value.Second + (audioHkStartAtTimePicker.Value.Minute * 60);
                SoundPlayer.Instance.PlaySound(audioHkFilesPathTxtBox.Text, (Guid)audioHkDevicesCmbBox.SelectedValue, startTime, (float)audioHkVolumeBar.Value / 100);
                volumeTest = true;
            }
        }

        private void AudioHkVolumeBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (volumeTest)
            {
                SoundPlayer.Instance.CloseWaveOut();
                volumeTest = false;
            }
        }

        private void NewFileSubMenuItem_Click(object sender, EventArgs e)
        {
            if (AppDataManager.getCfgParameter(AppDataNames.DisableDirtyTracker) == "0" && dirtyTracker.isFormDirty())
            {
                DialogResult answer = MessageBox.Show("Save hotkeys?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (answer)
                {
                    case DialogResult.Yes:
                        if (!SaveToXml())
                        {
                            return;
                        }
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            ResetHotkeysAndOptions();
            InitDirtyTracker();
            currentXmlFilePath = "";
        }

        private void AlwaysSaveOnClosingFileSubMenuItem_Click(object sender, EventArgs e)
        {
            ((MenuItem)sender).Checked = !((MenuItem)sender).Checked;
            AppDataManager.setCfgParameter(AppDataNames.SaveOnClosing, ((MenuItem)sender).Checked ? "1" : "0");
        }

        private void SaveFileSubMenuItem_Click(object sender, EventArgs e)
        {
            SaveToXml();
        }

        private void SaveAsXmlEvent(object sender, EventArgs e)
        {
            SaveAsXml();
        }

        private bool SaveAsXml()
        {
            bool saved = true;
            SaveFileDialog saveXmlDialog = new SaveFileDialog();
            saveXmlDialog.AddExtension = true;
            saveXmlDialog.DefaultExt = ".xml";
            saveXmlDialog.Filter = "XML|*.xml";
            saveXmlDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveXmlDialog.FileName = "Hotkeys.xml";
            if (saveXmlDialog.ShowDialog() == DialogResult.OK)
            {
                currentXmlFilePath = saveXmlDialog.FileName;
                SaveToXml();
            }
            else
            {
                saved = false;
            }
            return saved;
        }

        private void ExportAsZipFileSubMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportZipDialog = new SaveFileDialog();
            exportZipDialog.AddExtension = true;
            exportZipDialog.DefaultExt = ".zip";
            exportZipDialog.Filter = "ZIP|*.zip";
            exportZipDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            exportZipDialog.RestoreDirectory = true;
            if (exportZipDialog.ShowDialog() == DialogResult.OK)
            {
                string zipFilePath = exportZipDialog.FileName;
                string folderToZip = Path.Combine(Path.GetDirectoryName(zipFilePath), "tmpSoundBoardZipping");
                currentXmlFilePath = Path.Combine(folderToZip, "Hotkeys.xml");
                try
                {
                    xmlLogic.ExportHotkeysAsZip(zipFilePath, folderToZip);
                }
                catch (Exception ex)
                {
                    Logger.NewLog(ex, "Zip export failed.");
                    MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorExportZip, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Directory.Delete(folderToZip, true);
                }
            }
        }

        private void LoadFileSubMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openXml = new OpenFileDialog();
            openXml.Filter = "XML|*.xml";
            openXml.Multiselect = false;
            if (openXml.ShowDialog() == DialogResult.OK)
            {
                ResetHotkeysAndOptions();
                LoadXml(openXml.FileName);
            }
        }

        private void ExitFileSubMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OptionsMenuItem_Click(object sender, EventArgs e)
        {
            using (var optForm = new optionsForm(this))
            {
                optForm.ShowDialog();
            }
        }

        private void ControlHkAddHkBtn_Click(object sender, EventArgs e)
        {
            string key = "", friendlyActionName = "", displayedValue = "", keyToPress = "";
            float flowChangeValue = 0;
            int hotkeyId;
            ControlRoles role;
            try
            {
                key = controlHkKeyTxtBox.Text;
                friendlyActionName = controlHkRoleCmbBox.Text;
                role = (ControlRoles)controlHkRoleCmbBox.SelectedValue;
                switch (role)
                {
                    case ControlRoles.Forward:
                    case ControlRoles.Backward:
                        flowChangeValue = (int)controlHkFwdBwdValueNmrc.Value;
                        break;
                    case ControlRoles.IncreaseVolume:
                    case ControlRoles.DecreaseVolume:
                        flowChangeValue = controlHkVolumeBar.Value;
                        break;
                    case ControlRoles.HoldDownKey:
                        keyToPress = controlHkKeyToPressTxtBox.Text;
                        break;
                    case ControlRoles.IncreaseTempo:
                    case ControlRoles.DecreaseTempo:
                    case ControlRoles.IncreaseSpeed:
                    case ControlRoles.DecreaseSpeed:
                        flowChangeValue = controlHkVolumeBar.Value;
                        break;
                    case ControlRoles.IncreasePitch:
                    case ControlRoles.DecreasePitch:
                        flowChangeValue = controlHkPitchBar.Value;
                        break;
                }
                hotkeyId = hkLogic.AddNewControlHotkey(key, role, out displayedValue, keyToPress, flowChangeValue);
                ControlHkDataGridAddLine(key, role, displayedValue, hotkeyId);
                controlHkKeyTxtBox.Text = "";
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.MessageToUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorHelper.UnexpectedErrorAddHotkey, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.NewLog(ex, "Exception when adding a control hotkey.");
            }
        }

        private void ControlHkRoleCmbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ControlRoles ctrlRole = (ControlRoles)controlHkRoleCmbBox.SelectedValue;
            switch (ctrlRole)
            {
                case ControlRoles.Forward:
                case ControlRoles.Backward:
                    controlHkKeyPressPanel.Visible = false;
                    controlHkVolumeTempoPanel.Visible = false;
                    controlHkFwdBwdPanel.Visible = true;
                    controlHkPitchPanel.Visible = false;
                    break;
                case ControlRoles.IncreaseVolume:
                case ControlRoles.DecreaseVolume:
                case ControlRoles.IncreaseTempo:
                case ControlRoles.DecreaseTempo:
                case ControlRoles.IncreaseSpeed:
                case ControlRoles.DecreaseSpeed:
                    controlHkKeyPressPanel.Visible = false;
                    controlHkVolumeTempoPanel.Visible = true;
                    controlHkFwdBwdPanel.Visible = false;
                    controlHkPitchPanel.Visible = false;
                    break;
                case ControlRoles.IncreasePitch:
                case ControlRoles.DecreasePitch:
                    controlHkKeyPressPanel.Visible = false;
                    controlHkVolumeTempoPanel.Visible = false;
                    controlHkFwdBwdPanel.Visible = false;
                    controlHkPitchPanel.Visible = true;
                    break;
                case ControlRoles.HoldDownKey:
                    controlHkKeyPressPanel.Visible = true;
                    controlHkVolumeTempoPanel.Visible = false;
                    controlHkFwdBwdPanel.Visible = false;
                    controlHkPitchPanel.Visible = false;
                    break;
                case ControlRoles.MasterHotkey:
                case ControlRoles.Stop:
                case ControlRoles.PlayPause:
                case ControlRoles.Mute:
                case ControlRoles.AutoRepeat:
                    controlHkKeyPressPanel.Visible = false;
                    controlHkVolumeTempoPanel.Visible = false;
                    controlHkFwdBwdPanel.Visible = false;
                    controlHkPitchPanel.Visible = false;
                    break;
            }
        }

        private void ControlHkVolumeBar_Scroll(object sender, EventArgs e)
        {
            volumePanelValueLbl.Text = controlHkVolumeBar.Value.ToString() + "%";
        }

        private void HkRemoveBtn_Click(object sender, EventArgs e)
        {
            var buttonClicked = sender as Button;
            DataGridView dataGrid = buttonClicked.Name == "audioHkRemoveBtn" ? audioHkDataGrid : controlHkDataGrid;
            DataGridHkRemove(dataGrid, e);
        }

        private void FadeInBar_Scroll(object sender, EventArgs e)
        {
            fadingDataGrid.CurrentRow.Cells["fadeInCln"].Value = ((TrackBar)sender).Value + " ms";
        }

        private void FadeOutBar_Scroll(object sender, EventArgs e)
        {
            fadingDataGrid.CurrentRow.Cells["fadeOutCln"].Value = ((TrackBar)sender).Value + " ms";
        }

        private void FadingDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            string actionName = fadingDataGrid.CurrentRow.Cells["actionNameFadeCln"].Value.ToString();
            string fadeOutValue, fadeInValue;
            switch(actionName)
            {
                case "Stop":
                    fadeInBar.Enabled = false;
                    fadeOutValue = fadingDataGrid.CurrentRow.Cells["fadeOutCln"].Value.ToString();
                    fadeOutBar.Value = int.Parse(fadeOutValue.Substring(0, fadeOutValue.Length - 3));
                    fadeInBar.Value = 0;
                    break;
                case "StartSound":
                case "ForwardBackward":
                case "PlayPause":
                    fadeInBar.Enabled = true;
                    fadeOutValue = fadingDataGrid.CurrentRow.Cells["fadeOutCln"].Value.ToString();
                    fadeOutBar.Value = int.Parse(fadeOutValue.Substring(0, fadeOutValue.Length - 3));
                    fadeInValue = fadingDataGrid.CurrentRow.Cells["fadeInCln"].Value.ToString();
                    fadeInBar.Value = int.Parse(fadeInValue.Substring(0, fadeInValue.Length - 3));
                    break;
            }
        }

        private void FadingApplyBtn_Click(object sender, EventArgs e)
        {
            string fadingAction, fadeValue;
            foreach(DataGridViewRow row in fadingDataGrid.Rows)
            {
                fadingAction = row.Cells["actionNameFadeCln"].Value.ToString();
                fadeValue = row.Cells["fadeInCln"].Value.ToString();
                fadeValue = fadeValue.Substring(0, fadeValue.Length - 3);
                SoundPlayer.Instance.ChangeFadingValue((FadingActions)Enum.Parse(typeof(FadingActions), fadingAction), "fadeIn", int.Parse(fadeValue));
                fadeValue = row.Cells["fadeOutCln"].Value.ToString();
                fadeValue = fadeValue.Substring(0, fadeValue.Length - 3);
                SoundPlayer.Instance.ChangeFadingValue((FadingActions)Enum.Parse(typeof(FadingActions), fadingAction), "fadeOut", int.Parse(fadeValue));
            }
        }

        private void PitchBar_Scroll(object sender, EventArgs e)
        {
            controlHkPitchPanelValueLbl.Text = "+" + float.Parse(controlHkPitchBar.Value.ToString()) / 10 ;
        }

        private void FadingDataGrid_SizeChanged(object sender, EventArgs e)
        {
            int defaultSize = 173;
            int difference = fadingDataGrid.Size.Height - defaultSize;
            foreach (DataGridViewRow row in fadingDataGrid.Rows)
            {
                row.Height = (int)Math.Round( (double)(38 + (difference/4)) );
            }
        }

        private void AboutSubMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new aboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void InitDirtyTracker()
        {
            dirtyTracker = new DirtyTracker(audioHkDataGrid, controlHkDataGrid, fadingDataGrid);
        }

        private string GetConcatedFilenames(string paths)
        {
            string filenames = "";
            foreach (string file in paths.Split('*'))
            {
                filenames += file.Split('\\').Last() + ",\n";
            }
            return filenames.Substring(0, filenames.Length - 2);
        }

        private void ResetHotkeysAndOptions()
        {
            hkLogic.ClearHotkeysList();
            audioHkDataGrid.Rows.Clear();
            controlHkDataGrid.Rows.Clear();
        }

        public void UpdateTracksOrder(string value)
        {
            TracksOrders order;
            SoundPlayer.Instance.TracksPlayOrder = Enum.TryParse(value, out order) ? order : TracksOrders.Default;
        }  

        public void UpdateResetMusicRates(bool value)
        {
            SoundPlayer.Instance.ResetMusicRates = value;
        }

        public void UpdateResetAutoRepeat(bool value)
        {
            SoundPlayer.Instance.ResetAutoRepeat = value;
        }

        public void UpdateAudioLatency(string value)
        {
            int latency;
            latency = int.TryParse(value, out latency) ? latency : 50;
            SoundPlayer.Instance.AudioLatency = latency;
        }

        public void UpdateTracksFilepathsDisplay(bool fullPath)
        {
            audioHkDataGrid.Columns["audioShortFilesDisplayCln"].Visible = !fullPath;
            audioHkDataGrid.Columns["audioFullFilesDisplayCln"].Visible = fullPath;
        }

        public void UpdateNotifications(bool enable)
        {
            SoundPlayer.Instance.Notificator.Visible = enable;
        }

        public void AudioHkDataGridAddLine(string key, string files, float volume, int hotkeyId, Guid audioDevice, int startingTime, string name = "")
        {
            audioHkDataGrid.Rows.Add(name, key, GetConcatedFilenames(files), files.Replace("*", ",\n"), files, TimeSpan.FromSeconds(startingTime).ToString(@"mm\:ss"), (volume * 100) + "%", hotkeyId, audioDevice);
        }

        public void ControlHkDataGridAddLine(string key, ControlRoles role, string valueRowVal, int hotkeyId)
        {
            string friendlyRoleDisplay =  friendlyActionsNames.FirstOrDefault(x => x.Value == role).Key;
            controlHkDataGrid.Rows.Add(key, friendlyRoleDisplay, valueRowVal, hotkeyId);
        }

        public void UpdateFadingValues(int fadeInValue, int fadeOutValue, FadingActions fAction)
        {
            DataGridViewRow fadingValuesRow;
            SoundPlayer.Instance.ChangeFadingValue(fAction, "fadeIn", fadeInValue);
            SoundPlayer.Instance.ChangeFadingValue(fAction, "fadeOut", fadeOutValue);
            fadingValuesRow = fadingDataGrid.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["actionNameFadeCln"].Value.ToString() == fAction.ToString());
            fadingValuesRow.Cells["fadeInCln"].Value = fadeInValue + " ms";
            fadingValuesRow.Cells["fadeOutCln"].Value = fadeOutValue + " ms";
        }

        private void HkDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridHkRemove(sender, e);
            }
            string prout;
        }

        
    }
}
