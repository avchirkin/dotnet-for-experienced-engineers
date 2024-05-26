// Одни из наиболее часто используемых типов значений - базовые численные типы данных, типы bool и DateTime 

using ValueTypesBasics;

Console.WriteLine(typeof(int).IsValueType); // true
Console.WriteLine(typeof(bool).IsValueType); // true
Console.WriteLine(typeof(DateTime).IsValueType); // true

// У каждого значимого типа есть "значение по умолчанию", отличное от null (в отличии от ссылочных типов)
int intVal = default;
Console.WriteLine(intVal); // 0

bool boolVal = default;
Console.WriteLine(boolVal); // false

DateTime dt = default;
Console.WriteLine(dt); // 01.01.0001 00:00:00

// Дефолтные значения для экземпляров значимых типов никогда не равны null
SimpleStruct st = default;
// Console.WriteLine(st == null); // Ошибка компиляции

// Свойства дефолтных экземпляров структур имеют дефолтные значения
Console.WriteLine(st.Counter); // 0
Console.WriteLine(st.Description == null); // true
Console.WriteLine(st.DefaultName); // "Default Name" - свойство инициализируется при создании экземпляра структуры

var simple1 = new SimpleStruct {Counter = 1, Description = "Simple!"};
var simple2 = new SimpleStruct {Counter = 1, Description = "Simple!"};

// Для пользовательских значимых типов не определен оператор равенства
// Console.WriteLine(simple1 == simple2); // Ошибка компиляции
Console.WriteLine(simple1.Equals(simple2)); // true - экземпляры структуры имеют одинаковые значения свойств

var equatable1 = new EquatableStruct { Counter = 1, Description = "Equatable!" };
var equatable2 = new EquatableStruct { Counter = 1, Description = "Equatable!" };
Console.WriteLine(equatable1 == equatable2); // true - оператор == определен явно

int intVal2 = 41;
int intVal3 = 42;
Console.WriteLine(intVal2 == intVal3); // Предупреждение компилятора - значения сравниваются до фактической компиляции