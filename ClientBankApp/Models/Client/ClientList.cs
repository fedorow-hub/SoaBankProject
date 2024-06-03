using System.Collections.ObjectModel;

namespace ClientBankApp.Models.Client
{
    public class ClientList
    {
        public ObservableCollection<Client> Clients { get; set; } = null!;
    }
}
