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
    public partial class illusionruin : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public illusionruin()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Illusion Rune";
            bool enabled = Settings.Default.illudionruinensbled;
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

		private static byte[] Mesh = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			65,
			99,
			99,
			101,
			115,
			115,
			111,
			114,
			105,
			101,
			115,
			47,
			70,
			79,
			82,
			84,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			115,
			47,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			95,
			72,
			111,
			108,
			111,
			115,
			47,
			70,
			88,
			47,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			83,
			112,
			101,
			101,
			100,
			98,
			111,
			97,
			116,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			46,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			83,
			112,
			101,
			101,
			100,
			98,
			111,
			97,
			116,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			67
		};

		// Token: 0x04000074 RID: 116
		private static byte[] Mesh1 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			65,
			99,
			99,
			101,
			115,
			115,
			111,
			114,
			105,
			101,
			115,
			47,
			70,
			79,
			82,
			84,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			115,
			47,
			77,
			95,
			77,
			69,
			68,
			95,
			71,
			111,
			97,
			116,
			82,
			111,
			98,
			101,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			47,
			67,
			67,
			80,
			77,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			111,
			97,
			116,
			82,
			111,
			98,
			101,
			46,
			67,
			67,
			80,
			77,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			111,
			97,
			116,
			82,
			111,
			98,
			101,
			95,
			67,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		private static byte[] CID = new byte[23]
		{
			69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,66,111,116,104
		};

		private static byte[] CID1 = new byte[23]
		{
			69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,66,48,116,104
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

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";



			Stream fs024 = File.OpenRead(filePath1);
			foreach (long s in Researcher.FindPosition(fs024, 0, offsetback, Mesh1))
			{

				fs024.Close();
				BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
				binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
				binaryWrite.Write(Mesh);
				long headmeshset = s + 1155;
				binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
				binaryWrite.Write(CID);
				binaryWrite.Close();
				Settings.Default.illudionruinensbled = false;
				Settings.Default.Save();
				

			}





			revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] backbling removed!";
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";

		}

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.GalaxyDiscEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "galaxy disc" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();
			string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			Stream fs024 = File.OpenRead(filePath1);
			foreach (long s in Researcher.FindPosition(fs024, 0, offsetback, Mesh))
			{

				fs024.Close();
				BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
				binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
				binaryWrite.Write(Mesh1);
				long headmeshset = s + 1155;
				binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
				binaryWrite.Write(CID1);
				binaryWrite.Close();
				Settings.Default.illudionruinensbled = true;
				Settings.Default.Save();
				

			}



			revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] backbling added!";
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
    }
}
