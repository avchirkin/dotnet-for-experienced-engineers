namespace Accounts.API.Core;

public sealed record Account(Guid Id, Guid OwnerId, long Number, bool IsActive);