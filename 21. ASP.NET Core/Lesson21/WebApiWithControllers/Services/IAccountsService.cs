using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public interface IAccountsService
{
    Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo);
}