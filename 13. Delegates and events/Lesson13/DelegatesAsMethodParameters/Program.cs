using DelegatesAsMethodParameters.Calculator;
using DelegatesAsMethodParameters.Handlers;

DealWithCalculatorExample();
DealWithPipelineExample();

void DealWithCalculatorExample()
{
    // 1. Calculator
    var calculator = new Calculator();

    // В качестве параметра типа делегата используем анонимный метод
    var intsSum = calculator.Calculate((first, second) => first + second, 12, 14);
    Console.WriteLine(intsSum);

    var pointOne = new Point {X = 1, Y = 3};
    var pointTwo = new Point {X = 2, Y = 5};

    // А здесь используем ссылку на имеющийся метод сложения точек
    var pointsSum = calculator.Calculate(SumPoints, pointOne, pointTwo);
    Console.WriteLine(pointsSum);

    Point SumPoints(Point first, Point second)
    {
        return new Point { X = first.X + second.X, Y = first.Y + second.Y };
    }
}

void DealWithPipelineExample()
{
    // 2. Delegate-based pipeline
    var handlerTypes = new []
    {
        typeof(ContextLogger),
        typeof(ContextEnricher),
        typeof(ContextLogger),
    };

    var steps = new Stack<RequestDelegate?>();
    foreach (var handlerType in handlerTypes)
    {
        _ = steps.TryPeek(out var next);
        var handler = CreateDelegate(handlerType, next);
        steps.Push(handler);
    }

    var request = new Request(Guid.NewGuid());

    var firstStep = steps.Peek();
    firstStep?.Invoke(request);

    RequestDelegate CreateDelegate(Type type, RequestDelegate? next = null)
    {
        var handler = (IRequestHandler?)Activator.CreateInstance(type, next);
        return req => handler?.Handle(req);
    }
}