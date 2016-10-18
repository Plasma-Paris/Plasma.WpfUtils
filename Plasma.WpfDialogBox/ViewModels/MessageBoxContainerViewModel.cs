using Plasma.WpfFrameWork;

namespace Plasma.WpfDialogBox.ViewModels
{
    public class MessageBoxContainerViewModel : ViewModelBase
    {
        public MessageBoxContainerViewModel(BaseMessageBoxViewModel messageBoxViewModel)
        {
            CurrentMessageBoxContent = messageBoxViewModel;
            IsModal = CurrentMessageBoxContent.IsModal;
        }
        BaseMessageBoxViewModel _CurrentMessageBoxContent;
        public BaseMessageBoxViewModel CurrentMessageBoxContent
        {
            get
            {
                return _CurrentMessageBoxContent;
            }
            private set
            {
                Set(() => CurrentMessageBoxContent, ref _CurrentMessageBoxContent, value);
            }
        }

        public bool IsModal { get; private set; } 
    }
}
