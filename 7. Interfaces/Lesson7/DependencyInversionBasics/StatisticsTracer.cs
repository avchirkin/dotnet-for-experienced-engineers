namespace DependencyInversionBasics;

public class StatisticsTracer
{
    // Для трассировщика неважно, какая именно сущность хочет залогировать свою статистику.
    // Конкретная реализация трассировщика абстрагирована от него посредством интерфейса ITraceable.
    public void Trace(ITraceable traceable)
    {
        traceable.Trace();
    }
}