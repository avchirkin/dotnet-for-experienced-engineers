Console.WriteLine("Hello from tip-level statements example project!");

if (args.Count() != 2)
{
    Console.WriteLine("Неверное количество параметров!");
    return;
}

var name = args[0];
var greeting = args[1];

Console.WriteLine($"{name}, {greeting}!");
