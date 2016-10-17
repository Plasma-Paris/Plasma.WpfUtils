using Microsoft.WindowsAPICodePack.Dialogs;

namespace Plasma.WpfDialogBox.DialogIOForms
{
    public class ChooseDirectoryDialog : DialogIO
    {
        public string DirectoryName { get { return _DialogIO.FileName; } }

        public ChooseDirectoryDialog()
            : base(new CommonOpenFileDialog())
        {
            ((CommonOpenFileDialog)_DialogIO).IsFolderPicker = true;
        }
    }
}
