namespace DelegatesAsMethodParameters;

public sealed class Calculator
{
    public delegate T CalculateDelegate<T>(T first, T second);
    
    public T Calculate<T>(CalculateDelegate<T> expression, T first, T second)
    {
        return expression(first, second);
        // return expression.Invoke(first, second); // Аналогично первому вызову
    }
}