using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record PassengerInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = default!;

        public static PassengerInfoDto FromEntity(Passenger passengerEntity)
        {
            return new PassengerInfoDto
            {
                Id = passengerEntity.Id,
                Name = passengerEntity.Name,
            };
        }
    }
}
