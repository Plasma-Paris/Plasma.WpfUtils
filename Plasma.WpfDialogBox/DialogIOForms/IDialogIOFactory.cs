
namespace Plasma.WpfDialogBox.DialogIOForms
{
    public interface IDialogIOFactory
    {
        ChooseDirectoryDialog CreateChooseDirectoryDialog();
        OpenFileDialog CreateOpenFileDialog(string defaultExtension = null, string defaultFilterDisplayName = null, string defaultFilterExtension = null);
    }
}
