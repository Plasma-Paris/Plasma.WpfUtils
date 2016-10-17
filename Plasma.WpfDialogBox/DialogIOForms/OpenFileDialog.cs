using Microsoft.WindowsAPICodePack.Dialogs;

namespace Plasma.WpfDialogBox.DialogIOForms
{
    public class OpenFileDialog : DialogIO
    {
        public OpenFileDialog(string defaultExtension, string defaultFilterDisplayName, string defaultFilterExtension)
            : base(new CommonOpenFileDialog())
        {
            _DialogIO.DefaultExtension = defaultExtension;
            _DialogIO.Filters.Add(new CommonFileDialogFilter(defaultFilterDisplayName, defaultFilterExtension));
        }
        public string FileName { get { return _DialogIO.FileName; } }
    }
}
