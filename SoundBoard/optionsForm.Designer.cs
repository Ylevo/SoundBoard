namespace SoundBoard
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.resetButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.hotkeysStartChkBox = new System.Windows.Forms.CheckBox();
            this.browseHotkeysStartButton = new System.Windows.Forms.Button();
            this.hotkeysStartTxtBox = new System.Windows.Forms.TextBox();
            this.disableDirtyTrackerChkBox = new System.Windows.Forms.CheckBox();
            this.resetRatesOnNewPlayChkBox = new System.Windows.Forms.CheckBox();
            this.audioLatencyNumBox = new System.Windows.Forms.NumericUpDown();
            this.audioLatencyLbl = new System.Windows.Forms.Label();
            this.audioLatencyDescripLbl = new System.Windows.Forms.Label();
            this.tracksPlayOrderCmbBox = new System.Windows.Forms.ComboBox();
            this.tracksPlayOrderLbl = new System.Windows.Forms.Label();
            this.displayFullFilepathsChkBox = new System.Windows.Forms.CheckBox();
            this.resetAutoRepeatOnNewPlayChkBox = new System.Windows.Forms.CheckBox();
            this.enableNotifChkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.audioLatencyNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(380, 272);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(299, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(218, 272);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // hotkeysStartChkBox
            // 
            this.hotkeysStartChkBox.AutoSize = true;
            this.hotkeysStartChkBox.Location = new System.Drawing.Point(12, 23);
            this.hotkeysStartChkBox.Name = "hotkeysStartChkBox";
            this.hotkeysStartChkBox.Size = new System.Drawing.Size(242, 17);
            this.hotkeysStartChkBox.TabIndex = 3;
            this.hotkeysStartChkBox.Text = "Load hotkeys and options on start located at :";
            this.hotkeysStartChkBox.UseVisualStyleBackColor = true;
            this.hotkeysStartChkBox.CheckedChanged += new System.EventHandler(this.HotkeysStartChkBox_CheckedChanged);
            // 
            // browseHotkeysStartButton
            // 
            this.browseHotkeysStartButton.Location = new System.Drawing.Point(33, 44);
            this.browseHotkeysStartButton.Name = "browseHotkeysStartButton";
            this.browseHotkeysStartButton.Size = new System.Drawing.Size(75, 23);
            this.browseHotkeysStartButton.TabIndex = 4;
            this.browseHotkeysStartButton.Text = "Browse";
            this.browseHotkeysStartButton.UseVisualStyleBackColor = true;
            this.browseHotkeysStartButton.Click += new System.EventHandler(this.BrowseHotkeysStartButton_Click);
            // 
            // hotkeysStartTxtBox
            // 
            this.hotkeysStartTxtBox.Location = new System.Drawing.Point(114, 46);
            this.hotkeysStartTxtBox.Name = "hotkeysStartTxtBox";
            this.hotkeysStartTxtBox.ReadOnly = true;
            this.hotkeysStartTxtBox.Size = new System.Drawing.Size(276, 20);
            this.hotkeysStartTxtBox.TabIndex = 5;
            // 
            // disableDirtyTrackerChkBox
            // 
            this.disableDirtyTrackerChkBox.AutoSize = true;
            this.disableDirtyTrackerChkBox.Location = new System.Drawing.Point(12, 83);
            this.disableDirtyTrackerChkBox.Name = "disableDirtyTrackerChkBox";
            this.disableDirtyTrackerChkBox.Size = new System.Drawing.Size(233, 17);
            this.disableDirtyTrackerChkBox.TabIndex = 6;
            this.disableDirtyTrackerChkBox.Text = "Never ask me to save on closing or loading.";
            this.disableDirtyTrackerChkBox.UseVisualStyleBackColor = true;
            // 
            // resetRatesOnNewPlayChkBox
            // 
            this.resetRatesOnNewPlayChkBox.AutoSize = true;
            this.resetRatesOnNewPlayChkBox.Location = new System.Drawing.Point(12, 107);
            this.resetRatesOnNewPlayChkBox.Name = "resetRatesOnNewPlayChkBox";
            this.resetRatesOnNewPlayChkBox.Size = new System.Drawing.Size(320, 17);
            this.resetRatesOnNewPlayChkBox.TabIndex = 7;
            this.resetRatesOnNewPlayChkBox.Text = "Reset the tempo/pitch/speed rates when starting a new track.";
            this.resetRatesOnNewPlayChkBox.UseVisualStyleBackColor = true;
            // 
            // audioLatencyNumBox
            // 
            this.audioLatencyNumBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.audioLatencyNumBox.Location = new System.Drawing.Point(92, 204);
            this.audioLatencyNumBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.audioLatencyNumBox.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.audioLatencyNumBox.Name = "audioLatencyNumBox";
            this.audioLatencyNumBox.Size = new System.Drawing.Size(53, 20);
            this.audioLatencyNumBox.TabIndex = 8;
            this.audioLatencyNumBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // audioLatencyLbl
            // 
            this.audioLatencyLbl.AutoSize = true;
            this.audioLatencyLbl.Location = new System.Drawing.Point(9, 206);
            this.audioLatencyLbl.Name = "audioLatencyLbl";
            this.audioLatencyLbl.Size = new System.Drawing.Size(77, 13);
            this.audioLatencyLbl.TabIndex = 9;
            this.audioLatencyLbl.Text = "Audio latency :";
            // 
            // audioLatencyDescripLbl
            // 
            this.audioLatencyDescripLbl.AutoSize = true;
            this.audioLatencyDescripLbl.Location = new System.Drawing.Point(151, 206);
            this.audioLatencyDescripLbl.Name = "audioLatencyDescripLbl";
            this.audioLatencyDescripLbl.Size = new System.Drawing.Size(214, 13);
            this.audioLatencyDescripLbl.TabIndex = 11;
            this.audioLatencyDescripLbl.Text = "Increase it if you experience crackle/stutter.";
            // 
            // tracksPlayOrderCmbBox
            // 
            this.tracksPlayOrderCmbBox.FormattingEnabled = true;
            this.tracksPlayOrderCmbBox.Items.AddRange(new object[] {
            "Default",
            "Random",
            "Shuffle"});
            this.tracksPlayOrderCmbBox.Location = new System.Drawing.Point(145, 235);
            this.tracksPlayOrderCmbBox.Name = "tracksPlayOrderCmbBox";
            this.tracksPlayOrderCmbBox.Size = new System.Drawing.Size(83, 21);
            this.tracksPlayOrderCmbBox.TabIndex = 12;
            // 
            // tracksPlayOrderLbl
            // 
            this.tracksPlayOrderLbl.AutoSize = true;
            this.tracksPlayOrderLbl.Location = new System.Drawing.Point(9, 238);
            this.tracksPlayOrderLbl.Name = "tracksPlayOrderLbl";
            this.tracksPlayOrderLbl.Size = new System.Drawing.Size(130, 13);
            this.tracksPlayOrderLbl.TabIndex = 13;
            this.tracksPlayOrderLbl.Text = "Multiple tracks play order :";
            // 
            // displayFullFilepathsChkBox
            // 
            this.displayFullFilepathsChkBox.AutoSize = true;
            this.displayFullFilepathsChkBox.Location = new System.Drawing.Point(12, 153);
            this.displayFullFilepathsChkBox.Name = "displayFullFilepathsChkBox";
            this.displayFullFilepathsChkBox.Size = new System.Drawing.Size(165, 17);
            this.displayFullFilepathsChkBox.TabIndex = 14;
            this.displayFullFilepathsChkBox.Text = "Display full filepaths of tracks.";
            this.displayFullFilepathsChkBox.UseVisualStyleBackColor = true;
            // 
            // resetAutoRepeatOnNewPlayChkBox
            // 
            this.resetAutoRepeatOnNewPlayChkBox.AutoSize = true;
            this.resetAutoRepeatOnNewPlayChkBox.Location = new System.Drawing.Point(12, 130);
            this.resetAutoRepeatOnNewPlayChkBox.Name = "resetAutoRepeatOnNewPlayChkBox";
            this.resetAutoRepeatOnNewPlayChkBox.Size = new System.Drawing.Size(248, 17);
            this.resetAutoRepeatOnNewPlayChkBox.TabIndex = 15;
            this.resetAutoRepeatOnNewPlayChkBox.Text = "Turn off auto repeat when starting a new track.";
            this.resetAutoRepeatOnNewPlayChkBox.UseVisualStyleBackColor = true;
            // 
            // enableNotifChkBox
            // 
            this.enableNotifChkBox.AutoSize = true;
            this.enableNotifChkBox.Location = new System.Drawing.Point(12, 177);
            this.enableNotifChkBox.Name = "enableNotifChkBox";
            this.enableNotifChkBox.Size = new System.Drawing.Size(121, 17);
            this.enableNotifChkBox.TabIndex = 16;
            this.enableNotifChkBox.Text = "Enable notifications.";
            this.enableNotifChkBox.UseVisualStyleBackColor = true;
            // 
            // optionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 307);
            this.Controls.Add(this.enableNotifChkBox);
            this.Controls.Add(this.resetAutoRepeatOnNewPlayChkBox);
            this.Controls.Add(this.displayFullFilepathsChkBox);
            this.Controls.Add(this.tracksPlayOrderLbl);
            this.Controls.Add(this.tracksPlayOrderCmbBox);
            this.Controls.Add(this.audioLatencyDescripLbl);
            this.Controls.Add(this.audioLatencyLbl);
            this.Controls.Add(this.audioLatencyNumBox);
            this.Controls.Add(this.resetRatesOnNewPlayChkBox);
            this.Controls.Add(this.disableDirtyTrackerChkBox);
            this.Controls.Add(this.hotkeysStartTxtBox);
            this.Controls.Add(this.browseHotkeysStartButton);
            this.Controls.Add(this.hotkeysStartChkBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resetButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "optionsForm";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.audioLatencyNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox hotkeysStartChkBox;
        private System.Windows.Forms.Button browseHotkeysStartButton;
        private System.Windows.Forms.TextBox hotkeysStartTxtBox;
        private System.Windows.Forms.CheckBox disableDirtyTrackerChkBox;
        private System.Windows.Forms.CheckBox resetRatesOnNewPlayChkBox;
        private System.Windows.Forms.NumericUpDown audioLatencyNumBox;
        private System.Windows.Forms.Label audioLatencyLbl;
        private System.Windows.Forms.Label audioLatencyDescripLbl;
        private System.Windows.Forms.ComboBox tracksPlayOrderCmbBox;
        private System.Windows.Forms.Label tracksPlayOrderLbl;
        private System.Windows.Forms.CheckBox displayFullFilepathsChkBox;
        private System.Windows.Forms.CheckBox resetAutoRepeatOnNewPlayChkBox;
        private System.Windows.Forms.CheckBox enableNotifChkBox;
    }
}