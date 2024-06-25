using Accounts.API.Core;

namespace Accounts.API.Infrastructure;

public interface IAccountsRepository
{
    Task<IEnumerable<Account>> GetAllAccounts(bool isActiveOnly);
    Task<Account?> GetAccountByNumber(long number);
}