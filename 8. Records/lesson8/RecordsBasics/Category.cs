namespace RecordsBasics;

// Объявление записи осуществляется с помощью ключевого слова record.
// Записями могут являться как классы, так и структуры.
// Данное объявление синонимично объявлению public record class Category {...}
// Основное назначение записей - иммутабельное использование объектов-сущностей "из коробки".
public record Category
{
    public Guid Id { get; }
    
    // Модификатор свойства init говорит о том, что свойство может быть проинициализировано в конструкторе,
    // либо с помощью конструкции with.
    public string Name { get; init; }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}