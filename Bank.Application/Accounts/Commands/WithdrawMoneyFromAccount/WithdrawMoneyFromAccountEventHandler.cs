using Bank.Domain.Account.Events;
using MediatR;
using Serilog;

namespace Bank.Application.Accounts.Commands.WithdrawMoneyFromAccount
{
    public class WithdrawMoneyFromAccountEventHandler : INotificationHandler<WithdrawalMoneyFromAccountEvent>
    {
        public Task Handle(WithdrawalMoneyFromAccountEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Со счета {notification.Id} сняты {notification.WithdrawnMoney} рублей");
            return Task.CompletedTask;
        }
    }
}
