namespace DefaultInterfaceMethodImplementation;

// Интерфейс, который мы имеем возможность расширить.
public interface IMovable
{
    public float Speed { get; }

    void SetSpeed(float speed);
    
    public void SetDirection(float direction)
    {
        Console.WriteLine($"IMovable - direction: {direction}");
    }
}