using Tickets.Application.Models;

namespace Tickets.Application.Services.Abstractions;

public interface ITicketsService
{
    Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo);
    Task<TicketInfoDto?> GetTicketInfo(Guid id);
}