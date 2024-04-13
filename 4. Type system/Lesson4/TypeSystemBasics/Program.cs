
// Все типы, как ссылочные (reference), так и значимые (value) являются наследниками типа System.Object
var obj = new object();

// Проверка на тип с помощью рефлексии
Console.WriteLine(obj.GetType() == typeof(object)); // true

// Проверка на тип с помощью оператора is
Console.WriteLine(obj is object); // true

Console.ReadLine();

obj = "Some string";
Console.WriteLine(obj is object); // ВОПРОС - что будет в консоли?
Console.WriteLine(obj is string); // ВОПРОС - что будет в консоли?

Console.ReadLine();

var str = "Some string";
Console.WriteLine(str is object); // ВОПРОС - что будет в консоли?
Console.WriteLine(str is string); // ВОПРОС - что будет в консоли?

Console.ReadLine();

var sameObj = obj;
Console.WriteLine(obj.Equals(sameObj)); // true
Console.WriteLine(obj == sameObj); // true
Console.WriteLine(object.ReferenceEquals(obj, sameObj)); // true

Console.ReadLine();

var otherObj = new object();
Console.WriteLine(obj.Equals(otherObj)); // ВОПРОС - что будет в консоли?
Console.WriteLine(obj == otherObj); // ВОПРОС - что будет в консоли?
Console.WriteLine(object.ReferenceEquals(obj, otherObj)); // ВОПРОС - что будет в консоли?

Console.ReadLine();