using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ThreadPoolVsDirectThreadsUsing;

[SimpleJob(RuntimeMoniker.Net80, invocationCount: 3, iterationCount: 3, warmupCount: 2)]
[MemoryDiagnoser]
public class ThreadRunner
{
    [Benchmark]
    public void RunDirectly()
    {
        for (var counter = 0; counter < 100; counter++)
        {
            var thread = new Thread(() => Thread.Sleep(1_000));
            thread.Start();
        }
        
        Thread.Sleep(2_000);
    }
    
    [Benchmark]
    public void RunViaThreadPool()
    {
        for (var counter = 0; counter < 100; counter++)
        {
            ThreadPool.QueueUserWorkItem(_ => Thread.Sleep(1_000));
        }
        
        Thread.Sleep(2_000);
    }
}