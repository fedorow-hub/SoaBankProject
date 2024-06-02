﻿using Bank.Application.Interfaces;
using Bank.Domain.Account.Events;
using MediatR;
using Serilog;

namespace Bank.Application.Accounts.Commands.WithdrawMoneyFromAccount
{
	public class WithdrawMoneyFromAccountEventHandler : INotificationHandler<WithdrawalMoneyFromAccountEvent>
	{
		private readonly ICurrentWorkerService _workerService;
		public WithdrawMoneyFromAccountEventHandler(ICurrentWorkerService workerService)
		{
			_workerService = workerService;
		}
		public Task Handle(WithdrawalMoneyFromAccountEvent notification, CancellationToken cancellationToken)
		{
			Log.Information($"Со счета {notification.Id} {_workerService.Worker} снял {notification.WithdrawnMoney} рублей");
			return Task.CompletedTask;
		}
	}
}
