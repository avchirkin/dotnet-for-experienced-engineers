using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class PassengerService(TravelCardsDbContext context) : IPassangerService
    {
        public async Task<PassengerInfoDto> CreatePassenger(NewPassengerDto passengerCreationInfo)
        {
            var passenger = new Passenger
            {
                Id = Guid.NewGuid(),
                Name = passengerCreationInfo.Name,
            };

            var entry = await context.AddAsync(passenger);
            await context.SaveChangesAsync();

            return PassengerInfoDto.FromEntity(entry.Entity);
        }
    }
}
