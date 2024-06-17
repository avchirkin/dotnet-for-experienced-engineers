using System.Text.Json.Serialization;

namespace Layered.ApplicationCore.Models;

public sealed record NewTicketDto
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("client_id")]
    public Guid ClientId { get; init; }
    
    [JsonPropertyName("tariff_id")]
    public Guid TariffId { get; init; }
    
    [JsonPropertyName("account_id")]
    public Guid AccountId { get; init; }
}