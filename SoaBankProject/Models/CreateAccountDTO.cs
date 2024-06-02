using AutoMapper;
using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Clients.Commands.CreateClient;
using Bank.Application.Common.Mapping;
using Bank.Domain.Account;

namespace SoaBankProject.Models
{
	public class CreateAccountDTO : IMapWith<CreateAccountCommand>
	{
		public Guid ClientId { get; set; }

		public DateTime CreatedAt { get; set; }

		public byte AccountTerm { get; set; }

		public decimal Amount { get; set; }

		public int TypeId { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateAccountDTO, CreateAccountCommand>()
				.ForMember(accountCommand => accountCommand.ClientId,
					opt => opt.MapFrom(accountDto => accountDto.ClientId))
				.ForMember(accountCommand => accountCommand.CreatedAt,
					opt => opt.MapFrom(accountDto => accountDto.CreatedAt))
				.ForMember(accountCommand => accountCommand.AccountTerm,
					opt => opt.MapFrom(accountDto => accountDto.AccountTerm))
				.ForMember(accountCommand => accountCommand.Amount,
					opt => opt.MapFrom(accountDto => accountDto.Amount))
				.ForMember(accountCommand => accountCommand.TypeOfAccount,
					opt => opt.MapFrom(accountDto => TypeOfAccount.ParseFromInt(accountDto.TypeId)));
		}
	}
}
