using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        IEnumerable<TodoItem> GetAll(string user);
        IEnumerable<TodoItem> GetAllDone(string user);
        IEnumerable<TodoItem> GetAllUndone(string user);
        TodoItem GetById(Guid id, string user);
        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
        void Update(TodoItem todoItem);
    }
}