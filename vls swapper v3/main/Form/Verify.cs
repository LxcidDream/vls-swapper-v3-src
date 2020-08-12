using System;
using vls_swapper_v3.Properties;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace vls_swapper_v3
{
    public partial class Verify : MaterialForm
    {
        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        private readonly CultureInfo culture = CultureInfo.CurrentUICulture;
        public static string GetPaksFolder
        {
            get { return Settings.Default.paksPath; }
        }
        public Verify()
        {
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

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            string pathto10s1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto10s2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto0 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            if (File.Exists(pathto0) && File.Exists(pathto10s2))
            {
                backupWorker.RunWorkerAsync();
            }
            else
            {
                
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("temp"))
            {
                verifyWorker.RunWorkerAsync();
            }
            else
            {
                RichTextBoxInfo.Text = "[" + DateTime.Now + "] Temp folder not found, before verifying you need to backup your game files!\n";
            }
        }

        private void verifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            string pathto10s1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto10s2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto0 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            RichTextBoxInfo.Text = "[" + DateTime.Now + "] Starting...\n";
            try
            {
                if (File.Exists("temp/pakchunk10_s3-WindowsClient.pak") && File.Exists("temp/pakchunk10_s2-WindowsClient.pak"))
                {
                    if (File.Exists(pathto0))
                    {
                        File.Delete(pathto0);
                    }
                    if (File.Exists(pathto10s2))
                    {
                        File.Delete(pathto10s2);
                    }

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Temp folder detected!\n";

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copying game files... 1/2\n";

                    File.Copy("pakchunk10_s3-WindowsClient.pak", pathto0);

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copied 1/2 game files!\n";

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copying game files... 2/2\n";

                    File.Copy("temp/pakchunk10_s2-WindowsClient.pak", pathto10s2);

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copied 2/2 game files!\n";

                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Successfully verified your game files!\n";

                    File.Delete("temp/pakchunk10_s2-WindowsClient.pak");
                    File.Delete("temp/pakchunk10_s3-WindowsClient.pak");

                    Directory.Delete("temp");
                }
                else
                {
                    RichTextBoxInfo.Text += "[" + DateTime.Now + "] Temp folder found, but not game files in it!\n";
                }
            }
            catch (Exception)
            {
                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Error, contact whey if this isn't normal!\n";
            }
        }

        private void backupWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            string pathto10s1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto10s2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string pathto0 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            RichTextBoxInfo.Text = "[" + DateTime.Now + "] Starting... (may be long due to the size of paks files)\n";
            try
            {
                if (Directory.Exists("temp"))
                {
                    if (File.Exists("temp/pakchunk10_s3-WindowsClient.pak"))
                    {
                        File.Delete("temp/pakchunk10_s3-WindowsClient.pak");
                    }
                    if (File.Exists("temp/pakchunk10_s2-WindowsClient.pak"))
                    {
                        File.Delete("temp/pakchunk10_s2-WindowsClient.pak");
                    }
                    Directory.Delete("temp");
                }

                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Creating temp folder...\n";

                Directory.CreateDirectory("temp");

                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Temp folder created!\n";


                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copying game files... 1/2\n";

                File.Copy(pathto0, "temp/pakchunk10_s3-WindowsClient.pak");

                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copied 1/2 game files!\n";

                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copying game files... 2/2\n";

                File.Copy(pathto10s2, "temp/pakchunk10_s2-WindowsClient.pak");

                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Copied 2/2 game files!\n";


                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Successfully created backup of your game files!\n";
            }
            catch (Exception ex)
            {
                RichTextBoxInfo.Text += "[" + DateTime.Now + "] Error, contact whey if this isn't normal!\n" + ex.Message;
            }
        }
    }
}
