using CQRS.Core.Entities;
using CQRS.Features.Models;
using CQRS.Persistence.Postgres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.Tickets.CreateTicket;

public class CreateTicketHandler(AutoTicketDbContext context)
    : IRequestHandler<CreateTicketCommand, CreateTicketResponse>
{
    public async Task<CreateTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var client = await context.Clients.FirstOrDefaultAsync(c => c.Id.Equals(request.ClientId));
        if (client == null) throw new InvalidOperationException("Client doesn't exist");

        var account = await context.Accounts.FirstOrDefaultAsync(c => c.Id.Equals(request.AccountId));
        if (account == null) throw new InvalidOperationException("Account doesn't exist");

        var tariff = await context.Tariffs.FirstOrDefaultAsync(c => c.Id.Equals(request.TariffId));
        if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");

        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Name = request.Name ?? string.Empty,
            AccountId = account.Id,
            ClientId = client.Id,
            TariffId = tariff.Id,
            ActivationDate = DateTime.Now,
        };

        var entry = await context.AddAsync(ticket);
        await context.SaveChangesAsync();

        return new CreateTicketResponse { TicketInfo = TicketInfoDto.FromEntity(entry.Entity) };
    }
}