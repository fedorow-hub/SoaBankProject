using AutoMapper;
using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Common.Mapping;
using Bank.Domain.Account;

namespace SoaBankProject.Models
{
    public class CreateAccountDTO : IMapWith<CreateAccountCommand>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }

        public DateTime TimeOfCreated { get; set; }

        public DateTime AccountTerm { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAccountDTO, CreateAccountCommand>()
                .ForMember(accountCommand => accountCommand.Id,
                    opt => opt.MapFrom(accountDto => accountDto.Id))
                .ForMember(accountCommand => accountCommand.ClientId,
                    opt => opt.MapFrom(accountDto => accountDto.ClientId))
                .ForMember(accountCommand => accountCommand.CreatedAt,
                    opt => opt.MapFrom(accountDto => accountDto.TimeOfCreated))
                .ForMember(accountCommand => accountCommand.AccountTerm,
                    opt => opt.MapFrom(accountDto => accountDto.AccountTerm))
                .ForMember(accountCommand => accountCommand.Amount,
                    opt => opt.MapFrom(accountDto => accountDto.Amount))
                .ForMember(accountCommand => accountCommand.TypeOfAccount,
                    opt => opt.MapFrom(accountDto => TypeOfAccount.Parse(accountDto.Type)));
        }
    }
}
