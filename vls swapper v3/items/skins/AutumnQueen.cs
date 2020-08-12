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
    public partial class AutumnQueen : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public AutumnQueen()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
            this.Text = "AutumnQueen";
            MessageBox.Show("This skin uses Rox [Tier1], be sure to select this style before swapping the AutumnQueen!");
            bool enabled = Settings.Default.AutumnQueenEnabled;
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

        string Body = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Strawberry_Pilot/Meshes/F_MED_StrawberryPilot_T1_Body.F_MED_StrawberryPilot_T1_Body";
        string Body1 = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Forest_Queen/Meshes/F_MED_Forest_Queen.F_MED_Forest_Queen";
        string BodyBP = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Strawberry_Pilot/Meshes/F_MED_StrawberryPilot_AnimBP.F_MED_StrawberryPilot_AnimBP_C";
        string BodyBP1 = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Forest_Queen/Meshes/F_MED_Forest_Queen_AnimBp.F_MED_Forest_Queen_AnimBp_C";
        string Head = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Strawberry_Pilot/Meshes/Parts/F_MED_StrawberryPilot_LongHair_FaceAcc.F_MED_StrawberryPilot_LongHair_FaceAcc";
        string Head1 = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Forest_Queen/Meshes/Parts/F_MED_Forest_Queen_FaceAcc.F_MED_Forest_Queen_FaceAcc";
        string HeadBP = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Strawberry_Pilot/Meshes/Parts/F_MED_StrawberryPilot_LongHair_FaceAcc_AnimBP.F_MED_StrawberryPilot_LongHair_FaceAcc_AnimBP_C";
        string HeadBP1 = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Forest_Queen/Meshes/Parts/F_MED_Forest_Queen_FaceAcc_AnimBp.F_MED_Forest_Queen_FaceAcc_AnimBp_C";
        string FaceAcc = "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Strawberry_Pilot/Materials/MI_F_Strawberry_Pilot_Head.MI_F_Strawberry_Pilot_Head";
        string FaceAcc1 = "/Game/Characters/Player/Female/Medium/Heads/F_MED_Forest_Queen/Materials/MI_F_MED_Forest_Queen_Head.MI_F_MED_Forest_Queen_Head";

        string Gender = "EFortCustomGender::Female";
        string Gender1 = "EFortCustomGender::Femal1";

       

        private void RevertBytes_DoWork(object sender, DoWorkEventArgs e)
        {
           CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (revert1Bytes.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            revert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting..."; 
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(offsetskin1, path, Body, Body1, 0, 0,false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/3 removed!";
                Settings.Default.AutumnQueenEnabled = false;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Revert(offsetskin1, path, BodyBP, BodyBP1, 0, 0,false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 2/3 removed!";         
            }

            long offset_current = Settings.Default.current_offset;
            bool swap3 = wheyswapper.Revert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Body 3/3 removed!";

            bool swap4 = wheyswapper.Revert(offsetskin2, path1, Head, Head1, 0, 0,false);
            if (swap4)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 removed!";
            }

            bool swap5 = wheyswapper.Revert(offsetskin2, path1, HeadBP, HeadBP1, 0, 0,false);
            if (swap5)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 removed!";
            }

            bool swap6 = wheyswapper.Revert(offsetskin2, path1, FaceAcc, FaceAcc1, 0, 0, false);
            if (swap6)
            {
                RichTextBoxInfo.Text += "\n[LOG] FaceAcc removed!";
            }

            string cidPath = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";
            

            revert.Enabled = false;
            convert.Enabled = true;         

        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; 
            int offsetskin1 = Settings.Default.offsetskin1;
            int offsetpick = Settings.Default.offsetpick; 
            int offsetback = Settings.Default.offsetback; 
            int offsetskin2 = Settings.Default.offsetskin2; 
            int offsetemote = Settings.Default.offsetemote; 
            int offsetlobby = Settings.Default.offsetlobby; 
            int offsetpickmesh = Settings.Default.offsetpickmesh;

            if (Settings.Default.CrystalRoxEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Crystal[Using Rox]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }
            else if (Settings.Default.RileyEnabled)
            {
                MetroFramework.MetroMessageBox.Show(this, "Riley[Using Rox]" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                return;
            }

            convert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";     
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s3-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(offsetskin1, path, Body, Body1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 1/2 added!";
                Settings.Default.AutumnQueenEnabled = true;
                Settings.Default.Save();
            }

            bool swap2 = wheyswapper.Convert(offsetskin1, path, BodyBP, BodyBP1, 0, 0, false, false);
            if (swap2)
            {
                RichTextBoxInfo.Text += "\n[LOG] Body 2/2 added!";
            }

            long offset_current = Settings.Default.current_offset;
            bool swap3 = wheyswapper.Convert(offset_current, path, Gender, Gender1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Body 3/3 added!";

            bool swap4 = wheyswapper.Convert(offsetskin2, path1, Head, Head1, 0, 0, false, false);
            if (swap4)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 1/2 added!";
            }

            bool swap5 = wheyswapper.Convert(offsetskin2, path1, HeadBP, HeadBP1, 0, 0, false, false);
            if (swap5)
            {
                RichTextBoxInfo.Text += "\n[LOG] Head 2/2 added";
            }

            bool swap6 = wheyswapper.Convert(offsetskin2, path1, FaceAcc, FaceAcc1, 0, 0, false);
            if (swap6)
            {
                RichTextBoxInfo.Text += "\n[LOG] FaceAcc added!";
            }

            revert.Enabled = true;
            convert.Enabled = false;           
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
           
            
            

               CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;
                change1Bytes.RunWorkerAsync();
            
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

        private void RichTextBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
