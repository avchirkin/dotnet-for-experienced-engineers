using Tickets.Application.Models;

namespace Tickets.Integrations.Accounts;

public interface IAccountsServiceClient
{
    Task<AccountInfoDto?> GetAccountInfo(Guid id);
}