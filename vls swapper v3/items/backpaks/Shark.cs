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
	// Token: 0x020000A9 RID: 169
	public partial class Shark : MaterialForm
	{
		// Token: 0x0600099F RID: 2463 RVA: 0x000C733C File Offset: 0x000C553C
		public Shark()
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
			this.Text = "Shark Fin";
			bool sharkEnabled = Settings.Default.SharkEnabled;
			bool flag3 = sharkEnabled;
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

		// Token: 0x060009A0 RID: 2464 RVA: 0x000C74B9 File Offset: 0x000C56B9
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000C74C4 File Offset: 0x000C56C4
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000C7525 File Offset: 0x000C5725
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000C7540 File Offset: 0x000C5740
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x000C75A1 File Offset: 0x000C57A1
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x000C75BC File Offset: 0x000C57BC
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
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetback, Shark.Mesh1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Shark.Mesh);
				binaryWriter.Close();
				Settings.Default.SharkEnabled = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 removed!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, Shark.MeshBP1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Shark.MeshBP);
				binaryWriter2.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 removed!";
			}
			Stream stream3 = File.OpenRead(path2);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetlobby, Shark.BID1))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Shark.BID);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!"; ;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000C7908 File Offset: 0x000C5B08
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
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetback, Shark.Mesh))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Shark.Mesh1);
					binaryWriter.Close();
					Settings.Default.SharkEnabled = true;
					Settings.Default.Save();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 added!";
				}
				Stream stream2 = File.OpenRead(path2);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, Shark.MeshBP))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Shark.MeshBP1);
					binaryWriter2.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 added!";
				}
				Stream stream3 = File.OpenRead(path);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetlobby, Shark.BID))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Shark.BID1);
					binaryWriter3.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID added!";
				}
				this.revert.Enabled = true;
				this.convert.Enabled = false;
				stopwatch.Stop();
				double num = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";;
			
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000C7C8C File Offset: 0x000C5E8C
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

		// Token: 0x060009A8 RID: 2472 RVA: 0x000C7D30 File Offset: 0x000C5F30
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

		// Token: 0x04000F10 RID: 3856
		private Point lastPoint;

		// Token: 0x04000F11 RID: 3857
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000F12 RID: 3858
		private string enable = Resources.enabled;

		// Token: 0x04000F13 RID: 3859
		private string disabled = Resources.disabled;

		// Token: 0x04000F14 RID: 3860
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000F15 RID: 3861
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000F16 RID: 3862
		private string error = Resources.error;

		// Token: 0x04000F17 RID: 3863
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000F18 RID: 3864
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
			77,
			95,
			77,
			69,
			68,
			95,
			80,
			105,
			114,
			97,
			116,
			101,
			95,
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
			101,
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
			80,
			105,
			114,
			97,
			116,
			101,
			95,
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
			101,
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
			80,
			105,
			114,
			97,
			116,
			101,
			95,
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

		// Token: 0x04000F19 RID: 3865
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
			83,
			104,
			97,
			114,
			107,
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
			83,
			104,
			97,
			114,
			107,
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
			83,
			104,
			97,
			114,
			107,
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

		// Token: 0x04000F1A RID: 3866
		private static byte[] MeshBP = new byte[]
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
			77,
			95,
			77,
			69,
			68,
			95,
			80,
			105,
			114,
			97,
			116,
			101,
			95,
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
			101,
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
			80,
			105,
			114,
			97,
			116,
			101,
			95,
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

		// Token: 0x04000F1B RID: 3867
		private static byte[] MeshBP1 = new byte[]
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
			83,
			104,
			97,
			114,
			107,
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
			83,
			104,
			97,
			114,
			107,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x04000F1C RID: 3868
		private static byte[] BID = new byte[]
		{
			66,
			73,
			68,
			95,
			50,
			49,
			54,
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
			101,
			46,
			66,
			73,
			68,
			95,
			50,
			49,
			54,
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

		// Token: 0x04000F1D RID: 3869
		private static byte[] BID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			55,
			54,
			95,
			83,
			104,
			97,
			114,
			107,
			46,
			66,
			73,
			68,
			95,
			48,
			55,
			54,
			95,
			83,
			104,
			97,
			114,
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
