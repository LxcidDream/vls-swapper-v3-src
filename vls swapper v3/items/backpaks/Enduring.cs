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
	// Token: 0x020000BB RID: 187
	public partial class Enduring : MaterialForm
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x000D84A4 File Offset: 0x000D66A4
		public Enduring()
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
			this.Text = "EnduringCape";
			bool enduringEnabled = Settings.Default.EnduringEnabled;
			bool flag3 = enduringEnabled;
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

		// Token: 0x06000A8A RID: 2698 RVA: 0x000D8621 File Offset: 0x000D6821
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x000D862C File Offset: 0x000D682C
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x000D868D File Offset: 0x000D688D
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x000D86A8 File Offset: 0x000D68A8
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x000D8709 File Offset: 0x000D6909
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x000D8724 File Offset: 0x000D6924
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
			string path2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			Stream stream = File.OpenRead(path);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetback, Enduring.Mesh1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Enduring.Mesh);
				binaryWriter.Close();
				Settings.Default.EnduringEnabled = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
			}
			Stream stream2 = File.OpenRead(path2);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetlobby, Enduring.BID1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Enduring.BID);
				binaryWriter2.Close();
			}
			Stream stream3 = File.OpenRead(path2);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetlobby, Enduring.FBID1))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Enduring.FBID);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000D8A50 File Offset: 0x000D6C50
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
			string path = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			string path2 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			Stream stream = File.OpenRead(path2);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetback, Enduring.Mesh))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Enduring.Mesh1);
				binaryWriter.Close();
				Settings.Default.EnduringEnabled = true;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetlobby, Enduring.BID))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Enduring.BID1);
				binaryWriter2.Close();
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetlobby, Enduring.FBID))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Enduring.FBID1);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Locker Icon added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x000D8D7C File Offset: 0x000D6F7C
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

		// Token: 0x06000A92 RID: 2706 RVA: 0x000D8E20 File Offset: 0x000D7020
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

		// Token: 0x04001081 RID: 4225
		private Point lastPoint;

		// Token: 0x04001082 RID: 4226
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04001083 RID: 4227
		private string enable = Resources.enabled;

		// Token: 0x04001084 RID: 4228
		private string disabled = Resources.disabled;

		// Token: 0x04001085 RID: 4229
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04001086 RID: 4230
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04001087 RID: 4231
		private string error = Resources.error;

		// Token: 0x04001088 RID: 4232
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04001089 RID: 4233
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
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			101,
			116,
			101,
			111,
			114,
			77,
			97,
			110,
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
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			101,
			116,
			101,
			111,
			114,
			109,
			97,
			110,
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
			83,
			75,
			95,
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			101,
			116,
			101,
			111,
			114,
			109,
			97,
			110,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107
		};

		// Token: 0x0400108A RID: 4234
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
			67,
			97,
			112,
			101,
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
			67,
			97,
			112,
			101,
			47,
			77,
			101,
			115,
			104,
			101,
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
			67,
			97,
			112,
			101,
			46,
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
			67,
			97,
			112,
			101,
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
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x0400108B RID: 4235
		private static byte[] BID = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			53,
			55,
			95,
			86,
			105,
			115,
			105,
			116,
			111,
			114
		};

		// Token: 0x0400108C RID: 4236
		private static byte[] BID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			53,
			55,
			95,
			89,
			89,
			89,
			89,
			89,
			89,
			89
		};

		// Token: 0x0400108D RID: 4237
		private static byte[] FBID = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			55,
			50,
			95,
			86,
			105,
			107,
			105,
			110,
			103,
			77,
			97,
			108,
			101
		};

		// Token: 0x0400108E RID: 4238
		private static byte[] FBID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			53,
			55,
			95,
			86,
			105,
			115,
			105,
			116,
			111,
			114,
			0,
			0,
			0
		};
	}
}
