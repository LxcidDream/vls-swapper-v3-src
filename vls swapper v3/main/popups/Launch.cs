using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3
{
    public partial class Launch : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Launch()
        {
            InitializeComponent();
            skinManager.AddFormToManage(this);
            timer1.Enabled = true;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode =! Settings.Default.ismode;if (enabledmode){skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);}else{skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);}
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Environment.Exit(0);
        }
    }
}
