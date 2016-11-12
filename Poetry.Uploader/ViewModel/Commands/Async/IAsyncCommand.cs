/*
 * Async commands from Stephen Cleary https://msdn.microsoft.com/en-us/magazine/dn630647.aspx
 */
namespace Poetry.Uploader.ViewModel.Commands.Async
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}