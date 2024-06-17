using Onion.Application.Models;

namespace Onion.Application.Services.Abstractions;

public interface IAccountsService
{
    Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo);
}