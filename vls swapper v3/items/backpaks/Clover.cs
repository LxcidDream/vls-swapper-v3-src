using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using vls_swapper_v3;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;

namespace vls_swapper_v3.Backblings
{
    public partial class Clover : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Clover()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Rainbow Clover";
            bool enabled = Settings.Default.CloverEnabled;
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
          47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,95,77,69,68,95,83,117,109,109,101,114,72,101,114,111,101,115,95,85,110,105,99,111,114,110,47,77,101,115,104,101,115,47,66,97,99,107,112,97,99,107,95,83,117,109,109,101,114,95,72,101,114,111,101,115,95,85,110,105,99,111,114,110,95,69,120,112,111,114,116,46,66,97,99,107,112,97,99,107,95,83,117,109,109,101,114,95,72,101,114,111,101,115,95,85,110,105,99,111,114,110,95,69,120,112,111,114,116
          };
        private static byte[] Mesh1 = new byte[142]
        {
          47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,95,77,69,68,95,76,117,99,107,121,95,82,105,100,101,114,95,66,97,99,107,112,97,99,107,47,77,101,115,104,101,115,47,77,95,77,69,68,95,76,117,99,107,121,95,82,105,100,101,114,95,66,97,99,107,112,97,99,107,46,77,95,77,69,68,95,76,117,99,107,121,95,82,105,100,101,114,95,66,97,99,107,112,97,99,107,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };
        private static byte[] MeshBP = new byte[104]
        {
          47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,95,77,69,68,95,83,117,109,109,101,114,72,101,114,111,101,115,95,85,110,105,99,111,114,110,47,77,101,115,104,101,115,47,66,97,99,107,112,97,99,107,95,83,117,109,109,101,114,95,72,101,114,111,101,115,95,85,110,105,99,111,114,110,95,69,120,112,111,114,116
        };
        private static byte[] MeshBP1 = new byte[104]
        {
          71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,95,77,69,68,95,76,117,99,107,121,95,82,105,100,101,114,95,66,97,99,107,112,97,99,107,47,77,101,115,104,101,115,47,77,95,77,69,68,95,76,117,99,107,121,95,82,105,100,101,114,95,66,97,99,107,112,97,99,107,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] cid = new byte[]
        {
            047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 073, 116, 101, 109, 115, 047, 067, 111, 115, 109, 101, 116, 105, 099, 115, 047, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 066, 073, 068, 095, 048, 055, 052, 095, 076, 105, 102, 101, 103, 117, 097, 114, 100, 070, 101, 109, 097, 108, 101, 046, 066, 073, 068, 095, 048, 055, 052, 095, 076, 105, 102, 101, 103, 117, 097, 114, 100, 070, 101, 109, 097, 108, 101
        };

        private static byte[] cid1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 073, 116, 101, 109, 115, 047, 067, 111, 115, 109, 101, 116, 105, 099, 115, 047, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 098, 105, 100, 095, 050, 050, 057, 095, 108, 117, 099, 107, 121, 114, 105, 100, 101, 114, 109, 097, 108, 101, 046, 098, 105, 100, 095, 050, 050, 057, 095, 108, 117, 099, 107, 121, 114, 105, 100, 101, 114, 109, 097, 108, 101, 000, 000
        };

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            revert.Enabled = false;
             RichTextBoxInfo.Text += "\n[LOG] Starting...";

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
                Settings.Default.CloverEnabled = false;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 removed!";

            }

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetback, MeshBP1))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));              
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(MeshBP);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 removed!";
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
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            bool WolfPakEnabled = Settings.Default.WolfPackEnabled;
            if (WolfPakEnabled)
            {
                MetroMessageBox.Show(this, "WolfPack" + this.actsomewhelse, this.error, MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
                return;
            }

            else if (Settings.Default.BackupEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Wolf Backbling" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;
             RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, Mesh))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.CloverEnabled = true;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 added!";

            }

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetback, MeshBP))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(MeshBP1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 added!";
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
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
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
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
            revert1Bytes.RunWorkerAsync();
        }

        private static byte[] BID = new byte[]
        {
            66,
            73,
            68,
            95,
            48,
            55,
            52,
            95,
            76,
            105,
            102,
            101,
            103,
            117,
            97,
            114,
            100,
            70,
            101,
            109,
            97,
            108,
            101,
            46,
            66,
            73,
            68,
            95,
            48,
            55,
            52,
            95,
            76,
            105,
            102,
            101,
            103,
            117,
            97,
            114,
            100,
            70,
            101,
            109,
            97,
            108,
            101
        };

        
        private static byte[] BID1 = new byte[]
        {
            66,
            73,
            68,
            95,
            50,
            50,
            57,
            95,
            76,
            117,
            99,
            107,
            121,
            82,
            105,
            100,
            101,
            114,
            77,
            97,
            108,
            101,
            46,
            66,
            73,
            68,
            95,
            50,
            50,
            57,
            95,
            76,
            117,
            99,
            107,
            121,
            82,
            105,
            100,
            101,
            114,
            77,
            97,
            108,
            101,
            0,
            0
        };
    }
}
