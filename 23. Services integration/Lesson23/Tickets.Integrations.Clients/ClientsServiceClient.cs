using System.Text.Json;
using Tickets.Application.Models;

namespace Tickets.Integrations.Clients;

public sealed class ClientsServiceClient(IHttpClientFactory httpClientFactory) : IClientsServiceClient
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("clients");
    
    public async Task<ClientInfoDto?> GetClientInfo(Guid id)
    {
        using var response = await _client.GetAsync($"clients/{id}");
        using var content = response.Content;

        return await JsonSerializer.DeserializeAsync<ClientInfoDto>(await content.ReadAsStreamAsync());
    }
}