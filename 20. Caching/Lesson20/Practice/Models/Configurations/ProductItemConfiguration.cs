using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Practice.Models.Configurations;

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.ToTable("product_items");
        
        builder.HasKey(item => item.Id);

        builder.Property(item => item.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uuid");
        
        builder.Property(item => item.CategoryId)
            .IsRequired()
            .HasColumnName("category_id")
            .HasColumnType("uuid");
        
        builder.Property(item => item.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("text");
        
        builder.HasOne(item => item.Category)
            .WithMany(item => item.ProductItems)
            .HasForeignKey(item => item.CategoryId)
            .IsRequired();

        builder.HasMany(item => item.Props)
            .WithOne(item => item.ProductItem)
            .HasForeignKey(item => item.ProductItemId)
            .IsRequired();
    }
}