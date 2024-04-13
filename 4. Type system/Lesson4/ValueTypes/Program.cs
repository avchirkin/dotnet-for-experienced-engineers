
// Значимые типы наследуются от System.ValueType, который, в свою очередь, является наследником System.Object
var number = 13;
Console.WriteLine(number is object); // ВОПРОС - что будет в консоли?
Console.WriteLine(number is int); // ВОПРОС - что будет в консоли?

Console.ReadLine();

var otherNumber = 13;
Console.WriteLine(number == otherNumber); // true
Console.WriteLine(number.Equals(otherNumber)); // true
Console.WriteLine(object.ReferenceEquals(number, otherNumber)); // ВОПРОС - что выведется на консоль?

Console.ReadLine();

int intVal = 42;
Console.WriteLine(intVal is long); // false

long longVal = 42;
Console.WriteLine(longVal is int); // false