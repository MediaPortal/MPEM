using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionManager.Common;
using ExtensionManager.Common.DataObjects;

namespace ExtensionManagerUI.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private ObservableCollection<ExtensionInfo> _extension;
        private RepositoryInfo _repositoryInfo;

        public SearchViewModel() { }

        public ObservableCollection<ExtensionInfo> Extensions
        {
            get { return _extension; }
            set { _extension = value; NotifyPropertyChanged(); }
        }

        public RepositoryInfo RepositoryInfo
        {
            get { return _repositoryInfo; }
            set { _repositoryInfo = value; NotifyPropertyChanged(); }
        }
    }
}
