using System.Text.Json.Serialization;

namespace Accounts.API.Services.Models;

public sealed record AccountDto(long Number, bool IsActive)
{
    [JsonPropertyName("number")]
    public long Number { get; set; } = Number;

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; } = IsActive;
}