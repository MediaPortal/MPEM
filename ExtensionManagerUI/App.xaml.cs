using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ExtensionManager.Common.Utils.Logger;
using ExtensionManagerUI.Common;

namespace ExtensionManagerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly static MessengerService _messengerService = new MessengerService();
        internal static MessengerService MessengerService
        {
            get { return _messengerService; }
        }

       

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddLog(new ConsoleLogger());
#else
            LogManager.AddLog(new FileLogger(Environment.CurrentDirectory + "\\Logs", "ExtensionManager"));
#endif
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            LogManager.Destroy();
        }
    }
}
