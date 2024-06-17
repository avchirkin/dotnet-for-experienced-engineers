using System.Text.Json.Serialization;
using MediatR;

namespace CQRS.Features.Tickets.CreateTicket;

public sealed record CreateTicketCommand : IRequest<CreateTicketResponse>
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("client_id")]
    public Guid ClientId { get; init; }
    
    [JsonPropertyName("tariff_id")]
    public Guid TariffId { get; init; }
    
    [JsonPropertyName("account_id")]
    public Guid AccountId { get; init; }
}