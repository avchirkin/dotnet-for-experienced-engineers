using Practice.Models;

namespace Practice;

public static class Session
{
    private static ProductsService _productsService = default!;
    
    public static async Task Run(ProductItemsDbContext context)
    {
        _productsService = new ProductsService(context);
    }
}