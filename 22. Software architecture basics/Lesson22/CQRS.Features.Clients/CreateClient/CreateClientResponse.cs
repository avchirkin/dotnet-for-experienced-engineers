using CQRS.Features.Models;

namespace CQRS.Features.Clients.CreateClient;

public sealed record CreateClientResponse
{
    public ClientInfoDto ClientInfo { get; init; } = default!;
}