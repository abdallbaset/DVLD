using System;
using System.IO;
using System.ComponentModel;

namespace Infrastructure.Logging
{
    [Description("Handles writing critical fallback logs to a local text file when primary logging mechanisms (like Event Viewer) fail.")]
    public static class FallbackFileLogger
    {
        private static readonly string _fallbackPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Critical_Fallback_Log.txt");

        /// <summary>
        /// Writes the failed log entry along with the exception details to a local fallback text file safely.
        /// </summary>
        [Description("Safely writes a fallback log entry to a text file without crashing the application.")]
        public static void LogFallback(string message, Exception eventViewerException)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] | [EventViewer Failed: {eventViewerException?.Message}] | Original Message: {message}";

                File.AppendAllText(_fallbackPath, logEntry + Environment.NewLine);
            }
            catch
            {
               
            }
        }
    }
}