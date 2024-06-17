using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface ITravelCardService
    {
        Task<TravelCardInfoDto> CreateTravelCard(NewTravelCardDto travelCardCreationInfo);

        Task<TravelCardInfoDto?> GetTravelCardInfo(Guid id);
    }
}
