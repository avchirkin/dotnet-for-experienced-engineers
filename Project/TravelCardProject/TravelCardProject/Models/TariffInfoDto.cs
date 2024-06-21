using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record TariffInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = default!;

        [JsonPropertyName("duration")]
        public int? Duration { get; init; }

        [JsonPropertyName("underground_trip_price")]
        public decimal UndergroundTripPrice { get; init; }

        [JsonPropertyName("ground_trip_price")]
        public decimal GroundTripPrice { get; init; }

        public static TariffInfoDto FromEntity(Tariff tariffEntity)
        {
            return new TariffInfoDto
            {
                Id = tariffEntity.Id,
                Name = tariffEntity.Name,
                Duration = tariffEntity.Duration,
                UndergroundTripPrice = tariffEntity.UndergroundTripPrice,
                GroundTripPrice = tariffEntity.GroundTripPrice,
            };
        }
    }
}
