using CQRS.Features.Models;

namespace CQRS.Features.Tickets.CreateTicket;

public sealed record CreateTicketResponse
{
    public TicketInfoDto TicketInfo { get; init; } = default!;
}