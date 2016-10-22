using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.ViewModel;
using Moq;
using Poetry.Uploader.View;
using Poetry.Uploader.Services;
using Poetry.Uploader.PoetryGeneration;
using System.Resources;
using Poetry.Uploader.Resources;
using GalaSoft.MvvmLight.Messaging;
using Poetry.Uploader.Services.Messages;

namespace PoetryTests
{
    [TestClass]
    public class MainViewModelTests
    {
        private MainViewModel viewModel;
        private Mock<IPoetryParser> poetryParserMock;

        [TestInitialize]
        public void MyTestInitialize()
        {
            poetryParserMock = new Mock<IPoetryParser>();
            viewModel = new MainViewModel(poetryParserMock.Object);
        }

        [TestMethod]
        public void ExitCommand_DialogResult()
        {
            Mock<IWindow> windowMock = new Mock<IWindow>();
            viewModel.ExitCommand.Execute(windowMock.Object);

            windowMock.Verify(w => w.Close(), Times.Once);
        }

        [TestMethod]
        public void LoadPoetryCommand_CanExecute_GramSize0()
        {
            viewModel.GramSize = 0;

            Assert.IsFalse(viewModel.LoadPoetryCommand.CanExecute(null));
        }

        [TestMethod]
        public void Validation_GramSize()
        {
            viewModel.GramSize = 0;

            Assert.AreEqual(ValidationConstants.MainViewModel_GramSize_Err,
                viewModel[nameof(viewModel.GramSize)]);
        }

        [TestMethod]
        public void LoadPoetryCommand_MessageSent()
        {
            bool messageReceived = false;
            Messenger.Default.Register<ShowDialogMessages.UploadPoemMessage>(this,
                msg =>
                {
                    Assert.IsNotNull(msg);
                    Messenger.Default.Unregister<ShowDialogMessages.UploadPoemMessage>(this);
                    messageReceived = true;
                });
            viewModel.GramSize = 2;
            viewModel.LoadPoetryCommand.Execute(null);
            Assert.IsTrue(messageReceived);
        }

        [TestMethod]
        public void CreatePoetCommand_MessageSent()
        {
            bool messageReceived = false;
            Messenger.Default.Register<ShowDialogMessages.CreatePoetMessage>(this,
                msg =>
                {
                    Assert.IsNotNull(msg);
                    Messenger.Default.Unregister<ShowDialogMessages.CreatePoetMessage>(this);
                    messageReceived = true;
                });
            viewModel.GramSize = 2;
            viewModel.CreatePoetCommand.Execute(null);
            Assert.IsTrue(messageReceived);
        }

        [TestMethod]
        public void CreatePoetCommand_GrameSizeNotSet_CanExecute()
        {
            viewModel.GramSize = 0;
            Assert.IsTrue(viewModel.CreatePoetCommand.CanExecute(null));
        }
    }
}
