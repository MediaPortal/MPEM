using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.Utils.Logger
{
    public class Log
    {
        private Type _owner { get; set; }
        private Action<LogLevel, string> _logAction { get; set; }

        public Log(Type owner, Action<LogLevel, string> logAction)
        {
            _owner = owner;
            _logAction = logAction;
        }

        public void Message(LogLevel level, string message, params object[] args)
        {
            string logMessage = args.Length > 0 ? string.Format(message, args) : message;
            string logLine = string.Format("[{0}] [{1}] - {2}", level, _owner.Name, logMessage);
            if (_logAction != null)
            {
                _logAction.Invoke(level, logLine);
            }
        }
    }
}
