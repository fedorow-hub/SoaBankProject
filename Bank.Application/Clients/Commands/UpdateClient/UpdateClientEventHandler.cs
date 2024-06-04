using MediatR;
using Serilog;

namespace Bank.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientEventHandler : INotificationHandler<UpdateClientEvent>
    {
        public Task Handle(UpdateClientEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Изменены данные клиента {notification.Id}");
            return Task.CompletedTask;
        }
    }
}
