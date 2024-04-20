namespace Overriding;

// Ключевое слово sealed означает, что наследоваться далее от этого класса нельзя.
public sealed class ScorpionTank : ArmoredVehicle
{
    // Переопределяем абстрактное свойство базового класса.
    public override string Name => "Scorpion Tank";

    // Переопределяем абстрактное свойство базового класса.
    protected override Nation Nation => Nation.GLA;

    // Переопределяем виртуальное свойство базового класса.
    protected override float ArmorThickness { get; set; } = 75.0f;
    
    // Переопределяем метод базового класса, добавляя логирование.
    public override void UpgradeArmor(float increasingFactor)
    {
        Console.WriteLine($"\nUpgrading armor of {Name} ({Health} HP, {ArmorThickness}mm armor)...");
        base.UpgradeArmor(increasingFactor);
        Console.WriteLine($"Done. {ArmorThickness}mm available after upgrade.\n");
    }
}