using Tariffs.Application.Models;

namespace Tariffs.Application.Services.Abstractions;

public interface ITariffsService
{
    Task<TariffInfoDto?> GetTariffById(Guid id);
    Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo);
}