namespace ProductItems.Terminal.Models;

public sealed record Category
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;
        
    // Navigation property
    public IEnumerable<ProductItem>? ProductItems { get; init; }
}