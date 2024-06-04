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
        public async Task<ActionResult<string>> Create([FromBody] CreateAccountDTO createAccountDTO)
        {
            var command = _mapper.Map<CreateAccountCommand>(createAccountDTO);

            string responce = await Mediator.Send(command);
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new CloseAccountCommand
            {
                Id = id
            };
            string responce = await Mediator.Send(command);
            return Ok(responce);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<string>> WithdrawMoney([FromBody] WithdrawMoneyFromAccountCommand withdrawCommand)
        {
            string responce = await Mediator.Send(withdrawCommand);
            return Ok(responce);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> AddMoney([FromBody] AddMoneyCommand addCommand)
        {
            string responce = await Mediator.Send(addCommand);
            return Ok(responce);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> TransactionMoney([FromBody] TransactionBetweenAccountCommand transactionCommand)
        {
            string responce = await Mediator.Send(transactionCommand);
            return Ok(responce);
        }
    }
}
