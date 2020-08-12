using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using Console = System.Console;

namespace updater
{
    class Program
    {
        
        
            static WebClient webclient = new WebClient();
            static void Main(string[] args)
            {
                Console.CursorVisible = false;
            Console.SetWindowSize(35, 35);
            Console.Title = "vls swapper v3 -  Updates Checker";
                foreach (Process process in Process.GetProcessesByName("vls launcher.exe"))
                {
                    process.Kill();
                }
                Title();
                Input("Checking for updates...");
                Program.GetFileVer();
                Console.Read();
            }
            private static void Title()
            {
                System.Console.Clear();
                Colorful.Console.WriteLine();
                Colorful.Console.Write("                                                                                          \n", Color.MediumPurple);
                Colorful.Console.Write("                               █    ██  ██▓███  ▓█████▄  ▄▄▄     ▄▄▄█████▓▓█████  ██▀███  \n", Color.MediumPurple);
                Colorful.Console.Write("                               ██  ▓██▒▓██░  ██▒▒██▀ ██▌▒████▄   ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒\n", Color.MediumPurple);
                Colorful.Console.Write("                              ▓██  ▒██░▓██░ ██▓▒░██   █▌▒██  ▀█▄ ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒\n", Color.MediumPurple);
                Colorful.Console.Write("                              ▓▓█  ░██░▒██▄█▓▒ ▒░▓█▄   ▌░██▄▄▄▄██░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  \n", Color.MediumPurple);
                Colorful.Console.Write("                              ▒▒█████▓ ▒██▒ ░  ░░▒████▓  ▓█   ▓██▒ ▒██▒ ░ ░▒████▒░██▓ ▒██▒\n", Color.MediumPurple);
                Colorful.Console.Write("                              ░▒▓▒ ▒ ▒ ▒▓▒░ ░  ░ ▒▒▓  ▒  ▒▒   ▓▒█░ ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░\n", Color.MediumPurple);
                Colorful.Console.Write("                              ░░▒░ ░ ░ ░▒ ░      ░ ▒  ▒   ▒   ▒▒ ░   ░     ░ ░  ░  ░▒ ░ ▒░\n", Color.MediumPurple);
                Colorful.Console.Write("                               ░░░ ░ ░ ░░        ░ ░  ░   ░   ▒    ░         ░     ░░   ░ \n", Color.MediumPurple);
                Colorful.Console.Write("                                 ░                 ░          ░  ░           ░  ░   ░     \n", Color.MediumPurple);
                Colorful.Console.Write("                                                 ░                                        \n", Color.MediumPurple);
                Colorful.Console.Write("\n");
            }

            public static void Input(string text)
            {
                Colorful.Console.Write(string.Format("                              [{0}] ", DateTime.Now), Color.Purple);
                Colorful.Console.Write(text + "\n", Color.White);
            }

            private static void CheckForUpdates(string fv)
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Proxy = null;
                        webClient.Headers.Set("User-Agent", "2af72f100c356273d46284f6fd1dfc08");
                        string text = webClient.DownloadString("https://pastebin.com/raw/TPNtD4ve").ToString();
                        Input("Newest version: " + text);
                        if (!text.Contains(fv))
                        {
                            Input("Update available! Please wait till we download it...");
                            Program.Download();
                        }
                        else
                        {
                            Input("You are up to date!");
                            Thread.Sleep(3000);
                            Environment.Exit(1);
                        }
                    }
                    catch (Exception)
                    {
                        Input("ERROR: SERVER_ERROR");
                    }
                }
            }

            private static void GetFileVer()
            {
                if (File.Exists("vls launcher.exe"))
                {
                    FileVersionInfo fileVersionInfo = null;
                    try
                    {
                        fileVersionInfo = FileVersionInfo.GetVersionInfo("vls launcher.exe");
                    }
                    catch (Exception e)
                    {
                        Input("ERROR: " + e);
                    }
                    string text = string.Format("{0}.{1}.{2}.{3}", new object[]
                    {
                    fileVersionInfo.FileMajorPart,
                    fileVersionInfo.FileMinorPart,
                    fileVersionInfo.FileBuildPart,
                    fileVersionInfo.FilePrivatePart,
                    });
                    Input("Current Version: " + text);
                    Program.CheckForUpdates(text);
                    return;
                }
                Program.Download();
            }

            private static void Download()
            {
                string link = webclient.DownloadString("https://pastebin.com/raw/fLfa2F4S");
                try
                {
                    
                    if (File.Exists("vls launcher.exe"))
                    {
                        File.Delete("vls launcher.exe");
                    }
                    webclient.Proxy = null;
                    webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webclient.Headers.Set("User-Agent", "f5065f94cd648b088cd6a346444ba2f7");
                    webclient.DownloadFileAsync(new Uri(link), "vls launcher.exe");
                    while (webclient.IsBusy)
                        Thread.Sleep(1000);
                    if (File.Exists("vls launcher.exe"))
                    {
                        Input("Finished downloading! Starting vls swapper...");
                        Console.WriteLine();
                        Thread.Sleep(3000);
                        Process.Start("vls launcher.exe");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Input("ERROR: File not downloaded!");
                    }
                }
                catch (Exception arg)
                {
                    Input("ERROR: " + arg);
                    
                    Console.Read();

                }
            }

        private static int counter;
        
        

        private static void ProgressChanged(object obj, DownloadProgressChangedEventArgs e)
        {
            Program.counter++;
            bool flag = Program.counter % 200 == 0;
            if (flag)
            {
                Program.Input(string.Concat(new string[]
                {
                    "Downloaded ",
                    ((float)e.BytesReceived / 1024f / 1024f).ToString("#0.##"),
                    "Mo of ",
                    ((float)e.TotalBytesToReceive / 1024f / 1024f).ToString("#0.##"),
                    "Mo  (",
                    e.ProgressPercentage.ToString(),
                    "%)"
                }));
            }
        }

        private static void Completed(object obj, AsyncCompletedEventArgs e)
        {
        }
    }
    
}
