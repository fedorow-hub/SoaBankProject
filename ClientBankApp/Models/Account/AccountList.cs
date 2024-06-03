using System.Collections.ObjectModel;

namespace ClientBankApp.Models.Account
{
    public class AccountList
    {
        public ObservableCollection<Account> Accounts { get; set; } = null!;
    }
}
