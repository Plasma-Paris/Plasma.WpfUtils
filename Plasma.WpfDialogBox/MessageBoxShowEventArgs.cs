using System;
using Plasma.WpfDialogBox.ViewModels;

namespace Plasma.WpfDialogBox
{
    public class MessageBoxShowEventArgs : EventArgs
    {

        public MessageBoxShowEventArgs(MessageBoxContainerViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public MessageBoxContainerViewModel ViewModel { get; set; }
    }
}
