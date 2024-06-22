using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelCardsController(ITravelCardService travelCardService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInfo(Guid id)
        {
            var ticketInfo = await travelCardService.GetTravelCardInfo(id);
            return ticketInfo == null ? NotFound() : Ok(ticketInfo);
        }

        // Все что ниже без асинхрона - тут немного хз, что да как
        [HttpPost]
        public async Task<IActionResult> Create(NewTravelCardDto travelCardCreationInfo)
        {
            var created = await travelCardService.CreateTravelCard(travelCardCreationInfo);
            return Ok(created);
        }

        [HttpPost]
        public async void Activate(Guid travelCardId, Guid passengerId, Guid tariffId)
        {
            travelCardService.ActivateTravelCard(travelCardId, passengerId, tariffId);
        }

        [HttpPost]
        public async void SetTariff(Guid travelCardId, Guid tariffId)
        {
            travelCardService.SetTariffToTravelCard(travelCardId, tariffId);
        }

        [HttpPost]
        public async void Block(Guid id)
        {
            travelCardService.BlockTravelCard(id);
        }
    }
}
