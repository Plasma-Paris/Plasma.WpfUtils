
namespace Plasma.WpfDialogBox.DialogIOForms
{
    public class DialogIOFactory : IDialogIOFactory
    {
        public ChooseDirectoryDialog CreateChooseDirectoryDialog()
        {
            return new ChooseDirectoryDialog();
        }

        public OpenFileDialog CreateOpenFileDialog(string defaultExtension = null, string defaultFilterDisplayName = null, string defaultFilterExtension = null)
        {
            return new OpenFileDialog(defaultExtension, defaultFilterDisplayName, defaultFilterExtension);
        }
    }
}
