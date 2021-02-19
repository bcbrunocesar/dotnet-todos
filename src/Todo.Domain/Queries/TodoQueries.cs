using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user)
        {
            return todo => todo.Id == id && todo.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return todo => todo.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return todo => todo.User == user && todo.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return todo => todo.User == user && todo.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return todo =>
                todo.User == user &&
                todo.Done == done &&
                todo.Date == date.Date;
        }

        public static Expression<Func<TodoItem, dynamic>> OrderByDate() { 
            return todo => todo.Date;
        }
    }
}