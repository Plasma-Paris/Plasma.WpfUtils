using System;
using System.Windows;

namespace Plasma.WpfDialogBox
{
    public class MessageBoxHideEventArgs : EventArgs
    {
        public MessageBoxHideEventArgs(MessageBoxResult messageBoxResult)
        {
            MessageBoxResult = messageBoxResult;
        }
        public MessageBoxResult MessageBoxResult { get; private set; }
    }
}