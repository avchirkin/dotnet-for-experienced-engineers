using System.Globalization;
using WeatherInfoPortal;

namespace DistributedCaching;

public sealed class Session(IWeatherService service)
{
    public async Task Run()
    {
        while (true)
        {
            Console.WriteLine("Enter the latitude and longitude divided by comma:");
            var coordinatesString = Console.ReadLine() ?? string.Empty;

            var coordinates = coordinatesString.Split(",");
            if (coordinates.Length != 2)
            {
                Console.WriteLine("Incorrect number of parameters");
                continue;
            }

            if (!double.TryParse(coordinates[0], CultureInfo.InvariantCulture, out var latitude))
            {
                Console.WriteLine("Invalid latitude parameter, skipping...");
                continue;
            }
            
            if (!double.TryParse(coordinates[1], CultureInfo.InvariantCulture, out var longitude))
            {
                Console.WriteLine("Invalid longitude parameter, skipping...");
                continue;
            }

            var forecast = await service.GetForecast(latitude, longitude);
            Console.WriteLine(forecast);
        }
    }
}