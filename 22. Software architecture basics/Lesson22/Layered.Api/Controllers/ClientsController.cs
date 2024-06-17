using Layered.ApplicationCore.Models;
using Layered.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Layered.Api.Controllers;

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