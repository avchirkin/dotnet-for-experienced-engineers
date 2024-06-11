using WebApiWithControllers.Entities;
using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

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