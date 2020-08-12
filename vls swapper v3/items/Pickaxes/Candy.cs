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

namespace vls_swapper_v3.Picks
{
	// Token: 0x02000094 RID: 148
	public partial class Candy : MaterialForm
	{
		// Token: 0x0600088E RID: 2190 RVA: 0x000B0D00 File Offset: 0x000AEF00
		public Candy()
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
			this.Text = "Candy";
			bool candyEnabled = Settings.Default.CandyEnabled;
			bool flag3 = candyEnabled;
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

		// Token: 0x0600088F RID: 2191 RVA: 0x000B0E7D File Offset: 0x000AF07D
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x000B0E88 File Offset: 0x000AF088
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000B0EE9 File Offset: 0x000AF0E9
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x000B0F04 File Offset: 0x000AF104
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x000B0F65 File Offset: 0x000AF165
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000B0F80 File Offset: 0x000AF180
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
				string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
				string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				Stream stream = File.OpenRead(path2);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Candy.CandyMesh))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Candy.LolMesh);
					binaryWriter.Close();
					Settings.Default.CandyEnabled = false;
					Settings.Default.Save();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Mesh removed!";
				}
				Stream stream2 = File.OpenRead(path2);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Candy.CandyIcon))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Candy.LolIcon);
					binaryWriter2.Close();
					RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
					richTextBoxInfo3.Text += "\n[LOG] Icons removed!";
				}
				Stream stream3 = File.OpenRead(path);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpickmesh, Candy.CandySwing))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Candy.LolSwing);
					binaryWriter3.Close();
					RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
					richTextBoxInfo4.Text += "\n[LOG] Sounds 1/5 removed!";
				}
				Stream stream4 = File.OpenRead(path);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpickmesh, Candy.CandySwing2))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(Candy.LolSwing2);
					binaryWriter4.Close();
					RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
					richTextBoxInfo5.Text += "\n[LOG] Sounds 2/5 removed!";
				}
				Stream stream5 = File.OpenRead(path);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpickmesh, Candy.CandySwing3))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(Candy.LolSwing3);
					binaryWriter5.Close();
					RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
					richTextBoxInfo6.Text += "\n[LOG] Sounds 3/5 removed!";
				}
				Stream stream6 = File.OpenRead(path);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpickmesh, Candy.CandySwing4))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(Candy.LolSwing4);
					binaryWriter6.Close();
					RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
					richTextBoxInfo7.Text += "\n[LOG] Sounds 4/5 removed!";
				}
				Stream stream7 = File.OpenRead(path);
				foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetpickmesh, Candy.CandySwing5))
				{
					stream7.Close();
					BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
					binaryWriter7.Write(Candy.LolSwing5);
					binaryWriter7.Close();
					RichTextBox richTextBoxInfo8 = this.RichTextBoxInfo;
					richTextBoxInfo8.Text += "\n[LOG] Sounds 5/5 removed!";
					RichTextBox richTextBoxInfo9 = this.RichTextBoxInfo;
					richTextBoxInfo9.Text += "\n[LOG] All Sounds were removed!";
				}
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				stopwatch.Stop();
				double num = (double)stopwatch.Elapsed.Seconds;
				RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x000B15AC File Offset: 0x000AF7AC
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
			string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
			string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			Stream stream = File.OpenRead(path2);
			foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Candy.LolMesh))
			{
				stream.Close();
				BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(Candy.CandyMesh);
				binaryWriter.Close();
				Settings.Default.CandyEnabled = true;
				Settings.Default.Save();
				RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
				richTextBoxInfo2.Text += "\n[LOG] Mesh added!";
			}
			Stream stream2 = File.OpenRead(path2);
			foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Candy.LolIcon))
			{
				stream2.Close();
				BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
				binaryWriter2.Write(Candy.CandyIcon);
				binaryWriter2.Close();
				RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
				richTextBoxInfo3.Text += "\n[LOG] Icons added!";
			}
			Stream stream3 = File.OpenRead(path);
			foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpickmesh, Candy.LolSwing))
			{
				stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(Candy.CandySwing);
				binaryWriter3.Close();
				RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
				richTextBoxInfo4.Text += "\n[LOG] Sounds 1/5 added!";
			}
			Stream stream4 = File.OpenRead(path);
			foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpickmesh, Candy.LolSwing2))
			{
				stream4.Close();
				BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
				binaryWriter4.Write(Candy.CandySwing2);
				binaryWriter4.Close();
				RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
				richTextBoxInfo5.Text += "\n[LOG] Sounds 2/5 added!";
			}
			Stream stream5 = File.OpenRead(path);
			foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpickmesh, Candy.LolSwing3))
			{
				stream5.Close();
				BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
				binaryWriter5.Write(Candy.CandySwing3);
				binaryWriter5.Close();
				RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
				richTextBoxInfo6.Text += "\n[LOG] Sounds 3/5 added!";
			}
			Stream stream6 = File.OpenRead(path);
			foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpickmesh, Candy.LolSwing4))
			{
				stream6.Close();
				BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
				binaryWriter6.Write(Candy.CandySwing4);
				binaryWriter6.Close();
				RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
				richTextBoxInfo7.Text += "\n[LOG] Sounds 4/5 added!";
			}
			Stream stream7 = File.OpenRead(path);
			foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetpickmesh, Candy.LolSwing5))
			{
				stream7.Close();
				BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
				binaryWriter7.Write(Candy.CandySwing5);
				binaryWriter7.Close();
				RichTextBox richTextBoxInfo8 = this.RichTextBoxInfo;
				richTextBoxInfo8.Text += "\n[LOG] Sounds 5/5 added!";
				RichTextBox richTextBoxInfo9 = this.RichTextBoxInfo;
				richTextBoxInfo9.Text += "\n[LOG] All Sounds were added!";
			}
			this.revert.Enabled = true;
			this.convert.Enabled = false;
			stopwatch.Stop();
			double num = (double)stopwatch.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000B1BBC File Offset: 0x000AFDBC
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

		// Token: 0x06000897 RID: 2199 RVA: 0x000B1C98 File Offset: 0x000AFE98
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

		// Token: 0x04000D39 RID: 3385
		private Point lastPoint;

		// Token: 0x04000D3A RID: 3386
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000D3B RID: 3387
		private string enable = Resources.enabled;

		// Token: 0x04000D3C RID: 3388
		private string disabled = Resources.disabled;

		// Token: 0x04000D3D RID: 3389
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000D3E RID: 3390
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000D3F RID: 3391
		private string error = Resources.error;

		// Token: 0x04000D40 RID: 3392
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000D41 RID: 3393
		private static byte[] LolMesh = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			70,
			79,
			82,
			84,
			95,
			77,
			101,
			108,
			101,
			101,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			108,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			46,
			83,
			75,
			95,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			108,
			111,
			108,
			108,
			105,
			112,
			111,
			112
		};

		// Token: 0x04000D42 RID: 3394
		private static byte[] CandyMesh = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			70,
			79,
			82,
			84,
			95,
			77,
			101,
			108,
			101,
			101,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			49,
			53,
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			49,
			53,
			46,
			83,
			75,
			95,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			49,
			53,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000D43 RID: 3395
		private static byte[] LolIcon = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			73,
			99,
			111,
			110,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			73,
			116,
			101,
			109,
			115,
			47,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			46,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112
		};

		// Token: 0x04000D44 RID: 3396
		private static byte[] CandyIcon = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			73,
			99,
			111,
			110,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			73,
			116,
			101,
			109,
			115,
			47,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			49,
			53,
			46,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			49,
			53,
			0,
			0,
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

		// Token: 0x04000D45 RID: 3397
		private static byte[] LolBigIcon = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			73,
			99,
			111,
			110,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			73,
			116,
			101,
			109,
			115,
			47,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			45,
			76,
			46,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			45,
			76
		};

		// Token: 0x04000D46 RID: 3398
		private static byte[] CandyBigIcon = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			85,
			73,
			47,
			70,
			111,
			117,
			110,
			100,
			97,
			116,
			105,
			111,
			110,
			47,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			47,
			73,
			99,
			111,
			110,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			73,
			116,
			101,
			109,
			115,
			47,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			49,
			53,
			45,
			76,
			46,
			84,
			45,
			73,
			99,
			111,
			110,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			115,
			45,
			83,
			75,
			45,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			49,
			53,
			45,
			76,
			0,
			0,
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

		// Token: 0x04000D47 RID: 3399
		private static byte[] LolSwing = new byte[]
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
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			115,
			47,
			67,
			97,
			110,
			100,
			121,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			49,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			49
		};

		// Token: 0x04000D48 RID: 3400
		private static byte[] CandySwing = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			70,
			111,
			114,
			116,
			95,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			65,
			120,
			101,
			115,
			47,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			49,
			46,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
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

		// Token: 0x04000D49 RID: 3401
		private static byte[] LolSwing2 = new byte[]
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
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			115,
			47,
			67,
			97,
			110,
			100,
			121,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			50,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			50
		};

		// Token: 0x04000D4A RID: 3402
		private static byte[] CandySwing2 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			70,
			111,
			114,
			116,
			95,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			65,
			120,
			101,
			115,
			47,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			50,
			46,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			50,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000D4B RID: 3403
		private static byte[] LolSwing3 = new byte[]
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
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			115,
			47,
			67,
			97,
			110,
			100,
			121,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			51,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			51
		};

		// Token: 0x04000D4C RID: 3404
		private static byte[] CandySwing3 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			70,
			111,
			114,
			116,
			95,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			65,
			120,
			101,
			115,
			47,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			51,
			46,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			51,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000D4D RID: 3405
		private static byte[] LolSwing4 = new byte[]
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
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			115,
			47,
			67,
			97,
			110,
			100,
			121,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			53,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			53
		};

		// Token: 0x04000D4E RID: 3406
		private static byte[] CandySwing4 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			70,
			111,
			114,
			116,
			95,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			65,
			120,
			101,
			115,
			47,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			53,
			46,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			53,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000D4F RID: 3407
		private static byte[] LolSwing5 = new byte[]
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
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			115,
			47,
			67,
			97,
			110,
			100,
			121,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			54,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			67,
			97,
			110,
			100,
			121,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			54
		};

		// Token: 0x04000D50 RID: 3408
		private static byte[] CandySwing5 = new byte[]
		{
			47,
			71,
			97,
			109,
			101,
			47,
			83,
			111,
			117,
			110,
			100,
			115,
			47,
			70,
			111,
			114,
			116,
			95,
			87,
			101,
			97,
			112,
			111,
			110,
			115,
			47,
			65,
			120,
			101,
			115,
			47,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			54,
			46,
			70,
			105,
			114,
			101,
			95,
			65,
			120,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			48,
			54,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000D51 RID: 3409
		private static byte[] LolCIDY = new byte[]
		{
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			73,
			68,
			95,
			48,
			52,
			54,
			95,
			67,
			97,
			110,
			100,
			121
		};

		// Token: 0x04000D52 RID: 3410
		private static byte[] CandyCIDY = new byte[]
		{
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			73,
			68,
			95,
			48,
			52,
			54,
			95,
			89,
			89,
			89,
			89,
			89
		};

		// Token: 0x04000D53 RID: 3411
		private static byte[] LolCID = new byte[]
		{
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			73,
			68,
			95,
			48,
			49,
			53,
			95,
			72,
			111,
			108,
			105,
			100,
			97,
			121,
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101
		};

		// Token: 0x04000D54 RID: 3412
		private static byte[] CandyCID = new byte[]
		{
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			73,
			68,
			95,
			48,
			52,
			54,
			95,
			67,
			97,
			110,
			100,
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
			0
		};
	}
}
