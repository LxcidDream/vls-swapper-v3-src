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
    public partial class galaxydisc : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public galaxydisc()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "GalaxyDisc";
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


        private static byte[] galaxy = new byte[]
        {
           047, 071, 097, 109, 101, 047, 065, 099, 099, 101, 115, 115, 111, 114, 105, 101, 115, 047, 070, 079, 082, 084, 095, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 066, 097, 099, 107, 112, 097, 099, 107, 095, 071, 097, 108, 105, 108, 101, 111, 095, 072, 111, 108, 111, 115, 047, 070, 088, 047, 067, 067, 080, 077, 095, 071, 097, 108, 105, 108, 101, 111, 083, 112, 101, 101, 100, 098, 111, 097, 116, 095, 066, 097, 099, 107, 112, 097, 099, 107, 046, 067, 067, 080, 077, 095, 071, 097, 108, 105, 108, 101, 111, 083, 112, 101, 101, 100, 098, 111, 097, 116, 095, 066, 097, 099, 107 ,112, 097, 099, 107, 095, 067
        };

        private static byte[] galaxy1 = new byte[]
        {
           047, 071, 097, 109, 101, 047, 065, 099, 099, 101, 115, 115, 111, 114, 105, 101, 115, 047, 070, 079, 082, 084, 095, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 077, 095, 077, 069, 068, 095, 067, 101, 108, 101, 115, 116, 105, 097, 108, 095, 066, 097, 099, 107, 112, 097, 099, 107, 047, 066, 080, 095, 066, 097, 099, 107, 112, 097, 099, 107, 095, 067, 101, 108, 101, 115, 116, 105, 097, 108, 046, 066, 080, 095, 066, 097, 099, 107, 112, 097, 099, 107, 095, 067, 101, 108, 101, 115, 116, 105, 097, 108, 095, 067, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] CID = new byte[]
        {
           047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 073, 116, 101, 109, 115, 047, 067, 111, 115, 109, 101, 116, 105, 099, 115, 047, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 066, 073, 068, 095, 052, 051, 048, 095, 071, 097, 108, 105, 108, 101, 111, 083, 112, 101, 101, 100, 066, 111, 097, 116, 095, 057, 082, 088, 069, 051, 046, 066, 073, 068, 095, 052, 051, 048, 095, 071, 097, 108, 105, 108, 101, 111, 083, 112, 101, 101, 100, 066, 111, 097, 116, 095, 057, 082, 088, 069, 051
        };

        private static byte[] CID1 = new byte[]
        {
           047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 073, 116, 101, 109, 115, 047, 067, 111, 115, 109, 101, 116, 105, 099, 115, 047, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 098, 105, 100, 095, 049, 051, 056, 095, 099, 101, 108, 101, 115, 116, 105, 097, 108, 046, 098, 105, 100, 095, 049, 051, 056, 095, 099, 101, 108, 101, 115, 116, 105, 097, 108, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;


            revert.Enabled = false;
            RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";




            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, galaxy1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(galaxy);
                binaryWriter.Close();
                Settings.Default.GalaxyDiscEnabled = false;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling Removed!";

            }
            Stream fs2 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetlobby, CID1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID);
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

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";




            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, galaxy))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(galaxy1);
                binaryWriter.Close();
                Settings.Default.GalaxyDiscEnabled = true;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling Added!";

            }
            Stream fs2 = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetlobby, CID))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Added!";

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
