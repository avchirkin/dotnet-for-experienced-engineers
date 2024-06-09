using System.Text.Json.Serialization;

namespace WeatherInfoPortal.Models;

public sealed record HourlyInfo
{
    [JsonPropertyName("time")]
    public IEnumerable<string> Time { get; init; } = Enumerable.Empty<string>();
    
    [JsonPropertyName("temperature_2m")]
    public IEnumerable<float> Temperature { get; init; } = Enumerable.Empty<float>();
    
    [JsonPropertyName("rain")]
    public IEnumerable<float> Rain { get; init; } = Enumerable.Empty<float>();
    
    [JsonPropertyName("wind_speed_10m")]
    public IEnumerable<float> WindSpeed { get; init; } = Enumerable.Empty<float>();
}