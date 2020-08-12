using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Emotes;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.Other
{
    public partial class FlossAsk : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;


        public FlossAsk()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
        }

        private void infoitem_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
    
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
        
        }

        private void tposebuttn_Click(object sender, EventArgs e)
        {
  
        }

        private void robotbutton_Click(object sender, EventArgs e)
        {

        }

        private void BunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            FlossSwipe a = new FlossSwipe();
            a.ShowDialog();
        }

        private void BunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void BunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void BunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            FlossSprinkler a = new FlossSprinkler();
            a.ShowDialog();
        }

        private void BunifuFlatButton6_Click(object sender, EventArgs e)
        {
            FlossEnd a = new FlossEnd();
            a.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
