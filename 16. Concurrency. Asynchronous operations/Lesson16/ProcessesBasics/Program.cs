using System.Diagnostics;

// Процесс - это запущенное приложение в ОС
var path = "./../../../../Ticker/bin/Release/net8.0/Ticker";

// 1. Создание и запуск процесса через путь к исполняемому файлу

var tickUntilArg = DateTime.Now.AddSeconds(10).ToString("HH:mm:ss");

var process = Process.Start(path, new[] { tickUntilArg });
Console.WriteLine($"New process ID: {process.Id}");
Thread.Sleep(10_000);

// 2. Создание и запуск процесса через ProcessStartInfo

tickUntilArg = DateTime.Now.AddSeconds(10).ToString("HH:mm:ss");
var startInfo = new ProcessStartInfo
{
    FileName = path,
    Arguments = tickUntilArg
};

process = Process.Start(startInfo);
Console.WriteLine($"New process ID: {process?.Id}");
Thread.Sleep(10_000);