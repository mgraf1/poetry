using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.ViewModel;
using Poetry.Uploader.Services.WpfHelpers;
using Poetry.Uploader.Services.Api;
using Moq;
using Poetry.DTO.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            _viewModel.PoetToAdd = "bob";
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
            Assert.IsTrue(_viewModel.AddPoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddPoetCommand_PoetsContain_CanExecute()
        {
            PoetDTO poet = new PoetDTO { Name = "bob" };
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
            _viewModel.AddPoetCommand.Execute(null);
            _poetServiceMock.Verify(m => m.AddPoet(It.IsAny<PoetDTO>()), Times.Once);
        }

        [TestMethod]
        public void DeletePoetCommand_SelectedPoetNull_CanExecute()
        {
            _viewModel.SelectedPoet = null;
            Assert.IsFalse(_viewModel.DeletePoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeletePoetCommand_SelectedPoetNotNull_CanExecute()
        {
            _viewModel.SelectedPoet = new PoetDTO();
            Assert.IsTrue(_viewModel.DeletePoetCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeletePoetCommand_CallPoetService()
        {
            PoetDTO poet = new PoetDTO { Id = 3 };
            _viewModel.Poets.Add(poet);
            _viewModel.SelectedPoet = poet;

            _viewModel.DeletePoetCommand.Execute(null);

            _poetServiceMock.Verify(p => p.DeletePoet(poet.Id));
        }

        [TestMethod]
        public void DeletePoetCommand_PoetRemoved()
        {
            PoetDTO poet = new PoetDTO { Id = 4 };
            _viewModel.Poets.Add(poet);
            _viewModel.SelectedPoet = poet;
            _poetServiceMock.Setup(p => p.DeletePoet(poet.Id))
                .Returns(Task.FromResult(poet));

            _viewModel.DeletePoetCommand.Execute(null);

            Assert.AreEqual(0, _viewModel.Poets.Count);
        }

        [TestMethod]
        public void LoadedCommand_CantLoadTwice()
        {
            IEnumerable<PoetDTO> dtoList = new List<PoetDTO> { new PoetDTO { Name = "Bob" } };
            _poetServiceMock.Setup(m => m.GetAllPoets())
                .ReturnsAsync(dtoList);
            _viewModel.LoadedCommand.ExecuteAsync(null).Wait();
            _viewModel.LoadedCommand.ExecuteAsync(null).Wait();
            Assert.AreEqual(1, _viewModel.Poets.Count);
        }
    }
}
