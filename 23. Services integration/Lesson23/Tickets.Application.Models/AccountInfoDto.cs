using System.Text.Json.Serialization;

namespace Tickets.Application.Models;

public sealed record AccountInfoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("balance")]
    public decimal Balance { get; init; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; init; }
}