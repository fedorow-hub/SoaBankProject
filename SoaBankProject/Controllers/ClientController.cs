using Bank.Application.Clients.Commands.CreateClient;
using Bank.Application.Clients.Commands.DeleteClient;
using Bank.Application.Clients.Commands.UpdateClient;
using Bank.Application.Clients.Queries;
using Microsoft.AspNetCore.Mvc;

namespace SoaBankProject.Controllers
{
	public class ClientController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ClientListVm>> GetAll()
		{
			var query = new GetClientListQuery();

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<int>> Create([FromBody] CreateClientCommand createClientCommand)
		{
            int responce = await Mediator.Send(createClientCommand);
            return Ok(responce);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<int>> Update([FromBody] UpdateClientCommand updateClientCommand)
		{
            int responce = await Mediator.Send(updateClientCommand);
            return Ok(responce);
		}

		[HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Delete(Guid id)
		{
			var command = new DeleteClientCommand
			{
				Id = id
			};
			int responce = await Mediator.Send(command);
			return Ok(responce);
		}
	}
}
