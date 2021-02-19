using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands.Contracts.Todo;
using Todo.Tests.Fixtures.Commands;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [TestMethod]
        public void DADO_um_comando_invalido_DEVE_falhar()
        {
            CreateTodoCommand createTodoCommand = CreateTodoCommandFixture.Gimme(CreateTodoCommandFixture.INVALIDO);
            Assert.AreEqual(createTodoCommand.Valid, false);
        }

        [TestMethod]
        public void DADO_um_comando_valido_DEVE_passar()
        {
            CreateTodoCommand createTodoCommand = CreateTodoCommandFixture.Gimme(CreateTodoCommandFixture.VALIDO);
            Assert.AreEqual(createTodoCommand.Valid, true);
        }
    }
}