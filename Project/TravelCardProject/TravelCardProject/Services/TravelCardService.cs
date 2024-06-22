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

            // Что-то сомнительное, как будто, стоит сделать по-другому
            var accountService = new AccountService(context);
            var account = await accountService.CreateAccount();

            var travelCard = new TravelCard
            {
                Id = Guid.NewGuid(),
                Number = travelCardCreationInfo.Number,
                AccountId = account.Id,
                PassengerId = passenger.Id,
                Status = TravelCardStatus.NotActivated,
                HighCoefficientActive = false,
                IsPaused = false,
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

        public async void ActivateTravelCard(Guid travelCardId, Guid passengerId, Guid tariffId)
        {
            var travelCard = await context.TravelCards.FirstOrDefaultAsync(c => c.Id.Equals(travelCardId));
            if (travelCard == null) throw new InvalidOperationException("TravelCard doesn't exist");

            var passenger = await context.Passengers.FirstOrDefaultAsync(c => c.Id.Equals(passengerId));
            // Тут, по идее, нужно создать пользователя
            if (passenger == null) throw new InvalidOperationException("Passenger doesn't exist");

            var tariff = await context.Tariffs.FirstOrDefaultAsync(c => c.Id.Equals(tariffId));
            if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");

            DateTime activationDate = DateTime.Now;
            DateTime? expirationDate = null;
            if (tariff.Duration != null)
            {
                expirationDate = activationDate.AddDays((double)tariff.Duration);
            }

            travelCard.ActivationDate = activationDate;
            travelCard.ExpirationDate = expirationDate;
            travelCard.PassengerId = passenger.Id;
            // Возможно, стоило вызвать метод ниже, но, как будто, порядок действий не совсем корректный выходит - две проверки наличия ЭПБ, плюс проверка тарифа либо в методе, либо тоже дважды
            travelCard.TariffId = tariff.Id;
            travelCard.TariffUpdateDate = DateTime.Now;
            await context.SaveChangesAsync();
        }
        
        // Возможно, нужны проверки активности ЭПБ - а там и даты, и всякое
        public async void SetTariffToTravelCard(Guid travelCardId, Guid tariffId)
        {
            var travelCard = await context.TravelCards.FirstOrDefaultAsync(c => c.Id.Equals(travelCardId));
            if (travelCard == null) throw new InvalidOperationException("TravelCard doesn't exist");

            if (travelCard.TariffUpdateDate != null && ((DateTime)travelCard.TariffUpdateDate).AddDays(1) <= DateTime.Now)
            {
                var tariff = await context.Tariffs.FirstOrDefaultAsync(c => c.Id.Equals(tariffId));
                if (tariff == null) throw new InvalidOperationException("Tariff doesn't exist");

                travelCard.TariffId = tariff.Id;
                travelCard.TariffUpdateDate = DateTime.Now;
                await context.SaveChangesAsync();
            } 
            else
            {
                throw new InvalidOperationException("Tariff update is not available at current time");
            }

        } 

        public async void BlockTravelCard(Guid id)
        {
            var travelCard = await context.TravelCards.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (travelCard == null) throw new InvalidOperationException("TravelCard doesn't exist");

            travelCard.Status = TravelCardStatus.Blocked;
            await context.SaveChangesAsync();
        }
    }
}
