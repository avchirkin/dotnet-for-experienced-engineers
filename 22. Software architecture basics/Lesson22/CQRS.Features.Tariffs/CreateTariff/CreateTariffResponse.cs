using CQRS.Features.Models;

namespace CQRS.Features.Tariffs.CreateTariff;

public sealed record CreateTariffResponse
{
    public TariffInfoDto TariffInfo { get; init; } = default!;
}