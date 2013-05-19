using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtensionManager.Common.DataObjects
{
    public class ExtensionInfo
    {
        /// <summary>
        /// Gets or sets the Extension name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Extension type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Extension logo.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the Extension details.
        /// </summary>
        public string Details { get; set; }

        public string SubmittedBy { get; set; }

        public string Author { get; set; }

        public DateTime DateAdded { get; set; }

        public string ChangeLogLink { get; set; }

        public string WebsiteLink { get; set; }

        public string WikiLink { get; set; }

        public string ForumLink { get; set; }

        public string License { get; set; }

    

        /// <summary>
        /// Gets or sets the Extension rating.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the Extension category.
        /// </summary>
        public string Category { get; set; }

        public List<string> CategoryTags { get; set; }

        /// <summary>
        /// Gets or sets the extension download links.
        /// </summary>
        public List<VersionInfo> ExtensionVersions { get; set; }
        /// <summary>
        /// Gets or sets the screenshot links.
        /// </summary>
        public List<string> ScreenShots { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this Extension is installed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this Extension is installed; otherwise, <c>false</c>.
        /// </value>
        public bool IsInstalled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this Extension is compatible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this Extension is compatible; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompatible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this extension has an update available.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this extension has an update available; otherwise, <c>false</c>.
        /// </value>
        public bool IsUpdateAvailable { get; set; }

        public VersionInfo LatestVersion
        {
            get
            {
                return ExtensionVersions != null
                    ? ExtensionVersions.FirstOrDefault(x => x.IsLatest) : null;
            }
        }
    }
  
}
