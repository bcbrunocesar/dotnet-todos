using System;

namespace Todo.Api.Requests.Todo
{
    public class GetTodoByPeriodRequest
    {
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }

        public void Deconstruct(out DateTime date, out bool isDone)
        {
            date = Date;
            isDone = IsDone;
        }
    }
}