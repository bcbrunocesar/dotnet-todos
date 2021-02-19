using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shared.Commands.Contracts;

namespace Todo.Domain.Commands.Contracts.Todo
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        private CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            Contract contract = new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Campo título inválido!")
                .HasMinLen(User, 6, "User", "Usuário inválido!");

            AddNotifications(contract);
        }

        #region Deconstruct

        public void Deconstruct(out string title, out string user, out DateTime date)
        {
            title = Title;
            user = User;
            date = Date;
        }

        #endregion

        #region Builder

        public static CreateTodoCommand Builder() => new CreateTodoCommand();

        public CreateTodoCommand SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public CreateTodoCommand SetUser(string user)
        {
            User = user;
            return this;
        }

        public CreateTodoCommand SetDate(DateTime date)
        {
            Date = date;
            return this;
        }

        public CreateTodoCommand Build()
        {
            Validate();
            return this;
        }

        #endregion
    }
}