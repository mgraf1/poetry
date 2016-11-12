using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Poetry.DTO.Models;
using Poetry.Uploader.Resources;
using Poetry.Uploader.Services.Api;
using Poetry.Uploader.Services.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poetry.Uploader.ViewModel
{
    public class PoemUploadViewModel : ViewModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                if (_loadedCommand == null)
                {
                    _loadedCommand = new RelayCommand<object>(_loaded);
                }
                return _loadedCommand;
            }
        }
        public ICommand SelectFileCommand
        {
            get
            {
                if (_selectFileCommand == null)
                {
                    _selectFileCommand = new RelayCommand<object>(_selectFile);
                }
                return _selectFileCommand;
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        public ObservableCollection<PoetDTO> Poets { get; set; }

        private RelayCommand<object> _loadedCommand;
        private RelayCommand<object> _selectFileCommand;
        private IPoetService _poetService;
        private bool _isBusy;
        private string _error;

        public PoemUploadViewModel(IPoetService poetService)
        {
            _poetService = poetService;
            _isBusy = true;
            Poets = new ObservableCollection<PoetDTO>();
        }

        private async void _loaded(object obj)
        {
            try
            {
                var poets = await _poetService.GetAllPoets();
                foreach (var poet in poets)
                {
                    Poets.Add(poet);
                }
            }
            catch(Exception)
            {
                _error = ValidationConstants.CreatePoetViewModel_FailedAddPoet;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void _selectFile(object obj)
        {
            Messenger.Default.Send<ShowDialogMessages.SelectFileMessage>(new ShowDialogMessages.SelectFileMessage());
        }
    }
}
