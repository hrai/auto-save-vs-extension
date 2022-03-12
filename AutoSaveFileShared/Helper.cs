using System.IO;
using EnvDTE;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

[assembly: InternalsVisibleTo("AutoSaveFileTests")]
namespace AutoSaveFile
{
    internal class Helper
    {
        internal string GetFileType(Window window)
        {
            var documentFullName = window.Document?.FullName;

            if (documentFullName == null)
                documentFullName = window.Project?.FullName;

            if (Path.HasExtension(documentFullName))
                return Path.GetExtension(documentFullName).Replace(".", "");

            return "";
        }

        public static bool IsFileReadOnly(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);
            return fInfo.IsReadOnly;
        }

        internal bool ShouldSaveDocument(Window window, OptionPageGrid optionsPage)
        {
            var windowType = window.Kind;

            if (windowType == "Document")
            {
                var filePath = window.Document.FullName;

                if (File.Exists(filePath) && IsFileReadOnly(filePath))
                    return false;

                //if (!DirectoryHasPermission(Path.GetDirectoryName(filePath), FileSystemRights.Write))
                //    return false;

                var directoryList = GetConstituentFoldersFromPath(window);
                if (IsDocumentInIgnoredFolder(optionsPage.IgnoredFolders, directoryList))
                    return false;

                var fileType = GetFileType(window);
                var ignoredFileTypes = optionsPage.IgnoredFileTypes?
                    .ToLowerInvariant()
                    .Split(',')
                    .Select(str => str.Trim());

                if (ignoredFileTypes == null)
                    return true;

                if (ignoredFileTypes != null && !ignoredFileTypes.Contains(fileType))
                    return true;
            }

            return false;
        }

        /*
        private static bool DirectoryHasPermission(string directoryPath, FileSystemRights accessRight)
        {
            if (string.IsNullOrEmpty(directoryPath))
                return false;

            try
            {
                var rules = Directory.GetAccessControl(directoryPath).GetAccessRules(true, true, typeof(SecurityIdentifier));
                var identity = WindowsIdentity.GetCurrent();

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (!identity.Groups.Contains(rule.IdentityReference))
                        continue;

                    if ((accessRight & rule.FileSystemRights) != accessRight)
                        continue;

                    if (rule.AccessControlType != AccessControlType.Allow)
                        continue;

                    return true;
                }
            }
            catch { }
            return false;
        }
        */

        private IList<string> GetConstituentFoldersFromPath(Window window)
        {
            var documentFullName = window.Document?.FullName;

            if (documentFullName == null)
                documentFullName = window.Project?.FullName;

            return documentFullName.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
        }

        private bool IsDocumentInIgnoredFolder(string ignoredFolders, IList<string> directoryList)
        {
            foreach (string folder in ignoredFolders.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var incl = folder.StartsWith("!");
                var cleanFolderName = folder.Substring(incl ? 1 : 0).Trim();

                cleanFolderName = cleanFolderName.Replace('\\', '/');
                cleanFolderName = Regex.Escape(cleanFolderName);

                return directoryList.Any(dirs => dirs.Contains(cleanFolderName));
            }

            return false;
        }
    }
}
