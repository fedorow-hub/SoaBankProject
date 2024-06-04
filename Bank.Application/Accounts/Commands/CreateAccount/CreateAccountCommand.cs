using Bank.Domain.Account;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
	public record CreateAccountCommand : IRequest<string>
	{
        public Guid Id { get; init; }

        public Guid ClientId { get; init; }

		public DateTime CreatedAt { get; init; }

		public DateTime AccountTerm { get; init; }

		public decimal Amount { get; init; }

		public TypeOfAccount? TypeOfAccount { get; init; }
	}
}
