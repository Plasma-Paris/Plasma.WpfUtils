using System;
using System.Threading.Tasks;
using System.Windows;

namespace Plasma.WpfDialogBox
{
    public class AsyncMessageBoxHideEventListener : IDisposable
    {
        private MessageBoxHideEventArgs _EventArgs;
        public AsyncMessageBoxHideEventListener()
        {
            Successfully = new Task<MessageBoxResult>(() => _EventArgs.MessageBoxResult);
        }

        public void Listen(object sender, MessageBoxHideEventArgs eventArgs)
        {
            _EventArgs = eventArgs;

            if (!Successfully.IsCompleted)
                Successfully.RunSynchronously();
        }

        public Task<MessageBoxResult> Successfully { get; private set; }
        public void Dispose()
        {
            if (Successfully != null)
            {
                Successfully.Dispose();
                Successfully = null;
            }
        }
    }
}
