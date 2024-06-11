using Microsoft.AspNetCore.Mvc;
using WebApiWithControllers.Models;
using WebApiWithControllers.Services;

namespace WebApiWithControllers.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TicketsController(ITicketsService ticketsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        var ticketInfo = await ticketsService.GetTicketInfo(id);
        return ticketInfo == null ? NotFound() : Ok(ticketInfo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NewTicketDto ticketCreationInfo)
    {
        var created = await ticketsService.CreateTicket(ticketCreationInfo);
        return Ok(created);
    }
}