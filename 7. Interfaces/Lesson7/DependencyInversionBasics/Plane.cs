namespace DependencyInversionBasics;

public class Plane : ITraceable
{
    public int Route { get; }
    public string CurrentLocation { get; set; }

    public Plane(int route, string departurePoint)
    {
        Route = route;
        CurrentLocation = departurePoint;
    }
    
    public void Trace()
    {
        Console.WriteLine($"Plane on route {Route} is in location {CurrentLocation}");
    }
}