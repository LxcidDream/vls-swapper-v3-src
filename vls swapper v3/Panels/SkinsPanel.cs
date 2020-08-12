using System;
using vls_swapper_v3.Properties;
using vls_swapper_v3.items.messages;
using vls_swapper_v3.items.skins;
using System.Linq;
using System.Windows.Forms;
using vls_swapper_v3.items;
using vls_swapper_v3.Skins;
using vls_swapper_v3.Other;
using System.Text;
using System.Threading.Tasks;
using vls_swapper_v3.Backblings;
using vls_swapper_v3.Emotes;
using vls_swapper_v3.items.cp_skins.treeskin;
using vls_swapper_v3.items.kicking.skins;
using vls_swapper_v3.items.Pickaxes;
using vls_swapper_v3.main.popups;
using vls_swapper_v3.Emote;
using System.Net;

namespace vls_swapper_v3.Panels
{
    public partial class SkinsPanel : UserControl
    {
        bool freeregister = Settings.Default.premium;
        string error = Resources.error;
        string actsomewhelse = Resources.alreadydone;
        private static SkinsPanel _instance;
        public static SkinsPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SkinsPanel();
                return _instance;
            }
        }
        public SkinsPanel()
        {
            InitializeComponent();


            





        }

        

        

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                britebomber a = new britebomber();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            
                string text = new WebClient
                {
                    Proxy = null
                }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
                bool flag = text.Equals("enabled");
                if (flag)
                {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                AstroJack a = new AstroJack();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                eliteagent a = new eliteagent();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                traviscp a = new traviscp();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }


            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                wondercp a = new wondercp();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

            
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                if (freeregister == false)
                {
                    MessageBox.Show("Black Knight is reserved to Paid Members.");
                }
                else
                {
                    CPskinerror q = new CPskinerror(); q.ShowDialog();
                    new blackknight().ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Disabled");
            }

            
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {

            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                harleyquincp a = new harleyquincp();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                sparcle a = new sparcle();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

            
        }

        private void SkinsPanel_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            string text = new WebClient
            {
                Proxy = null
            }.DownloadString("https://pastebin.com/raw/8uKzpa0d");
            bool flag = text.Equals("enabled");
            if (flag)
            {
                CPskinerror q = new CPskinerror(); q.ShowDialog();
                new mainiac().ShowDialog();
            }
            else
            {
                MessageBox.Show("Disabled");
            }

            
        }

        

        private void renegadebutton_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            RenegadeRaider a = new RenegadeRaider();
            a.ShowDialog();
        }

        private void ghoulbutton_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            ghoulstyle a = new ghoulstyle();
            a.ShowDialog();
        }

        private void rednosedbutton_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            RedNosedNite a = new RedNosedNite();
            a.ShowDialog();
        }

        private void ikonikbutton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Disabled");
        }

        private void bunifuFlatButton14_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            Bracer a = new Bracer();
            a.ShowDialog();
        }

        private void bunifuFlatButton16_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            BlueTeamLeader a = new BlueTeamLeader();
            a.ShowDialog();
        }

        private void bunifuFlatButton26_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            Haze a = new Haze();
            a.ShowDialog();
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton21_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            Punchy a = new Punchy();
            a.ShowDialog();
        }

        private void bunifuFlatButton22_Click_1(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            Sparkplug a = new Sparkplug();
            a.ShowDialog();
        }

        private void skullrangerbutton_Click_2(object sender, EventArgs e)
        {
            bypassneed q = new bypassneed(); q.ShowDialog();
            SkullRanger a = new SkullRanger();
            a.ShowDialog();
        }

        private void dynamobutton_Click_2(object sender, EventArgs e)
        {
            
        }
    }
}
