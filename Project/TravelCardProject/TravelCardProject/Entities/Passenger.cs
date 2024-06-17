namespace TravelCardProject.Entities
{
    public record Passenger
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;

        public IEnumerable<TravelCard> TravelCards { get; init; } = default!;
    }
}
