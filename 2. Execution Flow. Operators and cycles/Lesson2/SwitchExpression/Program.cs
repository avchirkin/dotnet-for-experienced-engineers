// оператор switch позволяет заменить конструкцию с множеством условий if-else.
 
// ПРИМЕР - определение рабочих и выходных дней с помощью оператора switch
Console.WriteLine("Введите номер дня в неделе");
var dayNumber = int.Parse(Console.ReadLine()
    ?? throw new InvalidOperationException("Введите целое число от 1 до 7"));

switch(dayNumber) // значение, с которым будем сравнивать
{
    // Каждый вариант дня отражен в отдельном блоке case
    case 1:
        Console.WriteLine("Понедельник, рабочий"); // внутри блока описываем необходимую логику
        break; // если нашли нужное совпадение, останавливаем работу оператора switch
    case 2:
        Console.WriteLine("Вторник, рабочий");
        break;
    case 3:
        Console.WriteLine("Среда, рабочий");
        break;
    case 4:
        Console.WriteLine("Четверг, рабочий");
        break;
    case 5:
        Console.WriteLine("Пятница, рабочий");
        break;
    case 6:
        Console.WriteLine("Суббота, выходной");
        break;
    case 7:
        Console.WriteLine("Воскресенье, выходной");
        break;
    default: // если не нашли совпадения, выбрасываем исключение
        throw new InvalidOperationException($"Введите номер дня от 1 до 7!");
}

// ПРИМЕР - группировка нескольких блоков case с одинаковой логикой
switch(dayNumber)
{
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        Console.WriteLine($"День {dayNumber} - рабочий");
        break;
    case 6:
    case 7:
        Console.WriteLine($"День {dayNumber} - выходной");
        break;
    default:
        throw new InvalidOperationException($"Введите номер дня от 1 до 7!");
}

// ЗАДАНИЕ - написать консольное приложение, определяющее чётность/нечётность введённого числа.

// НА БУДУЩЕЕ - вся мощь оператора switch раскрывается с помощью механизма pattern matching,
// который мы рассмотрим позже.
