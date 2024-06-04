using MediatR;

namespace Bank.Application.Clients.Commands.DeleteClient
{
	public record DeleteClientCommand : IRequest<int>
	{
		public Guid Id { get; init; }
	}
}
