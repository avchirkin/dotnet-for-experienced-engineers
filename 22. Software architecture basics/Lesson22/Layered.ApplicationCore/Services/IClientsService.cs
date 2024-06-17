using Layered.ApplicationCore.Models;

namespace Layered.ApplicationCore.Services;

public interface IClientsService
{
    Task<ClientInfoDto> CreateClient(NewClientDto clientCreationInfo);
}