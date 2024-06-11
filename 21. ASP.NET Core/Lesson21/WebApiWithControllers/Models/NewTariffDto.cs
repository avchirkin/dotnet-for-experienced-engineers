namespace WebApiWithControllers.Models;

public sealed record NewTariffDto
{
    public required string Name { get; init; }
}