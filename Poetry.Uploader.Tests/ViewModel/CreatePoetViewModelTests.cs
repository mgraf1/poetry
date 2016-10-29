using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.ViewModel;
using Poetry.Uploader.Services.WpfHelpers;
using Poetry.Uploader.Services.Api;
using Moq;
using Poetry.DTO.Models;

namespace PoetryTests.ViewModel
{
    [TestClass]
    public class CreatePoetViewModelTests
    {
        private CreatePoetViewModel _viewModel;
        private Mock<IDispatcher> _dispatcherMock;
        private Mock<IPoetService> _poetServiceMock;

        [TestInitialize]
        public void MyTestInitialie()
        {
            _dispatcherMock = new Mock<IDispatcher>();
            _poetServiceMock = new Mock<IPoetService>();

            _viewModel = new CreatePoetViewModel(_poetServiceMock.Object, _dispatcherMock.Object);
        }

        [TestMethod]
        public void AddPoetCommand_PoetToAdd_Null_CanExecute()
        {
            _viewModel.PoetToAdd = null;
            Assert.IsFalse(_viewModel.AddPoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddPoetCommand_PoetToAdd_NotNull_CanExecute()
        {
            _viewModel.PoetToAdd = "hello";
            Assert.IsTrue(_viewModel.AddPoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddPoetCommand_PoetsContain_CanExecute()
        {
            PoetDTO poet = new PoetDTO { Name = "bob" };
            _viewModel.PoetToAdd = "bob";
            _viewModel.Poets.Add(poet);
            Assert.IsFalse(_viewModel.AddPoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddPoetCommand_PoetsNotContain_CanExecute()
        {
            PoetDTO poet = new PoetDTO { Name = "bob" };
            _viewModel.PoetToAdd = "bob2";
            _viewModel.Poets.Add(poet);
            Assert.IsTrue(_viewModel.AddPoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddPoetCommand_CallsPoetService()
        {
            _viewModel.PoetToAdd = "1";
            _viewModel.AddPoetCommand.Execute(null);
            _poetServiceMock.Verify(m => m.AddPoet(It.IsAny<PoetDTO>()), Times.Once);
        }
    }
}
