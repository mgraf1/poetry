using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.ViewModel;
using Poetry.Uploader.Services.Messages;
using Poetry.Uploader.Services.Api;
using Moq;
using PoetryTests.Helpers;

namespace PoetryTests.ViewModel
{
    [TestClass]
    public class PoemUploadViewModelTests
    {
        private PoemUploadViewModel _viewModel;
        private Mock<IPoetService> _poetServiceMock;
        private MessageHelper _messageHelper;

        [TestInitialize]
        public void MyTestInitialize()
        {
            _poetServiceMock = new Mock<IPoetService>();
            _viewModel = new PoemUploadViewModel(_poetServiceMock.Object);
            _messageHelper = new MessageHelper();
        }

        [TestMethod]
        public void SelectFileCommand_SendMessage()
        {
            _messageHelper.TestMessageReceived<ShowDialogMessages.SelectFileMessage>();
            _viewModel.SelectFileCommand.Execute(null);
            Assert.IsTrue(_messageHelper.WasMessageReceived());
        }
    }
}
