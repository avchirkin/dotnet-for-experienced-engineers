using MediatR;

namespace CQRS.Features.Tariffs.CreateTariff;

public sealed record CreateTariffCommand : IRequest<CreateTariffResponse>
{
    public required string Name { get; init; }
}