
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
    public partial class RoyaleKnight : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public RoyaleKnight()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Royale Knight";
            bool enabled = Settings.Default.RoyaleKnightEnabled;
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

        private static byte[] Body = new byte[149]
        {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,65,117,114,111,114,97,95,71,108,111,119,47,77,97,116,101,114,105,97,108,115,47,77,95,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119,46,77,95,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119
        };

        private static byte[] Body1 = new byte[149]
        {
    47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,84,86,95,50,56,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,50,56,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,50,56,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };

        private static byte[] Hair = new byte[157]
       {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,66,111,100,105,101,115,47,70,95,77,101,100,95,83,111,108,100,105,101,114,95,48,49,47,83,107,105,110,115,47,65,117,114,111,114,97,95,71,108,111,119,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,97,105,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119,46,70,95,77,69,68,95,67,111,109,109,97,110,100,111,95,72,97,105,114,95,48,49,95,65,117,114,111,114,97,71,108,111,119
       };

        private static byte[] Hair1 = new byte[157]
       {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,66,76,75,95,82,101,100,95,72,101,97,100,95,48,49,47,77,97,116,101,114,105,97,108,115,47,70,95,77,69,68,95,66,76,75,95,82,101,100,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,66,76,75,95,82,101,100,95,72,101,97,100,95,48,49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
       };

        private static byte[] Head = new byte[126]
       {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,47,77,101,115,104,47,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,72,73,83,95,82,97,109,105,114,101,122,95,72,101,97,100,95,48,49
       };

        private static byte[] Head1 = new byte[126]
     {
     47,71,97,109,101,47,67,104,97,114,97,99,116,101,114,115,47,80,108,97,121,101,114,47,70,101,109,97,108,101,47,77,101,100,105,117,109,47,72,101,97,100,115,47,70,95,77,69,68,95,67,65,85,95,74,97,110,101,95,72,101,97,100,95,48,49,47,77,101,115,104,101,115,47,70,95,77,69,68,95,67,65,85,95,74,97,110,101,95,72,101,97,100,95,48,49,46,70,95,77,69,68,95,67,65,85,95,74,97,110,101,95,72,101,97,100,95,48,49,0,0,0,0,0,0,0
     };

        private static byte[] Glasses = new byte[79]
         {
     47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,71,108,97,115,115,101,115,47,77,97,116,101,114,105,97,108,115,47,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,115,46,77,73,95,65,117,114,111,114,97,71,108,111,119,95,71,108,97,115,115,101,115
         };

        private static byte[] Glasses1 = new byte[79]
         {
     47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,97,116,101,114,105,97,108,115,47,72,97,116,95,77,95,67,111,109,109,97,110,100,111,95,49,49,46,72,97,116,95,77,95,67,111,109,109,97,110,100,111,95,49,49,0,0,0,0,0,0,0,0,0,0,0
         };

        private static byte[] Shades = new byte[78]
        {
     47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,71,108,97,115,115,101,115,47,77,101,115,104,101,115,47,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,104,97,100,101,115,46,70,101,109,97,108,101,95,67,111,109,109,97,110,100,111,95,83,104,97,100,101,115
        };
        private static byte[] Shades1 = new byte[78]
        {
     47,71,97,109,101,47,65,99,99,101,115,115,111,114,105,101,115,47,72,97,116,115,47,77,101,115,104,47,72,97,116,95,77,97,108,101,95,67,111,109,109,97,110,100,111,95,49,50,95,70,46,72,97,116,95,77,97,108,101,95,67,111,109,109,97,110,100,111,95,49,50,95,70,0,0,0,0,0
        };

        private static byte[] offsetr = new byte[37]
       {
    81,65,194,101,0,0,0,0,232,11,0,0,181,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,236,11,0,0,58
       };

        private static byte[] CID = new byte[25]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,70,101,109,97,108,101
        };

        private static byte[] CID1 = new byte[25]
        {
            69,70,111,114,116,67,117,115,116,111,109,71,101,110,100,101,114,58,58,70,101,109,97,49,101
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

            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 726L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body removed!";
            }




            

                Stream fs1 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin2, Hair1))
                {
                    fs1.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Hair);
                    binaryWriter.Close();
                Settings.Default.RoyaleKnightEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hair removed!";
                }


                Stream fs21222 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs21222, 0, offsetskin2, Glasses1))
                {
                    fs21222.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Glasses);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Glasses swapped!";
                }

                Stream fs023 = File.OpenRead(filePath);
                foreach (long s in Researcher.FindPosition(fs023, 0, offsetskin2, offsetr))
                {
                    fs023.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    long headmeshset = s + 1110;
                    binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(RoyaleKnight.Head);
                    RichTextBoxInfo.Text += "\n[LOG] Head removed!";
                    binaryWrite.Close();
                }

                Stream fs212222 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs212222, 0, offsetskin2, Shades1))
                {
                    fs212222.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Shades);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Shades removed!";
                }


            
            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;

            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (Settings.Default.RedNosedNiteEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Red-Nosed Raider[Using Nitelite]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SkullRangerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Skull Ranger" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.GhoulNiteEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ghoul Trooper[Using Nitelite]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.EliteNiteEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Elite Agent[Using Nitelite]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.GalaxyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Galaxy" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ShadowOpsEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Shadow Ops" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.OgGhoulEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "OG Ghoul Trooper" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";


            string filePath11 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";




            Stream stream = File.OpenRead(filePath1);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 726L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs1 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin2, Hair))
                {
                    fs1.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Hair1);
                    binaryWriter.Close();
                Settings.Default.RoyaleKnightEnabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hair added!";
                }


                Stream fs21222 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs21222, 0, offsetskin2, Glasses))
                {
                    fs21222.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Glasses1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Glasses swapped!";
                }

                Stream fs023 = File.OpenRead(filePath);
                foreach (long s in Researcher.FindPosition(fs023, 0, offsetskin2, offsetr))
                {
                    fs023.Close();
                    BinaryWriter binaryWrite = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    long headmeshset = s + 1110;
                    binaryWrite.BaseStream.Seek(headmeshset + 0L, SeekOrigin.Begin);
                    binaryWrite.Write(RoyaleKnight.Head1);
                    RichTextBoxInfo.Text += "\n[LOG] Head added!";
                    binaryWrite.Close();
                }

                Stream fs212222 = File.OpenRead(filePath);

                foreach (long s in Researcher.FindPosition(fs212222, 0, offsetskin2, Shades))
                {
                    fs212222.Close();
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                    binaryWriter.Write(Shades1);
                    binaryWriter.Close();
                    RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Shades added!";
                }


            
            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

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
            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

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
