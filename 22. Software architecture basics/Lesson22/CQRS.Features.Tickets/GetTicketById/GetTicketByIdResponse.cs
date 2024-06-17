using CQRS.Features.Models;

namespace CQRS.Features.Tickets.GetTicketById;

public sealed record GetTicketByIdResponse
{
    public TicketInfoDto? TicketInfo { get; init; }
}