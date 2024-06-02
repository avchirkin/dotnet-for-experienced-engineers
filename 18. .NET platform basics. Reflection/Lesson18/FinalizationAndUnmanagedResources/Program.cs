using FinalizationAndUnmanagedResources;

// 1. Детерминированная (явная) финализация - вызов Dispose из кода
var m1 = new SqlConnectionsManager(1);
m1.Dispose();

// 2. Детерминированная (явная) финализация - вызов Dispose через оператор using
using (var m2 = new SqlConnectionsManager(2))
{
    var conn = new SqlConnection("local.db");
}

// 3. Детерминированная (явная) финализация - вызов Dispose через оператор using
UseDisposedManagerInstance();

// 4. Недетерминированная (неявная) финализация - CLR вызывает финализатор
UseNonDisposedManagerInstance();

GC.Collect();
GC.WaitForPendingFinalizers();

Console.ReadKey();

void UseNonDisposedManagerInstance()
{
    var m4 = new SqlConnectionsManager(4);
    var conn = m4.Open("local.db");
}

void UseDisposedManagerInstance()
{
    using var m3 = new SqlConnectionsManager(3);
}