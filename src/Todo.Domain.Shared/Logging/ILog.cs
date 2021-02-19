using System;

namespace Todo.Domain.Shared.Logging
{
    public interface ILog<T>
    {
        void Error(string message, Exception exception);
        void Warn(string message);
        void Info(string message);
        void Debug(string message);
    }
}