using Bank.Application.Interfaces;
using Bank.Domain.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Clients.Commands.CreateClient
{
	public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
	{
		private readonly IApplicationDbContext _dbContext;

		public CreateClientCommandHandler(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
		{
			var bank = await _dbContext.Bank.FirstOrDefaultAsync(cancellationToken);

			if (bank != null)
			{
				var client = new Client(request.Id,
					request.Firstname, request.Lastname, request.Patronymic, request.PhoneNumber,
					request.PassportSeries, request.PassportNumber, request.TotalIncomePerMounth, bank);

				await _dbContext.Clients.AddAsync(client, cancellationToken);
				client.AddDomainEvent(new CreateClientEvent
				{
					Id = client.Id,
					Firstname = request.Firstname,
					Lastname = request.Lastname,
					Patronymic = request.Patronymic
				});
			}

            var result = _dbContext.SaveChangesAsync(cancellationToken);

            return await result;
		}
	}
}
