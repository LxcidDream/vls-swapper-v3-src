using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DiscordRPC;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.Menus
{
    public partial class LoginMenu : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        private static string GetTextFromUrl(string url)
        {
            WebClient wc = new WebClient();
            string page = wc.DownloadString(url);
            return page;
        }
        public LoginMenu()
        {
            UpdateRPC1();
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode;
            if (enabledmode)
            {
                skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
            }
            else
            {
                skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
            }

            

            try
            {
                string Offset = GetTextFromUrl("https://pastebin.com/raw/PiMS8hyX");
                var result = Regex.Split(Offset, "\r\n|\r|\n");
                Settings.Default.offsetskin1 = int.Parse(result[0]); //offset body
                Settings.Default.offsetskin2 = int.Parse(result[1]); //offset head
                Settings.Default.offsetpick = int.Parse(result[2]); //offset pickaxe mesh
                Settings.Default.offsetpickmesh = int.Parse(result[3]); //offset pickaxe sound
                Settings.Default.offsetback = int.Parse(result[4]); //offset backbling
                Settings.Default.offsetemote = int.Parse(result[5]); //offset emote_CMM
                Settings.Default.offsetbodyS3 = int.Parse(result[6]); //offset season 3 body
                Settings.Default.offsetbodyS31 = int.Parse(result[7]); //offset season 3 head
                Settings.Default.Save();
            }
            catch (Exception rr)
            {
                MessageBox.Show("Couldn't retrieve offsets from Juicy Server Please Contact whey " + rr);
            }
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
           
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                materialRaisedButton1_Click(sender, new EventArgs());
            }
        }

        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.credentialsSaved = true;
            Properties.Settings.Default.usernameSave = txtUsername.Text;
            Properties.Settings.Default.passwordSave = txtPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void freeButton_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.premium = false;
            Properties.Settings.Default.Save();
            FreeMsg form = new FreeMsg();
            var Open = form;
            Open.Closed += (s, args) => this.Close();
            this.Hide();
            Open.ShowDialog();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://shoppy.gg/@whey5000/groups/iPul7nH");
            //this.Hide();
            MessageBox.Show("if you wanna buy paid please dm whey#5000 on discord");
            Register f2 = new Register();
            f2.ShowDialog();

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            string username;
            string password;

            username = txtUsername.Text;
            password = txtPassword.Text;

            if (Yato.Application.isOTPEnabled())
            {
                string otp_code = txt2FA.Text;
                if (Yato.Auth.Login(username, password, otp_code))
                {
                    Yato.User user = Yato.Auth.getUser();
                }
            }
            else if (Yato.Auth.Login(username, password))
            {
                Yato.User user = Yato.Auth.getUser();
                if (Properties.Settings.Default.credentialsSaved == true)
                {
                    Properties.Settings.Default.usernameSave = txtUsername.Text;
                    Properties.Settings.Default.passwordSave = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                Properties.Settings.Default.premium = true;
                Properties.Settings.Default.Save();
                PaidMsg form = new PaidMsg();
                var Open = form;
                Open.Closed += (s, args) => this.Close();
                this.Hide();
                Open.ShowDialog();
            }
        }

        private void LoginMenu_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.credentialsSaved == true)
            {
                txtUsername.Text = Properties.Settings.Default.usernameSave;
                txtPassword.Text = Properties.Settings.Default.passwordSave;
                rememberMe.Checked = true;
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ResetPass f2 = new ResetPass();
            f2.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Credits a = new Credits();
            a.ShowDialog();
        }

        void UpdateRPC1()
        {
            loader.client.SetPresence(new RichPresence()
            {
                Details = "🍀 Fastest Skin Swapper",
                State = "🍀 Browsing Login Page",
                Assets = new Assets
                {
                    LargeImageKey = "original_1_",
                    LargeImageText = "Best Swapper",
                    SmallImageKey = "small1",
                    SmallImageText = "Powered by Whey"

                }
            });
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
