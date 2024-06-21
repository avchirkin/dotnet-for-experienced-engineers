using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController(IPassangerService passangerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NewPassengerDto passengerCreationInfo)
        {
            var created = await passangerService.CreatePassenger(passengerCreationInfo);
            return Ok(created);
        }
    }
}
