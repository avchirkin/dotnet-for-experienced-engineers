using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TravelCardProject.Entities
{
    public record Account
    {
        public Guid Id { get; init; }
        public decimal Balance { get; set; }

        public TravelCard TravelCard { get; init; } = default!;
    }
}
