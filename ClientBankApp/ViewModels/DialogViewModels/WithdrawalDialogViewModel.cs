﻿using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels.DialogViewModels
{
	public class WithdrawalDialogViewModel : ViewModel
	{
		private readonly AddAndWithdrawalsViewModel _viewModel;

		private readonly Account _currentAccount;

		#region Свойства зависимости
		private decimal _amount;
		public decimal Amount
		{
			get => _amount;
			set => Set(ref _amount, value);
		}
		#endregion

		public WithdrawalDialogViewModel(Account account, AddAndWithdrawalsViewModel viewModel)
		{
			_currentAccount = account;
			_viewModel = viewModel;
			#region Commands
			SaveCommand = new LambdaCommand(OnSaveCommandExecute, CanSaveCommandExecute);
			EscCommand = new LambdaCommand(OnEscCommandExecute, CanEscCommandExecute);
			#endregion
		}

		#region Commands
		#region SaveCommand

		public ICommand SaveCommand { get; }

		private bool CanSaveCommandExecute(object p) => true;

		private async void OnSaveCommandExecute(object p)
		{
			var amountDelta = new AmountDelta
			{
				Id = _currentAccount.Id,
				Amount = _amount,
            };
            string message = AcountAction.WithdrawalMoney(amountDelta);

			MessageBox.Show(message);

			if (p is Window window)
			{
				window.Close();
			}
			_viewModel.UpdateAccountList.Invoke();
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
