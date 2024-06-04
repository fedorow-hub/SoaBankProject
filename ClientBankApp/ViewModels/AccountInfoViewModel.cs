using ClientBankApp.Helpers;
using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;
using ClientBankApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.ViewModels
{
	public class AccountInfoViewModel : ViewModel
	{
		private readonly Client _currentClient;
		private readonly OpenAccountViewModel _openAccountViewModel;

		#region Свойства зависимости
		private string[] _accountTypes = { "Расчетный", "Кредитный", "Депозитный" };
		public string[] AccountTypes
		{
			get => _accountTypes;
			set => Set(ref _accountTypes, value);
		}

		private string _type = "Расчетный";
		public string Type
		{
			get => _type;
			set => Set(ref _type, value);
		}

		private decimal _amount;
		public decimal Amount
		{
			get => _amount;
			set => Set(ref _amount, value);
		}

		private byte _accountTerm = byte.MaxValue;
		public byte AccountTerm
		{
			get => _accountTerm;
			set => Set(ref _accountTerm, value);
		}
		#endregion

		public AccountInfoViewModel(Client client, OpenAccountViewModel openAccountViewModel)
		{
			_currentClient = client;
			_openAccountViewModel = openAccountViewModel;

			#region Commands
			SaveCommand = new LambdaCommand(OnSaveCommandExecute, CanSaveCommandExecute);
			OutCommand = new LambdaCommand(OnOutCommandExecute, CanOutCommandExecute);
			#endregion
		}

		#region Commands
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

		#region SaveCommand
		public ICommand SaveCommand { get; }
		private bool CanSaveCommandExecute(object p) => true;
		private async void OnSaveCommandExecute(object p)
		{
			var account = new Account
            {
				Id = Guid.NewGuid(),
				ClientId = _currentClient.Id,
                TimeOfCreated = DateTime.Now,
				AccountTerm = DateTime.Now.AddMonths(AccountTerm),
				Amount = Convert.ToDecimal(_amount),
				Type = _type
			};

			string message = AcountAction.CreateAccount(account);


			MessageBox.Show(message);

			if (p is Window window)
			{
				window.Close();
			}
			_openAccountViewModel.UpdateAccountList.Invoke();
		}
		#endregion
		#endregion
	}
}
