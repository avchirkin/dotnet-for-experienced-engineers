namespace Onion.Application.Models;

public sealed record NewAccountDto
{
    public required string Name { get; init; }
}