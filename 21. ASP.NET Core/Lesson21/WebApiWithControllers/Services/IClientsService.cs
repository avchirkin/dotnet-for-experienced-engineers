using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public interface IClientsService
{
    Task<ClientInfoDto> CreateClient(NewClientDto clientCreationInfo);
}