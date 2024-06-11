namespace WebApiWithControllers.Models;

public sealed record NewClientDto
{
    public required string Name { get; init; }
}