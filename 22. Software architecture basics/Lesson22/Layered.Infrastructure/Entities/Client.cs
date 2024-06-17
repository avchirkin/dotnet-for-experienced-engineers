namespace Layered.Infrastructure.Entities;

public record Client
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public DateTime ActivationDate { get; init; }
    public DateTime? DeactivationDate { get; init; }
    public bool IsActive => DeactivationDate is null;

    public virtual IEnumerable<Ticket> Tickets { get; init; } = default!;
}