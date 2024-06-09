using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Primitives;

namespace WeatherInfoPortal.Models;

public sealed record WeatherForecast
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }
    
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }
    
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }
    
    [JsonPropertyName("hourly_units")]
    public HourlyUnits? HourlyUnits { get; init; }
    
    [JsonPropertyName("hourly")]
    public HourlyInfo? HourlyInfo { get; init; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("1-day forecast");
        
        sb.AppendLine($"Latitude: {Latitude.ToString(CultureInfo.InvariantCulture)}");
        sb.AppendLine($"Longitude: {Longitude.ToString(CultureInfo.InvariantCulture)}");

        var timePoints = HourlyInfo!.Time.ToArray();
        var temp = HourlyInfo.Temperature.ToArray();
        var wind = HourlyInfo.WindSpeed.ToArray();
        var rain = HourlyInfo.Rain.ToArray();

        var tempU = HourlyUnits!.Temperature;
        var windU = HourlyUnits!.WindSpeed;
        var rainU = HourlyUnits!.Rain;

        for (var counter = 0; counter < timePoints.Length; counter++)
        {
            sb.AppendLine($"{timePoints[counter]}: {temp[counter]}{tempU}, {wind[counter]} {windU}, {rain[counter]} {rainU}");
        }

        sb.AppendLine();
        
        return sb.ToString();
    }
}