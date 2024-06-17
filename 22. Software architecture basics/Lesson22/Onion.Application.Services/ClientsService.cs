using Onion.Application.Models;
using Onion.Application.Services.Abstractions;
using Onion.Domain.Models;
using Onion.Persistence.Postgres;

namespace Onion.Application.Services;

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