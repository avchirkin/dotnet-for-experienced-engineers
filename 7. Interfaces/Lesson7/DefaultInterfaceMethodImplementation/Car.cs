namespace DefaultInterfaceMethodImplementation;

// "Старый" класс в кодовой базе, который мы не хотим или не имеем возможности расширить.
public class Car : IMovable
{
    // Наследовано от интерфейса.
    public float Speed { get; private set; }

    public void SetSpeed(float speed)
    {
        Speed = speed;
        Console.WriteLine($"Car speed is set to {speed}");
    }
}