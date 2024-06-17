namespace Onion.Application.Models;

public sealed record NewClientDto
{
    public required string Name { get; init; }
}