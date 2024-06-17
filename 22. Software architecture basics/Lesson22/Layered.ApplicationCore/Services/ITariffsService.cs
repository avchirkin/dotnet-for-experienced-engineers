using Layered.ApplicationCore.Models;

namespace Layered.ApplicationCore.Services;

public interface ITariffsService
{
    Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo);
}