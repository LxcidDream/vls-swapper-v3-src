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

namespace vls_swapper_v3
{
    public partial class store : UserControl
    {

        private static store _instance;
        public static store Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new store();
                return _instance;
            }
        }
        public store()
        {
            InitializeComponent();

            //using (WebResponse response = WebRequest.Create("https://api.nitestats.com/v1/shop/image").GetResponse())
            //{
            //    using (Stream responseStream = response.GetResponseStream())
            //    {
            //        Image image = Image.FromStream(responseStream);
            //        Image original = new Bitmap(image, new Size(image.Width / 2, image.Height / 2));
            //        this.pictureBox1.Image = new Bitmap(original);
            //    }
            //}



        }
    }
}
