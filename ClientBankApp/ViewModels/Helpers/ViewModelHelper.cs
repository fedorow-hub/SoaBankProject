using ClientBankApp.Models.Account;
using ClientBankApp.Models.Client;

namespace ClientBankApp.ViewModels.Helpers
{
	public static class ViewModelHelper
	{
		public static async Task<List<Account>> GetAccounts(Guid id)
		{
			// логика отправки запроса на сервер

			//var mediator = App.Host.Services.GetRequiredService<IMediator>();
			//var query = new GetAccountsQuery
			//{
			//	Id = id
			//};
			//var result = await mediator.Send(query);

			return null;
		}

		public static async Task<List<Client>> GetAllClients()
		{
			// логика отправки запроса на сервер

			//var mediator = App.Host.Services.GetRequiredService<IMediator>();
			//var query = new GetClientListQuery();
			//var result = await mediator.Send(query);

			return null;
		}
	}
}
