﻿using Bank.Application.Interfaces;
using Bank.Domain.Account;
using Bank.Domain.Root;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
	public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
	{
		private readonly IApplicationDbContext _dbContext;

		public CreateAccountCommandHandler(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var bank = await _dbContext.Bank.FirstOrDefaultAsync(cancellationToken);

			var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == request.ClientId, cancellationToken);

			if (client != null && bank != null)
			{
				switch (request.TypeOfAccount?.Id)
				{
					case 1://deposit 
						bank.AddMoneyToCapital(request.Amount);
						var depositAccount = DepositAccount.CreateDepositAccount(request.Id, request.ClientId, request.AccountTerm, request.Amount, request.CreatedAt);
						_dbContext.Accounts.Add(depositAccount);
						depositAccount.AddDomainEvent(new CreateAccountEvent
						{
							Id = depositAccount.Id,
							Money = request.Amount
						});
						break;
					case 2://credit 
						try
						{
							bank.WithdrawalMoneyFromCapital(request.Amount);
							var creditAccount = CreditAccount.CreateCreditAccount(request.Id, client,
								request.AccountTerm, request.Amount, request.CreatedAt);
							_dbContext.Accounts.Add(creditAccount);
							creditAccount.AddDomainEvent(new CreateAccountEvent
							{
								Id = creditAccount.Id,
								Money = request.Amount
							});
						}
						catch (DomainExeption ex)
						{
							return ex.Message;
						}
						break;
					case 3://plane
						bank.AddMoneyToCapital(request.Amount);
						var planeAccount = PlainAccount.CreatePlaneAccount(request.Id, request.ClientId, request.CreatedAt, request.AccountTerm, request.Amount);
						_dbContext.Accounts.Add(planeAccount);
						planeAccount.AddDomainEvent(new CreateAccountEvent
						{
							Id = planeAccount.Id,
							Money = request.Amount
						});
						break;
					default:
						Console.WriteLine("Нет такого типа счета");
						break;
				}
				await _dbContext.SaveChangesAsync(cancellationToken);
				return "Счет успешно создан";
			}
			return "Счет создать не удалось";
		}
	}
}
