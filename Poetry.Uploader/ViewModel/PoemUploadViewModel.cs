using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poetry.Uploader.ViewModel
{
    public class PoemUploadViewModel : ViewModelBase, IDataErrorInfo
    {
        public ICommand SelectPoetCommand
        {
            get
            {
                if (_selectPoetCommand == null)
                {
                    _selectPoetCommand = new RelayCommand<object>(c => _selectPoet());
                }
                return _selectPoetCommand;
            }
        }
        #region Validation
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
        #endregion

        private RelayCommand<object> _selectPoetCommand;

        private void _selectPoet()
        {
            Messenger.Default.Send<ShowDialogMessages.PoetSelectionMessage>(new ShowDialogMessages.PoetSelectionMessage());
        }
    }
}
