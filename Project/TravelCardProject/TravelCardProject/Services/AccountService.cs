using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class AccountService(TravelCardsDbContext context) : IAccountService
    {
        public async Task<AccountInfoDto> CreateAccount(NewAccountDto accountCreationInfo)
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Balance = 0,
            };

            var entry = await context.AddAsync(account);
            await context.SaveChangesAsync();

            return AccountInfoDto.FromEntity(entry.Entity);
        }
    }
}
