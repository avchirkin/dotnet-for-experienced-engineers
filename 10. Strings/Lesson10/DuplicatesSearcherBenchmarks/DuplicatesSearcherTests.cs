using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DuplicatesSearcherBenchmarks;

[SimpleJob(RuntimeMoniker.Net80, launchCount: 5, warmupCount: 3, iterationCount: 5)]
[MemoryDiagnoser]
public class DuplicatesSearcherTests
{
    private const string TestString = "This is the test string with a lot of useless information. This is for test purposes!";
    private readonly char[] _searchChars = "es".ToCharArray();

    private readonly SpanBasedDuplicatesSearcher _spanBasedSearcher = new ();
    
    [Benchmark]
    public void SpanBasedSearch()
    {
        _ = _spanBasedSearcher.SearchDuplicatesNumber(TestString, _searchChars);
    }
}