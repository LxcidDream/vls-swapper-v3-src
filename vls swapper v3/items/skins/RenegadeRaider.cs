using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.items.skins;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;

namespace vls_swapper_v3.items.skins
{
    public partial class RenegadeRaider : MaterialForm
    {
        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public RenegadeRaider()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "Renegade Raider";
            bool enabled = Settings.Default.RenegadeEnabled;
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


        string Body = "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Skins/Female_Commando_StreetRacerBlack/Materials/F_MED___StreetRacerBlack.F_MED___StreetRacerBlack";
        string Body1 = "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Skins/TV_20/Materials/F_MED_Commando_Body_TV20.F_MED_Commando_Body_TV20";
        string Gender = "EFortCustomGender::Female";
        string Gender1 = "EFortCustomGender::Femal1";
        string Color = "/Game/Characters/CharacterColorSwatches/Skin/F_Med_HIS_StreetRacerBlack.F_Med_HIS_StreetRacerBlack";
        string Color1 = "/Game/Characters/CharacterColorSwatches/Skin/F_Med_HIS_ASN_F_Med_HIS_ASN";
        string Head = "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Skins/Female_Commando_StreetRacerBlack/Materials/F_MED_StreetRacerBlack_Head_01.F_MED_StreetRacerBlack_Head_01";
        string Head1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Materials/F_MED_ASN_Sarah_Hair_01.F_MED_ASN_Sarah_Hair_01";
        string Headmesh = "/Game/Characters/Player/Female/Medium/Heads/F_MED_HIS_Ramirez_Head_01/Mesh/F_MED_HIS_Ramirez_Head_01.F_MED_HIS_Ramirez_Head_01";
        string Headmesh1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Meshes/F_MED_ASN_Sarah_Head_01.F_MED_ASN_Sarah_Head_01";
        string HeadmeshBP = "/Game/Characters/Player/Female/Medium/Heads/F_MED_HIS_Ramirez_Head_01/Mesh/F_MED_HIS_Ramirez_Head_01_AnimBP_Child.F_MED_HIS_Ramirez_Head_01_AnimBP_Child_C";
        string HeadmeshBP1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Meshes/F_MED_ASN_Sarah_Head_01_AnimBP_Child.F_MED_ASN_Sarah_Head_01_AnimBP_Child_C";
        string Hat = "/Game/Accessories/Hats/Materials/Hat_F_StreetRacerBlack.Hat_F_StreetRacerBlack";
        string Hat1 = "/Game/Accessories/Hats/Materials/Female_Commando_07_V01.Female_Commando_07_V01";
        string Hatmat = "/Game/Accessories/Hats/Mesh/Female_Outlander_06.Female_Outlander_06";
        string Hatmat1 = "/Game/Accessories/Hats/Mesh/Female_Commando_08.Female_Commando_08";

        //string Body = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Body.MI_F_MED_Renegade_Raider_Fire_Body";
        //string Body1 = "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Skins/TV_21/Materials/F_MED_Commando_Body_TV20.F_MED_Commando_Body_TV20";
        //string Gender = "EFortCustomGender::Female";
        //string Gender1 = "EFortCustomGender::Femal1";
        //string Head = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Head.MI_F_MED_Renegade_Raider_Fire_Head";
        //string Head1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Materials/F_MED_ASN_Sarah_Head_02.F_MED_ASN_Sarah_Head_02";
        //string FaceAcc = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_FaceAcc.MI_F_MED_Renegade_Raider_Fire_FaceAcc";
        //string FaceAcc1 = "/Game/Accessories/Hats/Materials/Female_Commando_07_V02.Female_Commando_07_V02";
        //string CCPM = "B_CCPM_Base_Niagara_RenegadeRaider_Fire.B_CCPM_Base_Niagara_RenegadeRaider_Fire";
        //string CCPM1 = "B_CCPM_Base_Niagara_RenegadeRaider_Fire.B_CCPM_Base_Niagara_RenegadeRaider_0000";



        private void change1Bytes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.ReconEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Expert" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.GingerEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ginger Gunner" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.NogOpsEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Nog Ops" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ReconSpeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Recon Specialist" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            else if (Settings.Default.CheckRenegadeEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Renegade Raider[Checkered]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.HonorEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Wonder Skin" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.SurvivalEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Survival Specialist" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.BlueTeamLeaderEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "BlueTeamLeader" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.ScarletDefenderEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Scarlet Defender" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }


            CheckForIllegalCrossThreadCalls = false;
            int Offset_Skin_Body = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int Offset_Skin_Head = Settings.Default.offsetskin2;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;



            convert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";
            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(Offset_Skin_Body, bodypath, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 added!";
                Settings.Default.RenegadeEnabled = true;
                Settings.Default.Save();
            }


            long offset_current = Settings.Default.current_offset;
            bool swap2 = wheyswapper.Convert(offset_current, bodypath, Gender, Gender1, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 added!";

            bool swap3 = wheyswapper.Convert(Offset_Skin_Head, headpath, Color, Color1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Color added!";

            bool swap4 = wheyswapper.Convert(Offset_Skin_Head, headpath, Head, Head1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/3 added!";

            offset_current = Settings.Default.current_offset;
            bool swap5 = wheyswapper.Convert(offset_current, headpath, Headmesh, Headmesh1, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/3 added!";

            offset_current = Settings.Default.current_offset;
            bool swap6 = wheyswapper.Convert(offset_current, headpath, HeadmeshBP, HeadmeshBP1, 0, 0, false, false);
            if (swap6)
                RichTextBoxInfo.Text += "\n[LOG] Head 3/3 added!";

            offset_current = Settings.Default.current_offset;
            bool swap7 = wheyswapper.Convert(Offset_Skin_Head, headpath, Hat, Hat1, 0, 0, false, false);
            if (swap7)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 added!";

            offset_current = Settings.Default.current_offset;
            bool swap8 = wheyswapper.Convert(offset_current, headpath, Hatmat, Hatmat1, 0, 0, false, false);
            if (swap8)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 added!";





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
            string bodypath = Settings.Default.paksPath + "\\pakchunk10_s8-WindowsClient.pak";
            string headpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string pickaxepath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string pickaxesoundpath = Settings.Default.paksPath + "\\pakchunk10_s9-WindowsClient.pak";
            string backblingpath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";
            string emotespath = Settings.Default.paksPath + "\\pakchunk10-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(Offset_Skin_Body, bodypath, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 removed!";
                Settings.Default.RenegadeEnabled = false;
                Settings.Default.Save();
            }


            long offset_current = Settings.Default.current_offset;
            bool swap2 = wheyswapper.Revert(offset_current, bodypath, Gender, Gender1, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 removed!";


            bool swap3 = wheyswapper.Revert(Offset_Skin_Head, headpath, Color, Color1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Color removed!";

            offset_current = Settings.Default.current_offset;
            bool swap4 = wheyswapper.Revert(Offset_Skin_Head, headpath, Head, Head1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap5 = wheyswapper.Revert(offset_current, headpath, Headmesh, Headmesh1, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap6 = wheyswapper.Revert(offset_current, headpath, HeadmeshBP, HeadmeshBP1, 0, 0, false, false);
            if (swap6)
                RichTextBoxInfo.Text += "\n[LOG] Head 3/3 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap7 = wheyswapper.Revert(offset_current, headpath, Hat, Hat1, 0, 0, false, false);
            if (swap7)
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 removed!";

            offset_current = Settings.Default.current_offset;
            bool swap8 = wheyswapper.Revert(offset_current, headpath, Hatmat, Hatmat1, 0, 0, false, false);
            if (swap8)
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 removed!";

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
