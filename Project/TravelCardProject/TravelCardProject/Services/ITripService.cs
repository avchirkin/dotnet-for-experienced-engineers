using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface ITripService
    {
        Task<TripInfoDto> CreateTrip(NewTripDto tripCreationInfo);

        Task<TripInfoDto?> GetTripInfo(Guid id);
    }
}
