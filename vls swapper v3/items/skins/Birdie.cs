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
    public partial class Birdie : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Birdie()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Birdie";
            bool enabled = Settings.Default.BirdieEnabled;
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

        private static byte[] Body = new byte[122]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,46,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72
        };

        private static byte[] Body1 = new byte[122]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,71,111,108,102,47,77,101,115,104,101,115,47,70,95,77,69,68,95,71,111,108,102,46,70,95,77,69,68,95,71,111,108,102,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] BodyAnim = new byte[175]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,66,80,46,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,66,80,95,67
        };

        private static byte[] BodyAnim1 = new byte[175]
        {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,71,111,108,102,47,77,101,115,104,101,115,47,70,95,77,69,68,95,71,111,108,102,95,65,110,105,109,66,112,46,70,95,77,69,68,95,71,111,108,102,95,65,110,105,109,66,112,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] Head = new byte[176]
       {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,69,121,101,108,97,115,104,101,115,95,69,120,112,111,114,116,46,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,69,121,101,108,97,115,104,101,115,95,69,120,112,111,114,116,95,69,89,69,76,65,83,72,69,83,95,77,69,83,72
       };

        private static byte[] Head1 = new byte[176]
      {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,71,111,108,102,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,71,111,108,102,95,70,97,99,101,65,99,99,46,70,95,77,69,68,95,71,111,108,102,95,70,97,99,101,65,99,99,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
      };

        private static byte[] HeadNull = new byte[118]
    {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,100,46,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,100
    };

        private static byte[] HeadNull1 = new byte[118]
 {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,49,46,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,49
 };

        private static byte[] HeadSkel = new byte[167]
{
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,108,97,115,104,101,95,83,107,101,108,101,116,111,110,95,65,66,80,46,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,108,97,115,104,101,95,83,107,101,108,101,116,111,110,95,65,66,80,95,67
};

        private static byte[] HeadSkel1 = new byte[167]
{
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,71,111,108,102,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,71,111,108,102,95,70,97,99,101,65,99,99,95,65,110,105,109,66,112,46,70,95,77,69,68,95,71,111,108,102,95,70,97,99,101,65,99,99,95,65,110,105,109,66,112,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
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

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";



            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 976L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body 1/2 removed!";

            }

            Stream fs2 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyAnim1))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyAnim);
                    binaryWriter.Close();
                Settings.Default.BirdieEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 Removed!";
                }

                Stream fs4 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head1))
                {
                    fs4.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/3 Removed!";
                }

                Stream fs5 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, HeadNull1))
                {
                    fs5.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadNull);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/3 Removed!";
                }

                Stream fs8 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs8, 0, offsetskin2, HeadSkel1))
                {
                    fs8.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadSkel);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 3/3 Removed!";
                
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

            if (Settings.Default.LaceEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Lace" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.VelocityEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Velocity" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.BoltEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Bolt" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SynapseEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Synapse" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SunbirdEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Sunbird" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.CalistoEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Callisto" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.DoublecrossEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Doublecross" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.IkonikFableEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ikonik[Using Fable]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.BracerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Bracer" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SkullyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Skully" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.VolleyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Volley Girl" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.PunchyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Moxie" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.FacetEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Facet" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";




            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 976L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body 1/2 added!";

            }

            Stream fs2 = File.OpenRead(filePath1);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyAnim))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyAnim1);
                    binaryWriter.Close();
                Settings.Default.BirdieEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 2/2 added!";
                }

                Stream fs4 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head))
                {
                    fs4.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Head1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/3 added!";
                }

                Stream fs5 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, HeadNull))
                {
                    fs5.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadNull1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/3 added!";
                }

                Stream fs8 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs8, 0, offsetskin2, HeadSkel))
                {
                    fs8.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(HeadSkel1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 3/3 added!";
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
