using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Persistence.Postgres.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(prop => prop.ClientId)
            .HasColumnName("client_id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(prop => prop.TariffId)
            .HasColumnName("tariff_id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(prop => prop.AccountId)
            .HasColumnName("account_id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(prop => prop.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Ignore(prop => prop.IsActive);
        
        builder.Property(prop => prop.ActivationDate)
            .HasColumnName("activation_date")
            .HasColumnType("timestamp")
            .IsRequired();
        
        builder.Property(prop => prop.DeactivationDate)
            .HasColumnName("deactivation_date")
            .HasColumnType("timestamp");
    
    }
}