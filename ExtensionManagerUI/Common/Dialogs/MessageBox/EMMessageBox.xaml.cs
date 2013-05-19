using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ExtensionManagerUI.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for TestDialog.xaml
    /// </summary>
    public partial class EMMessageBox : DialogBase
    {
        #region Statics

        /// <summary>
        /// Shows the message box.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public static EMMessageBoxResult ShowMessageBox(string title, string message, EMMessageBoxButtons buttons = EMMessageBoxButtons.OK, EMMessageBoxIcon icon = EMMessageBoxIcon.None)
        {
            var dialog = new EMMessageBox(title, message, buttons, icon);
            dialog.ShowDialog();
            return dialog.MessageBoxResult;
        }

        #endregion

        #region Fields

        private EMMessageBoxResult _messageBoxResult;
        private EMMessageBoxButtons _messageBoxButtons = EMMessageBoxButtons.OK;
        private EMMessageBoxIcon _messageBoxIcon;
        private string _message;
        private string _messageTitle;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EMMessageBox"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        public EMMessageBox(string title, string message, EMMessageBoxButtons buttons = EMMessageBoxButtons.OK, EMMessageBoxIcon icon = EMMessageBoxIcon.None)
        {
            ButtonResultCommand = new RelayCommand<EMMessageBoxResult>(param => ExecuteButtonResultCommand(param));
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            MessageBoxButtons = buttons;
            MessageBoxIcon = icon;
            Message = message;
            MessageTitle = title;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the button result command.
        /// </summary>
        public ICommand ButtonResultCommand { get; internal set; }

        /// <summary>
        /// Gets or sets the message box result.
        /// </summary>
        public EMMessageBoxResult MessageBoxResult
        {
            get { return _messageBoxResult; }
            set { _messageBoxResult = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the message box buttons.
        /// </summary>
        public EMMessageBoxButtons MessageBoxButtons
        {
            get { return _messageBoxButtons; }
            set { _messageBoxButtons = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the message box icon.
        /// </summary>
        public EMMessageBoxIcon MessageBoxIcon
        {
            get { return _messageBoxIcon; }
            set { _messageBoxIcon = value; NotifyPropertyChanged(); NotifyPropertyChanged("MessageIcon"); }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the message title.
        /// </summary>
        public string MessageTitle
        {
            get { return _messageTitle; }
            set { _messageTitle = value; NotifyPropertyChanged(); } 
        }

        /// <summary>
        /// Gets the message icon.
        /// </summary>
        public string MessageIcon
        {
            get { return string.Format("/ExtensionManagerUI;component/Common/Dialogs/MessageBox/Images/{0}.png", _messageBoxIcon); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the button result command.
        /// </summary>
        /// <param name="param">The param.</param>
        private void ExecuteButtonResultCommand(EMMessageBoxResult param)
        {
            MessageBoxResult = param;
            Close();
        }

        /// <summary>
        /// Handles the MouseDown event of the Title control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion
    }

    public enum EMMessageBoxResult
    {
        OK,
        Yes,
        No,
        Cancel
    }

    public enum EMMessageBoxButtons
    {
        OK,
        YesNo,
        YesNoCancel,
    }

    public enum EMMessageBoxIcon
    {
        None,
        Info,
        Question,
        Warn,
        Error
    }
}
