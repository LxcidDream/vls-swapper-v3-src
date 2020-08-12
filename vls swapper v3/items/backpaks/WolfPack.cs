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
using MetroFramework;

namespace vls_swapper_v3.Backblings
{
	// Token: 0x020000BE RID: 190
	public partial class WolfPack : MaterialForm
	{
		// Token: 0x06000AB0 RID: 2736 RVA: 0x000DAFE4 File Offset: 0x000D91E4
		public WolfPack()
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
			this.Text = "WolfPack";
			bool wolfPackEnabled = Settings.Default.WolfPackEnabled;
			bool flag3 = wolfPackEnabled;
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

		// Token: 0x06000AB1 RID: 2737 RVA: 0x000DB161 File Offset: 0x000D9361
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x000DB16C File Offset: 0x000D936C
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x000DB1CD File Offset: 0x000D93CD
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x000DB1E8 File Offset: 0x000D93E8
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x000DB249 File Offset: 0x000D9449
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x000DB264 File Offset: 0x000D9464
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
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, WolfPack.CID1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(WolfPack.CID);
				binaryWriter.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, WolfPack.Mesh1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(WolfPack.Mesh);
				binaryWriter2.Close();
				Settings.Default.WolfPackEnabled = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000DB510 File Offset: 0x000D9710
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

			
					    bool cloverEnabled = Settings.Default.CloverEnabled;
						if (cloverEnabled)
						{
							MetroMessageBox.Show(this, "Rainbow Clover" + this.actsomewhelse, this.error, MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
				return;
						}
						else
						{
							this.convert.Enabled = false;
							this.RichTextBoxInfo.Text = "";
							RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
							richTextBoxInfo.Text += "[LOG] Starting...";
							Stopwatch stopwatch = new Stopwatch();
							stopwatch.Start();
							string text = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
							string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
							string path2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
							Stream stream = File.OpenRead(path2);
							foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, WolfPack.CID))
							{
								stream.Close();
								BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
								binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
								binaryWriter.Write(WolfPack.CID1);
								binaryWriter.Close();
								this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Added!";
							}
							Stream stream2 = File.OpenRead(path);
							foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, WolfPack.Mesh))
							{
								stream2.Close();
								BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
								binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
								binaryWriter2.Write(WolfPack.Mesh1);
								binaryWriter2.Close();
								Settings.Default.WolfPackEnabled = true;
								Settings.Default.Save();
								this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
							}
							this.revert.Enabled = true;
							this.convert.Enabled = false;
							stopwatch.Stop();
							double num = (double)stopwatch.Elapsed.Seconds;
							this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
						}
					
				
			
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x000DB89C File Offset: 0x000D9A9C
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

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000DB940 File Offset: 0x000D9B40
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

		// Token: 0x040010BC RID: 4284
		private Point lastPoint;

		// Token: 0x040010BD RID: 4285
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x040010BE RID: 4286
		private string enable = Resources.enabled;

		// Token: 0x040010BF RID: 4287
		private string disabled = Resources.disabled;

		// Token: 0x040010C0 RID: 4288
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x040010C1 RID: 4289
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x040010C2 RID: 4290
		private string error = Resources.error;

		// Token: 0x040010C3 RID: 4291
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x040010C4 RID: 4292
		private static byte[] Mesh = new byte[]
		{
			77,
			95,
			77,
			69,
			68,
			95,
			83,
			117,
			109,
			109,
			101,
			114,
			72,
			101,
			114,
			111,
			101,
			115,
			95,
			85,
			110,
			105,
			99,
			111,
			114,
			110,
			47,
			77,
			101,
			115,
			104,
			101,
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
			83,
			117,
			109,
			109,
			101,
			114,
			95,
			72,
			101,
			114,
			111,
			101,
			115,
			95,
			85,
			110,
			105,
			99,
			111,
			114,
			110,
			95,
			69,
			120,
			112,
			111,
			114,
			116,
			46,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			83,
			117,
			109,
			109,
			101,
			114,
			95,
			72,
			101,
			114,
			111,
			101,
			115,
			95,
			85,
			110,
			105,
			99,
			111,
			114,
			110,
			95,
			69,
			120,
			112,
			111,
			114,
			116
		};

		// Token: 0x040010C5 RID: 4293
		private static byte[] Mesh1 = new byte[]
		{
			77,
			95,
			77,
			69,
			68,
			95,
			87,
			101,
			114,
			101,
			119,
			111,
			108,
			102,
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
			77,
			95,
			77,
			69,
			68,
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
			87,
			101,
			114,
			101,
			119,
			111,
			108,
			102,
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
			77,
			95,
			77,
			69,
			68,
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
			87,
			101,
			114,
			101,
			119,
			111,
			108,
			102,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
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

		// Token: 0x040010C6 RID: 4294
		private static byte[] CID = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			55,
			52,
			95,
			76,
			105,
			102,
			101,
			103,
			117,
			97,
			114,
			100,
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
			52,
			95,
			76,
			105,
			102,
			101,
			103,
			117,
			97,
			114,
			100,
			70,
			101,
			109,
			97,
			108,
			101
		};

		// Token: 0x040010C7 RID: 4295
		private static byte[] CID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			49,
			50,
			48,
			95,
			87,
			101,
			114,
			101,
			119,
			111,
			108,
			102,
			46,
			66,
			73,
			68,
			95,
			49,
			50,
			48,
			95,
			87,
			101,
			114,
			101,
			119,
			111,
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
			0,
			0,
			0,
			0,
			0,
			0
		};
	}
}
