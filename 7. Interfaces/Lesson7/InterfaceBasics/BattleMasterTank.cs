namespace InterfaceBasics;

// Наследуемся от интерфейса, как от обычного базового класса.
public class BattleMasterTank : IMovable
{
    // Наследуя интерфейс, мы обязаны реализовать его свойства и методы.
    public float MaxSpeed => 70.0f;

    // Собственное свойство класса, не имеющее отношения к интерфейсу.
    public float ArmorThickness => 120.0f;
    
    // Сигнатура метода реализации должна совпадать с сигнатурой метода интерфейса.
    public void Move(int waypoint)
    {
        Console.WriteLine($"Moving to waypoint {waypoint}...");
    }
}