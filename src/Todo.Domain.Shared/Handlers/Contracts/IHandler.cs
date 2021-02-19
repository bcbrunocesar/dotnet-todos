using Todo.Domain.Shared.Commands.Contracts;

namespace Todo.Domain.Shared.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}