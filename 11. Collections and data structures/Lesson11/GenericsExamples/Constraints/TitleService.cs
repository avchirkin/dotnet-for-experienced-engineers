namespace GenericsExamples.Constraints;

public sealed class TitleService
{
    public static string CreateTitle<T>(T item) where T : INamedItem
    {
        return $"{item.Name} - {item.Description}";
    }
}