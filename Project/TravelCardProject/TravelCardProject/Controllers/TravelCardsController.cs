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

        [HttpPost]
        public async Task<IActionResult> Create(NewTravelCardDto travelCardCreationInfo)
        {
            var created = await travelCardService.CreateTravelCard(travelCardCreationInfo);
            return Ok(created);
        }
    }
}
