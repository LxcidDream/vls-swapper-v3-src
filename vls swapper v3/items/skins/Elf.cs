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

namespace vls_swapper_v3.Skins
{
    public partial class Elf : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Elf()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Codename E.L.F";
            bool enabled = Settings.Default.ElfEnabled;
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
(byte) 77,
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
(byte) 77,
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
(byte) 52,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 66,
(byte) 82,
(byte) 95,
(byte) 52,
(byte) 51,
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
(byte) 77,
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
(byte) 52,
(byte) 95,
(byte) 66,
(byte) 82,
(byte) 48,
(byte) 52,
(byte) 51,
(byte) 46,
(byte) 77,
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
(byte) 52,
(byte) 95,
(byte) 66,
(byte) 82,
(byte) 48,
(byte) 52,
(byte) 51
     };
        private static byte[] Body1 = new byte[127]
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
(byte) 77,
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
(byte) 77,
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
(byte) 52,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 66,
(byte) 82,
(byte) 95,
(byte) 69,
(byte) 108,
(byte) 102,
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
(byte) 77,
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
(byte) 69,
(byte) 108,
(byte) 102,
(byte) 46,
(byte) 77,
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
(byte) 69,
(byte) 108,
(byte) 102,
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
        private static byte[] Hat = new byte[81]
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
(byte) 72,
(byte) 101,
(byte) 108,
(byte) 109,
(byte) 101,
(byte) 116,
(byte) 95,
(byte) 66,
(byte) 82,
(byte) 48,
(byte) 52,
(byte) 51,
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
(byte) 72,
(byte) 101,
(byte) 108,
(byte) 109,
(byte) 101,
(byte) 116,
(byte) 95,
(byte) 66,
(byte) 82,
(byte) 48,
(byte) 52,
(byte) 51
        };
        private static byte[] Hat1 = new byte[81]
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
(byte) 69,
(byte) 108,
(byte) 102,
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
(byte) 69,
(byte) 108,
(byte) 102,
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

        private static byte[] CIDY = new byte[34]
        {
      (byte) 67,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 57,
(byte) 48,
(byte) 95,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
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
(byte) 77,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108
        };
        private static byte[] CIDY1 = new byte[34]
        {
      (byte) 67,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 57,
(byte) 48,
(byte) 95,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
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
(byte) 77,
(byte) 95,
(byte) 89,
(byte) 89,
(byte) 89,
(byte) 89,
(byte) 89,
(byte) 89,
(byte) 89,
(byte) 89
        };

        private static byte[] CID = new byte[36]
        {
      (byte) 67,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 53,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
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
(byte) 77,
(byte) 95,
(byte) 72,
(byte) 111,
(byte) 108,
(byte) 105,
(byte) 100,
(byte) 97,
(byte) 121,
(byte) 69,
(byte) 108,
(byte) 102
        };
        private static byte[] CID1 = new byte[36]
        {
      (byte) 67,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 57,
(byte) 48,
(byte) 95,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
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
(byte) 77,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 0,
(byte) 0
        };

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

             RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                binaryWriter.Close();
                Settings.Default.ElfEnabled = false;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body removed!";
            }

            Stream fs2 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Hat1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat);
                binaryWriter.Close();
            }

            Stream fs598 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs598, 0, offsetskin2, Hat1))
            {
                fs598.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat removed!";
            }

			Stream fs4 = File.OpenRead(filePath);

			foreach (long s in Researcher.FindPosition(fs4, 0, offsetlobby, byte_5))
			{
				fs4.Close();
				BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
				binaryWriter.Write(byte_4);
				binaryWriter.Close();
				RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
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

            convert.Enabled = false;

             RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                binaryWriter.Close();
                Settings.Default.ElfEnabled = true;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body added!";
            }

            Stream fs9 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetskin2, Hat))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat1);
                binaryWriter.Close();
            }

            Stream fs2 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Hat))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat added!";
            }

			Stream fs4 = File.OpenRead(filePath);

			foreach (long s in Researcher.FindPosition(fs4, 0, offsetlobby, byte_4))
			{
				fs4.Close();
				BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
				binaryWriter.Write(byte_5);
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
            else
            {

               CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
                change1Bytes.RunWorkerAsync();
            }
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

		private static byte[] byte_4 = new byte[]
	{
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		66,
		82,
		95,
		69,
		108,
		102,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		69,
		108,
		102,
		46,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		69,
		108,
		102,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0
	};

		// Token: 0x04000B61 RID: 2913
		private static byte[] byte_5 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		66,
		82,
		95,
		52,
		51,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		95,
		66,
		82,
		48,
		52,
		51,
		46,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		95,
		66,
		82,
		48,
		52,
		51
		};

	}
}
