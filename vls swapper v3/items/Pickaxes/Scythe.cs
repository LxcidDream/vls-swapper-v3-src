
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;
using vls_swapper_v3.Properties;
using vls_swapper_v3.IO;
using vls_swapper_v3.main.popups;

namespace vls_swapper_v3.Picks
{
    public partial class Scythe : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Scythe()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Scythe";
            bool enabled = Settings.Default.ScytheEnabled;
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

        private static byte[] Mesh = new byte[112]
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101
         };

        private static byte[] Mesh1 = new byte[112]
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
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 46,
(byte) 83,
(byte) 75,
(byte) 95,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
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

        private static byte[] IconS = new byte[128]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
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
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
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
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101
        };

        private static byte[] Icon1 = new byte[128]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 75,
(byte) 45,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 46,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 75,
(byte) 45,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
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
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0
        };

        private static byte[] IconL = new byte[132]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
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
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
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
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 87,
(byte) 104,
(byte) 105,
(byte) 116,
(byte) 101,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 45,
(byte) 76
        };

        private static byte[] IconL1 = new byte[132]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 85,
(byte) 73,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 97,
(byte) 116,
(byte) 105,
(byte) 111,
(byte) 110,
(byte) 47,
(byte) 84,
(byte) 101,
(byte) 120,
(byte) 116,
(byte) 117,
(byte) 114,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 84,
(byte) 45,
(byte) 73,
(byte) 99,
(byte) 111,
(byte) 110,
(byte) 45,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 75,
(byte) 45,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
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
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 45,
(byte) 83,
(byte) 75,
(byte) 45,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 45,
(byte) 76,
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
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0
        };

        private static byte[] Locker = new byte[91]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 67,
(byte) 111,
(byte) 115,
(byte) 109,
(byte) 101,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
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
(byte) 49,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 49,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114
        };

        private static byte[] Locker1 = new byte[91]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 73,
(byte) 116,
(byte) 101,
(byte) 109,
(byte) 115,
(byte) 47,
(byte) 67,
(byte) 111,
(byte) 115,
(byte) 109,
(byte) 101,
(byte) 116,
(byte) 105,
(byte) 99,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 97,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 72,
(byte) 97,
(byte) 108,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 101,
(byte) 101,
(byte) 110,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 46,
(byte) 72,
(byte) 97,
(byte) 108,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 101,
(byte) 101,
(byte) 110,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
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

        private static byte[] Swing1 = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing1T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 50,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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

        private static byte[] Swing2 = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing2T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 51,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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

        private static byte[] Swing3 = new byte[96]
        {
           (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing3T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 53,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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

        private static byte[] Swing4 = new byte[96]
        {
           (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing4T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 54,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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

        private static byte[] Swing5 = new byte[96]
        {
           (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing5T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 53,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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

        private static byte[] Swing6 = new byte[96]
        {
          (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 110,
(byte) 97,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 105,
(byte) 99,
(byte) 107,
(byte) 65,
(byte) 120,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 80,
(byte) 65,
(byte) 95,
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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
(byte) 83,
(byte) 116,
(byte) 114,
(byte) 101,
(byte) 101,
(byte) 116,
(byte) 82,
(byte) 97,
(byte) 99,
(byte) 101,
(byte) 114,
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

        private static byte[] Swing6T = new byte[96]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 83,
(byte) 111,
(byte) 117,
(byte) 110,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 111,
(byte) 114,
(byte) 116,
(byte) 95,
(byte) 87,
(byte) 101,
(byte) 97,
(byte) 112,
(byte) 111,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 83,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 47,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
(byte) 95,
(byte) 48,
(byte) 54,
(byte) 46,
(byte) 115,
(byte) 99,
(byte) 121,
(byte) 116,
(byte) 104,
(byte) 101,
(byte) 95,
(byte) 119,
(byte) 104,
(byte) 111,
(byte) 111,
(byte) 115,
(byte) 104,
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
                Settings.Default.ScytheEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text += "\n[LOG] Mesh removed!";
            }

            Stream fs1 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetpick, Icon1))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(IconS);             
                binaryWriter.Close();
                RichTextBoxInfo.Text += "\n[LOG] Icons removed!";
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
            else if (Settings.Default.SqueakEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Pick Squeak" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.VisionEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Vision" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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
                Settings.Default.ScytheEnabled = true;
                Settings.Default.Save();
                 RichTextBoxInfo.Text += "\n[LOG] Mesh added!";
            }

            Stream fs1 = File.OpenRead(filePath1);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetpick, IconS))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Icon1);
                binaryWriter.Close();
                RichTextBoxInfo.Text += "\n[LOG] Icons added!";
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
    }
}
