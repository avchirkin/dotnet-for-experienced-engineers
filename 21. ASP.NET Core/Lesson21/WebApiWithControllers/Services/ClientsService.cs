using WebApiWithControllers.Entities;
using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public sealed class ClientsService(AutoTicketDbContext context) : IClientsService
{
    public async Task<ClientInfoDto> CreateClient(NewClientDto clientCreationInfo)
    {
        var client = new Client
        {
            Id = Guid.NewGuid(),
            Name = clientCreationInfo.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(client);
        await context.SaveChangesAsync();

        return ClientInfoDto.FromEntity(entry.Entity);
    }
}