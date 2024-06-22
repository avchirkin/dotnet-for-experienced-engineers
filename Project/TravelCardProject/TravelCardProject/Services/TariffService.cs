using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class TariffService(TravelCardsDbContext context) : ITariffService
    {
        public async Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo)
        {
            var tariff = new Tariff
            {
                Id = Guid.NewGuid(),
                Name = tariffCreationInfo.Name,
                Duration = tariffCreationInfo.Duration,
                UndergroundTripPrice = tariffCreationInfo.UndergroundTripPrice,
                GroundTripPrice = tariffCreationInfo.GroundTripPrice,
                ActivationPrice = tariffCreationInfo.ActivationPrice,
            };

            var entry = await context.AddAsync(tariff);
            await context.SaveChangesAsync();

            return TariffInfoDto.FromEntity(entry.Entity);
        }

        public async Task<TariffInfoDto?> GetTariffInfo(Guid id)
        {
            var tariff = await context.Tariffs
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
            return tariff == null ? null : TariffInfoDto.FromEntity(tariff);
        }
    }
}
