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

        [JsonPropertyName("terminal_id")]
        public TerminalInfoDto? TerminalInfo { get; init; }

        [JsonPropertyName("travel_card_id")]
        public TravelCardInfoDto TravelCardInfo { get; init; }

        public static TripInfoDto FromEntity(Trip tripEntity)
        {
            return new TripInfoDto
            {
                Id = tripEntity.Id,
                TripDate = tripEntity.TripDate,
                TerminalInfo = TerminalInfoDto.FromEntity(tripEntity.Terminal),
                TravelCardInfo = TravelCardInfoDto.FromEntity(tripEntity.TravelCard),
            };
        }
    }
}