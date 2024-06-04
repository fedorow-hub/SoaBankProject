using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.Models.Worker;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
    public class OpenAccountViewModel : ViewModel
    {
        public Action UpdateAccountList;
        private readonly Worker _worker;

        #region Свойства зависимости
        #region CurrentClient
        private Client _currentClient;
        public Client CurrentClient
        {
            get => _currentClient;
            set => Set(ref _currentClient, value);
        }
        #endregion

        #region Accounts
        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => Set(ref _accounts, value);
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

        public OpenAccountViewModel(Client currentClient, Worker worker)
        {
            _currentClient = currentClient;
            _worker = worker;

            #region Commands
            OutCommand = new LambdaCommand(OnOutCommandExecute, CanOutCommandExecute);
            CreateAccountCommand = new LambdaCommand(OnCreateAccountCommandExecute, CanCreateAccountCommandExecute);
            CloseAccountCommand = new LambdaCommand(OnCloseAccountCommandExecute, CanCloseAccountCommandExecute);
            #endregion

            UpdateAccountList += UpdateAccount;
            UpdateAccountList.Invoke();
        }

        private void UpdateAccount()
        {
            if (ClientAction.GetClients() != null)
            {
                Accounts = AcountAction.GetClientAccounsts(_currentClient.Id).Accounts;
            }
            else
            {
                Accounts = new ObservableCollection<Account>();
            }
        }

        #region Commands
        #region CreateAccount

        public ICommand CreateAccountCommand { get; }

        private bool CanCreateAccountCommandExecute(object p)
        {
            return true;
        }
        private AccountInfoWindow _accountInfoWindow;
        private void OnCreateAccountCommandExecute(object p)
        {
            var window = new AccountInfoWindow
            {
                Owner = Application.Current.MainWindow
            };
            _accountInfoWindow = window;
            window.DataContext = new AccountInfoViewModel(p as Client, this);
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }
        private void OnWindowClosed(object? sender, EventArgs e)
        {
            ((Window)sender!).Closed -= OnWindowClosed;
            _accountInfoWindow = null;
        }
        #endregion

        #region CloseAccount

        public ICommand CloseAccountCommand { get; }

        private bool CanCloseAccountCommandExecute(object p) => p != null;

        private async void OnCloseAccountCommandExecute(object p)
        {
            if (_selectedAccount.Amount > 0) //TODO перенести логику проверки в доменную модель
            {
                MessageBox.Show("На счету имеются денежные средства, перед закрытием счета их необходимо снять или перевести на другой счет");
            }
            else
            {
                string message = AcountAction.DeleteAccount(_selectedAccount.Id);

                MessageBox.Show(message);
            }

            UpdateAccountList.Invoke();
        }

        #endregion


        #region OutCommand
        public ICommand OutCommand { get; }

        private bool CanOutCommandExecute(object p) => true;

        private void OnOutCommandExecute(object p)
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
