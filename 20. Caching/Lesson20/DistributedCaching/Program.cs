using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherInfoPortal;
using Session = DistributedCaching.Session;
using WeatherServiceProxy = DistributedCaching.WeatherServiceProxy;

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
            var cache = svc.GetRequiredService<IDistributedCache>();
            var instance = svc.GetRequiredService<WeatherService>();
            return new WeatherServiceProxy(cache, instance);
        });

        var openMeteoUri = context.Configuration["OpenMeteoUri"]
                           ?? throw new InvalidOperationException("OpenMeteo URI should be provided");
        services.AddHttpClient("OpenMeteo", client =>
        {
            client.BaseAddress = new Uri(openMeteoUri);
        });

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = context.Configuration["Redis:Host"]
                ?? throw new InvalidOperationException("Redis host should be provided");
            opt.InstanceName = context.Configuration["Redis:Instance"]
                ?? throw new InvalidOperationException("Redis instance should be provided");
        });
    })
    .Build();

var weatherServiceInstance = host.Services.GetRequiredService<IWeatherService>();
var session = new Session(weatherServiceInstance);
await session.Run();

await host.RunAsync();