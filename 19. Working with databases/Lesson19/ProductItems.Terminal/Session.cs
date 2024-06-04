using ProductItems.Terminal.Models;

namespace ProductItems.Terminal;

public static class Session
{
    public static async Task Run(ProductItemsDbContext context)
    {
        var productsService = new ProductsService(context);
        
        // Добавим товары, категории и характеристики в БД
        await DealWithContext();
        
        // Извлечём данные о товарах из БД
        FetchItems();
        
        async Task DealWithContext()
        {
            var category = DataFactory.CreateCategory();
            var productItem = DataFactory.CreateProductItem(category);
            var property = DataFactory.CreateProperty();
            var propertyValue = DataFactory.CreatePropertyValue(property, productItem);
            
            await productsService.CreateCategory(category);
            await productsService.CreateProduct(productItem);
            await productsService.CreateProperty(property);
            await productsService.AddPropertyValue(propertyValue);
        }

        void FetchItems()
        {
            Console.WriteLine("\nSport items:");
            var sportProductItems = productsService.GetProductItemsByCategory("Sports");
            foreach (var item in sportProductItems)
            {
                Console.WriteLine(item);
            }

            var forPersonalUseItems = productsService
                .GetProductItemsByPropValue("ForPersonalUse", "True");

            Console.WriteLine("\nItems for personal use:");
            foreach (var item in forPersonalUseItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}