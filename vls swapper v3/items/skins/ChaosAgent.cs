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
	// Token: 0x0200002F RID: 47
	public partial class ChaosAgent : MaterialForm
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x000378F0 File Offset: 0x00035AF0
		public ChaosAgent()
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
			this.Text = "ChaosAgent";
			MessageBox.Show("This skin uses Catalyst [Tier2], be sure to select this style before swapping the ChaosAgent!");
			bool chaosAgentEnabled = Settings.Default.ChaosAgentEnabled;
			bool flag3 = chaosAgentEnabled;
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

		// Token: 0x060003E5 RID: 997 RVA: 0x00037A78 File Offset: 0x00035C78
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00037A84 File Offset: 0x00035C84
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00037AE5 File Offset: 0x00035CE5
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00037B00 File Offset: 0x00035D00
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00037B61 File Offset: 0x00035D61
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00037B7C File Offset: 0x00035D7C
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
			if (cancellationPending)
			{
				e.Cancel = true;
			}
			else
			{
				this.revert.Enabled = false;
				this.RichTextBoxInfo.Text = "";
				RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
				richTextBoxInfo.Text += "[LOG] Starting...";
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				Stream stream = File.OpenRead(path);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetskin, ChaosAgent.Body1))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(ChaosAgent.Body);
					binaryWriter.Close();
					Settings.Default.ChaosAgentEnabled = false;
					Settings.Default.Save();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 1/2 removed!";
				}
				for (int i = 0; i < 4; i++)
				{
					Stream stream2 = File.OpenRead(path);
					foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, ChaosAgent.BodyAnim1))
					{
						stream2.Close();
						BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
						binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
						binaryWriter2.Write(ChaosAgent.BodyAnim);
						binaryWriter2.Close();
						this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body Anim removed! [" + i.ToString() + "]";
					}
				}
				Stream stream3 = File.OpenRead(path2);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, ChaosAgent.Head1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(ChaosAgent.Head);
					binaryWriter3.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/3 removed!";
				}
				Stream stream4 = File.OpenRead(path2);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ChaosAgent.Head1))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(ChaosAgent.Head);
					binaryWriter4.Close();
				}
				Stream stream5 = File.OpenRead(path2);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ChaosAgent.HeadAnim1))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(ChaosAgent.HeadAnim);
					binaryWriter5.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/3 removed!";
				}
				Stream stream6 = File.OpenRead(path2);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, ChaosAgent.HeadAnim1))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(ChaosAgent.HeadAnim);
					binaryWriter6.Close();
				}
				Stream stream7 = File.OpenRead(path2);
				foreach (long num in Researcher.FindPosition(stream7, 0, (long)offsetskin2, ChaosAgent.offsetr))
				{
					stream7.Close();
					BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					long offset7 = num + 1225L;
					binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
					binaryWriter7.Write(ChaosAgent.FaceAcc);
					binaryWriter7.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 3/3 removed!";
				}
				string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
				Stream stream8 = File.OpenRead(path3);
				foreach (long offset8 in Researcher.FindPosition(stream8, 0, (long)offsetlobby, ChaosAgent.CID1))
				{
					stream8.Close();
					BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter8.BaseStream.Seek(offset8, SeekOrigin.Begin);
					binaryWriter8.Write(ChaosAgent.CID);
					binaryWriter8.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Locker Icon removed!";
				}
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				stopwatch.Stop();
				double num2 = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00038260 File Offset: 0x00036460
		private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
		{
			if (Settings.Default.WhiteoutEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "Whiteout" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
				return;
			}



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
			string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			Stream stream = File.OpenRead(path2);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetskin, ChaosAgent.Body))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(ChaosAgent.Body1);
				binaryWriter.Close();
				Settings.Default.ChaosAgentEnabled = true;
				Settings.Default.Save();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 1/2 added!";
			}
			for (int i = 0; i < 4; i++)
			{
				Stream stream2 = File.OpenRead(path2);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, ChaosAgent.BodyAnim))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(ChaosAgent.BodyAnim1);
					binaryWriter2.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body Anim added! [" + i.ToString() + "]";
				}
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, ChaosAgent.Head))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(ChaosAgent.Head1);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/3 added!";
			}
			Stream stream4 = File.OpenRead(path);
			foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ChaosAgent.Head))
			{
				stream4.Close();
				BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
				binaryWriter4.Write(ChaosAgent.Head1);
				binaryWriter4.Close();
			}
			Stream stream5 = File.OpenRead(path);
			foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ChaosAgent.HeadAnim))
			{
				stream5.Close();
				BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
				binaryWriter5.Write(ChaosAgent.HeadAnim1);
				binaryWriter5.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/3 added!";
			}
			Stream stream6 = File.OpenRead(path);
			foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, ChaosAgent.HeadAnim))
			{
				stream6.Close();
				BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
				binaryWriter6.Write(ChaosAgent.HeadAnim1);
				binaryWriter6.Close();
			}
			Stream stream7 = File.OpenRead(path);
			foreach (long num in Researcher.FindPosition(stream7, 0, (long)offsetskin2, ChaosAgent.offsetr))
			{
				stream7.Close();
				BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				long offset7 = num + 1225L;
				binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
				binaryWriter7.Write(ChaosAgent.FaceAcc1);
				binaryWriter7.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 3/3 added!";
			}
			string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
			Stream stream8 = File.OpenRead(path3);
			foreach (long offset8 in Researcher.FindPosition(stream8, 0, (long)offsetlobby, ChaosAgent.CID))
			{
				stream8.Close();
				BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter8.BaseStream.Seek(offset8, SeekOrigin.Begin);
				binaryWriter8.Write(ChaosAgent.CID1);
				binaryWriter8.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num2 = (double)stopwatch.Elapsed.Seconds;
			this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			




		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00038994 File Offset: 0x00036B94
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

		// Token: 0x060003ED RID: 1005 RVA: 0x00038A64 File Offset: 0x00036C64
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

		// Token: 0x060003EE RID: 1006 RVA: 0x00038B07 File Offset: 0x00036D07
		private void RichTextBoxInfo_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000350 RID: 848
		private Point lastPoint;

		// Token: 0x04000351 RID: 849
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000352 RID: 850
		private string enable = Resources.enabled;

		// Token: 0x04000353 RID: 851
		private string disabled = Resources.disabled;

		// Token: 0x04000354 RID: 852
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000355 RID: 853
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000356 RID: 854
		private string error = Resources.error;

		// Token: 0x04000357 RID: 855
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000358 RID: 856
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			50,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
			95,
			82,
			101,
			109,
			105,
			120,
			95,
			84,
			50
		};

		// Token: 0x04000359 RID: 857
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			46,
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
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

		// Token: 0x0400035A RID: 858
		private static byte[] BodyAnim = new byte[]
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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

		// Token: 0x0400035B RID: 859
		private static byte[] BodyAnim1 = new byte[]
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
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x0400035C RID: 860
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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
			83,
			82,
			95,
			68,
			114,
			105,
			102,
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
			84,
			50,
			51,
			52,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			83,
			82,
			95,
			68,
			114,
			105,
			102,
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
			84,
			50,
			51,
			52
		};

		// Token: 0x0400035D RID: 861
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
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			77,
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
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			95,
			72,
			101,
			97,
			100,
			46,
			77,
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
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x0400035E RID: 862
		private static byte[] HeadAnim = new byte[]
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
			83,
			116,
			114,
			101,
			101,
			116,
			95,
			82,
			97,
			99,
			101,
			114,
			95,
			68,
			114,
			105,
			102,
			116,
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
			83,
			82,
			95,
			68,
			114,
			105,
			102,
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
			84,
			50,
			51,
			52,
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
			83,
			82,
			95,
			68,
			114,
			105,
			102,
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
			84,
			50,
			51,
			52,
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

		// Token: 0x0400035F RID: 863
		private static byte[] HeadAnim1 = new byte[]
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
			77,
			95,
			77,
			69,
			68,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
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
			77,
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
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			95,
			72,
			101,
			97,
			100,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			46,
			77,
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
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			95,
			72,
			101,
			97,
			100,
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
			0
		};

		// Token: 0x04000360 RID: 864
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
			116,
			97,
			114,
			102,
			105,
			115,
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
			116,
			97,
			114,
			102,
			105,
			115,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			50,
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
			116,
			97,
			114,
			102,
			105,
			115,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			50
		};

		// Token: 0x04000361 RID: 865
		private static byte[] FaceAcc1 = new byte[]
		{
			47,
			48,
			48,
			48,
			48,
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
			116,
			97,
			114,
			102,
			105,
			115,
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
			116,
			97,
			114,
			102,
			105,
			115,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			50,
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
			116,
			97,
			114,
			102,
			105,
			115,
			104,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			50
		};

		// Token: 0x04000362 RID: 866
		private static byte[] offsetr = new byte[]
		{
			238,
			132,
			71,
			200,
			0,
			0,
			0,
			0,
			49,
			11,
			0,
			0,
			217,
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
			53,
			11
		};

		// Token: 0x04000363 RID: 867
		private static byte[] CID = new byte[]
		{
			67,
			73,
			68,
			95,
			52,
			56,
			54,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
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
			83,
			116,
			114,
			101,
			101,
			116,
			82,
			97,
			99,
			101,
			114,
			68,
			114,
			105,
			102,
			116,
			46,
			67,
			73,
			68,
			95,
			52,
			56,
			54,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
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
			83,
			116,
			114,
			101,
			101,
			116,
			82,
			97,
			99,
			101,
			114,
			68,
			114,
			105,
			102,
			116
		};

		// Token: 0x04000364 RID: 868
		private static byte[] CID1 = new byte[]
		{
			67,
			73,
			68,
			95,
			53,
			57,
			56,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
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
			77,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
			100,
			46,
			67,
			73,
			68,
			95,
			53,
			57,
			56,
			95,
			65,
			116,
			104,
			101,
			110,
			97,
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
			77,
			95,
			77,
			97,
			115,
			116,
			101,
			114,
			109,
			105,
			110,
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
	}
}
