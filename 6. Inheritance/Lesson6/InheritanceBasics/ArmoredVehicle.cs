namespace InheritanceBasics;

public class ArmoredVehicle : Vehicle
{
    // protected-члены доступны только из текущего класса и его наследников
    protected float ArmorThickness { get; set; } = 50.0f;
    
    public ArmoredVehicle(string name, Nation nation)
        : base(name, VehicleType.Military, nation)
    {
        Health += ArmorThickness;
    }

    public void UpgradeArmor(float increasingFactor)
    {
        Console.WriteLine($"\nUpgrading armor of {Name} ({Health} HP)...");
        Health += increasingFactor * ArmorThickness;
        Console.WriteLine($"Done. {Health} HP available after upgrade.\n");
    }
}