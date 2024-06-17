using CQRS.Features.Tariffs.CreateTariff;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TariffsController(IMediator sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTariffCommand createTariffCommand)
    {
        var created = await sender.Send(createTariffCommand);
        return Ok(created);
    }
}