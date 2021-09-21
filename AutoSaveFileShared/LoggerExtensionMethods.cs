using System;
using Microsoft.VisualStudio.Shell.Interop;

namespace AutoSaveFile
{
    public static class LoggerExtensionMethods
    {
        public static void LogInformation(this IVsActivityLog logger, string packageName, string message)
        {
            logger.LogEntry((UInt32)__ACTIVITYLOG_ENTRYTYPE.ALE_INFORMATION, packageName, message);
        }

        public static void LogWarning(this IVsActivityLog logger, string packageName, string message)
        {
            logger.LogEntry((UInt32)__ACTIVITYLOG_ENTRYTYPE.ALE_WARNING, packageName, message);
        }

        public static void LogError(this IVsActivityLog logger, string packageName, string message, Exception exception)
        {
            logger.LogEntry(
                (UInt32)__ACTIVITYLOG_ENTRYTYPE.ALE_ERROR,
                packageName,
                $"{message}{Environment.NewLine}Exception = `{exception.Message}`{Environment.NewLine}StackTrace = `{exception.StackTrace}`");
        }
    }

}
