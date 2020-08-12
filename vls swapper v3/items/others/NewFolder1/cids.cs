using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using vls_swapper_v3.Panels;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Properties;
using vls_swapper_v3.items.others.NewFolder1;

namespace vls_swapper_v3.items.others
{
    public partial class cids : Form
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public cids()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            

            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void convert_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            renegaderaider a = new renegaderaider();
            a.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void materialRaisedButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
