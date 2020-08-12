using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Skins
{
    public partial class Diver : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Diver()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Surf Rider";
            MessageBox.Show("This skin uses Catalyst [Tier1], be sure to select this style before swapping the Diver!");
            bool enabled = Settings.Default.DiverEnabled;
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

        private static byte[] Body = new byte[144]
     {
  47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,47,77,101,115,104,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,46,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120
        };

        private static byte[] Body1 = new byte[144]
    {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,47,77,101,115,104,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,46,70,95,77,69,68,95,74,101,116,95,83,107,105,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };

        private static byte[] BodyAnim = new byte[160]
  {
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,47,77,101,115,104,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,95,65,110,105,109,66,80,46,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,95,65,110,105,109,66,80,95,67
     };

        private static byte[] BodyAnim1 = new byte[160]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,47,77,101,115,104,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,95,65,110,105,109,66,80,46,70,95,77,69,68,95,74,101,116,95,83,107,105,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] Head = new byte[134]
{
 47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,83,82,95,68,114,105,102,116,95,70,97,99,101,65,99,99,46,70,95,77,69,68,95,83,82,95,68,114,105,102,116,95,70,97,99,101,65,99,99
};

        private static byte[] Head1 = new byte[134]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,95,70,97,99,101,65,99,99,46,70,95,77,69,68,95,74,101,116,95,83,107,105,95,70,97,99,101,65,99,99,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};

        private static byte[] HeadAnim = new byte[156]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,83,116,114,101,101,116,95,82,97,99,101,114,95,68,114,105,102,116,95,82,101,109,105,120,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,83,82,95,68,114,105,102,116,95,70,97,99,101,65,99,99,95,84,49,95,65,110,105,109,66,80,46,70,95,77,69,68,95,83,82,95,68,114,105,102,116,95,70,97,99,101,65,99,99,95,84,49,95,65,110,105,109,66,80,95,67
};

        private static byte[] HeadAnim1 = new byte[156]
{
47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,47,77,101,115,104,101,115,47,80,97,114,116,115,47,70,95,77,69,68,95,74,101,116,95,83,107,105,95,70,97,99,101,65,99,99,95,65,110,105,109,66,80,46,70,95,77,69,68,95,74,101,116,95,83,107,105,95,70,97,99,101,65,99,99,95,65,110,105,109,66,80,95,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private static byte[] CID = new byte[]
{
67,73,68,95,52,56,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,83,116,114,101,101,116,82,97,99,101,114,68,114,105,102,116,46,67,73,68,95,52,56,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,83,116,114,101,101,116,82,97,99,101,114,68,114,105,102,116
};
        private static byte[] CID1 = new byte[]
{
67,73,68,95,54,48,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,74,101,116,83,107,105,46,67,73,68,95,54,48,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,74,101,116,83,107,105,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
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

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                binaryWriter.Close();
                Settings.Default.DiverEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 1/2 removed!";
            }

            for (int i = 0; i < 4; i++)
            {

                Stream fs2 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyAnim1))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyAnim);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body Anim removed! [" + i + "]";
                }
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head1))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 removed!";
            }

            Stream fs5 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, HeadAnim1))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadAnim);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 removed!";
            }

            string cidPath = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(cidPath);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID1))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidPath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Locker Icon removed!";
            }

            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (Settings.Default.RedJadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Red Jade" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.WhiteoutEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Whiteout" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.MarshEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Marshmello" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;

             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, Body))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                binaryWriter.Close();
                Settings.Default.DiverEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body 1/2 added!";
            }

            for (int i = 0; i < 4; i++)
            {

                Stream fs2 = File.OpenRead(path1);

                foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, BodyAnim))
                {
                    fs2.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(BodyAnim1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body Anim added! [" + i + "]";
                }

            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 added!";
            }

            Stream fs5 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, HeadAnim))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadAnim1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 2/2 added!";
            }

            string cidPath = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fscid = File.OpenRead(cidPath);

            foreach (long s in Researcher.FindPosition(fscid, 0, offsetlobby, CID))
            {
                fscid.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidPath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Locker Icon added!";
            }


            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;

        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

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
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            revert1Bytes.RunWorkerAsync();
        }

        private void RichTextBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
