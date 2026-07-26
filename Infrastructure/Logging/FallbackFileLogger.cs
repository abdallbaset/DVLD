using System;
using System.ComponentModel;
using System.IO;
using System.Text;

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
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("========================================");
                sb.AppendLine($"[FALLBACK LOG] Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sb.AppendLine($"[Error] EventViewer Failed: {eventViewerException?.Message}");
                sb.AppendLine("--- Original Message Content ---");
                sb.AppendLine(message); 

                File.AppendAllText(_fallbackPath, sb.ToString() + Environment.NewLine);
            }
            catch
            {
                // Additional protection to ensure the code does not collapse if a file write error occurs
            }
        }
    }
}