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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poetry.Uploader.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowDialogMessages.UploadPoemMessage>(this, msg => _showUploadPoemDialog());
            Messenger.Default.Register<ShowDialogMessages.CreatePoetMessage>(this, msg => _showCreatePoetDialog());
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister<ShowDialogMessages.UploadPoemMessage>(this);
        }

        private void _showUploadPoemDialog()
        {
            var poemUploadWindow = new PoemUploadWindow();
            ShowDialog(poemUploadWindow);
        }

        private void _showCreatePoetDialog()
        {
            var createPoetWindow = new CreatePoetWindow();
            ShowDialog(createPoetWindow);
        }
    }
}
