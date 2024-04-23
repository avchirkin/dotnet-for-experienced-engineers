namespace InterfaceBasics;

// Класс Aurora, наследуя два интерфейса, обязуется на уровне контракта реализовать методы и свойства этих интерфейсов.
// Данное поведение является частичным эквивалентом множественного наследования, отсутствующего в .NET.
public class Aurora : IMovable, IAircraftUnit
{
    // Из IMovable
    public float MaxSpeed => 400.0f;

    // Из IAircraftUnit
    public float MaxFlightHeight => 10_000.0f;
    public float MaxFlightSpeed => 2500.0f;

    // Из IMovable
    public void Move(int waypoint)
    {
        // Реализация метода интерфейса в разных классах может отличаться.
        Console.WriteLine($"Aurora: moving to waypoint {waypoint}...");
    }
    
    // Из IAircraftUnit
    public void ChangeFlightCourse(float newDirection, float newHeight, float newSpeed)
    {
        Console.WriteLine($"Setting new course to {newDirection}, with height {newHeight} and speed {newSpeed}...");
    }
}