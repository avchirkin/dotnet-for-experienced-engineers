using CQRS.Features.Clients.CreateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ClientsController(IMediator sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateClientCommand createClientCommand)
    {
        var created = await sender.Send(createClientCommand);
        return Ok(created);
    }
}