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
using System.Net;
using System.Text.RegularExpressions;

namespace vls_swapper_v3.Picks
{
    public partial class Raiders : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        private static string GetTextFromUrl(string url)
        {
            WebClient wc = new WebClient();
            string page = wc.DownloadString(url);
            return page;
        }
        public Raiders()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));

            HttpWebRequest.DefaultWebProxy = new WebProxy();

            try
            {
                string Offset = GetTextFromUrl("https://pastebin.com/raw/6yZi8tFs");
                var result = Regex.Split(Offset, "\r\n|\r|\n");
                Settings.Default.offsetpurpleicon = int.Parse(result[0]); //offset_skin_body
                  

                Settings.Default.Save();
            }
            catch (Exception rr)
            {
                MessageBox.Show("Couldn't retrieve Informations from vls swapper's Server" + rr);
            }


            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Raider's Revenge";
            bool enabled = Settings.Default.RaidersEnabled;
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

        private static byte[] Mesh = new byte[85]
        {
      (byte) 47,
      (byte) 71,
      (byte) 97,
      (byte) 109,
      (byte) 101,
      (byte) 47,
      (byte) 87,
      (byte) 101,
      (byte) 97,
      (byte) 112,
      (byte) 111,
      (byte) 110,
      (byte) 115,
      (byte) 47,
      (byte) 70,
      (byte) 79,
      (byte) 82,
      (byte) 84,
      (byte) 95,
      (byte) 77,
      (byte) 101,
      (byte) 108,
      (byte) 101,
      (byte) 101,
      (byte) 47,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 77,
      (byte) 101,
      (byte) 115,
      (byte) 104,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 83,
      (byte) 75,
      (byte) 95,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 46,
      (byte) 83,
      (byte) 75,
      (byte) 95,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110
        };
        private static byte[] Mesh1 = new byte[85]
        {
      (byte) 47,
      (byte) 71,
      (byte) 97,
      (byte) 109,
      (byte) 101,
      (byte) 47,
      (byte) 87,
      (byte) 101,
      (byte) 97,
      (byte) 112,
      (byte) 111,
      (byte) 110,
      (byte) 115,
      (byte) 47,
      (byte) 70,
      (byte) 79,
      (byte) 82,
      (byte) 84,
      (byte) 95,
      (byte) 77,
      (byte) 101,
      (byte) 108,
      (byte) 101,
      (byte) 101,
      (byte) 47,
      (byte) 77,
      (byte) 101,
      (byte) 115,
      (byte) 104,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 83,
      (byte) 75,
      (byte) 95,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 111,
      (byte) 99,
      (byte) 97,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99,
      (byte) 46,
      (byte) 83,
      (byte) 75,
      (byte) 95,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 111,
      (byte) 99,
      (byte) 97,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99
        };
        private static byte[] Locker = new byte[45]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 73,
      (byte) 68,
      (byte) 95,
      (byte) 48,
      (byte) 55,
      (byte) 51,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 46,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 73,
      (byte) 68,
      (byte) 95,
      (byte) 48,
      (byte) 55,
      (byte) 51,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110
        };
        private static byte[] Locker1 = new byte[45]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 106,
      (byte) 97,
      (byte) 119,
      (byte) 46,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 106,
      (byte) 97,
      (byte) 119,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] IconS = new byte[93]
        {
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 84,
      (byte) 114,
      (byte) 97,
      (byte) 110,
      (byte) 115,
      (byte) 112,
      (byte) 97,
      (byte) 114,
      (byte) 101,
      (byte) 110,
      (byte) 116,
      (byte) 46,
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 84,
      (byte) 114,
      (byte) 97,
      (byte) 110,
      (byte) 115,
      (byte) 112,
      (byte) 97,
      (byte) 114,
      (byte) 101,
      (byte) 110,
      (byte) 116
        };
        private static byte[] Icon1 = new byte[93]
        {
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 97,
      (byte) 99,
      (byte) 111,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99,
      (byte) 46,
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 97,
      (byte) 99,
      (byte) 111,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] IconL = new byte[97]
        {
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 84,
      (byte) 114,
      (byte) 97,
      (byte) 110,
      (byte) 115,
      (byte) 112,
      (byte) 97,
      (byte) 114,
      (byte) 101,
      (byte) 110,
      (byte) 116,
      (byte) 45,
      (byte) 76,
      (byte) 46,
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 84,
      (byte) 114,
      (byte) 97,
      (byte) 110,
      (byte) 115,
      (byte) 112,
      (byte) 97,
      (byte) 114,
      (byte) 101,
      (byte) 110,
      (byte) 116,
      (byte) 45,
      (byte) 76
        };
        private static byte[] IconL1 = new byte[97]
        {
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 97,
      (byte) 99,
      (byte) 111,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99,
      (byte) 45,
      (byte) 76,
      (byte) 46,
      (byte) 84,
      (byte) 45,
      (byte) 73,
      (byte) 99,
      (byte) 111,
      (byte) 110,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 45,
      (byte) 83,
      (byte) 75,
      (byte) 45,
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 97,
      (byte) 120,
      (byte) 101,
      (byte) 45,
      (byte) 80,
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 65,
      (byte) 112,
      (byte) 97,
      (byte) 99,
      (byte) 111,
      (byte) 108,
      (byte) 121,
      (byte) 112,
      (byte) 116,
      (byte) 105,
      (byte) 99,
      (byte) 45,
      (byte) 76,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing1 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 49,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 49
        };
        private static byte[] Swing1T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 49,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 49,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing2 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 50,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 50
        };
        private static byte[] Swing2T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 50,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 50,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing3 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 51,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 51
        };
        private static byte[] Swing3T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 51,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 51,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing4 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 52,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 52
        };
        private static byte[] Swing4T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 52,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 52,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing5 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 53,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 53
        };
        private static byte[] Swing5T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 53,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 53,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private static byte[] Swing6 = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 54,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 66,
      (byte) 97,
      (byte) 108,
      (byte) 108,
      (byte) 111,
      (byte) 111,
      (byte) 110,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 54
        };
        private static byte[] Swing6T = new byte[56]
        {
      (byte) 80,
      (byte) 105,
      (byte) 99,
      (byte) 107,
      (byte) 65,
      (byte) 120,
      (byte) 101,
      (byte) 115,
      (byte) 47,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 54,
      (byte) 46,
      (byte) 80,
      (byte) 65,
      (byte) 95,
      (byte) 76,
      (byte) 111,
      (byte) 99,
      (byte) 107,
      (byte) 74,
      (byte) 97,
      (byte) 119,
      (byte) 95,
      (byte) 83,
      (byte) 119,
      (byte) 105,
      (byte) 110,
      (byte) 103,
      (byte) 95,
      (byte) 48,
      (byte) 54,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
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
            int offsetpurpleicon = Settings.Default.offsetpurpleicon;
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
                string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
                string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
                string text = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
                Stream stream = File.OpenRead(path2);
                foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Raiders.Mesh1))
                {
                    stream.Close();
                    BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                    binaryWriter.Write(Raiders.Mesh);
                    binaryWriter.Close();
                    Settings.Default.RaidersEnabled = false;
                    Settings.Default.Save();
                    this.RichTextBoxInfo.Text = "";
                    RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                    richTextBoxInfo2.Text += "\n[LOG] Mesh removed!";
                }
                Stream stream2 = File.OpenRead(path2);
                foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Raiders.Icon1))
                {
                    stream2.Close();
                    Settings.Default.RaidersEnabled = false;
                    Settings.Default.Save();
                    BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                    binaryWriter2.Write(Raiders.IconS);
                    binaryWriter2.Close();
                }
                Stream stream3 = File.OpenRead(path);
                foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpickmesh, Raiders.Swing1T))
                {
                    stream3.Close();
                    BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                    binaryWriter3.Write(Raiders.Swing1);
                    binaryWriter3.Close();
                }
                Stream stream4 = File.OpenRead(path);
                foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpickmesh, Raiders.Swing1T))
                {
                    stream4.Close();
                    BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                    binaryWriter4.Write(Raiders.Swing1);
                    binaryWriter4.Close();
                    RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
                    richTextBoxInfo3.Text += "\n[LOG] Sounds 1/6 removed!";
                }
                Stream stream5 = File.OpenRead(path);
                foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpickmesh, Raiders.Swing2T))
                {
                    stream5.Close();
                    BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                    binaryWriter5.Write(Raiders.Swing2);
                    binaryWriter5.Close();
                }
                Stream stream6 = File.OpenRead(path);
                foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpickmesh, Raiders.Swing2T))
                {
                    stream6.Close();
                    BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
                    binaryWriter6.Write(Raiders.Swing2);
                    binaryWriter6.Close();
                    RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
                    richTextBoxInfo4.Text += "\n[LOG] Sounds 2/6 removed!";
                }
                Stream stream7 = File.OpenRead(path);
                foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetpickmesh, Raiders.Swing3T))
                {
                    stream7.Close();
                    BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
                    binaryWriter7.Write(Raiders.Swing3);
                    binaryWriter7.Close();
                }
                Stream stream8 = File.OpenRead(path);
                foreach (long offset8 in Researcher.FindPosition(stream8, 0, (long)offsetpickmesh, Raiders.Swing3T))
                {
                    stream8.Close();
                    BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter8.BaseStream.Seek(offset8, SeekOrigin.Begin);
                    binaryWriter8.Write(Raiders.Swing3);
                    binaryWriter8.Close();
                    RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
                    richTextBoxInfo5.Text += "\n[LOG] Sounds 3/6 removed!";
                }
                Stream stream9 = File.OpenRead(path);
                foreach (long offset9 in Researcher.FindPosition(stream9, 0, (long)offsetpickmesh, Raiders.Swing4T))
                {
                    stream9.Close();
                    BinaryWriter binaryWriter9 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter9.BaseStream.Seek(offset9, SeekOrigin.Begin);
                    binaryWriter9.Write(Raiders.Swing4);
                    binaryWriter9.Close();
                }
                Stream stream10 = File.OpenRead(path);
                foreach (long offset10 in Researcher.FindPosition(stream10, 0, (long)offsetpickmesh, Raiders.Swing4T))
                {
                    stream10.Close();
                    BinaryWriter binaryWriter10 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter10.BaseStream.Seek(offset10, SeekOrigin.Begin);
                    binaryWriter10.Write(Raiders.Swing4);
                    binaryWriter10.Close();
                    RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
                    richTextBoxInfo6.Text += "\n[LOG] Sounds 4/6 removed!";
                }
                Stream stream11 = File.OpenRead(path);
                foreach (long offset11 in Researcher.FindPosition(stream11, 0, (long)offsetpickmesh, Raiders.Swing5T))
                {
                    stream11.Close();
                    BinaryWriter binaryWriter11 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter11.BaseStream.Seek(offset11, SeekOrigin.Begin);
                    binaryWriter11.Write(Raiders.Swing5);
                    binaryWriter11.Close();
                }
                Stream stream12 = File.OpenRead(path);
                foreach (long offset12 in Researcher.FindPosition(stream12, 0, (long)offsetpickmesh, Raiders.Swing5T))
                {
                    stream12.Close();
                    BinaryWriter binaryWriter12 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter12.BaseStream.Seek(offset12, SeekOrigin.Begin);
                    binaryWriter12.Write(Raiders.Swing5);
                    binaryWriter12.Close();
                    RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
                    richTextBoxInfo7.Text += "\n[LOG] Sounds 5/6 removed!";
                }
                Stream stream13 = File.OpenRead(path);
                foreach (long offset13 in Researcher.FindPosition(stream13, 0, (long)offsetpickmesh, Raiders.Swing6T))
                {
                    stream13.Close();
                    BinaryWriter binaryWriter13 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter13.BaseStream.Seek(offset13, SeekOrigin.Begin);
                    binaryWriter13.Write(Raiders.Swing6);
                    binaryWriter13.Close();
                }
                Stream stream14 = File.OpenRead(path);
                foreach (long offset14 in Researcher.FindPosition(stream14, 0, (long)offsetpickmesh, Raiders.Swing6T))
                {
                    stream14.Close();
                    BinaryWriter binaryWriter14 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter14.BaseStream.Seek(offset14, SeekOrigin.Begin);
                    binaryWriter14.Write(Raiders.Swing6);
                    binaryWriter14.Close();
                    RichTextBox richTextBoxInfo8 = this.RichTextBoxInfo;
                    richTextBoxInfo8.Text += "\n[LOG] Sounds 6/6 removed!";
                    RichTextBox richTextBoxInfo9 = this.RichTextBoxInfo;
                    richTextBoxInfo9.Text += "\n[LOG] All Sounds were removed!";
                }
                Stream stream15 = File.OpenRead(path2);
                foreach (long offset15 in Researcher.FindPosition(stream15, 0, (long)offsetpick, Raiders.pullout2))
                {
                    stream15.Close();
                    BinaryWriter binaryWriter15 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter15.BaseStream.Seek(offset15, SeekOrigin.Begin);
                    binaryWriter15.Write(Raiders.pullout1);
                    binaryWriter15.Close();
                    RichTextBox richTextBoxInfo10 = this.RichTextBoxInfo;
                    richTextBoxInfo10.Text += "\n[LOG] pullout Sound Removed!";
                }
                Stream stream16 = File.OpenRead(path2);
                foreach (long offset16 in Researcher.FindPosition(stream16, 0, (long)offsetpurpleicon, Raiders.purpleic1))
                {
                    stream16.Close();
                    BinaryWriter binaryWriter16 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter16.BaseStream.Seek(offset16, SeekOrigin.Begin);
                    binaryWriter16.Write(Raiders.purpleic);
                    binaryWriter16.Close();
                    RichTextBox richTextBoxInfo11 = this.RichTextBoxInfo;
                    richTextBoxInfo11.Text += "\n[LOG] purple icon Removed!";
                }
                Stream stream17 = File.OpenRead(path2);
                foreach (long offset17 in Researcher.FindPosition(stream17, 0, (long)offsetpick, Raiders.plhit2))
                {
                    stream17.Close();
                    BinaryWriter binaryWriter17 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter17.BaseStream.Seek(offset17, SeekOrigin.Begin);
                    binaryWriter17.Write(Raiders.plhit1);
                    binaryWriter17.Close();
                    RichTextBox richTextBoxInfo12 = this.RichTextBoxInfo;
                    richTextBoxInfo12.Text += "\n[LOG] players hit Sounds Removed!";
                }
                Stream stream18 = File.OpenRead(path2);
                foreach (long offset18 in Researcher.FindPosition(stream18, 0, (long)offsetpick, Raiders.hits2))
                {
                    stream18.Close();
                    BinaryWriter binaryWriter18 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter18.BaseStream.Seek(offset18, SeekOrigin.Begin);
                    binaryWriter18.Write(Raiders.hits1);
                    binaryWriter18.Close();
                    RichTextBox richTextBoxInfo13 = this.RichTextBoxInfo;
                    richTextBoxInfo13.Text += "\n[LOG] hit Smoke Removed!";
                }
                this.revert.Enabled = false;
                this.convert.Enabled = true;
                stopwatch.Stop();
                double num = (double)stopwatch.Elapsed.Seconds;
                RichTextBox richTextBoxInfo14 = this.RichTextBoxInfo;
                richTextBoxInfo14.Text += "\n[LOG] Done!";
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
            int offsetpurpleicon = Settings.Default.offsetpurpleicon;
            this.convert.Enabled = false;
            RichTextBox richTextBoxInfo = this.RichTextBoxInfo;
            richTextBoxInfo.Text += "\n[LOG] Starting...";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string path = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string path2 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path3 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            Stream stream = File.OpenRead(path2);
            foreach (long offset in Researcher.FindPosition(stream, 0, (long)offsetpick, Raiders.Mesh))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(Raiders.Mesh1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] mesh added!";
            }
            Stream stream2 = File.OpenRead(path2);
            foreach (long offset2 in Researcher.FindPosition(stream2, 0, (long)offsetpick, Raiders.IconS))
            {
                stream2.Close();
                Settings.Default.RaidersEnabled = true;
                Settings.Default.Save();
                BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter2.BaseStream.Seek(offset2, SeekOrigin.Begin);
                binaryWriter2.Write(Raiders.Icon1);
                binaryWriter2.Close();
            }
            Stream stream3 = File.OpenRead(path);
            foreach (long offset3 in Researcher.FindPosition(stream3, 0, (long)offsetpickmesh, Raiders.Swing1))
            {
                stream3.Close();
                BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
                binaryWriter3.Write(Raiders.Swing1T);
                binaryWriter3.Close();
            }
            Stream stream4 = File.OpenRead(path);
            foreach (long offset4 in Researcher.FindPosition(stream4, 0, (long)offsetpickmesh, Raiders.Swing1))
            {
                stream4.Close();
                BinaryWriter binaryWriter4 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter4.BaseStream.Seek(offset4, SeekOrigin.Begin);
                binaryWriter4.Write(Raiders.Swing1T);
                binaryWriter4.Close();
                RichTextBox richTextBoxInfo3 = this.RichTextBoxInfo;
                richTextBoxInfo3.Text += "\n[LOG] Sounds 1/6 added!";
            }
            Stream stream5 = File.OpenRead(path);
            foreach (long offset5 in Researcher.FindPosition(stream5, 0, (long)offsetpickmesh, Raiders.Swing2))
            {
                stream5.Close();
                BinaryWriter binaryWriter5 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter5.BaseStream.Seek(offset5, SeekOrigin.Begin);
                binaryWriter5.Write(Raiders.Swing2T);
                binaryWriter5.Close();
            }
            Stream stream6 = File.OpenRead(path);
            foreach (long offset6 in Researcher.FindPosition(stream6, 0, (long)offsetpickmesh, Raiders.Swing2))
            {
                stream6.Close();
                BinaryWriter binaryWriter6 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter6.BaseStream.Seek(offset6, SeekOrigin.Begin);
                binaryWriter6.Write(Raiders.Swing2T);
                binaryWriter6.Close();
                RichTextBox richTextBoxInfo4 = this.RichTextBoxInfo;
                richTextBoxInfo4.Text += "\n[LOG] Sounds 2/6 added!";
            }
            Stream stream7 = File.OpenRead(path);
            foreach (long offset7 in Researcher.FindPosition(stream7, 0, (long)offsetpickmesh, Raiders.Swing3))
            {
                stream7.Close();
                BinaryWriter binaryWriter7 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter7.BaseStream.Seek(offset7, SeekOrigin.Begin);
                binaryWriter7.Write(Raiders.Swing3T);
                binaryWriter7.Close();
            }
            Stream stream8 = File.OpenRead(path);
            foreach (long offset8 in Researcher.FindPosition(stream8, 0, (long)offsetpickmesh, Raiders.Swing3))
            {
                stream8.Close();
                BinaryWriter binaryWriter8 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter8.BaseStream.Seek(offset8, SeekOrigin.Begin);
                binaryWriter8.Write(Raiders.Swing3T);
                binaryWriter8.Close();
                RichTextBox richTextBoxInfo5 = this.RichTextBoxInfo;
                richTextBoxInfo5.Text += "\n[LOG] Sounds 3/6 added!";
            }
            Stream stream9 = File.OpenRead(path);
            foreach (long offset9 in Researcher.FindPosition(stream9, 0, (long)offsetpickmesh, Raiders.Swing4))
            {
                stream9.Close();
                BinaryWriter binaryWriter9 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter9.BaseStream.Seek(offset9, SeekOrigin.Begin);
                binaryWriter9.Write(Raiders.Swing4T);
                binaryWriter9.Close();
            }
            Stream stream10 = File.OpenRead(path);
            foreach (long offset10 in Researcher.FindPosition(stream10, 0, (long)offsetpickmesh, Raiders.Swing4))
            {
                stream10.Close();
                BinaryWriter binaryWriter10 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter10.BaseStream.Seek(offset10, SeekOrigin.Begin);
                binaryWriter10.Write(Raiders.Swing4T);
                binaryWriter10.Close();
                RichTextBox richTextBoxInfo6 = this.RichTextBoxInfo;
                richTextBoxInfo6.Text += "\n[LOG] Sounds 4/6 added!";
            }
            Stream stream11 = File.OpenRead(path);
            foreach (long offset11 in Researcher.FindPosition(stream11, 0, (long)offsetpickmesh, Raiders.Swing5))
            {
                stream11.Close();
                BinaryWriter binaryWriter11 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter11.BaseStream.Seek(offset11, SeekOrigin.Begin);
                binaryWriter11.Write(Raiders.Swing5T);
                binaryWriter11.Close();
            }
            Stream stream12 = File.OpenRead(path);
            foreach (long offset12 in Researcher.FindPosition(stream12, 0, (long)offsetpickmesh, Raiders.Swing5))
            {
                stream12.Close();
                BinaryWriter binaryWriter12 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter12.BaseStream.Seek(offset12, SeekOrigin.Begin);
                binaryWriter12.Write(Raiders.Swing5T);
                binaryWriter12.Close();
                RichTextBox richTextBoxInfo7 = this.RichTextBoxInfo;
                richTextBoxInfo7.Text += "\n[LOG] Sounds 5/6 added!";
            }
            Stream stream13 = File.OpenRead(path);
            foreach (long offset13 in Researcher.FindPosition(stream13, 0, (long)offsetpickmesh, Raiders.Swing6))
            {
                stream13.Close();
                BinaryWriter binaryWriter13 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter13.BaseStream.Seek(offset13, SeekOrigin.Begin);
                binaryWriter13.Write(Raiders.Swing6T);
                binaryWriter13.Close();
            }
            Stream stream14 = File.OpenRead(path);
            foreach (long offset14 in Researcher.FindPosition(stream14, 0, (long)offsetpickmesh, Raiders.Swing6))
            {
                stream14.Close();
                BinaryWriter binaryWriter14 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter14.BaseStream.Seek(offset14, SeekOrigin.Begin);
                binaryWriter14.Write(Raiders.Swing6T);
                binaryWriter14.Close();
                RichTextBox richTextBoxInfo8 = this.RichTextBoxInfo;
                richTextBoxInfo8.Text += "\n[LOG] Sounds 6/6 added!";
                RichTextBox richTextBoxInfo9 = this.RichTextBoxInfo;
                richTextBoxInfo9.Text += "\n[LOG] All Sounds were added!";
            }
            Stream stream15 = File.OpenRead(path2);
            foreach (long offset15 in Researcher.FindPosition(stream15, 0, (long)offsetpick, Raiders.pullout1))
            {
                stream15.Close();
                BinaryWriter binaryWriter15 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter15.BaseStream.Seek(offset15, SeekOrigin.Begin);
                binaryWriter15.Write(Raiders.pullout2);
                binaryWriter15.Close();
                RichTextBox richTextBoxInfo10 = this.RichTextBoxInfo;
                richTextBoxInfo10.Text += "\n[LOG] pullout Sound added!";
            }
            Stream stream16 = File.OpenRead(path2);
            foreach (long offset16 in Researcher.FindPosition(stream16, 0, (long)offsetpurpleicon, Raiders.purpleic))
            {
                stream16.Close();
                BinaryWriter binaryWriter16 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter16.BaseStream.Seek(offset16, SeekOrigin.Begin);
                binaryWriter16.Write(Raiders.purpleic1);
                binaryWriter16.Close();
                RichTextBox richTextBoxInfo11 = this.RichTextBoxInfo;
                richTextBoxInfo11.Text += "\n[LOG] purple icon Removed!";
            }
            Stream stream17 = File.OpenRead(path2);
            foreach (long offset17 in Researcher.FindPosition(stream17, 0, (long)offsetpick, Raiders.plhit1))
            {
                stream17.Close();
                BinaryWriter binaryWriter17 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter17.BaseStream.Seek(offset17, SeekOrigin.Begin);
                binaryWriter17.Write(Raiders.plhit2);
                binaryWriter17.Close();
                RichTextBox richTextBoxInfo12 = this.RichTextBoxInfo;
                richTextBoxInfo12.Text += "\n[LOG] players hit Sounds added!";
            }
            Stream stream18 = File.OpenRead(path2);
            foreach (long offset18 in Researcher.FindPosition(stream18, 0, (long)offsetpick, Raiders.hits1))
            {
                stream18.Close();
                BinaryWriter binaryWriter18 = new BinaryWriter(File.Open(path2, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter18.BaseStream.Seek(offset18, SeekOrigin.Begin);
                binaryWriter18.Write(Raiders.hits2);
                binaryWriter18.Close();
                RichTextBox richTextBoxInfo13 = this.RichTextBoxInfo;
                richTextBoxInfo13.Text += "\n[LOG] hit Smoke added!";
            }
            
            this.revert.Enabled = true;
            this.convert.Enabled = false;
            stopwatch.Stop();
            double num = (double)stopwatch.Elapsed.Seconds;
            RichTextBox richTextBoxInfo14 = this.RichTextBoxInfo;
            richTextBoxInfo14.Text += "\n[LOG] Done!";
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


        private static byte[] purpleic = new byte[]
        {
           082, 097, 114, 101
        };

        private static byte[] purpleic1 = new byte[]
        {
           101, 112, 105, 099
        };

        private static byte[] bypassr21 = new byte[]
        {
           080, 105, 099, 107, 097, 120, 101, 095, 073, 068, 095, 048, 055, 051, 095, 066, 097, 108, 108, 111, 111, 110, 046, 080, 105, 099, 107, 097, 120, 101, 095, 073, 068, 095, 048, 055, 051, 095, 066, 097, 108, 108, 111, 111, 110
        };

        private static byte[] bypassr22 = new byte[]
        {
            080, 105, 099, 107, 097, 120, 101, 095, 076, 111, 099, 107, 106, 097, 119, 046, 080, 105, 099, 107, 097, 120, 101, 095, 076, 111, 099, 107, 106, 097, 119, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] pullout1 = new byte[]
        {
           047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 083, 111, 117, 110, 100, 115, 047, 087, 101, 097, 112, 111, 110, 115, 047, 080, 105, 099, 107, 065, 120, 101, 115, 047, 066, 097, 108, 108, 111, 111, 110, 047, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 082, 101, 097, 100, 121, 095, 067, 117, 101, 046, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 082, 101, 097, 100, 121, 095, 067, 117, 101

        };

        private static byte[] pullout2 = new byte[]
        {
           000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000
        };

        private static byte[] plhit1 = new byte[]
       {
           047, 071, 097, 109, 101, 047, 065, 116, 104, 101, 110, 097, 047, 083, 111, 117, 110, 100, 115, 047, 087, 101, 097, 112, 111, 110, 115, 047, 080, 105, 099, 107, 065, 120, 101, 115, 047, 066, 097, 108, 108, 111, 111, 110, 047, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 073, 109, 112, 097, 099, 116, 095, 067, 117, 101, 046, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 073, 109, 112, 097, 099, 116, 095, 067, 117, 101
       };

        private static byte[] plhit2 = new byte[]
        {
           047, 071, 097, 109, 101, 047, 083, 111, 117, 110, 100, 115, 047, 070, 111, 114, 116, 095, 073, 109, 112, 097, 099, 116, 095, 083, 111, 117, 110, 100, 115, 047, 070, 108, 101, 115, 104, 047, 080, 108, 097, 121, 101, 114, 095, 073, 109, 112, 097, 099, 116, 095, 080, 065, 095, 076, 111, 099, 107, 074, 097, 119, 095, 067, 117, 101, 046, 080, 108, 097, 121, 101, 114, 095, 073, 109, 112, 097, 099, 116, 095, 080, 065, 095, 076, 111, 099, 107, 074, 097, 119, 095, 067, 117, 101, 000, 000, 000
        };

        private static byte[] hits1 = new byte[]
       {
           047, 071, 097, 109, 101, 047, 087, 101, 097, 112, 111, 110, 115, 047, 070, 079, 082, 084, 095, 077, 101, 108, 101, 101, 047, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 047, 070, 088, 047, 080, 095, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 073, 109, 112, 097, 099, 116, 046, 080, 095, 080, 105, 099, 107, 097, 120, 101, 095, 066, 097, 108, 108, 111, 111, 110, 095, 073, 109, 112, 097, 099, 116
       };

        private static byte[] hits2 = new byte[]
        {
           047, 071, 097, 109, 101, 047, 087, 101, 097, 112, 111, 110, 115, 047, 070, 079, 082, 084, 095, 077, 101, 108, 101, 101, 047, 066, 108, 117, 101, 112, 114, 105, 110, 116, 115, 047, 066, 095, 065, 116, 104, 101, 110, 097, 095, 080, 105, 099, 107, 097, 120, 101, 095, 071, 101, 110, 101, 114, 105, 099, 046, 066, 095, 065, 116, 104, 101, 110, 097, 095, 080, 105, 099, 107, 097, 120, 101, 095, 071, 101, 110, 101, 114, 105, 099, 095, 067, 000, 000, 000, 000, 000, 000
        };










    }
}
