using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.ComponentModel;

namespace AutoSaveFile
{
    public class OptionPageGrid : DialogPage
    {
        [Category("General")]
        [DisplayName("Time Delay")]
        [Description("Time delay in seconds for save")]
        public int TimeDelay { get; set; } = 5;

        [Category("General")]
        [DisplayName("Excluded File Types")]
        [Description("File types which will be ignored")]
        public IList<string> IgnoredFileTypes { get; set; }
    }
}
