
var intValue = 42;
object boxed = intValue; // Boxing - упаковка значимого типа в ссылочный, аллокация памяти в куче

int unboxed = (int)boxed; // Unboxing - распаковка значимого типа в переменную значимого типа

long longValue = (long)boxed; // ВОПРОС - распакуется ли int?
Console.WriteLine(boxed);

Console.ReadLine();

Console.WriteLine(intValue.ToString()); // Boxing!
Console.WriteLine($"Число: {intValue}"); // Boxing!
Console.WriteLine(intValue); // Boxing!
