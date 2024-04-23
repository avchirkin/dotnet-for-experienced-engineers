namespace DefaultInterfaceMethodImplementation;

public interface IFlyable : IMovable
{
    void IMovable.SetDirection(float direction)
    {
        Console.WriteLine($"IFlyable - direction: {direction}");
    }
}