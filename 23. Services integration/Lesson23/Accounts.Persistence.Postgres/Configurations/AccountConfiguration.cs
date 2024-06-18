using Accounts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounts.Persistence.Postgres.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

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
        
        builder.Property(prop => prop.Balance)
            .HasColumnName("balance")
            .HasColumnType("decimal")
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