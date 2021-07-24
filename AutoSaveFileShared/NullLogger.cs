using System;
using Microsoft.VisualStudio.Shell.Interop;

namespace AutoSaveFile
{
    internal class NullLogger : IVsActivityLog
    {
        public int LogEntry(uint actType, string pszSource, string pszDescription)
        {
            return 0;
        }

        public int LogEntryGuid(uint actType, string pszSource, string pszDescription, Guid guid)
        {
            return 0;
        }

        public int LogEntryHr(uint actType, string pszSource, string pszDescription, int hr)
        {
            return 0;
        }

        public int LogEntryGuidHr(uint actType, string pszSource, string pszDescription, Guid guid, int hr)
        {
            return 0;
        }

        public int LogEntryPath(uint actType, string pszSource, string pszDescription, string pszPath)
        {
            return 0;
        }

        public int LogEntryGuidPath(uint actType, string pszSource, string pszDescription, Guid guid, string pszPath)
        {
            return 0;
        }

        public int LogEntryHrPath(uint actType, string pszSource, string pszDescription, int hr, string pszPath)
        {
            return 0;
        }

        public int LogEntryGuidHrPath(uint actType, string pszSource, string pszDescription, Guid guid, int hr, string pszPath)
        {
            return 0;
        }
    }
}