using CQRS.Features.Models;
using CQRS.Persistence.Postgres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.Tickets.GetTicketById;

public class GetTicketByIdHandler(AutoTicketDbContext context) : IRequestHandler<GetTicketByIdQuery, GetTicketByIdResponse>
{
    public async Task<GetTicketByIdResponse> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await context.Tickets
            .Include(t => t.Client)
            .Include(t => t.Account)
            .Include(t => t.Tariff)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id.Equals(request.Id));
        return ticket == null
            ? new GetTicketByIdResponse()
            : new GetTicketByIdResponse { TicketInfo = TicketInfoDto.FromEntity(ticket) };
    }
}