using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Plasma.WpfDialogBox.DialogIOForms
{
    public class DialogIO
    {
        protected readonly CommonFileDialog _DialogIO;
        protected DialogIO(CommonFileDialog dialog)
        {
            _DialogIO = dialog;
        }
        public virtual MessageBoxResult ShowDialog()
        {
            var result = _DialogIO.ShowDialog();

            switch (result)
            {
                case CommonFileDialogResult.Ok:
                    return MessageBoxResult.OK;
                case CommonFileDialogResult.Cancel:
                    return MessageBoxResult.Cancel;
                case CommonFileDialogResult.None:
                default:
                    return MessageBoxResult.None;
            }
        }
        }
}
