using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualStudio.Threading;

namespace DevPace.WPF.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        private Func<bool> _canExecute;
        public Command(Action execute) => _execute = execute;
        public Command(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute.Invoke();

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<T> _execute;
        private Func<T, bool> _canExecute;
        public Command(Action<T> execute) => _execute = execute;
        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => _execute.Invoke((T)parameter);

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public class AsyncCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Func<T, Task> _execute;
        private Func<T, bool> _canExecute;
        public AsyncCommand(Func<T, Task> execute) => _execute = execute;
        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => _execute.Invoke((T)parameter).Forget();

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
