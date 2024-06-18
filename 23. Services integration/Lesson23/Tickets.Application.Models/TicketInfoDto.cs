using System.Text.Json.Serialization;
using Tickets.Domain.Models;

namespace Tickets.Application.Models;

public sealed record TicketInfoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("client_id")]
    public Guid ClientId { get; init; }
    
    [JsonPropertyName("client_info")]
    public ClientInfoDto? ClientInfo { get; init; }
    
    [JsonPropertyName("account_id")]
    public Guid AccountId { get; init; }
    
    [JsonPropertyName("account_info")]
    public AccountInfoDto? AccountInfo { get; init; }
    
    [JsonPropertyName("tariff_id")]
    public Guid TariffId { get; init; }
    
    [JsonPropertyName("tariff_info")]
    public TariffInfoDto? TariffInfo { get; init; }
    
    [JsonPropertyName("is_active")]
    public bool IsActive { get; init; }

    public static TicketInfoDto FromEntity(Ticket ticketEntity)
    {
        return new TicketInfoDto
        {
            Id = ticketEntity.Id,
            Name = ticketEntity.Name,
            ClientId = ticketEntity.ClientId,
            AccountId = ticketEntity.AccountId,
            TariffId = ticketEntity.TariffId,
            IsActive = ticketEntity.IsActive
        };
    }
}