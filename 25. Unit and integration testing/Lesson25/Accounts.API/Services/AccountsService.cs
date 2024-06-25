using Accounts.API.Infrastructure;
using Accounts.API.Services.Models;

namespace Accounts.API.Services;

public sealed class AccountsService(IAccountsRepository repository) : IAccountsService
{
    public async Task<IEnumerable<AccountDto>> GetAllAccounts(bool isActiveOnly = true)
    {
        var entities = await repository.GetAllAccounts(isActiveOnly);
        return entities.Select(e => new AccountDto(e.Number, e.IsActive));
    }

    public async Task<AccountDto?> GetAccountByNumber(long number)
    {
        var entity = await repository.GetAccountByNumber(number);
        return entity == null ? null : new AccountDto(entity.Number, entity.IsActive);
    }
}