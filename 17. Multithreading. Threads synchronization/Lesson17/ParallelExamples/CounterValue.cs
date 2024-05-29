namespace ParallelExamples;

public sealed class CounterValue<T>(T defaultValue)
{
    public T Value = defaultValue;
}