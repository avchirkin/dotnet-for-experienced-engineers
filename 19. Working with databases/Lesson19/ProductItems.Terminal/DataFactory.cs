using ProductItems.Terminal.Models;

namespace ProductItems.Terminal;

public static class DataFactory
{
    public static Category CreateCategory()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Sports"
        };

        return category;
    }
    
    public static ProductItem CreateProductItem(Category category)
    {
        var product = new ProductItem
        {
            Id = Guid.NewGuid(),
            CategoryId = category.Id,
            Name = "Boxing gloves"
        };

        return product;
    }

    public static Property CreateProperty()
    {
        var prop = new Property
        {
            Id = Guid.NewGuid(),
            Name = "ForPersonalUse"
        };

        return prop;
    }
    
    public static PropertyValue CreatePropertyValue(Property property, ProductItem productItem)
    {
        var propValue = new PropertyValue
        {
            Id = Guid.NewGuid(),
            PropertyId = property.Id,
            ProductItemId = productItem.Id,
            Value = true.ToString()
        };

        return propValue;
    }
}