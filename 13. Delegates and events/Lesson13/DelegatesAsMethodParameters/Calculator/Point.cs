namespace DelegatesAsMethodParameters.Calculator;

public readonly struct Point
{
    public int X { get; init; }
    public int Y { get; init; }

    public override string ToString()
    {
        return $"X = {X}, Y = {Y}";
    }
}