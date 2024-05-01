namespace RecordsEquality;

public sealed record SmartProductItem(Guid Id, string Name, string? Description)
{
    // Вместо неявно генерируемого компилятором метода Equals явно определяем свой.
    public bool Equals(SmartProductItem? other)
    {
        return Id == other?.Id && Name == other.Name;
    }

    // Перегрузка GetHashCode обязательна при явном определении Equals во избежание
    // неконсистентного поведения при проверке равенства двух экземпляров (например, в Dictionary).
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}