using System.Text.Json.Serialization;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Models
{
    public sealed record TripInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("trip_date")]
        public DateTime TripDate { get; init; }

        [JsonPropertyName("terminal_name")]
        public string TerminalName { get; init; }

        [JsonPropertyName("travel_card_number")]
        public string TravelCardNumber {  get; init; }

        public static TripInfoDto FromEntity(Trip tripEntity)
        {
            return new TripInfoDto
            {
                Id = tripEntity.Id,
                TripDate = tripEntity.TripDate,
                TerminalName = TerminalInfoDto.FromEntity(tripEntity.Terminal).Name,
                TravelCardNumber = TravelCardInfoDto.FromEntity(tripEntity.TravelCard).Number,
            };
        }
    }
}