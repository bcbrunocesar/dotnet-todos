using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TodoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(TodoItem todoItem)
        {
            _applicationDbContext.Todos.Add(todoItem);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _applicationDbContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(TodoQueries.OrderByDate());
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _applicationDbContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(TodoQueries.OrderByDate());
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _applicationDbContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(TodoQueries.OrderByDate());
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _applicationDbContext.Todos
                .AsNoTracking()
                .FirstOrDefault(TodoQueries.GetById(id, user));
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _applicationDbContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(TodoQueries.OrderByDate());
        }

        public void Update(TodoItem todoItem)
        {
            _applicationDbContext.Entry(todoItem).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }
    }
}









