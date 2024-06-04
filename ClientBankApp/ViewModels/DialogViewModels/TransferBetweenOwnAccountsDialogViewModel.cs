using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels.DialogViewModels
{
	public class TransferBetweenOwnAccountsDialogViewModel : ViewModel
	{
		private readonly TransferBetweenOwnAccountsViewModel _viewModel;

		private readonly Account _accountFrom;

		private readonly Account _accountTo;

		#region Свойства зависимости
		private decimal _amount;
		public decimal Amount
		{
			get => _amount;
			set => Set(ref _amount, value);
		}
		#endregion

		public TransferBetweenOwnAccountsDialogViewModel(Account accountFrom, Account accountTo, TransferBetweenOwnAccountsViewModel viewModel)
		{
			_accountFrom = accountFrom;
			_accountTo = accountTo;
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
			var transaction = new TransactionModel
			{
				FromAccountId = _accountFrom.Id,
				DestinationAccountId = _accountTo.Id,
				Amount = _amount
			};

            var message = AcountAction.TransactionMoney(transaction);

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
