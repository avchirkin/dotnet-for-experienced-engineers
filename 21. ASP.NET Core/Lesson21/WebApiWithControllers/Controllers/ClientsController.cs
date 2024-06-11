using Microsoft.AspNetCore.Mvc;
using WebApiWithControllers.Models;
using WebApiWithControllers.Services;

namespace WebApiWithControllers.Controllers;

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