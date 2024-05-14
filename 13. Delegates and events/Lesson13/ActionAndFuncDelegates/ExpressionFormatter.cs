namespace ActionAndFuncDelegates;

public sealed class ExpressionFormatter
{
    public string Format<T>(
        Func<T, T, string> formatFunc,
        Func<T, T, T> calcFunc,
        T first, T second)
    {
        var calcResult = calcFunc(first, second);
        var expression = formatFunc(first, second);

        return $"{expression} = {calcResult}";
    }
}