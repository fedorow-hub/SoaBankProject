﻿using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Bank;
using ClientBankApp.Models.Client;
using ClientBankApp.Models.Worker;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.Views;
using ClientBankApp.Views.AccountOperationWindow;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public string Date { get; private set; }

        public Action UpdateClientList;
        public Action UpdateAccountListForCurrentClient;

        #region Currency
        public decimal DollarCurrentRate { get; private set; }
        public decimal EuroCurrentRate { get; private set; }

        public Worker Worker { get; }
        #endregion

        #region Свойства зависимости
        #region SelectedClient
        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                Set(ref _selectedClient, value);
                UpdateAccountListForCurrentClient.Invoke();
            }
        }
        #endregion
        #region Clients
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                Set(ref _clients, value);
                _selectedClients.Source = Clients;
                OnPropertyChanged(nameof(SelectedClients));
            }
        }
        #endregion

        #region AccountsCurrentClient
        private ObservableCollection<Account> _accountsCurrentClient;
        public ObservableCollection<Account> AccountsCurrentClient
        {
            get => _accountsCurrentClient;
            set => Set(ref _accountsCurrentClient, value);
        }
        #endregion

        #region ClientFilterText
        private string _clientFilterText;

        public string ClientFilterText
        {
            get => _clientFilterText;
            set
            {
                if (!Set(ref _clientFilterText, value)) return;
                _selectedClients.View.Refresh();
            }
        }
        #endregion

        #region FilteredClient

        private readonly CollectionViewSource _selectedClients = new();

        private void OnClientFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Client client))
            {
                e.Accepted = false;
                return;
            }
            var filterText = _clientFilterText;

            if (string.IsNullOrWhiteSpace(filterText)) return;

            if (client.Firstname is null || client.Lastname is null || client.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }

            if (client.Firstname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (client.Lastname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (client.Patronymic.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }
        public ICollectionView SelectedClients => _selectedClients?.View;
        #endregion

        #region Title

        private string _title;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion


        #region EnableAddClient
        private bool _enableAddClient;
        public bool EnableAddClient
        {
            get => _enableAddClient;
            set => Set(ref _enableAddClient, value);
        }
        #endregion

        #region EnableDelClient
        private bool _enableDelClient;
        public bool EnableDelClient
        {
            get => _enableDelClient;
            set => Set(ref _enableDelClient, value);
        }
        #endregion

        #region EnableEditClient
        private bool _enableEditClient;
        public bool EnableEditClient
        {
            get => _enableEditClient;
            set => Set(ref _enableEditClient, value);
        }
        #endregion

        #region EnableOperationAccounts
        private bool _enableOperationAccounts;
        public bool EnableOperationAccounts
        {
            get => _enableOperationAccounts;
            set => Set(ref _enableOperationAccounts, value);
        }
        #endregion

        #endregion

        public MainWindowViewModel(Worker worker, ICurrentWorkerService workerService)
        {
            Worker = worker;
            workerService.Worker = Worker;

            var bank = GetExistBankOrCreate();

            Title = $"Банк {bank?.Name}, капитал банка: {bank?.Capital} руб.";

            #region Currency
            //Date = _exchangeRateService.GetDate();
            //DollarCurrentRate = _exchangeRateService.GetDollarExchangeRate().cur;
            //EuroCurrentRate = _exchangeRateService.GetEuroExchangeRate().cur;
            #endregion

            #region commands
            DeleteClientCommand = new LambdaCommand(OnDeleteClientCommandExecute, CanDeleteClientCommandExecute);
            OutLoggingCommand = new LambdaCommand(OnOutLoggingCommandExecute, CanOutLoggingCommandExecute);
            EditClientCommand = new LambdaCommand(OnEditClientCommandExecute, CanEditClientCommandExecute);
            AddClientCommand = new LambdaCommand(OnAddClientCommandExecute, CanAddClientCommandExecute);
            OpenOperationWindowCommand = new LambdaCommand(OnOpenOperationWindowCommandExecute, CanOpenOperationWindowCommandExecute);
            #endregion

            _enableAddClient = Worker.DataAccess.Commands.AddClient;
            _enableDelClient = Worker.DataAccess.Commands.DelClient;
            _enableEditClient = Worker.DataAccess.Commands.EditClient;

            UpdateClientList += UpdateClients;
            UpdateClientList.Invoke();
            UpdateAccountListForCurrentClient += UpdateAccount;
            _selectedClients.Filter += OnClientFiltred;
        }

        private void UpdateClients()
        {
            if (ClientAction.GetClients() != null)
            {
                Clients = ClientAction.GetClients().Clients;
            }
            else
            {
                Clients = new ObservableCollection<Client>();
            }
        }

        private void UpdateAccount()
        {
            if (ClientAction.GetClients() != null)
            {
                AccountsCurrentClient = AcountAction.GetClientAccounsts(_selectedClient.Id).Accounts;
            }
            else
            {
                AccountsCurrentClient = new ObservableCollection<Account>();
            }
        }

        private Bank GetExistBankOrCreate()
        {
            var bank = new Bank
            {
                Id = Guid.NewGuid(),
                Name = "Сбер",
                Capital = 100000000,
                DateOfCreation = DateTime.Now
            };

            return BankAction.CreateBank(bank);
        }


        #region Команды
        #region OutLoggingCommand
        public ICommand OutLoggingCommand { get; }

        private static bool CanOutLoggingCommandExecute(object p) => true;

        private static void OnOutLoggingCommandExecute(object p)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            if (p is Window window)
            {
                window.Close();
            }
        }
        #endregion


        #region DeleteClient

        public ICommand DeleteClientCommand { get; }

        private bool CanDeleteClientCommandExecute(object p)
        {
            if (_enableDelClient && SelectedClient != null)
                return true;
            return false;
        }
        private void OnDeleteClientCommandExecute(object p)
        {
            if (SelectedClient is null) return;

            //TODO вынести логику проверки на уровень домена
            foreach (var account in _accountsCurrentClient)
            {
                if (account.IsExistance)
                {
                    MessageBox.Show("У клиента есть незакрытые счета, удаление не возможно до их закрытия");
                    return;
                }
            }
            
            if(ClientAction.DeleteClient(SelectedClient.Id))
            {
                MessageBox.Show($"{Worker} удалил клиента {SelectedClient.Lastname}");
                UpdateClientList.Invoke();
            }
            else
            {
                MessageBox.Show($"Клиент {SelectedClient.Lastname} не удален");
            }
        }
        #endregion

        #region EditClient

        public ICommand EditClientCommand { get; }

        private bool CanEditClientCommandExecute(object p)
        {
            if (_enableEditClient && SelectedClient != null)
                return true;
            return false;
        }
        private ClientInfoWindow _clientInfoWindow;
        private void OnEditClientCommandExecute(object p)
        {
            if (SelectedClient is null) return;

            var window = new ClientInfoWindow
            {
                Owner = Application.Current.MainWindow
            };
            _clientInfoWindow = window;
            window.DataContext = new ClientInfoViewModel(this, Worker, SelectedClient);
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            ((Window)sender!).Closed -= OnWindowClosed;
            _clientInfoWindow = null;
        }
        #endregion

        #region AddClient

        public ICommand AddClientCommand { get; }

        private bool CanAddClientCommandExecute(object p)
        {
            if (_enableAddClient)
                return true;
            return false;
        }
        private void OnAddClientCommandExecute(object p)
        {
            var window = new ClientInfoWindow
            {
                Owner = Application.Current.MainWindow
            };
            _clientInfoWindow = window;
            window.DataContext = new ClientInfoViewModel(this, Worker);
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }

        #endregion


        #region OpenOperationWindow

        public ICommand OpenOperationWindowCommand { get; }

        private bool CanOpenOperationWindowCommandExecute(object p)
        {
            return SelectedClient is not null;
        }

        private void OnOpenOperationWindowCommandExecute(object p)
        {
            if (SelectedClient is null) return;

            var operationWindow = new OperationsWindow();
            var viewModel = new OperationsWindowViewModel(SelectedClient, this, Worker);
            operationWindow.DataContext = viewModel;
            operationWindow.Show();

            if (p is Window window)
            {
                window.Close();
            }
        }
        #endregion

        #endregion

    }
}
