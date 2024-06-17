namespace Onion.Application.Models;

public sealed record NewTariffDto
{
    public required string Name { get; init; }
}