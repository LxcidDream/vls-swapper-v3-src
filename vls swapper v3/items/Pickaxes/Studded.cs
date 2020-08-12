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

namespace vls_swapper_v3.Picks
{
    public partial class Studded : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Studded()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Studded";
            bool enabled = Settings.Default.StuddedEnabled;
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

        private static byte[] Mesh = new byte[111]
          {
      (byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 79,
(byte) 82,
(byte) 84,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 108,
(byte) 101,
(byte) 101,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 46,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101
          };
        private static byte[] Mesh1 = new byte[111]
        {
      (byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 79,
(byte) 82,
(byte) 84,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 108,
(byte) 101,
(byte) 101,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 46,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
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

        private static byte[] IconL = new byte[126]
        {
      (byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 45,
(byte) 76,
(byte) 46,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 45,
(byte) 76
        };
        private static byte[] IconL1 = new byte[126]
        {
      (byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 45,
(byte) 76,
(byte) 46,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 45,
(byte) 76,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] IconS = new byte[122]
        {
      (byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 46,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
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
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101
        };
        private static byte[] Icon1 = new byte[122]
        {
      (byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 46,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 112,
(byte) 68,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 114,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
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
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetpick, Mesh1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh);
                binaryWriter.Close();
                Settings.Default.StuddedEnabled = false;
                Settings.Default.Save();
                 RichTextBoxInfo.Text += "\n[LOG] Mesh removed!";
            }        


            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetpick, Icon1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(IconS);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Icons removed!";
            }

            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text += "\n[LOG] Done!";

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            if (Settings.Default.ScytheEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Scythe" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            
            else if (Settings.Default.SqueakEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Pick Squeak" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            
            else if (Settings.Default.VisionEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Vision" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            

            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetpick, Mesh))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.StuddedEnabled = true;
                Settings.Default.Save();
                 RichTextBoxInfo.Text += "\n[LOG] Mesh added!";
            }           

            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetpick, IconS))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Icon1);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Icons added!";
            }

            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
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
