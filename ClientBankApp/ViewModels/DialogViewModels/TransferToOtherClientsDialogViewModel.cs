using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels.DialogViewModels
{
    public class TransferToOtherClientsDialogViewModel : ViewModel
    {
        private readonly TransferToOtherClientsAccountsViewModel _transferToOtherClientsAccountsViewModel;

        #region Свойства зависимости
        #region Accounts
        private ObservableCollection<Account> _accountsSelectedClient;
        public ObservableCollection<Account> AccountsSelectedClient
        {
            get => _accountsSelectedClient;
            set => Set(ref _accountsSelectedClient, value);
        }
        #endregion

        #region Amount
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }
        #endregion

        #region SelectedAccount
        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set => Set(ref _selectedAccount, value);
        }
        #endregion
        #endregion

        public Client SelectedClient { get; set; }
        public Account AccountFrom { get; set; }

        public TransferToOtherClientsDialogViewModel(Account accountFrom, Client client, TransferToOtherClientsAccountsViewModel viewModel)
        {
            if (ClientAction.GetClients() != null)
            {
                _accountsSelectedClient = AcountAction.GetClientAccounsts(client.Id).Accounts;
            }
            else
            {
                _accountsSelectedClient = new ObservableCollection<Account>();
            }
            _transferToOtherClientsAccountsViewModel = viewModel;
            AccountFrom = accountFrom;
            SelectedClient = client;

            #region Commands
            SaveCommand = new LambdaCommand(OnSaveCommandExecute, CanSaveCommandExecute);
            EscCommand = new LambdaCommand(OnEscCommandExecute, CanEscCommandExecute);
            #endregion
        }

        #region Commands
        #region SaveCommand
        public ICommand SaveCommand { get; }
        private bool CanSaveCommandExecute(object p)
        {
            return _amount > 0 && _selectedAccount != null;
        }

        private async void OnSaveCommandExecute(object p)
        {
            var transaction = new TransactionModel
            {
                FromAccountId = AccountFrom.Id,
                DestinationAccountId = _selectedAccount.Id,
                Amount = _amount
            };

            var message = AcountAction.TransactionMoney(transaction);

            MessageBox.Show(message);

            if (p is Window window)
            {
                window.Close();
            }
            _transferToOtherClientsAccountsViewModel.UpdateAccountList.Invoke();
        }
        #endregion

        #region EscCommand
        public ICommand EscCommand { get; }
        private bool CanEscCommandExecute(object p) => true;
        private void OnEscCommandExecute(object p)
        {
            if (p is Window window)
            {
                window.Close();
            }
        }
        #endregion
        #endregion
    }
}
