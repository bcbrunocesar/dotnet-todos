using System;
using Todo.Domain.Commands.Contracts.Todo;

namespace Todo.Tests.Fixtures.Commands
{
    public class CreateTodoCommandFixture
    {
        public const string VALIDO = "VALIDO";
        public const string INVALIDO = "INVALIDO";

        public static CreateTodoCommand Gimme(string type) =>
            type switch
            {
                VALIDO => CreateTodoCommand.Builder()
                        .SetTitle("Teste")
                        .SetUser("Usuario")
                        .SetDate(new DateTime())
                        .Build(),
                INVALIDO => CreateTodoCommand.Builder()
                        .SetTitle("")
                        .SetUser("")
                        .Build(),
                _ => CreateTodoCommand.Builder()
                        .SetTitle("Teste")
                        .SetUser("Usuario")
                        .SetDate(new DateTime())
                        .Build()
            };
    }
}