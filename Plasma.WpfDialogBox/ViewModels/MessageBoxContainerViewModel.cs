namespace Plasma.WpfDialogBox.ViewModels
{
    public class MessageBoxContainerViewModel
    {
        public MessageBoxContainerViewModel(BaseMessageBoxViewModel messageBoxViewModel)
        {
            CurrentMessageBoxContent = messageBoxViewModel;
            IsModal = CurrentMessageBoxContent.IsModal;
        }
        public BaseMessageBoxViewModel CurrentMessageBoxContent { get; private set; }

        public bool IsModal { get; private set; } 
    }
}
