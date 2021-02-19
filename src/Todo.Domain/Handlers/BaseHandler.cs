using System.Collections.Generic;
using Flunt.Notifications;
using Todo.Domain.Shared.Commands.Commons;

namespace Todo.Domain.Handlers
{
    public class BaseHandler : Notifiable
    {
        protected GenericCommandResult HandleErrorCommandResult(string message, IReadOnlyCollection<Notification> notifications) =>
             GenericCommandResult.Builder()
                .IsSuccess(false)
                .SetMessage(message)
                .SetNotifications(notifications)
                .Build();

        protected GenericCommandResult HandleSuccessCommandResult(string message) =>
            GenericCommandResult.Builder()
                .IsSuccess(true)
                .SetMessage(message)
                .Build();
    }
}