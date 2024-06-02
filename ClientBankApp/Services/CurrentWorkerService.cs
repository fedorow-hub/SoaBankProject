using ClientBankApp.Models.Worker;

namespace ClientBankApp.Services
{
	public class CurrentWorkerService : ICurrentWorkerService
	{
		public Worker Worker { get; set; }
	}
}
