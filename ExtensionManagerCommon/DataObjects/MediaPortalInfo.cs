using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.DataObjects
{
    public class MediaPortalInfo
    {
        public VersionInfo MediaPortalVersion { get; set; }

        public ExtensionInfo MediaPortalSkin { get; set; }

        public MediaPortalInstallType InstallType { get; set; }

        public List<ExtensionInfo> InstalledExtensions { get; set; }
    }

    public enum MediaPortalInstallType
    {
        MediaPortalOnly,
        SingleSeat,
        MultiSeat
    }
}
