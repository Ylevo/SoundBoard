﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void NaudioLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            naudioLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://naudio.codeplex.com/license");
        }
    }
}
