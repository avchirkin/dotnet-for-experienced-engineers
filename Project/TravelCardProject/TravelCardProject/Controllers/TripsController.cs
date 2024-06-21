using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripsController(ITripService tripService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NewTripDto tripCreationInfo)
        {
            var created = await tripService.CreateTrip(tripCreationInfo);
            return Ok(created);
        }
    }
}
