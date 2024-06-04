using Microsoft.EntityFrameworkCore;
using ProductItems.Terminal.Models.Configurations;

namespace ProductItems.Terminal.Models;

public class ProductItemsDbContext : DbContext
{
    public DbSet<ProductItem> ProductItems { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Property> Properties { get; set; } = default!;
    public DbSet<PropertyValue> PropertyValues { get; set; } = default!;

    public ProductItemsDbContext(DbContextOptions<ProductItemsDbContext> options)
        : base (options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyValueConfiguration());
    }
}