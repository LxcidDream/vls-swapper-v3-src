using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using vls_swapper_v3.items.skins;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.Skins;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace vls_swapper_v3.items
{
    public partial class CheckRenegadeAsk : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;

        public CheckRenegadeAsk()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            CheckRenegade a = new CheckRenegade();
            a.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (Settings.Default.premium == false)
            {
                MessageBox.Show("This is for paid members only!", "reneagde to nog ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
            }
        }
    }
 }

