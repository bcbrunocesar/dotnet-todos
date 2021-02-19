using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Tests.Fixtures.Entities;

namespace Todo.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        [TestMethod]
        public void DADO_consulta_DEVE_retornar_apenas_tarefas_do_usuario()
        {
            List<TodoItem> todoItems = TodoItemFixture.GimmeList(TodoItemFixture.VALIDO);
            IQueryable<TodoItem> todoItemsResult = todoItems.AsQueryable().Where(TodoQueries.GetAll("Usuario 1"));

            Assert.AreEqual(3, todoItemsResult.Count());
        }
    }
}