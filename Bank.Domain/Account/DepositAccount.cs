﻿namespace Bank.Domain.Account
{
	public sealed class DepositAccount : Account
	{
		/// <summary>
		/// процентная ставка
		/// </summary>
		public InterestRate InterestRate { get; set; } = null!;

		public DepositAccount()
		{

		}

		public DepositAccount(Guid id, Guid clientId, byte termOfMonth, decimal amount, DateTime timeOfCreated)
			: base(id, clientId, termOfMonth, amount, timeOfCreated, TypeOfAccount.Deposit)
		{
			InterestRate = SetInterestRate();
		}

		public DepositAccount(Guid id, Guid clientId, DateTime accountTerm, decimal amount, DateTime timeOfCreated)
			: base(id, clientId, accountTerm, amount, timeOfCreated, TypeOfAccount.Deposit)
		{
			InterestRate = SetInterestRate();
		}

		/// <summary>
		/// метод создания счета
		/// </summary>
		/// <param name="id"></param>
		/// <param name="clientId"></param>
		/// <param name="termOfMonth"></param>
		/// <param name="amount"></param>
		/// <param name="timeOfCreated"></param>
		/// <returns></returns>
		public static DepositAccount CreateDepositAccount(Guid id, Guid clientId, byte termOfMonth, decimal amount, DateTime timeOfCreated)
		{
			var newAccount = new DepositAccount(id, clientId, termOfMonth, amount, timeOfCreated);
			return newAccount;
		}

		/// <summary>
		/// установка значения процентной ставки
		/// </summary>
		/// <returns></returns>
		private static InterestRate SetInterestRate()
		{
			return InterestRate.MaxRate;
		}


		//private void MounthlyCapitalization()
		//{
		//    var mouthlyPercent = Amount * InterestRate.Id / 100 / 12;
		//    Amount += mouthlyPercent;
		//}  
	}
}
