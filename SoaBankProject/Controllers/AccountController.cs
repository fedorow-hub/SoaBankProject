using AutoMapper;
using Bank.Application.Accounts;
using Bank.Application.Accounts.Commands.AddMoney;
using Bank.Application.Accounts.Commands.CloseAccount;
using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Accounts.Commands.TransactionBetweenAccounts;
using Bank.Application.Accounts.Commands.WithdrawMoneyFromAccount;
using Bank.Application.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;
using SoaBankProject.Models;

namespace SoaBankProject.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IMapper _mapper;

		public AccountController(IMapper mapper)
		{
			_mapper = mapper;

		}
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<AccountListVm>> GetAll(Guid id)
		{
			var query = new GetAccountsQuery
			{
				Id = id
			};

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult> Create([FromBody] CreateAccountDTO createAccountDTO)
		{
			var command = _mapper.Map<CreateAccountCommand>(createAccountDTO);
			await Mediator.Send(command);
			return Ok();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new CloseAccountCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> WithdrawMoney([FromBody] WithdrawMoneyFromAccountCommand withdrawCommand)
		{
			await Mediator.Send(withdrawCommand);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> AddMoney([FromBody] AddMoneyCommand addCommand)
		{
			await Mediator.Send(addCommand);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> TransactionMoney([FromBody] TransactionBetweenAccountCommand transactionCommand)
		{
			await Mediator.Send(transactionCommand);
			return NoContent();
		}
	}
}
