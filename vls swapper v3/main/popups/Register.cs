using System;
using System.Windows.Forms;
using vls_swapper_v3.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;
using System.Net;

namespace vls_swapper_v3.Menus
{
    public partial class Register : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        
        public Register()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode;
            if (enabledmode)
            {
                skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
            }
            else
            {
                skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
            }

            


        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            string token;

            username = txtUsername.Text;
            password = txtPassword.Text;
            token = materialSingleLineTextField1.Text;
            Yato.Auth.Register(username, password, token);
            MessageBox.Show("Register has been successful! Please login.", "vls Swapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            LoginMenu f1 = new LoginMenu();
            f1.Show();  
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //LoginMenu f1 = new LoginMenu();
            //f1.Show();
        }
    }
}
