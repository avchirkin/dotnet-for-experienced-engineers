using System.Collections.Concurrent;

// ConcurrentDictionary

DealWithDictionary();
// DealWithConcurrentDictionary();

void DealWithDictionary()
{
    var dictionary = new Dictionary<int, string>();

    var actions = new Action[100];
    var successCounter = 0;
    Array.Fill(actions, () =>
    {
        Thread.Sleep(100); // Имитация нагрузки
        if (dictionary.TryAdd(1, "Some text"))
        {
            Interlocked.Increment(ref successCounter);
        }
    });
    
    Parallel.Invoke(actions);
    
    Console.WriteLine($"{successCounter} successful addition(s) were performed");
}

void DealWithConcurrentDictionary()
{
    var dictionary = new ConcurrentDictionary<int, string>();

    var actions = new Action[100];
    var successCounter = 0;
    Array.Fill(actions, () =>
    {
        Thread.Sleep(100); // Имитация нагрузки
        if (dictionary.TryAdd(1, "Some text"))
        {
            Interlocked.Increment(ref successCounter);
        }
    });
    
    Parallel.Invoke(actions);
    
    Console.WriteLine($"{successCounter} successful addition(s) were performed");
}