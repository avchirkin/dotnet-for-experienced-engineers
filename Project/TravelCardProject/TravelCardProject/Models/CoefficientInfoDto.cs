using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record CoefficientInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("value")]
        public double Value { get; init; }

        [JsonPropertyName("duration_minutes")]
        public int? DurationMinutes { get; init; }

        public static CoefficientInfoDto FromEntity(Coefficient coefficientEntity)
        {
            return new CoefficientInfoDto
            {
                Id = coefficientEntity.Id,
                Name = coefficientEntity.Name,
                Value = coefficientEntity.Value,
                DurationMinutes = coefficientEntity.DurationMinutes,
            };
        }
    }
}
