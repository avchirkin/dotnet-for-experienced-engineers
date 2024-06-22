using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface ITravelCardService
    {
        Task<TravelCardInfoDto> CreateTravelCard(NewTravelCardDto travelCardCreationInfo);

        Task<TravelCardInfoDto?> GetTravelCardInfo(Guid id);

        void ActivateTravelCard(Guid travelCardId, Guid PassengerId, Guid TariffId);

        void SetTariffToTravelCard(Guid travelCardId, Guid TariffId);

        void BlockTravelCard(Guid Id);
    }
}
