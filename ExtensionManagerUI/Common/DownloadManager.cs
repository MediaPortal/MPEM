using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManagerUI.Common
{
    public class DownloadManager
    {
        public static async Task<string> DownloadFileAsync(string link, string destFilename)
        {
            Uri uri;
            if (Uri.TryCreate(link, UriKind.RelativeOrAbsolute, out uri))
            {
                string directory = Path.GetDirectoryName(destFilename);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (WebClient webClient = new WebClient())
                {
                    await webClient.DownloadFileTaskAsync(uri, destFilename); 
                    return destFilename;
                }
            }
            return string.Empty;
        }
    }
   
}
