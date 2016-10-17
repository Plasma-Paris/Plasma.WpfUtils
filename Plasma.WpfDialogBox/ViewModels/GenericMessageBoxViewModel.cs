using System.Windows;
using Plasma.WpfFrameWork;

namespace Plasma.WpfDialogBox.ViewModels
{
    public class GenericMessageBoxViewModel : BaseMessageBoxViewModel
    {
        public GenericMessageBoxViewModel()
        {
            YesCommand = new RelayCommand(Yes);
            NoCommand = new RelayCommand(No);
            OkCommand = new RelayCommand(Ok);
            CancelCommand = new RelayCommand(Cancel);
        }
        private bool _ButtonYesIsVisible;
        private bool _ButtonNoIsVisible;
        private bool _ButtonCancelIsVisible;
        private bool _ButtonOKIsVisible;
        public bool ButtonOKIsVisible
        {
            get
            {
                return _ButtonOKIsVisible;
            }
            set
            {
                Set(() => ButtonOKIsVisible, ref _ButtonOKIsVisible, value);
            }
        }
        public bool ButtonCancelIsVisible
        {
            get
            {
                return _ButtonCancelIsVisible;
            }
            set
            {
                Set(() => ButtonCancelIsVisible, ref _ButtonCancelIsVisible, value);
            }
        }
        public bool ButtonYesIsVisible
        {
            get
            {
                return _ButtonYesIsVisible;
            }
            set
            {
                Set(() => ButtonYesIsVisible, ref _ButtonYesIsVisible, value);
            }
        }
        public bool ButtonNoIsVisible
        {
            get
            {
                return _ButtonNoIsVisible;
            }
            set
            {
                Set(() => ButtonNoIsVisible, ref _ButtonNoIsVisible, value);
            }
        }

        public RelayCommand YesCommand { get; private set; }
        public RelayCommand NoCommand { get; private set; }
        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        private void Yes()
        {
            Hide(MessageBoxResult.Yes);
        }
        private void No()
        {
            Hide(MessageBoxResult.No);
        }
        private void Ok()
        {
            Hide(MessageBoxResult.OK);
        }
        private void Cancel()
        {
            Hide(MessageBoxResult.Cancel);
        }
    }
}
