namespace AsyncAwaitBasics.ProductItemsServiceExample;

public sealed class ProductItemsStorage
{
    public async Task<IEnumerable<ProductItem>> Fetch()
    {
        // Имитация получения товаров из БД...
        await Task.Delay(1_000);
        IEnumerable<ProductItem> products = new[]
        {
            new ProductItem(Guid.NewGuid(), "Мяч"),
            new ProductItem(Guid.NewGuid(), "Вратарские перчатки"),
            new ProductItem(Guid.NewGuid(), "Бутсы"),
            new ProductItem(Guid.NewGuid(), "Щитки"),
        };

        return products;
    }
}