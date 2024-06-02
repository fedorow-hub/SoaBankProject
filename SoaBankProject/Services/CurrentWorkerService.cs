using Bank.Application.Interfaces;
using Bank.Domain.Worker;

namespace SoaBankProject.Services
{
	public class CurrentWorkerService : ICurrentWorkerService
	{
		public Worker Worker { get; set; }
	}
}
