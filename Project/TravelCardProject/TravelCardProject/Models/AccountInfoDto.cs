using System.Text.Json.Serialization;
using TravelCardProject.Entities;

namespace TravelCardProject.Models
{
    public sealed record AccountInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; init; }

        public static AccountInfoDto FromEntity(Account accountEntity)
        {
            return new AccountInfoDto
            {
                Id = accountEntity.Id,
                Balance = accountEntity.Balance,
            };
        }
    }
}
