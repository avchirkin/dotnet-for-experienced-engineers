using System.Text.Json.Serialization;

namespace TravelCardProject.Models
{
    public sealed record NewTripDto
    {
        [JsonPropertyName("terminal_id")]
        public Guid TerminalId { get; init; }

        [JsonPropertyName("travel_card_id")]
        public Guid TravelCardId { get; init; }
    }
}
