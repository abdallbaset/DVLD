using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions; 

namespace Infrastructure.Logging
{
    [Description("Provides helper utilities to safely log information, warnings, and errors directly into the Windows Event Viewer under the DVLD_App source with dual-line tracking (Call line & Error line).")]
    public static class EventViewerLogger
    {
        private const string SourceName = "DVLD_System";

        /// <summary>
        /// Logs an informational event message.
        /// </summary>
        [Description("Logs an informational event message to the Windows Event Viewer.")]
        public static void LogInformation(string message)
        {
            string formattedMessage = FormatMessageWithCaller(message, EventLogEntryType.Information, null);
            WriteToEventLog(formattedMessage, EventLogEntryType.Information);
        }

        /// <summary>
        /// Logs a warning event message.
        /// </summary>
        [Description("Logs a warning event message to the Windows Event Viewer.")]
        public static void LogWarning(string message)
        {
            string formattedMessage = FormatMessageWithCaller(message, EventLogEntryType.Warning, null);
            WriteToEventLog(formattedMessage, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Logs an error message along with optional exception details and stack trace.
        /// </summary>
        [Description("Logs an error message along with optional exception details and stack trace to the Windows Event Viewer.")]
        public static void LogError(string message, Exception ex = null)
        {
            string formattedMessage = FormatMessageWithCaller(message, EventLogEntryType.Error, ex);
            WriteToEventLog(formattedMessage, EventLogEntryType.Error);
        }

        /// <summary>
        /// Formats the log message by tracking both the log call line and the actual exception source line.
        /// </summary>
        [Description("Formats the log message with dual line tracking using reflection and regex parsing.")]
        private static string FormatMessageWithCaller(string message, EventLogEntryType type, Exception ex)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(2, true);
                StackFrame frame = stackTrace.GetFrame(0);
                MethodBase callingMethod = frame?.GetMethod();

                string className = callingMethod?.DeclaringType?.FullName ?? "UnknownClass";
                string methodName = callingMethod?.Name ?? "UnknownMethod";
                int callLine = frame?.GetFileLineNumber() ?? -1;

                int errorLine = GetExceptionLineNumber(ex);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("========================================");
                sb.AppendLine($"[Location] Class: {className} -> Method: {methodName}");
                sb.AppendLine($"-> Log Called at Line: {callLine}"); 

                if (errorLine != -1)
                {
                    sb.AppendLine($"-> Actual Error Occurred at Line: {errorLine}");

                }

                sb.AppendLine($"[Message] {message}");

                if (ex != null)
                {
                    sb.AppendLine($"Exception Details:\n{ex.Message}");
                    sb.AppendLine($"Stack Trace:\n{ex.StackTrace}");
                }
                sb.AppendLine("========================================");

                return sb.ToString();
            }
            catch
            {
                return ex == null ? message : $"{message}\nException Details:\n{ex.Message}\nStack Trace:\n{ex.StackTrace}";
            }
        }

        /// <summary>
        /// Extracts the exact line number where the exception occurred from the exception's StackTrace string.
        /// </summary>
        private static int GetExceptionLineNumber(Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.StackTrace))
                return -1;

            Match match = Regex.Match(ex.StackTrace, @":line\s+(\d+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int line))
            {
                return line;
            }

            return -1;
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