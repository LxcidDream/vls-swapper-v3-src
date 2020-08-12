using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MaterialSkin;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.main.popups
{
    public partial class epicyourgay : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public epicyourgay()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.kickitems = true;
            loader form = new loader();
            var Open = form;
            Open.Closed += (s, args) => this.Close();
            this.Hide();
            Open.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Settings.Default.kickitems = false;
            loader form = new loader();
            var Open = form;
            Open.Closed += (s, args) => this.Close();
            this.Hide();
            Open.Show();
        }
    }
}
