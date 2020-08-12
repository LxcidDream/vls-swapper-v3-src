using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using vls_swapper_v3;
using MaterialSkin.Controls;
using MaterialSkin;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;
using MetroFramework;

namespace vls_swapper_v3.Backblings
{
    public partial class Backup : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Backup()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Backup Plan";         
            bool enabled = Settings.Default.BackupEnabled;
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

        private static byte[] Mesh = new byte[142]
              {
      (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 99,
(byte) 99,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 111,
(byte) 114,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 79,
(byte) 82,
(byte) 84,
(byte) 95,
(byte) 66,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 112,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 83,
(byte) 117,
(byte) 109,
(byte) 109,
(byte) 101,
(byte) 114,
(byte) 72,
(byte) 101,
(byte) 114,
(byte) 111,
(byte) 101,
(byte) 115,
(byte) 95,
(byte) 85,
(byte) 110,
(byte) 105,
(byte) 99,
(byte) 111,
(byte) 114,
(byte) 110,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 66,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 112,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 95,
(byte) 83,
(byte) 117,
(byte) 109,
(byte) 109,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 114,
(byte) 111,
(byte) 101,
(byte) 115,
(byte) 95,
(byte) 85,
(byte) 110,
(byte) 105,
(byte) 99,
(byte) 111,
(byte) 114,
(byte) 110,
(byte) 95,
(byte) 69,
(byte) 120,
(byte) 112,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 46,
(byte) 66,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 112,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 95,
(byte) 83,
(byte) 117,
(byte) 109,
(byte) 109,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 114,
(byte) 111,
(byte) 101,
(byte) 115,
(byte) 95,
(byte) 85,
(byte) 110,
(byte) 105,
(byte) 99,
(byte) 111,
(byte) 114,
(byte) 110,
(byte) 95,
(byte) 69,
(byte) 120,
(byte) 112,
(byte) 111,
(byte) 114,
(byte) 116
              };
        private static byte[] Mesh1 = new byte[142]
        {
      (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 99,
(byte) 99,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 111,
(byte) 114,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 79,
(byte) 82,
(byte) 84,
(byte) 95,
(byte) 66,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 112,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 48,
(byte) 50,
(byte) 46,
(byte) 77,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 48,
(byte) 50,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0
        };

        private static byte[] BID = new byte[47]
      {
66,73,68,95,48,55,52,95,76,105,102,101,103,117,97,114,100,70,101,109,97,108,101,46,66,73,68,95,48,55,52,95,76,105,102,101,103,117,97,114,100,70,101,109,97,108,101
      };

        private static byte[] BID1 = new byte[47]
       {
66,73,68,95,48,50,57,95,82,101,116,114,111,71,114,101,121,46,66,73,68,95,48,50,57,95,82,101,116,114,111,71,114,101,121,0,0,0,0,0,0,0,0,0,0,0,0
       };

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            revert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, Mesh1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh);
                binaryWriter.Close();
                Settings.Default.BackupEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
            }


            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetlobby, BID1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BID);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID removed!";
            }




            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;


            bool WolfPakEnabled = Settings.Default.WolfPackEnabled;
            if (WolfPakEnabled)
            {
                MetroMessageBox.Show(this, "WolfPack" + this.actsomewhelse, this.error, MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
                return;
            }

            else if (Settings.Default.CloverEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Wolf Backbling" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            else if (Settings.Default.MaliceEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Malice Wings" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.LaceBEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Stitches Backbling" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }


            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, Mesh))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.BackupEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
            }

            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetlobby, BID))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID added!";
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
