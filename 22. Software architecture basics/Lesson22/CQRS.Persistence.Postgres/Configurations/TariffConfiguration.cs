using CQRS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Persistence.Postgres.Configurations;

public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.ToTable("tariffs");

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
            .WithOne(prop => prop.Tariff);
    
    }
}