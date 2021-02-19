using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Todo.Domain.Commands.Contracts.Todo;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Shared.Commands.Commons;
using Todo.Domain.Shared.Logging;
using Todo.Tests.Fixtures.Commands;

namespace Todo.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private TodoHandler _todoHandler;
        private Mock<ILog<TodoItem>> _logMock;
        private Mock<ITodoRepository> _todoRepositoryMock;

        public CreateTodoHandlerTests()
        {
            _logMock = new Mock<ILog<TodoItem>>();
            _todoRepositoryMock = new Mock<ITodoRepository>();

            _todoHandler = new TodoHandler(_todoRepositoryMock.Object, _logMock.Object);
        }

        [TestMethod]
        public void DADO_comando_invalido_DEVE_interromper_a_execucao()
        {
            CreateTodoCommand createTodoCommand = CreateTodoCommandFixture.Gimme(CreateTodoCommandFixture.INVALIDO);
            GenericCommandResult genericCommandResult = (GenericCommandResult)_todoHandler.Handle(createTodoCommand);

            Assert.AreEqual(genericCommandResult.Success, false);
        }

        [TestMethod]
        public void DADO_comando_valido_DEVE_criar_a_tarefa()
        {
            CreateTodoCommand createTodoCommand = CreateTodoCommandFixture.Gimme(CreateTodoCommandFixture.VALIDO);
            GenericCommandResult genericCommandResult = (GenericCommandResult)_todoHandler.Handle(createTodoCommand);

            Assert.AreEqual(genericCommandResult.Success, true);
        }
    }
}