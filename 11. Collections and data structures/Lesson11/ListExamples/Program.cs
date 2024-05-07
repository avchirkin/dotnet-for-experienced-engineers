// 1. Инициализация списка
var listOne = new List<string>();
listOne.Add("one");
listOne.Add("two");
listOne.Add("three");
PrintList(listOne);

// Упрощенная инициализация
listOne = new List<string>
{
    "one", "two", "three"
};

// Ещё более лаконичная форма инициализации
listOne = ["one", "two", "three"];

// Создание нового экземпляра списка на основании имеющегося
var listTwo = new List<string>(listOne);
PrintList(listTwo);

// 2. Работа со списком

// Слияние двух списков
List<string> listThree = ["four", "five"];
listOne.AddRange(listThree);
PrintList(listOne);

// Проверка наличия элемента в списке по значению
Console.WriteLine(listOne.Contains("one")); // true

// Проверка наличия элемента в списке по предикату
Console.WriteLine(listOne.Exists(item => item.StartsWith("fo"))); // true

// Поиск элемента по предикату
Console.WriteLine(listOne.Find(item => item.StartsWith("fo"))); // four

// Удаление элемента из списка
listOne.Remove("one");
Console.WriteLine(listOne.Contains("one")); // false

// Вставка элемента в список по индексу
listOne.Insert(1, "middle");
PrintList(listOne);

// Очистка списка
listOne.Clear();
PrintList(listOne);

void PrintList<T>(List<T> list)
{
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}

// Complexity (average)
// Add - O(1)
// Insert - O(n)
// Contains - O(n)
// Remove - O(n)