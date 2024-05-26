// Task - это высокоуровневая абстракция "задания" - порции работы, которая должна быть выполнена.
// Данная абстракция используется как в контексте параллельного, так и асинхронного выполнения

// 1. Создание и запуск Task напрямую
// DealWithTasksCreation();

// 2. Работа с несколькими задачами
// DealWithMultipleTasks();

// 3. Создание и запуск задач с помощью TaskFactory
// DealWithTaskFactory();

// 4. Дочерние и родительские задачи
// DealWithDetachedTasks();
// DealWithAttachedTasks();

// 5. Цепочки задач
// DealWithContinuations();

// 6. Отмена выполнения задачи
// DealWithCancellation();

// 7. Возвращаемое значение задачи
// DealWithTaskResult();

void DealWithTasksCreation()
{
    Console.WriteLine($"Main thread ID: {Environment.CurrentManagedThreadId}");
    var taskOne = new Task(() =>
    {
        Console.WriteLine(DateTime.Now);
        Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}");
        Console.WriteLine($"Thread is ThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}"); // true
    });
    Console.WriteLine(taskOne.Status); // Created
    
    // Запускаем Task на исполнение
    taskOne.Start();
    Console.WriteLine(taskOne.Status); // WaitingToRun
    
    // Дожидаемся завершения
    taskOne.Wait();
    Console.WriteLine(taskOne.Status); // RanToCompleted

    // taskOne.Start(); // System.InvalidOperationException: Start may not be called on a task that has completed.
}

void DealWithMultipleTasks()
{
    var tasks = new Task[10];
    for (var counter = 0; counter < 10; counter++)
    {
        var id = counter;
        var task = new Task(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine($"Task ID: {id}");
        });
        task.Start();

        tasks[counter] = task;
    }
    
    Task.WaitAll(tasks);
    // Task.WaitAny(tasks); // Ожидаем не все задачи, а первую выполнившуюся
}

void DealWithTaskFactory()
{
    var tasks = new Task[10];
    for (var counter = 0; counter < 10; counter++)
    {
        var task = Task.Factory.StartNew(id =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine($"Task ID: {id}");
        }, counter);

        tasks[counter] = task;
    }
    
    Task.WaitAll(tasks);
}

void DealWithDetachedTasks()
{
    // Пример взят из статьи 
    // https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/attached-and-detached-child-tasks
    var parent = Task.Factory.StartNew(() =>
    {
        Console.WriteLine("Outer task executing.");

        var child = Task.Factory.StartNew(() => {
            // throw new Exception();
            Console.WriteLine("Nested task starting.");
            Thread.SpinWait(500000);
            Console.WriteLine("Nested task completing.");
        });
    });

    parent.Wait();
    Console.WriteLine("Outer has completed.");
}

void DealWithAttachedTasks()
{
    // Пример взят из статьи 
    // https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/attached-and-detached-child-tasks
    var parent = Task.Factory.StartNew(() =>
    {
        Console.WriteLine("Parent task executing.");
        var child = Task.Factory.StartNew(() => {
            //throw new Exception();
            Console.WriteLine("Attached child starting.");
            Thread.SpinWait(5000000);
            Console.WriteLine("Attached child completing.");
        }, TaskCreationOptions.AttachedToParent);
    });
    parent.Wait();
    Console.WriteLine("Parent has completed.");
}

void DealWithContinuations()
{
    var chain = Task.Run(() => Console.WriteLine("The first"))
        .ContinueWith(first => 
            Console.WriteLine($"The second on thread {Environment.CurrentManagedThreadId}"),
            TaskContinuationOptions.DenyChildAttach)
        .ContinueWith(second =>
            {
                Console.WriteLine($"The third on thread {Environment.CurrentManagedThreadId}");
                throw new Exception();
            },
            TaskContinuationOptions.OnlyOnRanToCompletion)
        .ContinueWith(third =>
            Console.WriteLine("The fourth"),
            TaskContinuationOptions.OnlyOnFaulted);

    chain.Wait();
}

void DealWithCancellation()
{
    try
    {
        var cts = new CancellationTokenSource(5_000);
        var token = cts.Token;
        var task = Task.Run(() =>
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    // Логика подготовки к завершению операции
                    // ..
                    token.ThrowIfCancellationRequested();
                }
                
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(1_000);
            }
        });

        task.Wait();
    }
    catch (AggregateException ex) when (ex.InnerException is TaskCanceledException tce)
    {
        Console.WriteLine(tce.Message);
    }
}

void DealWithTaskResult()
{
    var first = 3;
    var second = 5;
    
    // Проинициализировали, но не запустили задачу
    Task<int> sumTask = Task.Run(() => first + second);

    // Приводит к синхронному запуску задачи на выполнение
    var result = sumTask.Result;
    Console.WriteLine(result); // 8
}
