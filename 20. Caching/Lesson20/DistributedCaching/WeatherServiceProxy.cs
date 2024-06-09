using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using WeatherInfoPortal;
using WeatherInfoPortal.Models;

namespace DistributedCaching;

public class WeatherServiceProxy(IDistributedCache cache, IWeatherService instance) : IWeatherService
{
    public async Task<WeatherForecast> GetForecast(double latitude, double longitude)
    {
        var cachedResult = await GetFromCache();
        if(cachedResult != null)
        {
            Console.WriteLine($"Getting cached value for {latitude}, {longitude}");
            return cachedResult;
        }

        Console.WriteLine($"Fetching new value for {latitude}, {longitude}");
        var forecast = await instance.GetForecast(latitude, longitude);
        
        SaveToCache();

        return forecast;

        async Task<WeatherForecast?> GetFromCache()
        {
            var key = $"{latitude},{longitude}";
            var cached = await cache.GetStringAsync(key);

            return cached == null ? null : JsonSerializer.Deserialize<WeatherForecast>(cached);
        }
        
        void SaveToCache()
        {
            var cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));
        
            var key = $"{latitude},{longitude}";
            var valueToCache = JsonSerializer.Serialize(forecast);
            
            cache.Set(key, Encoding.UTF8.GetBytes(valueToCache), cacheEntryOptions);
        }
    }
}