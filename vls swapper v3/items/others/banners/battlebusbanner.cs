
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

namespace vls_swapper_v3.Emotes
{
    public partial class battlebusbanner : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public battlebusbanner()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "battle bus";
            bool enabled = Settings.Default.battlebusenabled;
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

        
             

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
			int offsetbanner = Settings.Default.offsetbanner;
			if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetbanner, bb2))
            {
                fs1.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(bb1);
                binaryWrite.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Banner removed!";
                Settings.Default.battlebusenabled = false;
                Settings.Default.Save();
            }

                    


            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           

           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
			int offsetbanner = Settings.Default.offsetbanner;
			convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetbanner, bb1))
            {
                fs1.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(bb2);
                binaryWrite.Close();
                Settings.Default.battlebusenabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Banner added!";
            }

           
          
            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;

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

		private static byte[] bb1 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			50,
			100,
			65,
			115,
			115,
			101,
			116,
			115,
			47,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			47,
			83,
			101,
			97,
			115,
			111,
			110,
			54,
			47,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			83,
			107,
			105,
			114,
			109,
			105,
			115,
			104,
			45,
			70,
			111,
			114,
			116,
			75,
			110,
			105,
			103,
			104,
			116,
			115,
			45,
			76,
			46,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			83,
			107,
			105,
			114,
			109,
			105,
			115,
			104,
			45,
			70,
			111,
			114,
			116,
			75,
			110,
			105,
			103,
			104,
			116,
			115,
			45,
			76,
			0,
			186,
			167,
			193,
			26,
			105,
			0,
			0,
			0,
			47,
			71,
			97,
			109,
			101,
			47,
			50,
			100,
			65,
			115,
			115,
			101,
			116,
			115,
			47,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			47,
			83,
			101,
			97,
			115,
			111,
			110,
			54,
			47,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			83,
			107,
			105,
			114,
			109,
			105,
			115,
			104,
			45,
			70,
			111,
			114,
			116,
			75,
			110,
			105,
			103,
			104,
			116,
			115,
			46,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			83,
			107,
			105,
			114,
			109,
			105,
			115,
			104,
			45,
			70,
			111,
			114,
			116,
			75,
			110,
			105,
			103,
			104,
			116,
			115
		};

		// Token: 0x04000224 RID: 548
		private static byte[] bb2 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			66,
			97,
			110,
			110,
			101,
			114,
			47,
			66,
			97,
			116,
			116,
			108,
			101,
			82,
			111,
			121,
			97,
			108,
			101,
			47,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			66,
			82,
			83,
			101,
			97,
			115,
			111,
			110,
			49,
			45,
			76,
			46,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			66,
			82,
			83,
			101,
			97,
			115,
			111,
			110,
			49,
			45,
			76,
			0,
			0,
			0,
			0,
			0,
			186,
			167,
			193,
			26,
			105,
			0,
			0,
			0,
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			66,
			97,
			110,
			110,
			101,
			114,
			47,
			66,
			97,
			116,
			116,
			108,
			101,
			82,
			111,
			121,
			97,
			108,
			101,
			47,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			66,
			82,
			83,
			101,
			97,
			115,
			111,
			110,
			49,
			46,
			84,
			45,
			66,
			97,
			110,
			110,
			101,
			114,
			115,
			45,
			73,
			99,
			111,
			110,
			115,
			45,
			66,
			82,
			83,
			101,
			97,
			115,
			111,
			110,
			49,
			0,
			0,
			0,
			0
		};
	}
}
