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
		private TypeOfAccount[] _accountTypes = { TypeOfAccount.Plain, TypeOfAccount.Credit, TypeOfAccount.Deposit };
		public TypeOfAccount[] AccountTypes
		{
			get => _accountTypes;
			set => Set(ref _accountTypes, value);
		}

		private string _type = "Рассчетный";
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
			// логика отправки соманды на сервер

			//var command = new CreateAccountCommand
			//{
			//	ClientId = _currentClient.Id,
			//	CreatedAt = DateTime.Now,
			//	AccountTerm = AccountTerm,
			//	Amount = Convert.ToDecimal(_amount),
			//	TypeOfAccount = TypeOfAccount.Parse(_type)
			//};

			//var message = await _mediator.Send(command);

			//MessageBox.Show(message);

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
