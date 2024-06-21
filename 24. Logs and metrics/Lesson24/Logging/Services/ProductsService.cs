using Logging.Models;

namespace Logging.Services;

public sealed class ProductsService(ILogger<ProductsService> logger) : IProductsService
{
    public ProductItem GetById(int id)
    {
        var result = new ProductItem(id, "Test product");
        logger.LogInformation("Service {Service}: {@ProductById}", nameof(GetById), result);
        return result;
    }
}