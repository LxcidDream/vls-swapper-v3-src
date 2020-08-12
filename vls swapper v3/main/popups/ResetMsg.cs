using System;
using MaterialSkin;
using MaterialSkin.Controls;
using vls_swapper_v3.Properties;


namespace vls_swapper_v3
{
    public partial class ResetMsg : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public ResetMsg()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
			//skins
			Settings.Default.RenegadeEnabled = false;
			Settings.Default.ReconEnabled = false;
			Settings.Default.WonderEnable = false;
			Settings.Default.OgGhoulEnabled = false;
			Settings.Default.ElfEnabled = false;
			Settings.Default.CheckRenegadeEnabled = false;
			Settings.Default.HushEnabled = false;
			Settings.Default.CheckeredRenegadeOpsEnabled = false;
			Settings.Default.WhiteoutEnabled = false;
			Settings.Default.ChaosAgentEnabled = false;
			Settings.Default.AerialEnabled = false;
			Settings.Default.HazeEnabled = false;
			Settings.Default.ReconFRKEnabled = false;
			Settings.Default.ReconRTLEnabled = false;
			Settings.Default.SkullRangerEnabled = false;
			Settings.Default.BlackKnightEnabled = false;
			Settings.Default.WaypointEnabled = false;
			Settings.Default.DynamoEnabled = false;
			Settings.Default.RazorEnabled = false;
			Settings.Default.IkonikFableEnabled = false;
			Settings.Default.IkonikOnesieEnabled = false;
			Settings.Default.BreakpointEnabled = false;
			Settings.Default.harlwyquinnenabled = false;
			Settings.Default.DreamEnabled = false;
			Settings.Default.AutumnQueenEnabled = false;
			Settings.Default.RileyEnabled = false;
			Settings.Default.CrystalRoxEnabled = false;
			Settings.Default.BlueTeamLeaderEnabled = false;
			Settings.Default.GingerEnabled = false;
			Settings.Default.NogOpsEnabled = false;
			Settings.Default.ReconSpeEnabled = false;
			Settings.Default.HonorEnabled = false;
			Settings.Default.SurvivalEnabled = false;
			Settings.Default.ScarletDefenderEnabled = false;
			Settings.Default.RedNosedNiteEnabled = false;
			Settings.Default.GhoulNiteEnabled = false;
			Settings.Default.RoyaleKnightEnabled = false;
			Settings.Default.EliteNiteEnabled = false;
			Settings.Default.GalaxyEnabled = false;
			Settings.Default.ShadowOpsEnabled = false;
			Settings.Default.LaceEnabled = false;
			Settings.Default.VelocityEnabled = false;
			Settings.Default.CalistoEnabled = false;
			Settings.Default.SynapseEnabled = false;
			Settings.Default.SunbirdEnabled = false;
			Settings.Default.DoublecrossEnabled = false;
			Settings.Default.WhiteStyleEnabled = false;
			Settings.Default.BirdieEnabled = false;
			Settings.Default.BracerEnabled = false;
			Settings.Default.SkullyEnabled = false;
			Settings.Default.VolleyEnabled = false;
			Settings.Default.BoltEnabled = false;
			Settings.Default.FacetEnabled = false;
			Settings.Default.PunchyEnabled = false;
			Settings.Default.SparkplugEnabled = false;
			Settings.Default.BeachEnabled = false;
			Settings.Default.RubyEnabled = false;
			Settings.Default.CrystalEnabled = false;
			Settings.Default.RileyAuraEnabled = false;
			Settings.Default.RustlerEnabled = false;
			Settings.Default.DiverEnabled = false;
			Settings.Default.MarshEnabled = false;
			Settings.Default.RedJadeEnabled = false;
			Settings.Default.DemiSkinEnabled = false;
			Settings.Default.aquamanenabled = false;
			Settings.Default.RustlerEnabled = false;

			//cids
			Settings.Default.renegadecid = false;
			Settings.Default.BlackShieldEnabled = false;
			Settings.Default.GalaxyDiscEnabled = false;
			Settings.Default.CloverEnabled = false;
			Settings.Default.EnduringEnabled = false;
			Settings.Default.EnduringRagnarok = false;
			Settings.Default.SharkEnabled = false;
			Settings.Default.RiftWingsEnabled = false;
			Settings.Default.WolfPackEnabled = false;
			Settings.Default.ScalyEnabled = false;
			Settings.Default.BackupEnabled = false;
			Settings.Default.BackupPerfectEnabled = false;
			Settings.Default.illudionruinensbled = false;
			Settings.Default.FlameSigilenabled = false;
			//pickaxes
			Settings.Default.RaidersEnabled = false;
			Settings.Default.CandyEnabled = false;
			Settings.Default.MintyEnabled = false;
			Settings.Default.PickaxeGalaxy = false;
			Settings.Default.ScytheEnabled = false;
			Settings.Default.VisionEnabled = false;
			Settings.Default.StuddedEnabled = false;
			Settings.Default.SqueakEnabled = false;
			Settings.Default.driverenabled = false;
			Settings.Default.fnscenabled = false;
			Settings.Default.diamondenabled = false;
			Settings.Default.startwandenabled = false;
			Settings.Default.deufaltraiders = false;
            Settings.Default.spickyenabled = false;
            Settings.Default.IceBreakerEnabled = false;
			Settings.Default.AxecaliburEnabled = false;
			Settings.Default.raidersscorcerenabled = false;
			Settings.Default.TrustyEnabled = false;
			//emotes
			Settings.Default.FlossEndEnabled = false;
			Settings.Default.ScenarioOffEnabled = false;
			Settings.Default.FlossSprinklerEnabled = false;
			Settings.Default.FlossSwipeEnabled = false;
			Settings.Default.ScenarioSwipeEnabled = false;
			Settings.Default.DropSwipeEnabled = false;
			Settings.Default.ScenarioElfEnabled = false;
			Settings.Default.SmoothElfEnabled = false;
			Settings.Default.nevergunnaenabled = false;
			Settings.Default.laserblast = false;
			Settings.Default.slickenabled = false;
			Settings.Default.infectionenabled = false;
			Settings.Default.twistedenabled = false;
			Settings.Default.levatewnabled = false;
			Settings.Default.takethel = false;
			Settings.Default.ponyupenabled = false;
			Settings.Default.flapperenabled = false;
			Settings.Default.ponyupenabled = false;
			Settings.Default.phoneitenabled = false;
			Settings.Default.lamacadrabaenabled = false;
			Settings.Default.Daydreamenabled = false;
			Settings.Default.pokienabled = false;
			Settings.Default.flapperenabled = false;
			//cpskins
			Settings.Default.astroworldenabled = false;
			Settings.Default.cpskinEnabled = false;
			Settings.Default.cpbritebomber = false;
			Settings.Default.traviscpenabled = false;
			Settings.Default.cpwonderenabled = false;
			//banners
			Settings.Default.battlebusenabled = false;
			Settings.Default.epicgamebanner = false;
			Settings.Default.Save();
            DoneMsg a = new DoneMsg();
            a.ShowDialog();
            this.Close();
        }
    }
}
