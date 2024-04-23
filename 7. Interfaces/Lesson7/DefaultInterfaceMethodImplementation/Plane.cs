namespace DefaultInterfaceMethodImplementation;

public class Plane : IFlyable
{
    // Наследовано от интерфейса.
    public float Speed { get; private set; }

    public void SetSpeed(float speed)
    {
        Speed = speed;
        Console.WriteLine($"Plane speed is set to {speed}");
    }
}