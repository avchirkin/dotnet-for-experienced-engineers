namespace PolymorphicBehavior;

// Ключевое слово sealed означает, что наследоваться далее от этого класса нельзя.
public sealed class ScorpionTank : ArmoredVehicle
{
    public new void Print()
    {
        Console.WriteLine("Scorpion - ready to sting!");
    }
}