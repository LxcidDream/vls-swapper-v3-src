using DiscordRPC;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3
{
    public partial class Credits : MaterialForm
    {
        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;

        public Credits()
        {
            UpdateRPC();
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

            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void UpdateRPC()
        {
            loader.client.SetPresence(new RichPresence()
            {
                Details = "🍀 Fastest Skin Swapper",
                State = "🍀 Browsing Credits",
                Assets = new Assets
                {
                    LargeImageKey = "original_1_",
                    LargeImageText = "Best Swapper",
                    SmallImageKey = "small1",
                    SmallImageText = "Powered by Whey"

                }
            });
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            loader.client.Dispose();
        }
    }
}
