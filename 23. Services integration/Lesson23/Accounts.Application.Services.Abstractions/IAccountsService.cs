using Accounts.Application.Models;

namespace Accounts.Application.Services.Abstractions;

public interface IAccountsService
{
    Task<AccountInfoDto?> GetAccountById(Guid id);
    
    Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo);
}