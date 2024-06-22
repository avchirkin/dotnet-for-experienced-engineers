using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record NewTravelCardDto
    {
        [JsonPropertyName("number")]
        public string Number { get; init; }

        [JsonPropertyName("passenger_id")]
        public Guid PassengerId { get; init; }
    }
}
