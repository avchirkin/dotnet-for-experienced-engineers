using CQRS.Core.Entities;
using CQRS.Features.Models;
using CQRS.Persistence.Postgres;
using MediatR;

namespace CQRS.Features.Accounts.CreateAccount;

public class CreateAccountHandler(AutoTicketDbContext context)
    : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ActivationDate = DateTime.Now
        };

        var entry = await context.AddAsync(account);
        await context.SaveChangesAsync();

        return new CreateAccountResponse { AccountInfo = AccountInfoDto.FromEntity(entry.Entity) };
    }
}