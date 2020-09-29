using System;
using System.Windows.Forms;
using System.IO;
using SoundBoard.Persistence;

namespace SoundBoard
{
    public partial class OptionsForm : Form
    {
        private MainForm mainF;
        public OptionsForm(MainForm mainF)
        {
            this.mainF = mainF;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            hotkeysStartTxtBox.Text = AppDataManager.getCfgParameter(AppDataNames.DefaultXmlFilePath);
            hotkeysStartChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.LoadXmlOnStartUp) == "1";
            disableDirtyTrackerChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.DisableDirtyTracker) == "1";
            resetRatesOnNewPlayChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.ResetRatesOnNewPlay) == "1";
            resetAutoRepeatOnNewPlayChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.ResetAutoRepeatOnNewPlay) == "1";
            displayFullFilepathsChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.DisplayTracksFullFilepaths) == "1";
            enableNotifChkBox.Checked = AppDataManager.getCfgParameter(AppDataNames.EnableNotifications) == "1";
            audioLatencyNumBox.Value = int.TryParse(AppDataManager.getCfgParameter(AppDataNames.AudioLatency), out int latency) ? latency : 50;
            tracksPlayOrderCmbBox.Text = AppDataManager.getCfgParameter(AppDataNames.TracksPlayOrder);
        }

        private void BrowseHotkeysStartButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog
            {
                Filter = "XML|*.xml",
                Multiselect = false
            };
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                hotkeysStartTxtBox.Text = selectFileDialog.FileName;
            }
        }

        private void HotkeysStartChkBox_CheckedChanged(object sender, EventArgs e)
        {
            browseHotkeysStartButton.Enabled = hotkeysStartChkBox.Checked;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            AppDataManager.setCfgParameter(AppDataNames.LoadXmlOnStartUp, hotkeysStartChkBox.Checked ? "1" : "0");
            AppDataManager.setCfgParameter(AppDataNames.DisableDirtyTracker, disableDirtyTrackerChkBox.Checked ? "1" : "0");
            AppDataManager.setCfgParameter(AppDataNames.ResetRatesOnNewPlay, resetRatesOnNewPlayChkBox.Checked ? "1" : "0");
            AppDataManager.setCfgParameter(AppDataNames.ResetAutoRepeatOnNewPlay, resetAutoRepeatOnNewPlayChkBox.Checked ? "1" : "0");
            AppDataManager.setCfgParameter(AppDataNames.DefaultXmlFilePath, hotkeysStartTxtBox.Text);
            AppDataManager.setCfgParameter(AppDataNames.AudioLatency, audioLatencyNumBox.Value.ToString());
            AppDataManager.setCfgParameter(AppDataNames.TracksPlayOrder, tracksPlayOrderCmbBox.SelectedItem.ToString());
            AppDataManager.setCfgParameter(AppDataNames.DisplayTracksFullFilepaths, displayFullFilepathsChkBox.Checked ? "1" : "0");
            AppDataManager.setCfgParameter(AppDataNames.EnableNotifications, enableNotifChkBox.Checked ? "1" : "0");
            mainF.UpdateAudioLatency(audioLatencyNumBox.Value.ToString());
            mainF.UpdateResetMusicRates(resetRatesOnNewPlayChkBox.Checked);
            mainF.UpdateResetAutoRepeat(resetAutoRepeatOnNewPlayChkBox.Checked);
            mainF.UpdateTracksOrder(tracksPlayOrderCmbBox.SelectedItem.ToString());
            mainF.UpdateTracksFilepathsDisplay(displayFullFilepathsChkBox.Checked);
            mainF.UpdateNotifications(enableNotifChkBox.Checked);
            AppDataManager.saveCfg();
            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            hotkeysStartChkBox.Checked = true;
            disableDirtyTrackerChkBox.Checked = false;
            displayFullFilepathsChkBox.Checked = false;
            resetRatesOnNewPlayChkBox.Checked = false;
            resetAutoRepeatOnNewPlayChkBox.Checked = true;
            hotkeysStartTxtBox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SoundBoard\\Hotkeys.xml");
            audioLatencyNumBox.Value = 60;
        }
    }
}
