using Microsoft.Extensions.Caching.Memory;
using WeatherInfoPortal;
using WeatherInfoPortal.Models;

namespace InMemoryCaching;

public class WeatherServiceProxy(IMemoryCache cache, IWeatherService instance) : IWeatherService
{
    public async Task<WeatherForecast> GetForecast(double latitude, double longitude)
    {
        if(cache.TryGetValue((latitude,longitude), out var cached))
        {
            Console.WriteLine($"Getting cached value for {latitude}, {longitude}");
            return (WeatherForecast)cached!;
        }

        Console.WriteLine($"Fetching new value for {latitude}, {longitude}");
        var forecast = await instance.GetForecast(latitude, longitude);
        
        SaveToCache();

        return forecast;

        void SaveToCache()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));
            cache.Set((latitude, longitude), forecast, cacheEntryOptions);
        }
    }
}