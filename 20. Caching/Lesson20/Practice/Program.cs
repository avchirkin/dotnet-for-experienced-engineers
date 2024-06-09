using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Practice;
using Practice.Models;
using ProductItems.Terminal;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json");
        config.AddEnvironmentVariables();
        config.Build();
    })
    .ConfigureServices((context, services) =>
    {
        var connString = context.Configuration.GetConnectionString("ProductItemsDb");
        services.AddDbContext<ProductItemsDbContext>(options => options.UseNpgsql(connString));
    })
    .Build();

var services = host.Services;
var context = services.GetRequiredService<ProductItemsDbContext>();
await Session.Run(context);

await host.RunAsync();
