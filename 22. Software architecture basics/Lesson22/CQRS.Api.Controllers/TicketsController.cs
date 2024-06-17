using CQRS.Features.Tickets.CreateTicket;
using CQRS.Features.Tickets.GetTicketById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TicketsController(IMediator sender) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        var result = await sender.Send(new GetTicketByIdQuery(id));
        return result.TicketInfo == null ? NotFound() : Ok(result.TicketInfo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketCommand createTicketCommand)
    {
        var created = await sender.Send(createTicketCommand);
        return Ok(created);
    }
}