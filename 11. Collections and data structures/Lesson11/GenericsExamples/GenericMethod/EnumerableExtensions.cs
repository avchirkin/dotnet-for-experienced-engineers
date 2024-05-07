namespace GenericsExamples.GenericMethod;

public static class EnumerableExtensions
{
    public static IEnumerable<T> FilterEmpty<T>(this IEnumerable<T> source)
    {
        return source.Where(item => item != null);
    }
    
    public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source)
    {
        var query = source.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key);

        foreach (var item in query)
        {
            yield return item;
        }
    }
}