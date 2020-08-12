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

namespace vls_swapper_v3.Backblings
{
	// Token: 0x020000C0 RID: 192
	public partial class RiftWings : MaterialForm
	{
		// Token: 0x06000ACA RID: 2762 RVA: 0x000DCD58 File Offset: 0x000DAF58
		public RiftWings()
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
			this.Text = "RiftWings";
			bool riftWingsEnabled = Settings.Default.RiftWingsEnabled;
			bool flag3 = riftWingsEnabled;
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

		// Token: 0x06000ACB RID: 2763 RVA: 0x000DCED5 File Offset: 0x000DB0D5
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x000DCEE0 File Offset: 0x000DB0E0
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x000DCF41 File Offset: 0x000DB141
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x000DCF5C File Offset: 0x000DB15C
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x000DCFBD File Offset: 0x000DB1BD
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x000DCFD8 File Offset: 0x000DB1D8
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
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, RiftWings.CID1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(RiftWings.CID);
				binaryWriter.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID removed!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, RiftWings.Mesh1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(RiftWings.Mesh);
				binaryWriter2.Close();
				Settings.Default.RiftWingsEnabled = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x000DD284 File Offset: 0x000DB484
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
				string path2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
				Stream stream = File.OpenRead(path2);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, RiftWings.CID))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(RiftWings.CID1);
					binaryWriter.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID added!";
				}
				Stream stream2 = File.OpenRead(path);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, RiftWings.Mesh))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(RiftWings.Mesh1);
					binaryWriter2.Close();
					Settings.Default.RiftWingsEnabled = true;
					Settings.Default.Save();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Backbling added!";
				}
				this.revert.Enabled = true;
				this.convert.Enabled = false;
				stopwatch.Stop();
				double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";

		}				
					
				
			
		

		// Token: 0x06000AD2 RID: 2770 RVA: 0x000DD648 File Offset: 0x000DB848
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

		// Token: 0x06000AD3 RID: 2771 RVA: 0x000DD6EC File Offset: 0x000DB8EC
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

		// Token: 0x040010E4 RID: 4324
		private Point lastPoint;

		// Token: 0x040010E5 RID: 4325
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x040010E6 RID: 4326
		private string enable = Resources.enabled;

		// Token: 0x040010E7 RID: 4327
		private string disabled = Resources.disabled;

		// Token: 0x040010E8 RID: 4328
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x040010E9 RID: 4329
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x040010EA RID: 4330
		private string error = Resources.error;

		// Token: 0x040010EB RID: 4331
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x040010EC RID: 4332
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
			66,
			105,
			114,
			116,
			104,
			100,
			97,
			121,
			67,
			97,
			107,
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
			66,
			105,
			114,
			116,
			104,
			100,
			97,
			121,
			67,
			97,
			107,
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
			66,
			105,
			114,
			116,
			104,
			100,
			97,
			121,
			67,
			97,
			107,
			101
		};

		// Token: 0x040010ED RID: 4333
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
			70,
			95,
			77,
			69,
			68,
			95,
			83,
			104,
			97,
			116,
			116,
			101,
			114,
			70,
			108,
			121,
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
			70,
			95,
			77,
			69,
			68,
			95,
			83,
			104,
			97,
			116,
			116,
			101,
			114,
			95,
			70,
			108,
			121,
			95,
			80,
			97,
			99,
			107,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			83,
			104,
			97,
			116,
			116,
			101,
			114,
			95,
			70,
			108,
			121,
			95,
			80,
			97,
			99,
			107
		};

		// Token: 0x040010EE RID: 4334
		private static byte[] CID = new byte[]
		{
			66,
			73,
			68,
			95,
			48,
			56,
			52,
			95,
			66,
			105,
			114,
			116,
			104,
			100,
			97,
			121,
			50,
			48,
			49,
			56,
			46,
			66,
			73,
			68,
			95,
			48,
			56,
			52,
			95,
			66,
			105,
			114,
			116,
			104,
			100,
			97,
			121,
			50,
			48,
			49,
			56
		};

		// Token: 0x040010EF RID: 4335
		private static byte[] CID1 = new byte[]
		{
			66,
			73,
			68,
			95,
			50,
			53,
			54,
			95,
			83,
			104,
			97,
			116,
			116,
			101,
			114,
			70,
			108,
			121,
			46,
			66,
			73,
			68,
			95,
			50,
			53,
			54,
			95,
			83,
			104,
			97,
			116,
			116,
			101,
			114,
			70,
			108,
			121,
			0,
			0,
			0,
			0
		};
	}
}
