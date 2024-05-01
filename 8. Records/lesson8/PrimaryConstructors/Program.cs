using PrimaryConstructors;

// Вызываем primary-конструктор
var productOne = new ProductItem("Sony Bravia", "TV with AI-based OS");
Console.WriteLine(productOne);

// productOne.Description = "Your best choice"; // Ошибка! У свойства Description нет публичного сеттера

// Вызываем "обычный" конструктор
var productTwo = new ProductItem("Sony Bravia");
Console.WriteLine(productTwo);