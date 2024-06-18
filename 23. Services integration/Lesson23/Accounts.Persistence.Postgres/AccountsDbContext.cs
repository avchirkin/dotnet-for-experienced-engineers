using Accounts.Domain.Models;
using Accounts.Persistence.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Persistence.Postgres;

public class AccountsDbContext(DbContextOptions<AccountsDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
}