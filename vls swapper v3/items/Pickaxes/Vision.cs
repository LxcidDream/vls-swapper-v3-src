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
using System.Threading;
using vls_swapper_v3.Properties;
using vls_swapper_v3;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Picks
{
    public partial class Vision : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Vision()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Vision";
            bool enabled = Settings.Default.VisionEnabled;
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

        private static byte[] Mesh = new byte[112]
         {
           47,71,97,109,101,47,87,101,97,112,111,110,115,47,70,79,82,84,95,77,101,108,101,101,47,80,105,99,107,97,120,101,95,83,116,114,101,101,116,82,97,99,101,114,87,104,105,116,101,47,77,101,115,104,101,115,47,83,75,95,80,105,99,107,97,120,101,95,83,116,114,101,101,116,82,97,99,101,114,87,104,105,116,101,46,83,75,95,80,105,99,107,97,120,101,95,83,116,114,101,101,116,82,97,99,101,114,87,104,105,116,101
         };

        private static byte[] Mesh1 = new byte[112]
        {
            47,71,97,109,101,47,87,101,97,112,111,110,115,47,70,79,82,84,95,77,101,108,101,101,47,80,105,99,107,97,120,101,95,83,116,114,101,101,116,71,111,116,104,47,77,101,115,104,101,115,47,83,116,114,101,101,116,95,71,111,116,104,95,80,105,99,107,97,120,101,46,83,116,114,101,101,116,95,71,111,116,104,95,80,105,99,107,97,120,101,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };



        private static byte[] Swing1 = new byte[95]
        {
            71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,49,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,49
        };

        private static byte[] Swing1T = new byte[95]
        {
           71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,49,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,49,0,0,0
        };

        private static byte[] Swing2 = new byte[95]
        {
            71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,50,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,50
        };

        private static byte[] Swing2T = new byte[95]
        {
           71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,50,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,50,0,0,0
        };

        private static byte[] Swing3 = new byte[95]
        {
           71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,51,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,51
        };

        private static byte[] Swing3T = new byte[95]
        {
           71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,51,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,51,0,0,0
        };

        private static byte[] Swing4 = new byte[95]
        {
          71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,52,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,52
        };

        private static byte[] Swing4T = new byte[95]
        {
            71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,52,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,52,0,0,0
        };

        private static byte[] Swing5 = new byte[95]
        {
           71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,53,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,53
        };

        private static byte[] Swing5T = new byte[95]
        {
            71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,53,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,53,0,0,0
        };

        private static byte[] Swing6 = new byte[95]
        {
          71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,82,97,99,101,114,47,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,54,46,80,65,95,83,116,114,101,101,116,82,97,99,101,114,95,83,119,105,110,103,95,48,54
        };

        private static byte[] Swing6T = new byte[95]
        {
            71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,83,116,114,101,101,116,71,111,116,104,47,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,54,46,80,65,95,83,116,114,101,101,116,71,111,116,104,95,83,119,105,110,103,95,48,54,0,0,0
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

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetpick, Mesh1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh);
                binaryWriter.Close();
                Settings.Default.VisionEnabled = false;
                Settings.Default.Save();
                 RichTextBoxInfo.Text += "\n[LOG] Mesh removed!";
            }

            Stream fs41234567891 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs41234567891, 0, offsetpickmesh, Swing1T))
            {
                fs41234567891.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing1);
                binaryWriter.Close();
            }

            Stream fs41 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs41, 0, offsetpickmesh, Swing1T))
            {
                fs41.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing1);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 1/6 removed!";
            }

            Stream fs51234567891 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs51234567891, 0, offsetpickmesh, Swing2T))
            {
                fs51234567891.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing2);
                binaryWriter.Close();
            }

            Stream fs51 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs51, 0, offsetpickmesh, Swing2T))
            {
                fs51.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing2);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 2/6 removed!";
            }

            Stream fs64545771 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs64545771, 0, offsetpickmesh, Swing3T))
            {
                fs64545771.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing3);
                binaryWriter.Close();
            }

            Stream fs61 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs61, 0, offsetpickmesh, Swing3T))
            {
                fs61.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing3);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 3/6 removed!";
            }

            Stream fs79101112131 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs79101112131, 0, offsetpickmesh, Swing4T))
            {
                fs79101112131.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing4);
                binaryWriter.Close();
            }

            Stream fs71 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs71, 0, offsetpickmesh, Swing4T))
            {
                fs71.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing4);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 4/6 removed!";
            }

            Stream fs854345441 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs854345441, 0, offsetpickmesh, Swing5T))
            {
                fs854345441.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing5);
                binaryWriter.Close();
            }

            Stream fs81 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs81, 0, offsetpickmesh, Swing5T))
            {
                fs81.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing5);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 5/6 removed!";
            }

            Stream fs92222222222222227242747 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs92222222222222227242747, 0, offsetpickmesh, Swing6T))
            {
                fs92222222222222227242747.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing6);
                binaryWriter.Close();
            }

            Stream fs9 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetpickmesh, Swing6T))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing6);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 6/6 removed!";
                 RichTextBoxInfo.Text += "\n[LOG] All Sounds were removed!";
            }

            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text += "\n[LOG] Done!";

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
            if (Settings.Default.StuddedEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Studded Axe" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.AxecaliburEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Axecalibur" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SqueakEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Pick Squeak" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            
            else if (Settings.Default.ScytheEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Scythe" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.TrustyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Trusty" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.IceBreakerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "IceBreaker" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;
             RichTextBoxInfo.Text = "";RichTextBoxInfo.Text += "[LOG] Starting...";      

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string filePath = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string filePath1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            Stream fs = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetpick, Mesh))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Mesh1);
                binaryWriter.Close();
                Settings.Default.VisionEnabled = true;
                Settings.Default.Save();
                 RichTextBoxInfo.Text += "\n[LOG] Mesh added!";
            }


            Stream fs45745745741 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs45745745741, 0, offsetpickmesh, Swing1))
            {
                fs45745745741.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing1T);
                binaryWriter.Close();
            }


            Stream fs41 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs41, 0, offsetpickmesh, Swing1))
            {
                fs41.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing1T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 1/6 added!";
            }

            Stream fs585241 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs585241, 0, offsetpickmesh, Swing2))
            {
                fs585241.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing2T);
                binaryWriter.Close();
            }

            Stream fs51 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs51, 0, offsetpickmesh, Swing2))
            {
                fs51.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing2T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 2/6 added!";
            }

            Stream fs615847 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs615847, 0, offsetpickmesh, Swing3))
            {
                fs615847.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing3T);
                binaryWriter.Close();
            }

            Stream fs61 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs61, 0, offsetpickmesh, Swing3))
            {
                fs61.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing3T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 3/6 added!";
            }

            Stream fs717924 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs717924, 0, offsetpickmesh, Swing4))
            {
                fs717924.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing4T);
                binaryWriter.Close();
            }

            Stream fs71 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs71, 0, offsetpickmesh, Swing4))
            {
                fs71.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing4T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 4/6 added!";
            }

            Stream fs83216549871 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs83216549871, 0, offsetpickmesh, Swing5))
            {
                fs83216549871.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing5T);
                binaryWriter.Close();
            }

            Stream fs81 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs81, 0, offsetpickmesh, Swing5))
            {
                fs81.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing5T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 5/6 added!";
            }

            Stream fs9528764 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs9528764, 0, offsetpickmesh, Swing6))
            {
                fs9528764.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing6T);
                binaryWriter.Close();
            }

            Stream fs9 = File.OpenRead(filePath);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetpickmesh, Swing6))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Swing6T);
                binaryWriter.Close();
                 RichTextBoxInfo.Text += "\n[LOG] Sound 6/6 added!";
                 RichTextBoxInfo.Text += "\n[LOG] All Sounds were added!";
            }

            revert.Enabled = true;
            convert.Enabled = false;
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
    }
}
