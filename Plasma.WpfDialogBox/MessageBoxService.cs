using System;
using System.Threading.Tasks;
using System.Windows;
using Plasma.WpfDialogBox.ViewModels;

namespace Plasma.WpfDialogBox
{
    public interface IMessageBoxService
    {
        Task<MessageBoxResult> ShowMessage(string messageBoxText, string title = null, MessageBoxButton button = MessageBoxButton.OK);
        Task<MessageBoxResult> ShowCustomMessageBox<T>(T messageBoxViewModel)
            where T : BaseMessageBoxViewModel;
        event EventHandler<MessageBoxShowEventArgs> OnShowRequestStarted;
        event EventHandler<MessageBoxHideEventArgs> OnHideRequestEnded;
    }

    public class MessageBoxService : IMessageBoxService
    {
        private readonly GenericMessageBoxViewModel _GenericMessageBoxViewModel;

        public MessageBoxService(GenericMessageBoxViewModel genericMessageBoxViewModel)
        {
            _GenericMessageBoxViewModel = genericMessageBoxViewModel;
        }
        
        public async Task<MessageBoxResult> ShowMessage(string messageBoxText, string title = null, MessageBoxButton button = MessageBoxButton.OK)
        {
            _GenericMessageBoxViewModel.IsModal = true;

            _GenericMessageBoxViewModel.Title = title;
            _GenericMessageBoxViewModel.MessageBox = messageBoxText;

            _GenericMessageBoxViewModel.ButtonOKIsVisible = false;
            _GenericMessageBoxViewModel.ButtonYesIsVisible = false;
            _GenericMessageBoxViewModel.ButtonNoIsVisible = false;
            _GenericMessageBoxViewModel.ButtonCancelIsVisible = false;
            
            switch (button)
            {
                case MessageBoxButton.OK:
                    _GenericMessageBoxViewModel.ButtonOKIsVisible = true;
                    break;
                case MessageBoxButton.OKCancel:
                    _GenericMessageBoxViewModel.ButtonOKIsVisible = true;
                    _GenericMessageBoxViewModel.ButtonCancelIsVisible = true;
                    break;
                case MessageBoxButton.YesNoCancel:
                    _GenericMessageBoxViewModel.ButtonYesIsVisible = true;
                    _GenericMessageBoxViewModel.ButtonNoIsVisible = true;
                    _GenericMessageBoxViewModel.ButtonCancelIsVisible = true;
                    break;
                case MessageBoxButton.YesNo:
                    _GenericMessageBoxViewModel.ButtonYesIsVisible = true;
                    _GenericMessageBoxViewModel.ButtonNoIsVisible = true;
                    break;
                default:
                    throw new ArgumentException($"La valeur de l'enum {nameof(MessageBoxButton)} {button} n'est pas supportée.");
            }

            return await ShowCustomMessageBox(_GenericMessageBoxViewModel); 
        }
        public async Task<MessageBoxResult> ShowCustomMessageBox<T>(T messageBoxViewModel) where T : BaseMessageBoxViewModel
        {
            if (messageBoxViewModel == null)
                return MessageBoxResult.None;

            var messageBoxContainerViewModel = new MessageBoxContainerViewModel(messageBoxViewModel);

            //if (messageBoxViewModel.InWindow)
            //{
            //    Window _window = new Window();
            //    _window.Owner = Application.Current.MainWindow;
            //    _window.Title = messageBoxViewModel.Title;
            //    ContentControl contentControl = new ContentControl()
            //    {
            //        Content = messageBoxContainerViewModel,
            //        Resources = Application.Current.MainWindow.Resources
            //    };
            //    _window.Content = contentControl;
            //    // TODO : _window.Height, _window.Height

            //    _window.ShowDialog();

            //    return MessageBoxResult.None; // TODO
            //}

            messageBoxViewModel.OnHideRequest += ViewModel_OnHideRequest;

            var eventListener = new AsyncMessageBoxHideEventListener();
            OnHideRequestEnded += eventListener.Listen;

            OnShowRequestStarted(this, new MessageBoxShowEventArgs(messageBoxContainerViewModel));

            var result = await eventListener.Successfully;
            OnHideRequestEnded -= eventListener.Listen;
            messageBoxViewModel.OnHideRequest -= ViewModel_OnHideRequest;
            return result;
        }

        public event EventHandler<MessageBoxShowEventArgs> OnShowRequestStarted = delegate { };
        public event EventHandler<MessageBoxHideEventArgs> OnHideRequestEnded = delegate { };
        private void ViewModel_OnHideRequest(object sender, MessageBoxHideEventArgs e)
        {
            OnHideRequestEnded(this, new MessageBoxHideEventArgs(e.MessageBoxResult));
        }

    }
}

// TODO: Multi message box
// TODO: Window