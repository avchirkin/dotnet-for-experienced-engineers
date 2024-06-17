using Microsoft.AspNetCore.Mvc;
using Onion.Application.Models;
using Onion.Application.Services.Abstractions;

namespace Onion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ClientsController(IClientsService clientsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(NewClientDto clientCreationInfo)
    {
        var created = await clientsService.CreateClient(clientCreationInfo);
        return Ok(created);
    }
}