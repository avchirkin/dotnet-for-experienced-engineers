using Microsoft.EntityFrameworkCore;
using Tickets.Application.Models;
using Tickets.Application.Services.Abstractions;
using Tickets.Domain.Models;
using Tickets.Integrations.Accounts;
using Tickets.Integrations.Clients;
using Tickets.Integrations.Tariffs;
using Tickets.Persistence.Postgres;

namespace Tickets.Application.Services;

public sealed class TicketsService(
    TicketsDbContext context,
    IClientsServiceClient clientsServiceClient,
    IAccountsServiceClient accountsServiceClient,
    ITariffsServiceClient tariffsServiceClient) : ITicketsService
{
    public async Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo)
    {
        var (client, account, tariff) = await GetTicketData(
            ticketCreationInfo.ClientId, ticketCreationInfo.AccountId, ticketCreationInfo.TariffId);

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

        var ticketInfo = TicketInfoDto.FromEntity(entry.Entity);
        
        return ticketInfo with { ClientInfo = client, AccountInfo = account, TariffInfo = tariff };
    }

    public async Task<TicketInfoDto?> GetTicketInfo(Guid id)
    {
        var ticket = await context.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id.Equals(id));

        if (ticket == null) return null;

        var ticketInfo = TicketInfoDto.FromEntity(ticket);
        var (client, account, tariff) = await GetTicketData(
            ticketInfo.ClientId, ticketInfo.AccountId, ticketInfo.TariffId);

        return ticketInfo with { ClientInfo = client, AccountInfo = account, TariffInfo = tariff };
    }

    private async Task<(ClientInfoDto client, AccountInfoDto account, TariffInfoDto tariff)> GetTicketData(
        Guid clientId, Guid accountId, Guid tariffId)
    {
        var client = await clientsServiceClient.GetClientInfo(clientId);
        if (client == null) throw new InvalidOperationException("Client doesn't exist");

        var account = await accountsServiceClient.GetAccountInfo(accountId);
        if (account == null) throw new InvalidOperationException("Account doesn't exist");

        var tariff = await tariffsServiceClient.GetTariffInfo(tariffId);
        if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");

        return (client, account, tariff);
    }
}