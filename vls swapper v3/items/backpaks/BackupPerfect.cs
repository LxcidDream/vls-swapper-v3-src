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

namespace vls_swapper_v3.Backblings
{
    public partial class BackupPerfect : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public BackupPerfect()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Backup Plan";
            bool enabled = Settings.Default.BackupPerfectEnabled;
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

        private static byte[] Mesh = new byte[81]
              {
    47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,101,115,104,47,83,75,95,83,104,105,101,108,100,95,66,108,97,99,107,107,110,105,103,104,116,46,83,75,95,83,104,105,101,108,100,95,66,108,97,99,107,107,110,105,103,104,116
              };
        private static byte[] Mesh1 = new byte[81]
        {
     47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,101,115,104,47,77,97,108,101,95,67,111,109,109,97,110,100,111,95,48,50,46,77,97,108,101,95,67,111,109,109,97,110,100,111,95,48,50,0,0,0,0,0,0,0,0,0,0
        };
        private static byte[] MeshBP = new byte[106]
     {
    47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,97,116,101,114,105,97,108,115,47,77,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,107,110,105,103,104,116,86,48,49,46,77,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,107,110,105,103,104,116,86,48,49
     };
        private static byte[] MeshBP1 = new byte[106]
{
   47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,70,79,82,84,95,66,97,99,107,112,97,99,107,115,47,77,97,116,101,114,105,97,108,115,47,77,97,108,101,95,67,111,109,109,97,110,100,111,95,48,50,95,83,116,101,97,108,116,104,82,97,112,116,111,114,46,77,97,108,101,95,67,111,109,109,97,110,100,111,95,48,50,95,83,116,101,97,108,116,104,82,97,112,116,111,114,0,0
};

        private static byte[] offsetr = new byte[]
{
   240,90,148,13,0,0,0,0,37,9,0,0,17,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,41,9,0
};
        private static byte[] CID = new byte[35]
{
  66,73,68,95,48,48,51,95,82,101,100,75,110,105,103,104,116,46,66,73,68,95,48,48,51,95,82,101,100,75,110,105,103,104,116
};
        private static byte[] CID1 = new byte[35]
{
 66,73,68,95,48,50,57,95,82,101,116,114,111,71,114,101,121,46,66,73,68,95,48,50,57,95,82,101,116,114,111,71,114,101,121
};

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            revert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID1))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Removed!";
            }

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, offsetr))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                long meshset = s + 574;
                binaryWriter.BaseStream.Seek(meshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh);
                binaryWriter.Close();
                Settings.Default.BackupPerfectEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 removed!";

            }


            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetback, MeshBP1))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(MeshBP);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 removed!";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done added!";
            }




            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;



            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";


            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID Added!";
            }

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetback, offsetr))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                long meshset = s + 574;
                binaryWriter.BaseStream.Seek(meshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.BackupPerfectEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 1/2 added!";

            }

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetback, MeshBP))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(MeshBP1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Backbling 2/2 added!";

            }
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done added!";



            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            
        }

        private void convert_Click(object sender, EventArgs e)
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
    }
}
