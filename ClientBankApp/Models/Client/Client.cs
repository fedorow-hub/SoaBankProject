namespace ClientBankApp.Models.Client
{
	public class Client
	{
		public Guid Id { get; set; }
		public string Firstname { get; set; } = null!;

		public string Lastname { get; set; } = null!;

		public string Patronymic { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string PassportSeries { get; set; } = null!;

		public string PassportNumber { get; set; } = null!;

		public string TotalIncomePerMounth { get; set; } = null!;
	}
}
