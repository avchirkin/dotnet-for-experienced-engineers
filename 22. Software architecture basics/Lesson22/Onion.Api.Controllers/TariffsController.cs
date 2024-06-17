using Microsoft.AspNetCore.Mvc;
using Onion.Application.Models;
using Onion.Application.Services.Abstractions;

namespace Onion.Api.Controllers;

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