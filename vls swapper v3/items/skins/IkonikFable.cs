using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using vls_swapper_v3;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Skins
{
    public partial class IkonikFable : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public IkonikFable()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Ikonik";      
            bool enabled = Settings.Default.IkonikFableEnabled;
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

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private static byte[] Body = new byte[122]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,46,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72
        };

        private static byte[] Body1 = new byte[122]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,77,95,77,69,68,95,75,112,111,112,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,46,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] BodyAnim = new byte[175]
        {
            47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,66,80,46,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,82,101,100,82,105,100,105,110,103,72,111,111,100,95,80,114,111,116,111,95,77,69,83,72,95,83,107,101,108,101,116,111,110,95,65,66,80,95,67
        };

        private static byte[] BodyAnim1 = new byte[175]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,77,95,77,69,68,95,75,112,111,112,70,97,115,104,105,111,110,47,77,101,115,104,101,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,65,110,105,109,66,80,46,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] BodySkel = new byte[94]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,97,115,101,47,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,46,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110
        };

        private static byte[] BodySkel1 = new byte[94]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,97,115,101,47,83,75,95,77,95,77,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,46,83,75,95,77,95,77,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,0,0,0,0,0,0
        };

        private static byte[] Head = new byte[144]
       {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,82,101,100,82,105,100,105,110,103,46,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,82,101,100,82,105,100,105,110,103
       };

        private static byte[] Head1 = new byte[144]
      {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,97,105,114,95,78,111,72,97,105,114,46,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,97,105,114,95,78,111,72,97,105,114,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
      };

        private static byte[] HeadNull = new byte[118]
    {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,100,46,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,100
    };

        private static byte[] HeadNull1 = new byte[118]
 {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,97,116,101,114,105,97,108,115,47,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,49,46,77,73,95,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,95,72,101,97,49
 };

        private static byte[] HeadMesh = new byte[131]
{
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49
};

        private static byte[] HeadMesh1 = new byte[131]
{
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,47,77,101,115,104,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,46,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] HeadMeshBP = new byte[159]
{
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,46,70,95,77,69,68,95,65,83,78,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,95,67
};

        private static byte[] HeadMeshBP1 = new byte[159]
{
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,47,77,101,115,104,47,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,46,77,95,77,69,68,95,65,83,78,95,74,97,101,95,72,101,97,100,95,48,49,95,65,110,105,109,66,80,95,67,104,105,108,100,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] HeadPart = new byte[176]
{
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,69,121,101,108,97,115,104,101,115,95,69,120,112,111,114,116,46,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,69,121,101,108,97,115,104,101,115,95,69,120,112,111,114,116,95,69,89,69,76,65,83,72,69,83,95,77,69,83,72
};

        private static byte[] HeadPart1 = new byte[176]
{
          47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,72,97,116,47,77,101,115,104,101,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99,46,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] HeadSkel = new byte[167]
{
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,82,101,100,82,105,100,105,110,103,47,77,101,115,104,47,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,108,97,115,104,101,95,83,107,101,108,101,116,111,110,95,65,66,80,46,70,101,109,97,108,101,95,77,101,100,105,117,109,95,83,116,97,114,102,105,115,104,95,72,101,97,100,95,48,49,95,108,97,115,104,101,95,83,107,101,108,101,116,111,110,95,65,66,80,95,67
};

        private static byte[] HeadSkel1 = new byte[167]
{
          47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,72,97,116,47,77,101,115,104,101,115,47,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99,95,65,110,105,109,66,80,46,77,95,77,69,68,95,75,112,111,112,95,70,97,115,104,105,111,110,95,70,97,99,101,65,99,99,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] offseth = new byte[37]
{
          107,156,16,13,0,0,0,0,140,11,0,0,81,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,144,11,0,0,58
};

        private static byte[] offsetskel = new byte[35]
{
          107,132,0,0,0,0,67,8,0,0,164,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,71,8,0,0,63
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
                string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
                this.RichTextBoxInfo.Text = "";
                RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
                richTextBoxInfo.Text += "[LOG] Starting...";
                Stream stream = File.OpenRead(path2);
                foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, IkonikFable.Body1))
                {
                    stream.Close();
                    BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                    binaryWriter.Write(IkonikFable.Body);
                    long offset = num + 976L;
                    binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                    binaryWriter.Write(IkonikFable.CID);
                    binaryWriter.Close();
                    RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                    richTextBoxInfo2.Text += "\n[LOG] Body removed!";
                    Settings.Default.IkonikFableEnabled = false;
                    Settings.Default.Save();
                }
                Stream stream2 = File.OpenRead(path);
                foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, IkonikFable.BodyAnim1))
                {
                    stream2.Close();
                    Settings.Default.IkonikFableEnabled = false;
                    Settings.Default.Save();
                    BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                    binaryWriter2.Write(IkonikFable.BodyAnim);
                    binaryWriter2.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/3 Removed!";
                }
                Stream stream3 = File.OpenRead(path);
                foreach (long num2 in Researcher.FindPosition(stream3, 0, (long)offsetskin, IkonikFable.offsetskel))
                {
                    stream3.Close();
                    BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    long offset3 = num2 + 186L;
                    binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                    binaryWriter3.Write(IkonikFable.BodySkel);
                    binaryWriter3.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 3/3 Removed!";
                }
                Stream stream4 = File.OpenRead(path2);
                foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, IkonikFable.Head1))
                {
                    stream4.Close();
                    BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                    binaryWriter4.Write(IkonikFable.Head);
                    binaryWriter4.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/5 Removed!";
                }
                Stream stream5 = File.OpenRead(path2);
                foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, IkonikFable.HeadNull1))
                {
                    stream5.Close();
                    BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                    binaryWriter5.Write(IkonikFable.HeadNull);
                    binaryWriter5.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/5 Removed!";
                }
                Stream stream6 = File.OpenRead(path2);
                foreach (long num3 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, IkonikFable.offseth))
                {
                    stream6.Close();
                    BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    long offset6 = num3 + 1028L;
                    long offset7 = num3 + 1294L;
                    binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
                    binaryWriter6.Write(IkonikFable.HeadMesh);
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 3/5 Removed!";
                    binaryWriter6.BaseStream.Seek(offset7, SeekOrigin.Begin);
                    binaryWriter6.Write(IkonikFable.HeadMeshBP);
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 4/5 Removed!";
                    binaryWriter6.Close();
                }
                Stream stream7 = File.OpenRead(path2);
                foreach (long offset8 in Researcher.FindPosition(stream7, 0, (long)offsetskin2, IkonikFable.HeadPart1))
                {
                    stream7.Close();
                    BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter7.BaseStream.Seek(offset8, SeekOrigin.Begin);
                    binaryWriter7.Write(IkonikFable.HeadPart);
                    binaryWriter7.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 5/5 Removed!";
                }
                Stream stream8 = File.OpenRead(path2);
                foreach (long offset9 in Researcher.FindPosition(stream8, 0, (long)offsetskin2, IkonikFable.HeadSkel1))
                {
                    stream8.Close();
                    BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter8.BaseStream.Seek(offset9, SeekOrigin.Begin);
                    binaryWriter8.Write(IkonikFable.HeadSkel);
                    binaryWriter8.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Skeleton Removed!";
                }
                string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
                Stream stream9 = File.OpenRead(path3);
                foreach (long offset10 in Researcher.FindPosition(stream9, 0, (long)offsetlobby, IkonikFable.CID1))
                {
                    stream9.Close();
                    BinaryWriter binaryWriter9 = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter9.BaseStream.Seek(offset10, SeekOrigin.Begin);
                    binaryWriter9.Write(IkonikFable.CID);
                    binaryWriter9.Close();
                }
                this.revert.Enabled = false;
                this.convert.Enabled = true;
                stopwatch.Stop();
                double num4 = (double)stopwatch.Elapsed.Seconds;
            }
        }

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
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, IkonikFable.Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(IkonikFable.Body1);
                long offset = num + 976L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(IkonikFable.CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body removed!";
            }
            Stream stream2 = File.OpenRead(path);
            foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetskin, IkonikFable.BodyAnim))
            {
                stream2.Close();
                Settings.Default.IkonikFableEnabled = true;
                Settings.Default.Save();
                BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                binaryWriter2.Write(IkonikFable.BodyAnim1);
                binaryWriter2.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 2/3 added!";
            }
            Stream stream3 = File.OpenRead(path);
            foreach (long num2 in Researcher.FindPosition(stream3, 0, (long)offsetskin, IkonikFable.offsetskel))
            {
                stream3.Close();
                BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                long offset3 = num2 + 186L;
                binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                binaryWriter3.Write(IkonikFable.BodySkel1);
                binaryWriter3.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body 3/3 added!";
            }
            Stream stream4 = File.OpenRead(path2);
            foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, IkonikFable.Head))
            {
                stream4.Close();
                BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                binaryWriter4.Write(IkonikFable.Head1);
                binaryWriter4.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 1/5 added!";
            }
            Stream stream5 = File.OpenRead(path2);
            foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, IkonikFable.HeadNull))
            {
                stream5.Close();
                BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                binaryWriter5.Write(IkonikFable.HeadNull1);
                binaryWriter5.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 2/5 added!";
            }
            Stream stream6 = File.OpenRead(path2);
            foreach (long num3 in Researcher.FindPosition(stream6, 0, (long)offsetskin2, IkonikFable.offseth))
            {
                stream6.Close();
                BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                long offset6 = num3 + 1028L;
                long offset7 = num3 + 1294L;
                binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
                binaryWriter6.Write(IkonikFable.HeadMesh1);
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 3/5 added!";
                binaryWriter6.BaseStream.Seek(offset7, SeekOrigin.Begin);
                binaryWriter6.Write(IkonikFable.HeadMeshBP1);
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 4/5 added!";
                binaryWriter6.Close();
            }
            Stream stream7 = File.OpenRead(path2);
            foreach (long offset8 in Researcher.FindPosition(stream7, 0, (long)offsetskin2, IkonikFable.HeadPart))
            {
                stream7.Close();
                BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter7.BaseStream.Seek(offset8, SeekOrigin.Begin);
                binaryWriter7.Write(IkonikFable.HeadPart1);
                binaryWriter7.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head 5/5 added!";
            }
            Stream stream8 = File.OpenRead(path2);
            foreach (long offset9 in Researcher.FindPosition(stream8, 0, (long)offsetskin2, IkonikFable.HeadSkel))
            {
                stream8.Close();
                BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter8.BaseStream.Seek(offset9, SeekOrigin.Begin);
                binaryWriter8.Write(IkonikFable.HeadSkel1);
                binaryWriter8.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Skeleton added!";
            }
            string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream stream9 = File.OpenRead(path3);
            foreach (long offset10 in Researcher.FindPosition(stream9, 0, (long)offsetlobby, IkonikFable.CID))
            {
                stream9.Close();
                BinaryWriter binaryWriter9 = new BinaryWriter(File.Open(path3, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter9.BaseStream.Seek(offset10, SeekOrigin.Begin);
                binaryWriter9.Write(IkonikFable.CID1);
                binaryWriter9.Close();
            }
            this.revert.Enabled = true;
            this.convert.Enabled = false;
            stopwatch.Stop();
            double num4 = (double)stopwatch.Elapsed.Seconds;
        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
            
            else
            {

               CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
                change1Bytes.RunWorkerAsync();
            }
        }

        private void revert_Click(object sender, EventArgs e)
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
