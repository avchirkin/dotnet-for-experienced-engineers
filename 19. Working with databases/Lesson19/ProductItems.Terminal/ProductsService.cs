using Microsoft.EntityFrameworkCore;
using ProductItems.Terminal.Models;

namespace ProductItems.Terminal;

public class ProductsService(ProductItemsDbContext context)
{
    public async Task CreateCategory(Category item)
    {
        await context.AddAsync(item);
        await context.SaveChangesAsync();
    }
    
    public async Task CreateProduct(ProductItem item)
    {
        await context.AddAsync(item);
        await context.SaveChangesAsync();
    }
    
    public async Task CreateProperty(Property item)
    {
        await context.AddAsync(item);
        await context.SaveChangesAsync();
    }
    
    public async Task AddPropertyValue(PropertyValue item)
    {
        await context.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public IEnumerable<ProductItem> GetProductItemsByCategory(string categoryName)
    {
        var query = context.ProductItems
            .Where(item => item.Category.Name.Equals(categoryName))
            .Include(item => item.Category)
            .Include(item => item.Props)
            .AsNoTracking();
        
        // Console.WriteLine(query.ToQueryString());

        return query;
    }
    
    public IEnumerable<ProductItem> GetProductItemsByPropValue(string propName, string value)
    {
        var query = context.ProductItems
            .Where(item => item.Props.Any(prop => prop.Property.Name == propName && prop.Value == value))
            .Include(item => item.Category)
            .Include(item => item.Props)
            .AsNoTracking();
        
        // Console.WriteLine(query.ToQueryString());

        return query;
    }
}