using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductItems.Terminal.Models.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

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

        builder.HasMany(item => item.ProductItems)
            .WithOne(item => item.Category)
            .HasForeignKey(item => item.CategoryId)
            .IsRequired();
    }
}