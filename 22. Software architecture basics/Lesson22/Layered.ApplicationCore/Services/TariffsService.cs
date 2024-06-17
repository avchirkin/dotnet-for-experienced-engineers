using Layered.ApplicationCore.Models;
using Layered.Infrastructure.Entities;

namespace Layered.ApplicationCore.Services;

public sealed class TariffsService(AutoTicketDbContext context) : ITariffsService
{
    public async Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo)
    {
        var tariff = new Tariff
        {
            Id = Guid.NewGuid(),
            Name = tariffCreationInfo.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(tariff);
        await context.SaveChangesAsync();

        return TariffInfoDto.FromEntity(entry.Entity);
    }
}