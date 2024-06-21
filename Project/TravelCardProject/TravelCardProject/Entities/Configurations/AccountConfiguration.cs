using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelCardProject.Entities.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.Balance)
                .HasColumnName("balance")
                .HasColumnType("decimal");

            builder.HasOne(item => item.TravelCard)
                .WithOne(item => item.Account)
                .HasForeignKey<TravelCard>(item => item.AccountId);
        }
    }
}
