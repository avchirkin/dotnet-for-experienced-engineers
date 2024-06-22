using Microsoft.EntityFrameworkCore;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class AccountService(TravelCardsDbContext context) : IAccountService
    {
        public async Task<Account> CreateAccount()
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Balance = 0,
            };

            await context.AddAsync(account);
            await context.SaveChangesAsync();

            return account;
        }

        public async Task<AccountInfoDto?> GetAccountInfo(Guid id)
        {
            var account = await context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
            return account == null ? null : AccountInfoDto.FromEntity(account);
        }
    }
}
