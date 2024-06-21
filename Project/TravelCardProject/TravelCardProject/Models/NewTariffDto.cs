using System.Text.Json.Serialization;

namespace TravelCardProject.Models
{
    public sealed record NewTariffDto
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = default!;

        [JsonPropertyName("duration")]
        public int? Duration { get; init; }

        [JsonPropertyName("underground_trip_price")]
        public decimal UndergroundTripPrice { get; init; }

        [JsonPropertyName("ground_trip_price")]
        public decimal GroundTripPrice { get; init; }
    }
}
