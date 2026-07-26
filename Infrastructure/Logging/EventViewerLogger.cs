using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Infrastructure.Logging
{
    [Description("Provides helper utilities to safely log information, warnings, and errors directly into the Windows Event Viewer under the DVLD_App source.")]
    public static class EventViewerLogger
    {
        private const string SourceName = "DVLD_App";

        /// <summary>
        /// Logs an informational event message.
        /// </summary>
        [Description("Logs an informational event message to the Windows Event Viewer.")]
        public static void LogInformation(string message)
        {
            WriteToEventLog(message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Logs a warning event message.
        /// </summary>
        [Description("Logs a warning event message to the Windows Event Viewer.")]
        public static void LogWarning(string message)
        {
            WriteToEventLog(message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Logs an error message along with optional exception details and stack trace.
        /// </summary>
        [Description("Logs an error message along with optional exception details and stack trace to the Windows Event Viewer.")]
        public static void LogError(string message, Exception ex = null)
        {
            string finalMessage = ex == null ? message : $"{message}\nException Details:\n{ex.Message}\nStack Trace:\n{ex.StackTrace}";
            WriteToEventLog(finalMessage, EventLogEntryType.Error);
        }

        /// <summary>
        /// Core handler to write entries to the Event Log, ensuring the source exists and handling permission errors safely.
        /// </summary>
        [Description("Core internal handler to write entries to the Windows Event Log safely, managing source creation and suppressing permission exceptions.")]
        private static void WriteToEventLog(string message, EventLogEntryType type)
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }
                EventLog.WriteEntry(SourceName, message, type);
            }
            catch (Exception ex)
            {
                FallbackFileLogger.LogFallback(message, ex);
            }
        }
    }
}