using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Poetry.DTO.Models;
using Poetry.Uploader.Resources;
using Poetry.Uploader.Services.Api;
using Poetry.Uploader.Services.WpfHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Poetry.Uploader.ViewModel
{
    public class CreatePoetViewModel : ViewModelBase, IDataErrorInfo
    {
        public ObservableCollection<PoetDTO> Poets { get; set; }
        public bool IsBusy { get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
        public string PoetToAdd
        { get { return _poetToAdd; }
            set
            {
                _poetToAdd = value;
                RaisePropertyChanged(nameof(PoetToAdd));
                ((RelayCommand<object>)AddPoetCommand).RaiseCanExecuteChanged();
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
        public ICommand AddPoetCommand
        {
            get
            {
                if (_addPoetCommand == null)
                {
                    _addPoetCommand = new RelayCommand<object>(_addPoet, _isAddPoetValid);
                }
                return _addPoetCommand;
            }
        }

        public string Error
        {
            get
            {
                return _error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string errMessage = null;

                switch (columnName)
                {
                    case nameof(Poets):
                        foreach(var poet in Poets)
                        {
                            var found = Poets.FirstOrDefault(p => p.Name == poet.Name) != null;
                            if (found)
                            {
                                errMessage = ValidationConstants.CreatePoetViewModel_DuplicatePoetErr;
                                break;
                            }
                        }
                        break;
                }

                return errMessage;
            }
        }

        private IPoetService _poetService;
        private IDispatcher _dispatcher;
        private RelayCommand<object> _loadedCommand;
        private RelayCommand<object> _addPoetCommand;
        private bool _isBusy;
        private string _poetToAdd;
        private string _error;

        public CreatePoetViewModel(IPoetService poetService, IDispatcher dispatcher)
        {
            _poetService = poetService;
            _dispatcher = dispatcher;
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
            catch (Exception)
            {
                _error = ValidationConstants.CreatePoetViewModel_FailedLoad;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void _addPoet(object obj)
        {
            IsBusy = true;
            try
            {
                var poet = await _poetService.AddPoet(new PoetDTO
                {
                    Name = PoetToAdd
                });
                Poets.Add(poet);
            }
            catch (Exception)
            {
                _error = ValidationConstants.CreatePoetViewModel_FailedAddPoet;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isAddPoetValid(object obj)
        {
            return !string.IsNullOrEmpty(PoetToAdd) && Poets.FirstOrDefault(pp => pp.Name == PoetToAdd) == null;
        }
    }
}
