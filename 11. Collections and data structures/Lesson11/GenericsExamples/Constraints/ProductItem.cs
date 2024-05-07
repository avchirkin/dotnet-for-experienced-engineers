namespace GenericsExamples.Constraints;

public sealed record ProductItem(string Name, string Description) : INamedItem;