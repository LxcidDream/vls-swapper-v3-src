using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using vls_swapper_v3.IO;
using vls_swapper_v3;
using MaterialSkin.Controls;
using MaterialSkin;
using vls_swapper_v3.Properties;
using vls_swapper_v3.main.popups;
using MetroFramework;

namespace vls_swapper_v3.Backblings
{
    public partial class harleyquinn : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private IContainer components;
        private MaterialRaisedButton revert;
        private MaterialRaisedButton convert;
        private PictureBox pictureBox1;
        private RichTextBox RichTextBoxInfo;
        private BackgroundWorker revert1Bytes;
        private BackgroundWorker change1Bytes;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public harleyquinn()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "harley quinn";         
            bool enabled = Settings.Default.harlwyquinnenabled;
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


        private static byte[] body1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 047, 077, 101, 115, 104, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 066, 111, 100, 121, 046, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 066, 111, 100, 121
        };

        private static byte[] body2 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 047, 077, 101, 115, 104, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 046, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] Bodybp1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 047, 077, 101, 115, 104, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 066, 111, 100, 121, 095, 065, 110, 105, 109, 066, 080, 046, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 066, 111, 100, 121, 095, 065, 110, 105, 109, 066, 080, 095, 067
        };

        private static byte[] Bodybp2 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 047, 077, 101, 115, 104, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 065, 110, 105, 109, 066, 080, 046, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 065, 110, 105, 109, 066, 080, 095, 067, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] Head1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 047, 077, 101, 115, 104, 101, 115, 047, 080, 097, 114, 116, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 072, 101, 097, 100, 046, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 072, 101, 097, 100
        };

        private static byte[] Head2 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 047, 077, 101, 115, 104, 101, 115, 047, 080, 097, 114, 116, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 070, 097, 099, 101, 065, 099, 099, 046, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 070, 097, 099, 101, 065, 099, 099, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] headbp1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 047, 077, 101, 115, 104, 101, 115, 047, 080, 097, 114, 116, 115, 047, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 072, 101, 097, 100, 095, 065, 110, 105, 109, 066, 080, 046, 070, 095, 077, 069, 068, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 074, 115, 095, 048, 049, 095, 072, 101, 097, 100, 095, 065, 110, 105, 109, 066, 080, 095, 067
        };

        private static byte[] headbp2 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 066, 111, 100, 105, 101, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 047, 077, 101, 115, 104, 101, 115, 047, 080, 097, 114, 116, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 070, 097, 099, 101, 065, 099, 099, 095, 065, 110, 105, 109, 066, 080, 046, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 070, 097, 099, 101, 065, 099, 099, 095, 065, 110, 105, 109, 066, 080, 095, 067, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] headam1 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 072, 101, 097, 100, 115, 047, 070, 095, 077, 069, 068, 095, 067, 065, 085, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 095, 080, 074, 095, 072, 101, 097, 100, 095, 048, 049, 047, 077, 101, 115, 104, 101, 115, 047, 070, 095, 077, 069, 068, 095, 067, 065, 085, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 095, 080, 074, 095, 072, 101, 097, 100, 095, 048, 049, 046, 070, 095, 077, 069, 068, 095, 067, 065, 085, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 095, 080, 074, 095, 072, 101, 097, 100, 095, 048, 049
        };

        private static byte[] headam2 = new byte[]
        {
            047, 071, 097, 109, 101, 047, 067, 104, 097, 114, 097, 099, 116, 101, 114, 115, 047, 080, 108, 097, 121, 101, 114, 047, 070, 101, 109, 097, 108, 101, 047, 077, 101, 100, 105, 117, 109, 047, 072, 101, 097, 100, 115, 047, 070, 095, 077, 069, 068, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 072, 101, 097, 100, 095, 048, 049, 047, 077, 101, 115, 104, 101, 115, 047, 070, 101, 109, 097, 108, 101, 095, 077, 101, 100, 105, 117, 109, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 072, 101, 097, 100, 046, 070, 101, 109, 097, 108, 101, 095, 077, 101, 100, 105, 117, 109, 095, 076, 111, 108, 108, 105, 112, 111, 112, 095, 072, 101, 097, 100, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] cid1 = new byte[]
        {
            067, 073, 068, 095, 050, 052, 053, 095, 065, 116, 104, 101, 110, 097, 095, 067, 111, 109, 109, 097, 110, 100, 111, 095, 070, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 106, 115
        };

        private static byte[] cid2 = new byte[]
        {
            067, 073, 068, 095, 050, 052, 053, 095, 065, 116, 104, 101, 110, 097, 095, 067, 111, 109, 109, 097, 110, 100, 111, 095, 070, 095, 089, 089, 089, 089, 089, 089, 089, 089, 089, 089, 089, 089, 089
        };

        private static byte[] cid11 = new byte[]
        {
            067, 073, 068, 095, 055, 048, 052, 095, 065, 116, 104, 101, 110, 097, 095, 067, 111, 109, 109, 097, 110, 100, 111, 095, 070, 095, 076, 111, 108, 108, 105, 112, 111, 112, 084, 114, 105, 099, 107, 115, 116, 101, 114
        };

        private static byte[] cid22 = new byte[]
        {
            067, 073, 068, 095, 050, 052, 053, 095, 065, 116, 104, 101, 110, 097, 095, 067, 111, 109, 109, 097, 110, 100, 111, 095, 070, 095, 068, 117, 114, 114, 098, 117, 114, 103, 101, 114, 080, 106, 115, 000, 000, 000, 000
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

            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            Stream fs = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, body1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(body2);
                binaryWriter.Close();
                Settings.Default.harlwyquinnenabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body Removed!";
            }

            Stream fs2 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, Bodybp1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Bodybp2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body Bp Removed!";
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head1))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Removed!";
            }

            Stream fs5 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, headam1))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(headam2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Am Removed!";
            }

            string cidpath = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fs6 = File.OpenRead(cidpath);

            foreach (long s in Researcher.FindPosition(fs6, 0, offsetskin2, headbp1))
            {
                fs6.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(headbp2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Bp Removed!";
            }


            Stream fs7 = File.OpenRead(cidpath);

            foreach (long s in Researcher.FindPosition(fs7, 0, offsetlobby, cid1))
            {
                fs7.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cid2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID 1/2 Removed!";
            }

            Stream fs9 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetlobby, cid11))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cid22);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID 2/2 Removed!";
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



            if (Settings.Default.IkonikOnesieEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ikonik[Using Onesie]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            else if (Settings.Default.WaypointEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Waypoint" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            else if (Settings.Default.DynamoEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "dyamo" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;

            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path33 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fs = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs, 0, offsetskin1, body1))
            {
                fs.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(body2);
                binaryWriter.Close();
                Settings.Default.harlwyquinnenabled = true;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body added!";
            }

            Stream fs2 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin1, Bodybp1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Bodybp2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Body Bp added!";
            }

            Stream fs4 = File.OpenRead(path);

            foreach (long s in Researcher.FindPosition(fs4, 0, offsetskin2, Head1))
            {
                fs4.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Head2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head added!";
            }

            Stream fs5 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs5, 0, offsetskin2, headam1))
            {
                fs5.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(headam2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Am added!";
            }

            string cidpath = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream fs6 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs6, 0, offsetskin2, headbp1))
            {
                fs6.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(headbp2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head Bp added!";
            }
            
            
            Stream fs7 = File.OpenRead(cidpath);

            foreach (long s in Researcher.FindPosition(fs7, 0, offsetlobby, cid1))
            {
                fs7.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cid2);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID 1/2 added!";
            }

            Stream fs9 = File.OpenRead(cidpath);

            foreach (long s in Researcher.FindPosition(fs9, 0, offsetlobby, cid11))
            {
                fs9.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(cidpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cid22);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] CID 2/2 added!";
            }


            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {

        }

        private void revert_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(harleyquinn));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.revert1Bytes = new System.ComponentModel.BackgroundWorker();
            this.change1Bytes = new System.ComponentModel.BackgroundWorker();
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this;
            // 
            // revert1Bytes
            // 
            this.revert1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RevertBytes_DoWork);
            // 
            // change1Bytes
            // 
            this.change1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChangeBytes_DoWork);
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 111);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 87;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click_1);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 74);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 89;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 74);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 86;
            this.RichTextBoxInfo.Text = "";
            // 
            // harleyquinn
            // 
            this.ClientSize = new System.Drawing.Size(451, 246);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "harleyquinn";
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

            else
            {

                CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
                change1Bytes.RunWorkerAsync();
            }
        }

        private void revert_Click_1(object sender, EventArgs e)
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
                revert1Bytes.RunWorkerAsync();
            }
        }
    }
}
