using MediatR;

namespace Bank.Application.Clients.Queries
{
	public record GetClientListQuery : IRequest<ClientListVm>;
}
