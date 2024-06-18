using Microsoft.AspNetCore.Mvc;
using Tariffs.Application.Models;
using Tariffs.Application.Services.Abstractions;

namespace Tariffs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TariffsController(ITariffsService tariffsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await tariffsService.GetTariffById(id);
        if (result == null) return NotFound();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NewTariffDto tariffCreationInfo)
    {
        var created = await tariffsService.CreateTariff(tariffCreationInfo);
        return Ok(created);
    }
}