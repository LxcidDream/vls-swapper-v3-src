using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using vls_swapper_v3.items.skins;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.Skins;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace vls_swapper_v3.items
{
	
	public partial class RenegadeAsk : MaterialForm
	{
		bool freeregister = Settings.Default.premium;
		public RenegadeAsk()
		{
			this.InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
			this.skinManager.AddFormToManage(this);
			this.skinManager.Theme = MaterialSkinManager.Themes.DARK;
			bool flag = !Settings.Default.ismode;
			bool flag2 = flag;
			if (flag2)
			{
				this.skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE);
			}
			else
			{
				this.skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE);
			}

			Icon = ((System.Drawing.Icon)(Properties.Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
		}

		
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			RenegadeRaider a = new RenegadeRaider();
			a.ShowDialog();
		}

		
		private void PictureBox2_Click(object sender, EventArgs e)
		{
			

			if (freeregister == false)
			{
				MessageBox.Show("Checkered Renegade is reserved to Paid Members.");
			}
			else
			{
				CheckRenegade a = new CheckRenegade();
				a.ShowDialog();
			}


		}

		
		private readonly MaterialSkinManager skinManager = MaterialSkinManager.Instance;

		
		

		
	}
}
