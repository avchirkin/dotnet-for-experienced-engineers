namespace AsyncAwaitBasics.ProductItemsServiceExample;

public sealed class ProductItemsService
{
    private readonly ProductItemsStorage _storage = new();

    public async Task<IEnumerable<ProductItem>> GetProducts()
    {
        // Асинхронный запрос в репозиторий...
        var products = await _storage.Fetch();

        // Здесь может быть логика фильтрации/маппинга полученных сущностей на DTO...
        
        return products;
    }
}