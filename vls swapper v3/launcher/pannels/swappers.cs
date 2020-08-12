using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Emote;
using System.Diagnostics;
using System.Net;

namespace vls_swapper_v3
{
    public partial class swappers : UserControl
    {
		private static bool NeedUpdate;
		private static swappers _instance;
        public static swappers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new swappers();
                return _instance;
            }
        }

        public swappers()
        {
            InitializeComponent();

			
			
			


		}

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {


            Loader a = new Loader();
            a.ShowDialog();

           
        }


		






	}


	


}
