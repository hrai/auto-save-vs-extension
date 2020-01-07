using Microsoft.VisualStudio.Shell;
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
        public string IgnoredFileTypes { get; set; }

        [Category("General")]
        [DisplayName("Save All Files When VS Loses Focus")]
        [Description("True saves all the files when VS loses focus")]
        public bool ShouldSaveAllFilesWhenVSLosesFocus { get; set; } = true;
    }
}
