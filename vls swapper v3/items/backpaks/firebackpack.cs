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
using vls_swapper_v3.IO;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Emotes
{
    public partial class firebackpack : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        private RichTextBox RichTextBoxInfo;
        private BackgroundWorker revert1Bytes;
        private BackgroundWorker change1Bytes;
        private PictureBox pictureBox1;
        private MaterialRaisedButton revert;
        private MaterialRaisedButton convert;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public firebackpack()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Flame Sigil";
            bool enabled = Settings.Default.FlameSigilenabled;
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

            change1Bytes.DoWork += ChangeBytes_DoWork;
            revert1Bytes.DoWork += RevertBytes_DoWork;
        }

        
             

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";



            Stream fs024 = File.OpenRead(filePath1);
            foreach (long s in Researcher.FindPosition(fs024, 0, offsetback, bb2))
            {

                fs024.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(bb1);
                long headmeshset = s + 1155;
                binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CID);
                binaryWrite.Close();
                Settings.Default.FlameSigilenabled = false;
                Settings.Default.Save();


            }





            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] backbling removed!";
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.GalaxyDiscEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "galaxy disc" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            convert.Enabled = false;

            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            Stream fs024 = File.OpenRead(filePath1);
            foreach (long s in Researcher.FindPosition(fs024, 0, offsetback, bb1))
            {

                fs024.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWrite.Write(bb2);
                long headmeshset = s + 1155;
                binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                binaryWrite.Write(CID1);
                binaryWrite.Close();
                Settings.Default.FlameSigilenabled = true;
                Settings.Default.Save();


            }



            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] backbling added!";
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {

        }

        private void revert_Click(object sender, EventArgs e)
        {

        }


        private static byte[] CID = new byte[23]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,66,111,116,104
        };

        private static byte[] CID1 = new byte[23]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,66,48,116,104
        };

		private static byte[] bb2 = new byte[]
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
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			95,
			72,
			111,
			108,
			111,
			115,
			47,
			70,
			88,
			47,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			70,
			108,
			97,
			116,
			98,
			101,
			100,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			0,
			165,
			209,
			30,
			206,
			119,
			0,
			0,
			0,
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
			68,
			101,
			118,
			105,
			108,
			82,
			111,
			99,
			107,
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
			70,
			88,
			47,
			66,
			80,
			95,
			77,
			95,
			77,
			69,
			68,
			95,
			68,
			101,
			118,
			105,
			108,
			82,
			111,
			99,
			107,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			46,
			66,
			80,
			95,
			77,
			95,
			77,
			69,
			68,
			95,
			68,
			101,
			118,
			105,
			108,
			82,
			111,
			99,
			107,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			67
		};

		// Token: 0x040000CF RID: 207
		private static byte[] bb1 = new byte[]
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
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			95,
			72,
			111,
			108,
			111,
			115,
			47,
			70,
			88,
			47,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			70,
			108,
			97,
			116,
			98,
			101,
			100,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			0,
			165,
			209,
			30,
			206,
			119,
			0,
			0,
			0,
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
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			95,
			72,
			111,
			108,
			111,
			115,
			47,
			70,
			88,
			47,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			70,
			108,
			97,
			116,
			98,
			101,
			100,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			46,
			67,
			67,
			80,
			77,
			95,
			71,
			97,
			108,
			105,
			108,
			101,
			111,
			70,
			108,
			97,
			116,
			98,
			101,
			100,
			95,
			66,
			97,
			99,
			107,
			112,
			97,
			99,
			107,
			95,
			67
		};







		private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firebackpack));
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.revert1Bytes = new System.ComponentModel.BackgroundWorker();
            this.change1Bytes = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 70);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 70;
            this.RichTextBoxInfo.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 107);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 72;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click_1);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 70);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 71;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click_1);
            // 
            // firebackpack
            // 
            this.ClientSize = new System.Drawing.Size(444, 238);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "firebackpack";
            this.Sizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void convert_Click_1(object sender, EventArgs e)
        {
			string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}
			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
			change1Bytes.RunWorkerAsync();
		}

        private void revert_Click_1(object sender, EventArgs e)
        {
			string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

			if (!File.Exists(filePath))
			{
				paks a = new paks(); a.ShowDialog();
				return;
			}
			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
			revert1Bytes.RunWorkerAsync();
		}
    }
}
