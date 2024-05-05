using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Spans;

[SimpleJob(RuntimeMoniker.Net80, iterationCount: 5, warmupCount: 3, launchCount: 3)]
[MemoryDiagnoser]
public class SpanBenchmark
{
    [Params(1000)]
    public int N = 10;

    string? _names;
    int _index, _lastItemLength;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _names = "Vladimir,Pavel,Stanislav,Ivan,Nickolay";
        _index = _names.LastIndexOf(",",StringComparison.Ordinal);
        _lastItemLength = _names.Length - _index;
    }

    [Benchmark]
    public void Substring()
    {
        for(var i = 0; i < N; i++)
        {
            var data = _names!.Substring(_index + 1, _lastItemLength - 1);
            var matches = data == "Nickolay";
        }
    }

    [Benchmark]
    public void Split()
    {
        for(var i = 0; i < N; i++)
        {
            var data = _names!.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var matches = data[^1] == "Nickolay";
        }
    }
    
    [Benchmark]
    public void Span()
    {
        for(var i = 0; i < N; i++)
        {
            var data = _names!.AsSpan().Slice(_index + 1, _lastItemLength - 1);
            var matches = data is "Nickolay";
        }
    }
}