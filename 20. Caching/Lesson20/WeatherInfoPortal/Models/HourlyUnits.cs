using System.Text.Json.Serialization;

namespace WeatherInfoPortal.Models;

public sealed record HourlyUnits
{
    [JsonPropertyName("time")]
    public string? Time { get; init; }
    
    [JsonPropertyName("temperature_2m")]
    public string? Temperature { get; init; }
    
    [JsonPropertyName("rain")]
    public string? Rain { get; init; }
    
    [JsonPropertyName("wind_speed_10m")]
    public string? WindSpeed { get; init; }
}