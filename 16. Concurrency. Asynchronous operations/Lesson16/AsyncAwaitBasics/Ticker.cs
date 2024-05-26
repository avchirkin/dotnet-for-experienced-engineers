namespace AsyncAwaitBasics;

public class Ticker
{
    // Ключевое слово async говорит компилятору о том, что в методе присутствует асинхронная операция
    public async Task TickUntil(TimeSpan period, int delay)
    {
        Console.WriteLine($"Started on thread {Environment.CurrentManagedThreadId}");
        
        var tickUntil = DateTime.Now.Add(period);
        while (tickUntil >= DateTime.Now)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine($"Thread ID before await: {Environment.CurrentManagedThreadId}");
            // Ключевое слово await указывает на то, что операция должна выполниться асинхронно
            await Task.Delay(delay);
            Console.WriteLine($"Thread ID after await: {Environment.CurrentManagedThreadId}\n");
        }
        
        Console.WriteLine($"Finished on thread {Environment.CurrentManagedThreadId}");
    }
}