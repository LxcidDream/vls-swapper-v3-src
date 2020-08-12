using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.Menus
{
    public partial class ResetPass : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public ResetPass()
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

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            username = txtUsername.Text;
            password = txtPassword.Text;
            string newpassword = txtNewPassword.Text;
            string newpassword_confirmation = txtNewPasswordCheck.Text;
            if (Yato.Application.isOTPEnabled())
            {
                string otp_code = txt2FA.Text;
                Yato.Auth.ChangePassword(username, password, newpassword, newpassword_confirmation, otp_code);
            }
            else
                Yato.Auth.ChangePassword(username, password, newpassword, newpassword_confirmation);
            this.Hide();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //LoginMenu f1 = new LoginMenu();
            //f1.Show();
        }
    }
}
