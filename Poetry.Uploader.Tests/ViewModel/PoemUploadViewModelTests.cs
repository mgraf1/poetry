using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;

namespace PoetryTests.ViewModel
{
    [TestClass]
    public class PoemUploadViewModelTests
    {
        private PoemUploadViewModel viewModel;

        [TestInitialize]
        public void MyTestInitialize()
        {
            viewModel = new PoemUploadViewModel();
        }

        [TestMethod]
        public void SelectPoetCommand_MessageSent()
        {
            bool messageReceived = false;
            Messenger.Default.Register<ShowDialogMessages.PoetSelectionMessage>(this, 
                msg =>
                {
                    Assert.IsNotNull(msg);
                    Messenger.Default.Unregister<ShowDialogMessages.PoetSelectionMessage>(this);
                    messageReceived = true;
                });
            viewModel.SelectPoetCommand.Execute(null);
            Assert.IsTrue(messageReceived);
        }
    }
}
