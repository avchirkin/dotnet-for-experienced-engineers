using CQRS.Core.Entities;
using CQRS.Persistence.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Postgres;

public class AutoTicketDbContext(DbContextOptions<AutoTicketDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Tariff> Tariffs { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Ticket> Tickets { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new TariffConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    
    }
}