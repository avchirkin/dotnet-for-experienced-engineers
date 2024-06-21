using System.Text.Json.Serialization;

namespace TravelCardProject.Models
{
    public sealed record NewPassengerDto
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = default!;
    }
}
