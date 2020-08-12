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
using vls_swapper_v3.IO;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Emotes
{
    public partial class nevergunna : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public nevergunna()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "never gunna";
            bool enabled = Settings.Default.nevergunnaenabled;
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

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private static byte[] CMM = new byte[104]
        {
            47,71,97,109,101,47,65,110,105,109,97,116,105,111,110,47,71,97,109,101,47,77,97,105,110,80,108,97,121,101,114,47,69,109,111,116,101,115,47,66,108,111,119,105,110,103,66,117,98,98,108,101,47,69,109,111,116,101,95,66,108,111,119,105,110,103,66,117,98,98,108,101,95,67,77,77,95,77,46,69,109,111,116,101,95,66,108,111,119,105,110,103,66,117,98,98,108,101,95,67,77,77,95,77
        };
        private static byte[] CMM1 = new byte[104]
        {
            47,71,97,109,101,47,65,110,105,109,97,116,105,111,110,47,71,97,109,101,47,77,97,105,110,80,108,97,121,101,114,47,69,109,111,116,101,115,47,78,101,118,101,114,71,111,110,110,97,47,69,109,111,116,101,95,78,101,118,101,114,71,111,110,110,97,95,67,77,77,95,77,46,69,109,111,116,101,95,78,101,118,101,114,71,111,110,110,97,95,67,77,77,95,77,0,0,0,0,0,0,0,0,0
        };
        private static byte[] CMF = new byte[104]
        {
            47,71,97,109,101,47,65,110,105,109,97,116,105,111,110,47,71,97,109,101,47,77,97,105,110,80,108,97,121,101,114,47,69,109,111,116,101,115,47,66,108,111,119,105,110,103,66,117,98,98,108,101,47,69,109,111,116,101,95,66,108,111,119,105,110,103,66,117,98,98,108,101,95,67,77,70,95,77,46,69,109,111,116,101,95,66,108,111,119,105,110,103,66,117,98,98,108,101,95,67,77,70,95,77
        };
        private static byte[] CMF1 = new byte[104]
        {
            47,71,97,109,101,47,65,110,105,109,97,116,105,111,110,47,71,97,109,101,47,77,97,105,110,80,108,97,121,101,114,47,69,109,111,116,101,115,47,78,101,118,101,114,71,111,110,110,97,47,69,109,111,116,101,95,78,101,118,101,114,71,111,110,110,97,95,67,77,70,95,77,46,69,109,111,116,101,95,78,101,118,101,114,71,111,110,110,97,95,67,77,70,95,77,0,0,0,0,0,0,0,0,0
        };
        private readonly object Settingstab;

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";



            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetemote, CMM1))
            {
                fs1.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CMM);
                binaryWrite.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Dance 1/2 removed!";
                Settings.Default.nevergunnaenabled = false;
                Settings.Default.Save();
            }

            Stream fs2 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetemote, CMF1))
            {
                fs2.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CMF);
                binaryWrite.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Dance 2/2 removed!";
            }



            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.takethel)
            {
                MetroFramework.MetroMessageBox.Show(this, "take the l" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetemote, CMM))
            {
                fs1.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CMM1);
                binaryWrite.Close();
                Settings.Default.nevergunnaenabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Dance 1/2 added!";
            }

            Stream fs2 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetemote, CMF))
            {
                fs2.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CMF1);
                binaryWrite.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Dance 2/2 added!";
            }



            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            Dance i = new Dance(); i.ShowDialog();
            change1Bytes.RunWorkerAsync();
        }

        private void revert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            revert1Bytes.RunWorkerAsync();
        }
    }
}
