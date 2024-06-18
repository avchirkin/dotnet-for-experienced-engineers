namespace Clients.Application.Models;

public sealed record NewClientDto
{
    public required string Name { get; init; }
}