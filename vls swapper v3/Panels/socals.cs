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

namespace vls_swapper_v3.Panels
{
    public partial class socals : UserControl
    {
        private static socals _instance;
        public static socals Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new socals();
                return _instance;
            }
        }
        public socals()
        {
            InitializeComponent();

            WebClient webClient = new WebClient();
            this.label1.Text = "hi " +  Environment.UserName + ", " + webClient.DownloadString("https://pastebin.com/raw/Ymib9MrC");
            
            WebClient hahah = new WebClient();
            this.label3.Text = hahah.DownloadString("https://pastebin.com/raw/EDfZgBnc");
            

        }

        private void bunifuFlatButton33_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
