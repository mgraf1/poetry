using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Poetry.Uploader.View
{
    public class WindowBase : Window, IWindow
    {
        public WindowBase()
        {
            Messenger.Default.Register<ShowDialogMessages.SelectFileMessage>(this, m =>
            {
                var fileDialog = new Microsoft.Win32.OpenFileDialog()
                {
                    Multiselect = false,
                    Filter = "TXT Files (*.txt)|*.txt"
                };

                var result = fileDialog.ShowDialog();

                var resultMessage = new SelectFileResultMessage(result, fileDialog.FileName);

                Messenger.Default.Send<SelectFileResultMessage>(resultMessage);
            });

            Closing += WindowBase_OnClosing;
        }

        private void WindowBase_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister<ShowDialogMessages.SelectFileMessage>(this);
            Closing -= WindowBase_OnClosing;
        }

        protected bool ShowDialog(Window window)
        {
            window.Owner = this;
            bool? result = window.ShowDialog();

            return result.HasValue && result.Value;
        }
    }
}
