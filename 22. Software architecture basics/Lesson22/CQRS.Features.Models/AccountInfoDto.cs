using System.Text.Json.Serialization;
using CQRS.Core.Entities;

namespace CQRS.Features.Models;

public sealed record AccountInfoDto
{
    [JsonPropertyName("id")] public Guid Id { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("balance")] public decimal Balance { get; init; }

    [JsonPropertyName("is_active")] public bool IsActive { get; init; }

    public static AccountInfoDto FromEntity(Account accountEntity)
    {
        return new AccountInfoDto
        {
            Id = accountEntity.Id,
            Name = accountEntity.Name,
            Balance = accountEntity.Balance,
            IsActive = accountEntity.IsActive,
        };
    }
}