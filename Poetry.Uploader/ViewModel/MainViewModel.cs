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
    public class MainViewModel : ViewModelBase
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

        private RelayCommand<View.IWindow> _exitCommand;
        private IPoetryParser _poetryParser;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IPoetryParser poetryParser)
        {
            _poetryParser = poetryParser;
        }
    }
}