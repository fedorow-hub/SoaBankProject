using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Clients.Commands.DeleteClient
{
	public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public DeleteClientCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
		{

			var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
			if (client != null)
			{
				_context.Clients.Remove(client);
			}

			var result = _context.SaveChangesAsync(cancellationToken);

			return await result;
		}
	}
}
