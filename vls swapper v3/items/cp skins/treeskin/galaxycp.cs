
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
    public partial class galaxycp : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public galaxycp()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "maven";
            bool enabled = Settings.Default.cpgalaxyenabled;
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

		public static void ReplaceBytes(string pak, long offset, byte[] bytes)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(pak, FileMode.Open, FileAccess.ReadWrite));
			binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
			binaryWriter.Write(bytes);
			binaryWriter.Close();
		}

	

		





		private void convert_Click(object sender, EventArgs e)
        {
			string filePath = Settings.Default.paksPath + "\\pakchunk10_s2-WindowsClient.pak";
			string filePath1 = Settings.Default.paksPath + "\\pakchunk10_s3-WindowsClient.pak";

			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

			if (Settings.Default.cpskinEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "a cp skin has been already converted " + MessageBoxButtons.OK + MessageBoxIcon.Error, 100);
				return;
			}


			convert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			galaxycp.ReplaceBytes(filePath, 3268051L, galaxycp.frozenbody);
			galaxycp.ReplaceBytes(filePath, 3268051L, galaxycp.aerialbody);
			this.RichTextBoxInfo.AppendText("\n[LOG] head added!");
			galaxycp.ReplaceBytes(filePath, 3264546L, galaxycp.head1);
			galaxycp.ReplaceBytes(filePath, 3264546L, galaxycp.head2);
			this.RichTextBoxInfo.AppendText("\n[LOG] body added!");
			galaxycp.ReplaceBytes(filePath, 213611755L, galaxycp.glasses);
			galaxycp.ReplaceBytes(filePath, 213611755L, galaxycp.glasses1);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp added!");
			Settings.Default.cpskinEnabled = true;
			Settings.Default.cpgalaxyenabled = true;
			Settings.Default.Save();







			revert.Enabled = true;
			convert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

        private void revert_Click(object sender, EventArgs e)
        {
			string filePath = Settings.Default.paksPath + "\\pakchunk10_s2-WindowsClient.pak";
			string filePath1 = Settings.Default.paksPath + "\\pakchunk10_s3-WindowsClient.pak";
			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;



			revert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			galaxycp.ReplaceBytes(filePath, 3268051L, galaxycp.aerialbody);
			galaxycp.ReplaceBytes(filePath, 3268051L, galaxycp.frozenbody);
			this.RichTextBoxInfo.AppendText("\n[LOG] head removed!");
			galaxycp.ReplaceBytes(filePath, 3264546L, galaxycp.head2);
			galaxycp.ReplaceBytes(filePath, 3264546L, galaxycp.head1);
			this.RichTextBoxInfo.AppendText("\n[LOG] body removed!");
			galaxycp.ReplaceBytes(filePath, 213611755L, galaxycp.glasses1);
			galaxycp.ReplaceBytes(filePath, 213611755L, galaxycp.glasses);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp removed!");
			Settings.Default.cpskinEnabled = false;
			Settings.Default.cpgalaxyenabled = false;
			Settings.Default.Save();








			convert.Enabled = true;
			revert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		private static byte[] glasses1 = new byte[]
		{
			0,
			0,
			0,
			67,
			80,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			66,
			111,
			100,
			121,
			95,
			77,
			95,
			80,
			105,
			114,
			97,
			116,
			101,
			49,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			105,
			118,
			101
		};

		// Token: 0x040008CC RID: 2252
		private static byte[] glasses = new byte[]
		{
			0,
			0,
			0,
			67,
			80,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
			95,
			66,
			111,
			100,
			121,
			95,
			77,
			95,
			80,
			105,
			114,
			97,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			105,
			118,
			101
		};

		// Token: 0x040008CD RID: 2253
		private static byte[] aerialbody = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			65,
			116,
			104,
			101,
			110,
			97,
			47,
			72,
			101,
			114,
			111,
			101,
			115,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			95,
			77,
			97,
			116,
			104,
			46,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			95,
			77,
			97,
			116,
			104,
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

		// Token: 0x040008CE RID: 2254
		private static byte[] frozenbody = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			65,
			116,
			104,
			101,
			110,
			97,
			47,
			72,
			101,
			114,
			111,
			101,
			115,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65,
			46,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65
		};

		// Token: 0x040008CF RID: 2255
		private static byte[] head2 = new byte[]
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
			67,
			104,
			97,
			114,
			97,
			99,
			116,
			101,
			114,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			101,
			109,
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
			72,
			101,
			97,
			100,
			115,
			47,
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			77,
			97,
			116,
			104,
			46,
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			77,
			97,
			116,
			104,
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

		// Token: 0x040008D0 RID: 2256
		private static byte[] head1 = new byte[]
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
			67,
			104,
			97,
			114,
			97,
			99,
			116,
			101,
			114,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			101,
			109,
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
			72,
			101,
			97,
			100,
			115,
			47,
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65,
			46,
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65
		};
	}
}
