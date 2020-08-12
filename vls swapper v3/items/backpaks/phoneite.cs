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
    public partial class phoneite : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public phoneite()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Phone it up";
            bool enabled = Settings.Default.phoneitenabled;
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

        string CMM = "/Game/Animation/Game/MainPlayer/Emotes/Acrobatic_Superhero/Emote_AcrobaticSuperhero_CMM_M.Emote_AcrobaticSuperhero_CMM_M";
        string CMM1 = "/Game/Animation/Game/MainPlayer/Emotes/Epic_Sax_Guy/Emote_EpicSaxGuy_CMM_M1.Emote_EpicSaxGuy_CMM_M1";
        string CMF = "/Game/Animation/Game/MainPlayer/Emotes/Acrobatic_Superhero/Emote_AcrobaticSuperhero_CMF_M.Emote_AcrobaticSuperhero_CMF_M";
        string CMF1 = "/Game/Animation/Game/MainPlayer/Emotes/Epic_Sax_Guy/Emote_EpicSaxGuy_CMF_M.Emote_EpicSaxGuy_CMF_M";


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
                Settings.Default.phoneitenabled = false;
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
            if (Settings.Default.lamacadrabaenabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "lamacadraba" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
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
                Settings.Default.phoneitenabled = true;
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
