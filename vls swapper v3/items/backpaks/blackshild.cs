using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.items.skins;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace vls_swapper_v3.items.backpaks
{
    public partial class blackshild : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public blackshild()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "BlackShield";
            bool enabled = Settings.Default.BlackShieldEnabled;
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

        private static byte[] Mesh = new byte[107]
          {
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
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 66,
(byte) 97,
(byte) 100,
(byte) 97,
(byte) 115,
(byte) 115,
(byte) 95,
(byte) 66,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 112,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 95,
(byte) 66,
(byte) 97,
(byte) 100,
(byte) 97,
(byte) 115,
(byte) 115,
(byte) 46,
(byte) 77,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 95,
(byte) 66,
(byte) 97,
(byte) 100,
(byte) 97,
(byte) 115,
(byte) 115,
          };
        private static byte[] Mesh1 = new byte[107]
        {
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
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 105,
(byte) 101,
(byte) 108,
(byte) 100,
(byte) 95,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 107,
(byte) 110,
(byte) 105,
(byte) 103,
(byte) 104,
(byte) 116,
(byte) 46,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 105,
(byte) 101,
(byte) 108,
(byte) 100,
(byte) 95,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 107,
(byte) 110,
(byte) 105,
(byte) 103,
(byte) 104,
(byte) 116,
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

        private static byte[] CID = new byte[45]
        {
      (byte) 66,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 55,
(byte) 53,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 66,
(byte) 97,
(byte) 100,
(byte) 97,
(byte) 115,
(byte) 115,
(byte) 46,
(byte) 66,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 55,
(byte) 53,
(byte) 95,
(byte) 84,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 97,
(byte) 108,
(byte) 66,
(byte) 97,
(byte) 100,
(byte) 97,
(byte) 115,
(byte) 115
        };
        private static byte[] CID1 = new byte[45]
        {
      (byte) 66,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 48,
(byte) 52,
(byte) 95,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 75,
(byte) 110,
(byte) 105,
(byte) 103,
(byte) 104,
(byte) 116,
(byte) 46,
(byte) 66,
(byte) 73,
(byte) 68,
(byte) 95,
(byte) 48,
(byte) 48,
(byte) 52,
(byte) 95,
(byte) 66,
(byte) 108,
(byte) 97,
(byte) 99,
(byte) 107,
(byte) 75,
(byte) 110,
(byte) 105,
(byte) 103,
(byte) 104,
(byte) 116,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0
        };

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            revert.Enabled = false;
            RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

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


            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, Mesh1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh);
                binaryWriter.Close();
                Settings.Default.BlackShieldEnabled = false;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
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

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";

            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Added!";
            }

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, Mesh))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.BlackShieldEnabled = true;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
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


    }
}
