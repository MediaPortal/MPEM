using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.Utils.Logger
{
    /// <summary>
    /// Message type
    /// </summary>
    public enum LogLevel
    {
        Verbose,
        /// <summary>
        /// Debug message
        /// </summary>
        Debug,
        /// <summary>
        /// Info message
        /// </summary>
        Info,
        /// <summary>
        /// Warn message
        /// </summary>
        Warn,
        /// <summary>
        /// Error message
        /// </summary>
        Error
    }
}
