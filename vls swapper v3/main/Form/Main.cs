using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using vls_swapper_v3.Panels;
using System.Linq;
using System.Text;
using vls_swapper_v3.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading.Tasks;
using DiscordRPC;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using vls_swapper_v3.Classes;
using System.IO;
using System.Net;
using vls_swapper_v3.Menus;

namespace vls_swapper_v3
{
    public partial class Main : MaterialForm
    {
        
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public Main()
        {
            
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            UpdateRPC();
            
                if (!panel1.Controls.Contains(SkinsPanel.Instance))
                {
                    panel1.Controls.Add(SkinsPanel.Instance);
                    SkinsPanel.Instance.Dock = DockStyle.Fill;
                    SkinsPanel.Instance.BringToFront();
                }
                else
                    SkinsPanel.Instance.BringToFront();


            //bool enabled = Settings.Default.sizebig;
            //if (enabled)
            //{
            //    Size = new System.Drawing.Size(800, 627);
            //    panel1.Size = new System.Drawing.Size(801, 517);

            //    materialRaisedButton8.BringToFront();

            //}
            //else
            //{
            //    Size = new System.Drawing.Size(800, 448);
            //    panel1.Size = new System.Drawing.Size(801, 340);


            //    materialRaisedButton5.BringToFront();

            //}


            if (Properties.Settings.Default.premium == false)
            {
                pictureBox1.Image = Resources.NO;
                materialLabel1.Location = new System.Drawing.Point(731, 35);
            }
            else
            {
                pictureBox1.Image = Resources.YES1;
                materialLabel1.Location = new System.Drawing.Point(724, 35);
            }




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


            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);


        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            
            Options a = new Options();
            a.ShowDialog();
            
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
           
                if (!panel1.Controls.Contains(SkinsPanel.Instance))
                {
                    panel1.Controls.Add(SkinsPanel.Instance);
                    SkinsPanel.Instance.Dock = DockStyle.Fill;
                    SkinsPanel.Instance.BringToFront();
                }
                else
                    SkinsPanel.Instance.BringToFront();
            
            
            UpdateRPC();

        }



        void UpdateRPC()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Skins Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Skins Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }

        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            Credits a = new Credits();
            a.ShowDialog();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            

            if (!panel1.Controls.Contains(backpacksPanel.Instance))
            {
                panel1.Controls.Add(backpacksPanel.Instance);
                backpacksPanel.Instance.Dock = DockStyle.Fill;
                backpacksPanel.Instance.BringToFront();
            }
            else
                backpacksPanel.Instance.BringToFront();
            backbacks();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(pickaxesPanel.Instance))
            {
                panel1.Controls.Add(pickaxesPanel.Instance);
                pickaxesPanel.Instance.Dock = DockStyle.Fill;
                pickaxesPanel.Instance.BringToFront();
            }
            else
                pickaxesPanel.Instance.BringToFront();
            pickaxes();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(EmotesPanel.Instance))
            {
                panel1.Controls.Add(EmotesPanel.Instance);
                EmotesPanel.Instance.Dock = DockStyle.Fill;
                EmotesPanel.Instance.BringToFront();
            }
            else
                EmotesPanel.Instance.BringToFront();
            emotes();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(otherPanel.Instance))
            {
                panel1.Controls.Add(otherPanel.Instance);
                otherPanel.Instance.Dock = DockStyle.Fill;
                otherPanel.Instance.BringToFront();
            }
            else
                otherPanel.Instance.BringToFront();
            other();
        }



        

        void backbacks()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Backpacks Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Backpacks Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
        }

        void other()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Other Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Other Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
        }

        void pickaxes()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Pickaxes Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Pickaxes Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
        }

        

        void emotes()
        {
            Yato.User user = Yato.Auth.getUser();

            bool enabled = Settings.Default.premium;
            if (enabled)
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Emotes Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Logged in as " + user.getUsername(),
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
            else
            {
                loader.client.SetPresence(new RichPresence()
                {
                    Details = "🍀 Fastest Skin Swapper",
                    State = "🍀 Browsing Emotes Tab",
                    Assets = new Assets
                    {
                        LargeImageKey = "original_1_",
                        LargeImageText = "Free user",
                        SmallImageKey = "small1",
                        SmallImageText = "Powered by Whey"

                    }
                });

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(800, 627);
            panel1.Size = new System.Drawing.Size(801, 517);
        }

        private void materialRaisedButton5_Click_1(object sender, EventArgs e)
        {
            //Size = new System.Drawing.Size(800, 627);
            //panel1.Size = new System.Drawing.Size(801, 517);


            MessageBox.Show("soon");
            

            //materialRaisedButton8.BringToFront();

            //Settings.Default.sizebig = true;
            //Settings.Default.Save();
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(800, 448);
            panel1.Size = new System.Drawing.Size(801, 340);

            materialRaisedButton5.BringToFront();

            Settings.Default.sizebig = false;
            Settings.Default.Save();
        }
    }
}
