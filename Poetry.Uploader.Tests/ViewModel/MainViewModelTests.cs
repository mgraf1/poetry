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
using PoetryTests.Helpers;

namespace PoetryTests
{
    [TestClass]
    public class MainViewModelTests
    {
        private MainViewModel _viewModel;
        private Mock<IPoetryParser> _poetryParserMock;
        private MessageHelper _messageHelper;

        [TestInitialize]
        public void MyTestInitialize()
        {
            _poetryParserMock = new Mock<IPoetryParser>();
            _viewModel = new MainViewModel(_poetryParserMock.Object);
            _messageHelper = new MessageHelper();
        }

        [TestMethod]
        public void ExitCommand_DialogResult()
        {
            Mock<IWindow> windowMock = new Mock<IWindow>();
            _viewModel.ExitCommand.Execute(windowMock.Object);

            windowMock.Verify(w => w.Close(), Times.Once);
        }
    }
}
