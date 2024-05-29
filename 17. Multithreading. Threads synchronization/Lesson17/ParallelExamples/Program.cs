using BenchmarkDotNet.Running;
using ParallelExamples;

DealWithParallelInvoke();
// await DealWithParallelForEach();

void DealWithParallelInvoke()
{
    var actions = new[]
    {
        () => Action("one"),
        () => Action("two"),
        () => Action("three"),
        () => Action("four"),
        () => Action("five"),
        () => Action("six"),
        () => Action("seven"),
        () => Action("eight"),
    };

    Invoke(1);
    Invoke(2);
    Invoke(4);
    Invoke(Environment.ProcessorCount);

    void Invoke(int coresNumber)
    {
        Console.WriteLine($"\n{coresNumber} core(s)");
        Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = coresNumber}, actions);
    }

    void Action(string message)
    {
        Console.WriteLine($"{message}: {Environment.CurrentManagedThreadId}, {ThreadPool.ThreadCount} threads in pool");
        // Thread.Sleep(500);
    }
}

async Task DealWithParallelForEach()
{
    new Traversal().TraverseSequentially();
    new Traversal().TraverseInParallel();
    new Traversal().TraverseInDeepParallel();
    new Traversal().TraverseInDeepParallelWithOversizeThreadPool();
    await new Traversal().TraverseInDeepParallelAsync();
    
    // BenchmarkRunner.Run<Traversal>();
}







