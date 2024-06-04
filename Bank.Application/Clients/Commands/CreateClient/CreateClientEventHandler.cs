using MediatR;
using Serilog;

namespace Bank.Application.Clients.Commands.CreateClient
{
    public class CreateClientEventHandler : INotificationHandler<CreateClientEvent>
    {
        public Task Handle(CreateClientEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Добавлен клиент {notification.Id} {notification.Lastname} {notification.Firstname} {notification.Patronymic}");
            return Task.CompletedTask;
        }
    }
}
