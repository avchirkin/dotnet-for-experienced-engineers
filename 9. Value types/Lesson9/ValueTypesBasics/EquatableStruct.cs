namespace ValueTypesBasics;

public struct EquatableStruct
{
    public int Counter { get; set; }
    
    public string Description { get; set; }

    public string DefaultName => "Default Name";

    // Для возможности использования оператора == нужно определить его явно
    public static bool operator == (EquatableStruct first, EquatableStruct second)
    {
        return first.Counter == second.Counter
               && first.Description == second.Description;
    }

    // Оператор != обязательно должен быть определен в пару к ==
    public static bool operator !=(EquatableStruct first, EquatableStruct second)
    {
        return !(first == second);
    }
    
    // В случае определения оператора == необходимо также переопределить методы Equals(EquatableStruct), Equals(object)
    // и GetHashCode во избежание неконсистентной проверки на равенство/эквивалентность разными способами.
    public bool Equals(EquatableStruct other)
    {
        return Counter == other.Counter && Description == other.Description;
    }

    public override bool Equals(object? obj)
    {
        return obj is EquatableStruct other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Counter, Description);
    }
}