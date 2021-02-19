using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Requests.Todo;
using Todo.Domain.Commands.Contracts.Todo;
using Todo.Domain.Commands.Todo;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Shared.Commands.Contracts;

namespace Todo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly TodoHandler _todoHandler;

        public TodoController(ITodoRepository todoRepository, TodoHandler todoHandler)
        {
            _todoRepository = todoRepository;
            _todoHandler = todoHandler;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository todoRepository)
        {
            return todoRepository.GetAll(GetUser());
        }

        [HttpGet]
        [Route("by-id")]
        public TodoItem GetById([FromQuery] GetByIdRequest getByIdRequest)
        {
            return _todoRepository.GetById(getByIdRequest.Id, GetUser());
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone()
        {
            return _todoRepository.GetAllDone(GetUser());
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone()
        {
            return _todoRepository.GetAllUndone(GetUser());
        }

        [HttpGet]
        [Route("by-period")]
        public IEnumerable<TodoItem> GetByPeriod([FromQuery] GetTodoByPeriodRequest getTodoByPeriodRequest)
        {
            (DateTime date, bool isDone) = getTodoByPeriodRequest;

            return _todoRepository.GetByPeriod(
                GetUser(),
                date,
                isDone);
        }

        [HttpPost]
        [Route("")]
        public ICommandResult Create(
            [FromBody] CreateTodoCommand createTodoCommand,
            [FromServices] TodoHandler todoHandler)
        {
            createTodoCommand.User = GetUser();
            return todoHandler.Handle(createTodoCommand);
        }

        [HttpPatch]
        [Route("")]
        public ICommandResult Update([FromBody] UpdateTodoCommand updateTodoCommand)
        {
            updateTodoCommand.User = GetUser();
            return _todoHandler.Handle(updateTodoCommand);
        }

        [HttpPatch]
        [Route("mark-as-done")]
        public ICommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand markTodoAsDoneCommand)
        {
            markTodoAsDoneCommand.User = GetUser();
            return _todoHandler.Handle(markTodoAsDoneCommand);
        }

        [HttpPatch]
        [Route("mark-as-undone")]
        public ICommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand markTodoAsUndoneCommand)
        {
            markTodoAsUndoneCommand.User = GetUser();
            return _todoHandler.Handle(markTodoAsUndoneCommand);
        }

        private string GetUser() => User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
    }
}