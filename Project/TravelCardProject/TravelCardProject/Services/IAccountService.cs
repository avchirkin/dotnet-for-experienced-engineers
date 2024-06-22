using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount();

        Task<AccountInfoDto?> GetAccountInfo(Guid id);
    }
}
