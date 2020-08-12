using DiscordRPC;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3
{
    public partial class Annoucement : MaterialForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Annoucement()
        {

            InitializeComponent();

            label1.Text = string.Format(label1.Text, Program.AnnoucementMessage);

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;
            if (enabledmode)
            {
                skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
            }
            else
            {
                skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
            }
        }

        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/hT4mpcR");
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

   
    }
}
