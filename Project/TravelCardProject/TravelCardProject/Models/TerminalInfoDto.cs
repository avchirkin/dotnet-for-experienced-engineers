using System.Text.Json.Serialization;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Models
{
    public sealed record TerminalInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("transport_type")]
        public TransportType TransportType { get; init; }

        public static TerminalInfoDto FromEntity(Terminal terminalEntity)
        {
            return new TerminalInfoDto
            {
                Id = terminalEntity.Id,
                Name = terminalEntity.Name,
                TransportType = terminalEntity.TransportType,
            };
        }
    }
}
