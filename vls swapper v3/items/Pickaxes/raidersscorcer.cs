using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;
using vls_swapper_v3;
using vls_swapper_v3.main.popups;
using vls_swapper_v3.IO;

namespace vls_swapper_v3.Emotes
{
    public partial class raidersscorcer : MaterialForm
    {

        Point lastPoint;
        CultureInfo culture = CultureInfo.CurrentUICulture;
        string enable = Resources.enabled;
        string disabled = Resources.disabled;
        string actsomewhelse = Resources.alreadydone;
        string paksinvalid = Resources.pathinvalid;
        string error = Resources.error;
        private MaterialRaisedButton revert;
        private BackgroundWorker revert1Bytes;
        private BackgroundWorker change1Bytes;
        private MaterialRaisedButton convert;
        private PictureBox pictureBox1;
        private RichTextBox RichTextBoxInfo;
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public raidersscorcer()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
            this.Text = "Raiders Revenge";
            bool enabled = Settings.Default.raidersscorcerenabled;
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

        private static byte[] cueswing = new byte[]
        {
            47,71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,65,114,99,116,105,99,83,110,105,112,101,114,47,80,65,95,65,114,99,116,105,99,83,110,105,112,101,114,95,83,119,105,110,103,95,67,117,101,46,80,65,95,65,114,99,116,105,99,83,110,105,112,101,114,95,83,119,105,110,103,95,67,117,101,0
        };

        private static byte[] cueswing1 = new byte[]
        {
            47,71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,80,105,99,107,65,120,101,95,76,111,99,107,106,97,119,95,83,119,105,110,103,95,65,116,104,101,110,97,95,67,117,101,46,80,105,99,107,65,120,101,95,76,111,99,107,74,97,119,95,83,119,105,110,103,95,65,116,104,101,110,97,95,67,117,101
        };

        private static byte[] cueready = new byte[]
        {
            47,71,97,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,65,114,99,116,105,99,83,110,105,112,101,114,47,80,65,95,65,114,99,116,105,99,83,110,105,112,101,114,95,82,101,97,100,121,95,67,117,101,46,80,65,95,65,114,99,116,105,99,83,110,105,112,101,114,95,82,101,97,100,121,95,67,117,101,0
        };

        private static byte[] cueready1 = new byte[]
        {
            47,71,71,109,101,47,65,116,104,101,110,97,47,83,111,117,110,100,115,47,87,101,97,112,111,110,115,47,80,105,99,107,65,120,101,115,47,80,105,99,107,65,120,101,95,76,111,99,107,106,97,119,95,83,119,105,110,103,95,65,116,104,101,110,97,95,67,117,101,46,80,105,99,107,65,120,101,95,76,111,99,107,74,97,119,95,83,119,105,110,103,95,65,116,104,101,110,97,95,67,117,101
        };

        string mesh = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/Meshes/Pickaxe_M_MED_ArcticSniper.Pickaxe_M_MED_ArcticSniper";
        string mesh1 = "/Game/Weapons/FORT_Melee/Meshes/SK_Pickaxe_PostApocalyptic.SK_Pickaxe_PostApocalyptic";

        
        

        string cueImapct = "/Game/Athena/Sounds/Weapons/PickAxes/ArcticSniper/PickAxe_ArcticSniper_Impact_Cue.PickAxe_ArcticSniper_Impact_Cue";
        string cueImapct1 = "/Game/Sounds/Fort_Impact_Sounds/Flesh/Player_Impact_PA_LockJaw_Cue.Player_Impact_PA_LockJaw_Cue";
        string icon = "/Game/UI/Foundation/Textures/Icons/Weapons/Items/T-Icon-Pickaxes-Pickaxe-ID-132-ArcticSniper.T-Icon-Pickaxes-Pickaxe-ID-132-ArcticSniper";
        string icons = "/Game/UI/Foundation/Textures/Icons/Weapons/Items/T-Icon-Pickaxes-SK-Pickaxe-PostApacolyptic.T-Icon-Pickaxes-SK-Pickaxe-PostApacolyptic";
        string fx = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_Weapon.P_Melee_Arctic_Sniper_Weapon";
        string fx1 = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_Weapon.P_Melee_Arctic_Sniper_Wea";
        string hit = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_Hit.P_Melee_Arctic_Sniper_Hit";
        string hit1 = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_H";
        string sound13 = "/Game/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_FireTrail.P_Melee_Arctic_Sniper_FireTrail";
        string sound131 = "/0000/Weapons/FORT_Melee/Pickaxe_ArcticSniper/FX/P_Melee_Arctic_Sniper_FireTrail.P_Melee_Arctic_Sniper_FireTrail";



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



            revert.Enabled = false;
            RichTextBoxInfo.Text = "";
            RichTextBoxInfo.Text += "[LOG] Starting...";
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            bool swap1 = wheyswapper.Revert(offsetpick, path, mesh, mesh1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Mesh removed!";
                Settings.Default.raidersscorcerenabled = false;
                Settings.Default.Save();
            }


            bool swap2 = wheyswapper.Revert(offsetpick, path1, icon, icons, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Icon removed!";

            
            bool swap3 = wheyswapper.Revert(offsetpick, path1, fx, fx1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Sound 1/3 removed!";

            
            bool swap4 = wheyswapper.Revert(offsetpick, path1, hit, hit1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Sound 2/3 removed!";

            
            bool swap5 = wheyswapper.Revert(offsetpick, path1, sound13, sound131, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Sound 3/3 removed!";

            bool swap6 = wheyswapper.Revert(offsetpick, path1, cueImapct, cueImapct1, 0, 0, false, false);
            if (swap6)
                RichTextBoxInfo.Text += "\n[LOG] Cue 1/3 removed!";

            Stream fs2 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetpick, cueswing1))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cueswing);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Cue 2/3 removed!";
            }

            Stream fs23 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs23, 0, offsetpick, cueready1))
            {
                fs23.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cueready);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Cue 3/3 removed!";
            }


            revert.Enabled = false;
            convert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void ChangeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
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
            string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
            string path1 = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";

            bool swap1 = wheyswapper.Convert(offsetpick, path, mesh, mesh1, 0, 0, false, false);
            if (swap1)
            {
                RichTextBoxInfo.Text += "\n[LOG] Mesh added!";
                Settings.Default.raidersscorcerenabled = true;
                Settings.Default.Save();
            }


            bool swap2 = wheyswapper.Convert(offsetpick, path1, icon, icons, 0, 0, false, false);
            if (swap2)
                RichTextBoxInfo.Text += "\n[LOG] Icon added!";


            bool swap3 = wheyswapper.Convert(offsetpick, path1, fx, fx1, 0, 0, false, false);
            if (swap3)
                RichTextBoxInfo.Text += "\n[LOG] Sound 1/3 added!";


            bool swap4 = wheyswapper.Convert(offsetpick, path1, hit, hit1, 0, 0, false, false);
            if (swap4)
                RichTextBoxInfo.Text += "\n[LOG] Sound 2/3 added!";


            bool swap5 = wheyswapper.Convert(offsetpick, path1, sound13, sound131, 0, 0, false, false);
            if (swap5)
                RichTextBoxInfo.Text += "\n[LOG] Sound 3/3 added!";

            bool swap6 = wheyswapper.Convert(offsetpick, path1, cueImapct, cueImapct1, 0, 0, false, false);
            if (swap6)
                RichTextBoxInfo.Text += "\n[LOG] Cue 1/3 added!";

            Stream fs2 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs2, 0, offsetpick, cueswing))
            {
                fs2.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cueswing1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Cue 2/3 added!";
            }

            Stream fs23 = File.OpenRead(path1);

            foreach (long s in Researcher.FindPosition(fs23, 0, offsetpick, cueready))
            {
                fs23.Close();
                BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(path1, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(s + 0L, SeekOrigin.Begin);
                binaryWriter.Write(cueready1);
                binaryWriter.Close();
                RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Cue 3/3 added!";
            }





            convert.Enabled = false;
            revert.Enabled = true;
            RichTextBoxInfo.Text += "\n[LOG] Done!";
        }

        private void convert_Click(object sender, EventArgs e)
        {

        }

        private void revert_Click(object sender, EventArgs e)
        {

        }



        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(raidersscorcer));
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.revert1Bytes = new System.ComponentModel.BackgroundWorker();
            this.change1Bytes = new System.ComponentModel.BackgroundWorker();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 110);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 91;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click_1);
            // 
            // revert1Bytes
            // 
            this.revert1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RevertBytes_DoWork);
            // 
            // change1Bytes
            // 
            this.change1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChangeBytes_DoWork);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 73);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 93;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 73);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 90;
            this.RichTextBoxInfo.Text = "";
            // 
            // raidersscorcer
            // 
            this.ClientSize = new System.Drawing.Size(438, 243);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RichTextBoxInfo);
            this.MaximizeBox = false;
            this.Name = "raidersscorcer";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void convert_Click_1(object sender, EventArgs e)
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

        private void revert_Click_1(object sender, EventArgs e)
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
