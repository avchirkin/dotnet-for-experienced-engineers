namespace CQRS.Core.Entities;

public record Account
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public DateTime ActivationDate { get; init; }
    public DateTime? DeactivationDate { get; init; }
    public bool IsActive => DeactivationDate is null;
    public decimal Balance { get; init; }

    public virtual Ticket Ticket { get; init; } = default!;
}