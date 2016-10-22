using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Poetry.Uploader.View
{
    /// <summary>
    /// Interaction logic for PoemUploadWindow.xaml
    /// </summary>
    public partial class PoemUploadWindow : WindowBase
    {
        public PoemUploadWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowDialogMessages.PoetSelectionMessage>(this, msg => _showPoetSelectionDialog());
        }

        private void _showPoetSelectionDialog()
        {
            var poetSelectionWindow = new PoetSelectionWindow();
            ShowDialog(poetSelectionWindow);
        }

        private void poemUploadWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister<ShowDialogMessages.PoetSelectionMessage>(this);
        }
    }
}
