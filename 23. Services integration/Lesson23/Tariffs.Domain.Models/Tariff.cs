namespace Tariffs.Domain.Models;

public record Tariff
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public DateTime ActivationDate { get; init; }
    public DateTime? DeactivationDate { get; init; }
    public bool IsActive => DeactivationDate is null;
}