using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Models;
using Tickets.Persistence.Postgres.Configurations;

namespace Tickets.Persistence.Postgres;

public class TicketsDbContext(DbContextOptions<TicketsDbContext> options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    }
}