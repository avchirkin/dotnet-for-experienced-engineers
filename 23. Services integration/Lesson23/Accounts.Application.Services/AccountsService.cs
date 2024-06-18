using Accounts.Application.Models;
using Accounts.Application.Services.Abstractions;
using Accounts.Domain.Models;
using Accounts.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Application.Services;

public sealed class AccountsService(AccountsDbContext context) : IAccountsService
{
    public async Task<AccountInfoDto?> GetAccountById(Guid id)
    {
        var entry = await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id.Equals(id));

        if (entry == null)
        {
            return null;
        }
        
        return AccountInfoDto.FromEntity(entry);
    }

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