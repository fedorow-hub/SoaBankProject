﻿using ClientBankApp.ViewModels.DialogViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ClientBankApp.ViewModels
{
	class ViewModelLocator
	{
		public LoginWindowViewModel LoginWindowModel =>
		App.Host.Services.GetRequiredService<LoginWindowViewModel>();
		public OperationsWindowViewModel OperationWindowModel =>
			App.Host.Services.GetRequiredService<OperationsWindowViewModel>();
		public OpenAccountViewModel OpenAccountModel =>
			App.Host.Services.GetRequiredService<OpenAccountViewModel>();
		public AccountInfoViewModel AccountViewModel =>
			App.Host.Services.GetRequiredService<AccountInfoViewModel>();
		public AddAndWithdrawalsViewModel AddAndWithdrawalsViewModel =>
			App.Host.Services.GetRequiredService<AddAndWithdrawalsViewModel>();
		public AddDialogViewModel AddDialogModel =>
			App.Host.Services.GetRequiredService<AddDialogViewModel>();
		public TransferBetweenOwnAccountsViewModel BetweenOwnAccounts =>
			App.Host.Services.GetRequiredService<TransferBetweenOwnAccountsViewModel>();
		public TransferBetweenOwnAccountsDialogViewModel TransferBetweenOwnAccounts =>
			App.Host.Services.GetRequiredService<TransferBetweenOwnAccountsDialogViewModel>();
		public TransferToOtherClientsAccountsViewModel TransferToOtherClientsAccounts =>
			App.Host.Services.GetRequiredService<TransferToOtherClientsAccountsViewModel>();
		public TransferToOtherClientsDialogViewModel TransferToOtherClientsDialog =>
			App.Host.Services.GetRequiredService<TransferToOtherClientsDialogViewModel>();
		public WithdrawalDialogViewModel WithdrawalDialog =>
			App.Host.Services.GetRequiredService<WithdrawalDialogViewModel>();
	}
}
