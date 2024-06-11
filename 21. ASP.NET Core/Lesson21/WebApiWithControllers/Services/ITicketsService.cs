using WebApiWithControllers.Models;

namespace WebApiWithControllers.Services;

public interface ITicketsService
{
    Task<TicketInfoDto> CreateTicket(NewTicketDto ticketCreationInfo);
    Task<TicketInfoDto?> GetTicketInfo(Guid id);
}