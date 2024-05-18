// 1. System.Tuple - это ссылочный тип данных, представляющий из себя легковесный контейнер для хранения данных.
// Tuple - иммутабельный (экземпляры не могут быть изменены после создания).

Tuple<int, string> pair = new (42, "magic number");
Console.WriteLine(pair.Item1); // 42
Console.WriteLine(pair.Item2); // magic number

// pair.Item1 = 56; // Ошибка компиляции - Item1 has no setter


// 2. System.ValueTuple - это значимый тип данных, схожий с System.Tuple, но поддерживающий именованные члены и деконструкцию.
// ValueTuple - мутабельная структура, поэтому его члены можно менять после создания экземпляра.

// Объявление и инициализация ValueTuple
(float, float) coordinates = (54.46f, 35.89f);

// Деконструкция экземпляра ValueTuple
var (x, y) = coordinates;
Console.WriteLine($"X: {x}, Y: {y}"); // "X: 54.46, Y: 35.89"

// Допустимо опускать тип переменной
var idAndName = (134, "Stepan");
Console.WriteLine($"Id: {idAndName.Item1}, name: {idAndName.Item2}"); // "Id: 134, name: Stepan"

// Члены кортежа можно именовать
(int Id, string Name) employee = (73, "Vladimir");
Console.WriteLine($"Id: {employee.Id}, name: {employee.Name}"); // "Id: 73, name: Vladimir"

// Можно переприсвоить переменной кортежа значение (кортеж справа должен совпадать по структуре)
employee = (45, "Sergey");
Console.WriteLine($"Id: {employee.Id}, name: {employee.Name}"); // "Id: 45, name: Sergey"

// Можно указать имена членов кортежа в правой части
var stats = (Points: 80, Position: 3);
Console.WriteLine($"Points: {stats.Points}, position: {stats.Position}"); // Points: 80, position: 3

// Поддерживается конструкция with
stats = stats with { Points = 83 };

// Кортежи поддерживают операторы == и !=. Равенство определяется НЕ по именам членов кортежа, а по их позициям
var t1 = (First: 24, Second: 67, Third: 99);

var t2 = (X: 24, Y: 67, Z: 99);
Console.WriteLine(t1 == t2); // true

t1 = (X: 0, Y: 1, Z: 2);
Console.WriteLine(t1.First); // Допустимо, новые имена для членов будут проигнорированы

var t3 = (24, 67, 100);
Console.WriteLine(t1 == t3); // false

var t4 = (1, "test");
var t5 = ("test", 1);
var t6 = (2, "test");
// Console.WriteLine(t4 == t5); // Ошибка компиляции
Console.WriteLine(t4 == t6); // false

// Кортежи можно использовать как параметры и типы возвращаемого значения в методах
var result = Multiple((4, 8), 2);
Console.WriteLine(result); // (8, 16)

(int First, int Second) Multiple((int First, int Second) input, int multiplier)
{
    return (input.First * multiplier, input.Second * multiplier);
}

// Пример - алиасы для кортежей 


