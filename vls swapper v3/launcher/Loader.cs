using DiscordRPC;
using MaterialSkin.Controls;
using System;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using vls_swapper_v3.Properties;
using vls_swapper_v3.Menus;

namespace vls_swapper_v3.Emote
{
    public partial class Loader : Form
    {

        public static bool asfree => freeregister;
        public static bool freeregister = false;
        public static string LoggedUser;
        public static DiscordRpcClient client;

        private static string GetTextFromUrl(string url)
        {
            WebClient wc = new WebClient();
            string page = wc.DownloadString(url);
            return page;
        }

        public Loader()
        {
            Initialize();
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            HttpWebRequest.DefaultWebProxy = new WebProxy();

           
        }   

        private void Initialize()
        {
            client = new DiscordRpcClient("707324387950329856");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "🍀 vls Swapper",
                State = "🍀 Loading...",
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
            client.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Form form = new LoginMenu();
            var Open = form;
            Open.Closed += (s, args) => this.Close();
            this.Hide();
            Open.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (animaProgressBar1.Value == 90)
            {
                timer2.Enabled = false;
                timer1.Enabled = true;
            }
            animaProgressBar1.Value += 10;
        }

        private void Loader_Load(object sender, EventArgs e)
        {

        }
    }
}
