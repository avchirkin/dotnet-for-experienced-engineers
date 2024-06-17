using Layered.ApplicationCore.Models;
using Layered.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Layered.Api.Controllers;

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