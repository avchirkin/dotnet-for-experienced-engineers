using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Practice.Models.Configurations;

public class PropertyValueConfiguration : IEntityTypeConfiguration<PropertyValue>
{
    public void Configure(EntityTypeBuilder<PropertyValue> builder)
    {
        builder.ToTable("property_values");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.PropertyId)
            .HasColumnName("property_id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(item => item.ProductItemId)
            .HasColumnName("product_item_id")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(item => item.Value)
            .HasColumnName("value")
            .HasColumnType("varchar")
            .HasMaxLength(3000);

        builder.HasOne(item => item.Property)
            .WithMany(item => item.Values)
            .HasForeignKey(item => item.PropertyId)
            .IsRequired();
        
        builder.HasOne(item => item.ProductItem)
            .WithMany(item => item.Props)
            .HasForeignKey(item => item.ProductItemId)
            .IsRequired();
    }
}