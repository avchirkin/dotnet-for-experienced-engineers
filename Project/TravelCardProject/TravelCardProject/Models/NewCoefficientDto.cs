using System.Text.Json.Serialization;

namespace TravelCardProject.Models
{
    public sealed record NewCoefficientDto
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("value")]
        public double Value { get; init; }

        [JsonPropertyName("duration_minutes")]
        public int? DurationMinutes { get; init; }
    }
}
