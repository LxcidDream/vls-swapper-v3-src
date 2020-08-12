
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
    public partial class DemiSkin : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public DemiSkin()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            MessageBox.Show("This skin uses normal Onesie, be sure to select this style before swapping the Demi!");
            this.Text = "Demi";
            bool enabled = Settings.Default.DemiSkinEnabled;
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

        private static byte[] Body = new byte[127]
          {
             47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,47,77,101,115,104,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,66,111,100,121,46,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,66,111,100,121
          };

        private static byte[] Body1 = new byte[127]
          {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,47,77,101,115,104,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,46,70,95,77,69,68,95,77,97,115,97,107,111,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
          };

        private static byte[] BodyMesh = new byte[143]
          {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,47,77,101,115,104,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,66,111,100,121,95,65,110,105,109,66,80,46,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,66,111,100,121,95,65,110,105,109,66,80,95,67
          };

        private static byte[] BodyMesh1 = new byte[143]
          {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,47,77,101,115,104,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,95,65,110,105,109,66,80,46,70,95,77,69,68,95,77,97,115,97,107,111,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
          };

        private static byte[] Head = new byte[133]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,72,101,97,100,46,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,72,101,97,100
        };

        private static byte[] Head1 = new byte[133]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,77,97,115,97,107,111,95,70,97,99,101,65,99,99,46,70,95,77,69,68,95,77,97,115,97,107,111,95,70,97,99,101,65,99,99,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] HeadMesh = new byte[149]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,72,101,97,100,95,65,110,105,109,66,80,46,70,95,77,69,68,95,68,117,114,114,98,117,114,103,101,114,80,74,115,95,48,49,95,72,101,97,100,95,65,110,105,109,66,80,95,67
        };

        private static byte[] HeadMesh1 = new byte[149]
       {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,77,97,115,97,107,111,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,77,97,115,97,107,111,95,70,97,99,101,65,99,99,95,65,110,105,109,66,108,117,101,112,114,105,110,116,46,70,95,77,69,68,95,77,97,115,97,107,111,95,70,97,99,101,65,99,99,95,65,110,105,109,66,108,117,101,112,114,105,110,116,95,67,0,0,0,0,0,0,0
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

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            Stream stream = File.OpenRead(filePath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 940L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body 1/2 removed!";
            }

            Stream fs2 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyMesh1))
                {
                    fs2.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(BodyMesh);
                    binaryWrite.Close();
                Settings.Default.DemiSkinEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 removed!";
                }

                Stream fs3 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin2, Head1))
                {
                    fs3.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Head);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 removed!";
                }

                Stream fs4 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, HeadMesh1))
                {
                    fs4.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HeadMesh);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 removed!";
                }
            

            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";


            Stream stream = File.OpenRead(filePath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, BodyMesh))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(BodyMesh1);
                long offset = num + 940L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
                richTextBoxInfo3.Text += "\n[LOG] Body 1/2 added!";
            }

            Stream fs2 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyMesh))
                {
                    fs2.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(BodyMesh1);
                    binaryWrite.Close();
                Settings.Default.DemiSkinEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 Added!";
                }

                Stream fs3 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin2, Head))
                {
                    fs3.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Head1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 Added!";
                }

                Stream fs4 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, HeadMesh))
                {
                    fs4.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(HeadMesh1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 Added!";
                }

            
            revert.Enabled = true;

            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
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

        private void DemiSkin_Load(object sender, EventArgs e)
        {

        }
    }
}
