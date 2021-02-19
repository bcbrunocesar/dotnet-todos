using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Tests.Fixtures.Entities;

namespace Todo.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTest
    {
        [TestMethod]
        public void DADO_uma_nova_tarefa_o_status_DEVE_ser_false()
        {
            TodoItem todoItem = TodoItemFixture.Gimme(TodoItemFixture.VALIDO);
            Assert.AreEqual(todoItem.Done, false);
        }

        [TestMethod]
        public void DADO_preenchimento_por_metodos_builders_a_entidade_DEVE_ser_alterada()
        {
            DateTime todoDate = new DateTime(2021, 2, 16);
            TodoItem todoItem = TodoItem.Builder()
                .SetTitle("Titulo")
                .SetUser("Usuario")
                .SetDate(todoDate)
                .Build();

            Assert.AreEqual(todoItem.Title, "Titulo");
            Assert.AreEqual(todoItem.User, "Usuario");
            Assert.AreEqual(todoItem.Date, todoDate);
        }
    }
}