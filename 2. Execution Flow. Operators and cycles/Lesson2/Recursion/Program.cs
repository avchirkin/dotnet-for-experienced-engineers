// Рекурсией называется подход, при котором вместо использования цикла мы вызываем блок кода
// нужное количество раз изнутри самого блока.

// ПРИМЕР - рассчитаем степень числа с помощью рекурсии. 
Console.WriteLine("Введите число, которое нужно возвести в степень");
var number = int.Parse(Console.ReadLine()
    ?? throw new InvalidOperationException("Введите целое число"));

Console.WriteLine("Введите показатель степени");
var power = int.Parse(Console.ReadLine()
    ?? throw new InvalidOperationException("Введите целое число"));

var result = Power(number, power);
Console.WriteLine(result);

// НА БУДУЩЕЕ - метод является членом типа, определяемым пользователем для реализации фрагмента
// логики в изолированном контексте. Объявление метода включает опциональные модификаторы,
// тип возвращаемого значения, название метода и набор параметров в круглых скобках.
// Подробнее о методах мы поговорим на одном из следующих занятий.
static double Power(double value, int currentPower)
{
    if (currentPower == 1)
    {
        return value;
    }

    return value * Power(value, currentPower - 1);
}

// ЗАДАНИЕ - используя рекурсию, найти сумму чисел, введённых пользователем через пробел.
