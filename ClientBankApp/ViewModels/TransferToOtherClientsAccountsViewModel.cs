using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.Models.Worker;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.ViewModels.DialogViewModels;
using ClientBankApp.ViewModels.Helpers;
using ClientBankApp.Views.DialogWindows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
	public class TransferToOtherClientsAccountsViewModel : ViewModel
	{
		public Action UpdateAccountList;
		public Action UpdateClientList;
		private Worker _worker;

		#region Свойства зависимости
		private Client _currentClient;
		public Client CurrentClient
		{
			get => _currentClient;
			set => Set(ref _currentClient, value);
		}

		#region Accounts
		private ObservableCollection<Account> _accounts;
		public ObservableCollection<Account> Accounts
		{
			get => _accounts;
			set => Set(ref _accounts, value);
		}
		#endregion

		#region SelectedAccound
		private Account _selectedAccount;
		public Account SelectedAccount
		{
			get => _selectedAccount;
			set => Set(ref _selectedAccount, value);
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

		#region SelectedClient
		private Client _selectedClient;
		public Client SelectedClient
		{
			get => _selectedClient;
			set => Set(ref _selectedClient, value);
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

		#endregion

		public TransferToOtherClientsAccountsViewModel(Client currentClient, Worker worker)
		{
			_currentClient = currentClient;
			_worker = worker;

			TransferCommand = new LambdaCommand(OnTransferCommandExecute, CanTransferCommandExecute);

			UpdateAccountList += UpdateAccount;
			UpdateAccountList.Invoke();

			UpdateClientList += UpdateClients;
			UpdateClientList.Invoke();

			_selectedClients.Filter += OnClientFiltred;
		}

		private void UpdateClients()
		{
            if (MyHttpClient.GetClients() != null)
            {
                Clients = MyHttpClient.GetClients().Clients;
            }
            else
            {
                Clients = new ObservableCollection<Client>();
            }
		}

		private void UpdateAccount()
		{
            if (MyHttpClient.GetClients() != null)
            {
                Accounts = MyHttpClient.GetClientAccounsts(_currentClient.Id).Accounts;
            }
            else
            {
                Accounts = new ObservableCollection<Account>();
            }
		}

		#region Commands
		#region TransferCommand

		private TransferToOtherClientWindow _dialogWindow;
		public ICommand TransferCommand { get; }
		private bool CanTransferCommandExecute(object p)
		{
			return (_selectedAccount != null && _selectedClient != null);
		}

		private void OnTransferCommandExecute(object p)
		{
			var window = new TransferToOtherClientWindow
			{
				Owner = Application.Current.MainWindow
			};
			_dialogWindow = window;
			window.DataContext = new TransferToOtherClientsDialogViewModel(_selectedAccount, _selectedClient, this);
			window.Closed += OnWindowClosed;
			window.ShowDialog();
		}

		private void OnWindowClosed(object? sender, EventArgs e)
		{
			((Window)sender!).Closed -= OnWindowClosed;
			_dialogWindow = null;
		}
		#endregion
		#endregion
	}
}
