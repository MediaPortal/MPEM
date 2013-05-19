using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionManager.Common;
using ExtensionManager.Common.DataObjects;
using ExtensionManagerUI.Common;

namespace ExtensionManagerUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() { }

        private MediaPortalInfo _mediaPortalInfo;

        public MediaPortalInfo MediaPortalInfo
        {
            get { return _mediaPortalInfo; }
            set { _mediaPortalInfo = value; NotifyPropertyChanged(); }
        }
    }
}
