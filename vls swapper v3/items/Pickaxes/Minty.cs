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
using MetroFramework;

namespace vls_swapper_v3.Picks
{
	// Token: 0x0200008A RID: 138
	public partial class Minty : MaterialForm
	{
		// Token: 0x0600080C RID: 2060 RVA: 0x000A1D14 File Offset: 0x0009FF14
		public Minty()
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
			this.Text = "Merry Mint Axe";
			bool mintyEnabled = Settings.Default.MintyEnabled;
			bool flag3 = mintyEnabled;
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

		// Token: 0x0600080D RID: 2061 RVA: 0x000A1E91 File Offset: 0x000A0091
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x000A1E9C File Offset: 0x000A009C
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x000A1EFD File Offset: 0x000A00FD
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x000A1F18 File Offset: 0x000A0118
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x000A1F79 File Offset: 0x000A0179
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000A1F94 File Offset: 0x000A0194
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
				string text = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
				Stream stream = File.OpenRead(text);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Minty.Mesh1))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Minty.Mesh);
					binaryWriter.Close();
					Settings.Default.MintyEnabled = false;
					Settings.Default.Save();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Mesh removed!";
				}
				Stream stream2 = File.OpenRead(text);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Minty.MeshMat1))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Minty.MeshMat);
					binaryWriter2.Close();
					RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
					richTextBoxInfo3.Text += "\n[LOG] Mesh Material removed!";
				}
				Stream stream3 = File.OpenRead(text);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpick, Minty.Icone1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Minty.Icone);
					binaryWriter3.Close();
					RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
					richTextBoxInfo4.Text += "\n[LOG] Icons removed!";
				}
				Stream stream4 = File.OpenRead(path);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpick, Minty.Swing1T))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(Minty.Swing1);
					binaryWriter4.Close();
					RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
					richTextBoxInfo5.Text += "\n[LOG] Sound 1/3 removed!";
				}
				Stream stream5 = File.OpenRead(path);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpick, Minty.Swing2T))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(Minty.Swing2);
					binaryWriter5.Close();
					RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
					richTextBoxInfo6.Text += "\n[LOG] Sound 2/3 removed!";
				}
				Stream stream6 = File.OpenRead(path);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpick, Minty.Swing3T))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(Minty.Swing3);
					binaryWriter6.Close();
					RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
					richTextBoxInfo7.Text += "\n[LOG] Sound 3/3 removed!";
				}
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				stopwatch.Stop();
				double num = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x000A24F0 File Offset: 0x000A06F0
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
			bool pickaxeGalaxy = Settings.Default.PickaxeGalaxy;
			if (pickaxeGalaxy)
			{
				MetroMessageBox.Show(this, "Galaxy Pickaxe" + this.actsomewhelse, this.error, MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
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
				Stream stream = File.OpenRead(text);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Minty.Mesh))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(Minty.Mesh1);
					binaryWriter.Close();
					Settings.Default.MintyEnabled = true;
					Settings.Default.Save();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Mesh added!";
				}
				Stream stream2 = File.OpenRead(text);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Minty.MeshMat))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(Minty.MeshMat1);
					binaryWriter2.Close();
					RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
					richTextBoxInfo3.Text += "\n[LOG] Mesh Material added!";
				}
				Stream stream3 = File.OpenRead(text);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpick, Minty.Icone))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(Minty.Icone1);
					binaryWriter3.Close();
					RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
					richTextBoxInfo4.Text += "\n[LOG] Icons added!";
				}
				Stream stream4 = File.OpenRead(path);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpick, Minty.Swing1))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(Minty.Swing1T);
					binaryWriter4.Close();
					RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
					richTextBoxInfo5.Text += "\n[LOG] Sound 1/3 added!";
				}
				Stream stream5 = File.OpenRead(path);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpick, Minty.Swing2))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(Minty.Swing2T);
					binaryWriter5.Close();
					RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
					richTextBoxInfo6.Text += "\n[LOG] Sound 2/3 added!";
				}
				Stream stream6 = File.OpenRead(path);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpick, Minty.Swing3))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(Minty.Swing3T);
					binaryWriter6.Close();
					RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
					richTextBoxInfo7.Text += "\n[LOG] Sound 3/3 added!";
				}
				this.revert.Enabled = true;
				this.convert.Enabled = false;
				stopwatch.Stop();
				double num = (double)stopwatch.Elapsed.Seconds;
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x000A2A64 File Offset: 0x000A0C64
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

		// Token: 0x06000815 RID: 2069 RVA: 0x000A2B08 File Offset: 0x000A0D08
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

		// Token: 0x04000C07 RID: 3079
		private Point lastPoint;

		// Token: 0x04000C08 RID: 3080
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000C09 RID: 3081
		private string enable = Resources.enabled;

		// Token: 0x04000C0A RID: 3082
		private string disabled = Resources.disabled;

		// Token: 0x04000C0B RID: 3083
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000C0C RID: 3084
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000C0D RID: 3085
		private string error = Resources.error;

		// Token: 0x04000C0E RID: 3086
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000C0F RID: 3087
		private static byte[] Mesh = new byte[]
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116,
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116,
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116
		};

		// Token: 0x04000C10 RID: 3088
		private static byte[] Mesh1 = new byte[]
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000C11 RID: 3089
		private static byte[] MeshMat = new byte[]
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
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
			77,
			73,
			95,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			46,
			77,
			73,
			95,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			100,
			75,
			110,
			105,
			103,
			104,
			116,
			95,
			87,
			105,
			110,
			116,
			101,
			114
		};

		// Token: 0x04000C12 RID: 3090
		private static byte[] MeshMat1 = new byte[]
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
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
			77,
			73,
			95,
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
			67,
			97,
			110,
			101,
			46,
			77,
			73,
			95,
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
			67,
			97,
			110,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000C13 RID: 3091
		private static byte[] Icone = new byte[]
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			73,
			68,
			45,
			49,
			52,
			51,
			45,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			73,
			68,
			45,
			49,
			52,
			51,
			45,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114
		};

		// Token: 0x04000C14 RID: 3092
		private static byte[] Icone1 = new byte[]
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			80,
			105,
			99,
			107,
			97,
			120,
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
			0
		};

		// Token: 0x04000C15 RID: 3093
		private static byte[] IconeT = new byte[]
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			73,
			68,
			45,
			49,
			52,
			51,
			45,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
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
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			45,
			73,
			68,
			45,
			49,
			52,
			51,
			45,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
			45,
			76
		};

		// Token: 0x04000C16 RID: 3094
		private static byte[] IconeT1 = new byte[]
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000C17 RID: 3095
		private static byte[] Swing1 = new byte[]
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			83,
			119,
			105,
			110,
			103,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			83,
			119,
			105,
			110,
			103
		};

		// Token: 0x04000C18 RID: 3096
		private static byte[] Swing1T = new byte[]
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
			67,
			97,
			110,
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			67,
			117,
			101,
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
			67,
			97,
			110,
			101,
			95,
			83,
			119,
			105,
			110,
			103,
			95,
			67,
			117,
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
			0
		};

		// Token: 0x04000C19 RID: 3097
		private static byte[] Swing2 = new byte[]
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			73,
			109,
			112,
			97,
			99,
			116,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			73,
			109,
			112,
			97,
			99,
			116
		};

		// Token: 0x04000C1A RID: 3098
		private static byte[] Swing2T = new byte[]
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
			67,
			97,
			110,
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			95,
			73,
			109,
			112,
			97,
			99,
			116,
			95,
			67,
			117,
			101,
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
			67,
			97,
			110,
			101,
			95,
			73,
			109,
			112,
			97,
			99,
			116,
			95,
			67,
			117,
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
			0
		};

		// Token: 0x04000C1B RID: 3099
		private static byte[] Swing3 = new byte[]
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
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			87,
			105,
			110,
			116,
			101,
			114,
			47,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			97,
			100,
			121,
			46,
			80,
			105,
			99,
			107,
			97,
			120,
			101,
			95,
			87,
			105,
			110,
			116,
			101,
			114,
			70,
			108,
			105,
			110,
			116,
			108,
			111,
			99,
			107,
			95,
			82,
			101,
			97,
			100,
			121
		};

		// Token: 0x04000C1C RID: 3100
		private static byte[] Swing3T = new byte[]
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
			67,
			97,
			110,
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
			67,
			97,
			110,
			100,
			121,
			67,
			97,
			110,
			101,
			95,
			69,
			113,
			117,
			105,
			112,
			50,
			95,
			67,
			117,
			101,
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
			67,
			97,
			110,
			101,
			95,
			69,
			113,
			117,
			105,
			112,
			50,
			95,
			67,
			117,
			101,
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
