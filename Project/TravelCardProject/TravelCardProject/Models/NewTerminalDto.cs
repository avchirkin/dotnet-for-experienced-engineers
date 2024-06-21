using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record NewTerminalDto
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("transport_type")]
        public TransportType TransportType { get; init; }
    }
}
