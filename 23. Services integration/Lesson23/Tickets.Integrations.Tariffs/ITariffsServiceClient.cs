using Tickets.Application.Models;

namespace Tickets.Integrations.Tariffs;

public interface ITariffsServiceClient
{
    Task<TariffInfoDto?> GetTariffInfo(Guid id);
}