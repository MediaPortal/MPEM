using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionManager.Common.DataObjects;

namespace ExtensionManagerUI.ViewModels
{
    public class ManageViewModel : ViewModelBase
    {
        private ObservableCollection<ExtensionInfo> _installedExtension;

        public ManageViewModel() { }

        public ObservableCollection<ExtensionInfo> InstalledExtensions
        {
            get { return _installedExtension; }
            set { _installedExtension = value; NotifyPropertyChanged(); }
        }
    }
}
