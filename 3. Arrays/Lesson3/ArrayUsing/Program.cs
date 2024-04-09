
// ПРИМЕР - базовая функциональность массивов
int[] numbers = new int[5];

numbers[0] = 42;
numbers[1] = 23;
numbers[2] = 89;
// numbers[5] = 13; // ошибка IndexOutOfRangeException в рантайме - не существует элемента с индексом 5

// ВОПРОС - что выведется для элементов с индексами 3 и 4?
Console.WriteLine("Вывод массива с помощью цикла for");
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

Console.ReadLine();

Console.WriteLine("\nВывод массива с помощью цикла while");
var enumerator = numbers.GetEnumerator();
while(enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

Console.ReadLine();

Console.WriteLine("\nВывод массива с помощью цикла foreach");
foreach (int num in numbers)
{
    Console.WriteLine(num);
}

Console.ReadLine();

// ПРИМЕР - Упрощённая инициализация массива
Console.WriteLine("\nВывод массива - простая инициализация");

var anotherNumbers = new[] { 1, 17, 74, 23, 95 };
foreach (var number in anotherNumbers)
{
    Console.WriteLine(number);
}

Console.ReadLine();

// ПРИМЕР - Ещё более упрощённая форма инициализации
Console.WriteLine("\nВывод массива - ещё более простая инициализация");

anotherNumbers = [15, 26, 38, 91, 40];
foreach (var number in anotherNumbers)
{
    Console.WriteLine(number);
}

Console.ReadLine();
