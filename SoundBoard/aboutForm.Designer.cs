namespace SoundBoard
{
    partial class aboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutForm));
            this.licenseGrpBox = new System.Windows.Forms.GroupBox();
            this.licenseRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.licenseGrpBoxHeader = new System.Windows.Forms.Label();
            this.soundBoardTitleLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.naudioLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.licenseGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // licenseGrpBox
            // 
            this.licenseGrpBox.Controls.Add(this.licenseRichTxtBox);
            this.licenseGrpBox.Controls.Add(this.licenseGrpBoxHeader);
            this.licenseGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseGrpBox.Location = new System.Drawing.Point(33, 109);
            this.licenseGrpBox.Name = "licenseGrpBox";
            this.licenseGrpBox.Size = new System.Drawing.Size(342, 204);
            this.licenseGrpBox.TabIndex = 0;
            this.licenseGrpBox.TabStop = false;
            // 
            // licenseRichTxtBox
            // 
            this.licenseRichTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.licenseRichTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.licenseRichTxtBox.Location = new System.Drawing.Point(17, 35);
            this.licenseRichTxtBox.Name = "licenseRichTxtBox";
            this.licenseRichTxtBox.Size = new System.Drawing.Size(309, 152);
            this.licenseRichTxtBox.TabIndex = 2;
            this.licenseRichTxtBox.Text = resources.GetString("licenseRichTxtBox.Text");
            // 
            // licenseGrpBoxHeader
            // 
            this.licenseGrpBoxHeader.AutoSize = true;
            this.licenseGrpBoxHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseGrpBoxHeader.Location = new System.Drawing.Point(69, 0);
            this.licenseGrpBoxHeader.Name = "licenseGrpBoxHeader";
            this.licenseGrpBoxHeader.Size = new System.Drawing.Size(183, 15);
            this.licenseGrpBoxHeader.TabIndex = 1;
            this.licenseGrpBoxHeader.Text = "Microsoft Public License (Ms-Pl)";
            // 
            // soundBoardTitleLbl
            // 
            this.soundBoardTitleLbl.AutoSize = true;
            this.soundBoardTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundBoardTitleLbl.Location = new System.Drawing.Point(131, 33);
            this.soundBoardTitleLbl.Name = "soundBoardTitleLbl";
            this.soundBoardTitleLbl.Size = new System.Drawing.Size(121, 16);
            this.soundBoardTitleLbl.TabIndex = 1;
            this.soundBoardTitleLbl.Text = "SoundBoard v1.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Powered by";
            // 
            // naudioLinkLabel
            // 
            this.naudioLinkLabel.AutoSize = true;
            this.naudioLinkLabel.LinkVisited = true;
            this.naudioLinkLabel.Location = new System.Drawing.Point(199, 62);
            this.naudioLinkLabel.Name = "naudioLinkLabel";
            this.naudioLinkLabel.Size = new System.Drawing.Size(42, 13);
            this.naudioLinkLabel.TabIndex = 3;
            this.naudioLinkLabel.TabStop = true;
            this.naudioLinkLabel.Text = "NAudio";
            this.naudioLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NaudioLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SoundBoard.Properties.Resources.soundboard_logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(33, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 325);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.naudioLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundBoardTitleLbl);
            this.Controls.Add(this.licenseGrpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aboutForm";
            this.Text = "About SoundBoard";
            this.licenseGrpBox.ResumeLayout(false);
            this.licenseGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox licenseGrpBox;
        private System.Windows.Forms.Label licenseGrpBoxHeader;
        private System.Windows.Forms.RichTextBox licenseRichTxtBox;
        private System.Windows.Forms.Label soundBoardTitleLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel naudioLinkLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}