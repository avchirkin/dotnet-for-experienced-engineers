using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Persistence.Postgres.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.Id)
            .HasColumnName("id")
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

        builder.HasMany(prop => prop.Tickets)
            .WithOne(prop => prop.Client);
    
    }
}