﻿using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace vls_swapper_v3.items.skins
{
    public partial class ReconExpert : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public ReconExpert()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "Recon Expert";
            bool enabled = Settings.Default.ReconEnabled;
            if (enabled)
            {
                revert.Enabled = true;
                convert.Enabled = false;
            }
            else
            {
                revert.Enabled = false;
                convert.Enabled = true;

            }
        }


        


        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetlobby = Settings.Default.offsetlobby;
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
				string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
				Stream stream = File.OpenRead(path3);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, ReconExpert.CID1))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(ReconExpert.CID);
					binaryWriter.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
				}
				Stream stream2 = File.OpenRead(path);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin2, ReconExpert.Skin1))
				{
					stream2.Close();
					Settings.Default.ReconEnabled = false;
					Settings.Default.Save();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(ReconExpert.Skin);
					binaryWriter2.Close();
					RichTextBoxInfo.Text += "\n[LOG] Skin Color removed!";
				}
				Stream stream3 = File.OpenRead(path2);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin, ReconExpert.Body1))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(ReconExpert.Body);
					binaryWriter3.Close();
					RichTextBoxInfo.Text += "\n[LOG] Body removed!";
				}
				Stream stream4 = File.OpenRead(path);
				foreach (long num in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ReconExpert.offsetr))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					long num2 = num + 893L;
					long offset4 = num2 + 257L;
					binaryWriter4.BaseStream.Seek(num2, SeekOrigin.Begin);
					binaryWriter4.Write(ReconExpert.HeadMesh);
					RichTextBoxInfo.Text += "\n[LOG] HeadMesh removed!";
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(ReconExpert.HeadMeshBP);
					RichTextBoxInfo.Text += "\n[LOG] HeadMeshBP removed!";
					binaryWriter4.Close();
				}
				Stream stream5 = File.OpenRead(path);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ReconExpert.Hat1))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(ReconExpert.Hat);
					binaryWriter5.Close();
					RichTextBoxInfo.Text += "\n[LOG] Hat 1/2 removed!";
				}
				Stream stream6 = File.OpenRead(path);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, ReconExpert.HatTex1))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(ReconExpert.HatTex);
					binaryWriter6.Close();
					RichTextBoxInfo.Text += "\n[LOG] Hat 2/2 removed!";
				}
				Stream stream7 = File.OpenRead(path);
				foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetskin2, ReconExpert.HeadTex1))
				{
					stream7.Close();
					BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
					binaryWriter7.Write(ReconExpert.HeadTex);
					binaryWriter7.Close();
					RichTextBoxInfo.Text += "\n[LOG] Head removed!";
				}
				Stream stream8 = File.OpenRead(path);
				foreach (long num3 in Researcher.FindPosition(stream8, 0, (long)offsetskin2, ReconExpert.offsethair))
				{
					stream8.Close();
					BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					long num4 = num3 + 1125L;
					num4 = num4;
					binaryWriter8.BaseStream.Seek(num4, SeekOrigin.Begin);
					binaryWriter8.Write(ReconExpert.Hair);
					RichTextBoxInfo.Text += "\n[LOG] Hair removed!";
				}
				this.revert.Enabled = false;
				this.convert.Enabled = true;
				RichTextBoxInfo.Text += "\n[LOG] Done";
			}
		}

        private void change1Bytes_DoWork(object sender, DoWorkEventArgs e)
        {
			Control.CheckForIllegalCrossThreadCalls = false;
			int offsetskin = Settings.Default.offsetskin1;
			int offsetback = Settings.Default.offsetback;
			int offsetskin2 = Settings.Default.offsetskin2;
			int offsetlobby = Settings.Default.offsetlobby;
			bool cancellationPending = this.revert1Bytes.CancellationPending;
			if (cancellationPending)
			{
				e.Cancel = true;
			}
			
			if (Settings.Default.RenegadeEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "Renegade Raider" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
				return;
			}

			if (Settings.Default.WonderEnable)
			{
				MetroFramework.MetroMessageBox.Show(this, "Wonder" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
				return;
			}

			if (Settings.Default.CheckRenegadeEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "Renegade Raider [checkerd]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
				return;
			}

			else
			{
				convert.Enabled = false;
				this.RichTextBoxInfo.Text = "";
				RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
				richTextBoxInfo.Text += "[LOG] Starting...";
				string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
				string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
				Stream stream = File.OpenRead(path3);
				foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetlobby, ReconExpert.CID))
				{
					stream.Close();
					BinaryWriter binaryWriter = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
					binaryWriter.Write(ReconExpert.CID1);
					binaryWriter.Close();
					this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID Added!";
				}
				Stream stream2 = File.OpenRead(path);
				foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin2, ReconExpert.Skin))
				{
					stream2.Close();
					Settings.Default.ReconEnabled = true;
					Settings.Default.Save();
					BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
					binaryWriter2.Write(ReconExpert.Skin1);
					binaryWriter2.Close();
					RichTextBoxInfo.Text += "\n[LOG] Skin Color Added!";
				}
				Stream stream3 = File.OpenRead(path2);
				foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin, ReconExpert.Body))
				{
					stream3.Close();
					BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
					binaryWriter3.Write(ReconExpert.Body1);
					binaryWriter3.Close();
					RichTextBoxInfo.Text += "\n[LOG] Body Added!";
				}
				Stream stream4 = File.OpenRead(path);
				foreach (long num in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ReconExpert.offsetr))
				{
					stream4.Close();
					BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					long num2 = num + 893L;
					long offset4 = num2 + 257L;
					binaryWriter4.BaseStream.Seek(num2, SeekOrigin.Begin);
					binaryWriter4.Write(ReconExpert.HeadMesh1);
					RichTextBoxInfo.Text += "\n[LOG] HeadMesh Added!";
					binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
					binaryWriter4.Write(ReconExpert.HeadMeshBP1);
					RichTextBoxInfo.Text += "\n[LOG] HeadMeshBP Added!";
					binaryWriter4.Close();
				}
				Stream stream5 = File.OpenRead(path);
				foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ReconExpert.Hat))
				{
					stream5.Close();
					BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
					binaryWriter5.Write(ReconExpert.Hat1);
					binaryWriter5.Close();
					RichTextBoxInfo.Text += "\n[LOG] Hat 1/2 Added!";
				}
				Stream stream6 = File.OpenRead(path);
				foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, ReconExpert.HatTex))
				{
					stream6.Close();
					BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
					binaryWriter6.Write(ReconExpert.HatTex1);
					binaryWriter6.Close();
					RichTextBoxInfo.Text += "\n[LOG] Hat 2/2 Added!";
				}
				Stream stream7 = File.OpenRead(path);
				foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetskin2, ReconExpert.HeadTex))
				{
					stream7.Close();
					BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
					binaryWriter7.Write(ReconExpert.HeadTex1);
					binaryWriter7.Close();
					RichTextBoxInfo.Text += "\n[LOG] Head Added!";
				}
				Stream stream8 = File.OpenRead(path);
				foreach (long num3 in Researcher.FindPosition(stream8, 0, (long)offsetskin2, ReconExpert.offsethair))
				{
					stream8.Close();
					BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
					long num4 = num3 + 1125L;
					num4 = num4;
					binaryWriter8.BaseStream.Seek(num4, SeekOrigin.Begin);
					binaryWriter8.Write(ReconExpert.Hair1);
					RichTextBoxInfo.Text += "\n[LOG] Hair Added!";
				}
				convert.Enabled = false;
				revert.Enabled = true;
				RichTextBoxInfo.Text += "\n[LOG] Done!";

			}
		}

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
            CheckForIllegalCrossThreadCalls = false;
            change1Bytes.RunWorkerAsync();
        }

        private void revert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
            CheckForIllegalCrossThreadCalls = false; 
            revert1Bytes.RunWorkerAsync();
        }



		private static byte[] HeadTex = new byte[]
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
			101,
			100,
			95,
			83,
			111,
			108,
			100,
			105,
			101,
			114,
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
			70,
			101,
			109,
			97,
			108,
			101,
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
			66,
			108,
			97,
			99,
			107,
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
			66,
			108,
			97,
			99,
			107,
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
			66,
			108,
			97,
			99,
			107,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49
		};

		
		private static byte[] HeadTex1 = new byte[]
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
			101,
			100,
			95,
			83,
			111,
			108,
			100,
			105,
			101,
			114,
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
			70,
			101,
			109,
			97,
			108,
			101,
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
			66,
			108,
			97,
			99,
			107,
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
			66,
			108,
			97,
			99,
			107,
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
			66,
			108,
			97,
			99,
			107,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			57
		};

		
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
			101,
			100,
			95,
			83,
			111,
			108,
			100,
			105,
			101,
			114,
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
			70,
			101,
			109,
			97,
			108,
			101,
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
			66,
			108,
			97,
			99,
			107,
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
			95,
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
			66,
			108,
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
			95,
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
			66,
			108,
			97,
			99,
			107
		};

		
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
			101,
			100,
			95,
			83,
			111,
			108,
			100,
			105,
			101,
			114,
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
			86,
			95,
			49,
			52,
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
			67,
			111,
			109,
			109,
			97,
			110,
			100,
			111,
			95,
			66,
			111,
			100,
			121,
			95,
			84,
			86,
			49,
			52,
			46,
			70,
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
			66,
			111,
			100,
			121,
			95,
			84,
			86,
			49,
			52,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		
		private static byte[] Hat = new byte[]
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
			72,
			97,
			116,
			115,
			47,
			77,
			101,
			115,
			104,
			47,
			70,
			101,
			109,
			97,
			108,
			101,
			95,
			79,
			117,
			116,
			108,
			97,
			110,
			100,
			101,
			114,
			95,
			48,
			54,
			46,
			70,
			101,
			109,
			97,
			108,
			101,
			95,
			79,
			117,
			116,
			108,
			97,
			110,
			100,
			101,
			114,
			95,
			48,
			54
		};

		
		private static byte[] Hat1 = new byte[]
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
			72,
			97,
			116,
			115,
			47,
			77,
			101,
			115,
			104,
			47,
			70,
			101,
			109,
			97,
			108,
			101,
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
			48,
			54,
			46,
			70,
			101,
			109,
			97,
			108,
			101,
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
			48,
			54,
			0,
			0
		};

		
		private static byte[] HatTex = new byte[]
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
			72,
			97,
			116,
			115,
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
			72,
			97,
			116,
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
			66,
			108,
			97,
			99,
			107,
			46,
			72,
			97,
			116,
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
			66,
			108,
			97,
			99,
			107
		};

		
		private static byte[] HatTex1 = new byte[]
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
			72,
			97,
			116,
			115,
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
			101,
			109,
			97,
			108,
			101,
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
			48,
			54,
			46,
			70,
			101,
			109,
			97,
			108,
			101,
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
			48,
			54,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		
		private static byte[] HeadMesh = new byte[]
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
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
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
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
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
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49
		};

		
		private static byte[] HeadMesh1 = new byte[]
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
			66,
			76,
			75,
			95,
			82,
			101,
			100,
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
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			66,
			76,
			75,
			95,
			82,
			101,
			100,
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
			66,
			76,
			75,
			95,
			82,
			101,
			100,
			95,
			72,
			101,
			97,
			100,
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
			0
		};

		
		private static byte[] HeadMeshBP = new byte[]
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
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
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
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67,
			104,
			105,
			108,
			100,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			72,
			73,
			83,
			95,
			82,
			97,
			109,
			105,
			114,
			101,
			122,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67,
			104,
			105,
			108,
			100,
			95,
			67
		};

		
		private static byte[] HeadMeshBP1 = new byte[]
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
			66,
			76,
			75,
			95,
			82,
			101,
			100,
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
			47,
			70,
			95,
			77,
			69,
			68,
			95,
			66,
			76,
			75,
			95,
			82,
			101,
			100,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
			95,
			67,
			104,
			105,
			108,
			100,
			46,
			70,
			95,
			77,
			69,
			68,
			95,
			66,
			76,
			75,
			95,
			82,
			101,
			100,
			95,
			72,
			101,
			97,
			100,
			95,
			48,
			49,
			95,
			65,
			110,
			105,
			109,
			66,
			80,
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
			0
		};

		
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
			73,
			116,
			101,
			109,
			115,
			47,
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
			67,
			73,
			68,
			95,
			49,
			54,
			50,
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
			46,
			67,
			73,
			68,
			95,
			49,
			54,
			50,
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
			114
		};

		
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
			73,
			116,
			101,
			109,
			115,
			47,
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
			67,
			73,
			68,
			95,
			48,
			50,
			50,
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
			46,
			67,
			73,
			68,
			95,
			48,
			50,
			50,
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
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		
		private static byte[] Skin = new byte[]
		{
			83,
			107,
			105,
			110,
			47,
			70,
			95,
			77,
			101,
			100,
			95,
			72,
			73,
			83,
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
			66,
			108,
			97,
			99,
			107,
			46,
			70,
			95,
			77,
			101,
			100,
			95,
			72,
			73,
			83,
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
			66,
			108,
			97,
			99,
			107
		};

		
		private static byte[] Skin1 = new byte[]
		{
			83,
			107,
			105,
			110,
			47,
			70,
			95,
			77,
			101,
			100,
			95,
			66,
			76,
			75,
			46,
			70,
			95,
			77,
			101,
			100,
			95,
			66,
			76,
			75,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		
		private static byte[] Hair = new byte[]
		{
			69,
			67,
			117,
			115,
			116,
			111,
			109,
			72,
			97,
			116,
			84,
			121,
			112,
			101,
			95,
			72,
			101,
			108,
			109,
			101,
			116
		};

		
		private static byte[] Hair1 = new byte[]
		{
			69,
			67,
			117,
			115,
			116,
			111,
			109,
			72,
			97,
			116,
			84,
			121,
			112,
			101,
			95,
			72,
			97,
			116,
			0,
			0,
			0
		};

		
		private static byte[] offsetr = new byte[]
		{
			51,
			119,
			123,
			0,
			0,
			0,
			0,
			17,
			11,
			0,
			0,
			148,
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
			21,
			11,
			0,
			0,
			58,
			0,
			0,
			0
		};

		
		private static byte[] offsethair = new byte[]
		{
			104,
			177,
			4,
			241,
			0,
			0,
			0,
			0,
			62,
			8,
			0,
			0,
			50,
			10,
			0,
			0,
			0,
			0,
			0,
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
			66,
			8,
			0,
			0,
			56,
			0,
			0,
			0
		};

		private void ReconExpert_Load(object sender, EventArgs e)
		{

		}
	}
}