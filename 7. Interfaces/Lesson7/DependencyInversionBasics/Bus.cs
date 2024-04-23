namespace DependencyInversionBasics;

public class Bus : ITraceable
{
    public int Route { get; }
    public float CurrentPosition { get; set; }

    public Bus(int route, float startingPosition)
    {
        Route = route;
        CurrentPosition = startingPosition;
    }
    
    public void Trace()
    {
        Console.WriteLine($"Bus on route {Route} is in point {CurrentPosition}");
    }
}