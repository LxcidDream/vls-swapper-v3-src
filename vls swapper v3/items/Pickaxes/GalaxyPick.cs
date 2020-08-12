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
using vls_swapper_v3.Picks;
using MetroFramework;

namespace vls_swapper_v3.Picks
{
	// Token: 0x0200008C RID: 140
	public partial class GalaxyPick : MaterialForm
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x000A52E4 File Offset: 0x000A34E4
		public GalaxyPick()
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
			this.Text = "Galaxy Pickaxe";
			bool pickaxeGalaxy = Settings.Default.PickaxeGalaxy;
			bool flag3 = pickaxeGalaxy;
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

		// Token: 0x06000827 RID: 2087 RVA: 0x000A5461 File Offset: 0x000A3661
		private void bunifuImageButton4_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x000A546C File Offset: 0x000A366C
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000A54CD File Offset: 0x000A36CD
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000A54E8 File Offset: 0x000A36E8
		private void label5_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000A5549 File Offset: 0x000A3749
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x000A5564 File Offset: 0x000A3764
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
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, GalaxyPick.Mesh1))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(GalaxyPick.Mesh);
					binaryWriter.Close();
					Settings.Default.PickaxeGalaxy = false;
					Settings.Default.Save();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Mesh removed!";
				}
				Stream stream2 = File.OpenRead(text);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, GalaxyPick.Icone1))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(GalaxyPick.Icone);
					binaryWriter2.Close();
					RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
					richTextBoxInfo3.Text += "\n[LOG] Galaxy removed!";
				}
				Stream stream3 = File.OpenRead(text);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpick, GalaxyPick.IconeT1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(GalaxyPick.IconeT);
					binaryWriter3.Close();
					RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
					richTextBoxInfo4.Text += "\n[LOG] Icons removed!";
				}
				Stream stream4 = File.OpenRead(text);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpick, GalaxyPick.IconeR1))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(GalaxyPick.IconeR);
					binaryWriter4.Close();
					RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
					richTextBoxInfo5.Text += "\n[LOG] Sound 1/3 removed!";
				}
				Stream stream5 = File.OpenRead(text);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpick, GalaxyPick.Legs1))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(GalaxyPick.Legs);
					binaryWriter5.Close();
					RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
					richTextBoxInfo6.Text += "\n[LOG] Sound 2/3 removed!";
				}
				Stream stream6 = File.OpenRead(text);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpick, GalaxyPick.CID1))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(GalaxyPick.CID);
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

		// Token: 0x0600082D RID: 2093 RVA: 0x000A5AC0 File Offset: 0x000A3CC0
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
			bool MintyEnabled = Settings.Default.MintyEnabled;
			if (MintyEnabled)
			{
				MetroMessageBox.Show(this, "Merry Mint Axe" + this.actsomewhelse, this.error, MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
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
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, GalaxyPick.Mesh))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(GalaxyPick.Mesh1);
					binaryWriter.Close();
					Settings.Default.PickaxeGalaxy = true;
					Settings.Default.Save();
					RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
					richTextBoxInfo2.Text += "\n[LOG] Mesh added!";
				}
				Stream stream2 = File.OpenRead(text);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, GalaxyPick.Icone))
				{
					stream2.Close();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(GalaxyPick.Icone1);
					binaryWriter2.Close();
					RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
					richTextBoxInfo3.Text += "\n[LOG] Galaxy added!";
				}
				Stream stream3 = File.OpenRead(text);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpick, GalaxyPick.IconeT))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(GalaxyPick.IconeT1);
					binaryWriter3.Close();
					RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
					richTextBoxInfo4.Text += "\n[LOG] Icons added!";
				}
				Stream stream4 = File.OpenRead(text);
				foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpick, GalaxyPick.IconeR))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(GalaxyPick.IconeR1);
					binaryWriter4.Close();
					RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
					richTextBoxInfo5.Text += "\n[LOG] Sound 1/3 added!";
				}
				Stream stream5 = File.OpenRead(text);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpick, GalaxyPick.Legs))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(GalaxyPick.Legs1);
					binaryWriter5.Close();
					RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
					richTextBoxInfo6.Text += "\n[LOG] Sound 2/3 added!";
				}
				Stream stream6 = File.OpenRead(text);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpick, GalaxyPick.CID))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(text, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(GalaxyPick.CID1);
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

		// Token: 0x0600082E RID: 2094 RVA: 0x000A6034 File Offset: 0x000A4234
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

		// Token: 0x0600082F RID: 2095 RVA: 0x000A60D8 File Offset: 0x000A42D8
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

		// Token: 0x04000C4F RID: 3151
		private Point lastPoint;

		// Token: 0x04000C50 RID: 3152
		private CultureInfo culture = CultureInfo.CurrentUICulture;

		// Token: 0x04000C51 RID: 3153
		private string enable = Resources.enabled;

		// Token: 0x04000C52 RID: 3154
		private string disabled = Resources.disabled;

		// Token: 0x04000C53 RID: 3155
		private string actsomewhelse = Resources.alreadydone;

		// Token: 0x04000C54 RID: 3156
		private string paksinvalid = Resources.pathinvalid;

		// Token: 0x04000C55 RID: 3157
		private string error = Resources.error;

		// Token: 0x04000C56 RID: 3158
		private MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		// Token: 0x04000C57 RID: 3159
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

		// Token: 0x04000C58 RID: 3160
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
			95,
			80,
			105,
			99,
			107,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
			46,
			77,
			73,
			95,
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
			95,
			80,
			105,
			99,
			107,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
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
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000C59 RID: 3161
		private static byte[] Icone = new byte[]
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

		// Token: 0x04000C5A RID: 3162
		private static byte[] Icone1 = new byte[]
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
			46,
			83,
			75,
			95,
			80,
			105,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		// Token: 0x04000C5B RID: 3163
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

		// Token: 0x04000C5C RID: 3164
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
			49,
			54,
			45,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			49,
			54,
			45,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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

		// Token: 0x04000C5D RID: 3165
		private static byte[] IconeL = new byte[]
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

		// Token: 0x04000C5E RID: 3166
		private static byte[] IconeL1 = new byte[]
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
			49,
			54,
			45,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			49,
			54,
			45,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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

		// Token: 0x04000C5F RID: 3167
		private static byte[] IconeR = new byte[]
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

		// Token: 0x04000C60 RID: 3168
		private static byte[] IconeR1 = new byte[]
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
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			65,
			120,
			101,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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

		// Token: 0x04000C61 RID: 3169
		private static byte[] Legs = new byte[]
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

		// Token: 0x04000C62 RID: 3170
		private static byte[] Legs1 = new byte[]
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
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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

		// Token: 0x04000C63 RID: 3171
		private static byte[] CID = new byte[]
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

		// Token: 0x04000C64 RID: 3172
		private static byte[] CID1 = new byte[]
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
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
			47,
			80,
			105,
			99,
			107,
			65,
			120,
			101,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
			65,
			120,
			101,
			95,
			67,
			101,
			108,
			101,
			115,
			116,
			105,
			97,
			108,
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
	}
}
