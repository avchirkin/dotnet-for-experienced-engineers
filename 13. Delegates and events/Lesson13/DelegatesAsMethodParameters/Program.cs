using DelegatesAsMethodParameters;

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