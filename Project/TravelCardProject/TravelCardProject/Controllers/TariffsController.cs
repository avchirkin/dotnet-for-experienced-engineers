using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TariffsController(ITariffService tariffService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NewTariffDto tariffCreationInfo)
        {
            var created = await tariffService.CreateTariff(tariffCreationInfo);
            return Ok(created);
        }
    }
}
