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

namespace vls_swapper_v3.items.skins
{
    public partial class ogghoul : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public ogghoul()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            MessageBox.Show("This Item Will show up as green ghoul trooper in your locker but will be pink in game!");
            this.Text = "OG Ghoul Trooper";
            bool enabled = Settings.Default.OgGhoulEnabled;
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



        private static byte[] Body = new byte[149]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,65,117,114,111,114,97,95,71,108,111,119,47,77,97,116,101,114,105,97,108,115,47,77,95,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119,46,77,95,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119
        };

        private static byte[] Body1 = new byte[149]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,95,77,69,68,95,90,111,109,98,105,101,95,80,105,110,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,90,111,109,98,105,101,95,80,105,110,107,95,66,111,100,121,46,70,95,77,69,68,95,90,111,109,98,105,101,95,80,105,110,107,95,66,111,100,121,0,0,0,0,0,0,0,0
        };

        private static byte[] Color = new byte[66]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,66,76,75,95,76,117,110,97,46,70,95,66,76,75,95,76,117,110,97
        };

        private static byte[] Color1 = new byte[66]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,67,104,97,114,97,99,116,101,114,67,111,108,111,114,83,119,97,116,99,104,101,115,47,83,107,105,110,47,70,95,66,76,75,95,76,117,110,97,46,70,95,66,76,75,95,76,117,110,49
        };

        private static byte[] Hair = new byte[157]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,65,117,114,111,114,97,95,71,108,111,119,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,97,105,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,97,105,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119
        };

        private static byte[] Hair1 = new byte[157]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,95,77,69,68,95,90,111,109,98,105,101,95,80,105,110,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,82,97,109,105,114,101,122,95,90,111,109,98,105,101,95,80,105,110,107,95,72,97,105,114,46,70,95,77,69,68,95,82,97,109,105,114,101,122,95,90,111,109,98,105,101,95,80,105,110,107,95,72,97,105,114
        };

        private static byte[] Head = new byte[157]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,65,117,114,111,114,97,95,71,108,111,119,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,95,65,117,114,111,114,97,71,108,111,119,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,101,97,100,95,48,49,95,65,117,114,111,114,97,71,108,111,119
        };

        private static byte[] Head1 = new byte[157]
        {
           47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,70,95,77,69,68,95,90,111,109,98,105,101,95,80,105,110,107,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,82,97,109,105,114,101,122,95,90,111,109,98,105,101,95,80,105,110,107,95,72,101,97,100,46,70,95,77,69,68,95,82,97,109,105,114,101,122,95,90,111,109,98,105,101,95,80,105,110,107,95,72,101,97,100
        };

        private static byte[] Glasses = new byte[79]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,71,108,97,115,115,101,115,47,77,97,116,101,114,105,97,108,115,47,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,115,46,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,115
        };

        private static byte[] Glasses1 = new byte[79]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,71,108,97,115,115,101,115,47,77,97,116,101,114,105,97,108,115,47,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,115,46,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,49
        };

        private static byte[] Shades = new byte[78]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,71,108,97,115,115,101,115,47,77,101,115,104,101,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,104,97,100,101,115,46,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,104,97,100,101,115
        };

        private static byte[] Shades1 = new byte[78]
        {
           47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,82,97,109,105,114,101,122,95,71,108,97,115,115,101,115,46,82,97,109,105,114,101,122,95,71,108,97,115,115,101,115,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] CID = new byte[25]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,70,101,109,97,108,101
        };

        private static byte[] CID1 = new byte[25]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,70,101,109,97,49,101
        };


        public static string GetPaksFolder
        {
            get { return Settings.Default.paksPath; }
        }

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            int offsetskin = Settings.Default.offsetskin1;
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
                RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
                richTextBoxInfo.Text += "\n[LOG] Starting...";
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
                string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
                string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
                string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
                string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
                string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
                Stream stream = File.OpenRead(bodypath);
                foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, ogghoul.Body1))
                {
                    stream.Close();
                    BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                    binaryWriter.Write(ogghoul.Body);
                    long offset = num + 726L;
                    binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                    binaryWriter.Write(ogghoul.CID);
                    binaryWriter.Close();
                    RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                    richTextBoxInfo2.Text += "\n[LOG] Body removed!";
                }
                Stream stream2 = File.OpenRead(headpath);
                foreach (long num2 in Researcher.FindPosition(stream2, 0, (long)offsetskin2, ogghoul.Hair1))
                {
                    stream2.Close();
                    BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    long offset2 = num2 - 288L;
                    binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                    binaryWriter2.Write(ogghoul.Color);
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Color removed!";
                    binaryWriter2.BaseStream.Seek(num2, SeekOrigin.Begin);
                    binaryWriter2.Write(ogghoul.Hair);
                    binaryWriter2.Close();
                    Settings.Default.OgGhoulEnabled = false;
                    Settings.Default.Save();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Hair removed!";
                }
                Stream stream3 = File.OpenRead(headpath);
                foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, ogghoul.Head1))
                {
                    stream3.Close();
                    BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                    binaryWriter3.Write(ogghoul.Head);
                    binaryWriter3.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head removed!";
                }
                Stream stream4 = File.OpenRead(headpath);
                foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ogghoul.Glasses1))
                {
                    stream4.Close();
                    BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                    binaryWriter4.Write(ogghoul.Glasses);
                    binaryWriter4.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Glasses removed!";
                }
                Stream stream5 = File.OpenRead(headpath);
                foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ogghoul.Shades1))
                {
                    stream5.Close();
                    BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                    binaryWriter5.Write(ogghoul.Shades);
                    binaryWriter5.Close();
                    this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Shades removed!";
                }
                this.revert.Enabled = false;
                this.convert.Enabled = true;
                stopwatch.Stop();
                double num3 = (double)stopwatch.Elapsed.Seconds;
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
            }
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            int offsetskin = Settings.Default.offsetskin1;
            int offsetskin2 = Settings.Default.offsetskin2;
            int offsetlobby = Settings.Default.offsetlobby;
            this.convert.Enabled = false;
            RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
            richTextBoxInfo.Text += "\n[LOG] Starting...";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            Stream stream = File.OpenRead(bodypath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin, ogghoul.Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(ogghoul.Body1);
                long offset = num + 726L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(ogghoul.CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }
            Stream stream2 = File.OpenRead(headpath);
            foreach (long num2 in Researcher.FindPosition(stream2, 0, (long)offsetskin2, ogghoul.Hair))
            {
                stream2.Close();
                BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                long offset2 = num2 - 288L;
                binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                binaryWriter2.Write(ogghoul.Color1);
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Color added!";
                binaryWriter2.BaseStream.Seek(num2, SeekOrigin.Begin);
                binaryWriter2.Write(ogghoul.Hair1);
                binaryWriter2.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Hair added!";
                Settings.Default.OgGhoulEnabled = true;
                Settings.Default.Save();
            }
            Stream stream3 = File.OpenRead(headpath);
            foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetskin2, ogghoul.Head))
            {
                stream3.Close();
                BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                binaryWriter3.Write(ogghoul.Head1);
                binaryWriter3.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head added!";
            }
            Stream stream4 = File.OpenRead(headpath);
            foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetskin2, ogghoul.Glasses))
            {
                stream4.Close();
                BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                binaryWriter4.Write(ogghoul.Glasses1);
                binaryWriter4.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Glasses added!";
            }
            Stream stream5 = File.OpenRead(headpath);
            foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetskin2, ogghoul.Shades))
            {
                stream5.Close();
                BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                binaryWriter5.Write(ogghoul.Shades1);
                binaryWriter5.Close();
                this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Shades added!";
            }
            this.revert.Enabled = true;
            this.convert.Enabled = false;
            stopwatch.Stop();
            double num3 = (double)stopwatch.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Settings.Default.paksPath + "\\pakchunk10_s2-WindowsClient.pak";

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
            string filePath = Settings.Default.paksPath + "\\pakchunk10_s2-WindowsClient.pak";

            if (!File.Exists(filePath))
            {
                paks a = new paks(); a.ShowDialog();
                return;
            }
            else
            {

                CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
                revert1Bytes.RunWorkerAsync();
            }
        }
    }
}
