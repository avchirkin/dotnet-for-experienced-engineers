using ProductItems.Terminal.Models;

namespace ProductItems.Terminal;

public static class Session
{
    private static ProductItemsDbContext _context = default!;
    private static readonly ProductsService ProductsService = new(_context);
    
    public static async Task Run(ProductItemsDbContext context)
    {
        _context = context;
        
        // Добавим товары, категории и характеристики в БД
        await AddEntitiesToDb();
        
        // Извлечём данные о товарах из БД
        // FetchProductItemsByCategory();
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
            
        await ProductsService.CreateCategory(category);
        await ProductsService.CreateProduct(productItem);
        await ProductsService.CreateProperty(property);
        await ProductsService.AddPropertyValue(propertyValue);
    }
    
    private static void FetchProductItemsByCategory()
    {
        Console.WriteLine("\nSport items:");
        var sportProductItems = ProductsService.GetProductItemsByCategory("Sports");
        foreach (var item in sportProductItems)
        {
            Console.WriteLine(item);
        }
    }
    
    private static void FetchProductItemsByPropValue()
    {
        var forPersonalUseItems = ProductsService
            .GetProductItemsByPropValue("ForPersonalUse", "True");

        Console.WriteLine("\nItems for personal use:");
        foreach (var item in forPersonalUseItems)
        {
            Console.WriteLine(item);
        }
    }
    
    private static async Task DeleteProductItemById()
    {
        await ProductsService.DeleteProductItemById(Guid.Parse("9de5a969-a063-4f96-a642-c0c3c02476ea"));
    }
}