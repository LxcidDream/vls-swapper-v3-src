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
    public partial class BlackKnight : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public BlackKnight()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "BlackKnight";         
            bool enabled = Settings.Default.BlackKnightEnabled;
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

        private static byte[] Body = new byte[168]
        {
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,84,86,95,51,50,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114,47,77,97,116,101,114,105,97,108,115,47,77,95,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114,46,77,95,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114
        };
        private static byte[] Body1 = new byte[168]
       {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,77,95,77,101,100,95,83,111,108,100,105,101,114,95,48,52,47,83,107,105,110,115,47,66,82,95,66,108,97,99,107,75,110,105,103,104,116,47,77,97,116,101,114,105,97,108,115,47,77,95,77,101,100,95,83,111,108,100,105,101,114,95,66,111,100,121,95,84,86,50,56,95,66,108,97,99,107,75,110,105,103,104,116,46,77,95,77,101,100,95,83,111,108,100,105,101,114,95,66,111,100,121,95,84,86,50,56,95,66,108,97,99,107,75,110,105,103,104,116,0,0,0,0,0,0
       };
        private static byte[] BodyMesh = new byte[102]
     {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,77,101,115,104,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,46,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49
     };
        private static byte[] BodyMesh1 = new byte[102]
  {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,77,95,77,69,68,95,66,114,111,110,116,111,47,77,101,115,104,101,115,47,77,95,77,69,68,95,66,114,111,110,116,111,46,77,95,77,69,68,95,66,114,111,110,116,111,0,0,0,0,0,0,0,0,0,0,0,0,0,0
  };
        private static byte[] BodyMeshBP = new byte[136]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,77,101,115,104,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,80,46,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,80,95,67
};
        private static byte[] BodyMeshBP1 = new byte[136]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,77,95,77,69,68,95,66,114,111,110,116,111,47,77,101,115,104,101,115,47,77,95,77,69,68,95,66,114,111,110,116,111,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,108,117,101,112,114,105,110,116,46,77,95,77,69,68,95,66,114,111,110,116,111,95,83,107,101,108,101,116,111,110,95,65,110,105,109,66,108,117,101,112,114,105,110,116,95,67
};
        private static byte[] BodySkeleton = new byte[94]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,97,115,101,47,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110,46,83,75,95,77,95,70,101,109,97,108,101,95,66,97,115,101,95,83,107,101,108,101,116,111,110
};
        private static byte[] BodySkeleton1 = new byte[94]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,77,97,108,101,47,77,101,100,105,117,109,47,66,97,115,101,47,83,75,95,77,95,77,65,76,69,95,66,97,115,101,95,83,107,101,108,101,116,111,110,46,83,75,95,77,95,77,65,76,69,95,66,97,115,101,95,83,107,101,108,101,116,111,110,0,0,0,0,0,0
};
        private static byte[] Chainmail = new byte[124]
{
80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,101,100,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,67,104,97,105,110,109,97,105,108,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114
};
        private static byte[] Chainmail1 = new byte[124]
{
80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,101,100,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,67,104,97,105,110,109,97,105,108,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,66,82,48,54,46,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,66,82,48,54,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] Hat = new byte[92]
{
47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,97,116,101,114,105,97,108,115,47,72,97,116,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114,46,72,97,116,95,67,111,109,109,97,110,100,111,95,82,101,100,75,110,105,103,104,116,95,87,105,110,116,101,114
};
        private static byte[] Hat1 = new byte[92]
{
47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,97,116,101,114,105,97,108,115,47,72,97,116,95,67,111,109,109,97,110,100,111,95,66,108,97,99,107,75,110,105,103,104,116,46,72,97,116,95,67,111,109,109,97,110,100,111,95,66,108,97,99,107,75,110,105,103,104,116,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] HatMesh = new byte[89]
{
65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,75,110,105,103,104,116,95,48,49,46,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,75,110,105,103,104,116,95,48,49
};
        private static byte[] HatMesh1 = new byte[89]
{
65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,77,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,75,110,105,103,104,116,95,48,49,46,77,97,108,101,95,67,111,109,109,97,110,100,111,95,66,82,95,66,108,97,99,107,75,110,105,103,104,116,95,48,49,0,0,0,0
};
        private static byte[] CID = new byte[83]
{
67,73,68,95,50,57,52,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,82,101,100,75,110,105,103,104,116,87,105,110,116,101,114,46,67,73,68,95,50,57,52,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,82,101,100,75,110,105,103,104,116,87,105,110,116,101,114
};
        private static byte[] CID1 = new byte[83]
{
67,73,68,95,48,51,53,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,77,95,77,101,100,105,101,118,97,108,46,67,73,68,95,48,51,53,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,77,95,77,101,100,105,101,118,97,108,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            revert.Enabled = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";


            Stream fs = File.OpenRead(filePath);         

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                long bodymeshset = s - 509;
                long bodymeshbpset = s - 288;
                long skeletonseet = s - 706;
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                binaryWriter.BaseStream.Seek(bodymeshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyMesh);
                binaryWriter.BaseStream.Seek(bodymeshbpset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyMeshBP);
                binaryWriter.BaseStream.Seek(skeletonseet + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodySkeleton);
                binaryWriter.Close();
                Settings.Default.BlackKnightEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body removed!";
            }

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin2, Chainmail1))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Chainmail);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Chainmail removed!";
            }

            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Hat1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                long hatmeshset = s + 177;
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat);
                binaryWriter.BaseStream.Seek(hatmeshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HatMesh);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head removed!";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
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

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";

            Stream fscid = File.OpenRead(filePath11);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath11, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID added!";
            }

            Stream fs = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                long bodymeshset = s - 509;
                long bodymeshbpset = s - 288;
                long skeletonseet = s - 706;
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                binaryWriter.BaseStream.Seek(bodymeshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyMesh1);
                binaryWriter.BaseStream.Seek(bodymeshbpset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodyMeshBP1);
                binaryWriter.BaseStream.Seek(skeletonseet + 0L, SeekOrigin.Begin);
                binaryWriter.Write(BodySkeleton1);
                binaryWriter.Close();
                Settings.Default.BlackKnightEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body added!";
            }

            Stream fs1 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin2, Chainmail))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Chainmail1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Chainmail added!";
            }

            Stream fs2 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Hat))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                long hatmeshset = s + 177;
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat1);
                binaryWriter.BaseStream.Seek(hatmeshset + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HatMesh1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head added!";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
            }

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

        private void BlackKnight_Load(object sender, EventArgs e)
        {

        }
    }
}
