using CQRS.Features.Models;

namespace CQRS.Features.Accounts.CreateAccount;

public sealed record CreateAccountResponse
{
    public AccountInfoDto AccountInfo { get; init; } = default!;
}