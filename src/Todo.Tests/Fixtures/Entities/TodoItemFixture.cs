using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Tests.Fixtures.Entities
{
    public class TodoItemFixture
    {
        public const string VALIDO = "VALIDO";

        public static TodoItem Gimme(string type) =>
            type switch
            {
                VALIDO => TodoItem.Builder()
                            .SetTitle("Teste")
                            .SetUser("Usuario")
                            .SetDate(DateTime.Now)
                            .Build(),
                _ => new TodoItem("Teste", "Usuario", DateTime.Now)
            };

        public static List<TodoItem> GimmeList(string type) =>
            type switch
            {
                VALIDO => new List<TodoItem>() {
                    TodoItem.Builder()
                            .SetTitle("Estudar dotnet")
                            .SetUser("Usuario 1")
                            .SetDate(DateTime.Now)
                            .Build(),
                       TodoItem.Builder()
                            .SetTitle("Estudar nodejs")
                            .SetUser("Usuario 2")
                            .SetDate(DateTime.Now)
                            .Build(),
                        TodoItem.Builder()
                            .SetTitle("Estudar angular")
                            .SetUser("Usuario 1")
                            .SetDate(DateTime.Now)
                            .Build(),
                        TodoItem.Builder()
                            .SetTitle("Estudar java")
                            .SetUser("Usuario 1")
                            .SetDate(DateTime.Now)
                            .Build()
                },
                _ => default
            };
    }
}