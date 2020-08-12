using vls_swapper_v3.Properties;
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
    public partial class Wonder : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Wonder()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "Wonder";
            bool enabled = Settings.Default.WonderEnable;
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

        private static byte[] Body = new byte[143]
        {
           80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,69,68,95,95,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
        };

        private static byte[] Body1 = new byte[143]
        {
           80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,83,116,101,97,108,116,104,95,72,111,110,111,114,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,83,116,101,97,108,116,104,72,111,110,111,114,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,66,111,100,121,95,83,116,101,97,108,116,104,72,111,110,111,114,0,0,0
        };

        private static byte[] Head = new byte[155]
        {
        80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,95,72,101,97,100,95,48,49
        };

        private static byte[] Head1 = new byte[155]
        {
          80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,83,116,101,97,108,116,104,95,72,111,110,111,114,47,77,97,116,101,114,105,97,108,115,47,70,95,83,77,76,95,65,83,78,95,83,116,101,97,108,116,104,72,111,110,111,114,95,72,97,105,114,46,70,95,83,77,76,95,65,83,78,95,83,116,101,97,108,116,104,72,111,110,111,114,95,72,97,105,114,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] HeadMesh = new byte[126]
        {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49
        };

        private static byte[] HeadMesh1 = new byte[126]
        {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,65,83,78,95,75,117,109,105,107,111,95,72,101,97,100,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,65,83,78,95,75,117,109,105,107,111,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,65,83,78,95,75,117,109,105,107,111,95,72,101,97,100,95,48,49,0
        };

        private static byte[] Color = new byte[98]
        {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107,46,70,95,77,101,100,95,72,73,83,95,83,116,114,101,101,116,82,97,99,101,114,66,108,97,99,107
        };

        private static byte[] Color1 = new byte[98]
        {
          47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,77,101,100,95,65,83,78,95,75,117,109,105,107,111,46,70,95,77,101,100,95,65,83,78,95,75,117,109,105,107,111,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] Hat = new byte[67]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54,46,70,101,109,97,108,101,95,79,117,116,108,97,110,100,101,114,95,48,54
        };

        private static byte[] Hat1 = new byte[67]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,72,97,116,95,69,109,112,116,121,46,72,97,116,95,69,109,112,116,121,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] offsetr = new byte[39]
        {
           51,119,123,0,0,0,0,17,11,0,0,148,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,21,11,0,0,58,0,0,0
        };




        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

            RichTextBoxInfo.Text += "\n[LOG] Starting...";

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
                Settings.Default.WonderEnable = false;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body removed!";
            }

            Stream fs2 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Head1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 removed!";
            }

            Stream fs3 = File.OpenRead(path);
            foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin2, offsetr))
            {
                fs3.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                long headmeshset = s + 893;
                long headmeshbpset = headmeshset + 257;
                binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                binaryWrite.Write(Wonder.HeadMesh);
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 removed!";
                binaryWrite.Close();
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Hat1))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat swapped[Re-Added]!";
            }

            Stream fs5 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, Color1))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Color);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Skin Color removed!";
            }



            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

            if (Settings.Default.ReconEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Expert" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            
            else if (Settings.Default.RenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            if (Settings.Default.CheckRenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider [checkerd]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;

            RichTextBoxInfo.Text += "\n[LOG] Starting...";

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
                Settings.Default.WonderEnable = true;
                Settings.Default.Save(); RichTextBoxInfo.Text = "";
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body added!";
            }

            Stream fs2 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Head))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head 1/2 added!";
            }

            Stream fs3 = File.OpenRead(path);
            foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin2, offsetr))
            {
                fs3.Close();
                BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                long headmeshset = s + 893;
                long headmeshbpset = headmeshset + 257;
                binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                binaryWrite.Write(Wonder.HeadMesh1);
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 added!";
                binaryWrite.Close();
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Hat))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat swapped[Deleted]!";
            }

            Stream fs5 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, Color))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Color1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Skin Color added!";
            }



            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
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

                CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;

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
            CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
            revert1Bytes.RunWorkerAsync();
        }
    }
}
