var timeUntil = DateTime.Parse(args[0]);
while (DateTime.Now <= timeUntil)
{
    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
    Thread.Sleep(1_000);
}