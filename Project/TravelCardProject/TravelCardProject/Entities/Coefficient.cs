namespace TravelCardProject.Entities
{
    public record Coefficient
    {
        public Guid Id { get; init; }
        // Наименование коэффициента - для обращения к нему
        public string Name { get; init; }
        // Значение коэффициента
        public double Value { get; init; }
        // Длительность действия, если есть
        public int? DurationMinutes { get; init; }
    }
}
