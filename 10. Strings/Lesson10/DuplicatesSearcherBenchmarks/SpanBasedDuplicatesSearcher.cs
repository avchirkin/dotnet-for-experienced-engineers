namespace DuplicatesSearcherBenchmarks;

public class SpanBasedDuplicatesSearcher
{
    public long SearchDuplicatesNumber(string source, char[] chars)
    {
        var span = source.AsSpan();
        var duplicatesNumber = 0L;
        SearchBySpan(span, chars, ref duplicatesNumber);

        return duplicatesNumber;
    }

    private void SearchBySpan(ReadOnlySpan<char> part, char[] chars, ref long duplicates)
    {
        var index = part.IndexOf(chars);
        if (index < 0)
        {
            return;
        }

        duplicates++;
        var tail = part[(index + 1)..];
        SearchBySpan(tail, chars, ref duplicates);
    }
}