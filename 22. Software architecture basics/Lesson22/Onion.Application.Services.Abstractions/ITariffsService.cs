using Onion.Application.Models;

namespace Onion.Application.Services.Abstractions;

public interface ITariffsService
{
    Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo);
}