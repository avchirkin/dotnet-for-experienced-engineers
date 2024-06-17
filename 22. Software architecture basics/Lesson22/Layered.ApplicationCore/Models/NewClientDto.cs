namespace Layered.ApplicationCore.Models;

public sealed record NewClientDto
{
    public required string Name { get; init; }
}