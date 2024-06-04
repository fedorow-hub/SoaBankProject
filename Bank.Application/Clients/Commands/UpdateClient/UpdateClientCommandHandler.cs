using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Bank.Application.Clients.Commands.UpdateClient
{
	public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public UpdateClientCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
		{
			var client = _context.Clients.FirstOrDefault(r => r.Id == request.Id);

			client?.ChangeFirstname(request.Firstname);
			client?.ChangeLastname(request.Lastname);
			client?.ChangePatronymic(request.Patronymic);
			client?.ChangePhoneNumber(request.PhoneNumber);
			client?.ChangePassportSeries(request.PassportSeries);
			client?.ChangePassportNumber(request.PassportNumber);
			client?.ChangeTotalIncomePerMounth(request.TotalIncomePerMounth.ToString(CultureInfo.CurrentCulture));

			client?.AddDomainEvent(new UpdateClientEvent
            {
                Id = request.Id
            });

            var result = _context.SaveChangesAsync(cancellationToken);

            return await result;
		}
	}
}
