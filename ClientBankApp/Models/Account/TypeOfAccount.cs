namespace ClientBankApp.Models.Account
{
	public sealed class TypeOfAccount
	{
		public static readonly TypeOfAccount Deposit = new(1, "Депозитный");

		public static readonly TypeOfAccount Credit = new(2, "Кредитный");

		public static readonly TypeOfAccount Plain = new(3, "Расчетный");

		private TypeOfAccount(int id, string name)
		{
		}

		public static TypeOfAccount Parse(string value)
			=> value switch
			{
				"Депозитный" => Deposit,
				"Кредитный" => Credit,
				"Расчетный" => Plain
			};
	}
}
