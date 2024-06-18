using Clients.Application.Models;
using Clients.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Clients.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ClientsController(IClientsService clientsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await clientsService.GetClientById(id);
        if (result == null) return NotFound();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NewClientDto clientCreationInfo)
    {
        var created = await clientsService.CreateClient(clientCreationInfo);
        return Ok(created);
    }
}