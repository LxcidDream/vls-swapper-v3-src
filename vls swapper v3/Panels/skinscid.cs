using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using vls_swapper_v3.items.others.NewFolder1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vls_swapper_v3.Panels
{
    public partial class skinscid : UserControl
    {

        private static skinscid _instance;
        public static skinscid Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new skinscid();
                return _instance;
            }
        }
        public skinscid()
        {
            InitializeComponent();
        }

        private void renegadebutton_Click(object sender, EventArgs e)
        {
            renegaderaider a = new renegaderaider();
            a.ShowDialog();
        }
    }
}
