using System;
using System.Windows;
using Plasma.WpfFrameWork;

namespace Plasma.WpfDialogBox.ViewModels
{
    public class BaseMessageBoxViewModel : ViewModelBase
    {
        public BaseMessageBoxViewModel()
        {
            HideCommand = new RelayCommand(Hide);
        }

        private bool _IsModal;
        private string _MessageBox;
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                Set(() => Title, ref _Title, value);
                _Title = value;
            }
        }
        public string MessageBox
        {
            get
            {
                return _MessageBox;
            }
            set
            {
                Set(() => MessageBox, ref _MessageBox, value);
            }
        }
        
        public bool IsModal
        {
            get
            {
                return _IsModal;
            }
            set
            {
                Set(() => IsModal, ref _IsModal, value);
            }
        }

        public event EventHandler<MessageBoxHideEventArgs> OnHideRequest = delegate { };

        public RelayCommand HideCommand
        {
            get; private set;
        }

        public virtual void Hide(MessageBoxResult result)
        {
            OnHideRequest(this, new MessageBoxHideEventArgs(result));
        }

        public virtual void Hide()
        {
            Hide(MessageBoxResult.None);
        }
    }
}
