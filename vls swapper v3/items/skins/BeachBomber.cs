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
    public partial class BeachBomber : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public BeachBomber()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Beach Bomber";
            bool enabled = Settings.Default.BeachEnabled;
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

        private static byte[] Body = new byte[141]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,46,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110
};
        private static byte[] Body1 = new byte[141]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,47,77,101,115,104,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,46,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] BodyPart = new byte[157]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,95,65,110,105,109,66,112,46,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,95,65,110,105,109,66,112,95,67
};
        private static byte[] BodyPart1 = new byte[157]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,47,77,101,115,104,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,65,110,105,109,66,80,46,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] Head = new byte[163]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99,46,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99
};
        private static byte[] Head1 = new byte[163]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,72,101,97,100,46,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,72,101,97,100,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] HeadPart = new byte[169]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,95,72,117,110,116,101,114,95,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,84,114,101,97,115,117,114,101,72,117,110,116,101,114,70,97,115,104,95,70,97,99,101,65,99,99,95,65,110,105,109,66,112,46,70,95,77,69,68,95,84,114,101,97,115,117,114,101,72,117,110,116,101,114,70,97,115,104,95,70,97,99,101,65,99,99,95,65,110,105,109,66,112,95,67
};
        private static byte[] HeadPart1 = new byte[169]
{
   47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,72,101,97,100,95,65,110,105,109,66,80,46,70,95,77,69,68,95,66,114,105,116,101,95,66,111,109,98,101,114,95,83,117,109,109,101,114,95,72,101,97,100,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0
};
        
        private static byte[] HeadMat = new byte[141]
{
  47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,65,83,78,95,83,97,114,97,104,95,72,101,97,100,95,48,49,47,83,107,105,110,115,47,84,114,101,97,115,117,114,101,72,117,110,116,101,114,70,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,84,72,70,97,115,104,105,111,110,95,72,101,97,100,46,70,95,77,69,68,95,84,72,70,97,115,104,105,111,110,95,72,101,97,100
};
        private static byte[] HeadMat1 = new byte[141]
{
  47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,101,100,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,76,117,99,104,97,100,111,114,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,95,76,117,99,104,97,100,111,114,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,95,76,117,99,104,97,100,111,114,0
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

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 988L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body 1/2 removed!";
            }

            Stream fs1 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin1, BodyPart1))
                {
                    fs1.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyPart);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 removed!";
                }

                Stream fs2 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Head1))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 removed!";
                }

                Stream fs22 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs22, 0, offsetskin2, HeadPart1))
                {
                    fs22.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadPart);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 removed!";
                }

            Stream fs222 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs222, 0, offsetskin2, HeadMat1))
            {
                fs222.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadMat);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Material removed!";
            }



            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";

        }

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

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (Settings.Default.SparkplugEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Sparkplug" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RubyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ruby" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.CrystalEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Crystal" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RileyAuraEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Riley[Using Aura]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.HazeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Haze" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RustlerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Rustler" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }


            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 988L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body 1/2 added!";
            }

            Stream fs1 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin1, BodyPart))
                {
                    fs1.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyPart1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 added!";
                }

                Stream fs2 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Head))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 added!";
                }

                Stream fs22 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs22, 0, offsetskin2, HeadPart))
                {
                    fs22.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadPart1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 added!";
                }

            Stream fs222 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs222, 0, offsetskin2, HeadMat))
            {
                fs222.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadMat1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Material added!";
            }



            revert.Enabled = true;
            convert.Enabled = false;
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
    }
}
