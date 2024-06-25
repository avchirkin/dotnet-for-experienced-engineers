using System.Text.Json.Serialization;

namespace Accounts.API.IntegrationTests.Models;

public sealed record AccountTestDto
{
    [JsonPropertyName("number")]
    public long Number { get; set; }
    
    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }
}