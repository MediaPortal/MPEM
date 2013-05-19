using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.DataObjects
{
    public class RepositoryInfo
    {
        public RepositoryInfo()
        {
            ExtensionCategories = new List<ExtensionCategory>();
            ExtensionFilters = new List<ExtensionCategory>();
        }
        public List<ExtensionCategory> ExtensionCategories { get; set; }
        public List<ExtensionCategory> ExtensionFilters { get; set; }
    }

    public class ExtensionCategory
    {
        public ExtensionCategory()
        {
            Categories = new List<ExtensionCategory>();
        }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<ExtensionCategory> Categories { get; set; }
    }
}
