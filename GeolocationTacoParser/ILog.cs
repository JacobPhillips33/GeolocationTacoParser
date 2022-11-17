using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTacoParser
{
    public interface ILog
    {
        void LogFatal(string log, Exception exception = null);
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogDebug(string log);
    }
}
