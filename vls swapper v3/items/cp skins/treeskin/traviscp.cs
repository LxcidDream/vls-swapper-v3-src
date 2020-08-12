using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MaterialSkin;
using System.Text;
using MaterialSkin.Controls;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.Properties;
using System.IO;
using vls_swapper_v3.main.popups;
using System.Diagnostics;

namespace vls_swapper_v3.items.cp_skins.treeskin
{
    public partial class traviscp : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public traviscp()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "travis";
            bool enabled = Settings.Default.traviscpenabled;
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
			if (Settings.Default.cpskinEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "a cp skin has been already converted " + MessageBoxButtons.OK + MessageBoxIcon.Error, 100);
				return;
			}


			string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath1))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}

			CheckForIllegalCrossThreadCalls = false;



			convert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

			traviscp.ReplaceBytes(filePath, 3268051L, traviscp.head);
			traviscp.ReplaceBytes(filePath, 3268051L, traviscp.head1);
			this.RichTextBoxInfo.AppendText("\n[LOG] head added!");
			traviscp.ReplaceBytes(filePath, 3264546L, traviscp.body);
			traviscp.ReplaceBytes(filePath, 3264546L, traviscp.body1);
			this.RichTextBoxInfo.AppendText("\n[LOG] body added!");
			traviscp.ReplaceBytes(filePath, 203378241L, traviscp.cp);
			traviscp.ReplaceBytes(filePath, 203378241L, traviscp.cp1);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp added!");
			Settings.Default.cpskinEnabled = true;
			Settings.Default.traviscpenabled = true;
			Settings.Default.Save();

			revert.Enabled = true;
			convert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

        private void revert_Click(object sender, EventArgs e)
        {
			CheckForIllegalCrossThreadCalls = false;

			string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath1))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}






			revert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

			traviscp.ReplaceBytes(filePath, 3268051L, traviscp.head1);
			traviscp.ReplaceBytes(filePath, 3268051L, traviscp.head);
			this.RichTextBoxInfo.AppendText("\n[LOG] head removed!");
			traviscp.ReplaceBytes(filePath, 3264546L, traviscp.body1);
			traviscp.ReplaceBytes(filePath, 3264546L, traviscp.body);
			this.RichTextBoxInfo.AppendText("\n[LOG] body removed!");
			traviscp.ReplaceBytes(filePath, 203378241L, traviscp.cp1);
			traviscp.ReplaceBytes(filePath, 203378241L, traviscp.cp);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp removed!");
			Settings.Default.cpskinEnabled = false;
			Settings.Default.traviscpenabled = false;
			Settings.Default.Save();

			convert.Enabled = true;
			revert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}









		private static byte[] cp = new byte[]
		{
			0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,108,100,105,101,114
		};
		private static byte[] cp1 = new byte[]
		{
			0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,49,100,105,101,114
		};

		// Token: 0x040006EA RID: 1770
		private static byte[] body1 = new byte[]
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
			74,
			101,
			114,
			107,
			121,
			46,
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
			74,
			101,
			114,
			107,
			121,
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

		// Token: 0x040006EB RID: 1771
		private static byte[] body = new byte[]
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

		// Token: 0x040006EC RID: 1772
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
			72,
			101,
			97,
			100,
			115,
			47,
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
			72,
			101,
			97,
			100,
			95,
			77,
			95,
			74,
			101,
			114,
			107,
			121,
			46,
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
			72,
			101,
			97,
			100,
			95,
			77,
			95,
			74,
			101,
			114,
			107,
			121,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040006ED RID: 1773
		private static byte[] head = new byte[]
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
