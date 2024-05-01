using RecordsBasics;

var smartTVs = new Category("SmartTV");
var productOne = new ProductItem("Sony Bravia", "Hi-tech TV", smartTVs);
Console.WriteLine(productOne); // Обратите внимание на вывод в консоль - в чём отличие от вывода обычного класса?

var androidTVs = new Category("Android TV");

// productOne.Category = androidTVs;// Ошибка! Экземпляр productOne не содержит свойств с публичными сеттерами
// Конструкция with позволяет создавать копию записи, изменяя лишь нужные свойства.
var productTwo = productOne with { Category = androidTVs };
Console.WriteLine(productTwo); // Тот же вывод, что и для productOne, но с измененным Category

Console.WriteLine(productOne); // Тот же вывод, что в строке 5 - исходный экземпляр не поменялся!

var productThree = productTwo;
Console.WriteLine(productTwo == productThree); // true
productTwo = productTwo with { Description = "TV with AI-featured OS" };
Console.WriteLine(productTwo == productThree); // false - создали новый экземпляр записи


