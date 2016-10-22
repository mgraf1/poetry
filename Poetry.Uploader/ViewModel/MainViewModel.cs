using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Poetry.Uploader.PoetryGeneration;
using Poetry.Uploader.Services;
using System.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Poetry.Uploader.Resources;
using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;
using Poetry.Uploader.Services.Api;

namespace Poetry.Uploader.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {   
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand<View.IWindow>(w => w.Close());
                }
                return _exitCommand;
            }
        }

        public ICommand LoadPoetryCommand
        {
            get
            {
                if (_loadPoetryCommand == null)
                {
                    _loadPoetryCommand = new RelayCommand<object>(x => _loadPoetry(),
                        x => GramSize >= GramSizeSource.First());
                }
                return _loadPoetryCommand;
            }
        }

        public ICommand CreatePoetCommand
        {
            get
            {
                if (_createPoetCommand == null)
                {
                    _createPoetCommand = new RelayCommand<object>(x => _createPoet());
                }
                return _createPoetCommand;
            }
        }

        public int GramSize { get; set; }
        public IEnumerable<int> GramSizeSource
        {
            get
            {
                if (_gramSizeSource == null)
                {
                    _gramSizeSource = new List<int> { 2, 3, 4 };
                }
                return _gramSizeSource;
            }      
        }

        #region Validation

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessage = null;
                switch (columnName)
                {
                    case nameof(GramSize):
                        if (GramSize < GramSizeSource.First())
                        {
                            errorMessage = ValidationConstants.MainViewModel_GramSize_Err;
                        }
                        
                        break;
                }

                return errorMessage;
            }
        }

        #endregion

        private RelayCommand<View.IWindow> _exitCommand;
        private RelayCommand<object> _loadPoetryCommand;
        private RelayCommand<object> _createPoetCommand;
        private IPoetryParser _poetryParser;
        private List<int> _gramSizeSource;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IPoetryParser poetryParser)
        {
            _poetryParser = poetryParser;
        }

        private void _loadPoetry()
        {
            Messenger.Default.Send<ShowDialogMessages.UploadPoemMessage>(new ShowDialogMessages.UploadPoemMessage()); 
        }

        private void _createPoet()
        {
            Messenger.Default.Send<ShowDialogMessages.CreatePoetMessage>(new ShowDialogMessages.CreatePoetMessage());
        }
    }
}