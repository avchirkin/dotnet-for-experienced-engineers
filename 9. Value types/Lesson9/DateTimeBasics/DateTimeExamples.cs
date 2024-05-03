namespace DateTimeBasics;

public class DateTimeExamples
{
    public void Run()
    {
        DateTime dt = default;
        Console.WriteLine(dt); // 01.01.0001 00:00:00 для en-RU

        var now = DateTime.Now;
        Console.WriteLine(now); // Текущее время (например, 02.05.2024 21:41:12)

        var utcNow = DateTime.UtcNow;
        Console.WriteLine(utcNow); // Текущее время по Coordinated Universal Time (UTC)

        // Парсинг даты из строки со значением CultureInfo по умолчанию
        var parsedDt = DateTime.Parse("2021-06-10 17:45:33");
        Console.WriteLine(parsedDt); // 10.06.2021 17:45:33

        _ = DateTime.TryParse("2023-12-15", out parsedDt);
        Console.WriteLine(parsedDt); // 15.12.2023 00:00:00
        
        // Форматированный вывод даты - только месяц и год
        var yearsAndMonths = DateTime.Now.ToString("MM-yyyy");
        Console.WriteLine(yearsAndMonths); // 02-2024

        // Полный формат даты-времени
        var fullDateTime = DateTime.Now.ToString("F");
        Console.WriteLine(fullDateTime); // Thursday, 2 May 2024 22:19:51

        // НА БУДУЩЕЕ - перегрузки методов Parse и TryParse, а также ToString в DateTime обладают мощными возможностями
        // форматирования парсинга и вывода даты и времени, в том числе - с учётом региональных настроек (см. п. 4 ДЗ)

        // Количество дней в указанном месяце указанного года
        var feb2024DaysNumber = DateTime.DaysInMonth(2024, 02);
        Console.WriteLine(feb2024DaysNumber); // 29
        
        // Проверка на високосный год
        Console.WriteLine(DateTime.IsLeapYear(2023)); // false
        Console.WriteLine(DateTime.IsLeapYear(2024)); // true

        // Прибавление-убавление времени
        var someDate = DateTime.Parse("2023-01-01");
        
        var twoDaysAfter = someDate.AddDays(2);
        Console.WriteLine(twoDaysAfter); // 03.01.2023 00:00:00

        var twoDaysBefore = someDate.AddDays(-2);
        Console.WriteLine(twoDaysBefore); // 30.12.2022 00:00:00
    }
}