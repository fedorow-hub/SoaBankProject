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
		public async Task<ActionResult> Create([FromBody] CreateClientCommand createClientCommand)
		{
			await Mediator.Send(createClientCommand);
			return Ok();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Update([FromBody] UpdateClientCommand updateClientCommand)
		{
			await Mediator.Send(updateClientCommand);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new DeleteClientCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
