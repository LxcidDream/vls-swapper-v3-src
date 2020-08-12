using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using vls_swapper_v3.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using vls_swapper_v3.Classes;
using System.IO;
using DiscordRPC;
using System.Diagnostics;
using vls_swapper_v3.items;
using System.Threading;

namespace vls_swapper_v3
{
    public partial class Options : MaterialForm
    {

        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        private object openFileDialog1;

        public static string GetPaksFolder
        {
            get { return Settings.Default.paksPath; }
        }
        public Options()
        {
            Settingstabb();


            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            path.Text = Settings.Default.paksPath;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            loader.client.Dispose();
        }

        private static string GetEpicDirectory() => Directory.Exists(@"C:\ProgramData\Epic") ? @"C:\ProgramData\Epic" : Directory.Exists(@"D:\ProgramData\Epic") ? @"D:\ProgramData\Epic" : Directory.Exists(@"E:\ProgramData\Epic") ? @"E:\ProgramData\Epic" : @"F:\ProgramData\Epic";
        private static bool DatFileExists() => File.Exists($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
        public static string GetGameFiles()
        {
            if (DatFileExists())
            {
                string jsonData = File.ReadAllText($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
                if (Utilities.IsValidJson(jsonData))
                {
                    JToken FortnitePath = JsonConvert.DeserializeObject<JToken>(jsonData);
                    if (FortnitePath != null)
                    {
                        JArray installationListArray = FortnitePath["InstallationList"].Value<JArray>();
                        if (installationListArray != null)
                        {
                            foreach (JToken FortnitePathReal in installationListArray)
                            {
                                if (string.Equals(FortnitePathReal["AppName"].Value<string>(), "Fortnite"))
                                {
                                    return $@"{FortnitePathReal["InstallLocation"].Value<string>()}\FortniteGame\Content\Paks";
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Settings.Default.paksPath = dialog.FileName;
                Settings.Default.Save();
                path.Text = Settings.Default.paksPath;
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            bool enabled = !Settings.Default.ismode;
            if (enabled)
            {
                Settings.Default.ismode = true;
                Settings.Default.Save();

                skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
            }
            else
            {
                Settings.Default.ismode = false;
                Settings.Default.Save();
                bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); } //255, 128, 128
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (Settings.Default.premium == false)
            {
                accounterror a = new accounterror();
                a.ShowDialog();
            }
            else
            {
                accountinfo a = new accountinfo();
                a.ShowDialog();
            }

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ResetMsg a = new ResetMsg();
            a.ShowDialog();
            return;
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {

            string path = Settings.Default.paksPath + "\\pakchunk10_s2-WindowsClient.pak";
            string path2 = Settings.Default.paksPath + "\\pakchunk10_s3-WindowsClient.pak";
            try
            {
                using (new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    MessageBox.Show("Swapper is working (pakchunk10_s2)!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "vls swapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            try
            {
                using (new FileStream(path2, FileMode.Open, FileAccess.ReadWrite))
                {
                    MessageBox.Show("Swapper is working (pakchunk10_s3)!");
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "vls Swapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            if (File.Exists(GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak"))
            {
                Process.Start(GetPaksFolder);
                return;
            }
            MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {

        }

        

        public static string GetGamewin()
        {
            if (DatFileExists())
            {
                string jsonData = File.ReadAllText($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
                if (Utilities.IsValidJson(jsonData))
                {
                    JToken FortnitePath = JsonConvert.DeserializeObject<JToken>(jsonData);
                    if (FortnitePath != null)
                    {
                        JArray installationListArray = FortnitePath["InstallationList"].Value<JArray>();
                        if (installationListArray != null)
                        {
                            foreach (JToken FortnitePathReal in installationListArray)
                            {
                                if (string.Equals(FortnitePathReal["AppName"].Value<string>(), "Fortnite"))
                                {
                                    return $@"{FortnitePathReal["InstallLocation"].Value<string>()}\FortniteGame\\Binaries\Win64\";
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void Settingstabb()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Settings Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Settings Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
        }

        private void materialRaisedButton6_Click_1(object sender, EventArgs e)
        {


        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton6_Click_2(object sender, EventArgs e)
        {
            //killfortntie();
            //Thread.Sleep(1000);
            //LanchgameEAC();
            //new Launch().ShowDialog();
        }

        public void killfortntie()
        {
            try
            {
                Process.Start("cmd.exe", "/c taskkill /F /IM EpicGamesLauncher.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM FortniteClient-Win64-Shipping_BE.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM FortniteClient-Win64-Shipping_EAC.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM FortniteClient-Win64-Shipping.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM FortniteLauncher.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM BEService.exe /T");
                Process.Start("cmd.exe", "/c taskkill /F /IM EasyAntiCheat.exe /T");
            }
            catch
            {

            }
        }

        void LanchgameEAC()
        {
            string filepath = GetGamewin();
            
            Process.Start(filepath + "\\FortniteClient-Win64-Shipping_EAC.exe");
        }

        private void materialRaisedButton7_Click_1(object sender, EventArgs e)
        {
            killfortntie();
            Thread.Sleep(1000);
            LanchgameBE();
            new Launch().ShowDialog();
        }

        void LanchgameBE()
        {
            string filepath = GetGamewin();

            Process.Start(filepath + "\\FortniteClient-Win64-Shipping_BE.exe");
        }

        private void materialRaisedButton8_Click_1(object sender, EventArgs e)
        {

            Verify a = new Verify();
            a.ShowDialog();
        }
    }
}
