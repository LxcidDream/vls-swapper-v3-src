using System;
using vls_swapper_v3.items.messages;
using vls_swapper_v3.items.backpaks;
using vls_swapper_v3.Backblings;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Other;
using vls_swapper_v3.Emotes;
using vls_swapper_v3.Properties;

namespace vls_swapper_v3.Panels
{
    public partial class backpacksPanel : UserControl
    {
        private static backpacksPanel _instance;
        public static backpacksPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new backpacksPanel();
                return _instance;
            }
        }
        public backpacksPanel()
        {
            InitializeComponent();
        }

        private void blackshieldbutton_Click(object sender, EventArgs e)
        {
            blackshild a = new blackshild();
            a.ShowDialog();
        }

        private void galaxybutton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("disabled");
            return;

            if (Settings.Default.premium == false)
            {
                MessageBox.Show("This is for paid members only!", "sith to galaxy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new galaxydisc().ShowDialog();
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (Settings.Default.premium == false)
            {
                MessageBox.Show("This is for paid members only!", "poolparty to rainbow clover", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new Clover().ShowDialog();
            }
        }

        private void enduringbutton_Click(object sender, EventArgs e)
        {
            EnduringAsk a = new EnduringAsk();
            a.ShowDialog();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Shark a = new Shark();
            a.ShowDialog();
        }

        private void wolfpackbutton_Click(object sender, EventArgs e)
        {
            WolfPack a = new WolfPack();
            a.ShowDialog();
        }

        private void scalybutton_Click(object sender, EventArgs e)
        {
            Scaly a = new Scaly();
            a.ShowDialog();
        }

        private void shaterredbutton_Click(object sender, EventArgs e)
        {
            RiftWings a = new RiftWings();
            a.ShowDialog();
        }

        private void backupbutton_Click(object sender, EventArgs e)
        {
            BackupAsk a = new BackupAsk();
            a.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            illusionruin a = new illusionruin();
            a.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            firebackpack a = new firebackpack();
            a.ShowDialog();
        }
    }
}
