using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vls_swapper_v3
{
    public partial class Homepannel : UserControl
    {
        private static Homepannel _instance;
        public static Homepannel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Homepannel();
                return _instance;
            }
        }

        public Homepannel()
        {
            InitializeComponent();
        }

        private void Homepannel_Load(object sender, EventArgs e)
        {

        }
    }
}
