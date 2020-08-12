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

namespace vls_swapper_v3.Skins
{
    public partial class CheckRenegade : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public CheckRenegade()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "Checkered Renegade";
            bool enabled = Settings.Default.CheckRenegadeEnabled;
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

        string Body = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Body.MI_F_MED_Renegade_Raider_Fire_Body";
        string Body1 = "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Skins/TV_21/Materials/F_MED_Commando_Body_TV21.F_MED_Commando_Body_TV21";
        string Gender = "EFortCustomGender::Female";
        string Gender1 = "EFortCustomGender::Femal1";
        string Head = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Head.MI_F_MED_Renegade_Raider_Fire_Head";
        string Head1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Materials/F_MED_ASN_Sarah_Head_02.F_MED_ASN_Sarah_Head_02";
        string FaceAcc = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_FaceAcc.MI_F_MED_Renegade_Raider_Fire_FaceAcc";
        string FaceAcc1 = "/Game/Accessories/Hats/Materials/Female_Commando_07_V01.Female_Commando_07_V01";
        string CCPM = "B_CCPM_Base_Niagara_RenegadeRaider_Fire.B_CCPM_Base_Niagara_RenegadeRaider_Fire";
        string CCPM1 = "B_CCPM_Base_Niagara_RenegadeRaider_Fire.B_CCPM_Base_Niagara_RenegadeRaider_0000";

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int Offset_Skin_Body = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int Offset_Skin_Head = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(Offset_Skin_Body, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 removed!";
                Settings.Default.CheckRenegadeEnabled = false;
                Settings.Default.Save();
            }


            long offset_current = Settings.Default.current_offset;
            bool swap2 = wheyswapper.Revert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 removed!";

            bool swap3 = wheyswapper.Revert(Offset_Skin_Head, path1, Head, Head1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap4 = wheyswapper.Revert(offset_current, path1, FaceAcc, FaceAcc1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap5 = wheyswapper.Revert(offset_current, path1, CCPM, CCPM1, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Head 3/3 removed!";

            revert.Enabled = false;
            convert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
     

            CheckForIllegalCrossThreadCalls = false;
            int Offset_Skin_Body = Settings.Default.offsetbodyS3;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int Offset_Skin_Head = Settings.Default.offsetbodyS31;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;



            convert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(10000, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 added!";
                Settings.Default.CheckRenegadeEnabled = true;
                Settings.Default.Save();
            }


            long offset_current = Settings.Default.current_offset;
            bool swap2 = wheyswapper.Convert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 added!";

            bool swap3 = wheyswapper.Convert(Offset_Skin_Head, path1, Head, Head1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/3 added!";

            offset_current = Settings.Default.current_offset;
            bool swap4 = wheyswapper.Convert(Offset_Skin_Head, path1, FaceAcc, FaceAcc1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/3 added!";

            offset_current = Settings.Default.current_offset;
            bool swap5 = wheyswapper.Convert(Offset_Skin_Body, path, CCPM, CCPM1, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Head 3/3 added!";

            convert.Enabled = false;
            revert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void revert1Bytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int Offset_Skin_Body = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int Offset_Skin_Head = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(Offset_Skin_Body, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 removed!";
                Settings.Default.RenegadeEnabled = false;
                Settings.Default.Save();
            }


            long offset_current = Settings.Default.current_offset;
            bool swap2 = wheyswapper.Revert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 removed!";

            bool swap3 = wheyswapper.Revert(Offset_Skin_Head, path1, Head, Head1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap4 = wheyswapper.Revert(offset_current, path1, FaceAcc, FaceAcc1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap5 = wheyswapper.Revert(offset_current, path1, CCPM, CCPM1, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Head 3/3 removed!";

            revert.Enabled = false;
            convert.Enabled = true;
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
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2;int offsetlobby = Settings.Default.offsetlobby;
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
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetlobby = Settings.Default.offsetlobby;
            revert1Bytes.RunWorkerAsync();
        }
    }
}
