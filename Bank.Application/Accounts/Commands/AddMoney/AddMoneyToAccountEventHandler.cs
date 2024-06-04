using Bank.Domain.Account.Events;
using MediatR;
using Serilog;

namespace Bank.Application.Accounts.Commands.AddMoney
{
    public class AddMoneyToAccountEventHandler : INotificationHandler<AddedMoneyToAccountEvent>
    {
        public Task Handle(AddedMoneyToAccountEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"На счет {notification.Id} внесены {notification.AddedMoney} рублей");
            return Task.CompletedTask;
        }
    }
}
