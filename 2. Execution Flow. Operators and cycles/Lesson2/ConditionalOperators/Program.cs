// Выполняем код в блоке фигурных скобок под if, если выражение в круглых скобках равно true.
// Оператор равенства == не стоит путать с оператором присвоения =.
if (args.Length == 0)
{
    Console.WriteLine("Не передано параметров при запуске приложения");
}

if (args.Length > 0 && args[0] == "--path")
{
    Console.WriteLine("Набор параметров корректный");
}

if (args.Length < 1 || args[0] != "--path")
{
    Console.WriteLine("Набор параметров некорректный");
}

// Запрашиваем ввод значения пользователем через консоль
Console.WriteLine("Please, enter a number");
var input = Console.ReadLine();

// Пробуем парсить введённое значение как число типа int.
// Если удалось распарсить, метод TryParse вернёт true, а результат парсинга сохранится в переменную number.
if (int.TryParse(input, out var number))
{
    Console.WriteLine($"Input has successfully parsed as {number}");
}
else // если число распарсить не удалось (TryParse вернул false), попадём в эту ветку
{
    Console.WriteLine("Input is not a valid number");
}

Console.WriteLine("Please, enter a FizzBuzz number");

// Пользуемся более "опасной" версией метода парсинга числа из строки - int.Parse. В отличии от TryParse,
// этот метод вернет результат парсинга, если введено корректное число, либо упадёт с исключением в обратном случае.
var fizzBuzzValue = int.Parse(Console.ReadLine() ?? string.Empty);
if (fizzBuzzValue % 15 == 0)
{
    Console.WriteLine("FizzBuzz");
}
else if (fizzBuzzValue % 3 == 0)
{
    Console.WriteLine("Fizz");
}
else if(fizzBuzzValue % 5 == 0)
{
    Console.WriteLine("Buzz");
}
else
{
    Console.WriteLine("Not an interesting number");
}

// ЗАДАНИЕ - написать консольное приложение, определяющее по введённому номеру дня от 1 до 7,
// является ли этот день рабочим или выходным. Использовать 5-дневную рабочую неделю.

