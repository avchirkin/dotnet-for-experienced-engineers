
// ПРИМЕР - поиск элемента в массиве
var names = new[] { "Aleksandr", "Aleksey", "Vasiliy" };
Print(names, "Source array:");

Console.ReadLine();

var index = Array.IndexOf(names, "Aleksandr");
Console.WriteLine($"Index of 'Aleksandr' is {index}"); // 0

Console.ReadLine();

// ПРИМЕР - Инвертируем последовательность элементов в массиве
Array.Reverse(names);
Print(names, "Reversed array:");

Console.ReadLine();

// ЗАДАНИЕ - написать собственную реализацию метода Reverse - приложение, которое меняет порядок введённых пользователем символов на обратный

// ПРИМЕР - заполняем массив значением по умолчанию
var array = new int[10];
Array.Fill(array, 42);
Print(array, "Non-empty array:");

Console.ReadLine();

// ПРИМЕР - объединяем массивы копированием в массив большего размера
var smallArray = new int[] { 1, 2, 3, };
var anotherSmallArray = new int[] { 4, 5, };
var hugeArray = new int[10];

Array.Copy(smallArray, hugeArray, smallArray.Length);
Array.ConstrainedCopy(anotherSmallArray, 0, hugeArray, smallArray.Length, anotherSmallArray.Length);
Print(hugeArray, "Concatenated array:");

// ПРИМЕР - создание экземпляра массива с помощью статического метода Array.CreateInstance
var createdArray = (int[])Array.CreateInstance(typeof(int), 5);
Print(createdArray, "Created array:");

static void Print<T>(T[] array, string head)
{
    Console.WriteLine($"\n{head}");
    foreach (var item in array)
    {
        Console.Write(item);
        Console.Write(" ");
    }

    Console.WriteLine();
}