using Accounts.API.Core;

namespace Accounts.API.Infrastructure;

public class AccountsRepository : IAccountsRepository
{
    private readonly IEnumerable<Account> _accounts = new[]
    {
        new Account(Guid.NewGuid(), Guid.NewGuid(), 100, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 101, false),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 102, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 103, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 104, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 105, false),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 106, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 107, true),
    };
    
    public Task<IEnumerable<Account>> GetAllAccounts(bool isActiveOnly = true)
    {
        var result = _accounts;
        if (isActiveOnly)
        {
            result = _accounts.Where(a => a.IsActive);
        }

        return Task.FromResult(result);
    }

    public Task<Account?> GetAccountByNumber(long number)
    {
        return Task.FromResult(_accounts.FirstOrDefault(a => a.Number.Equals(number)));
    }
}