namespace TravelCardProject.Entities
{
    public record Terminal
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        // Тип транспорта, в котором терминал
        public TransportType TransportType { get; init; }

        public IEnumerable<Trip> Trips { get; init; } = default!;
    }
}
