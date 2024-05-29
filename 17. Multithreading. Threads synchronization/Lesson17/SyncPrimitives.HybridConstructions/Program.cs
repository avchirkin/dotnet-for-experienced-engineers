// 1. Monitor
DealWithMonitor();

// 2. lock - "синтаксический сахар" для Monitor
DealWithLock();

void DealWithMonitor()
{
    var locker = new object();
    var list = new List<int>();

    var cts = new CancellationTokenSource(3_000);
    var token = cts.Token;
    
    var actions = new Action[10_000];
    Array.Fill(actions, () =>
    {
        using (token.Register(() => token.ThrowIfCancellationRequested()))
        {
            Monitor.Enter(locker);
            list.Add(DateTime.Now.Millisecond);
            // throw new Exception();
            Monitor.Exit(locker);
        }
    });
    
    Parallel.Invoke(actions);
    
    Console.WriteLine(list.Count);
}

void DealWithLock()
{
    var locker = new object();
    var list = new List<int>();

    var actions = new Action[100_000];
    Array.Fill(actions, () =>
    {
        lock (locker)
        {
            list.Add(DateTime.Now.Millisecond);
        }
    });
    
    Parallel.Invoke(actions);
    
    Console.WriteLine(list.Count);
}