namespace Overriding;

/* Абстрактным называется класс, экземпляр которого создать нельзя (абстракция верхнего уровня, служащая для хранения
наиболее общих признаков типов в иерархии наследования). В абстрактном классе можно объявлять абстрактные 
(необходимо будет переопределить в наследниках), виртуальные (можно переопределить, но не обязательно) и обычные члены.
*/
public abstract class Vehicle
{
    private const float DefaultHealth = 100.0f;
    
    // Необходимо переопределить для каждого наследника.
    public abstract string Name { get; }
    
    // Необходимо переопределить для каждого наследника.
    protected abstract VehicleType Type { get; }
    
    // Необходимо переопределить для каждого наследника.
    protected abstract Nation Nation { get; }
    
    // Свойство переопределить невозможно, но можно установить его значение из наследника.
    protected float Health { get; set; } = DefaultHealth;

    // Свойство может быть переопределено в наследнике.
    protected virtual float DamageFactor => 0.5f;

    // Необходимо переопределить для каждого наследника.
    public abstract void ApplyDamage();

    // Метод перегружает метод ToString класса Object, но может быть вновь перегружен в наследниках.
    public override string ToString()
    {
        return $"{Name} ({Type}), Side - {Nation}, Health - {Health} HP";
    }
}