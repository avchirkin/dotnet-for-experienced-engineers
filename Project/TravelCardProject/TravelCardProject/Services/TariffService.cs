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
            };

            var entry = await context.AddAsync(tariff);
            await context.SaveChangesAsync();

            return TariffInfoDto.FromEntity(entry.Entity);
        }
    }
}
