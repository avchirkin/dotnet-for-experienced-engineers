namespace RecordsBasics;

// Запись можно пометить как sealed во избежании наследования, аналогично тому,
// как это делается с обычными классами.
public sealed record ProductItem
{
    public Guid Id { get; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public Category Category { get; init; }

    public ProductItem(string name, string? description, Category category)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;
    }
}