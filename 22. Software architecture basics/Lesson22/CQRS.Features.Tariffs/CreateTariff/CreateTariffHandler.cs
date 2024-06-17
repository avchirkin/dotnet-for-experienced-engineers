using CQRS.Core.Entities;
using CQRS.Features.Models;
using CQRS.Persistence.Postgres;
using MediatR;

namespace CQRS.Features.Tariffs.CreateTariff;

public class CreateTariffHandler(AutoTicketDbContext context)
    : IRequestHandler<CreateTariffCommand, CreateTariffResponse>
{
    public async Task<CreateTariffResponse> Handle(CreateTariffCommand request, CancellationToken cancellationToken)
    {
        var tariff = new Tariff
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(tariff);
        await context.SaveChangesAsync();

        return new CreateTariffResponse { TariffInfo = TariffInfoDto.FromEntity(entry.Entity) };
    }
}