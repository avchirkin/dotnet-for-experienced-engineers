using WebApiWithControllers.Entities;
using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

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