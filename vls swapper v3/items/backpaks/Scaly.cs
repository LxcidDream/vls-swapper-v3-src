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

namespace vls_swapper_v3.Backblings
{
	// Token: 0x020000BA RID: 186
	public partial class Scaly : MaterialForm
	{
		// Token: 0x06000A7C RID: 2684 RVA: 0x000D76F8 File Offset: 0x000D58F8
		public Scaly()
		{
			this.InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
			this.skinManager.AddFormToManage(this);
			this.skinManager.Theme = MaterialSkinManager.Themes.DARK;
			bool flag = !Settings.Default.ismode;
			bool flag2 = flag;
			if (flag2)
			{
				this.skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
			}
			else
			{
				this.skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
			}
			this.Text = "Scaly";
			bool scalyEnabled = Settings.Default.ScalyEnabled;
			bool flag3 = scalyEnabled;
			if (flag3)
			{
				this.revert.Enabled = true;
				this.convert.Enabled = false;
			}
			else
			{
				this.revert.Enabled = false;
				this.convert.Enabled = true;
			}
			
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000D7875 File Offset: 0x000D5A75
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000D7880 File Offset: 0x000D5A80
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x000D78E1 File Offset: 0x000D5AE1
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x000D78FC File Offset: 0x000D5AFC
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x000D795D File Offset: 0x000D5B5D
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x000D7978 File Offset: 0x000D5B78
		private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetpick = Settings.Default.offsetpick;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetemote = Settings.Default.offsetemote;
			int offsetlobby = Settings.Default.offsetlobby;
			int offsetpickmesh = Settings.Default.offsetpickmesh;
			this.revert.Enabled = false;
			this.RichTextBoxInfo.Text = "";
			RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
			richTextBoxInfo.Text += "[LOG] Starting...";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			string text = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			string path2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			Stream stream = File.OpenRead(path2);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, Scaly.CID1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Scaly.CID);
				binaryWriter.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, Scaly.Mesh1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Scaly.Mesh);
				binaryWriter2.Close();
				Settings.Default.ScalyEnabled = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x000D7C24 File Offset: 0x000D5E24
		private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetpick = Settings.Default.offsetpick;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetemote = Settings.Default.offsetemote;
			int offsetlobby = Settings.Default.offsetlobby;
			int offsetpickmesh = Settings.Default.offsetpickmesh;
			this.convert.Enabled = false;
			this.RichTextBoxInfo.Text = "";
			RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
			richTextBoxInfo.Text += "[LOG] Starting...";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string text = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			Stream stream = File.OpenRead(path);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetback, Scaly.Mesh))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Scaly.Mesh1);
				binaryWriter.Close();
				Settings.Default.ScalyEnabled = true;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
			}
			string path2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			Stream stream2 = File.OpenRead(path2);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetlobby, Scaly.CID))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Scaly.CID1);
				binaryWriter2.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x000D7ED0 File Offset: 0x000D60D0
		private void convert_Click(object sender, EventArgs e)
		{
			string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			bool flag = !File.Exists(path);
			if (flag)
			{
				paks paks = new paks();
				paks.ShowDialog();
			}
			else
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				int offsetskin = Settings.Default.offsetskin1;
				int offsetpick = Settings.Default.offsetpick;
				int offsetback = Settings.Default.offsetback;
				int offsetskin2 = Settings.Default.offsetskin2;
				int offsetemote = Settings.Default.offsetemote;
				int offsetlobby = Settings.Default.offsetlobby;
				int offsetpickmesh = Settings.Default.offsetpickmesh;
				this.change1Bytes.RunWorkerAsync();
			}
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x000D7F74 File Offset: 0x000D6174
		private void revert_Click(object sender, EventArgs e)
		{
			string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			bool flag = !File.Exists(path);
			if (flag)
			{
				paks paks = new paks();
				paks.ShowDialog();
			}
			else
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				int offsetskin = Settings.Default.offsetskin1;
				int offsetpick = Settings.Default.offsetpick;
				int offsetback = Settings.Default.offsetback;
				int offsetskin2 = Settings.Default.offsetskin2;
				int offsetemote = Settings.Default.offsetemote;
				int offsetlobby = Settings.Default.offsetlobby;
				int offsetpickmesh = Settings.Default.offsetpickmesh;
				this.revert1Bytes.RunWorkerAsync();
			}
		}

		// Token: 0x0400106E RID: 4206
		private Point lastPoint;

		// Token: 0x0400106F RID: 4207
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04001070 RID: 4208
		private string enable = Resources.enabled;

		// Token: 0x04001071 RID: 4209
		private string disabled = Resources.disabled;

		// Token: 0x04001072 RID: 4210
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04001073 RID: 4211
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04001074 RID: 4212
		private string error = Resources.error;

		// Token: 0x04001075 RID: 4213
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04001076 RID: 4214
		private static byte[] Mesh = new byte[]
		{
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
			86,
			105,
			107,
			105,
			110,
			103,
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
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			83,
			75,
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
			77,
			97,
			108,
			101,
			95,
			86,
			105,
			107,
			105,
			110,
			103,
			46,
			83,
			75,
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
			77,
			97,
			108,
			101,
			95,
			86,
			105,
			107,
			105,
			110,
			103
		};

		// Token: 0x04001077 RID: 4215
		private static byte[] Mesh1 = new byte[]
		{
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
			101,
			115,
			104,
			47,
			83,
			75,
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
			77,
			97,
			108,
			101,
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
			49,
			49,
			46,
			83,
			75,
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
			77,
			97,
			108,
			101,
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
			49,
			49,
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

		// Token: 0x04001078 RID: 4216
		private static byte[] CID = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			55,
			49,
			95,
			86,
			105,
			107,
			105,
			110,
			103,
			70,
			101,
			109,
			97,
			108,
			101,
			46,
			66,
			73,
			68,
			95,
			48,
			55,
			49,
			95,
			86,
			105,
			107,
			105,
			110,
			103,
			70,
			101,
			109,
			97,
			108,
			101
		};

		// Token: 0x04001079 RID: 4217
		private static byte[] CID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			51,
			49,
			95,
			68,
			105,
			110,
			111,
			115,
			97,
			117,
			114,
			46,
			66,
			73,
			68,
			95,
			48,
			51,
			49,
			95,
			68,
			105,
			110,
			111,
			115,
			97,
			117,
			114,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}
}
