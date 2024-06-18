using Clients.Application.Models;

namespace Clients.Application.Services.Abstractions;

public interface IClientsService
{
    Task<ClientInfoDto?> GetClientById(Guid id);
    Task<ClientInfoDto> CreateClient(NewClientDto clientCreationInfo);
}