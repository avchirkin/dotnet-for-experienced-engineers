using Tickets.Application.Models;

namespace Tickets.Integrations.Clients;

public interface IClientsServiceClient
{
    Task<ClientInfoDto?> GetClientInfo(Guid id);
}