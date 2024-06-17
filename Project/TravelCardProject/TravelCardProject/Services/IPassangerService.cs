using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface IPassangerService
    {
        Task<PassengerInfoDto> CreatePassenger(NewPassengerDto passengerCreationInfo);
    }
}
