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
    public partial class RedNosedNite : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public RedNosedNite()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Red-Nosed Raider";     
            bool enabled = Settings.Default.RedNosedNiteEnabled;
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
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 66,
(byte) 111,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 95,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 95,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 46,
(byte) 77,
(byte) 95,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119
       };

        private static byte[] Body1 = new byte[149]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 66,
(byte) 111,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 66,
(byte) 82,
(byte) 95,
(byte) 82,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 52,
(byte) 95,
(byte) 114,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 52,
(byte) 95,
(byte) 114,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0,
(byte) 0
        };

        private static byte[] Hair = new byte[157]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 66,
(byte) 111,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 95,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 105,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 105,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119
        };

        private static byte[] Hair1 = new byte[157]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 105,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 105,
(byte) 114,
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

        private static byte[] HeadTex = new byte[157]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 66,
(byte) 111,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 83,
(byte) 111,
(byte) 108,
(byte) 100,
(byte) 105,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 83,
(byte) 107,
(byte) 105,
(byte) 110,
(byte) 115,
(byte) 47,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 95,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 95,
(byte) 65,
(byte) 117,
(byte) 114,
(byte) 111,
(byte) 114,
(byte) 97,
(byte) 71,
(byte) 108,
(byte) 111,
(byte) 119
        };

        private static byte[] HeadTex1 = new byte[157]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 67,
(byte) 104,
(byte) 97,
(byte) 114,
(byte) 97,
(byte) 99,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 115,
(byte) 47,
(byte) 80,
(byte) 108,
(byte) 97,
(byte) 121,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 105,
(byte) 117,
(byte) 109,
(byte) 47,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 101,
(byte) 100,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 48,
(byte) 49,
(byte) 47,
(byte) 77,
(byte) 97,
(byte) 116,
(byte) 101,
(byte) 114,
(byte) 105,
(byte) 97,
(byte) 108,
(byte) 115,
(byte) 47,
(byte) 82,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 47,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 114,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 46,
(byte) 70,
(byte) 95,
(byte) 77,
(byte) 69,
(byte) 68,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 72,
(byte) 101,
(byte) 97,
(byte) 100,
(byte) 95,
(byte) 114,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
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

        private static byte[] Hat = new byte[78]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 99,
(byte) 99,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 111,
(byte) 114,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 71,
(byte) 108,
(byte) 97,
(byte) 115,
(byte) 115,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 100,
(byte) 101,
(byte) 115,
(byte) 46,
(byte) 70,
(byte) 101,
(byte) 109,
(byte) 97,
(byte) 108,
(byte) 101,
(byte) 95,
(byte) 67,
(byte) 111,
(byte) 109,
(byte) 109,
(byte) 97,
(byte) 110,
(byte) 100,
(byte) 111,
(byte) 95,
(byte) 83,
(byte) 104,
(byte) 97,
(byte) 100,
(byte) 101,
(byte) 115
        };

        private static byte[] Hat1 = new byte[78]
        {
            (byte) 47,
(byte) 71,
(byte) 97,
(byte) 109,
(byte) 101,
(byte) 47,
(byte) 65,
(byte) 99,
(byte) 99,
(byte) 101,
(byte) 115,
(byte) 115,
(byte) 111,
(byte) 114,
(byte) 105,
(byte) 101,
(byte) 115,
(byte) 47,
(byte) 72,
(byte) 97,
(byte) 116,
(byte) 115,
(byte) 47,
(byte) 77,
(byte) 101,
(byte) 115,
(byte) 104,
(byte) 47,
(byte) 82,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 116,
(byte) 46,
(byte) 82,
(byte) 101,
(byte) 105,
(byte) 110,
(byte) 100,
(byte) 101,
(byte) 101,
(byte) 114,
(byte) 95,
(byte) 72,
(byte) 97,
(byte) 116,
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

            revert.Enabled = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";



            Stream stream = File.OpenRead(bodypath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body1))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body);
                long offset = num + 726L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body removed!";
            }

            Stream fs1 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs1, 0, offsetskin2, Hair1))
            {
                fs1.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hair);
                binaryWriter.Close();
                Settings.Default.RedNosedNiteEnabled = false;
                Settings.Default.Save();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hair removed!";
            }

            Stream fs2 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, HeadTex1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadTex);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head removed!";
            }

            Stream fs53 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs53, 0, offsetskin2, Hat1))
            {
                fs53.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat removed!";
            }



            revert.Enabled = false;
            convert.Enabled = true;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (Settings.Default.SkullRangerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Skull Ranger" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.GhoulNiteEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ghoul Trooper[Using Nitelite]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RoyaleKnightEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Royale Knight" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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

            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";

            Stream stream = File.OpenRead(bodypath);
            foreach (long num in Researcher.FindPosition(stream, 0, (long)offsetskin1, Body))
            {
                stream.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(bodypath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                binaryWriter.Write(Body1);
                long offset = num + 726L;
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(CID1);
                binaryWriter.Close();
                RichTextBox richTextBoxInfo2 = this.RichTextBoxInfo;
                richTextBoxInfo2.Text += "\n[LOG] Body added!";
            }

            Stream fs2 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetskin2, Hair))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite)); ;
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hair1);
                Settings.Default.RedNosedNiteEnabled = true;
                Settings.Default.Save();
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hair added!";
            }

            Stream fs3 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs3, 0, offsetskin2, HeadTex))
            {
                fs3.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(HeadTex1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Head added!";
            }


            Stream fs53 = File.OpenRead(headpath);

            foreach (long s in Researcher.FindPosition(fs53, 0, offsetskin2, Hat))
            {
                fs53.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(headpath, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(Hat1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Hat  added!";
            }


            

            


            revert.Enabled = true;
            convert.Enabled = false;
            sw.Stop();
            double elapsed = sw.Elapsed.Seconds;
            this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Done!";
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
    }
}
