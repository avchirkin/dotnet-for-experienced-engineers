namespace ProductItems.Terminal.Models;

public sealed record ProductItem
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public Guid CategoryId { get; init; }

    
    // Navigation properties
    public Category Category { get; init; } = default!;

    public IEnumerable<PropertyValue> Props { get; init; } = default!;
}
