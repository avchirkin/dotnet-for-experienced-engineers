using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ParallelExamples;

[SimpleJob(RuntimeMoniker.Net80, launchCount: 3, warmupCount: 2, iterationCount: 5)]
[MemoryDiagnoser]
public class Traversal
{
    private readonly string _root = $"/Users/{Environment.UserName}/Repos";
    
    [Benchmark]
    public void TraverseSequentially()
    {
        var dirInfo = new DirectoryInfo(_root);
        Console.WriteLine($"Analyzing directory {dirInfo.FullName}...");
        var counter = 0L;
        foreach(var child in dirInfo.GetDirectories())
        {
            Enumerate(child, ref counter);
        }
        Console.WriteLine($"{ThreadPool.ThreadCount} threads in pool");
        Console.WriteLine($"{counter} directories found in directory");
    }
    
    [Benchmark]
    public void TraverseInParallel()
    {
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        var dirInfo = new DirectoryInfo(_root);
        Console.WriteLine($"Analyzing directory {dirInfo.FullName}...");

        var counter = 0L;
        Parallel.ForEach(dirInfo.GetDirectories(), options, child =>
        {
            Enumerate(child, ref counter);
        });
        
        Console.WriteLine($"{ThreadPool.ThreadCount} threads in pool");
        Console.WriteLine($"{counter} directories found in directory");
    }
    
    [Benchmark]
    public void TraverseInDeepParallel()
    {
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        var dirInfo = new DirectoryInfo(_root);
        Console.WriteLine($"Analyzing directory {dirInfo.FullName}...");

        var counter = 0L;
        Parallel.ForEach(dirInfo.GetDirectories(), options, child =>
        {
            EnumerateInParallel(child, ref counter);
        });
        
        Console.WriteLine($"{ThreadPool.ThreadCount} threads in pool");
        Console.WriteLine($"{counter} directories found in directory");
    }
    
    [Benchmark]
    public async Task TraverseInDeepParallelAsync()
    {
        var dirInfo = new DirectoryInfo(_root);
        Console.WriteLine($"Analyzing directory {dirInfo.FullName}...");

        CounterValue<long> counter = new CounterValue<long>(0L);
        await Parallel.ForEachAsync(dirInfo.GetDirectories(),
            async (child, _) => await EnumerateInParallelAsync(child, counter));
        
        Console.WriteLine($"{ThreadPool.ThreadCount} threads in pool");
        Console.WriteLine($"{counter.Value} directories found in directory");
    }
    
    [Benchmark]
    public void TraverseInDeepParallelWithOversizeThreadPool()
    {
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        var dirInfo = new DirectoryInfo(_root);
        Console.WriteLine($"Analyzing directory {dirInfo.FullName}...");
        
        ThreadPool.SetMinThreads(1_000, 1_000);
        
        var counter = 0L;
        Parallel.ForEach(dirInfo.GetDirectories(), options, child =>
        {
            EnumerateInParallel(child, ref counter);
        });
        
        Console.WriteLine($"{ThreadPool.ThreadCount} threads in pool");
        Console.WriteLine($"{counter} directories found in directory");
    }
    
    void Enumerate(DirectoryInfo dir, ref long dirsCount)
    {
        var children = dir.GetDirectories();
        if (children.Length == 0)
        {
            return;
        }

        Interlocked.Add(ref dirsCount, children.Length);
        foreach (var child in children)
        {
            Enumerate(child, ref dirsCount);
        }
    }
    
    void EnumerateInParallel(DirectoryInfo dir, ref long dirsCount)
    {
        var children = dir.GetDirectories();
        if (children.Length == 0)
        {
            return;
        }

        Interlocked.Add(ref dirsCount, children.Length);

        long localCount = 0L;
        Parallel.ForEach(children, child =>
        {
            EnumerateInParallel(child, ref localCount);
        });

        Interlocked.Add(ref dirsCount, localCount);
    }
    
    async ValueTask EnumerateInParallelAsync(DirectoryInfo dir, CounterValue<long> dirsCount)
    {
        var children = dir.GetDirectories();
        if (children.Length == 0)
        {
            return;
        }
        
        Interlocked.Add(ref dirsCount.Value, children.Length);
        
        await Parallel.ForEachAsync(children,
            async (child, _) => await EnumerateInParallelAsync(child, dirsCount));
    }
}