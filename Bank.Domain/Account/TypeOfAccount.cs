using Bank.Domain.Root;

namespace Bank.Domain.Account
{
	public sealed class TypeOfAccount : Enumeration
	{
		public static readonly TypeOfAccount Deposit = new(1, "Депозитный");

		public static readonly TypeOfAccount Credit = new(2, "Кредитный");

		public static readonly TypeOfAccount Plain = new(3, "Расчетный");

		private TypeOfAccount(int id, string name)
			: base(id, name)
		{
		}

		public static TypeOfAccount Parse(string value)
			=> value switch
			{
				"Депозитный" => Deposit,
				"Кредитный" => Credit,
				"Расчетный" => Plain,
				_ => throw new DomainExeption("Unknown account type")
			};

		public static TypeOfAccount ParseFromInt(int value)
		=> value switch
		{
			1 => Deposit,
			2 => Credit,
			3 => Plain,
			_ => throw new DomainExeption("Unknown account type")
		};
	}
}
