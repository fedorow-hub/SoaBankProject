using MediatR;
using Serilog;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountEventHandler : INotificationHandler<CreateAccountEvent>
    {
        public Task Handle(CreateAccountEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Открыт счет {notification.Id} с начальной суммой {notification.Money} рублей");
            return Task.CompletedTask;
        }
    }
}
