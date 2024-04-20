namespace InheritanceBasics;

public class Vehicle
{
    private const float DefaultHealth = 100.0f;
    
    public string Name { get; }
    public VehicleType Type { get; }
    public Nation Nation { get; }
    public float Health { get; protected set; } = DefaultHealth;

    protected float DamageFactor => 0.15f;

    public Vehicle(string name, VehicleType type, Nation nation)
    {
        Name = name;
        Type = type;
        Nation = nation;
    }

    protected void ApplyDamage()
    {
        Health -= Health * DamageFactor;
    }

    public override string ToString()
    {
        return $"{Name} ({Type}), Side - {Nation}, Health - {Health} HP";
    }
}