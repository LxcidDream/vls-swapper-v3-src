using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vls_swapper_v3.Panels
{
    public partial class Skinsnokick : UserControl
    {

        private static Skinsnokick _instance;
        public static Skinsnokick Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Skinsnokick();
                return _instance;
            }
        }
        public Skinsnokick()
        {
            InitializeComponent();
        }

        private void ghoulbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
