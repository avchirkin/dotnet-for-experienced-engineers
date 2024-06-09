namespace Practice.Models;

public sealed record PropertyValue
{
    public Guid Id { get; init; }
    
    public Guid ProductItemId { get; init; }

    public Guid PropertyId { get; init; }
    
    public string? Value { get; init; }
    
    // Navigation properties
    public ProductItem ProductItem { get; init; } = default!;

    public Property Property { get; init; } = default!;
}