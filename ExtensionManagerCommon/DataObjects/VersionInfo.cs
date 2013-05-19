using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.DataObjects
{
    public class VersionInfo
    {
        public string FriendlyName { get; set; }

        public string VersionName { get; set; }

        public string Version { get; set; }

        public string Status { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string DownloadLink { get; set; }

        public bool IsLatest { get; set; }
    }
}
