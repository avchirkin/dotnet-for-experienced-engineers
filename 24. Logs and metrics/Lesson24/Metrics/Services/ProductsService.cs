using Metrics.Models;

namespace Metrics.Services;

public sealed class ProductsService(ILogger<ProductsService> logger) : IProductsService
{
    public ProductItem GetById(int id)
    {
        logger.LogInformation($"Service - GetById {id}");
        return new ProductItem(id, "Test product");
    }
}