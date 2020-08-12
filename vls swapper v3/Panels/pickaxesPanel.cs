using System;
using vls_swapper_v3.items.messages;
using vls_swapper_v3.items.backpaks;
using vls_swapper_v3.Backblings;
using System.Linq;
using System.Text;
using vls_swapper_v3.Picks;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.items.Pickaxes;
using vls_swapper_v3.Emotes;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.Panels
{
    public partial class pickaxesPanel : UserControl
    {
        private static pickaxesPanel _instance;
        public static pickaxesPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new pickaxesPanel();
                return _instance;
            }
        }
        public pickaxesPanel()
        {
            InitializeComponent();
        }

        private void raidersbutton_Click(object sender, EventArgs e)
        {
            raidersrevenge a = new raidersrevenge();
            a.ShowDialog();
        }

        private void candybutton_Click(object sender, EventArgs e)
        {
            Candy a = new Candy();
            a.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Minty a = new Minty();
            a.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            GalaxyPick a = new GalaxyPick();
            a.ShowDialog();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Squeak a = new Squeak();
            a.ShowDialog();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Scythe a = new Scythe();
            a.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            fncspick a = new fncspick();
            a.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            driver a = new driver();
            a.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (Settings.Default.premium == false)
            {
                MessageBox.Show("This is for paid members only!", "lug axe to studded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new Studded().ShowDialog();
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            diamond a = new diamond();
            a.ShowDialog();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            startwand a = new startwand();
            a.ShowDialog();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            spicky a = new spicky();
            a.ShowDialog();
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            if (Settings.Default.premium == false)
            {
                MessageBox.Show("This is for paid members only!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
            }
        }

        private void visionbutton_Click(object sender, EventArgs e)
        {
            Vision a = new Vision();
            a.ShowDialog();
        }
    }
}
