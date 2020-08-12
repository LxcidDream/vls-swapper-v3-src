using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using vls_swapper_v3.items.others;

namespace vls_swapper_v3.Panels
{
    public partial class otherPanel : UserControl
    {
        private static otherPanel _instance;
        public static otherPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new otherPanel();
                return _instance;
            }
        }
        public otherPanel()
        {
            InitializeComponent();
        }

        

        private void renegadebutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disabled");
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            banners a = new banners();
            a.ShowDialog();
        }
    }
}
