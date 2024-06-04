using Bank.Domain.Account.Events;
using MediatR;
using Serilog;

namespace Bank.Application.Accounts.Commands.CloseAccount
{
    public class CloseAccountEventHandler : INotificationHandler<CloseAccountEvent>
    {
        public Task Handle(CloseAccountEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Закрыт счет {notification.Id}");
            return Task.CompletedTask;
        }
    }
}
