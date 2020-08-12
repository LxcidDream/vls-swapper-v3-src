
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

namespace vls_swapper_v3.Emote
{
    public partial class Glowstick : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Glowstick()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Glow stick";
            bool enabled = Settings.Default.DropSwipeEnabled;
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

        string CMM = "/Game/Animation/Game/MainPlayer/Emotes/Calculated/Emote_Calculated_CMM_Montage.Emote_Calculated_CMM_Montage";
        string CMM1 = "/Game/Animation/Game/MainPlayer/Emotes/GlowStickDance/Emote_GlowStickDance_CMM_M.Emote_GlowStickDance_CMM_M";
        string CMF = "/Game/Animation/Game/MainPlayer/Emotes/Calculated/Emote_Calculated_CMF_Montage.Emote_Calculated_CMF_Montage";
        string CMF1 = "/Game/Animation/Game/MainPlayer/Emotes/GlowStickDance/Emote_GlowStickDance_CMF_M.Emote_GlowStickDance_CMF_M";


        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int offsetskin1 = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int offsetskin2 = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;

            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(offsetemote, path, CMM, CMM1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Dance 1/2 removed!";
                Settings.Default.lamacadrabaenabled = false;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Revert(offsetemote, path, CMF, CMF1, 0, 0, false, false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Dance 2/2 removed!";
            }




            revert.Enabled = false;
            convert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.phoneitenabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "phone it up" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            CheckForIllegalCrossThreadCalls = false;
            int offsetskin1 = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int offsetskin2 = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;
            convert.Enabled = false;
            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(offsetemote, path, CMM, CMM1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Dance 1/2 added!";
                Settings.Default.lamacadrabaenabled = true;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Convert(offsetemote, path, CMF, CMF1, 0, 0, false, false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Dance 2/2 added!";
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
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
           Dance i = new Dance(); i.ShowDialog();
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
