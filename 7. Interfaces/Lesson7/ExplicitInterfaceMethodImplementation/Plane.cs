namespace ExplicitInterfaceMethodImplementation;

public class Plane : IMovable, IFlyable
{
    public void Move()
    {
        Console.WriteLine("Moving");
    }
    
    void IMovable.Move()
    {
        Console.WriteLine("Moving through the landing zone");
    }

    void IFlyable.Move()
    {
        Console.WriteLine("Moving to the target airport");
    }
}