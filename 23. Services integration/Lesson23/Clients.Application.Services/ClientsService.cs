using Clients.Application.Models;
using Clients.Application.Services.Abstractions;
using Clients.Domain.Models;
using Clients.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Clients.Application.Services;

public sealed class ClientsService(ClientsDbContext context) : IClientsService
{
    public async Task<ClientInfoDto?> GetClientById(Guid id)
    {
        var entry = await context.Clients
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id.Equals(id));

        if (entry == null)
        {
            return null;
        }
        
        return ClientInfoDto.FromEntity(entry);
    }
    
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