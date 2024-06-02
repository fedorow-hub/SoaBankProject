using ClientBankApp.Models.Root;

namespace ClientBankApp.Models.Account
{
	public abstract class Account: Entity
	{
		/// <summary>
		/// идентификационный номер клиента, которому принадлежит счет
		/// </summary>
		public Guid ClientId { get; private set; }

		/// <summary>
		/// дата и время создания счета
		/// </summary>
		public DateTime TimeOfCreated { get; private set; }

		/// <summary>
		/// сумма, лежащая на счете
		/// </summary>
		public decimal Amount { get; protected set; }

		/// <summary>
		/// дата, до которой действует счет
		/// </summary>
		public DateTime AccountTerm { get; private set; }

		/// <summary>
		/// действующий или закрытый счет
		/// </summary>
		public bool IsExistance { get; private set; }

		public TypeOfAccount Type { get; private set; } = null!;

		public Account()
		{

		}

		public Account(Guid clientId, byte termOfMonth, decimal amount, DateTime timeOfCreated, TypeOfAccount type)
		{
			AccountTerm = timeOfCreated.AddMonths(termOfMonth);
			ClientId = clientId;
			TimeOfCreated = timeOfCreated;
			Amount = amount;
			IsExistance = true;
			Type = type;
		}

		public Account(Guid id, Guid clientId, byte termOfMonth, decimal amount, DateTime timeOfCreated, TypeOfAccount type)
		{
			AccountTerm = timeOfCreated.AddMonths(termOfMonth);
			ClientId = clientId;
			TimeOfCreated = timeOfCreated;
			Amount = amount;
			IsExistance = true;
			Type = type;
		}
	}
}
