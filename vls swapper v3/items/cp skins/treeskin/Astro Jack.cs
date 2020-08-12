
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;
using vls_swapper_v3.IO;

namespace vls_swapper_v3.Emotes
{
    public partial class AstroJack : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public AstroJack()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Astro Jack";
            bool enabled = Settings.Default.astroworldenabled;
            if (enabled)
            {
                revert.Enabled = true;
                convert.Enabled = false;
            }
            else
            {
                revert.Enabled = false;
                convert.Enabled = true;

            }

            
        }

        


        public static void ReplaceBytes(string pak, long offset, byte[] bytes)
        {
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(pak, FileMode.Open, FileAccess.ReadWrite));
            binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
            binaryWriter.Write(bytes);
            binaryWriter.Close();
        }

        private static byte[] body = new byte[103]
        {
            47,71,97,109,101,47,65,116,104,101,110,97,47,72,101,114,111,101,115,47,77,101,115,104,101,115,47,66,111,100,105,101,115,47,67,80,95,66,111,100,121,95,67,111,109,109,97,110,100,111,95,70,95,82,101,98,105,114,116,104,68,101,102,97,117,108,116,65,46,67,80,95,66,111,100,121,95,67,111,109,109,97,110,100,111,95,70,95,82,101,98,105,114,116,104,68,101,102,97,117,108,116,65
        };
        private static byte[] body1 = new byte[103]
        {
            47,71,97,109,101,47,65,116,104,101,110,97,47,72,101,114,111,101,115,47,77,101,115,104,101,115,47,66,111,100,105,101,115,47,67,80,95,65,116,104,101,110,97,95,66,111,100,121,95,77,95,74,101,114,107,121,83,112,97,99,101,46,67,80,95,65,116,104,101,110,97,95,66,111,100,121,95,77,95,74,101,114,107,121,83,112,97,99,101,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };
        private static byte[] head = new byte[103]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,80,97,114,116,115,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,67,80,95,72,101,97,100,95,70,95,82,101,98,105,114,116,104,68,101,102,97,117,108,116,65,46,67,80,95,72,101,97,100,95,70,95,82,101,98,105,114,116,104,68,101,102,97,117,108,116,65
        };
        private static byte[] head1 = new byte[103]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,80,97,114,116,115,47,70,97,99,101,65,99,99,101,115,115,111,114,105,101,115,47,67,80,95,77,95,77,69,68,95,67,121,99,108,111,110,101,83,112,97,99,101,46,67,80,95,77,95,77,69,68,95,67,121,99,108,111,110,101,83,112,97,99,101,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] cp = new byte[]
        {
            0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,108,100,105,101,114
        };
        private static byte[] cp1 = new byte[]
        {
            0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,49,100,105,101,114
        };


        



        private void revert_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;


            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath1))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }






            revert.Enabled = false;

            RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            AstroJack.ReplaceBytes(filePath, 3268051L, AstroJack.head1);
            AstroJack.ReplaceBytes(filePath, 3268051L, AstroJack.head);
            this.RichTextBoxInfo.AppendText("\n[LOG] head removed!");
            AstroJack.ReplaceBytes(filePath, 3264546L, AstroJack.body1);
            AstroJack.ReplaceBytes(filePath, 3264546L, AstroJack.body);
            this.RichTextBoxInfo.AppendText("\n[LOG] body removed!");
            AstroJack.ReplaceBytes(filePath, 203378241L, AstroJack.cp1);
            AstroJack.ReplaceBytes(filePath, 203378241L, AstroJack.cp);
            this.RichTextBoxInfo.AppendText("\n[LOG] cp removed!");
            Settings.Default.cpskinEnabled = false;
            Settings.Default.astroworldenabled = false;
            Settings.Default.Save(); 

            convert.Enabled = true;
            revert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {


            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath1))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }

            if (Settings.Default.cpskinEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "a cp skin has been already converted " + MessageBoxButtons.OK + MessageBoxIcon.Error, 100);
                return;
            }

            CheckForIllegalCrossThreadCalls = false;


            convert.Enabled = false;

            RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            AstroJack.ReplaceBytes(filePath, 3268051L, AstroJack.head);
            AstroJack.ReplaceBytes(filePath, 3268051L, AstroJack.head1);
            this.RichTextBoxInfo.AppendText("\n[LOG] head added!");
            AstroJack.ReplaceBytes(filePath, 3264546L, AstroJack.body);
            AstroJack.ReplaceBytes(filePath, 3264546L, AstroJack.body1);
            this.RichTextBoxInfo.AppendText("\n[LOG] body added!");
            AstroJack.ReplaceBytes(filePath, 203378241L, AstroJack.cp);
            AstroJack.ReplaceBytes(filePath, 203378241L, AstroJack.cp1);
            this.RichTextBoxInfo.AppendText("\n[LOG] cp added!");
            Settings.Default.cpskinEnabled = true;
            Settings.Default.astroworldenabled = true;
            Settings.Default.Save();

            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void AstroJack_Load(object sender, EventArgs e)
        {

        }
    }
}
