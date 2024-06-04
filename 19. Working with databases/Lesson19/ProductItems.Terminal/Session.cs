using ProductItems.Terminal.Models;

namespace ProductItems.Terminal;

public static class Session
{
    private static ProductsService _productsService = default!;
    
    public static async Task Run(ProductItemsDbContext context)
    {
        _productsService = new ProductsService(context);
        
        // Добавим товары, категории и характеристики в БД
        // await AddEntitiesToDb();
        
        // Извлечём данные о товарах из БД
        FetchProductItemsByCategory();
        // FetchProductItemsByPropValue();
        
        // Удаляем товар из БД вместе со связанными сущностями
        // await DeleteProductItemById();
    }
    
    private static async Task AddEntitiesToDb()
    {
        var category = DataFactory.CreateCategory();
        var productItem = DataFactory.CreateProductItem(category);
        var property = DataFactory.CreateProperty();
        var propertyValue = DataFactory.CreatePropertyValue(property, productItem);
            
        await _productsService.CreateCategory(category);
        await _productsService.CreateProduct(productItem);
        await _productsService.CreateProperty(property);
        await _productsService.AddPropertyValue(propertyValue);
    }
    
    private static void FetchProductItemsByCategory()
    {
        Console.WriteLine("\nSport items:");
        var sportProductItems = _productsService.GetProductItemsByCategory("Sports");
        foreach (var item in sportProductItems)
        {
            Console.WriteLine(item);
        }
    }
    
    private static void FetchProductItemsByPropValue()
    {
        var forPersonalUseItems = _productsService
            .GetProductItemsByPropValue("ForPersonalUse", "True");

        Console.WriteLine("\nItems for personal use:");
        foreach (var item in forPersonalUseItems)
        {
            Console.WriteLine(item);
        }
    }
    
    private static async Task DeleteProductItemById()
    {
        await _productsService.DeleteProductItemById(Guid.Parse("9de5a969-a063-4f96-a642-c0c3c02476ea"));
    }
}