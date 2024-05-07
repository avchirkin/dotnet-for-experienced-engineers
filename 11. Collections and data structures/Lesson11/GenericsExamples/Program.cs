using GenericsExamples.Constraints;
using GenericsExamples.GenericMethod;
using GenericsExamples.GenericType;

// ПРИМЕР - Generic-тип

var intsStorage = new FixedStack<int>(4);
intsStorage.Put(13, 25, 42, 67);
Console.WriteLine(intsStorage.Get()); // 67
Console.WriteLine(intsStorage.Get()); // 42
Console.WriteLine(intsStorage.Get()); // 25
Console.WriteLine(intsStorage.Get()); // 13
// Console.WriteLine(intsStorage.Get()); // StorageIsEmptyException

var stringsStorage = new FixedStack<string>(3);
stringsStorage.Put("one", "two", "three");
Console.WriteLine(stringsStorage.Get()); // three
Console.WriteLine(stringsStorage.Get()); // two
Console.WriteLine(stringsStorage.Get()); // one
// Console.WriteLine(stringsStorage.Get()); // StorageIsFullException

// ПРИМЕР - Generic-метод
var names = new List<string?> {"Aleksey", "Aleksandr", null, "Vasiliy"};
var filteredNames = names.FilterEmpty();
foreach (var name in filteredNames)
{
    Console.WriteLine(name); 
}

var listWithDuplicates = new List<int> { 1, 3, 56, 17, 3, 24, 15, 56 };
var duplicates = listWithDuplicates.GetDuplicates();
foreach (var item in duplicates)
{
    Console.WriteLine(item); 
}

// ПРИМЕР - constraint на реализацию интерфейса
var product = new ProductItem("Sony Bravia", "Your best choice");
var location = new Location("Санкт-Петербург", "Северная столица");
var student = new Student("Владимир Иванов", "ЭТФ-123");

Console.WriteLine(TitleService.CreateTitle(product)); // "Sony Bravia - Your best choice"
Console.WriteLine(TitleService.CreateTitle(location)); // "Санкт-Петербург - Северная столица"
// Console.WriteLine(TitleService.CreateTitle(student)); // Ошибка! Student не реализует INamedItem

// ПРИМЕР - constraint на ссылочный тип
var students = new List<Student?> { student, null };
var filteredStudents = students.FilterNulls();
foreach (var st in filteredStudents)
{
    Console.WriteLine(st); 
}
