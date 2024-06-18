using System.Text.Json;
using Tickets.Application.Models;

namespace Tickets.Integrations.Tariffs;

public sealed class TariffsServiceClient(IHttpClientFactory httpClientFactory) : ITariffsServiceClient
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("tariffs");
    
    public async Task<TariffInfoDto?> GetTariffInfo(Guid id)
    {
        using var response = await _client.GetAsync($"tariffs/{id}");
        using var content = response.Content;

        return await JsonSerializer.DeserializeAsync<TariffInfoDto>(await content.ReadAsStreamAsync());
    }
}