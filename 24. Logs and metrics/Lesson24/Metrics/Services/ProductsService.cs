using Metrics.Models;
using Prometheus;

namespace Metrics.Services;

public sealed class ProductsService : IProductsService
{
    private readonly Counter _invocationsCounter = Prometheus.Metrics.CreateCounter(
        "product_service_invocations_total", "Number of ProductsService invocations");
    public ProductItem GetById(int id)
    {
        _invocationsCounter.Inc();
        return new ProductItem(id, "Test product");
    }
}