using System;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using System.Runtime.InteropServices;
using System.Net;
using System.Diagnostics;

namespace vls_swapper_v3.main.popups
{
    public partial class paks : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public paks()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Red400, Primary.Grey900, Primary.Grey900, Accent.Red400, TextShade.WHITE);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/vMgdJCX");
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
        }
    }
}
