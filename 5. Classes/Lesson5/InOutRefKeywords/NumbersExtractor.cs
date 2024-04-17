using System.Text.RegularExpressions;

namespace InOutRefKeywords
{
    internal class NumbersExtractor
    {
        public static bool TryExtract(string source, out long[] numbers)
        {
            numbers = [];
            
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(source);

            if (matches.Count == 0)
            {
                return false;
            }

            numbers = matches
                .Select(ParseMatch)
                .OfType<long>()
                .ToArray();

            return true;

            static long? ParseMatch(Match match)
            {
                if (long.TryParse(match.Value, out var longVal))
                {
                    return longVal;
                }

                return null;
            }
        }
    }
}
