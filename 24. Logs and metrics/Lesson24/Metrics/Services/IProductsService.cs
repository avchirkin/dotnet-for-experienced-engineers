using Metrics.Models;

namespace Metrics.Services;

public interface IProductsService
{
    ProductItem GetById(int id);
}