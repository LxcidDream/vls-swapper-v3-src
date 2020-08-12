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
	// Token: 0x020000B2 RID: 178
	public partial class EnduringRagnarok : MaterialForm
	{
		// Token: 0x06000A14 RID: 2580 RVA: 0x000CFD54 File Offset: 0x000CDF54
		public EnduringRagnarok()
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
			this.Text = "Enduring Cape";
			bool enduringRagnarok = Settings.Default.EnduringRagnarok;
			bool flag3 = enduringRagnarok;
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

		// Token: 0x06000A15 RID: 2581 RVA: 0x000CFED1 File Offset: 0x000CE0D1
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x000CFEDC File Offset: 0x000CE0DC
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x000CFF3D File Offset: 0x000CE13D
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x000CFF58 File Offset: 0x000CE158
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x000CFFB9 File Offset: 0x000CE1B9
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x000CFFD4 File Offset: 0x000CE1D4
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
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, EnduringRagnarok.CID1))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(EnduringRagnarok.CID);
				binaryWriter.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, EnduringRagnarok.Mesh1))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(EnduringRagnarok.Mesh);
				binaryWriter2.Close();
				Settings.Default.EnduringRagnarok = false;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Mesh removed!";
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetback, EnduringRagnarok.MeshBP1))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(EnduringRagnarok.MeshBP);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Animation removed!";
			}
			this.revert.Enabled = false;
			this.convert.Enabled = true;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x000D0330 File Offset: 0x000CE530
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
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, EnduringRagnarok.CID))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(EnduringRagnarok.CID1);
				binaryWriter.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Added!";
			}
			Stream stream2 = File.OpenRead(path);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetback, EnduringRagnarok.Mesh))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(EnduringRagnarok.Mesh1);
				binaryWriter2.Close();
				Settings.Default.EnduringRagnarok = true;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Mesh added!";
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetback, EnduringRagnarok.MeshBP))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(EnduringRagnarok.MeshBP1);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Animation added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x000D068C File Offset: 0x000CE88C
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

		// Token: 0x06000A1D RID: 2589 RVA: 0x000D0730 File Offset: 0x000CE930
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

		// Token: 0x04000FC9 RID: 4041
		private Point lastPoint;

		// Token: 0x04000FCA RID: 4042
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000FCB RID: 4043
		private string enable = Resources.enabled;

		// Token: 0x04000FCC RID: 4044
		private string disabled = Resources.disabled;

		// Token: 0x04000FCD RID: 4045
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000FCE RID: 4046
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000FCF RID: 4047
		private string error = Resources.error;

		// Token: 0x04000FD0 RID: 4048
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000FD1 RID: 4049
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
			68,
			97,
			114,
			107,
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
			68,
			97,
			114,
			107,
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
			68,
			97,
			114,
			107,
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
			101
		};

		// Token: 0x04000FD2 RID: 4050
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
			0
		};

		// Token: 0x04000FD3 RID: 4051
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
			68,
			97,
			114,
			107,
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
			68,
			97,
			114,
			107,
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
			95,
			83,
			107,
			101,
			108,
			101,
			116,
			111,
			110,
			95,
			65,
			110,
			105,
			109,
			66,
			108,
			117,
			101,
			112,
			114,
			105,
			110,
			116,
			95,
			67,
			104,
			105,
			108,
			100,
			46,
			77,
			95,
			77,
			69,
			68,
			95,
			68,
			97,
			114,
			107,
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
			95,
			83,
			107,
			101,
			108,
			101,
			116,
			111,
			110,
			95,
			65,
			110,
			105,
			109,
			66,
			108,
			117,
			101,
			112,
			114,
			105,
			110,
			116,
			95,
			67,
			104,
			105,
			108,
			100,
			95,
			67
		};

		// Token: 0x04000FD4 RID: 4052
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
			95,
			65,
			110,
			105,
			109,
			66,
			108,
			117,
			101,
			112,
			114,
			105,
			110,
			116,
			95,
			67,
			104,
			105,
			108,
			100,
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
			95,
			65,
			110,
			105,
			109,
			66,
			108,
			117,
			101,
			112,
			114,
			105,
			110,
			116,
			95,
			67,
			104,
			105,
			108,
			100,
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

		// Token: 0x04000FD5 RID: 4053
		private static byte[] CID = new byte[]
		{
			67,
			111,
			115,
			109,
			101,
			116,
			105,
			99,
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
			115,
			47,
			66,
			73,
			68,
			95,
			48,
			55,
			51,
			95,
			68,
			97,
			114,
			107,
			86,
			105,
			107,
			105,
			110,
			103,
			46,
			66,
			73,
			68,
			95,
			48,
			55,
			51,
			95,
			68,
			97,
			114,
			107,
			86,
			105,
			107,
			105,
			110,
			103
		};

		// Token: 0x04000FD6 RID: 4054
		private static byte[] CID1 = new byte[]
		{
			67,
			111,
			115,
			109,
			101,
			116,
			105,
			99,
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
			115,
			47,
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
			101,
			46,
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
	}
}
