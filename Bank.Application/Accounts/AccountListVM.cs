using Bank.Application.Accounts.Queries;

namespace Bank.Application.Accounts
{
    public class AccountListVm
    {
        public List<AccountLookUpDTO> Accounts { get; set; } = null!;
    }
}
