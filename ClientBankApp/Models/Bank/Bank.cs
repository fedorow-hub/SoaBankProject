using ClientBankApp.Models.Root;

namespace ClientBankApp.Models.Bank
{
	public sealed class Bank : Entity
	{
		/// <summary>
		/// название банка
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// капиталл банка в рублях
		/// </summary>
		public decimal Capital { get; private set; }

		/// <summary>
		/// дата создания банка
		/// </summary>
		public DateTime DateOfCreation { get; private set; }

		/// <summary>
		/// одиночный объект банка
		/// </summary>
		private static volatile Bank? _uniqueInstanceOfBank;

		private static readonly object SyncRoot = new();

		private Bank(string name, decimal capital, DateTime dateOfCreation)
		{
			Name = name;
			//Clients = new List<Client.Client>();
			Capital = capital;
			DateOfCreation = dateOfCreation;
		}

		/// <summary>
		/// метод создания одиночного объекта банка
		/// </summary>
		/// <param name="name"></param>
		/// <param name="capital"></param>
		/// <param name="dateOfCreation"></param>
		/// <returns></returns>
		public static Bank CreateBank(string name, decimal capital, DateTime dateOfCreation)
		{
			if (_uniqueInstanceOfBank != null) return _uniqueInstanceOfBank;
			lock (SyncRoot)
			{
				_uniqueInstanceOfBank = new Bank(name, capital, dateOfCreation);
			}
			return _uniqueInstanceOfBank;
		}

		/// <summary>
		/// добавление средств в капиталл банка
		/// </summary>
		/// <param name="money"></param>
		public void AddMoneyToCapital(decimal money)
		{
			Capital += money;
		}

		/// <summary>
		/// снятие средств из капиталла банка
		/// </summary>
		/// <param name="money"></param>
		/// <exception cref="DomainExeption"></exception>
		public void WithdrawalMoneyFromCapital(decimal money)
		{
			if (Capital >= money)
			{
				Capital -= money;
			}
			//else throw new DomainExeption("Недостаточно средств банка");
		}
	}
}
