using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ExtensionManagerUI.ViewModels;

namespace ExtensionManagerUI.Views
{
    /// <summary>
    /// Base class for creating Views
    /// </summary>
    public class ViewBase : UserControl, INotifyPropertyChanged
    {
        public ViewBase()
        {
            CreateCommands();
        }

        #region Properties

        /// <summary>
        /// The view model property
        /// </summary>
        public static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.Register("ViewModel", typeof(ViewModelBase), typeof(ViewBase)
          , new PropertyMetadata(new ViewModelBase(), (d,e) => (d as ViewBase).OnViewModelChanged(e)));

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ViewModelBase ViewModel
        {
            get { return (ViewModelBase)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        #region Virtuals

        /// <summary>
        /// Raises the <see cref="E:ViewModelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public virtual void OnViewModelChanged(DependencyPropertyChangedEventArgs e){}

        public virtual void CreateCommands() { }

        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return;
            }
         
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}
