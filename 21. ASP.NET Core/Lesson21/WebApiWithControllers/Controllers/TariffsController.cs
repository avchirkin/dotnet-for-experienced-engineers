using Microsoft.AspNetCore.Mvc;
using WebApiWithControllers.Models;
using WebApiWithControllers.Services;

namespace WebApiWithControllers.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TariffsController(ITariffsService tariffsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(NewTariffDto tariffCreationInfo)
    {
        var created = await tariffsService.CreateTariff(tariffCreationInfo);
        return Ok(created);
    }
}