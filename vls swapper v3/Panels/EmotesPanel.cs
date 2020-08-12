using vls_swapper_v3.Emotes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vls_swapper_v3.Other;
using vls_swapper_v3.Emote;

namespace vls_swapper_v3.Panels
{
    
    public partial class EmotesPanel : UserControl
    {
        
        private static EmotesPanel _instance;
        public static EmotesPanel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmotesPanel();
                return _instance;
            }
        }
        public EmotesPanel()
        {
            InitializeComponent(); 
        }
        private void flossButton_Click(object sender, EventArgs e)
        {
            FlossAsk a = new FlossAsk();
            a.ShowDialog();
        }

        private void EmotesPanel_Load(object sender, EventArgs e)
        {

        }
      
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void scenariobutton_Click(object sender, EventArgs e)
        {
            ScenarioElf a = new ScenarioElf();
            a.ShowDialog();
        }

        private void robotbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming next update.");
        }
  
        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void BunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            takethe a = new takethe();
            a.ShowDialog();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            nevergunna a = new nevergunna();
            a.ShowDialog();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            laserblast a = new laserblast();
            a.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            slick a = new slick();
            a.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            infection a = new infection();
            a.ShowDialog();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            twist a = new twist();
            a.ShowDialog();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            levertat a = new levertat();
            a.ShowDialog();

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ponyup a = new ponyup();
            a.ShowDialog();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            flapper a = new flapper();
            a.ShowDialog();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            phoneite a = new phoneite();
            a.ShowDialog();
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            lamacadraba a = new lamacadraba();
            a.ShowDialog();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            Daydream a = new Daydream();
            a.ShowDialog();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            poki a = new poki();
            a.ShowDialog();
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            Glowstick a = new Glowstick();
            a.ShowDialog();
        }
    }
}
