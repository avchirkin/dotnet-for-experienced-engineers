using Clients.Domain.Models;
using Clients.Persistence.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Clients.Persistence.Postgres;

public class ClientsDbContext(DbContextOptions<ClientsDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
    }
}