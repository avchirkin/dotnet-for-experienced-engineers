using Microsoft.EntityFrameworkCore;
using Tariffs.Domain.Models;
using Tariffs.Persistence.Postgres.Configurations;

namespace Tariffs.Persistence.Postgres;

public class TariffsDbContext(DbContextOptions<TariffsDbContext> options) : DbContext(options)
{
    public DbSet<Tariff> Tariffs { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TariffConfiguration());
    }
}