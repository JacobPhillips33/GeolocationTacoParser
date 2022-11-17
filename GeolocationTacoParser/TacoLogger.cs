using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTacoParser
{
    public class TacoLogger : ILog
    {
        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Error: {log}, Exception {exception}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }

        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }

        public void LogDebug(string log)
        {
            Console.WriteLine($"Debug: {log}");
        }
    }
}
