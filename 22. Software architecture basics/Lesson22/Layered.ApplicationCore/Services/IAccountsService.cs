using Layered.ApplicationCore.Models;

namespace Layered.ApplicationCore.Services;

public interface IAccountsService
{
    Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo);
}