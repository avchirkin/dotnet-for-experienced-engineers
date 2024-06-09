using WeatherInfoPortal.Models;

namespace WeatherInfoPortal;

public interface IWeatherService
{
    Task<WeatherForecast> GetForecast(double latitude, double longitude);
}