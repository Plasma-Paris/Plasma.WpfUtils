using Plasma.WpfDialogBox.ViewModels;
using Plasma.WpfFrameWork;

namespace Plasma.WpfDialogBox.Example
{
    public class MainViewModel : ViewModelBase
    {
        MessageBoxService _Service;
        public MainViewModel()
        {
            var defaultMessageBoxViewModel = new GenericMessageBoxViewModel();
            
            _Service = new MessageBoxService(defaultMessageBoxViewModel);

            _Service.OnShowRequestStarted += (s, e) => CurrentMessageBox = e.ViewModel;
            _Service.OnHideRequestEnded += (s, e) => CurrentMessageBox = null;

            YesNoMessageBoxCommand = new RelayCommand(YesNoMessageBox);
        }

        private MessageBoxContainerViewModel _CurrentMessageBox;
        public MessageBoxContainerViewModel CurrentMessageBox
        {
            get
            {
                return _CurrentMessageBox;
            }
            set
            {
                Set(() => CurrentMessageBox, ref _CurrentMessageBox, value);
            }
        }

        public RelayCommand YesNoMessageBoxCommand { get; private set; }

        async void YesNoMessageBox()
        {
            var result = await _Service.ShowMessage("This is the content of the message box","This is the title",System.Windows.MessageBoxButton.YesNo);
            if (result == System.Windows.MessageBoxResult.Yes)
                await _Service.ShowMessage("User chosse Yes !");
            if (result == System.Windows.MessageBoxResult.No)
                await _Service.ShowMessage("User chosse No !");
        }
    }
}