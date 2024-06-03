using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.ViewModels.DialogViewModels;
using ClientBankApp.ViewModels.Helpers;
using ClientBankApp.Views.DialogWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
	public class AddAndWithdrawalsViewModel : ViewModel
	{
		public Action UpdateAccountList;

		#region Свойства зависимости
		private Client _currentClient;
		public Client CurrentClient
		{
			get => _currentClient;
			set => Set(ref _currentClient, value);
		}

		#region Accounts
		private ObservableCollection<Account> _accounts = null!;
		public ObservableCollection<Account> Accounts
		{
			get => _accounts;
			set
			{
				Set(ref _accounts, value);
			}
		}
		#endregion

		#region SelectedAccount
		private Account _selectedAccount = null!;
		public Account SelectedAccount
		{
			get => _selectedAccount;
			set => Set(ref _selectedAccount, value);
		}
		#endregion


		#endregion

		public AddAndWithdrawalsViewModel(Client currentClient)
		{
			_currentClient = currentClient;

			#region Commands
			AddCommand = new LambdaCommand(OnAddCommandExecute, CanAddCommandExecute);
			WithdrawalCommand = new LambdaCommand(OnWithdrawalCommandExecute, CanWithdrawalCommandExecute);
			#endregion

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

		#region Commands
		public AddDialogWindow DialogWindow { get; private set; } = null!;

		#region AddCommand
		public ICommand AddCommand { get; }
		private bool CanAddCommandExecute(object? p) => p != null;

		private void OnAddCommandExecute(object p)
		{
			var window = new AddDialogWindow
			{
				Owner = Application.Current.MainWindow
			};
			DialogWindow = window;
			window.DataContext = new AddDialogViewModel((p as Account)!, this);
			window.Closed += OnWindowClosed;
			window.ShowDialog();
		}
		#endregion

		public WithdrawalDialogWindow WithdrawalDialogWindow { get; private set; } = null!;

		#region WithdrawalCommand
		public ICommand WithdrawalCommand { get; }
		private bool CanWithdrawalCommandExecute(object? p) => p != null;
		private void OnWithdrawalCommandExecute(object p)
		{
			var window = new WithdrawalDialogWindow
			{
				Owner = Application.Current.MainWindow
			};
			WithdrawalDialogWindow = window;
			window.DataContext = new WithdrawalDialogViewModel((p as Account)!, this);
			window.Closed += OnWindowClosed;
			window.ShowDialog();
		}

		private void OnWindowClosed(object? sender, EventArgs e)
		{
			((Window)sender!).Closed -= OnWindowClosed;
			DialogWindow = null!;
		}

		#endregion

		#endregion


	}
}
