using Logging.Models;

namespace Logging.Services;

public interface IProductsService
{
    ProductItem GetById(int id);
}