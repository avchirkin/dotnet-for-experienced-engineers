namespace Overriding;

public abstract class ArmoredVehicle : Vehicle
{
    // Унаследовано от Vehicle.
    protected override VehicleType Type => VehicleType.Military;
    protected override float DamageFactor => 0.15f;

    // Собственное свойство типа, может быть установлено в наследниках.
    protected virtual float ArmorThickness { get; set; } = 50.0f;
    
    // Унаследовано от Vehicle.
    public override void ApplyDamage()
    {
        Health -= Math.Max(Health * DamageFactor - ArmorThickness, 0);
    }
    
    // Собственный метод. Может быть переопределён в наследниках.
    public virtual void UpgradeArmor(float increasingFactor)
    {
        ArmorThickness *= increasingFactor;
    }
}