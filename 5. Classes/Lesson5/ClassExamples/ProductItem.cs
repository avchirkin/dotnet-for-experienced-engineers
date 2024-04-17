namespace ClassExamples
{
    // Объявление класса
    // <модификатор доступа> class <название класса>
    // Модификатор доступа internal делает класс видимым в пределах сборки
    internal class ProductItem
    {
        // Приватное поле-константа, проинициализированное в месте объявления
        private const string DefaultCategory = Categories.Common;

        // Свойство с геттером и инициализацией по умолчанию
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public string Category { get; }

        // Авто-свойство с геттером и сеттером
        public string? Description { get; set; }

        // Параметризованный публичный конструктор
        public ProductItem(string name, string? description, string category = DefaultCategory)
        {
            Name = name;
            Description = description;
            Category = category;
        }

        // Объявление метода
        public override string ToString()
        {
            return $"{Name}\t{Category}\t{Description}";
        }
    }
}
