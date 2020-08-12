using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MaterialSkin;
using System.Linq;
using MaterialSkin.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Properties;
using vls_swapper_v3.Panels;
using DiscordRPC;

namespace vls_swapper_v3
{
    public partial class launcher : MaterialForm
    {

        

        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public launcher()
        {
            InitializeComponent();
            UpdateRPC();
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

            if (!panel1.Controls.Contains(Homepannel.Instance))
            {
                panel1.Controls.Add(Homepannel.Instance);
                Homepannel.Instance.Dock = DockStyle.Fill;
                Homepannel.Instance.BringToFront();
            }
            else
                Homepannel.Instance.BringToFront();


            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            
        }

        void UpdateRPC()
        {


            loader.client.SetPresence(new RichPresence()
            {
                Details = "🍀 Fastest Skin Swapper",
                State = "🍀 Browsing launcher",
                Assets = new Assets
                {
                    LargeImageKey = "original_1_",
                    LargeImageText = "Fastest swapper",
                    SmallImageKey = "small1",
                    SmallImageText = "Powered by Whey"

                }
            });






        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Homepannel.Instance))
            {
                panel1.Controls.Add(Homepannel.Instance);
                Homepannel.Instance.Dock = DockStyle.Fill;
                Homepannel.Instance.BringToFront();
            }
            else
                Homepannel.Instance.BringToFront();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            //if (!panel1.Controls.Contains(store.Instance))
            //{
            //    panel1.Controls.Add(store.Instance);
            //    store.Instance.Dock = DockStyle.Fill;
            //    store.Instance.BringToFront();
            //}
            //else
            //    store.Instance.BringToFront();

            MessageBox.Show("soon");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(swappers.Instance))
            {
                panel1.Controls.Add(swappers.Instance);
                swappers.Instance.Dock = DockStyle.Fill;
                swappers.Instance.BringToFront();
            }
            else
                swappers.Instance.BringToFront();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            Credits a = new Credits();
            a.ShowDialog();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            
        }

        private void launcher_Load(object sender, EventArgs e)
        {

        }
    }
}
