using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Skins
{
    public partial class BlueTeamLeader : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public BlueTeamLeader()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "BlueTeamLeader";
            bool enabled = Settings.Default.BlueTeamLeaderEnabled;
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

            change1Bytes.DoWork += ChangeBytes_DoWork;
            revert1Bytes.DoWork += RevertBytes_DoWork;
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

        private static byte[] Head = new byte[172]
     {
    47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,49
        };

        private static byte[] Head1 = new byte[172]
   {
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,101,100,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
      };

        private static byte[] Hat = new byte[78]
{
   47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,97,116,101,114,105,97,108,115,47,72,97,116,95,70,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,72,97,116,95,70,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
   };

        private static byte[] Hat1 = new byte[78]
{
 47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,97,116,101,114,105,97,108,115,47,72,97,116,95,70,95,67,111,109,109,97,110,100,111,95,48,51,95,86,48,49,46,72,97,116,95,70,95,67,111,109,109,97,110,100,111,95,48,51,95,86,48,49,0,0
};

        private static byte[] HatMesh = new byte[67]
{
  47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54,46,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54
};

        private static byte[] HatMesh1 = new byte[67]
{
 47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,48,51,46,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,48,51,0,0
};

        private static byte[] Body = new byte[160]
{
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
};

        private static byte[] Body1 = new byte[160]
{
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,66,82,95,83,111,110,121,69,120,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,83,111,110,121,69,120,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,83,111,110,121,69,120,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] Color = new byte[98]
{
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
};
        private static byte[] Color1 = new byte[98]
{
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,49,50,51,52,53
};
        private static byte[] CID = new byte[]
        {
            69,
            70,
            111,
            114,
            116,
            67,
            117,
            115,
            116,
            111,
            109,
            71,
            101,
            110,
            100,
            101,
            114,
            58,
            58,
            70,
            101,
            109,
            97,
            108,
            101
        };

        // Token: 0x0400043F RID: 1087
        private static byte[] CID1 = new byte[]
        {
            69,
            70,
            111,
            114,
            116,
            67,
            117,
            115,
            116,
            111,
            109,
            71,
            101,
            110,
            100,
            101,
            114,
            58,
            58,
            70,
            101,
            109,
            97,
            49,
            101
        };



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

            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";

            Stream stream = File.OpenRead(bodypath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 743L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs598 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs598, 0, offsetskin2, Hat1))
                {
                    fs598.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Hat);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat 1/2 removed!";
                    Settings.Default.IkonikOnesieEnabled = false;
                    Settings.Default.Save();
                }

                Stream fs5988 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs5988, 0, offsetskin2, HatMesh1))
                {
                    fs5988.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HatMesh);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat 2/2 removed!";
                }

                Stream fs59888 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs59888, 0, offsetskin2, Head1))
                {
                    fs59888.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head removed!";
                }

                Stream fs598888 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs598888, 0, offsetskin2, Color1))
                {
                    fs598888.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Color);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Color removed!";
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

            if (Settings.Default.ReconEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Expert" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.GingerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ginger Gunner" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.NogOpsEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Nog Ops" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ReconSpeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Specialist" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            else if (Settings.Default.CheckRenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider[Checkered]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.HonorEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Wonder Skin" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SurvivalEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Survival Specialist" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ScarletDefenderEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Scarlet Defender" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";

            Stream stream = File.OpenRead(bodypath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 743L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs598 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs598, 0, offsetskin2, Hat))
                {
                    fs598.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Hat1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat 1/2 added!";
                Settings.Default.IkonikOnesieEnabled = true;
                Settings.Default.Save();
            }

                Stream fs5988 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs5988, 0, offsetskin2, HatMesh))
                {
                    fs5988.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HatMesh1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat 2/2 added!";
                }

                Stream fs59888 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs59888, 0, offsetskin2, Head))
                {
                    fs59888.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head added!";
                }

                Stream fs598888 = File.OpenRead(headpath);

                foreach (long s in Researcher.FindPosition(fs598888, 0, offsetskin2, Color))
                {
                    fs598888.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Color1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Color added!";
                }
            

            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

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
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

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
