namespace DateTimeBasics;

public class TimeSpanExamples
{
    public void Run()
    {
        var dateOne = DateTime.Parse("2024-01-01 15:00:00");
        var dateTwo = DateTime.Parse("2024-01-02 17:30:00");

        // TimeSpan представляет собой временной интервал
        TimeSpan ts = dateTwo - dateOne;
        
        // Декомпозированный по единицам времени интервал между двумя моментами времени
        Console.WriteLine(ts.Days); // 1 полный день между двумя моментами
        Console.WriteLine(ts.Hours); // 2 полных часа
        Console.WriteLine(ts.Minutes); // 30 полных минут
        Console.WriteLine(ts.Seconds); // 0 секунд
        
        // Общее количество времени между двумя моментами
        Console.WriteLine(ts.TotalHours); // 26.5 часов
        Console.WriteLine(ts.TotalMinutes); // 1590 минут

        // Создание интервала заданного размера
        var twoDays = TimeSpan.FromDays(2);
        var twoDaysAfter = dateOne + twoDays; // Оператор + перегружен, можно сложить DateTime и TimeSpan
        Console.WriteLine(twoDaysAfter); // 03.01.2024 15:00:00
        
        // TimeSpan можно добавлять к дате с помощью метода Add
        var fourDaysAfter = dateOne.Add(TimeSpan.FromDays(4));
        Console.WriteLine(fourDaysAfter); // 05.01.2024 15:00:00
    }
}