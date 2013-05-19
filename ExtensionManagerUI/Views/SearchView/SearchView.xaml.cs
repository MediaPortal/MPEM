using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ExtensionManager.Common.DataObjects;
using ExtensionManagerUI.Common;
using ExtensionManagerUI.Common.Dialogs;
using ExtensionManagerUI.ViewModels;

namespace ExtensionManagerUI.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : ViewBase
    {
        #region Fields

        /// <summary>Default category option, hard coded to be used if filter/sorting methods</summary>      
        private const string CategoryAll = "All";

        /// <summary>collection of extension</summary>      
        private ICollectionView _extensions;

        /// <summary> selected extension tpe</summary>        
        private string _selectedExtensionType = SearchView.CategoryAll;

        /// <summary> selected category name</summary>        
        private string _selectedCategory;

        /// <summary> selected SortFilter option </summary>        
        private string _selectedSortFilter;

        /// <summary> text entered in the serach textbox </summary>           
        private string _searchText;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchView"/> class.
        /// </summary>
        public SearchView()
        {
            InitializeComponent();
            MouseToTouchConverter.RegisterEvents(this);
        }
    
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        public ICollectionView Extensions
        {
            get { return _extensions; }
            set { _extensions = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the type of the selected extension. (Plugin, Skin etc.)
        /// </summary>
        public string SelectedExtensionType
        {
            get { return _selectedExtensionType; }
            set
            {
                _selectedExtensionType = value;
                SelectedCategory = CategoryAll;
                NotifyPropertyChanged();
                RefreshExtensionList();
            }
        }

        /// <summary>
        /// Gets or sets the selected category. (Input, Videos, Music etc.)
        /// </summary>
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged();
                RefreshExtensionList(); 
            }
        }

        /// <summary>
        /// Gets or sets the selected sort filter.(New, Most Downloaded etc.)
        /// </summary>
        public string SelectedSortFilter
        {
            get { return _selectedSortFilter; }
            set
            {
                _selectedSortFilter = value; 
                NotifyPropertyChanged();
                RefreshExtensionList();
            }
        }
        
        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; NotifyPropertyChanged(); RefreshExtensionList(); }
        }

        /// <summary>
        /// Gets the install command.
        /// </summary>
        public ICommand InstallCommand { get; internal set; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        public ICommand UpdateCommand { get; internal set; }

        public ExtensionInfo CurrentExtension
        {
            get
            {
                return _extensions == null ? null 
                    : _extensions.CurrentItem as ExtensionInfo;
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:ViewModelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        public override void OnViewModelChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnViewModelChanged(e);
            var viewModel = e.NewValue as SearchViewModel;
            if (viewModel != null)
            {
                // wrap the ExtensionInfo list in a ICollectionView so we can filter and sort a bit easier
                Extensions = new ListCollectionView(viewModel.Extensions);
                Extensions.Filter = new Predicate<object>(ExtensionsListFilter);
                Extensions.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }

        /// <summary>
        /// Creates the UI commands.
        /// </summary>
        public override void CreateCommands()
        {
            base.CreateCommands();
            InstallCommand = new RelayCommand<ExtensionInfo>(ex => InstallExtension(ex), ex => ex is ExtensionInfo && !(ex as ExtensionInfo).IsInstalled);
            UpdateCommand = new RelayCommand<ExtensionInfo>(ex => UpdateExtension(ex), ex => ex is ExtensionInfo && !(ex as ExtensionInfo).IsUpdateAvailable);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Filter to apply to extesions when filtering the collection
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private bool ExtensionsListFilter(object item)
        {
            var extension = item as ExtensionInfo;
            if (extension != null)
            {
                // TODO: make better search predicate once Extension model is not just a mockup
                bool result = true;
                if (_selectedExtensionType != SearchView.CategoryAll)
                {
                    result = _selectedCategory != SearchView.CategoryAll
                        ? extension.Category == _selectedExtensionType && extension.CategoryTags.Contains(_selectedCategory)
                        : extension.Category == _selectedExtensionType;
                }

                if (result == true && _selectedSortFilter != SearchView.CategoryAll)
                {
                    result = extension.CategoryTags.Contains(_selectedSortFilter);
                }

                if (result == true && !string.IsNullOrEmpty(_searchText))
                {
                    result = extension.Name.ToLower().StartsWith(_searchText.ToLower()) || extension.Name.ToLower().Contains(_searchText.ToLower());
                }

                return result;
            }
            return false;
        }

        /// <summary>
        /// Refreshes the extension list.
        /// </summary>
        private void RefreshExtensionList()
        {
            if (_extensions != null)
            {
                _extensions.Refresh();
            }
        }

        private void UpdateExtension(ExtensionInfo ex)
        {
            EMMessageBox.ShowMessageBox("UpdateCommand", "Feature Not Implemented!", EMMessageBoxButtons.OK, EMMessageBoxIcon.Error);
        }

        private void InstallExtension(ExtensionInfo ex)
        {
            EMMessageBox.ShowMessageBox("InstallCommand", "Feature Not Implemented!", EMMessageBoxButtons.OK, EMMessageBoxIcon.Error);
        }

        #endregion
    }
}
