using Microsoft.EntityFrameworkCore;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class TripService(TravelCardsDbContext context) : ITripService
    {
        public async Task<TripInfoDto> CreateTrip(NewTripDto tripCreationInfo)
        {
            // Скорее всего, надо написать свои эксепшены
            var terminal = await context.Terminals.FirstOrDefaultAsync(c => c.Id.Equals(tripCreationInfo.TerminalId));
            if (terminal == null) throw new InvalidOperationException("Terminal doesn't exist");

            var travelCard = await context.TravelCards
                .Include(c => c.Account)
                .Include(c => c.Tariff)
                .Include(c => c.Passenger)
                .FirstOrDefaultAsync(c => c.Id.Equals(tripCreationInfo.TravelCardId));
            if (travelCard == null) throw new InvalidOperationException("Travel card doesn't exist");

            var trip = new Trip
            {
                Id = Guid.NewGuid(),
                TripDate = DateTime.Now,
                TerminalId = terminal.Id,
                TravelCardId = travelCard.Id,
            };

            var entry = await context.AddAsync(trip);
            await context.SaveChangesAsync();

            // Тут туго возвращается Информация о trip из-за проблем с выводом связей Travel Card
            return TripInfoDto.FromEntity(entry.Entity);
        }
    }
}
