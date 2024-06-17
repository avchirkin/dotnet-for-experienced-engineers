using Onion.Application.Models;
using Onion.Application.Services.Abstractions;
using Onion.Domain.Models;
using Onion.Persistence.Postgres;

namespace Onion.Application.Services;

public sealed class AccountsService(AutoTicketDbContext context) : IAccountsService
{
    public async Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo)
    {
        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = accountCreationInfo.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(account);
        await context.SaveChangesAsync();

        return AccountInfoDto.FromEntity(entry.Entity);
    }
}