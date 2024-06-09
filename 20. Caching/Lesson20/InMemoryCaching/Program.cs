using InMemoryCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherInfoPortal;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json");
        config.AddEnvironmentVariables();
        config.Build();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<WeatherService>();
        services.AddScoped<IWeatherService, WeatherServiceProxy>(svc =>
        {
            var cache = svc.GetRequiredService<IMemoryCache>();
            var instance = svc.GetRequiredService<WeatherService>();
            return new WeatherServiceProxy(cache, instance);
        });

        var openMeteoUri = context.Configuration["OpenMeteoUri"]
                           ?? throw new InvalidOperationException("OpenMeteo URI should be provided");
        services.AddHttpClient("OpenMeteo", client =>
        {
            client.BaseAddress = new Uri(openMeteoUri);
        });

        services.AddMemoryCache();
    })
    .Build();

var weatherServiceInstance = host.Services.GetRequiredService<IWeatherService>();
var session = new Session(weatherServiceInstance);
await session.Run();

await host.RunAsync();