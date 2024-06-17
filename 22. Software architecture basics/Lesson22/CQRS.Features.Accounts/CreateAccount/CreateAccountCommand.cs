using MediatR;

namespace CQRS.Features.Accounts.CreateAccount;

public sealed record CreateAccountCommand : IRequest<CreateAccountResponse>
{
    public required string Name { get; init; }
}