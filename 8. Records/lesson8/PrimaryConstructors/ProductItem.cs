namespace PrimaryConstructors;

// Primary-конструктор позволяет избавиться от бойлерплейта в виде авто-свойств.
// Свойства будут сгенерированы компилятором автоматически с модификаторами {get; init}
public sealed record ProductItem(string Name, string? Description)
{
    // Свойство, имеющее только геттер, всё ещё нужно объявлять явно.
    public Guid Id { get; } = Guid.NewGuid();
    
    // Мы можем создавать обычные конструкторы в пару к primary.
    public ProductItem(string name)
        : this(name, string.Empty) // Вызов primary-конструктора обязателен!
    {
        Name = name;
    }
}