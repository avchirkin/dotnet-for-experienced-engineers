using Onion.Application.Models;

namespace Onion.Application.Services.Abstractions;

public interface ITicketsService
{
    Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo);
    Task<TicketInfoDto?> GetTicketInfo(Guid id);
}