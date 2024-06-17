namespace Layered.ApplicationCore.Models;

public sealed record NewAccountDto
{
    public required string Name { get; init; }
}