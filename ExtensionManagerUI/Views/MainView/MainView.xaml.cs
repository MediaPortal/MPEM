using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtensionManager.Common.DataObjects;
using ExtensionManager.Common.Utils;
using ExtensionManagerUI.Common;
using ExtensionManagerUI.Common.Dialogs;
using ExtensionManagerUI.ViewModels;

namespace ExtensionManagerUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ViewBase
    {
        #region Fields

        private ManageViewModel _manageViewModel;
        private SearchViewModel _searchViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            LoadDummyData();
        }



        private void LoadDummyData()
        {
            ViewModel = new ViewModels.MainViewModel
            {
                MediaPortalInfo = XmlSerialization.Deserialize<MediaPortalInfo>(Environment.CurrentDirectory + "\\Data\\DummyMediaPortalData.xml")
            };

            SearchViewModel = new ViewModels.SearchViewModel
            {
               Extensions = XmlSerialization.Deserialize<ObservableCollection<ExtensionInfo>>(Environment.CurrentDirectory + "\\Data\\DummyExtensionData.xml"),
               RepositoryInfo = XmlSerialization.Deserialize<RepositoryInfo>(Environment.CurrentDirectory + "\\Data\\DummyRepositoyData.xml")
            };

            ManageViewModel = new ViewModels.ManageViewModel
            {
                InstalledExtensions = XmlSerialization.Deserialize<ObservableCollection<ExtensionInfo>>(Environment.CurrentDirectory + "\\Data\\DummyExtensionData.xml"),
            };
        }


        #endregion

        #region Properties

        public SearchViewModel SearchViewModel
        {
            get { return _searchViewModel; }
            set { _searchViewModel = value; NotifyPropertyChanged(); }
        }
   
        public ManageViewModel ManageViewModel
        {
            get { return _manageViewModel; }
            set { _manageViewModel = value; }
        }

        //private CreateViewModel _createViewModel;

        //public CreateViewModel CreateViewModel
        //{
        //    get { return _createViewModel; }
        //    set { _createViewModel = value; }
        //}

        #endregion

        #region Methods


        #endregion

        #region Element Events

        private void WindowTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        private void WindowClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        #endregion
    }
}
