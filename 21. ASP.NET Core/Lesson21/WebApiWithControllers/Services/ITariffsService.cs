using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public interface ITariffsService
{
    Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo);
}