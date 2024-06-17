using System.Text.Json.Serialization;
using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Models
{
    public sealed record TravelCardInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("number")]
        public string Number { get; init; }

        [JsonPropertyName("activation_date")]
        public DateTime ActivationDate { get; init; }

        [JsonPropertyName("expiration_date")]
        public DateTime? ExpirationDate { get; init; }

        [JsonPropertyName("status")]
        public TravelCardStatus Status { get; init; }

        [JsonPropertyName("account_id")]
        public AccountInfoDto? AccountInfo { get; init; }

        [JsonPropertyName("tariff_id")]
        public TariffInfoDto TariffInfo { get; init; }

        [JsonPropertyName("passenger_id")]
        public PassengerInfoDto PassengerInfo { get; init; }

        public static TravelCardInfoDto FromEntity(TravelCard travelCardEntity)
        {
            return new TravelCardInfoDto
            {
                Id = travelCardEntity.Id,
                Number = travelCardEntity.Number,
                ActivationDate = travelCardEntity.ActivationDate,
                ExpirationDate = travelCardEntity.ExpirationDate,
                Status = travelCardEntity.Status,
                AccountInfo = AccountInfoDto.FromEntity(travelCardEntity.Account),
                TariffInfo = TariffInfoDto.FromEntity(travelCardEntity.Tariff),
                PassengerInfo = PassengerInfoDto.FromEntity(travelCardEntity.Passenger),
            };
        }
    }
}