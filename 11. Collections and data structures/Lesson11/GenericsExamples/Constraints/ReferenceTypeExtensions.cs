namespace GenericsExamples.Constraints;

public static class ReferenceTypeExtensions
{
    public static IEnumerable<T> FilterNulls<T>(this IEnumerable<T?> source) where T: class
    {
        return source.Where(item => item != null).Cast<T>();
    }
}