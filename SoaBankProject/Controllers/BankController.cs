using Bank.Application.Bank.Commands;
using Bank.Domain.Bank;
using Microsoft.AspNetCore.Mvc;

namespace SoaBankProject.Controllers
{
	public class BankController : BaseController
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<SomeBank>> Create([FromBody] CreateBankCommand createBank)
		{
			SomeBank bank = await Mediator.Send(createBank);
			return Ok(bank);
		}
	}
}
