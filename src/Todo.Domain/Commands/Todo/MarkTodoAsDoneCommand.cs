using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shared.Commands.Contracts;

namespace Todo.Domain.Commands.Todo
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand() { }

        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            Contract contract = new Contract()
                .Requires()
                .HasMinLen(User, 6, "User", "Usuário inválido!");

            AddNotifications(contract);
        }
    }
}