using InOutRefKeywords;

var input = Console.ReadLine() ?? string.Empty;
if (NumbersExtractor.TryExtract(input, out var numbers))
{
    foreach(var number in numbers)
    {
        Console.WriteLine(number);
    }
}
else
{
    Console.WriteLine("No numbers found");
}

Console.ReadLine();

var pointProcessor = new PointProcessor();
var point = new Point { X = 0, Y = 0 };

pointProcessor.IncreasePoint(point);
Console.WriteLine($"X={point.X}, Y={point.Y}"); // ВОПРОС - что выведется на консоль?

pointProcessor.IncreasePoint(ref point);
Console.WriteLine($"X={point.X}, Y={point.Y}"); // ВОПРОС - что выведется на консоль?

Console.ReadLine();

pointProcessor.DoNothing(in point);


