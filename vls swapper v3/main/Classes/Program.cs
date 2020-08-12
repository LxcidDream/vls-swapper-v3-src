using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Linq;
using vls_swapper_v3;
using System.Collections.Generic;
using vls_swapper_v3.main.popups;
using System.Threading.Tasks;
using vls_swapper_v3.Properties;
using vls_swapper_v3.items.skins;
using System.Web.Script.Serialization;
using vls_swapper_v3.IO;

namespace vls_swapper_v3
{
    static class Program
    {
		private static bool NeedUpdate;

        public static object AnnoucementMessage { get; internal set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
		
		private static void Main(string[] args)
		{
			//Annoucement();
			Yato.Application.setName("vls swapper"); // You can set that to anything you want
			//Yato.Application.setJsonHash("27d3b2aa3d9e2bdc71e20c4368baeb48"); // Actual hash of Newtonsoft.Json.dll, you can get it with Yato.getJsonDllHash()
			Yato.Application.Initialize("aUlKbmVOaWVuZHU4UTZremFJTUNrMGExSVZrdnl1NnF1cWV4NkxuOWNCdnhuTWV1TFg=", "NivaRZXHPW", "da95ac66b03b0c77c6bbae6c7a06c58984de58ea");

			Program.GetCurrentVersion();
			bool needUpdate = Program.NeedUpdate;
			if (needUpdate)
			{
				Update update = new Update();
				bool flag = update.ShowDialog() != DialogResult.OK;
				if (flag)
				{
					Environment.Exit(0);
				}
			}
			FormUtils.SetDefaultIcon();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			Application.Run(new loader());
		}


		private static void GetCurrentVersion()
		{
			FileVersionInfo fileVersionInfo = null;
			try
			{
				fileVersionInfo = FileVersionInfo.GetVersionInfo("vls launcher.exe");
			}
			catch (Exception)
			{
				return;
			}
			Program.CheckForUpdates(string.Format("{0}.{1}.{2}.{3}", new object[]
			{
				fileVersionInfo.FileMajorPart,
				fileVersionInfo.FileMinorPart,
				fileVersionInfo.FileBuildPart,
				fileVersionInfo.FilePrivatePart
			}));
		}


		private static void CheckForUpdates(string CurrentVersion)
		{
			using (WebClient webClient = new WebClient())
			{
				try
				{
					webClient.Proxy = null;
					string value = webClient.DownloadString("https://pastebin.com/raw/TPNtD4ve").ToString();
					bool flag = !CurrentVersion.Contains(value);
					if (flag)
					{
						Program.NeedUpdate = true;
					}
					else
					{
						Program.NeedUpdate = false;
					}
				}
				catch (Exception)
				{
				}
			}
		}

		//private static void Annoucement()
  //      {
  //          WebClient webc = new WebClient();
  //          webc.Proxy = null;
  //          webc.Headers.Set("User-Agent", Variables.getVariable("annoucement-useragent"));
  //          string AnnoucementJSON = webc.DownloadString("https://pastebin.com/raw/Tmqt9d1w");

  //          var serializer = new JavaScriptSerializer();
  //          serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
  //          dynamic data = serializer.Deserialize(AnnoucementJSON, typeof(object));
  //          bool enabled = data.enabled;

  //          if (enabled)
  //          {
  //              AnnoucementMessage = data.message;
  //              Annoucement a = new Annoucement();
  //              a.ShowDialog();
  //          }
  //      }

		//private static void DeathMode()
		//{
		//string text = new WebClient
		//{
		//Proxy = null
		//}.DownloadString("https://pastebin.com/raw/8uKzpa0d");
		//bool flag = text.Equals("enabled");
		//if (flag)
		//{
		//MessageBox.Show("The vls swapper servers is actually under maintenance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		//Environment.Exit(0);
		//}
		//}

	}
}
