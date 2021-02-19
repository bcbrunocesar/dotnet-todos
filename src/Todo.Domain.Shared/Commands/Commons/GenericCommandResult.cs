using System.Collections.Generic;
using Flunt.Notifications;
using Todo.Domain.Shared.Commands.Contracts;

namespace Todo.Domain.Shared.Commands.Commons
{
    public class GenericCommandResult : ICommandResult
    {
        private GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static GenericCommandResult Builder() => new GenericCommandResult();

        public GenericCommandResult IsSuccess(bool isSuccess)
        {
            Success = isSuccess;
            return this;
        }

        public GenericCommandResult SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public GenericCommandResult SetNotifications(IReadOnlyCollection<Notification> notifications)
        {
            Data = notifications;
            return this;
        }

        public GenericCommandResult SetData(object data)
        {
            Data = data;
            return this;
        }

        public GenericCommandResult Build() => this;
    }
}