using CQRS.Core.Entities;
using CQRS.Features.Models;
using CQRS.Persistence.Postgres;
using MediatR;

namespace CQRS.Features.Clients.CreateClient;

public class CreateClientHandler(AutoTicketDbContext context)
    : IRequestHandler<CreateClientCommand, CreateClientResponse>
{
    public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(client);
        await context.SaveChangesAsync();

        return new CreateClientResponse { ClientInfo = ClientInfoDto.FromEntity(entry.Entity) };
    }
}