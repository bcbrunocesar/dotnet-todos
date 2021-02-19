using Todo.Domain.Commands.Contracts.Todo;
using Todo.Domain.Commands.Todo;
using Todo.Domain.Entities;
using Todo.Domain.Messages;
using Todo.Domain.Repositories;
using Todo.Domain.Shared.Commands.Contracts;
using Todo.Domain.Shared.Handlers.Contracts;
using Todo.Domain.Shared.Logging;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        BaseHandler,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILog<TodoItem> _log;

        public TodoHandler(ITodoRepository todoRepository, ILog<TodoItem> log)
        {
            _todoRepository = todoRepository;
            _log = log;
        }

        public ICommandResult Handle(CreateTodoCommand createTodoCommand)
        {
            createTodoCommand.Validate();

            if (createTodoCommand.Invalid)
            {
                _log.Info(TodoMessage.WARNING_VALIDATION);
                return HandleErrorCommandResult(TodoMessage.WARNING_VALIDATION, createTodoCommand.Notifications);
            }

            TodoItem todoItem = TodoItem.Builder()
                .SetTitle(createTodoCommand.Title)
                .SetUser(createTodoCommand.User)
                .SetDate(createTodoCommand.Date)
                .Build();

            _todoRepository.Create(todoItem);

            _log.Info(TodoMessage.SUCCESSFULLY_ADDED);
            return HandleSuccessCommandResult(TodoMessage.SUCCESSFULLY_ADDED);
        }

        public ICommandResult Handle(UpdateTodoCommand updateTodoCommand)
        {
            updateTodoCommand.Validate();

            if (updateTodoCommand.Invalid)
            {
                _log.Info(TodoMessage.WARNING_VALIDATION);
                return HandleErrorCommandResult(TodoMessage.WARNING_VALIDATION, updateTodoCommand.Notifications);
            }

            TodoItem todoItem = _todoRepository.GetById(updateTodoCommand.Id, updateTodoCommand.User);
            todoItem.UpdateTitle(updateTodoCommand.Title);

            _todoRepository.Update(todoItem);

            _log.Info(TodoMessage.SUCCESSFULLY_UPDATED);
            return HandleSuccessCommandResult(TodoMessage.SUCCESSFULLY_UPDATED);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand markTodoAsDoneCommand)
        {
            markTodoAsDoneCommand.Validate();

            if (markTodoAsDoneCommand.Invalid)
            {
                _log.Info(TodoMessage.WARNING_VALIDATION);
                return HandleErrorCommandResult(TodoMessage.WARNING_VALIDATION, markTodoAsDoneCommand.Notifications);
            }

            TodoItem todoItem = _todoRepository.GetById(markTodoAsDoneCommand.Id, markTodoAsDoneCommand.User);
            todoItem.MarkAsDone();

            _todoRepository.Update(todoItem);

            _log.Info(TodoMessage.SUCCESSFULLY_UPDATED);
            return HandleSuccessCommandResult(TodoMessage.SUCCESSFULLY_UPDATED);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand markTodoAsUndoneCommand)
        {
            markTodoAsUndoneCommand.Validate();

            if (markTodoAsUndoneCommand.Invalid)
            {
                _log.Info(TodoMessage.WARNING_VALIDATION);
                return HandleErrorCommandResult(TodoMessage.WARNING_VALIDATION, markTodoAsUndoneCommand.Notifications);
            }

            TodoItem todoItem = _todoRepository.GetById(markTodoAsUndoneCommand.Id, markTodoAsUndoneCommand.User);
            todoItem.MarkAsUndone();

            _todoRepository.Update(todoItem);

            _log.Info(TodoMessage.SUCCESSFULLY_UPDATED);
            return HandleSuccessCommandResult(TodoMessage.SUCCESSFULLY_UPDATED);
        }
    }
}