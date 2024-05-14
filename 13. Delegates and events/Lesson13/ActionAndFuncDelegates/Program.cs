// 1. Actions

// Создаём экземпляр Action через синтаксис MethodGroup

using ActionAndFuncDelegates;
using Microsoft.VisualBasic;

var printAction = new Action<string>(Console.WriteLine);
printAction("Hey!"); // Hey!

// Создаём экземпляр Action через синтаксис анонимного метода
var printActionTwo = (string message) => Console.WriteLine(message);
printActionTwo("Hey again!"); // Hey again!

// Action с двумя параметрами
var printActionThree = (DateTime dt, string message) => Console.WriteLine($"{dt}: {message}");
printActionThree(DateTime.Now, "Great moment of your life!"); // Great moment of your life!


// 2. Functions

// Последний generic-типа - всегда тип возвращаемого значения, остальные - типы параметров

var currDateAsString = new Func<string>(() => DateTime.Now.ToString("f"));
var currDateTime = currDateAsString();
Console.WriteLine(currDateTime); // Tuesday, 14 May 2024 12:22

var powFunc = new Func<int, double>(Pow);
var powOf3 = powFunc(3);
Console.WriteLine(powOf3); // 9

// Функции также можно создавать через анонимные методы 
var sumFunc = (int first, int second) => (double)first + second;
var sum = sumFunc(4, 5);
Console.WriteLine(sum); // 9

// Явное создание экземпляра функции с передачей анонимного метода в качестве параметра
sumFunc = new Func<int, int, double>((first, second) => first + second);
sum = sumFunc(10, 15);
Console.WriteLine(sum); // 25

// 3. Action и Func как аргументы

var formatter = new ExpressionFormatter();
var result = formatter.Format(
    (first, second) => $"{first} + {second}",
    (first, second) => first + second,
    4,
    6);
Console.WriteLine(result); // 4 + 6 = 10

double Pow(int number)
{
    return number * number;
}
