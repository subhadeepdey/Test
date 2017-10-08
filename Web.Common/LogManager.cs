using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common
{
    public class LogManager
    {
        static LogWriter logWriter;

        static LogManager()
        {
            InitLogging();
        }

        private static void InitLogging()
        {
            logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(logWriter, false);
        }

        public LogWriter LogWriter
        {
            get
            {
                return logWriter;
            }
        }

        public static void WriteInfo(String message)
        {
            logWriter.Write(message, "General", default(Int32), default(Int32), TraceEventType.Information);
        }
        public static void WriteError(String message)
        {
            logWriter.Write(message, "General", default(Int32), default(Int32), default(Int32));
        }
        public static void WriteError(Exception ex, string errorID)
        {
            StringBuilder error = new StringBuilder();
            error.AppendLine("MESSAGE: " + ex.Message);
            error.AppendLine("SOURCE: " + ex.Source);
            error.AppendLine("INSTANCE: " + ex.InnerException);
            error.AppendLine("DATA: " + ex.Data);
            error.AppendLine("TARGETSITE: " + ex.TargetSite);
            error.AppendLine("STACKTRACE: " + ex.StackTrace);
            logWriter.Write(error.ToString(), errorID, 5, 2000, TraceEventType.Error);
        }
    }
}
