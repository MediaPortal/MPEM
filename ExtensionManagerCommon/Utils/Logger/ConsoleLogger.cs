using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionManager.Common.Utils.Logger
{
    public class ConsoleLogger : Logger
    {
        protected override void LogQueuedMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
