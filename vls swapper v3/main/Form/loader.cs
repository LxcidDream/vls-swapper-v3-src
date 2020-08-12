using vls_swapper_v3.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using vls_swapper_v3;
using System.Net;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DiscordRPC;
using vls_swapper_v3.main.popups;
using System.IO;
using vls_swapper_v3.Menus;

namespace vls_swapper_v3
{
    public partial class loader : Form
    {
        private readonly string warnmessage = Resources.warnload;
        private readonly string warning = Resources.warning;
        public static DiscordRpcClient client;

        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        private static string GetTextFromUrl(string url)
        {
            WebClient wc = new WebClient();
            string page = wc.DownloadString(url);
            return page;
        }
        public loader()
        {
            Initialize();

            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            

            if (Path.GetFileName(Path.GetDirectoryName(Environment.CurrentDirectory)) == "Temp")
            {
                MessageBox.Show("vls Swapper cannot be run from WinRAR! Please extract to a folder and try again.", "vls Swapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
                Environment.Exit(0);
            }
            
            try
            {
                string AutoPath = Options.GetGameFiles();
                Settings.Default.paksPath = AutoPath;
                Settings.Default.Save();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Couldn't find the path to your Fortnite Games Files" + ee);
            }

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);



            if (!File.Exists("Updater.exe"))
            {
                
            }
            File.Delete("Updater.exe");


        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            client.Dispose();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            launcher form = new launcher();
            var Open = form;
            Open.Closed += (s, args) => this.Close();
            this.Hide();
            Open.Show();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        int mov;
        int movX;
        int movY;

        private void loader_Load(object sender, EventArgs e)
        {

        }
    }
}
