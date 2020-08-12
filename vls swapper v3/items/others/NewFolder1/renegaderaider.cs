using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using vls_swapper_v3;
using MaterialSkin.Controls;
using MaterialSkin;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;
using MetroFramework;

namespace vls_swapper_v3.items.others.NewFolder1
{
    public partial class renegaderaider : Form
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public renegaderaider()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "Backup Plan";
            bool enabled = Settings.Default.renegadecid;
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

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
			
			convert.Enabled = false;
			RichTextBoxInfo.Text += "[LOG] Starting...";
			int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetlobby, cid1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cid2);
                binaryWriter.Close();
                Settings.Default.renegadecid = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Skin Added!";
				RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
			}

			revert.Enabled = true;
			convert.Enabled = false;
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
			backgroundWorker1.RunWorkerAsync();
		}

		private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{

			revert.Enabled = false;
			RichTextBoxInfo.Text += "[LOG] Starting...";

			int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
			string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			Stream fs = File.OpenRead(filePath1);

			foreach (long s in Researcher.FindPosition(fs, 0, offsetlobby, cid2))
			{
				fs.Close();
				BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
				binaryWriter.Write(cid1);
				binaryWriter.Close();
				Settings.Default.renegadecid = false;
				Settings.Default.Save();
				RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Skin removed!";
				RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
			}

			revert.Enabled = false;
			convert.Enabled = true;
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
			backgroundWorker2.RunWorkerAsync();
		}

		private static byte[] cid2 = new byte[]
		{
			67,
			73,
			68,
			95,
			48,
			50,
			56,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			67,
			111,
			109,
			109,
			97,
			110,
			100,
			111,
			95,
			70,
			46,
			67,
			73,
			68,
			95,
			48,
			50,
			56,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			67,
			111,
			109,
			109,
			97,
			110,
			100,
			111,
			95,
			70,
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

		private static byte[] cid1 = new byte[]
		{
			67,
			73,
			68,
			95,
			50,
			56,
			55,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			67,
			111,
			109,
			109,
			97,
			110,
			100,
			111,
			95,
			77,
			95,
			65,
			114,
			99,
			116,
			105,
			99,
			83,
			110,
			105,
			112,
			101,
			114,
			46,
			67,
			73,
			68,
			95,
			50,
			56,
			55,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			67,
			111,
			109,
			109,
			97,
			110,
			100,
			111,
			95,
			77,
			95,
			65,
			114,
			99,
			116,
			105,
			99,
			83,
			110,
			105,
			112,
			101,
			114
		};

		
	}
}
