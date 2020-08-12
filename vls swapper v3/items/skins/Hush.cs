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

namespace vls_swapper_v3.Skins
{
	// Token: 0x02000021 RID: 33
	public partial class Hush : MaterialForm
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00024A74 File Offset: 0x00022C74
		public Hush()
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
			this.Text = "Hush";
			
			bool hushEnabled = Settings.Default.HushEnabled;
			bool flag3 = hushEnabled;
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

		// Token: 0x0600032A RID: 810 RVA: 0x00024BFC File Offset: 0x00022DFC
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00024C08 File Offset: 0x00022E08
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00024C69 File Offset: 0x00022E69
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00024C84 File Offset: 0x00022E84
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00024CE5 File Offset: 0x00022EE5
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00024D00 File Offset: 0x00022F00
		private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetlobby = Settings.Default.offsetlobby;
			bool cancellationPending = this.revert1Bytes.CancellationPending;
			bool flag = cancellationPending;
			if (flag)
			{
				e.Cancel = true;
			}
			else
			{
				this.revert.Enabled = false;
				this.RichTextBoxInfo.Text = "";
				RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
				RichTextBox richTextBox = richTextBoxInfo;
				richTextBox.Text += "[LOG] Starting...";
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path2 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
				Stream stream = File.OpenRead(path);
				foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, Hush.Body))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
					binaryWriter.Write(Hush.Body1);
					long offset = num + 666L;
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Hush.CID1);
					binaryWriter.Close();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Body 1/2 removed!";
				}
				Stream stream2 = File.OpenRead(path);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, Hush.BodyPart1))
				{
					stream2.Close();
					Settings.Default.HushEnabled = false;
					Settings.Default.Save();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Hush.BodyPart);
					binaryWriter2.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/2 removed!";
				}
				Stream stream3 = File.OpenRead(path2);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, Hush.FaceAcc1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Hush.FaceAcc);
					binaryWriter3.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head removed!";
				}
				Stream stream4 = File.OpenRead(path2);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, Hush.FaceAccBP1))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(Hush.FaceAccBP);
					binaryWriter4.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Special Face removed!";
				}
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				stopwatch.Stop();
				double num2 = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x000251DC File Offset: 0x000233DC
		private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetlobby = Settings.Default.offsetlobby;
			this.convert.Enabled = false;
			this.RichTextBoxInfo.Text = "";
			RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
			RichTextBox richTextBox = richTextBoxInfo;
			richTextBox.Text += "[LOG] Starting...";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			Stream stream = File.OpenRead(path2);
			foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, Hush.Body))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
				binaryWriter.Write(Hush.Body1);
				long offset = num + 666L;
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Hush.CID1);
				binaryWriter.Close();
				RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
				richTextBoxInfo2.Text += "\n[LOG] Body 1/2 added!";
			}
			Stream stream2 = File.OpenRead(path2);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, Hush.BodyPart))
			{
				stream2.Close();
				Settings.Default.IkonikFableEnabled = true;
				Settings.Default.Save();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Hush.BodyPart1);
				binaryWriter2.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/2 added!";
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, Hush.FaceAcc))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Hush.FaceAcc1);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head added!";
			}
			Stream stream4 = File.OpenRead(path);
			foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, Hush.FaceAccBP))
			{
				stream4.Close();
				BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
				binaryWriter4.Write(Hush.FaceAccBP1);
				binaryWriter4.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Special Face added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num2 = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00025698 File Offset: 0x00023898
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
					int offsetback = Settings.Default.offsetback;
					int offsetskin2 = Settings.Default.offsetskin2;
					int offsetlobby = Settings.Default.offsetlobby;
					this.change1Bytes.RunWorkerAsync();
				
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00025768 File Offset: 0x00023968
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
				int offsetback = Settings.Default.offsetback;
				int offsetskin2 = Settings.Default.offsetskin2;
				int offsetlobby = Settings.Default.offsetlobby;
				this.revert1Bytes.RunWorkerAsync();
			}
		}

		// Token: 0x040001C3 RID: 451
		private Point lastPoint;

		// Token: 0x040001C4 RID: 452
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x040001C5 RID: 453
		private string enable = Resources.enabled;

		// Token: 0x040001C6 RID: 454
		private string disabled = Resources.disabled;

		// Token: 0x040001C7 RID: 455
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x040001C8 RID: 456
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x040001C9 RID: 457
		private string error = Resources.error;

		// Token: 0x040001CA RID: 458
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x040001CB RID: 459
		private static byte[] Body = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
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
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			49,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			49
		};

		// Token: 0x040001CC RID: 460
		private static byte[] Body1 = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			66,
			97,
			110,
			100,
			105,
			116,
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
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040001CD RID: 461
		private static byte[] BodyPart = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
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
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67
		};

		// Token: 0x040001CE RID: 462
		private static byte[] BodyPart1 = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			66,
			97,
			110,
			100,
			105,
			116,
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
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67,
			0
		};

		// Token: 0x040001CF RID: 463
		private static byte[] FaceAcc = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			49,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			49,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99
		};

		// Token: 0x040001D0 RID: 464
		private static byte[] FaceAcc1 = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			66,
			97,
			110,
			100,
			105,
			116,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040001D1 RID: 465
		private static byte[] FaceAccBP = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			71,
			114,
			97,
			102,
			102,
			105,
			116,
			105,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67
		};

		// Token: 0x040001D2 RID: 466
		private static byte[] FaceAccBP1 = new byte[]
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
			80,
			108,
			97,
			121,
			101,
			114,
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			66,
			97,
			110,
			100,
			105,
			116,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			67,
			97,
			118,
			97,
			108,
			114,
			121,
			95,
			66,
			97,
			110,
			100,
			105,
			116,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67,
			0
		};

		private static byte[] CID = new byte[]
		{
			69,
			70,
			111,
			114,
			116,
			67,
			117,
			115,
			116,
			111,
			109,
			71,
			101,
			110,
			100,
			101,
			114,
			58,
			58,
			70,
			101,
			109,
			97,
			108,
			101
		};

		// Token: 0x0400043F RID: 1087
		private static byte[] CID1 = new byte[]
		{
			69,
			70,
			111,
			114,
			116,
			67,
			117,
			115,
			116,
			111,
			109,
			71,
			101,
			110,
			100,
			101,
			114,
			58,
			58,
			70,
			101,
			109,
			97,
			49,
			101
		};
	}
}
