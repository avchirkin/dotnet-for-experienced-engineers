using Layered.ApplicationCore.Models;

namespace Layered.ApplicationCore.Services;

public interface ITicketsService
{
    Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo);
    Task<TicketInfoDto?> GetTicketInfo(Guid id);
}