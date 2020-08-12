﻿using vls_swapper_v3.Properties;
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
	// Token: 0x02000028 RID: 40
	public partial class Haze : MaterialForm
	{
		// Token: 0x06000389 RID: 905 RVA: 0x0002EDA4 File Offset: 0x0002CFA4
		public Haze()
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
			this.Text = "Haze";
			bool hazeEnabled = Settings.Default.HazeEnabled;
			bool flag3 = hazeEnabled;
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

		// Token: 0x0600038A RID: 906 RVA: 0x0002EF21 File Offset: 0x0002D121
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0002EF2C File Offset: 0x0002D12C
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0002EF8D File Offset: 0x0002D18D
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0002EFA8 File Offset: 0x0002D1A8
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0002F009 File Offset: 0x0002D209
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0002F024 File Offset: 0x0002D224
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
				string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
				string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
				string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
				string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
				string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
				string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
				Stream stream = File.OpenRead(bodypath);
				foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, Haze.Body1))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
					binaryWriter.Write(Haze.Body);
					long offset = num + 988L;
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Haze.CID);
					binaryWriter.Close();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Body 1/2 removed!";
				}
				Stream stream2 = File.OpenRead(bodypath);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, Haze.BodyPart1))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Haze.BodyPart);
					binaryWriter2.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/2 removed!";
				}
				Stream stream3 = File.OpenRead(headpath);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, Haze.Head1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Haze.Head);
					binaryWriter3.Close();
					Settings.Default.HazeEnabled = false;
					Settings.Default.Save();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/2 removed!";
				}
				Stream stream4 = File.OpenRead(headpath);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, Haze.HeadPart1))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(Haze.HeadPart);
					binaryWriter4.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/2 removed!";
				}
				Stream stream5 = File.OpenRead(headpath);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, Haze.HeadMat1))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(Haze.HeadMat);
					binaryWriter5.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head Material removed!";
				}
				Stream stream6 = File.OpenRead(headpath);
				foreach (long num2 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, Haze.offsetr))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
					long offset6 = num2 + 239L;
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(Haze.HeadSpecial);
					binaryWriter6.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head Special removed!";
				}
				string text2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				stopwatch.Stop();
				double num3 = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0002F680 File Offset: 0x0002D880
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
			RichTextBox richTextBox = richTextBoxInfo;
			richTextBox.Text += "[LOG] Starting...";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
			string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
			string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
			string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
			string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
			string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
			Stream stream = File.OpenRead(bodypath);
			foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, Haze.Body))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
				binaryWriter.Write(Haze.Body1);
				long offset = num + 988L;
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Haze.CID1);
				binaryWriter.Close();
				RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
				richTextBoxInfo2.Text += "\n[LOG] Body 1/2 added!";
			}
			Stream stream2 = File.OpenRead(bodypath);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, Haze.BodyPart))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Haze.BodyPart1);
				binaryWriter2.Close();
				Settings.Default.HazeEnabled = true;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/2 added!";
			}
			Stream stream3 = File.OpenRead(headpath);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, Haze.Head))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Haze.Head1);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/2 added!";
			}
			Stream stream4 = File.OpenRead(headpath);
			foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, Haze.HeadPart))
			{
				stream4.Close();
				BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
				binaryWriter4.Write(Haze.HeadPart1);
				binaryWriter4.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/2 added!";
			}
			Stream stream5 = File.OpenRead(headpath);
			foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, Haze.HeadMat))
			{
				stream5.Close();
				BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
				binaryWriter5.Write(Haze.HeadMat1);
				binaryWriter5.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head Material added!";
			}
			Stream stream6 = File.OpenRead(headpath);
			foreach (long num2 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, Haze.offsetr))
			{
				stream6.Close();
				BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
				long offset6 = num2 + 239L;
				binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
				binaryWriter6.Write(Haze.HeadSpecial1);
				binaryWriter6.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head Special added!";
			}
			string text2 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num3 = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0002FE0C File Offset: 0x0002E00C
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

		// Token: 0x06000392 RID: 914 RVA: 0x0002FEB0 File Offset: 0x0002E0B0
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

		// Token: 0x0400028D RID: 653
		private Point lastPoint;

		// Token: 0x0400028E RID: 654
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x0400028F RID: 655
		private string enable = Resources.enabled;

		// Token: 0x04000290 RID: 656
		private string disabled = Resources.disabled;

		// Token: 0x04000291 RID: 657
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000292 RID: 658
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000293 RID: 659
		private string error = Resources.error;

		// Token: 0x04000294 RID: 660
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000295 RID: 661
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110
		};

		// Token: 0x04000296 RID: 662
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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

		// Token: 0x04000297 RID: 663
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			95,
			65,
			110,
			105,
			109,
			66,
			112,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			95,
			65,
			110,
			105,
			109,
			66,
			112,
			95,
			67
		};

		// Token: 0x04000298 RID: 664
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
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

		// Token: 0x04000299 RID: 665
		private static byte[] Head = new byte[]
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			95,
			70,
			97,
			99,
			101,
			65,
			99,
			99
		};

		// Token: 0x0400029A RID: 666
		private static byte[] Head1 = new byte[]
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			0,
			0,
			0
		};

		// Token: 0x0400029B RID: 667
		private static byte[] HeadPart = new byte[]
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			95,
			72,
			117,
			110,
			116,
			101,
			114,
			95,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
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
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			72,
			117,
			110,
			116,
			101,
			114,
			70,
			97,
			115,
			104,
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
			112,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			72,
			117,
			110,
			116,
			101,
			114,
			70,
			97,
			115,
			104,
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
			112,
			95,
			67
		};

		// Token: 0x0400029C RID: 668
		private static byte[] HeadPart1 = new byte[]
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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
			80,
			117,
			110,
			107,
			95,
			68,
			101,
			118,
			105,
			108,
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

		// Token: 0x0400029D RID: 669
		private static byte[] HeadMat = new byte[]
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
			72,
			101,
			97,
			100,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			65,
			83,
			78,
			95,
			83,
			97,
			114,
			97,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			47,
			83,
			107,
			105,
			110,
			115,
			47,
			84,
			114,
			101,
			97,
			115,
			117,
			114,
			101,
			72,
			117,
			110,
			116,
			101,
			114,
			70,
			47,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			84,
			72,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			95,
			72,
			101,
			97,
			100,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			84,
			72,
			70,
			97,
			115,
			104,
			105,
			111,
			110,
			95,
			72,
			101,
			97,
			100
		};

		// Token: 0x0400029E RID: 670
		private static byte[] HeadMat1 = new byte[]
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
			72,
			101,
			97,
			100,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			77,
			101,
			100,
			117,
			115,
			97,
			95,
			72,
			101,
			97,
			100,
			47,
			83,
			107,
			105,
			110,
			115,
			47,
			80,
			117,
			110,
			107,
			68,
			101,
			118,
			105,
			108,
			47,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			80,
			117,
			110,
			107,
			68,
			101,
			118,
			105,
			108,
			95,
			72,
			101,
			97,
			100,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			80,
			117,
			110,
			107,
			68,
			101,
			118,
			105,
			108,
			95,
			72,
			101,
			97,
			100,
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

		// Token: 0x0400029F RID: 671
		private static byte[] HeadSpecial = new byte[]
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
			72,
			101,
			97,
			100,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			65,
			83,
			78,
			95,
			83,
			97,
			114,
			97,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
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
			65,
			83,
			78,
			95,
			83,
			97,
			114,
			97,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			65,
			83,
			78,
			95,
			83,
			97,
			114,
			97,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49
		};

		// Token: 0x040002A0 RID: 672
		private static byte[] HeadSpecial1 = new byte[]
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
			72,
			101,
			97,
			100,
			115,
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			77,
			101,
			100,
			117,
			115,
			97,
			95,
			72,
			101,
			97,
			100,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			70,
			101,
			109,
			97,
			108,
			101,
			95,
			77,
			101,
			100,
			105,
			117,
			109,
			95,
			77,
			101,
			100,
			117,
			115,
			97,
			95,
			72,
			101,
			97,
			100,
			46,
			70,
			101,
			109,
			97,
			108,
			101,
			95,
			77,
			101,
			100,
			105,
			117,
			109,
			95,
			77,
			101,
			100,
			117,
			115,
			97,
			95,
			72,
			101,
			97,
			100,
			0,
			0
		};

		// Token: 0x040002A1 RID: 673
		private static byte[] offsetr = new byte[]
		{
			150,
			190,
			72,
			149,
			0,
			0,
			0,
			0,
			128,
			10,
			0,
			0,
			3,
			13,
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
			6,
			0,
			0,
			0,
			132,
			10,
			0,
			0,
			84,
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
