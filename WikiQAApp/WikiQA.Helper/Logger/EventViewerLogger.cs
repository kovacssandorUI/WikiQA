using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Helper.Logger
{
    public static class EventViewerLogger
    {
        public static void LogError(string source, Exception e)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "WikiQA");
            }
            EventLog.WriteEntry(source, e.ToString(), EventLogEntryType.Error);
        }

        public static void LogError(string source, object objectToLog, Exception e)
        {
            var logObject = JsonConvert.SerializeObject(objectToLog);
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "WikiQA");
            }
            EventLog.WriteEntry(source, e.ToString() + "\n" + logObject, EventLogEntryType.Error);
        }

        public static void LogInformation(string source, Exception e)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "WikiQA");
            }
            EventLog.WriteEntry(source, e.ToString(), EventLogEntryType.Information);
        }

        public static void LogInformation(string source, object objectToLog, string message = null)
        {
            var logObject = JsonConvert.SerializeObject(objectToLog);
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "WikiQA");
            }
            if (message != null)
            {
                EventLog.WriteEntry(source, message + "\n" + logObject, EventLogEntryType.Information);
            }
            else
            {
                EventLog.WriteEntry(source, logObject, EventLogEntryType.Information);
            }
        }



        public static void LogWarning(string source, Exception e)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "WikiQA");
            }
            EventLog.WriteEntry(source, e.ToString(), EventLogEntryType.Warning);
        }
    }


}
