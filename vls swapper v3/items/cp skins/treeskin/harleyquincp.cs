
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;
using vls_swapper_v3.IO;

namespace vls_swapper_v3.Emotes
{
    public partial class harleyquincp : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        private MaterialRaisedButton revert;
        private MaterialRaisedButton convert;
        private PictureBox pictureBox1;
        private RichTextBox RichTextBoxInfo;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public harleyquincp()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "harley quin";
            bool enabled = Settings.Default.harleyquincp;
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

        


        public static void ReplaceBytes(string pak, long offset, byte[] bytes)
        {
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(pak, FileMode.Open, FileAccess.ReadWrite));
            binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
            binaryWriter.Write(bytes);
            binaryWriter.Close();
        }

		private static byte[] Body = new byte[]
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
			72,
			101,
			114,
			111,
			101,
			115,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65,
			46,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65
		};

		// Token: 0x040007B1 RID: 1969
		private static byte[] Body1 = new byte[]
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
			72,
			101,
			114,
			111,
			101,
			115,
			47,
			77,
			101,
			115,
			104,
			101,
			115,
			47,
			66,
			111,
			100,
			105,
			101,
			115,
			47,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			46,
			67,
			80,
			95,
			66,
			111,
			100,
			121,
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
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			0,
			0,
			0,
			0,
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

		// Token: 0x040007B2 RID: 1970
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
			67,
			104,
			97,
			114,
			97,
			99,
			116,
			101,
			114,
			80,
			97,
			114,
			116,
			115,
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
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65,
			46,
			67,
			80,
			95,
			72,
			101,
			97,
			100,
			95,
			70,
			95,
			82,
			101,
			98,
			105,
			114,
			116,
			104,
			68,
			101,
			102,
			97,
			117,
			108,
			116,
			65
		};

		// Token: 0x040007B3 RID: 1971
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
			67,
			104,
			97,
			114,
			97,
			99,
			116,
			101,
			114,
			80,
			97,
			114,
			116,
			115,
			47,
			70,
			97,
			99,
			101,
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
			67,
			80,
			95,
			70,
			95,
			77,
			69,
			68,
			95,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			46,
			67,
			80,
			95,
			70,
			95,
			77,
			69,
			68,
			95,
			76,
			111,
			108,
			108,
			105,
			112,
			111,
			112,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
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

		private static byte[] CP = new byte[]
		{
			0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,108,100,105,101,114
		};
		private static byte[] CP1 = new byte[]
		{
			0,0,67,80,95,65,116,104,101,110,97,95,72,101,97,100,95,77,95,79,114,110,97,109,101,110,116,83,111,49,100,105,101,114
		};




		private void revert_Click(object sender, EventArgs e)
        {
			string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath1))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}



			revert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

			harleyquincp.ReplaceBytes(filePath, 3268051L, harleyquincp.Head1);
			harleyquincp.ReplaceBytes(filePath, 3268051L, harleyquincp.Head);
			this.RichTextBoxInfo.AppendText("\n[LOG] head removed!");
			harleyquincp.ReplaceBytes(filePath, 3264546L, harleyquincp.Body1);
			harleyquincp.ReplaceBytes(filePath, 3264546L, harleyquincp.Body);
			this.RichTextBoxInfo.AppendText("\n[LOG] body removed!");
			harleyquincp.ReplaceBytes(filePath, 203378241L, harleyquincp.CP1);
			harleyquincp.ReplaceBytes(filePath, 203378241L, harleyquincp.CP);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp removed!");
			Settings.Default.cpskinEnabled = false;
			Settings.Default.harleyquincp = false;
			Settings.Default.Save();

			convert.Enabled = true;
			revert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

        private void convert_Click(object sender, EventArgs e)
        {
			string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath1))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}

			if (Settings.Default.cpskinEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "a cp skin has been already converted " + MessageBoxButtons.OK + MessageBoxIcon.Error, 100);
				return;
			}

			CheckForIllegalCrossThreadCalls = false;


			convert.Enabled = false;

			RichTextBoxInfo.Text += "[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

			harleyquincp.ReplaceBytes(filePath, 3268051L, harleyquincp.Head);
			harleyquincp.ReplaceBytes(filePath, 3268051L, harleyquincp.Head1);
			this.RichTextBoxInfo.AppendText("\n[LOG] head added!");
			harleyquincp.ReplaceBytes(filePath, 3264546L, harleyquincp.Body);
			harleyquincp.ReplaceBytes(filePath, 3264546L, harleyquincp.Body1);
			this.RichTextBoxInfo.AppendText("\n[LOG] body added!");
			harleyquincp.ReplaceBytes(filePath, 203378241L, harleyquincp.CP);
			harleyquincp.ReplaceBytes(filePath, 203378241L, harleyquincp.CP1);
			this.RichTextBoxInfo.AppendText("\n[LOG] cp added!");
			Settings.Default.harleyquincp = true;
			Settings.Default.cpskinEnabled = true;
			Settings.Default.Save();

			revert.Enabled = true;
			convert.Enabled = false;
			sw.Stop();
			double elapsed = sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
		}

        private void AstroJack_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(harleyquincp));
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 113);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 91;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 76);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 93;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 76);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 90;
            this.RichTextBoxInfo.Text = "";
            // 
            // harleyquincp
            // 
            this.ClientSize = new System.Drawing.Size(442, 245);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "harleyquincp";
            this.Sizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
