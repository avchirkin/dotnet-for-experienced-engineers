using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ParallelLinqExamples;

[SimpleJob(RuntimeMoniker.Net80, launchCount: 3, warmupCount: 2, iterationCount: 5)]
[MemoryDiagnoser]
public class Summator
{
    private readonly IEnumerable<int> _numbers = Enumerable.Range(0, 1_000_000);
    
    [Benchmark]
    public void MaxSequential()
    {
        _ = _numbers.Max();
    }
    
    [Benchmark]
    public void MaxParallel()
    {
        _ = _numbers.AsParallel().Max();
    }
}