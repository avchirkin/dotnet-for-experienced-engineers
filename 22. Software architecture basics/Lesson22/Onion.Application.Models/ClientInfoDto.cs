using System.Text.Json.Serialization;
using Onion.Domain.Models;

namespace Onion.Application.Models;

public sealed record ClientInfoDto
{
    [JsonPropertyName("id")] public Guid Id { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("is_active")] public bool IsActive { get; init; }

    public static ClientInfoDto FromEntity(Client clientEntity)
    {
        return new ClientInfoDto
        {
            Id = clientEntity.Id,
            Name = clientEntity.Name,
            IsActive = clientEntity.IsActive
        };
    }
}