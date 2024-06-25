using Accounts.API.Services.Models;

namespace Accounts.API.Services;

public interface IAccountsService
{
    Task<IEnumerable<AccountDto>> GetAllAccounts(bool isActiveOnly);
    Task<AccountDto?> GetAccountByNumber(long number);
}