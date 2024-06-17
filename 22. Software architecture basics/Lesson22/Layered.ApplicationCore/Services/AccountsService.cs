using Layered.ApplicationCore.Models;
using Layered.Infrastructure.Entities;

namespace Layered.ApplicationCore.Services;

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