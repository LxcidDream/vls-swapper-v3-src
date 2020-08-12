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

namespace vls_swapper_v3.Skins
{
    public partial class CheckOps : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public CheckOps()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Checkered Renegade";
            bool enabled = Settings.Default.CheckeredRenegadeOpsEnabled;
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

        private static byte[] Body = new byte[150]
        {
    47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,66,82,95,85,103,108,121,83,119,101,97,116,101,114,47,77,97,116,101,114,105,97,108,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,52,95,85,103,108,121,83,119,101,97,116,101,114,46,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,52,95,85,103,108,121,83,119,101,97,116,101,114
        };

        private static byte[] Body1 = new byte[150]
        {
    47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,84,86,95,50,49,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,84,86,50,49,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,84,86,50,49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] Head = new byte[83]
          {
    47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,95,67,111,109,109,97,110,100,111,95,67,104,114,105,115,116,109,97,115,72,97,116,95,65,84,72,46,70,95,67,111,109,109,97,110,100,111,95,67,104,114,105,115,116,109,97,115,72,97,116,95,65,84,72
          };

        private static byte[] Head1 = new byte[83]
       {
   47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,48,56,46,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,48,56,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
       };

        private static byte[] CID = new byte[81]
   {
  67,73,68,95,48,52,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,72,111,108,105,100,97,121,83,119,101,97,116,101,114,46,67,73,68,95,48,52,54,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,95,72,111,108,105,100,97,121,83,119,101,97,116,101,114
   };

        private static byte[] CID1 = new byte[81]
{
  67,73,68,95,48,50,56,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,46,67,73,68,95,48,50,56,95,65,116,104,101,110,97,95,67,111,109,109,97,110,100,111,95,70,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
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
             RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

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




            Stream fs024 = File.OpenRead(path1);
                foreach (long s in Researcher.FindPosition(fs024, 0, offsetskin1, Body1))
                {
                    Settings.Default.CheckeredRenegadeOpsEnabled = false;
                    Settings.Default.Save(); RichTextBoxInfo.Text = "";
                    fs024.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Body);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Body removed!";
                }

                Stream fs030 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs030, 0, offsetskin2, Head1))
                {
                    fs030.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Head);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Head removed!";
                }
            
            convert.Enabled = true;
            revert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text += "\n[LOG] Done!"; ;
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (change1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }



            convert.Enabled = false;
             RichTextBoxInfo.Text += "\n[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

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
            


                Stream fs024 = File.OpenRead(path1);
                foreach (long s in Researcher.FindPosition(fs024, 0, offsetskin1, Body))
                {
                    Settings.Default.CheckeredRenegadeOpsEnabled = true;
                    Settings.Default.Save(); RichTextBoxInfo.Text = "";
                    fs024.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Body1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Body added!";
                }

                Stream fs030 = File.OpenRead(path);
                foreach (long s in Researcher.FindPosition(fs030, 0, offsetskin2, Head))
                {
                    fs030.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWrite.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(Head1);
                    binaryWrite.Close();
                    RichTextBoxInfo.Text += "\n[LOG] Head added!";
                }           



            convert.Enabled = false;
            revert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
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
