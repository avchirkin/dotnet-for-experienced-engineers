using RecordsEquality;

var id = Guid.NewGuid();
var productOne = new ProductItem(id, "Sony Bravia", "Your Best Choice");
var productTwo = new ProductItem(id, "Sony Bravia", "Your Best Choice");

// По умолчанию, эквивалентность двух экземпляров записи определяется значением всех их свойств.
Console.WriteLine(productOne == productTwo); // true - все свойства двух экземпляров записей равны.

Console.ReadLine();

var productThree = new ProductItem(id, "Sony Bravia", "Your Best Choice in 2024");
Console.WriteLine(productOne == productThree); // false - отличается свойство Description

Console.ReadLine();

var smartProductOne = new SmartProductItem(id, "Sony Bravia", "Your Best Choice");
var smartProductTwo = new SmartProductItem(id, "Sony Bravia", "Your Best Choice in 2024");
Console.WriteLine(smartProductOne == smartProductTwo); // true - при проверке на равенство исключено свойство Description

Console.ReadLine();

var smartProductThree = new SmartProductItem(id, "Sony Bravia 2024", "Your Best Choice");
Console.WriteLine(smartProductOne == smartProductThree); // false - отличается свойство Name
