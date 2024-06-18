using System.Text.Json.Serialization;

namespace Tickets.Application.Models;

public sealed record ClientInfoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; init; }
}