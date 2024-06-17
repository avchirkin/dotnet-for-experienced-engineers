using Microsoft.EntityFrameworkCore;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class TravelCardService(TravelCardsDbContext context) : ITravelCardService
    {
        public async Task<TravelCardInfoDto> CreateTravelCard(NewTravelCardDto travelCardCreationInfo)
        {
            // Скорее всего, надо написать свои эксепшены
            var passenger = await context.Passengers.FirstOrDefaultAsync(c => c.Id.Equals(travelCardCreationInfo.PassengerId));
            if (passenger == null) throw new InvalidOperationException("Passenger doesn't exist");

            var account = await context.Accounts.FirstOrDefaultAsync(c => c.Id.Equals(travelCardCreationInfo.AccountId));
            if (account == null) throw new InvalidOperationException("Account doesn't exist");

            var tariff = await context.Tariffs.FirstOrDefaultAsync(c => c.Id.Equals(travelCardCreationInfo.TariffId));
            if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");

            DateTime activationDate = DateTime.Now;
            DateTime? expirationDate = null;
            if (tariff.Duration != null)
            {
                expirationDate = activationDate.AddDays((double)tariff.Duration);
            }

            var travelCard = new TravelCard
            {
                Id = Guid.NewGuid(),
                Number = travelCardCreationInfo.Number,
                AccountId = account.Id,
                TariffId = tariff.Id,
                PassengerId = passenger.Id,
                ActivationDate = activationDate,
                ExpirationDate = expirationDate,
                Status = TravelCardStatus.NotActivated,
                HighCoefficientActive = false,
            };

            var entry = await context.AddAsync(travelCard);
            await context.SaveChangesAsync();

            return TravelCardInfoDto.FromEntity(entry.Entity);
        }

        public async Task<TravelCardInfoDto?> GetTravelCardInfo(Guid id)
        {
            var travelCard = await context.TravelCards
                .Include(t => t.Passenger)
                .Include(t => t.Account)
                .Include(t => t.Tariff)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
            return travelCard == null ? null : TravelCardInfoDto.FromEntity(travelCard);
        }
    }
}
