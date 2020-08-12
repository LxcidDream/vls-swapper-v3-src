using vls_swapper_v3.Properties;
using vls_swapper_v3.Panels;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using vls_swapper_v3.items.skins;
using System.Windows.Forms;

namespace vls_swapper_v3.items.messages
{
    public partial class ghoulstyle : MaterialForm
    {
        private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public ghoulstyle()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Disabled " + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
            return;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

            ogghoul a = new ogghoul();
            a.ShowDialog();
        }
    }
}
