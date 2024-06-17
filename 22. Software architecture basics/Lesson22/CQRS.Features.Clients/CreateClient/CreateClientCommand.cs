using MediatR;

namespace CQRS.Features.Clients.CreateClient;

public sealed record CreateClientCommand : IRequest<CreateClientResponse>
{
    public required string Name { get; init; }
}