using Microsoft.EntityFrameworkCore;
using WebApiWithControllers.Entities;
using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public sealed class TicketsService(AutoTicketDbContext context) : ITicketsService
{
    public async Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo)
    {
        var client = await context.Clients.FirstOrDefaultAsync(c => c.Id.Equals(ticketCreationInfo.ClientId));
        if (client == null) throw new InvalidOperationException("Client doesn't exist");
        
        var account = await context.Accounts.FirstOrDefaultAsync(c => c.Id.Equals(ticketCreationInfo.AccountId));
        if (account == null) throw new InvalidOperationException("Account doesn't exist");
        
        var tariff = await context.Tariffs.FirstOrDefaultAsync(c => c.Id.Equals(ticketCreationInfo.TariffId));
        if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");
        
        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Name = ticketCreationInfo.Name ?? string.Empty,
            AccountId = account.Id,
            ClientId = client.Id,
            TariffId = tariff.Id,
            ActivationDate = DateTime.Now,
        };

        var entry = await context.AddAsync(ticket);
        await context.SaveChangesAsync();

        return TicketInfoDto.FromEntity(entry.Entity);
    }

    public async Task<TicketInfoDto?> GetTicketInfo(Guid id)
    {
        var ticket = await context.Tickets
            .Include(t => t.Client)
            .Include(t => t.Account)
            .Include(t => t.Tariff)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id.Equals(id));
        return ticket == null ? null : TicketInfoDto.FromEntity(ticket);
    }
}