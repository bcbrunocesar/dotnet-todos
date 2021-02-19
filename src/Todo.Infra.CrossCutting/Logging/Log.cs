using System;
using Microsoft.Extensions.Logging;
using Todo.Domain.Shared.Logging;

namespace Todo.Infra.CrossCutting.Logging
{
    public class Log<T> : ILog<T>
    {   
        private readonly ILogger<T> _logger;

        public Log(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Debug(string message)
        {
            _logger.LogDebug(message);
        }

        public void Error(string message, Exception exception)
        {
            _logger.LogError(message, exception);
        }

        public void Info(string message)
        {
            _logger.LogInformation(message);
        }

        public void Warn(string message)
        {
            _logger.LogWarning(message);
        }
    }
}