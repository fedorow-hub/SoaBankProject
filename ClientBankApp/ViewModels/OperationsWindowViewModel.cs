﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.ViewModels.Base;
using ClientBankApp.Views.AccountOperationWindow.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClientBankApp.Views;
using ClientBankApp.Models.Worker;
using ClientBankApp.Models.Client;

namespace ClientBankApp.ViewModels
{
	public class OperationsWindowViewModel : ViewModel
	{
		private readonly MainWindowViewModel _mainWindowViewModel;
		private readonly Worker _worker;

		#region Свойства зависимости
		private Client _currentClient;
		public Client CurrentClient
		{
			get => _currentClient;
			set => Set(ref _currentClient, value);
		}

		#region Pages
		private Page _currentPage;
		public Page CurrentPage
		{
			get => _currentPage;
			set => Set(ref _currentPage, value);
		}
		#endregion
		#endregion

		public OperationsWindowViewModel(Client currentClient,
			MainWindowViewModel mainWindowViewModel, Worker worker)
		{
			_currentClient = currentClient;
			_mainWindowViewModel = mainWindowViewModel;
			_worker = worker;

			#region Pages
			_addAndWithdrawals = new AddAndWithdrawalsPage();
			_betweenOwnAccounts = new TransferBetweenOwnAccountPage();
			_openAccount = new OpenAccountPage();
			_transferToOtherClientsAccounts = new TransferToOtherClientsAccountPage();

			CurrentPage = new EmptyPage();
			#endregion

			#region Commands
			ExitCommand = new LambdaCommand(OnExitCommandExecute, CanExitCommandExecute);
			AddAndWithdrawalsCommand = new LambdaCommand(OnAddAndWithdrawalsCommandExecuted, CanAddAndWithdrawalsCommandExecute);
			BetweenOwnAccountsCommand = new LambdaCommand(OnBetweenOwnAccountsCommandExecuted, CanBetweenOwnAccountsCommandExecute);
			TransferToOtherClientsAccountsCommand = new LambdaCommand(OnTransferToOtherClientsAccountsCommandExecuted, CanTransferToOtherClientsAccountsCommandExecute);
			OpenAccountCommand = new LambdaCommand(OnOpenAccountCommandExecuted, CanOpenAccountCommandExecute);
			#endregion
		}


		private readonly Page _addAndWithdrawals;
		private readonly Page _betweenOwnAccounts;
		private readonly Page _openAccount;
		private readonly Page _transferToOtherClientsAccounts;

		#region Commands

		#region AddAndWithdrawalsCommand
		public ICommand AddAndWithdrawalsCommand { get; }
		private void OnAddAndWithdrawalsCommandExecuted(object p)
		{
			CurrentPage = _addAndWithdrawals;
			_addAndWithdrawals.DataContext = new AddAndWithdrawalsViewModel(_currentClient);
		}
		private bool CanAddAndWithdrawalsCommandExecute(object p)
		{
			if (CurrentPage == _addAndWithdrawals)
				return false;
			return true;
		}
		#endregion

		#region BetweenOwnAccountsCommand
		public ICommand BetweenOwnAccountsCommand { get; }
		private void OnBetweenOwnAccountsCommandExecuted(object p)
		{
			CurrentPage = _betweenOwnAccounts;
			_betweenOwnAccounts.DataContext = new TransferBetweenOwnAccountsViewModel(_currentClient, _worker);
		}
		private bool CanBetweenOwnAccountsCommandExecute(object p)
		{
			if (CurrentPage == _betweenOwnAccounts)
				return false;
			return true;
		}
		#endregion

		#region TransferToOtherClientsAccountsCommand
		public ICommand TransferToOtherClientsAccountsCommand { get; }
		private void OnTransferToOtherClientsAccountsCommandExecuted(object p)
		{
			CurrentPage = _transferToOtherClientsAccounts;
			_transferToOtherClientsAccounts.DataContext = new TransferToOtherClientsAccountsViewModel(_currentClient, _worker);
		}
		private bool CanTransferToOtherClientsAccountsCommandExecute(object p)
		{
			return CurrentPage != _transferToOtherClientsAccounts;
		}
		#endregion

		#region OpenAccountCommand
		public ICommand OpenAccountCommand { get; }
		private void OnOpenAccountCommandExecuted(object p)
		{
			CurrentPage = _openAccount;

			_openAccount.DataContext = new OpenAccountViewModel((p as Client)!, _worker);

		}
		private bool CanOpenAccountCommandExecute(object p)
		{
			return CurrentPage != _openAccount;
		}
		#endregion

		#region ExitCommand
		public ICommand ExitCommand { get; }

		private static bool CanExitCommandExecute(object p) => true;

		private void OnExitCommandExecute(object p)
		{
			var mainWindow = new MainWindow
			{
				DataContext = _mainWindowViewModel
			};
			mainWindow.Show();

			if (p is Window window)
			{
				window.Close();
			}
		}
		#endregion
		#endregion
	}
}
