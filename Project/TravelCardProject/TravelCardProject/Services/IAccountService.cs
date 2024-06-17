using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface IAccountService
    {
        Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo);
    }
}
