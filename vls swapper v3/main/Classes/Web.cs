using System;
using System.IO;
using System.Net;

namespace vls_swapper_v3.IO
{
    public class Web
    {
        public static void downloadFileSilent(string url, string path = null)
        {
            WebClient wc = new WebClient();
            Uri address = new Uri(url);
            wc.Proxy = null;
            if (path == null)
            {
                wc.DownloadFileAsync(address, Path.GetFileName(address.LocalPath));
            }
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }

                wc.DownloadFileAsync(address, path);
            }
        }

        public static string downloadStringSilent(string url)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            return wc.DownloadString(url);
        }
    }
}
