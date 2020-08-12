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
    public partial class aquaman : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public aquaman()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "aqua man";
            bool enabled = Settings.Default.aquamanenabled;
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

        string Body = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Mechanical_Engineer/Meshes/F_MED_Mechanical_Engineer.F_MED_Mechanical_Engineer";
        string Body1 = "/Game/Characters/Player/Male/Medium/Bodies/M_MED_Sandcastle/Meshes/M_MED_Sandcastle.M_MED_Sandcastle";
        string BodyBP = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Mechanical_Engineer/Meshes/F_MED_Mechanical_Engineer_AnimBP.F_MED_Mechanical_Engineer_AnimBP_C";
        string BodyBP1 = "/Game/Characters/Player/Male/Medium/Bodies/M_MED_Sandcastle/Meshes/M_MED_Sandcastle_AnimBP.M_MED_Sandcastle_AnimBP_C";
        string Gender = "EFortCustomGender::Female";
        string Gender1 = "EFortCustomGender::Femal1";
        string FaceACC = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Mechanical_Engineer/Meshes/Parts/F_MED_Mechanical_Engineer_FaceAcc.F_MED_Mechanical_Engineer_FaceAcc";
        string FaceACC1 = "/Game/Characters/Player/Male/Medium/Bodies/M_MED_Sandcastle/Meshes/Parts/M_MED_Sandcastle_FaceAcc.M_MED_Sandcastle_FaceAcc";
        string FaceACCBP = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Mechanical_Engineer/Meshes/Parts/F_MED_Mechanical_Engineer_FaceAcc_AnimBP.F_MED_Mechanical_Engineer_FaceAcc_AnimBP_C";
        string FaceACCBP1 = "/Game/Characters/Player/Male/Medium/Bodies/M_MED_Sandcastle/Meshes/Parts/M_MED_Sandcastle_FaceAcc_AnimBP.M_MED_Sandcastle_FaceAcc_AnimBP_C";
        string Head = "/Game/Characters/Player/Female/Medium/Heads/F_MED_Mechanical_Engineer_Head_01/Meshes/Female_Medium_Mechanical_Engineer_Head_01.Female_Medium_Mechanical_Engineer_Head_01";
        string Head1 = "/Game/Characters/Player/Male/Medium/Heads/M_MED_Sandcastle_Head/Meshes/M_MED_Sandcastle_Head.M_MED_Sandcastle_Head";
        string HeadBP = "/Game/Characters/Player/Female/Medium/Heads/F_MED_Mechanical_Engineer_Head_01/Meshes/F_MED_Mechanical_Engineer_Head_AnimBP_Child.F_MED_Mechanical_Engineer_Head_AnimBP_Child_C";
        string HeadBP1 = "/Game/Characters/Player/Male/Medium/Heads/M_MED_Sandcastle_Head/Meshes/M_MED_Sandcastle_Head_AnimBP.M_MED_Sandcastle_Head_AnimBP_C";



        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int offsetskin1 = Settings.Default.offsetbodyS3;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int offsetskin2 = Settings.Default.offsetbodyS31;
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
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(offsetskin1, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/3 removed!";
                Settings.Default.aquamanenabled = false;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Revert(offsetskin1, path, BodyBP, BodyBP1, 0, 0, false, false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 2/3 removed!";
            }

            long offset_current = Settings.Default.current_offset;
            bool swap3 = wheyswapper.Revert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap3)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 3/3 removed!";
            }

            bool swap4 = wheyswapper.Revert(offsetskin2, path1, FaceACC, FaceACC1, 0, 0, false, false);
            if (swap4)
            {
                RichTextBoxInfo.Text += "\n[LOG] Face 1/2 removed!";
            }

            bool swap5 = wheyswapper.Revert(offsetskin2, path1, FaceACCBP, FaceACCBP1, 0, 0, false, false);
            if (swap5)
            {
                RichTextBoxInfo.Text += "\n[LOG] Face 2/2 removed!";
            }

            bool swap6 = wheyswapper.Revert(offsetskin2, path1, Head, Head1, 0, 0, false, false);
            if (swap6)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 removed!";
            }

            bool swap7 = wheyswapper.Revert(offsetskin2, path1, HeadBP, HeadBP1, 0, 0, false, false);
            if (swap7)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 removed!";
            }



            revert.Enabled = false;
            convert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int offsetskin1 = Settings.Default.offsetbodyS3;
            int offsetpick = Settings.Default.offsetpick;
            int offsetback = Settings.Default.offsetback;
            int offsetskin2 = Settings.Default.offsetbodyS31;
            int offsetemote = Settings.Default.offsetemote;
            int offsetlobby = Settings.Default.offsetlobby;
            int offsetpickmesh = Settings.Default.offsetpickmesh;
            convert.Enabled = false;
            RichTextBoxInfo.Text = ""; RichTextBoxInfo.Text += "[LOG] Starting...";

            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(offsetskin1, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/3 added!";
                Settings.Default.aquamanenabled = true;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Convert(offsetskin1, path, BodyBP, BodyBP1, 0, 0, false, false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 2/3 added!";
            }

            long offset_current = Settings.Default.current_offset;
            bool swap3 = wheyswapper.Convert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap3)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 3/3 added!";
            }

            bool swap4 = wheyswapper.Convert(offsetskin2, path1, FaceACC, FaceACC1, 0, 0, false, false);
            if (swap4)
            {
                RichTextBoxInfo.Text += "\n[LOG] Face 1/2 added!";
            }

            bool swap5 = wheyswapper.Convert(offsetskin2, path1, FaceACCBP, FaceACCBP1, 0, 0, false, false);
            if (swap5)
            {
                RichTextBoxInfo.Text += "\n[LOG] Face 2/2 added!";
            }

            bool swap6 = wheyswapper.Convert(offsetskin2, path1, Head, Head1, 0, 0, false, false);
            if (swap6)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 added!";
            }

            bool swap7 = wheyswapper.Convert(offsetskin2, path1, HeadBP, HeadBP1, 0, 0, false, false);
            if (swap7)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 added!";
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
