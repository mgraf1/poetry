using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Poetry.DTO.Models;
using Poetry.Uploader.Services.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Poetry.Uploader.ViewModel
{
    public class CreatePoetViewModel : ViewModelBase
    {
        public ObservableCollection<PoetDTO> Poets { get; set; }
        public bool IsBusy { get; set; }

        public ICommand LoadedCommand
        {
            get
            {
                if (_loadedCommand == null)
                {
                    _loadedCommand = new RelayCommand<object>(c => _loaded());
                }
                return _loadedCommand;
            }
        }

        private IPoetService _poetService;
        private RelayCommand<object> _loadedCommand;

        public CreatePoetViewModel(IPoetService poetService)
        {
            _poetService = poetService;
            Poets = new ObservableCollection<PoetDTO>();
        }

        private void _loaded()
        {
            IsBusy = true;
            _poetService.GetAllPoets()
            .ContinueWith(result =>
            {
                var poets = result.Result;
                if (!result.IsFaulted)
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        foreach (var poet in poets)
                        {
                            Poets.Add(poet);
                        }
                        IsBusy = false;
                    }));
                }
            });
        }
    }
}
