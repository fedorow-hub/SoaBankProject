using AutoMapper;
using Bank.Domain.Account;
using Bank.Application.Common.Mapping;

namespace Bank.Application.Accounts.Queries
{
    public class AccountLookUpDTO : IMapWith<Account>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }

        public DateTime TimeOfCreated { get; set; }

        public decimal Amount { get; set; }

        public DateTime AccountTerm { get; set; }

        public bool IsExistance { get; set; }

        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountLookUpDTO>()
                .ForMember(accountDto => accountDto.Id,
                    opt => opt.MapFrom(account => account.Id))
                .ForMember(accountDto => accountDto.ClientId,
                    opt => opt.MapFrom(account => account.ClientId))
                .ForMember(accountDto => accountDto.TimeOfCreated,
                    opt => opt.MapFrom(client => client.TimeOfCreated))
                .ForMember(accountDto => accountDto.Amount,
                    opt => opt.MapFrom(client => client.Amount))
                .ForMember(accountDto => accountDto.AccountTerm,
                    opt => opt.MapFrom(client => client.AccountTerm))
                .ForMember(accountDto => accountDto.IsExistance,
                    opt => opt.MapFrom(client => client.IsExistance))
                .ForMember(accountDto => accountDto.Type,
                    opt => opt.MapFrom(client => client.Type.Name));
        }
    }
}
