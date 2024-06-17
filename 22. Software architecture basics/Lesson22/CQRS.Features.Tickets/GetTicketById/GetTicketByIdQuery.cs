using MediatR;

namespace CQRS.Features.Tickets.GetTicketById;

public record GetTicketByIdQuery(Guid Id) : IRequest<GetTicketByIdResponse>;