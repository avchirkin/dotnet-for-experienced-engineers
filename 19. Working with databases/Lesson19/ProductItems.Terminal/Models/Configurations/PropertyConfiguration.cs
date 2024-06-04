using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductItems.Terminal.Models.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("properties");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(item => item.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(250)
            .IsRequired();

        builder.HasMany(item => item.Values)
            .WithOne(item => item.Property)
            .HasForeignKey(item => item.PropertyId);
    }
}