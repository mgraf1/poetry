/*
 * Async commands from Stephen Cleary https://msdn.microsoft.com/en-us/magazine/dn630647.aspx
 */
namespace Poetry.Uploader.ViewModel.Commands.Async
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public abstract bool CanExecute(object parameter);

        public abstract Task ExecuteAsync(object parameter);

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}