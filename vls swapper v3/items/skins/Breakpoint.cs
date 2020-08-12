using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using vls_swapper_v3;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Skins
{
    public partial class Breakpoint : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Breakpoint()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Breakpoint";
            bool enabled = Settings.Default.BreakpointEnabled;
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

        private static byte[] Body = new byte[124]
     {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103
     };

        private static byte[] Body1 = new byte[124]
   {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,47,77,101,115,104,101,115,47,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,66,111,100,121,95,77,69,83,72,46,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,66,111,100,121,95,77,69,83,72
   };

        private static byte[] BodyPart = new byte[140]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,65,110,105,109,66,80,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,65,110,105,109,66,80,95,67
};

        private static byte[] BodyPart1 = new byte[140]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,97,115,101,47,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,46,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] BodyFire = new byte[152]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,83,107,105,110,115,47,70,105,114,101,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,66,111,100,121,95,118,50,46,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,66,111,100,121,95,118,50
};

        private static byte[] BodyFire1 = new byte[152]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,47,83,107,105,110,115,47,78,101,111,110,76,105,110,101,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,95,78,101,111,110,76,105,110,101,115,95,66,111,100,121,46,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,95,78,101,111,110,76,105,110,101,115,95,66,111,100,121,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] Head = new byte[140]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,72,101,97,100,95,48,49
};
        private static byte[] Head1 = new byte[140]
{
47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,47,77,101,115,104,101,115,47,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,72,65,84,95,77,69,83,72,46,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,72,65,84,95,77,69,83,72,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] HeadBP = new byte[156]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,68,97,114,107,86,105,107,105,110,103,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67
};
        private static byte[] HeadBP1 = new byte[156]
{
47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,47,77,101,115,104,101,115,47,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,72,65,84,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,108,117,101,112,114,105,110,116,46,70,95,77,69,68,95,66,108,117,101,95,66,97,100,97,115,115,95,72,65,84,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,108,117,101,112,114,105,110,116,95,67,0,0,0,0,0,0,0,0
};
        private static byte[] FireHair = new byte[146]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,83,107,105,110,115,47,70,105,114,101,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,97,105,114,46,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,97,105,114
};
        private static byte[] FireHair1 = new byte[146]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,83,107,105,110,115,47,70,105,114,101,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,97,105,114,46,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,50,105,114
};
        private static byte[] HeadMat = new byte[146]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,68,97,114,107,95,86,105,107,105,110,103,95,48,49,47,83,107,105,110,115,47,70,105,114,101,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,101,97,100,46,77,73,95,70,95,77,69,68,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,72,101,97,100
};
        private static byte[] HeadMat1 = new byte[146]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,66,108,117,101,66,97,100,97,115,115,47,83,107,105,110,115,47,78,101,111,110,76,105,110,101,115,47,70,95,77,69,68,95,78,101,111,110,76,105,110,101,115,95,72,101,97,100,46,70,95,77,69,68,95,78,101,111,110,76,105,110,101,115,95,72,101,97,100,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] Effect = new byte[126]
{
47,71,97,109,101,47,69,102,102,101,99,116,115,47,70,111,114,116,95,69,102,102,101,99,116,115,47,69,102,102,101,99,116,115,47,67,104,97,114,97,99,116,101,114,115,47,65,116,104,101,110,97,95,80,97,114,116,115,47,69,121,101,84,114,97,105,108,115,47,67,67,80,77,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,70,101,109,97,108,101,46,67,67,80,77,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,70,101,109,97,108,101,95,67
};
        private static byte[] Effect1 = new byte[126]
{
47,71,97,109,101,47,69,102,102,101,99,116,115,47,70,111,114,116,95,69,102,102,101,99,116,115,47,69,102,102,101,99,116,115,47,67,104,97,114,97,99,116,101,114,115,47,65,116,104,101,110,97,95,80,97,114,116,115,47,69,121,101,84,114,97,105,108,115,47,67,67,80,77,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,70,101,109,97,108,101,46,67,67,80,77,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,95,70,101,109,97,108,101,95,90
};
        private static byte[] CID = new byte[123]
{
   47,71,97,109,101,47,65,116,104,101,110,97,47,73,116,101,109,115,47,67,111,115,109,101,116,105,99,115,47,67,104,97,114,97,99,116,101,114,115,47,67,73,68,95,51,56,48,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101,46,67,73,68,95,51,56,48,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,68,97,114,107,86,105,107,105,110,103,95,70,105,114,101
};
        private static byte[] CID1 = new byte[123]
{
47,71,97,109,101,47,65,116,104,101,110,97,47,73,116,101,109,115,47,67,111,115,109,101,116,105,99,115,47,67,104,97,114,97,99,116,101,114,115,47,67,73,68,95,52,50,57,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,78,101,111,110,76,105,110,101,115,46,67,73,68,95,52,50,57,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,78,101,111,110,76,105,110,101,115,0,0,0,0,0,0,0,0,0,0,0,0
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

            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID1))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
            }


            Stream fs = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body1))
                {
                    fs.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Body);
                    binaryWriter.Close();
                    Settings.Default.BreakpointEnabled = false;
                    Settings.Default.Save();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 1/5 removed!";
                }

                Stream fs1 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin1, Body1))
                {
                    fs1.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Body);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/5 removed!";
                }

                Stream fs2 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyPart1))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyPart);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 3/5 removed!";
                }

                Stream fs22 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs22, 0, offsetskin1, BodyPart1))
                {
                    fs22.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyPart);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 4/5 removed!";
                }

                Stream fs3 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin1, BodyFire1))
                {
                    fs3.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyFire);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 5/5 removed!";
                }

                Stream fs11 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs11, 0, offsetskin2, Head1))
                {
                    fs11.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/6 removed!";
                }

                Stream fs4 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head1))
                {
                    fs4.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/6 removed!";
                }

                Stream fs44 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs44, 0, offsetskin2, HeadBP1))
                {
                    fs44.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadBP);
                    binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 3/6 removed!";
            }              

                Stream fs6 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs6, 0, offsetskin2, HeadBP1))
                {
                    fs6.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadBP);
                    binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 4/6 removed!";
            }

                Stream fs7 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs7, 0, offsetskin2, FireHair1))
                {
                    fs7.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(FireHair);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 5/6 removed!";
                }

                Stream fs9 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs9, 0, offsetskin2, HeadMat1))
                {
                    fs9.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadMat);
                    binaryWriter.Close();
               
                }

                Stream fs99 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs99, 0, offsetskin2, HeadMat1))
                {
                    fs99.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadMat);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 6/6 removed!";
                }

            Stream fs8 = File.OpenRead(path);

                foreach (long s in Researcher.FindPosition(fs8, 0, offsetskin2, Effect1))
                {
                    fs8.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Effect);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Effect removed!";
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

            

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID added!";
            }


            Stream fs = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                binaryWriter.Close();
                Settings.Default.BreakpointEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 1/5 added!";
            }

            Stream fs1 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin1, Body))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/5 added!";
            }

            Stream fs2 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyPart))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyPart1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 3/5 added!";
            }

            Stream fs22 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs22, 0, offsetskin1, BodyPart))
            {
                fs22.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyPart1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 4/5 added!";
            }

            Stream fs3 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin1, BodyFire))
            {
                fs3.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyFire1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 5/5 added!";
            }

            Stream fs11 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs11, 0, offsetskin2, Head))
            {
                fs11.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/6 added!";
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/6 added!";
            }

            Stream fs44 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs44, 0, offsetskin2, HeadBP))
            {
                fs44.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadBP1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 3/6 added!";
            }

            Stream fs6 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs6, 0, offsetskin2, HeadBP))
            {
                fs6.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadBP1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 4/6 added!";
            }

            Stream fs7 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs7, 0, offsetskin2, FireHair))
            {
                fs7.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(FireHair1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 5/6 added!";
            }

            Stream fs9 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetskin2, HeadMat))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadMat1);
                binaryWriter.Close();

            }

            Stream fs99 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs99, 0, offsetskin2, HeadMat))
            {
                fs99.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadMat1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 6/6 added!";
            }

            Stream fs8 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs8, 0, offsetskin2, Effect))
            {
                fs8.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Effect1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Effect added!";
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

        private void RichTextBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
