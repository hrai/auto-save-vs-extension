using System.IO;
using EnvDTE;
using System.Runtime.CompilerServices;

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
    }
}
