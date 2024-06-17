using System.Text.Json.Serialization;
using Layered.Infrastructure.Entities;

namespace Layered.ApplicationCore.Models;

public sealed record TicketInfoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("client_info")]
    public ClientInfoDto? ClientInfo { get; init; }
    
    [JsonPropertyName("account_info")]
    public AccountInfoDto? AccountInfo { get; init; }
    
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
            ClientInfo = ClientInfoDto.FromEntity(ticketEntity.Client),
            AccountInfo = AccountInfoDto.FromEntity(ticketEntity.Account),
            TariffInfo = TariffInfoDto.FromEntity(ticketEntity.Tariff),
            IsActive = ticketEntity.IsActive
        };
    }
}