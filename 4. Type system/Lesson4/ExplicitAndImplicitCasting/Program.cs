
using ExplicitAndImplicitCasting;


// Преобразования ссылочных типов

object obj = new Student("Andrey"); // Implicit cast - приведение к базовому типу
// Student student = obj; // Ошибка! ВОПРОС - почему?
Student student = (Student)obj; // Explicit cast - явное приведение, в obj действительно лежит Student
Student? otherStudent = obj as Student; // Приведение с помощью оператора as

var str = "Some string";
// otherStudent = (Student)str; // Ошибка! Невозможно преобразовать String к Student даже с explicit cast
// otherStudent = str as Student; // Ошибка!
var explicitlyStringableStudent = (ExplicitlyStringableStudent)str; // Ок - переопределен оператор явного преобразования
str = (string)explicitlyStringableStudent; // Ок - переопределен оператор явного преобразования

var implicitlyStringableStudent = str; // Ок - переопределен оператор неявного преобразования
str = implicitlyStringableStudent; // Ок - переопределен оператор неявного преобразования


// Преобразования значимых типов

int intVal = 42;
long longVal = intVal; // Implicit cast - кладём значение "меньшего" типа в переменную "большего"

long smallLongVal = 1;
// int smallIntVal = smallLongVal; // Ошибка!
int smallIntVal = (int)smallLongVal; // Explicit cast - говорим компилятору, что значение "точно уместится"

long largeLongVal = 10_000_000_000L;
int largeIntVal = (int)largeLongVal; // Explicit cast. ВОПРОС - что произойдёт в рантайме?
Console.WriteLine(largeIntVal);
