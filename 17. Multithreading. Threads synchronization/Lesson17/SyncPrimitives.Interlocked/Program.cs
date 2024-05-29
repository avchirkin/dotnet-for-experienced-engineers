await BadIncrement();
// await BetterIncrement();
// await Exchange();
// Exchange();
// CompareExchange();

// Некорректный способ инкремента для многопоточного окружения
// Конкурирующие потоки могут прочитать "частично измененное" значение
async Task BadIncrement()
{
    int counter = 0;
    var tasks = new Task[10_000];
    for (var step = 0; step < 10_000; step++)
    {
        tasks[step] = Task.Run(() => counter++);
    }
    
    await Task.WhenAll(tasks);
    
    Console.WriteLine(counter); // ?
}

// Атомарный инкремент - конкурирующие потоки не увидят "частично измененного" значения
async Task BetterIncrement()
{
    var counter = 0;
    var tasks = new Task[10_000];
    for (var step = 0; step < 10_000; step++)
    {
        tasks[step] = Task.Run(() => Interlocked.Increment(ref counter));
    }

    await Task.WhenAll(tasks);
    
    Console.WriteLine(counter); // ?
}

// Атомарная замена значения - конкурирующие потоки не увидят "частично измененные" данные
void Exchange()
{
    int x = 0;
    int y = 42;

    int oldX = Interlocked.Exchange(ref x, y);
    Console.WriteLine("x до изменения: {0}, x после изменения: {1}", oldX, x);
}

// Атомарная замена значения с проверкой исходного значения на равенство компаранду
// "eсли всё ещё X = 0, то поменяй его значение на Y" 
void CompareExchange()
{
    int x = 0;
    int y = 42;

    int oldX = Interlocked.CompareExchange(ref x, y, 0);
    Console.WriteLine("x до изменения: {0}, x после изменения: {1}", oldX, x);
}