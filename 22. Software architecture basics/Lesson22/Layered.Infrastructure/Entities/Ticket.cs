namespace Layered.Infrastructure.Entities;

public record Ticket
{
    public Guid Id { get; init; }
    public Guid ClientId { get; init; }
    public Guid TariffId { get; init; }
    public Guid AccountId { get; init; }
    public required string Name { get; init; }
    public DateTime ActivationDate { get; init; }
    public DateTime? DeactivationDate { get; init; }
    public bool IsActive => DeactivationDate is null;

    public virtual Client Client { get; init; } = default!;
    public virtual Tariff Tariff { get; init; } = default!;
    public virtual Account Account { get; init; } = default!;
}