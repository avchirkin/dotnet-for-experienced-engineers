using System.Globalization;
using DelegatesBasics;

Console.ReadLine();

// Инициализация через конструктор
PrintDelegate printerOne = new PrintDelegate(PrintDateTime);
printerOne("message from printerOne");

Console.ReadLine();

// Инициализация через указание Method
printerOne = PrintMessage;
printerOne("message from printerOne");

Console.ReadLine();

// Делегаты можно объединять в цепочки
PrintDelegate? printerTwo = PrintDateTime;
printerTwo += PrintMessage;
printerTwo("message from printerTwo");

Console.ReadLine();

// Делегаты можно исключать из цепочки
printerTwo -= PrintMessage;
printerTwo?.Invoke("message from printer two");

void PrintDateTime(string message)
{
    Console.WriteLine($"{DateTime.Now.ToString("G", CultureInfo.CurrentCulture)}");
}

void PrintMessage(string message)
{
    Console.WriteLine(message);
}

// Объявление делегата
namespace DelegatesBasics
{
    internal delegate void PrintDelegate(string message);
}





