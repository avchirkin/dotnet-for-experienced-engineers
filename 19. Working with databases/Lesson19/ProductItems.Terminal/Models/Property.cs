namespace ProductItems.Terminal.Models;

public sealed record Property {
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    
    // Navigation property
    public IEnumerable<PropertyValue> Values { get; init; } = default!;
}