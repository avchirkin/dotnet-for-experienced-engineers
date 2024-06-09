using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherInfoPortal.Models;

namespace WeatherInfoPortal;

public sealed class WeatherService(IHttpClientFactory httpClientFactory) : IWeatherService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("OpenMeteo");

    public async Task<WeatherForecast> GetForecast(double latitude, double longitude)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(
                _client.BaseAddress!,
                $"/v1/forecast?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&hourly=temperature_2m,rain,wind_speed_10m&forecast_days=1"),
        };

        using var response = await _client.SendAsync(request);

        var forecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(await response.Content.ReadAsStreamAsync());
        return forecast ?? throw new InvalidOperationException("Couldn't parse response of OpenMeteo");
    }
}