using Microsoft.EntityFrameworkCore;
using Tariffs.Application.Models;
using Tariffs.Application.Services.Abstractions;
using Tariffs.Domain.Models;
using Tariffs.Persistence.Postgres;

namespace Tariffs.Application.Services;

public sealed class TariffsService(TariffsDbContext context) : ITariffsService
{
    public async Task<TariffInfoDto?> GetTariffById(Guid id)
    {
        var entry = await context.Tariffs
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id.Equals(id));

        if (entry == null)
        {
            return null;
        }
        
        return TariffInfoDto.FromEntity(entry);
    }
    
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