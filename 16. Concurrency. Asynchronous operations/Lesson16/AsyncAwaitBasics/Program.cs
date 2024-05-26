using AsyncAwaitBasics;
using AsyncAwaitBasics.ProductItemsServiceExample;

await DealWithAsyncAwait();
// await DealWithSynchronousExecutionOfAsyncTask();
// await DealWithTaskResults();

async Task DealWithAsyncAwait()
{
    var ticker = new Ticker();

    // Запускаем асинхронную таску на основном потоке
    Console.WriteLine($"Starting await of ticker task on thread {Environment.CurrentManagedThreadId}...");

    var tickerTask = ticker.TickUntil(TimeSpan.FromSeconds(5), 1_000);
    await tickerTask;

    // Завершение асинхронной операции - поток зависит от параметра, переданного в ConfigureAwait
    Console.WriteLine($"Finished awaiting of ticker task on thread {Environment.CurrentManagedThreadId}");
}

Task DealWithSynchronousExecutionOfAsyncTask()
{
    var ticker = new Ticker();
    
    // Синхронное ожидание асинхронной задачи
    var anotherTickerTask = ticker.TickUntil(TimeSpan.FromSeconds(5), 1_000);
    anotherTickerTask.GetAwaiter().GetResult();
    // anotherTickerTask.RunSynchronously(); // Синонимично примеру выше
    
    return Task.CompletedTask;
}

async Task DealWithTaskResults()
{
    var service = new ProductItemsService();
    var productItems = await service.GetProducts();

    foreach (var item in productItems)
    {
        Console.WriteLine(item);
    }
}