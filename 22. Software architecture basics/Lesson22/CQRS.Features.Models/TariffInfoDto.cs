using System.Text.Json.Serialization;
using CQRS.Core.Entities;

namespace CQRS.Features.Models;

public sealed record TariffInfoDto
{
    [JsonPropertyName("id")] public Guid Id { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("is_active")] public bool IsActive { get; init; }

    public static TariffInfoDto FromEntity(Tariff tariffEntity)
    {
        return new TariffInfoDto
        {
            Id = tariffEntity.Id,
            Name = tariffEntity.Name,
            IsActive = tariffEntity.IsActive
        };
    }
}