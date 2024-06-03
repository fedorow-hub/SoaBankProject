using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.Models.Worker;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.ViewModels.DialogViewModels;
using ClientBankApp.Views.DialogWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
	public class TransferBetweenOwnAccountsViewModel : ViewModel
	{
		public Action UpdateAccountList;
		private readonly Worker _worker;

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

		#region SelectedAccountFrom
		private Account _selectedAccountFrom;
		public Account SelectedAccountFrom
		{
			get => _selectedAccountFrom;
			set => Set(ref _selectedAccountFrom, value);
		}
		#endregion

		#region SelectedAccountTo
		private Account _selectedAccountTo;
		public Account SelectedAccountTo
		{
			get => _selectedAccountTo;
			set => Set(ref _selectedAccountTo, value);

		}
		#endregion
		#endregion

		public TransferBetweenOwnAccountsViewModel(Client currentClient, Worker worker)
		{
			_currentClient = currentClient;
			_worker = worker;

			TransferCommand = new LambdaCommand(OnTransferCommandExecute, CanTransferCommandExecute);

			UpdateAccountList += UpdateAccount;
			UpdateAccountList.Invoke();
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

		#region TransferCommand

		private TransferBetweenOwnAccountsDialogWindow _dialogWindow;
		public ICommand TransferCommand { get; }

		private bool CanTransferCommandExecute(object p)
		{
			return (_selectedAccountFrom != null && _selectedAccountTo != null) && (_selectedAccountFrom.Id != _selectedAccountTo.Id);
		}

		private void OnTransferCommandExecute(object p)
		{
			var window = new TransferBetweenOwnAccountsDialogWindow
			{
				Owner = Application.Current.MainWindow
			};
			_dialogWindow = window;
			window.DataContext = new TransferBetweenOwnAccountsDialogViewModel(_selectedAccountFrom, _selectedAccountTo, this);
			window.Closed += OnWindowClosed;
			window.ShowDialog();
		}

		private void OnWindowClosed(object? sender, EventArgs e)
		{
			((Window)sender!).Closed -= OnWindowClosed;
			_dialogWindow = null;
		}
		#endregion
	}
}
