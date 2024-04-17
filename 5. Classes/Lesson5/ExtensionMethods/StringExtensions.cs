namespace ExtensionMethods
{
    internal static class StringExtensions
    {
        // Extension-методы служат для расширения функциональности существующих типов.
        // Extension-метод должен быть статическим и определенным в статическом классе.
        public static string Shorten(this string sourceString)
        {
            const int symbolsNumber = 3;
            return ShortenTo(sourceString, symbolsNumber);
        }

        public static string ShortenTo(this string sourceString, int symbolsNumber)
        {
            const int minLength = 5;

            if (sourceString.Length < minLength) return sourceString;
            return new string($"{sourceString[..symbolsNumber]}.");
        }
    }

    // ЗАДАНИЕ - написать extension-метод, делающий первую букву каждого слова заглавной. В качестве разделителя использовать пробел.
}
