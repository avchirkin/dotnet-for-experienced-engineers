// 1. Mutex
// DealWithMutex();

// 2. Semaphore
// DealWithSemaphore();

void DealWithMutex()
{
    var list = new List<int>();

    var actions = new Action[100_000];
    
    var mutex = new Mutex();
    
    Array.Fill(actions, () =>
    {
        mutex.WaitOne();
        list.Add(DateTime.Now.Millisecond);
        mutex.ReleaseMutex();
    });
    
    Parallel.Invoke(actions);
    
    Console.WriteLine(list.Count);
}

void DealWithSemaphore()
{
    var actions = new Action[100];
    
    var semaphore = new Semaphore(1, 1);
    // var semaphore = new SemaphoreSlim(5, 5); // гибридная альтернатива обычному Semaphore

    var counter = 0;
    Array.Fill(actions, () =>
    {
        semaphore.WaitOne();
        Console.WriteLine(++counter);
        Thread.Sleep(1_000);
        semaphore.Release();
    });
    
    Parallel.Invoke(actions);
}