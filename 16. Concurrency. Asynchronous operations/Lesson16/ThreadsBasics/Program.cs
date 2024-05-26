// Поток (Thread) - это абстракция, представляющая часть исполняемого процесса. Каждый поток имеет свою собственную
// память, стек исполнения и контекст.

// 1. Создание потока из кода
var mainThread = Thread.CurrentThread;
Console.WriteLine($"Main thread ID: {mainThread.ManagedThreadId}");

// 1. Создание потока через конструктор
var threadOne = new Thread(() =>
{
    Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}");
    Thread.Sleep(2_000);
});
Console.WriteLine(threadOne.ThreadState); // Unstarted
Console.WriteLine($"threadOne is ThreadPool thread: {threadOne.IsThreadPoolThread}"); // false

// Запускаем поток на выполнение
threadOne.Start();
Console.WriteLine(threadOne.ThreadState); // Running

// Дожидаемся завершения потока
threadOne.Join();
Console.WriteLine(threadOne.ThreadState); // Stopped

Console.ReadLine();

// 2. Создание потока через ThreadPool
Console.WriteLine("\nUsing ThreadPool");
var threadTwoHasStarted = ThreadPool.QueueUserWorkItem(_ =>
{
    Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"threadTwo is ThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}"); // true
    Thread.Sleep(2_000);
});

if (threadTwoHasStarted)
{
    Console.WriteLine("threadTwo has started");
    Thread.Sleep(2_000);
}
