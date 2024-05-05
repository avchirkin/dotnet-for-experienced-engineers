using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace StringBuilder;

[SimpleJob(RuntimeMoniker.Net80, iterationCount: 10, warmupCount: 3, launchCount: 3)]
[MemoryDiagnoser]
public class StringBuilderBenchmark
{
    [Benchmark]
    public double ConcatenateStrings()
    {
        var str = string.Empty;
        str += DateTime.Now.Hour;
        str += DateTime.Now.Minute;
        str += DateTime.Now.Second;
        str += DateTime.Now.Millisecond;
        str += DateTime.Now.Microsecond;
        str += DateTime.Now.Nanosecond;

        return str.Length;
    }
    
    [Benchmark]
    public double UseStringBuilder()
    {
        var sb = new System.Text.StringBuilder();
        sb.Append(DateTime.Now.Hour);
        sb.Append(DateTime.Now.Minute);
        sb.Append(DateTime.Now.Second);
        sb.Append(DateTime.Now.Millisecond);
        sb.Append(DateTime.Now.Microsecond);
        sb.Append(DateTime.Now.Nanosecond);

        return sb.ToString().Length;
    }
}