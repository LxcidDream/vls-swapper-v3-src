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
    public partial class Ginger : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Ginger()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Ginger Gunner";  
            bool enabled = Settings.Default.GingerEnabled;
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

        private static byte[] Body = new byte[160]
        {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
        };
        private static byte[] Body1 = new byte[160]
        {
      47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,66,82,95,48,55,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,66,82,48,55,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,66,82,48,55,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };
        private static byte[] Hat = new byte[67]
        {
      47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54,46,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54
        };
        private static byte[] Hat1 = new byte[67]
        {
      47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,77,97,115,107,95,71,105,110,103,101,114,98,114,101,97,100,46,77,97,115,107,95,71,105,110,103,101,114,98,114,101,97,100,0,0,0,0,0,0
        };
        private static byte[] HeadMesh = new byte[126]
        {
      47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49
        };
        private static byte[] HeadMesh1 = new byte[126]
        {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,48,49,46,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,48,49,0,0,0,0
        };
        private static byte[] HeadMeshBP = new byte[154]
        {
      47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,46,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,95,67
        };
        private static byte[] HeadMeshBP1 = new byte[154]
        {
      47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,46,70,95,77,69,68,95,67,65,85,95,65,114,109,115,116,114,111,110,103,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,95,67,0,0,0,0
        };
        private static byte[] HeadTex = new byte[172]
        {
      (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 66,
(byte) 111,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
        };

        private static byte[] HeadTex1 = new byte[172]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,57
        };

        private static byte[] HatTex = new byte[78]
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
(byte) 72,
(byte) 97,
(byte) 116,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 72,
(byte) 97,
(byte) 116,
(byte) 95,
(byte) 70,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 46,
(byte) 72,
(byte) 97,
(byte) 116,
(byte) 95,
(byte) 70,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
        };
        private static byte[] HatTex1 = new byte[78];





        

        private static byte[] offsetr = new byte[39]
     {
             51,119,123,0,0,0,0,17,11,0,0,148,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,21,11,0,0,58,0,0,0
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

            string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";       


                Settings.Default.GingerEnabled = false;
                Settings.Default.Save();

            Stream stream = File.OpenRead(path1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 743L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                Settings.Default.GingerEnabled = false;
                Settings.Default.Save();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs023 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs023, 0, offsetskin2, offsetr))
                {
                    fs023.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    long headmeshset = s + 893;
                    long headmeshbpset = headmeshset + 257;
                    binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Ginger.HeadMesh);
                    RichTextBoxInfo.Text += "\n[LOG] HeadMesh removed!";
                    binaryWrite.BaseStream.Seek(headmeshbpset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Ginger.HeadMeshBP);
                    RichTextBoxInfo.Text += "\n[LOG] HeadMeshBP removed!";
                    binaryWrite.Close();
                }

                Stream fs025 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs025, 0, offsetskin2, Hat1))
                {
                    fs025.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Hat);
                    binaryWrite.Close();

                }

                Stream fs027 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs027, 0, offsetskin2, HatTex1))
                {
                    fs027.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HatTex);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Hat removed!";
                }

                Stream fs028 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs028, 0, offsetskin2, HeadTex1))
                {
                    fs028.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HeadTex);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Head removed!";
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

            if (Settings.Default.RenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ReconEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Expert" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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
                MetroFramework.MetroMessageBox.Show(this, "Checkered Renegade" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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
            else if (Settings.Default.BlueTeamLeaderEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "BlueTeamLeader" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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

            string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

          


                Settings.Default.GingerEnabled = true;
                Settings.Default.Save();

            

            Stream stream = File.OpenRead(path1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 743L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                Settings.Default.GingerEnabled = true;
                Settings.Default.Save();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs023 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs023, 0, offsetskin2, offsetr))
                {
                    fs023.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    long headmeshset = s + 893;
                    long headmeshbpset = headmeshset + 257;
                    binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Ginger.HeadMesh1);
                    RichTextBoxInfo.Text += "\n[LOG] HeadMesh added!";
                    binaryWrite.BaseStream.Seek(headmeshbpset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Ginger.HeadMeshBP1);
                    RichTextBoxInfo.Text += "\n[LOG] HeadMeshBP added!";
                    binaryWrite.Close();
                }

                Stream fs025 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs025, 0, offsetskin2, Hat))
                {
                    fs025.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Hat1);
                    binaryWrite.Close();

                }

                Stream fs027 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs027, 0, offsetskin2, HatTex))
                {
                    fs027.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HatTex1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Hat added!";
                }

                Stream fs028 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs028, 0, offsetskin2, HeadTex))
                {
                    fs028.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HeadTex1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Head added!";
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
