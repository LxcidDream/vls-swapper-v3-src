﻿using vls_swapper_v3.Backblings;
using vls_swapper_v3.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace vls_swapper_v3.Other
{
    public partial class BackupAsk : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public BackupAsk()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            BackupPerfect a = new BackupPerfect();
            a.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {      
            Backup a = new Backup();
            a.ShowDialog();
        }
    }
    }

