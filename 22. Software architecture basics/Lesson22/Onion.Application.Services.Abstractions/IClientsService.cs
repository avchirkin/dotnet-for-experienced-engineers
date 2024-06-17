using Onion.Application.Models;

namespace Onion.Application.Services.Abstractions;

public interface IClientsService
{
    Task<ClientInfoDto> CreateClient(NewClientDto clientCreationInfo);
}