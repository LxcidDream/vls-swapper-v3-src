
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3
{
    public partial class Update : MaterialForm
    {
        static WebClient webclient = new WebClient();
        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Update()
        {

            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;
            if (enabledmode)
            {
                skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
            }
            else
            {
                skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
            }

            
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            string link = webclient.DownloadString("https://pastebin.com/raw/5Bzpg2jY");
            if (!File.Exists("Updater.exe"))
            {
                webclient.DownloadFileAsync(new Uri(link), "updater.exe");

                Thread.Sleep(1000);
            }
            else
            {

            }
        }

        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            Process.Start(new WebClient().DownloadString("https://discord.gg/hT4mpcR"));
        }
    }
}
