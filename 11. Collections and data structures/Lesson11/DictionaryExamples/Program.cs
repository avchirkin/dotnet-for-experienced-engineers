// 1. Объявление и инициализация словаря
var employees = new Dictionary<int, string>();
employees.Add(1, "Anton Semenov"); // добавление через метод Add
employees[2] = "Arkadiy Stepanov"; // добавление по ключу
// employees.Add(2, "Gennadiy Volkov"); // Ошибка в рантайме - такой ключ уже добавлен
employees[2] = "Gennadiy Volkov"; // ОК - перезаписываем значение по ключу "2"

// Упрощённая инициализация словаря
var routes = new Dictionary<int, (string From, string To)>
{
    {117, ("Moscow", "Omsk")},
    {256, ("Saratov", "Kazan")},
    {439, ("Novosibirsk", "Astrakhan")},
};

// 2. Получение значения из словаря
var employee = employees[1];
Console.WriteLine(employee); // "Anton Semenov"

// employee = employees[3]; // Ошибка в рантайме - нет ключа "3" в словаре

// Проверка существования ключа
if (employees.ContainsKey(3))
{
    employee = employees[3];
}
else
{
    Console.WriteLine("Сотрудник не найден");
}

// Проверка существования ключа с использованием Try-семантики
if (!employees.TryGetValue(3, out employee))
{
    Console.WriteLine("Сотрудник не найден");
}

// Complexity (average)
// Add - O(1), O(n) if collision
// [] - O(1), O(n) if collision
// ContainsKey - O(1), O(n) if collision
// Remove - O(1), O(n) if collision