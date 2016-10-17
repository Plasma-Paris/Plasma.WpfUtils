using System;
using System.Windows.Input;

namespace Plasma.WpfFrameWork
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute) : this(execute, null)
        {
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = new Action(execute);

            if (canExecute != null)
                _canExecute = new Func<bool>(canExecute);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }
        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter) && _execute != null)
                _execute();
        }
    }
}
