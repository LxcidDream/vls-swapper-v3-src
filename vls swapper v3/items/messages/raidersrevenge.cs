﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Emotes;
using vls_swapper_v3.Picks;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.items.messages
{
    public partial class raidersrevenge : MaterialForm
    {
        bool freeregister = Settings.Default.premium;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public raidersrevenge()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

            
            
                new Raiders().ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            deufaltraiders a = new deufaltraiders();
            a.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (freeregister == false)
            {
                MessageBox.Show("Raiders Revenge (Perfect) is reserved to Paid Members.");
            }
            else
            {
                new raidersscorcer().ShowDialog();
            }
        }
    }
}
